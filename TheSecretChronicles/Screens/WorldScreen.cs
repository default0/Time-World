using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheSecretChronicles.Game.World;

namespace TheSecretChronicles.Screens
{
    public class WorldScreen : Screen
    {

        public WorldScreen(string saveName)
        {

        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new World(this));
        }

        public void EnterLevel(string levelName)
        {
            Push(new LevelScreen(levelName));
        }
    }
}
