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
    public class Basic2D
    {

        public Vector2 pos, dims;

        public float rot;

        public Texture2D myModel;

        public Basic2D(String PATH,Vector2 POS, Vector2 DIMS) 
        {
            pos = POS;
            dims = DIMS;

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 OFFSET) {

            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), SpriteEffects.None, 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {

            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(ORIGIN.X, ORIGIN.Y), SpriteEffects.None, 0);
            }
        }
    }
}
