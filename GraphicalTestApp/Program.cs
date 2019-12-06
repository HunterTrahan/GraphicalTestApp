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
            //Set up game here
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;

            Room startingRoom = new Room();

            startingRoom.LoadRoom("Rooms/StartingRoom.txt");

            game.Root = startingRoom;

            game.Run();
        }
    }
}
