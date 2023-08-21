using System.Collections.Generic;
using escapismLaptop;
using escapismLaptop.Content;
using escapismLaptop.Content.GameObjects;
using escapismLaptop.Content.GameObjects.Enemies;

public abstract class Level{
    public List<GameObject> levelObjects;
    public List<Spikes> spikes;

    public int[,] tileMap;

    public Level(){
        this.levelObjects = new List<GameObject>();
    }

    public void initializeLevelObjects()
    {
        for(int i = 0; i < tileMap.GetLength(0); i++)
        {
            for(int j = 0; j < tileMap.GetLength(1); j++)
            {
                if (tileMap[i,j] == 1)
                {
                    Collideable box = new Collideable(ContentManager.getInstance().texture_box);
                    box.location = new Microsoft.Xna.Framework.Vector2(j * 64, i * 64);
                    this.levelObjects.Add(box);
                }
                if (tileMap[i,j] == 2)
                {
                    Spikes spikes = new Spikes();
                    spikes.location = new Microsoft.Xna.Framework.Vector2(j * 64, i * 64);
                    this.levelObjects.Add(spikes);
                }
                if (tileMap[i, j] == 3)
                {
                    Door door = new Door();
                    door.location = new Microsoft.Xna.Framework.Vector2(j * 64, i * 64);
                    this.levelObjects.Add(door);
                }
                if (tileMap[i, j] == 4)
                {
                    Halfslab halfslab = new Halfslab();
                    halfslab.location = new Microsoft.Xna.Framework.Vector2(j * 64, i * 64);
                    this.levelObjects.Add(halfslab);
                }

            }
        }
    }

}