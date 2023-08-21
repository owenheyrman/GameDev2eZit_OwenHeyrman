using escapismLaptop;
using escapismLaptop.Content.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


//Design Pattern: State Pattern
public abstract class Scene
{

    public List<GameObject> sceneObjects;

    public Scene()
    {
        this.sceneObjects = new List<GameObject>();
    }



    public virtual void Update(GameTime gameTime)
    {
        foreach (GameObject gameObject in sceneObjects)
        {
            gameObject.Update(gameTime);
        }


    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        foreach (GameObject gameObject in sceneObjects)
        {
            gameObject.Draw(spriteBatch);
        }

        if (Game1.currentSceneType == eScene.playing)
        {
            foreach (GameObject gameObject in Game1.currentLevel.levelObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }


    }
}