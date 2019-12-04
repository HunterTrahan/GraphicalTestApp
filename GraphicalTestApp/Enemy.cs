using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Enemy : Entity
    {
        private Direction _facing;
        //private float _speed = 100;
        private AABB _hitbox = new AABB(16, 16);
        public Room CurrentRoom;

        public Enemy(float x, float y) : base(x, y)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            AddChild(_hitbox);
        }

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
