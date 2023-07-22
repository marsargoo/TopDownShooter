﻿using System;
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

namespace TopDownShooter
{
    public class Hero : Unit
    {

        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET)
        {
            bool checkScroll = false;

            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
                checkScroll = true;
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);

            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET));
            }

            if (checkScroll)
            {
                GameGlobals.CheckScroll(pos);
            }

            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
