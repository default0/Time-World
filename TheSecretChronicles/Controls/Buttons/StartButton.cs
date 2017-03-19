using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using System.IO;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input;
using osu.Framework.Screens;
using TheSecretChronicles.Screens;

namespace TheSecretChronicles.Controls.Buttons
{
    public class StartButton : Sprite
    {
        private Screen screen;

        public StartButton(Screen screen)
            : base()
        {
            this.screen = screen;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Texture = TextureLoader.FromStream(File.OpenRead("Resources/Graphics/Menu/start.png"));
        }

        protected override bool OnClick(InputState state)
        {
            
            screen.Push(new SaveSelectScreen());
            return base.OnClick(state);
        }
    }
}