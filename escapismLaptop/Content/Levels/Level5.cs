using escapismLaptop.Content.GameObjects.Powerups;

namespace escapismLaptop.Content.Levels
{
    internal class Level5 : Level
    {
        public Level5()
        {
            Helena helena = new Helena();
            helena.location = new Microsoft.Xna.Framework.Vector2(100, 300);
            levelObjects.Add(helena);

            Wings wings = new Wings();
            wings.location = new Microsoft.Xna.Framework.Vector2(600, 500);
            levelObjects.Add(wings);




            this.tileMap = new int[,]
            {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,3,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            if (this.tileMap != null)
            {
                initializeLevelObjects();
            }
        }
    }
}
