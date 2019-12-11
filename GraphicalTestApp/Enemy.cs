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

        //Define a enemies base health
        protected int _health = 10;

        //Creates a timer for invincibilty frames
        protected Timer Iframes = new Timer();

        //Sets the speed of the player
        public float _Speed { get; set; } = 100f;

        //Creates the Enemy entity
        public Enemy(float x, float y) : base(x, y)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += Touch;
            AddChild(_hitbox);
        }

        //Checks if the enemy has touched the sword
        protected void Touch(float deltaTime)
        {

            if(_hitbox.DetectCollision(Sword.Instance._hitbox) && Iframes.Seconds >= 2f)
            {
                Iframes.Restart();
                _health -= Sword.Instance.Damage;
                if(_health <= 0)
                {
                    Die();
                }
            }
        }

        //Kills the enemy
        protected void Die()
        {
            Y = -400;
            Parent.RemoveChild(this);
        }

        //defines what it is to move
        //---needs to be virtual---
        protected virtual void Move(float deltaTime)
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
        protected void MoveUp(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(X, _hitbox.Top))
            {
                //Y -= 100 * deltaTime;
                YVelocity = -_Speed * deltaTime;
                XVelocity = 0f;
            }
            else
            {
                XVelocity = 0f;
                YVelocity = 0f;
                _facing = Direction.East;
            }
        }

        //Enemy moves down
        protected void MoveDown(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(X, _hitbox.Bottom))
            {
                //Y += 100 * deltaTime;
                YVelocity = _Speed * deltaTime;
                XVelocity = 0;
            }
            else
            {
                XVelocity = 0f;
                YVelocity = 0f;
                _facing = Direction.West;
            }
        }

        //Enemy moves left
        protected void MoveLeft(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(_hitbox.Left, Y))
            {
                //X -= 100 * deltaTime;
                XVelocity = -_Speed * deltaTime;
                YVelocity = 0;
            }
            else
            {
                XVelocity = 0f;
                YVelocity = 0f;
                _facing = Direction.North;
            }
        }

        //Enemy moves right
        protected void MoveRight(float deltaTime)
        {
            if(!CurrentRoom.GetCollosion(_hitbox.Right, Y))
            {
                //X += 100 * deltaTime;
                XVelocity = _Speed * deltaTime;
                YVelocity = 0f;
            }
            else
            {
                XVelocity = 0f;
                YVelocity = 0f;
                _facing = Direction.South;
            }
        }
    }
}
