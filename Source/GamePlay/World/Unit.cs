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
    public class Unit : Basic2D 
    {
        public float speed;

        public Unit(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        public override void Update()
        {
           
            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
