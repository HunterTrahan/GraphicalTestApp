using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sword _sword = new Sword(11, 0);
        private Actor _swordNode = new Actor();

        //Create the player entity
        public Player(float x, float y) : base(x, y)
        {
            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;
            OnUpdate += SwingSword;
            _swordNode.AddChild(_sword);
        }

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
            if (Input.IsKeyDown(87))
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
            if (Input.IsKeyDown(83))
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
            if (Input.IsKeyDown(65))
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
            if (Input.IsKeyDown(68))
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
