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
        public AABB _hitbox = new AABB(16, 16);

        //Determines if the sword is swinging or not
        public bool isSwinging;

        //swords damage
        private int _damage = 5;

        //Instance the sword
        private static Sword _instance;

        public static Sword Instance
        {
            get { return _instance; }
        }

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
            _instance = this;
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
                    Rotate(-1.5f);
                    Parent.Parent.RemoveChild(Parent);
                    
                }
            }
        }
    }
}