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

        public BoxEnemy(float x, float y) : base("barry.png", 6, 1) {
            this.x = x;
            this.y = y;
        }
        void Update() {
            
        }


        void OnCollision(GameObject collider) {
            Player player = collider as Player;
            player.Score -= scorePenaltyPerFrame;
        }

    }
}
