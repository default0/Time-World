using OpenTK;
using OpenTK.Input;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input;
using osu.Framework.Screens;
using TheSecretChronicles.Controls.Buttons;

namespace TheSecretChronicles.Screens
{
    public class MainMenuScreen : Screen
    {
        private Sprite selectedButton;

        private StartButton startButton;

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            Add(
                new FillFlowContainer()
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[] 
                    {
                        startButton = new StartButton(this)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Size = new Vector2(256f, 128f)
                        }
                    }
                }
            );
            selectedButton = startButton;
        }

        protected override void Update()
        {
            if(selectedButton.Scale.X == 1f)
                selectedButton.ScaleTo(1.1f, 1000);
            else if(selectedButton.Scale.X == 1.1f)
                selectedButton.ScaleTo(1f, 1000);

            base.Update();
        }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if (!IsCurrentScreen)
                return base.OnKeyDown(state, args);

            if(args.Key == Key.Enter)
            {
                selectedButton.TriggerClick(state);
            }

            return true;
        }
    }
}