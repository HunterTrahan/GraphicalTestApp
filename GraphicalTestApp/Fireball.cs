using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Fireball : Entity
    {
        //create the sprite for the fireball
        private Sprite _sprite = new Sprite("Sprites/Weapons/Fireball.png");

        //Creates a hitbox for the fireball
        private AABB _hitbox = new AABB(16,16);

        //Creates the fireball entity
        public Fireball(float x, float y) : base(x,y)
        {
            AddChild(_sprite);
            AddChild(_hitbox);
        }
    }
}
