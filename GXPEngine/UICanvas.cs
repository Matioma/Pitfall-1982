using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UICanvas : GameObject
    {
        static UICanvas _instance;

        AnimationSprite healthBarSpriteSheet;

        EasyDraw uiEasyDraw;


        int _currentHP = 0;
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
            healthBarSpriteSheet = new AnimationSprite("HealthSpriteSheet.png", 1, 3);
            healthBarSpriteSheet.SetXY(game.width - 250, 50);
            AddChild(healthBarSpriteSheet);
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

        public void UpdateHealth(int health)
        {
            _currentHP = health;
            healthBarSpriteSheet.SetFrame(healthBarSpriteSheet.frameCount - health);
           
        }
    }
}
