using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TopDownShooter.Source.Engine.Input.KeyBoard;

namespace TopDownShooter
{
    internal class Globals
    {
        public static ContentManager Content;
        public static SpriteBatch spriteBatch;
        public static McKeyboard keyboard;
    }
}
