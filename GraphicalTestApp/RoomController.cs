using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphicalTestApp
{
    class RoomController : Actor
    {
        public static Room[] Rooms = new Room[12];

        private Vector3 GridSize = new Vector3(16, 16, 0);
        private Vector3 RoomSize = new Vector3(16, 11, 0);

        public RoomController()
        {
            Startup();

        }

        //Grid
        private bool[,] _collision;


        //Room List
        public Room StartingRoom = new Room();
        Room Room2 = new Room();
        Room Room3 = new Room();

        Room Room4 = new Room();

        Room Room5 = new Room();
        Room Room6 = new Room();
        Room Room7 = new Room();
        Room Room8 = new Room();
        Room Room9 = new Room();
        Room Room10 = new Room();
        Room Room11= new Room();
        Room Room12= new Room();
       

        public void Startup()
        {
            Rooms[0] = StartingRoom;
            Rooms[1] = Room2;
            Rooms[2] = Room3;

            Rooms[3] = Room4;

            Rooms[4] = Room5;
            Rooms[5] = Room6;
            Rooms[6] = Room7;
            Rooms[7] = Room8;
            Rooms[8] = Room9;
            Rooms[9] = Room10;
            Rooms[10] = Room11;
            Rooms[11] = Room12;

            StartingRoom.West = Rooms[1];
            StartingRoom.East = Rooms[2];
            StartingRoom.North = Rooms[3];

            Room4.North = Rooms[4];
            Room4.South = Rooms[0];

            Room5.South = Rooms[3];
            Room5.West = Rooms[6];
            Room5.East = Rooms[5];

            Room6.West = Rooms[4];

            Room7.North = Rooms[8];
            Room7.East = Rooms[4];

            Room8.West = Rooms[8];
            Room8.East = Rooms[9];

            Room9.South = Rooms[6];
            Room9.East = Rooms[7];

            Room10.West = Rooms[10];
            Room10.East = Rooms[7];

            Room11.North = Rooms[11];
            Room11.West = Rooms[9];

            Room12.South = Rooms[10];
        }

        //Loads and returns a room from a file
        public void LoadRoom(Room room, string path)
        {
            StreamReader reader = new StreamReader(path);

            int width, height;
            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);

            RoomSize.x = width;
            RoomSize.y = height;

            //Create the collision grid
            _collision = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                string row = reader.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char tile = row[x];
                    switch (tile)
                    {
                        case '1':
                            //Create and add a Wall and its hitbox
                            _collision[x, y] = true;
                            Sprite WallSprite = new Sprite("Sprites/Walls/StoneWall.png");
                            WallSprite.X = x * GridSize.x;
                            WallSprite.Y = y * GridSize.y;

                            //Creates the hitbox
                            AABB _hitbox = new AABB(16, 16);
                            _hitbox.X = x * GridSize.x + 8;
                            _hitbox.Y = y * GridSize.y + 8;

                            room.AddChild(WallSprite);
                            room.AddChild(_hitbox);
                            break;

                        case 'w':
                            //Create and add a Wall and its hitbox
                            Sprite WaterSprite = new Sprite("Sprites/Walls/Water.png");
                            WaterSprite.X = x * GridSize.x;
                            WaterSprite.Y = y * GridSize.y;

                            //Creates the hitbox
                            AABB hitbox = new AABB(16, 16);
                            hitbox.X = x * GridSize.x + 8;
                            hitbox.Y = y * GridSize.y + 8;

                            room.AddChild(WaterSprite);
                            room.AddChild(hitbox);
                            break;

                        //case '@':
                        //    //Create and add a Player to the room
                        //    Player p = new Player(x * GridSize.x, y * GridSize.y);
                        //    Sprite playerGraphic = new Sprite("Sprites/People/Player.png");
                        //    p.AddChild(playerGraphic);
                        //    p.CurrentRoom = this;

                        //    room.AddChild(p);
                        //    break;

                        case 'r':
                            //Create and add a Rat to the room
                            Rat r = new Rat(x * GridSize.x, y * GridSize.y);
                            Sprite RatGraphic = new Sprite("Sprites/Enemies/Rat.png");
                            r.AddChild(RatGraphic);
                            r.CurrentRoom = room;
                            room._collision = _collision;

                            room.AddChild(r);
                            break;

                    }
                }
            }
        }
    }
}
