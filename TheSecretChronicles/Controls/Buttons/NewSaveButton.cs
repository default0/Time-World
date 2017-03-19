using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Input;
using osu.Framework.Screens;
using TheSecretChronicles.Screens;

namespace TheSecretChronicles.Controls.Buttons
{
    public class NewSaveButton : SpriteText
    {
        private Screen screen;

        public NewSaveButton(Screen screen)
        {
            this.screen = screen;
            Text = "New Save";
        }

        protected override bool OnClick(InputState state)
        {
            screen.Push(new SaveCreationScreen());

            return base.OnClick(state);
        }
    }
}
