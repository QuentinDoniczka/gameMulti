using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using client.Entites;
using client.Entites.Interfaces;


namespace test.Entites
{
    public class PlayerFactory
    {
        public static IPlayer init(Vector2 position = default(Vector2))
        {
            IPlayer player = new Player(position);
            return player;
        }

        public static IPlayer X15Y10()
        {
            return init(new Vector2(15, 10));
        }
        public static IPlayer OwnPosition(Vector2 position)
        {
            return init(position);
        }
    }
}
