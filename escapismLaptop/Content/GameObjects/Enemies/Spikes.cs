using Microsoft.Xna.Framework;

namespace escapismLaptop.Content.GameObjects.Enemies
{
    public class Spikes : Collideable
    {
        public Spikes() : base(ContentManager.getInstance().texture_spikes)
        {
        }

        public override Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)this.location.X + 10, (int)this.location.Y + 5, this.texture.Width - 20, this.texture.Height - 5);
            }
        }

    }
}
