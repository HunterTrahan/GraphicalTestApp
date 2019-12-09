using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Rat : Enemy
    {
        //Creates a instances of random
        Random Rand = new Random();

        //used to prevent the enemy from clipping
        private int Counter = 502;

        //keeps track of the last random number
        private int LastRand = 0;

        //creates a timer to delay the rats movement
        Timer Dely = new Timer();

        //Create the rat enemy
        public Rat(float x, float y) : base(x, y)
        {
            if (Dely.Seconds >= 0.1f)
            {
                Dely.Restart();
                OnUpdate += Move;
            }
        }

        //Define what it is to move
        protected override void Move(float deltaTime)
        {
            if(Counter >= 500)
            {
                Counter = 0;
                LastRand = Rand.Next(1,5);
            }
            else if(LastRand == 1)
            {
                MoveUp(deltaTime);
                Counter++;
            }
            else if(LastRand == 2)
            {
                MoveDown(deltaTime);
                Counter++;
            }
            else if(LastRand == 3)
            {
                MoveLeft(deltaTime);
                Counter++;
            }
            else if(LastRand == 4)
            {
                MoveRight(deltaTime);
                Counter++;
            }  
        }
    }
}
