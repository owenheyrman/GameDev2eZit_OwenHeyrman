using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects.Powerups
{
    internal class Wings : Collideable
    {
        public Wings() : base(ContentManager.getInstance().texture_wings)
        {
        }
    }
}
