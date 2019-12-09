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

            RoomController CurrentRoom = new RoomController();

            Player player = new Player(50,50, RoomController.Rooms[0], root);
            Sprite playerGraphic = new Sprite("Sprites/People/Player.png");

            player.AddChild(playerGraphic);

            game.Root = root;

            CurrentRoom.LoadRoom(RoomController.Rooms[0], "Rooms/StartingRoom.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[1], "Rooms/Room2.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[2], "Rooms/Room3.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[3], "Rooms/Room4.txt");

            CurrentRoom.LoadRoom(RoomController.Rooms[4], "Rooms/Room5.txt");

            CurrentRoom.LoadRoom(RoomController.Rooms[5], "Rooms/Room6.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[6], "Rooms/Room7.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[7], "Rooms/Room8.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[8], "Rooms/Room9.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[9], "Rooms/Room10.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[10], "Rooms/Room11.txt");
            CurrentRoom.LoadRoom(RoomController.Rooms[11], "Rooms/Room12.txt");
        
            root.AddChild(RoomController.Rooms[0]);
            RoomController.Rooms[0].AddChild(player);

            game.Run();
        }
    }
}
