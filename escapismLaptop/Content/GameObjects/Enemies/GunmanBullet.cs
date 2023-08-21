using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects.Enemies
{
    internal class GunmanBullet : Collideable
    {
        private Level level;
        public GunmanBullet(Level level) : base(ContentManager.getInstance().texture_bullet)
        {
            this.level = level;
        }

        public override void Update(GameTime gameTime)
        {
            this.location.X += 35;
            if (this.location.X > 890)
                this.level.levelObjects.Remove(this);
            base.Update(gameTime);
        }
    }
    
}
