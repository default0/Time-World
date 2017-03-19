using OpenTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using TheSecretChronicles.Screens;

namespace TheSecretChronicles.Game.World
{
    public class World : Container
    {
        private WorldScreen screen;

        public World(WorldScreen screen)
        {
            this.screen = screen;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            WorldPlayer player = new WorldPlayer();
            player.Origin = Anchor.Centre;
            player.Position = new Vector2(64, 64);
            AutoSizeAxes = Axes.Both;
            Add(new Waypoint(screen) { LevelName = "Resources\\Levels\\lvl_3.tsclvl" });

            Add(player);
        }
    }
}
