using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class DeathTrigger:Sprite
    {
        public DeathTrigger(float x, float y, int width) : base("playerHitBox.png") {
            alpha = 0.0f;
            SetXY(x, y);
            this.width = width;
        }

        void OnCollision(GameObject collider)
        {
            if (collider is Player)
            {
                var player = collider as Player;
                player.Kill();
            }
        }
    }
}
