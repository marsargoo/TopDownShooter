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

namespace TopDownShooter
{
    public class Projectile : Basic2D
    {
        public bool isDone;

        public float speed;

        public Vector2 direction;

        public Unit owner;

        public McTimer timer;

        public Projectile(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {

            isDone = false;

            speed = 5.0f;

            owner = OWNER;

            direction = TARGET - owner.pos;
            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            timer = new McTimer(1200);
        }

        public virtual void Update(Vector2 OFFSET, List<Unit> UNITS)
        {

            pos += direction * speed;



            timer.UpdateTimer();

            if (timer.Test())
            {
                isDone = true;
            }
            if (HitSomething(UNITS))
            {
                isDone = true;
            }

        }

        public virtual bool HitSomething(List<Unit> UNITS)
        {
            for (int i = 0; i < UNITS.Count; i++)
            {
                if (Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit();
                    return true;
                }          
            }

            return false;

        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
