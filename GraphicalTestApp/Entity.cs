using System;

namespace GraphicalTestApp
{
    class Entity : Actor
    {
        private Vector3 _velocity = new Vector3();
        private Vector3 _acceleration = new Vector3();

        //Implement velocity on the X axis
        public float XVelocity
        {
            get
            {
                return _velocity.x;
            }
            set
            {
                _velocity.x = value;
            }
        }

        // Implement acceleration on the X axis
        public float XAcceleration
        {  
            get
            {
                return _acceleration.x;
            }
            set
            {
                _acceleration.x = value;
            }
        }

        //Implement velocity on the Y axis
        public float YVelocity
        {
            get
            {
                return _velocity.y;
            }
            set
            {
                _velocity.y = value;
            }
        }

        //Implement acceleration on the Y axis
        public float YAcceleration
        { 
            get
            {
                return _acceleration.y;
            }
            set
            {
                _acceleration.y = value;
            }
        }

        //Creates an Entity at the specified coordinates
        public Entity(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override void Update(float deltaTime)
        {
            //## Calculate velocity from acceleration ##//

            //## Calculate position from velocity ##//
            X += _velocity.x;
            Y += _velocity.y;

            base.Update(deltaTime);
        }
    }
}
