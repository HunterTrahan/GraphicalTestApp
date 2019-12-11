using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Dragon : Enemy
    {
        //Creates a stopwatch
        Stopwatch stopwatch = new Stopwatch();

        //Create the dragon entity
        public Dragon(float x, float y) : base(x, y)
        {
            stopwatch.Start();
            //OnUpdate += Move;   
            OnUpdate += FireBall;
        }

        //allows the dragon to shoot fireball
        public void FireBall(float deltaTime)
        {
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                Fireball ballfire = new Fireball(16, 16);

                ballfire.XAcceleration = -0.01f;

                ballfire.X = X - 1;
                ballfire.Y = Y - 1;

                Parent.AddChild(ballfire);

                stopwatch.Restart();
            }
        }
    }

}
