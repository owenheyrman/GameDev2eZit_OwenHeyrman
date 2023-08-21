using escapismLaptop.Content.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapismLaptop.Content.GameObjects.Enemies
{
    internal class Gunman : Collideable
    {
        Animation.Animation animation;
        

        private Level level;
        private MovementManager movementManager;
        private Helena helena;

        private Vector2 direction;

        

        public Gunman(Level level, Helena helena) : base(ContentManager.getInstance().spritesheetGunman)
        {
            this.level = level;
            movementManager = new MovementManager(this, 50, 110, acceleration: 0.3f, maxSpeed: 2);


            animation = new Animation.Animation(1);
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(23, 9, 255, 267)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(312, 9, 207, 267)));

            this.helena = helena;
            
        }

        public override Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)this.location.X, (int)this.location.Y, 83, 110);
            }
        }

        private double counter;

        override public void Update(GameTime gameTime)
        {
            this.animation.Update(gameTime);

            counter += gameTime.ElapsedGameTime.TotalSeconds;

            if(counter > 2)
            {
                counter = 0;
                Shoot();
            }

            Move(gameTime);

        }



        private void Shoot()
        {
            GunmanBullet bullet = new GunmanBullet(level);
            bullet.location = this.location + new Vector2(200, 10);
            this.level.levelObjects.Add(bullet);
        }

        private void Move(GameTime gameTime)
        {
            direction = DecideDirection(gameTime);
            movementManager.Update(gameTime, direction);

        }

        private Vector2 DecideDirection(GameTime gameTime)
        {


            if (this.location.Y > helena.location.Y)
            {
                return new Vector2(0, -1);
            }
            else return Vector2.Zero;





        }
        override public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.texture, this.location, this.animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 0.42f, SpriteEffects.None, 0);
        }
    }
}
