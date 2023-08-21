namespace escapismLaptop.Content.Levels
{
    public class Level2 : Level
    {
        public Level2()
        {
            Helena helena = new Helena();
            helena.location = new Microsoft.Xna.Framework.Vector2(75, 465);
            levelObjects.Add(helena);



            this.tileMap = new int[,]
            {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,3,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,2,0,0,0,2,0,1,1,1,1,1},
            {1,0,0,0,4,0,4,0,4,0,0,0,0,0,1},
            {1,0,0,4,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,0,0,0,1,0,0,0,0,1,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,0,0,0,1,0,1},
            {1,0,0,2,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            if (this.tileMap != null)
            {
                initializeLevelObjects();
            }
        }
    }
}
