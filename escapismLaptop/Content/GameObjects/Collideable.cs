using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects
{
    public class Collideable : GameObject
    {
        public Collideable(Microsoft.Xna.Framework.Graphics.Texture2D texture) : base(texture)
        {
        }


        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)this.location.X, (int)this.location.Y, this.texture.Width, this.texture.Height);
            }
        }


        public bool CollidesWith(Collideable other)
        {
            if (other != null && this != null)
                return this.Bounds.Intersects(other.Bounds);
            else
                return false;
        }

        
    }
}
