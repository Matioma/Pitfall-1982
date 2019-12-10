using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
using GXPEngine.Units;

public class Player : Unit
{
    private float _maxSpeed = 12;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
    }

    private float _jumpSpeed = -10;
    public float JumpSpeed
    {
        get { return _jumpSpeed; }
    }


    protected UnitState currentState = UnitState.Idle;
    private const float FrameTimeMs = 250;
    private float _speedX = 0;
    private float _speedY = 0;

    public Player(float x, float y) : base("barry.png", 7, 1)
    {
        SetXY(x, y);
    }

    public override void Update()
    {
        HandleStates();
        HandleMovement();
    }

    private void Jumping() {
        if (Input.GetKeyDown(Key.SPACE))
        {
            if (IsOnGround)
            {
                _speedY = JumpSpeed;
                currentState = UnitState.Jumping;
            }
        }
    }

    private void ClimbLedder() {

    }

    /// <summary>
    /// Left right movement functionality
    /// </summary>
    private void LeftRightMovement()
    {
        bool RightPressed = Input.GetKey(Key.RIGHT);
        bool LeftPressed = Input.GetKey(Key.LEFT);

        if (RightPressed)
        {
            Mirror(false, false);
            _speedX = 5;
            if(currentState!= UnitState.Jumping) { 
                currentState = UnitState.Running;
            }
        }
        if (LeftPressed)
        {
            Mirror(true, false);
            _speedX = -5;
            if (currentState != UnitState.Jumping)
            {
                currentState = UnitState.Running;
            }
        }
        if (!RightPressed && !LeftPressed) {
                currentState = UnitState.Idle;
        }
    }

    /// <summary>
    /// Handle States behaviour
    /// </summary>
    private void HandleStates() {
        switch (currentState) {
            case UnitState.Idle:
                HandleAnimation(FrameTimeMs, 4,3);
                Jumping();
                LeftRightMovement();
                if (!IsOnGround)
                {
                    currentState = UnitState.Falling;
                }
                break;

            case UnitState.Running:
                HandleAnimation(FrameTimeMs, 0, 3);
                LeftRightMovement();
                Jumping();
                if (!IsOnGround)
                {
                    currentState = UnitState.Falling;
                }
                break;

            case UnitState.Jumping:
                HandleAnimation(FrameTimeMs, 3, 1);
                LeftRightMovement();
                ApplyGravity();
                if (IsOnGround)
                {
                    currentState = UnitState.Idle;
                }
                break;
            case UnitState.Falling:
                HandleAnimation(FrameTimeMs, 3, 1);
                ApplyGravity();
                if (IsOnGround)
                {
                    currentState = UnitState.Idle;
                }
                break;

            default:
                Console.WriteLine("Undefined state");
                break;
        }
    }


    private void HandleMovement() {
        Move(_speedX, _speedY);
        _speedX *= 0.9f;
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

    void OnCollision(GameObject collider)
    {
    }
}