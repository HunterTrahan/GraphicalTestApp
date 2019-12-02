using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;

            Room startingRoom = new Room();

            startingRoom.LoadRoom("Rooms/StartingRoom.txt");

            //root.AddChild();

            //Player player = new Player(12, 76);
            //Sprite playerGraphic = new Sprite("Sprites/People/Player.png");
            //player.AddChild(playerGraphic);

            //root.AddChild(player);

            //## Set up game here ##//

            game.Run();
        }
    }
}
