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
            OnUpdate += FireBall;
        }

        //allows the dragon to shoot fireball
        public void FireBall(float deltaTime)
        {
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                Fireball ballfire = new Fireball(16, 16);

                Vector3 Dposition = new Vector3(X,Y,1);
                Vector3 Pposition = new Vector3(Player.Instance.X, Player.Instance.Y, 1);
                Vector3 Direction = Dposition - Pposition;

                ballfire.XAcceleration = -0.0001f * Direction.x;
                ballfire.YAcceleration = -0.0001f * Direction.y;

                ballfire.X = X - 1;
                ballfire.Y = Y - 1;

                Parent.AddChild(ballfire);

                stopwatch.Restart();
            }
        }
    }

}
