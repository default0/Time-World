using OpenTK.Graphics;
using OpenTK.Input;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input;
using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using TheSecretChronicles.Controls.Buttons;

namespace TheSecretChronicles.Screens
{
    public class SaveSelectScreen : Screen
    {
        private Container<Drawable> _selectedSave;
        private Container<Drawable> selectedSave
        {
            get { return _selectedSave; }
            set
            {
                if (_selectedSave != null)
                {
                    _selectedSave.Colour = Color4.White;
                    _selectedSave.ScaleTo(1f, 1000);
                }

                _selectedSave = value;
                _selectedSave.Colour = Color4.Yellow;
            }
        }
        private FillFlowContainer fc;

        [BackgroundDependencyLoader]
        private void load()
        {
            var saves = IOHelper.GetFiles("Saves");
            Add(
                fc = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Children = new Drawable[]
                    {
                        selectedSave = new NewSaveButton(this)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = "New Save"
                        }
                    }
                }
            );
            fc.Add(saves.Select(savePath => new SelectSaveButton(this, savePath) { Anchor = Anchor.Centre, Origin = Anchor.Centre }));
        }

        protected override void Update()
        {
            if (selectedSave.Scale.X == 1f)
                selectedSave.ScaleTo(1.1f, 1000);
            else if (selectedSave.Scale.X == 1.1f)
                selectedSave.ScaleTo(1f, 1000);

            base.Update();
        }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if (!IsCurrentScreen)
                return base.OnKeyDown(state, args);

            if (args.Key == Key.Enter)
            {
                selectedSave.TriggerClick(state);
            }
            else if (args.Key == Key.Down)
            {
                bool foundSelectedSave = false;
                foreach (var child in fc.Children)
                {
                    if (foundSelectedSave)
                    {
                        selectedSave = (Container<Drawable>)child;
                        break;
                    }
                    if (child == selectedSave)
                    {
                        if (child != fc.Children.Last())
                        {
                            foundSelectedSave = true;
                        }
                        else
                        {
                            selectedSave = (Container<Drawable>)fc.Children.First();
                            break;
                        }
                    }
                }
            }
            else if (args.Key == Key.Up)
            {
                Drawable lastChild = null;
                foreach (var child in fc.Children)
                {
                    if (child == selectedSave)
                    {
                        if (lastChild == null)
                            selectedSave = (Container<Drawable>)fc.Children.Last();
                        else
                            selectedSave = (Container<Drawable>)lastChild;
                        break;
                    }
                    lastChild = child;
                }
            }


            return true;
        }
    }
}