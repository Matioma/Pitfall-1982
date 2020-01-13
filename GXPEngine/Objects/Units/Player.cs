using GXPEngine;
using GXPEngine.Core;
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

    private float _maxSpeed = 250;
    private float _jumpSpeed = -250;
    private int _score = 2000;
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
    public int Score {
        get {
            return _score;
        }
        set {
            if (value >= 0)
            {
                _score = value;
            }
            else {
                _score = 0;
            }
            scoreChangedHandler();
        }
    }


    static Player _playerInstance =null;
    public static Player PlayerInstance
    {
        get {
            if (_playerInstance != null)
            {
                return _playerInstance;
            }
            else {
                Console.WriteLine("The player instance does not exist yet");
                return null;
            }
        }
        private set
        {
            if (_playerInstance == null)
            {
                _playerInstance = value;
                //LevelManager.Instance.setPlayerRef(PlayerInstance);
            }
            else
            {
                if (value != _playerInstance) {
                    //value.LateDestroy();
                }
                Console.WriteLine("Tried to create second Instace of the Player, destroying this instance");
            }
        }
    }



    OnScoreChanged scoreChangedHandler;
    public delegate void OnScoreChanged();

    private PlayerState currentState = PlayerState.Idle;
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
        PlayerInstance = this;
        SetScaleXY(1f, 1f);
        SetXY(x, y);
        scoreChangedHandler += updateUI;
        scoreChangedHandler += outputScore;
    }
    public Player() : base("PlayerSpriteSheet.png", 6, 1)
    {
        PlayerInstance = this;
        //SetScaleXY(1f, 1f);
        //SetXY(x, y);
        scoreChangedHandler += updateUI;
        scoreChangedHandler += outputScore;
    }

    void Update()
    {
        handleStates();
        updatePlayerPosition();
        handleLevelTransition();
    }
    void OnCollision(GameObject collider)
    {
        var Enemy = collider as BoxEnemy;
        if (Enemy != null)
        {
            Console.WriteLine("Dead");
        }
        if (collider is OnRopeTigger ) {
            Console.WriteLine(_score);
            if (currentState != PlayerState.Falling) {
                attachToRope(collider);
            }

        }
    }

    void handleLevelTransition() {
        if (this.x < 10) {
            LevelManager.Instance.DisplayNextLevel(false);
            Console.WriteLine("Move LEft");
        } else if(this.x > game.width-10){
            LevelManager.Instance.DisplayNextLevel(true);
            Console.WriteLine("Move right");
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
        Move(_speedX * Time.deltaTime / 1000, _speedY * Time.deltaTime / 1000);
        _speedX *= 0.9f * Time.deltaTime / 1000;
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
        if (IsOnGround)
        {
            _speedY = 0;
        }
        else
        {
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
            _speedX = 0;
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


    /// <summary>
    /// UI Methods
    /// </summary>
    private void updateUI()
    {
        Console.WriteLine("Score Changed");
    }
    private void outputScore()
    {
        Console.WriteLine(Score);
    }
}