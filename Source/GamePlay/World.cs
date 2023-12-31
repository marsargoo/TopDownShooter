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

namespace TopDownShooter.Source.GamePlay
{
    public class World
    {
        public UI ui;
        public int numKilled;

        public Hero hero;
        public Vector2 offset;

        public List<Projectile> projectiles = new List<Projectile>();
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public World()
        {
            hero = new Hero("2D/Hero", new Vector2(300, 300), new Vector2(48, 48));
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMobs;
            GameGlobals.CheckScroll = CheckScroll;
            offset = new Vector2(0,0);

            spawnPoints.Add(new SpawnPoint("2D\\Misc\\circle", new Vector2(50, 50), new Vector2(35, 35)));
            
            spawnPoints.Add(new SpawnPoint("2D\\Misc\\circle", new Vector2(Globals.screenWidth / 2, 50), new Vector2(35, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("2D\\Misc\\circle", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            ui = new UI();
            numKilled = 0;
        }

        public virtual void Update()
        {
            hero.Update(offset);

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(offset);

            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, mobs.ToList<Unit>());

                if (projectiles[i].isDone)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Update(offset, hero);

                if (mobs[i].isDead)
                {
                    numKilled++;
                    mobs.RemoveAt(i);
                    i--;
                }
            }

            ui.Update(this);
        }

        public virtual void AddMobs(object INFO)
        {
            mobs.Add((Mob)INFO);
            
        }
        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);

        }

        public virtual void CheckScroll(object INFO)
        {
            Vector2 tempVector = (Vector2)INFO;

            if (tempVector.X < -offset.X + Globals.screenWidth * .4f)
            {
                offset = new Vector2(offset.X + hero.speed, offset.Y);
            }
            if (tempVector.X > -offset.X + Globals.screenWidth * .6f)
            {
                offset = new Vector2(offset.X - hero.speed, offset.Y);
            }
            if (tempVector.Y < -offset.Y + Globals.screenHeight * .4f)
            {
                offset = new Vector2(offset.X, offset.Y + hero.speed);
            }
            if (tempVector.Y > -offset.Y + Globals.screenHeight * .6f)
            {
                offset = new Vector2(offset.X, offset.Y - hero.speed);
            }
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);

            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }

            ui.Draw(this);
        }
    }
}
