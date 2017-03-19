using osu.Framework.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Input;
using OpenTK.Input;

namespace TheSecretChronicles.Controls
{
    public class ConfirmableTextBox : TextBox
    {
        public event Action Confirmed;

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if(args.Key == Key.Enter)
            {
                Confirmed?.Invoke();
                return true;
            }

            return base.OnKeyDown(state, args);
        }
    }
}
