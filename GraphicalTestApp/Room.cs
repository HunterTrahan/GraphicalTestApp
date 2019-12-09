using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphicalTestApp
{
    //Defines the directions
    enum Direction
    {
        North,
        South,
        East,
        West
    }

    class Room : Actor
    {
        private Vector3 GridSize = new Vector3(16, 16, 0);
        private Vector3 RoomSize = new Vector3(16, 11, 0);

        //Rooms connected to this one
        private Room _north;
        private Room _south;
        private Room _east;
        private Room _west;

        //Grid
        public bool[,] _collision;

        //returns whether there is a solid entity at the point
        public bool GetCollosion(float x, float y)
        {
            x /= GridSize.x;
            y /= GridSize.y;

            if (x >= 0 && y >= 0 && x < RoomSize.x && y < RoomSize.y)
            {
                return _collision[(int)x, (int)y];
            }

            //A point outside the Scene is !not a collision
            else
            {
                return true;
            }
        }

        //Get north room and set south room
        public Room North
        {
            get
            {
                return _north;
            }
            set
            {
                if (value != null)
                {
                    //connect the rooms both ways
                    value._south = this;
                }

                _north = value;
            }
        }

        //Get south room and set north room
        public Room South
        {
            get
            {
                return _south;
            }
            set
            {
                if (value != null)
                {
                    //connect the rooms both ways
                    value._north = this;
                }

                _south = value;
            }
        }

        //Get east room and set west room
        public Room East
        {
            get
            {
                return _east;
            }
            set
            {
                if (value != null)
                {
                    //connect the rooms both ways
                    value._west = this;
                }

                _east = value;
            }
        }

        //Get west room and set east room
        public Room West
        {
            get
            {
                return _west;
            }
            set
            {
                if (value != null)
                {
                    //connect the rooms both ways
                    value._east = this;
                }

                _west = value;
            }
        }    
    }
}
