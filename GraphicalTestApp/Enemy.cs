using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Enemy : Entity
    {
        //Refrences the facing direction
        private Direction _facing;

        //Creates the hitbox for the enemy
        private AABB _hitbox = new AABB(16, 16);

        //Refrences the current room the enemy is in
        public Room CurrentRoom;

        //Creates the Enemy entity
        public Enemy(float x, float y) : base(x, y)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            AddChild(_hitbox);
        }

        //defines what it is to move
        private void Move(float deltaTime)
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp(deltaTime);
                    break;

                case Direction.East:
                    MoveRight(deltaTime);
                    break;

                case Direction.South:
                    MoveDown(deltaTime);
                    break;

                case Direction.West:
                    MoveLeft(deltaTime);
                    break;
            }
        }

        //Enemy moves up
        private void MoveUp(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(X, _hitbox.Top))
            {
                Y -= 100 * deltaTime;
            }
            else
            {
                _facing = Direction.East;
            }
        }

        //Enemy moves down
        private void MoveDown(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(X, _hitbox.Bottom))
            {
                Y += 100 * deltaTime;
            }
            else
            {
                _facing = Direction.West;
            }
        }

        //Enemy moves left
        private void MoveLeft(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(_hitbox.Left, Y))
            {
                X -= 100 * deltaTime;
            }
            else
            {
                _facing = Direction.North;
            }
        }

        //Enemy moves right
        private void MoveRight(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(_hitbox.Right, Y))
            {
                X += 100 * deltaTime;
            }
            else
            {
                _facing = Direction.South;
            }
        }
    }
}
