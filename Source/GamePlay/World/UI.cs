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
using TopDownShooter.Source.GamePlay;

namespace TopDownShooter
{
    public class UI
    {
        public SpriteFont font;
        public UI() {
            font = Globals.content.Load<SpriteFont>("Font\\Arial16");
        }

        public void Update(World WORLD)
        {

        }

        public void Draw(World WORLD)
        {
            String tempString = "Number of Mobs killed: " + WORLD.numKilled;
            Vector2 strDims = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight - 40), Color.White);
        }
    }
}
