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

namespace TopDownShooter.Source.GamePlay
{
    public class World
    {

        public Hero hero;
        public Vector2 offset;

        public List<Projectile> projectiles = new List<Projectile>();
        public World()
        {
            hero = new Hero("2D/Hero", new Vector2(300, 300), new Vector2(48, 48));
            GameGlobals.PassProjectile = AddProjectile;
            offset = new Vector2(0,0);
        }

        public virtual void Update()
        {
            hero.Update();

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);

                if (projectiles[i].isDone)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
            
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
