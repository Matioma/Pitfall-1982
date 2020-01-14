using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using TiledMapParser;
namespace GXPEngine
{
    class TiledLevel : GameObject
    {
        const int tileSize = 64;
        const int cols = 100;
        const int rows = 10;

        short[,] tiledDataShort;

        public TiledLevel() {
            /*int[] tiledData = {
                0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
            };



                int index = 0;
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < cols; j++) {
                        AddTile(tiledData[index], j * tileSize, i * tileSize);
                        index++;
                    }
                }
                AddPlayer();*/
        }


        public TiledLevel(string fileName) {
            Map levelData = MapParser.ReadMap(fileName);
            SpawnTiles(levelData);
            SpawnObjects(levelData);
        }

        public void SpawnTiles(Map levelData) {
            if (levelData.Layers == null || levelData.Layers.Length == 0)
            {
                return;
            }

            Layer mainLayer = levelData.Layers[0];
            tiledDataShort = mainLayer.GetTileArray();

            for (int i = 0; i < mainLayer.Height; i++)
            {
                for (int j = 0; j < mainLayer.Width; j++)
                {
                    int tileNumber = tiledDataShort[j, i];
                    if (tileNumber > 0) {
                        AddTile(tileNumber, j * tileSize, i * tileSize);
                    }
                }
            }
        }

        public void SpawnObjects(Map levelData) {
            if (levelData.ObjectGroups == null || levelData.ObjectGroups.Length == 0) {
                return;
            }
            ObjectGroup objectGroup = levelData.ObjectGroups[0];

            if (objectGroup.Objects == null || objectGroup.Objects.Length == 0) {
                return;
            }

            foreach (TiledObject obj in objectGroup.Objects) {
                switch (obj.Name) {
                    case "Rope":
                        Rope rope = new Rope();
                        rope.x = obj.X;
                        rope.y = obj.Y;
                        AddChild(rope);
                        break;
                    case "BoxEnemy":
                        BoxEnemy boxEnemy = new BoxEnemy();
                        boxEnemy.x = obj.X;
                        boxEnemy.y = obj.Y;
                        AddChild(boxEnemy);
                        break;
                    case "Player":
                        Player player = new Player();
                        player.x = obj.X;
                        player.y = obj.Y;
                        LevelManager.Instance.PlayerInstace = player;
                        break;
                }
            }


        }


        void AddTile(int id, int x, int y) {
            GameObject gameObject = null;
            switch (id) {
                case 0:
                    break;
                case 1:
                    gameObject = new Ground();
                    break;
                case 2:
                    gameObject = new Stairs();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    throw new Exception("Unknow tile" + id + ";");
            }
            
            if (gameObject != null) {
                gameObject.SetXY(x, y);
                AddChild(gameObject);
            }
        }


    }
}
