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
    public float MaxSpeed
    {
        get { return _maxSpeed; }
    }

    private float _jumpSpeed = -250;
    public float JumpSpeed
    {
        get { return _jumpSpeed; }
    }

    private int _score = 2000;
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

    OnScoreChanged scoreChangedHandler;
    public delegate void OnScoreChanged();

    protected PlayerState currentState = PlayerState.Idle;
    private const float FrameTimeMs = 250;
    private float _speedX = 0;
    private float _speedY = 0;

    private float climbingSpeed = 1;

    public Player(float x, float y) : base("PlayerSpriteSheet.png", 6, 1)
    {
        SetScaleXY(1f, 1f);
        SetXY(x, y);
        scoreChangedHandler += UpdateUI;
        scoreChangedHandler += OutputScore;
    }

    public override void Update()
    {
        HandleStates();
        MovePlayer();
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
                AttachToRope(collider);
            }

        }
    }

    private void HandleStates()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                HandleIdleState();
                break;
            case PlayerState.Running:
                HandleRunning();
                break;
            case PlayerState.Jumping:
                HandleJumping();
                break;
            case PlayerState.Falling:
                HandleFalling();
                break;
            case PlayerState.Climbing:
                HandleClimbing();
                break;
            case PlayerState.OnTopOfLedder:
                HandleOnTopOfLedder();
                break;
            case PlayerState.OnRope:
                HandleOnRope();

                break;
            default:
                Console.WriteLine("Undefined state for player");
                break;
        }
    }

    
    private void Jump() {
        _speedY = JumpSpeed;
        currentState = PlayerState.Jumping;
    }
    private void MovePlayer()
    {
        Move(_speedX * Time.deltaTime / 1000, _speedY * Time.deltaTime / 1000);
        _speedX *= 0.9f * Time.deltaTime / 1000;
    }

    private void AttachToRope( GameObject target) {
        SetXY(0, width/2);
        currentState = PlayerState.OnRope;
        target.AddChild(this);
    }
    void JumpOfLedder()
    {
        if (Input.GetKey(Key.LEFT))
        {
            _speedY = JumpSpeed;
            currentState = PlayerState.Jumping;
        }
        else if (Input.GetKey(Key.RIGHT))
        {
            _speedY = JumpSpeed;
            currentState = PlayerState.Jumping;
        }
    }
    private GameObject CanClimb()
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
    private bool TryClimbLedder() {
        var stairsObject = CanClimb();
        if (stairsObject != null)
        {
            StartClimbing(stairsObject);
            return true;
        }
        return false;
    }
    private void StartClimbing(GameObject stairObject) {
        currentState = PlayerState.Climbing;
        Sprite stairSprite = (Sprite)stairObject;
        if (stairSprite != null)
        {
            x = stairSprite.x + stairSprite.width / 2;
            _speedX = 0;
        }
        else {
            Console.WriteLine("Failed to cast the stairs to ");
        }
        
    }
    /// <summary>
    /// Left right movement functionality
    /// </summary>
    private void HandleHorizontalInput()
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
    private void HandleLedderClimbingMovement() {
        if (!Input.GetKey(Key.UP) && !Input.GetKey(Key.DOWN))
        {
            _speedY = 0;
        }
        if (Input.GetKey(Key.UP))
        {
            Move(0, -climbingSpeed);
            HandleAnimation(FrameTimeMs, 3, 2);
        }
        if (Input.GetKey(Key.DOWN)) {
            Move(0, climbingSpeed);
            HandleAnimation(FrameTimeMs, 3, 1);
        }
        
    }
    private void ApplyGravity()
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
    private void HandleIdleState() {
        HandleAnimation(FrameTimeMs, 6, 1);
        HandleHorizontalInput();
        if (Input.GetKeyDown(Key.SPACE))
        {
            Jump();
        }
        if (Input.GetKeyDown(Key.UP)) {
            TryClimbLedder();
            
        }
        if (!IsOnGround)
        {
            currentState = PlayerState.Falling;
            _speedX = 0;
        }
    }
    private void HandleRunning()
    {
        HandleAnimation(FrameTimeMs, 2, 4);
        HandleHorizontalInput();
        if (Input.GetKeyDown(Key.SPACE))
        {
            Jump();
        }
        if (Input.GetKey(Key.UP)) {
            TryClimbLedder();
        }
        if (!IsOnGround)
        {
            currentState = PlayerState.Falling;
            _speedX = 0;
        }
    }
    private void HandleJumping() {
        HandleAnimation(FrameTimeMs, 0, 1);
        HandleHorizontalInput();
        ApplyGravity();
        if (IsOnGround)
        {
            currentState = PlayerState.Idle;
        }
    }
    private void HandleFalling() {
        HandleAnimation(FrameTimeMs, 0, 1);
        ApplyGravity();
        if (IsOnGround)
        {
            currentState = PlayerState.Idle;
        }
    }
    private void HandleClimbing()
    {
        HandleAnimation(FrameTimeMs, 3, 1);
        HandleLedderClimbingMovement();
       
        if (CanClimb() == null) {
            currentState = PlayerState.OnTopOfLedder;
            _speedY = 0;
        }
        
        if (IsOnGround)
        {
            currentState = PlayerState.Idle;
            Console.WriteLine("Back to iddle");
        }
    }
    private void HandleOnTopOfLedder()
    {
        JumpOfLedder();
        if (Input.GetKey(Key.DOWN))
        {
            currentState = PlayerState.Climbing;
        }
    }
    private void HandleOnRope()
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



    private void UpdateUI()
    {
        Console.WriteLine("Score Changed");
    }
    private void OutputScore()
    {
        Console.WriteLine(Score);
    }
}