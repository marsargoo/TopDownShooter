using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Security.Cryptography;

namespace TopDownShooter
{
    public class Imp : Mob
    {

        public Imp(Vector2 POS) : base("2D\\Units\\Mobs\\Imp", POS, new Vector2(40,40))
        {
            speed = 1.5f;
        }

        public override void Update(Vector2 OFFSET, Hero HERO)
        {
            base.Update(OFFSET, HERO);
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
