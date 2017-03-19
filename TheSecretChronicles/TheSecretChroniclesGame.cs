using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Input;
using TheSecretChronicles.Screens;

namespace TheSecretChronicles
{
    public class TheSecretChroniclesGame : osu.Framework.Game
    {
        public const float Fps = 60.0f;

        [BackgroundDependencyLoader]
        private void load()
        {
            this.Host.MaximumUpdateHz = Fps;
            
            Add(new MainMenuScreen());
        }
    }
}