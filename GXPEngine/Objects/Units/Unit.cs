using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;
using GXPEngine.Objects.Units;

namespace GXPEngine.Units
{
    
    

    public abstract class Unit : Sprite
    {

        Sprite hitBox;
        protected AnimationSprite animationSprite;
        public bool IsOnGround {
            get {
                foreach (GameObject collidedObject in GetCollisions())
                {
                    if (collidedObject.parent is Ground || collidedObject is Alligator)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private float animationTimer = 0.0f;

        public Unit(string path, int cols, int rows, int frames = -1, bool keepInChache = false, bool addCollider = true):base("playerHitBox.png")
        {
            /*hitBox = new Sprite("playerHitBox.png", false, false);
            hitBox.alpha = 0.0f;*/

            alpha = 0.0f;


            SetOrigin(width/2, height);
            SetXY(game.width / 2, game.height / 2);

            animationSprite = new AnimationSprite(path, cols, rows);
            animationSprite.SetOrigin(animationSprite.width / 2, animationSprite.height);
            AddChild(animationSprite);
        }

        protected new void Mirror(bool flipHorizontal, bool flipVertical) {
            animationSprite.Mirror(flipHorizontal, flipVertical);
            base.Mirror(flipHorizontal, flipVertical);
        }

        public void SetHitBox(int width, int height) {
            this.width = width;
            this.height = height;

            animationSprite.width = width;
            animationSprite.height = width;
        }    

      
        protected void HandleAnimation(float frameTime, int startFrame, int numberOfFrames)
        {
            animationTimer += Time.deltaTime;
            animationSprite.SetFrame((int)(animationTimer / frameTime) % numberOfFrames + startFrame);
        }
    }
}
