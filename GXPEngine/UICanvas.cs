using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UICanvas : GameObject
    {
        static UICanvas _instance;

        EasyDraw uiEasyDraw;

        string  _scoreText= "";
        string _timerText ="";

        public static UICanvas Instance{
            get{if (_instance == null ){
                    _instance = new UICanvas();
                    Game.main.AddChild(_instance);
                }
                return _instance;
            }
            set{
            }
        }

        UICanvas()
        {
            uiEasyDraw = new EasyDraw(150, 60);
            AddChild(uiEasyDraw);
        }

        void Update() {
            uiEasyDraw.Clear(0);
            uiEasyDraw.Text(_scoreText + "\n" + _timerText , 50, 50);
            
        }

        public void DrawScore(int score) {
            _scoreText = score.ToString();
        }

        public void DrawTimer(float time) {
            var timeInSec = (int)time / 1000;
            int minutes = (int)timeInSec / 60;
            int sec = (int)timeInSec % 60;
            _timerText = minutes + ":" + sec;
        }



    }
}
