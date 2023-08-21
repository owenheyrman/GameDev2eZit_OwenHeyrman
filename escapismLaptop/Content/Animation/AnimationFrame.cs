using Microsoft.Xna.Framework;

namespace escapismLaptop.Content.Animation
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public AnimationFrame(Rectangle sourceRectangle, float duration = 1)
        {
            this.SourceRectangle = sourceRectangle;
            this.Duration = duration;
        }
        public float Duration { get; set; }
    }
}
