using GXPEngine.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class BoxEnemy : Enemy
    {
        int scorePenaltyPerFrame = 14;
        bool movingLeft = false;
        float speed = 300;

        public BoxEnemy(float x, float y) : base("barry.png", 6, 1) {
            this.x = x;
            this.y = y;
            SetScaleXY(0.5f, 0.5f);
        }
        public BoxEnemy() : base("barry.png", 6, 1)
        {
            SetScaleXY(0.5f, 0.5f);
        }
        void Update() {
            Move();
        }

        void Move() {
            
            x -= speed * Time.deltaTime / 1000;
            if (x < 10) {
                x = game.width - 10;
            }
        }


        void OnCollision(GameObject collider) {
            Player player = collider as Player;
            if(player != null) {
                player.Score -= scorePenaltyPerFrame;
            }
        }

    }
}
