using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Objects.Units
{
    public class Alligator:AnimationSprite
    {
        enum AlligatorState {
            Closed,
            Open

        }

        AlligatorState currentState = AlligatorState.Closed;
        int _timeToClose = 3000;
        int _timer;

        public Alligator(float x, float y):base("ALigatorSpriteSheet.png", 1,7)
        {
            SetXY(x, y);
            SetOrigin(width / 2, 0);
            SetFrame(5);
            _timer = _timeToClose;
        }

        void Update() {
            _timer -= Time.deltaTime;
            if (_timer <= 0) {
                if (currentState == AlligatorState.Closed)
                {
                    currentState = AlligatorState.Open;
                    SetFrame(5);
                }
                else if(currentState == AlligatorState.Open){
                    currentState = AlligatorState.Closed;
                    SetFrame(6);
                }
                _timer = _timeToClose;
            }

        }


        void OnCollision(GameObject collider) {
            if(currentState == AlligatorState.Open)
            {
                if (collider is Player) {
                    var player = collider as Player;
                    player.Kill();

                }

            }

        }



    }
}
