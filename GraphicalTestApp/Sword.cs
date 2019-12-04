using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Sword : Entity
    {
        //Refrence to the sprite
        private Sprite _sprite;

        //Create the hitbox for the sword
        private AABB _hitbox = new AABB(16, 16);

        //Determines if the sword is swinging or not
        public bool isSwinging;

        //swords damage
        private int _damage = 5;

        //Gets the swords damage
        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        //Create the sword entity
        public Sword(float x, float y) : base(x, y)
        {
            _sprite = new Sprite("Sprites/Weapons/Sword.png");
            AddChild(_sprite);
            OnUpdate += RotateSword;
            AddChild(_hitbox);
        }

        //Rotate the sword and remove sword
        public void RotateSword(float deltaTime)
        {
            if (isSwinging)
            {
                Rotate(5f * deltaTime);
                if (GetRotation() >= 2)
                {
                    isSwinging = false;

                    //Removes the swordnode from the player
                    Parent.Parent.RemoveChild(Parent);
                    Rotate(-1.5f);
                }
            }
        }
    }
}