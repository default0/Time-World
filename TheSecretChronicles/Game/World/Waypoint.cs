using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecretChronicles.Screens;

namespace TheSecretChronicles.Game.World
{
    public class Waypoint : Sprite
    {
        public string LevelName;
        private WorldScreen screen;

        public Waypoint(WorldScreen screen)
        {
            this.screen = screen;
            Texture = TextureLoader.FromStream(File.OpenRead("Resources\\Graphics\\World\\waypoint.png"));
        }

        public void Enter()
        {
            screen.EnterLevel(LevelName);
        }
    }
}
