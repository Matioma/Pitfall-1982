using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Player : Sprite
{
    private float _maxSpeed = 12;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
    }

    private float _jumpSpeed = -15;
    public float JumpSpeed
    {
        get { return _jumpSpeed; }
    }

    private bool _onGround = false;
    public bool IsOnGround
    {
        get { return _onGround; }
        set { _onGround = value; }
    }

    private float _speedX = 0;
    private float _speedY = 0;

    public Player(float x, float y, string spritePath) : base(spritePath)
    {
        base.x = x;
        base.y = y;
    }


    void Update()
    {
        applyGravity();
        handleInput();
        Move(_speedX, _speedY);
    }

    private void handleInput()
    {
        if (!Input.GetKey(Key.RIGHT) && !Input.GetKey(Key.LEFT))
        {
            _speedX = 0;
        }
        if (Input.GetKey(Key.RIGHT))
        {
            _speedX = 5;
        }
        if (Input.GetKey(Key.LEFT))
        {
            _speedX = -5;
        }
        if (Input.GetKeyDown(Key.SPACE))
        {
            IsOnGround = false;
            _speedY = JumpSpeed;
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

    void OnCollision(GameObject collider)
    {
        Console.WriteLine(collider);
        if (collider is Ground)
        {
            if (collider.HitTestPoint(x, y + height + 0.01f))
            {
                IsOnGround = true;
            }
            else
            {
                IsOnGround = false;
            }
        }
    }
}