using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace escapismLaptop.Content.GameObjects
{
    public class GameObject
    {
        public Vector2 location;
        protected Texture2D texture;
        protected Rectangle sourceRectangle;

        public GameObject(Texture2D texture)
        {
            this.texture = texture;
            this.sourceRectangle = new Rectangle(0, 0, this.texture.Width, this.texture.Height);

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                spriteBatch.Draw(texture, location, sourceRectangle, Color.White);
            }
        }

        public virtual void Update(GameTime gameTime)
        {

        }


    }
}
