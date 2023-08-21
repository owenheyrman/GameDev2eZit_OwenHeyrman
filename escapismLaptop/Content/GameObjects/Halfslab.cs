using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects
{
    internal class Halfslab : Collideable
    {
        public Halfslab() : base(ContentManager.getInstance().texture_halfslab)
        {
        }
    }
}
