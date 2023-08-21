using escapismLaptop.Content.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.Scenes
{
    public class GameOver : Scene
    {
        public GameOver()
        {
            GameObject gameOver = new GameObject(ContentManager.getInstance().texture_gameOver);
            this.sceneObjects.Add(gameOver);
        }
    }
}
