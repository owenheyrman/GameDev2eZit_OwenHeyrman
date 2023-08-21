using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace escapismLaptop.Content.Input
{
    public class InputManager
    {
        public Vector2 ReadInput()
        {
            var state = Keyboard.GetState();
            var direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left)) direction.X -= 1;
            if (state.IsKeyDown(Keys.Right)) direction.X += 1;
            if (state.IsKeyDown(Keys.Down)) direction.Y += 1;
            if (state.IsKeyDown(Keys.Up)) direction.Y -= 1;
            return direction;
        }
    }
}
