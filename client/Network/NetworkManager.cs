using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using Microsoft.Xna.Framework;

    public class NetworkManager
    {
        private UdpClient udpClient;
        private IPEndPoint serverEndPoint;
        private Vector2 lastReceivedCoordinates;
        private DateTime lastReceivedTime;
        private readonly TimeSpan timeoutDuration = TimeSpan.FromSeconds(1); // 1 seconde de timeout

        public NetworkManager()
        {
            udpClient = new UdpClient(9999);
            serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public Vector2? ReceiveCoordinates()
        {
            if (udpClient.Available > 0)
            {
                byte[] receivedData = udpClient.Receive(ref serverEndPoint);
                string message = Encoding.ASCII.GetString(receivedData);

                // Convertir le message en coordonnées Vector2
                string[] coords = message.Split(',');
                float x = float.Parse(coords[0]);
                float y = float.Parse(coords[1]);

                lastReceivedCoordinates = new Vector2(x, y);
                lastReceivedTime = DateTime.Now;
                return lastReceivedCoordinates;
            }

            // Si le temps écoulé depuis la dernière réception dépasse le timeout
            if (DateTime.Now - lastReceivedTime > timeoutDuration)
            {
                return null; // Indique que le serveur ne répond plus
            }

            return lastReceivedCoordinates;
        }
    }

}
