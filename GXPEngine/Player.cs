using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Player : Sprite
    {
        private float _maxSpeed = 12;
        public float MaxSpeed {
            get { return _maxSpeed; }
            set { }
        }

        private float _jumpSpeed = -15;
        public float JumpSpeed {
            get { return _jumpSpeed; }
            set { _jumpSpeed = value; }
        }


        private float _speedX = 0;
        private float _speedY = 0;

        public Player(float x, float y, string spritePath) : base(spritePath) {
            base.x = x;
            base.y = y;
        }


        void Update() {
            applyGravity();
            handleInput();
            Move(_speedX, _speedY);
        }

        private void handleInput() {
           

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


            if (Input.GetKeyDown(Key.SPACE)) {
                _speedY = JumpSpeed;
            }
        }
        private void applyGravity() {
            if (!onSomething())
            {
                _speedY += Physics.Gravity;
            }
            else {
                _speedY = 0;
            }
        }

        bool onSomething()
        {
            foreach (var obj in game.GetGameObjectCollisions(this))
            {
                if (obj.HitTestPoint(x, y + height + 0.01f))
                {
                    return true;
                }
            }
            return false;
        }


        bool objectBeneaf(){
            
            return HitTestPoint(Input.mouseX, Input.mouseY);
        }

        void collide() {
        }
    }
}
