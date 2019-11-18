using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;
            

            Player player = new Player(12, 76);
            Sprite playerGraphic = new Sprite("Sprites/People/Player.png");
            //Sword sword = new Sword(14, 78);
            Sprite swordGraphic = new Sprite("Sprites/People/Sword.png");
            //sword.AddChild(swordGraphic);
            player.AddChild(playerGraphic);
            //player.AddChild(sword);

            root.AddChild(player);

            //## Set up game here ##//

            game.Run();
        }
    }
}
