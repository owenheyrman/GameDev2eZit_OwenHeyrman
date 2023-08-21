using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            for (int i = 0; i < Game1.currentLevel.levelObjects.Count; i++)
            {
                Game1.currentLevel.levelObjects[i].Draw(spriteBatch);
            }
        }

    }
}
