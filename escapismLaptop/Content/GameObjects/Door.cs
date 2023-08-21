using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects
{
    internal class Door : Collideable
    {
        public Door() : base(ContentManager.getInstance().texture_door)
        {
        }

        

    }
   
}
