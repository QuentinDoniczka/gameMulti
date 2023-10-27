using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    static void Main(string[] args)
    {
        Console.WriteLine("Démarrage du serveur...");
        UdpClient udpServer = new UdpClient(8888);

        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

        // Coordonnées initiales du joueur "IA"
        int x = 400;
        int y = 400;

        // Directions possibles : 0 = Droite, 1 = Bas, 2 = Gauche, 3 = Haut
        int direction = 0;

        while (true)
        {
            switch (direction)
            {
                case 0: // Droite
                    x++;
                    if (x >= 500) direction = 1;
                    break;
                case 1: // Bas
                    y++;
                    if (y >= 500) direction = 2;
                    break;
                case 2: // Gauche
                    x--;
                    if (x <= 400) direction = 3;
                    break;
                case 3: // Haut
                    y--;
                    if (y <= 400) direction = 0;
                    break;
            }

            string message = $"{x},{y}";
            byte[] data = Encoding.ASCII.GetBytes(message);

            Console.WriteLine($"Envoi des coordonnées au client: {message} sur le port {clientEndPoint.Port}");
            udpServer.Send(data, data.Length, clientEndPoint);

            Thread.Sleep(1000 / 60); // Envoyer 60 fois par seconde
        }
    }
}
