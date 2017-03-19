using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Input;
using osu.Framework.Screens;
using TheSecretChronicles.Screens;
using System.IO;

namespace TheSecretChronicles.Controls.Buttons
{
    public class SelectSaveButton : SpriteText
    {
        private Screen screen;
        private string saveName;

        public SelectSaveButton(Screen screen, string saveName)
        {
            this.saveName = Path.GetFileName(saveName);
            this.screen = screen;
            Text = saveName;
        }

        protected override bool OnClick(InputState state)
        {
            screen.Push(new WorldScreen(saveName));

            return base.OnClick(state);
        }
    }
}
