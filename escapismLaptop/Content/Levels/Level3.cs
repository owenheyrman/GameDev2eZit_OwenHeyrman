using escapismLaptop.Content.GameObjects.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.Levels
{
    public class Level3 : Level
    {
        public Level3()
        {
            Helena helena = new Helena();
            helena.location = new Microsoft.Xna.Framework.Vector2(570, 465);
            levelObjects.Add(helena);

            Guard guard = new Guard();
            guard.location = new Microsoft.Xna.Framework.Vector2(272, 385);
            levelObjects.Add(guard);



            this.tileMap = new int[,]
            {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,3,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1,0,1,0,1,1},
            {1,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            if (this.tileMap != null)
            {
                initializeLevelObjects();
            }
        }
    }
}
