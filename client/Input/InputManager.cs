using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace client.Input
{
    public class InputManager : IInputManager
    {
        public Vector2 GetMovementDirection()
        {
            Vector2 direction = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Z)) // Move Up
                direction.Y -= 1;
            if (keyboardState.IsKeyDown(Keys.S)) // Move Down
                direction.Y += 1;
            if (keyboardState.IsKeyDown(Keys.Q)) // Move Left
                direction.X -= 1;
            if (keyboardState.IsKeyDown(Keys.D)) // Move Right
                direction.X += 1;

            return direction;
        }
    }
}
