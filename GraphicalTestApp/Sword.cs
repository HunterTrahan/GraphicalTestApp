using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Sword : Entity
    {
        private Sprite _sprite;
        private AABB _hitbox;
        public bool isSwinging;

        private int _damage = 5;

        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public Sword(float x, float y) : base(x, y)
        {
            _sprite = new Sprite("Sprites/Weapons/Sword.png");
            AddChild(_sprite);
            OnUpdate += RotateSword;
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