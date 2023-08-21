using escapismLaptop.Content.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace escapismLaptop.Content.GameObjects.Enemies
{
    public class Guard : Collideable
    {
        Animation.Animation animation;
        private SpriteEffects lastDirection = SpriteEffects.None;
        MovementManager movementManager;

        Vector2 direction;
        private double secondCounter = 0;


        public Guard() : base(ContentManager.getInstance().spritesheetGuard)
        {
            movementManager = new MovementManager(this, 83, 120, acceleration: 0.3f, maxSpeed: 2);

            animation = new Animation.Animation(4);
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 4, 80, 121)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(100, 4, 80, 121)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(199, 4, 80, 121)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(294, 4, 83, 121)));
        }

        public override Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)this.location.X, (int)this.location.Y, 83, 120);
            }
        }

        override public void Update(GameTime gameTime)
        {

            this.animation.Update(gameTime);
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            direction = DecideDirection(gameTime);
            movementManager.Update(gameTime, direction);

        }

        private Vector2 DecideDirection(GameTime gameTime)
        {
            if (secondCounter >= 6)
            {
                secondCounter = 0;
            }

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 3)
            {
                this.lastDirection = SpriteEffects.None;
                return new Vector2(-1, 0);
            }

            else
            {
                this.lastDirection = SpriteEffects.FlipHorizontally;
                return new Vector2(1, 0);
            }


        }

        override public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.texture, this.location, this.animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1f, this.lastDirection, 0);
        }
    }
}
