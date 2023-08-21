using escapismLaptop.Content.GameObjects;
using escapismLaptop.Content.GameObjects.Enemies;
using escapismLaptop.Content.GameObjects.Powerups;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace escapismLaptop.Content.Movement
{
    public class MovementManager
    {
        private GameObject gameObject;

        private int boundsX;
        private int boundsY;


        private float jumpHeight;
        private float gravity;

        public Vector2 velocity =  Vector2.Zero;

        private float acceleration;
        private float deceleration;
        private float maxSpeed;

        private float maxFallSpeed;


        private bool grounded = false;

        public MovementManager(GameObject gameObject, int boundsX, int boundsY, float jumpHeight = 5.2f, float gravity = 0.12f, float acceleration = 1f, float deceleration = 1.5f, float maxSpeed = 5f, float maxFallSpeed = 20)
        {
            this.gameObject = gameObject;
            this.boundsX = boundsX;
            this.boundsY = boundsY;
            this.jumpHeight = jumpHeight;
            this.gravity = gravity;
            this.acceleration = acceleration;
            this.deceleration = deceleration;
            this.maxSpeed = maxSpeed;
            this.maxFallSpeed = maxFallSpeed;
        }

        public void Update(GameTime gameTime, Vector2 direction)
        {
            if(!this.grounded) 
            {
                this.velocity.Y += gravity;
            }

            if(direction.X != 0)
            {
                if (direction.X > 0)
                {
                    this.velocity.X += acceleration;
                }
                else
                {
                    this.velocity.X -= acceleration;
                }
            }
            else
            {
                if (this.velocity.X > 0 && this.velocity.X < deceleration)
                {
                    this.velocity.X -= deceleration;
                }
                else if (this.velocity.X < 0 && this.velocity.X < -deceleration)
                {
                    this.velocity.X += deceleration;
                }
            }

            if (this.velocity.X > maxSpeed)
            {
                this.velocity.X = maxSpeed;
            }
            else if (this.velocity.X < -maxSpeed)
            {
                this.velocity.X = -maxSpeed;
            }

            if (this.velocity.Y > maxFallSpeed)
            {
                this.velocity.Y = maxFallSpeed;
            }

            if (direction.Y == -1 && this.grounded)
            {
                this.velocity.Y -= jumpHeight;
                this.grounded = false;
            }

            if (!WillCollide(true))
            {
                this.gameObject.location.X += this.velocity.X;
            }
            else
            {
                this.velocity.X = 0;
            }

            if (!WillCollide(false))
            {
                this.gameObject.location.Y += this.velocity.Y;
            }
            else
            {
                this.grounded = true;
            }


            //gradually slow to a stop
            if(velocity.X != 0)
            {
                velocity.X *= 0.95f;
                
                if(velocity.X > 0)
                {
                    velocity.X -= 0.02f;
                }
                if(velocity.X < 0)
                {
                      velocity.X += 0.02f;
                }
                if(velocity.X < 0.05f && velocity.X > -0.05f)
                {
                    velocity.X = 0;
                }
            }



            CheckAndHandleWalkedOffEdge();
            CheckAndHandleJumpingIntoRoof();
            
        }

        public Rectangle calculateCollisions()
        {
            for (int i = 0; i < Game1.currentLevel.levelObjects.Count; i++)
            {   
                if (Game1.currentLevel.levelObjects[i] is Collideable)
                {
                    if (((Collideable)Game1.currentLevel.levelObjects[i]).CollidesWith((Collideable)this.gameObject) && !((Collideable)Game1.currentLevel.levelObjects[i] == (Collideable)this.gameObject) )
                    {
                        if (Game1.currentLevel.levelObjects[i] is Spikes || Game1.currentLevel.levelObjects[i] is Guard || Game1.currentLevel.levelObjects[i] is GunmanBullet)
                            Game1.Lose();
                        if (Game1.currentLevel.levelObjects[i] is Door)
                            Game1.WinLevel();
                        if (Game1.currentLevel.levelObjects[i] is Wings)                    
                            if (gameObject is ICanPickUp)
                                (gameObject as ICanPickUp).ActivateFlight();
                        
                        return ((Collideable)Game1.currentLevel.levelObjects[i]).Bounds;
                    }
                }
            }
            return Rectangle.Empty;
        }

        public bool WillCollide(bool xAxis)
        {
            Rectangle currentBounds = new Rectangle((int)this.gameObject.location.X, (int)this.gameObject.location.Y, this.boundsX, this.boundsY);
            Rectangle futureBounds = new Rectangle((int)this.gameObject.location.X, (int)this.gameObject.location.Y, this.boundsX, this.boundsY);

            int maxX = (int)maxSpeed;
            int maxY = (int)jumpHeight;

            if (xAxis && velocity.X != 0)
            {
                if (velocity.X > 0)
                {
                    futureBounds.X += maxX;
                }
                else
                {
                    futureBounds.X -= maxX;
                }
            }
            
            
            if (!xAxis && velocity.Y != 0)
            {
                if (velocity.Y > 0)
                {
                    futureBounds.Y += maxY;
                }
                else
                {
                    futureBounds.Y -= maxY;
                }
            }

            


            this.gameObject.location = new Vector2(futureBounds.X, futureBounds.Y);
            Rectangle collision = calculateCollisions();
            this.gameObject.location = currentBounds.Location.ToVector2();
            if (collision != Rectangle.Empty)
            {
                if(velocity.Y >= gravity && (futureBounds.Bottom > collision.Top - maxSpeed) && (futureBounds.Bottom <= collision.Top + velocity.Y))
                {
                    LandResponse(collision);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public void LandResponse(Rectangle collision)
        {
            this.gameObject.location.Y = collision.Top - boundsY;
            velocity.Y = 0;
            grounded = true;
        }

        public void CheckAndHandleWalkedOffEdge()
        {
            this.gameObject.location.Y += 2;
            if(!WillCollide(false))
            {
                this.gameObject.location.Y -= 2;
                this.grounded = false;
            }
            else
            {
                this.gameObject.location.Y -= 2;
            }

        }
        public void CheckAndHandleJumpingIntoRoof()
        {

            if (!this.grounded && this.velocity.Y < 0)
            {
                this.gameObject.location.Y += 1;
                if (WillCollide(false))
                {
                    this.velocity.Y = 0;
                }
                this.gameObject.location.Y -= 1;
            }

        }
    }
}
