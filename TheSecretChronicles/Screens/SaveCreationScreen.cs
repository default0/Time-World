using osu.Framework.Allocation;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Screens;
using osu.Framework.Graphics;
using OpenTK;
using osu.Framework.Input;
using OpenTK.Input;
using System.Linq;
using TheSecretChronicles.Controls;

namespace TheSecretChronicles.Screens
{
    public class SaveCreationScreen : Screen
    {
        private ConfirmableTextBox saveNameBox;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(
                saveNameBox = new ConfirmableTextBox
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(300f, 50f),
                    PlaceholderText = "Save name"
                }
            );
            saveNameBox.Confirmed += SaveNameBox_OnConfirmed;
            Schedule(() => saveNameBox.TriggerFocus());
        }

        private void SaveNameBox_OnConfirmed()
        {
            createSave();
        }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if (args.Key == Key.Enter && IsCurrentScreen)
            {
                createSave();
                return true;
            }

            return base.OnKeyDown(state, args);
        }

        private void createSave()
        {
            if (saveNameBox.Text == "")
                return;
            IOHelper.WriteTextFile($"Saves/{saveNameBox.Text}", "Test");
            Push(new WorldScreen(saveNameBox.Text));
        }
    }
}