using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Objects.Units;
using GXPEngine.Units;
using System;


public enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Falling,
    Climbing,
    OnTopOfLedder,
    OnRope
}
public class Player : Unit
{
    const int MAX_HEALTH = 3;
    int lifesLeft;
    int LifesLeft {
        get { return lifesLeft; }
        set {
            lifesLeft = value;


        }

    }

    Vector2 spawnPosition;

    private float _maxSpeed = 5;
    private float _jumpSpeed = -12;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        private set { _maxSpeed = value; }
    }
    public float JumpSpeed
    {
        get { return _jumpSpeed; }
        private set { _jumpSpeed = value; }
    }


    const float START_TIME = 1200 * 1000;
    float _time = 1200* 1000;
    float Timer {
        get { return _time; }
        set {
            if(value > 0)
            {
                _time = value;
            }
            else
            {
                _time = 0;
            }
            onUIUpdateHandler();
        }
    }


    const int START_SCORE = 2000;
    int _score = 2000;
    
    public int Score {
        get {
            return _score;
        }
        set {
            if (value >= 0)
            {
                if (value < _score) {
                    MyGame.Instance.sounds["Damage"].Play();
                    //game.
                }
                _score = value;
            }
            else {
                _score = 0;
            }
            onUIUpdateHandler();
        }
    }


    OnUIUpdate onUIUpdateHandler;
    delegate void OnUIUpdate();

    PlayerState currentState = PlayerState.Falling;
    public PlayerState CurrentState{
        get { return currentState; }
        set { currentState = value; }
    }

    const float FrameTimeMs = 250;
    float _speedX = 0;
    float _speedY = 0;

    float _climbingSpeed = 1;

    public Player(float x, float y) : base("PlayerSpriteSheet.png", 6, 1)
    {
        SetScaleXY(1f, 1f);
        SetXY(x, y);
        setupPlayer(x, y);
         onUIUpdateHandler += UpdateUI;
    }
    public Player() : base("PlayerSpriteSheet.png", 6, 1)
    {
        onUIUpdateHandler += UpdateUI;
    }

    void Update()
    {
        handleStates();
        updatePlayerPosition();
        handleLevelTransition();
        timerCountDown();

        if (Input.GetKeyUp(Key.R)) {
            RestartGame();
        }
    }

    void setupPlayer( float x, float y) {
        spawnPosition.x = x;
        spawnPosition.y = y;
        lifesLeft = MAX_HEALTH;
        _time = START_TIME;
        _score = START_SCORE;

    }
    void RestartGame() {
        if (LevelManager.Instance.ActiveLevelIndex != 0) {
            LevelManager.Instance.ActiveLevelIndex = 0;
            LevelManager.Instance.OpenLevel(0);
        }
        
        SetXY(spawnPosition.x, spawnPosition.y);
        lifesLeft = MAX_HEALTH;
        _time = START_TIME;
        _score = START_SCORE;
        UpdateHealthUI();

    }
    void timerCountDown() {
        Timer -= Time.deltaTime;
    }
    void OnCollision(GameObject collider)
    {
        var Enemy = collider as BoxEnemy;
        if (Enemy != null)
        {
        }
        if (collider is OnRopeTigger ) {
            if (currentState != PlayerState.Falling) {
                attachToRope(collider);
            }
        }
    }
    void handleLevelTransition() {
        if(CurrentState != PlayerState.OnRope) { 
            if (x < 10) {
                LevelManager.Instance.DisplayNextLevel(right:false);
                x = game.width - 12;
            } else if(x > game.width-10){
                LevelManager.Instance.DisplayNextLevel(right:true);
                x = 12;
            }
        }
    }
    private void handleStates()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                handleIdleState();
                break;
            case PlayerState.Running:
                handleRunning();
                break;
            case PlayerState.Jumping:
                handleJumping();
                break;
            case PlayerState.Falling:
                handleFalling();
                break;
            case PlayerState.Climbing:
                handleClimbing();
                break;
            case PlayerState.OnTopOfLedder:
                handleOnTopOfLedder();
                break;
            case PlayerState.OnRope:
                handleOnRope();
                break;
            default:
                Console.WriteLine("Undefined state for player");
                break;
        }
    }
    private void jump() {
        _speedY = JumpSpeed;
        currentState = PlayerState.Jumping;
    }
    private void updatePlayerPosition()
    {
        Move(_speedX , 0);
        _speedX *= 0.9f * Time.deltaTime / 1000;

        //if(_spe)
        Move(0, _speedY);
        //MoveUntilCollision(0, _speedY);



    }
    private void attachToRope( GameObject target) {
        SetXY(0, width/2);
        currentState = PlayerState.OnRope;
        target.AddChild(this);
    }
    private GameObject canClimb()
    {
        foreach (var collidedObject in GetCollisions())
        {
            if (collidedObject is Stairs)
            {
                return collidedObject;
            }
        }
        return null;
    }
    private bool tryClimbLedder() {
        var stairsObject = canClimb();
        if (stairsObject != null)
        {
            startClimbing(stairsObject);
            return true;
        }
        return false;
    }
    private void startClimbing(GameObject stairObject) {
        currentState = PlayerState.Climbing;
        var stairSprite = stairObject as Stairs;

        _speedX = 0;
        x = stairSprite.x + stairSprite.width / 2; // Center the player to the center of the stairs
    }

    /// <summary>
    /// Left right movement functionality
    /// </summary>
    private void handleHorizontalInput()
    {
        bool RightPressed = Input.GetKey(Key.RIGHT);
        bool LeftPressed = Input.GetKey(Key.LEFT);

        if (RightPressed)
        {
            Mirror(false, false);
            _speedX = MaxSpeed;
            if(currentState!= PlayerState.Jumping) { 
                currentState = PlayerState.Running;
            }
        }
        if (LeftPressed)
        {
            Mirror(true, false);
            _speedX = -MaxSpeed;
            if (currentState != PlayerState.Jumping)
            {
                currentState = PlayerState.Running;
            }
        }
        if (!RightPressed && !LeftPressed) {
            currentState = PlayerState.Idle;
        }
    }
    private void handleLedderClimbingMovement() {
        if (!Input.GetKey(Key.UP) && !Input.GetKey(Key.DOWN))
        {
            _speedY = 0;
        }
        if (Input.GetKey(Key.UP))
        {
            Move(0, -_climbingSpeed);
            HandleAnimation(FrameTimeMs, 3, 2);
        }
        if (Input.GetKey(Key.DOWN)) {
            Move(0, _climbingSpeed);
            HandleAnimation(FrameTimeMs, 3, 1);
        }
        
    }
    private void applyGravity()
    {
        if (IsOnGround){
            if(_speedY >0)
                _speedY = 0;
        }
        else {
            _speedY += Physics.Gravity;
        }
        

    }
    
    /// <summary>
    /// States handling methods
    /// </summary>
    private void handleIdleState() {
        HandleAnimation(FrameTimeMs, 6, 1);
        handleHorizontalInput();
        if (Input.GetKeyDown(Key.SPACE))
        {
            jump();
        }
        if (Input.GetKeyDown(Key.UP)) {
            tryClimbLedder();
            
        }
        if (!IsOnGround)
        {
            currentState = PlayerState.Falling;
            //_speedX = 0;
        }
    }
    private void handleRunning()
    {
        HandleAnimation(FrameTimeMs, 2, 4);
        handleHorizontalInput();
        if (Input.GetKeyDown(Key.SPACE))
        {
            jump();
        }
        if (Input.GetKey(Key.UP)) {
            tryClimbLedder();
        }
        if (!IsOnGround)
        {
            currentState = PlayerState.Falling;
            _speedX = 0;
        }
    }
    private void handleJumping() {
        HandleAnimation(FrameTimeMs, 0, 1);
        handleHorizontalInput();
        applyGravity();
        if (IsOnGround)
        {
            currentState = PlayerState.Idle;
        }
    }
    private void handleFalling() {
        HandleAnimation(FrameTimeMs, 0, 1);
        applyGravity();
        if (IsOnGround)
        {
            currentState = PlayerState.Idle;
        }
    }
    private void handleClimbing()
    {
        HandleAnimation(FrameTimeMs, 3, 1);
        handleLedderClimbingMovement();
       
        if (canClimb() == null) {
            currentState = PlayerState.OnTopOfLedder;
            _speedY = 0;
        }
        if (IsOnGround)
        {
            if(Input.GetKeyDown(Key.DOWN))
                currentState = PlayerState.Idle;
           
        }
    }
    private void handleOnTopOfLedder()
    {
        if (Input.GetKey(Key.LEFT) || Input.GetKey(Key.RIGHT) )
        {
            jump();
        }
        if (Input.GetKey(Key.DOWN))
        {
            currentState = PlayerState.Climbing;
        }
    }
    private void handleOnRope()
    {
        _speedY = 0;
        if (Input.GetKeyDown(Key.DOWN))
        {
            Vector2 worldPosition = this.TransformPoint(x, y);
            SetXY(worldPosition.x, worldPosition.y);
            parent.RemoveChild(this);
            game.LateAddChild(this);
            currentState = PlayerState.Falling;
        }
    }

    public void Kill()
    {
        lifesLeft--;
        UpdateHealthUI();

        if (lifesLeft <= 0)
        {
            RestartGame();
           
            return;
        }

        SetXY(spawnPosition.x, spawnPosition.y);
        MyGame.Instance.sounds["Death"].Play();
    }


    /// <summary>
    /// UI Method
    /// </summary>
    private void UpdateUI()
    {
        UICanvas.Instance.DrawScore(this.Score);
        UICanvas.Instance.DrawTimer(this.Timer);
    }
    private void UpdateHealthUI() {
        UICanvas.Instance.UpdateHealth(this.lifesLeft);
    }
}