using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.Scenes
{
    public class Playing : Scene
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = 0; i < Game1.currentLevel.levelObjects.Count; i++)
            {
                Game1.currentLevel.levelObjects[i].Update(gameTime);
            }
            
        }

    }
}
