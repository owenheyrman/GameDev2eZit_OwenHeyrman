

public class Level1 : Level
{



    public Level1()
    {
        Helena helena = new Helena();
        helena.location = new Microsoft.Xna.Framework.Vector2(100, 300);
        levelObjects.Add(helena);



        this.tileMap = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,3,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,0,0,1,0,0,0,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,1,0,0,0,1},
            {1,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,0,1,1,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        if (this.tileMap != null)
        {
            initializeLevelObjects();
        }
    }

}