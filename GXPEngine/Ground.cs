using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Ground:GameObject
    {
        readonly Sprite _hitBox;
        AnimationSprite _visuals;
        //AnimationSprite _animSprite;


        public Ground(int x, int y, string spritePath){
            this.x = x;
            this.y = y;
            //_visuals = new Sprite(spritePath, false, false);

            _hitBox = new Sprite("playerHitBox.png");
            _hitBox.alpha = 0.0f;
            AddChild(_visuals);
            AddChild(_hitBox);
        }


        public Ground()
        {
            _visuals = new AnimationSprite("Tiles.png", 5, 1);
            _visuals.SetFrame(0);

            _hitBox = new Sprite("playerHitBox.png");
            _hitBox.alpha = 0.0f;
            AddChild(_visuals);
            AddChild(_hitBox);
        }

        public void SetSpriteExtent(int width,int height)
        {
            _visuals.width = width;
            _visuals.height = height;
        }
        public void SetHitBoxSize(int width, int height) {
            _hitBox.width = width;
            _hitBox.height = height;
        }
        public void OffsetTheHitBox(int x, int y)
        {
            _hitBox.x= x;
            _hitBox.y = y;
        }

    }
}
