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

        //Sprite swordGraphic = new Sprite("Sprites/People/Sword.png");

        private int _damage = 5;

        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public Sword(float x, float y) : base(12, 76)
        {
            OnStart += CreateSword;
        }

        //Add sword to the scene
        private void CreateSword()
        {
            Sword _sword = new Sword(14, 78);
            Sprite swordGraphic = new Sprite("Sprites/People/Sword.png");
        }

        //remove sword from the scene
        private void DetachSword()
        {
            
        }
    }
}
