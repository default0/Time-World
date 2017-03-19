using osu.Framework.Allocation;
using osu.Framework.Screens;
using TheSecretChronicles.Game;

namespace TheSecretChronicles.Screens
{
    public class LevelScreen : Screen
    {
        private string levelName;

        public LevelScreen(string levelName)
        {
            this.levelName = levelName;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new Level(levelName));
        }
    }
}