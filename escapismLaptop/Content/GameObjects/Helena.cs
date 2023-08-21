using escapismLaptop.Content;
using escapismLaptop.Content.Animation;
using escapismLaptop.Content.GameObjects;
using escapismLaptop.Content.GameObjects.Powerups;
using escapismLaptop.Content.Input;
using escapismLaptop.Content.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Helena : Collideable, ICanPickUp
{
    private InputManager inputManager;
    private MovementManager movementManager;


    Animation currentAnimation;

    private Animation idleAnimation;
    private Animation runningAnimation;

    private Animation jumpAnimation;
    private Animation fallAnimation;
    private Animation landAnimation;

    private double secondCounter;

    public override Rectangle Bounds
    {
        get
        {
            return new Rectangle((int)this.location.X + 8, (int)this.location.Y, 50, 83);
        }
    }

    public Helena() : base(ContentManager.getInstance().spritesheetHelena)
    {
        inputManager = new InputManager();
        movementManager = new MovementManager(this, 75, 83);


        InitializeAnimations();


    }

    public void InitializeAnimations()
    {
        idleAnimation = new Animation(4);
        idleAnimation.AddFrame(new AnimationFrame(new Rectangle(67, 73, 158, 211)));
        idleAnimation.AddFrame(new AnimationFrame(new Rectangle(229, 73, 150, 211)));
        idleAnimation.AddFrame(new AnimationFrame(new Rectangle(380, 73, 154, 211)));
        idleAnimation.AddFrame(new AnimationFrame(new Rectangle(547, 73, 155, 211)));

        runningAnimation = new Animation();
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(22, 366, 178, 210)));
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(223, 366, 182, 210)));
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(437, 366, 182, 210)));
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(638, 366, 177, 210)));
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(843, 366, 183, 210)));
        runningAnimation.AddFrame(new AnimationFrame(new Rectangle(1039, 366, 183, 210)));

        jumpAnimation = new Animation(1);
        jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(67, 627, 152, 223)));

        fallAnimation = new Animation(2);
        fallAnimation.AddFrame(new AnimationFrame(new Rectangle(237, 627, 200, 223)));

        landAnimation = new Animation(2);
        landAnimation.AddFrame(new AnimationFrame(new Rectangle(475, 627, 178, 223)));


        currentAnimation = idleAnimation;

    }



    private SpriteEffects lastDirection;
    override public void Update(GameTime gameTime)
    {

        this.currentAnimation.Update(gameTime);
        Move(gameTime);








    }

    private void Move(GameTime gameTime)
    {


        Vector2 direction = this.inputManager.ReadInput();

        //make character face the right direction
        if (direction.X == 1)
            lastDirection = SpriteEffects.None;
        else if (direction.X == -1)
            lastDirection = SpriteEffects.FlipHorizontally;

        //change animation
        if (movementManager.velocity.X != 0 && direction.X != 0)
        {
            this.currentAnimation = runningAnimation;
        }
        else if (movementManager.velocity.Y != 0)
        {
            this.currentAnimation = fallAnimation;
            if (movementManager.velocity.Y <= 1f && movementManager.velocity.Y != 0.12f)
            {
                this.currentAnimation = jumpAnimation;
            }
        }


        if ((movementManager.velocity.Y == 0 || movementManager.velocity.Y == 0.12f) && movementManager.velocity.X == 0)
        {
            this.currentAnimation = idleAnimation;
        }

        if (!flying)
            movementManager.Update(gameTime, direction);
        else
        {
            this.location += 10 * direction;
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (secondCounter >= 2)
            {
                flying = false;
                secondCounter = 0;
            }
        }




    }





    override public void Draw(SpriteBatch spriteBatch)
    {

        spriteBatch.Draw(this.texture, this.location, this.currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 0.4f, this.lastDirection, 0);
    }

    private bool flying = false;
    public void ActivateFlight()
    {
        flying = true;
    }
}

