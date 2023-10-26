using Microsoft.Xna.Framework;

namespace client.Entites.Interfaces
{
    public interface IPlayer
    {
        Vector2 Position { get; }
        float Speed { get; }
        void Move(Vector2 direction);
    }
}
