using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace escapismLaptop.Content.Animation
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private int fps;

        public Animation(int fps = 10)
        {
            frames = new List<AnimationFrame>();
            counter = 0;
            this.fps = fps;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }


        private double secondCounter = 0;
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1.0 / this.fps)
            {
                counter++;
                if (counter >= frames.Count)
                    counter = 0;
                secondCounter = 0;
            }
        }
    }
}
