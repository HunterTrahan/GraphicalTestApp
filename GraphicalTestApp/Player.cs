using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        //Creates the sword
        private Sword _sword = new Sword(11, 0);

        //Refrences to the root
        private Actor _root;

        //Creates the sword node which handles the sword
        private Actor _swordNode = new Actor();

        //Creates the hitbox
        private AABB _hitbox = new AABB(16, 16);

        //Refrences the current room the player is in
        public Room CurrentRoom;

        //Instance the player
        private static Player _instance;

        //Instances of the player
        public static Player Instance
        {
            get { return _instance; }
        }

        //Create the player entity
        public Player(float x, float y, Room room, Actor root) : base(x, y)
        {
            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;
            OnUpdate += SwingSword;
            _instance = this;
            _swordNode.AddChild(_sword);
            AddChild(_hitbox);

            CurrentRoom = room;

            _root = root;
        }

        //Dictates if the player changes rooms
        private void Travel(Room destination)
        {
            _root.RemoveChild(CurrentRoom);
            _root.AddChild(destination);

            CurrentRoom = destination;
            if(Parent == null)
            {
                return;
            }

            Parent.RemoveChild(this);
            CurrentRoom.AddChild(this);
        }

        //Player swings the sword
        public void SwingSword(float deltatime)
        {
            if (Input.IsKeyPressed(75))
            {
                AddChild(_swordNode);
                _sword.isSwinging = true;
                _swordNode.X = 1;
                _swordNode.Y = 0;
            }
        }

        //Move up one space
        private void MoveUp(float deltaTime)
        {
            if (Y - 1 < 15)
            {
                if (CurrentRoom is Room)
                {
                    Travel(CurrentRoom.North);
                    Y = 140;
                }
            }

            else if (Input.IsKeyDown(87) && !CurrentRoom.GetCollosion(X, _hitbox.Top))
            {
                Y -= 100 * deltaTime;

                _swordNode.X = 0;
                _swordNode.Y = 1;

                _sword.X = 0;
                _sword.Y = -11;

                _sword.Rotate((float)Math.PI);
            }
        }

        //move down one space
        private void MoveDown(float deltaTime)
        {
            if (Y + 1 > 160)
            {
                if (CurrentRoom is Room)
                {
                    Travel(CurrentRoom.South);
                    Y = 25;
                }
            }
            else if (Input.IsKeyDown(83) && !CurrentRoom.GetCollosion(X, _hitbox.Bottom))
            {
                Y += 100 * deltaTime;

                _swordNode.X = 0;
                _swordNode.Y = -1;

                _sword.X = 0;
                _sword.Y = 11;

                _sword.Rotate((float)Math.PI);
            }
        }

        //Move one space to the left
        private void MoveLeft(float deltaTime)
        {
            if(X - 1 < 10)
            {
                if(CurrentRoom is Room)
                {
                    Travel(CurrentRoom.West);
                    X = 240;
                }
            }

            else if (Input.IsKeyDown(65) && !CurrentRoom.GetCollosion(_hitbox.Left, Y))
            {
                X -= 100 * deltaTime;

                _swordNode.X = -1;
                _swordNode.Y = 0;

                _sword.X = -11;
                _sword.Y = 0;

                _sword.Rotate((float)Math.PI);
            }
        }

        //Move one space to the right
        private void MoveRight(float deltaTime)
        {
            if (X + 1 > 245)
            {
                if (CurrentRoom is Room)
                {
                    Travel(CurrentRoom.East);
                    X = 15;
                }
            }

            else if (Input.IsKeyDown(68) && !CurrentRoom.GetCollosion(_hitbox.Right, Y))
            {
                X += 100 * deltaTime;

                _swordNode.X = 1;
                _swordNode.Y = 0;

                _sword.X = 11;
                _sword.Y = 0;

                _sword.Rotate((float)Math.PI);
            }
        }
    }
}
