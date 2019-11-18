using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        //Create the player entity
        public Player(float x, float y) : base(12, 76)
        {
            //Input.IsKeyPressed(MoveRight, 100); //D
            //Input.IsKeyPressed(MoveLeft, 97); //A
            //Input.IsKeyPressed(MoveUp, 119); //W
            //Input.IsKeyPressed(MoveDown, 115); //S

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;
        }

        //Move up one space
        private void MoveUp(float deltaTime)
        {
            if(Input.IsKeyDown(87))
            {
                Y -= 100 * deltaTime;
            }
        }

        //move down one space
        private void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(83))
            {
                Y += 100 * deltaTime;
            }
        }

        //Move one space to the left
        private void MoveLeft(float deltaTime)
        {
            if (Input.IsKeyDown(65))
            {
                X -= 100 * deltaTime;
            }
        }

        //Move one space to the right
        private void MoveRight(float deltaTime)
        {
            if (Input.IsKeyDown(68))
            {
                X += 100 * deltaTime;
            }
        }
    }
}
