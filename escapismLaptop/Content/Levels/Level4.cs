using escapismLaptop.Content.GameObjects.Enemies;

namespace escapismLaptop.Content.Levels
{
    internal class Level4 : Level
    {
        public Level4()
        {
            Helena helena = new Helena();
            helena.location = new Microsoft.Xna.Framework.Vector2(690, 470);
            levelObjects.Add(helena);

            Gunman gunman1 = new Gunman(this, helena);
            gunman1.location = new Microsoft.Xna.Framework.Vector2(100, 466);
            levelObjects.Add(gunman1);





            this.tileMap = new int[,]
            {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,3,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,0,1,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            if (this.tileMap != null)
            {
                initializeLevelObjects();
            }
        }
    }
}
