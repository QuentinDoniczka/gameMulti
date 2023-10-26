
using client.Entites.Interfaces;
using Microsoft.Xna.Framework;

namespace client.Entites
{
    public class Player : IPlayer
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 10.0f;

        public Player(Vector2 initPosition)
        {
            Position = initPosition;
        }
        public void Move(Vector2 direction)
        {
            if (direction != Vector2.Zero)
            {
                direction = Vector2.Normalize(direction);
            }
            Position += direction * Speed;
        }
    }
}
