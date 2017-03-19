using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecretChronicles.Game.Animations;
using osu.Framework.Input;
using OpenTK.Input;

namespace TheSecretChronicles.Game.World
{
    public class WorldPlayer : Container
    {
        private InputManager inputManager;
        private AnimatedSprite animation;
        private float speed = 400;

        [BackgroundDependencyLoader]
        private void load(UserInputManager inputManager)
        {
            this.inputManager = inputManager;
            animation = new AnimatedSprite();
            animation.AddAnimation(new Animation("down") {
                new Frame(125f, "Resources\\Graphics\\World\\Player\\down.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\down_1.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\down.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\down_2.png")
            });
            animation.AddAnimation(new Animation("up") {
                new Frame(125f, "Resources\\Graphics\\World\\Player\\up.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\up_1.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\up.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\up_2.png")
            });
            animation.AddAnimation(new Animation("left") {
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left_1.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left.png"),
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left_2.png")
            });
            animation.AddAnimation(new Animation("right") {
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left.png") { Mirrored = (true, false) },
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left_1.png") { Mirrored = (true, false) },
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left.png") { Mirrored = (true, false) },
                new Frame(125f, "Resources\\Graphics\\World\\Player\\left_2.png") { Mirrored = (true, false) }
            });
            animation.Anchor = Anchor.Centre;
            animation.Origin = Anchor.Centre;
            animation.RelativeSizeAxes = Axes.Both;
            Add(animation);
            Width = 64;
            Height = 64;
            animation.PlayAnimation("right");
        }

        protected override void Update()
        {
            base.Update();
            var keys = inputManager.CurrentState.Keyboard.Keys;
            if (keys.Contains(Key.Up) || keys.Contains(Key.W))
            {
                Y -= speed / TheSecretChroniclesGame.Fps;
                animation.PlayAnimation("up"); 
            }
            else if (keys.Contains(Key.Down) || keys.Contains(Key.S))
            {
                Y += speed / TheSecretChroniclesGame.Fps; 
                animation.PlayAnimation("down");
            }
            else if (keys.Contains(Key.Right) || keys.Contains(Key.D))
            {
                X += speed / TheSecretChroniclesGame.Fps; 
                animation.PlayAnimation("right");
            }
            else if (keys.Contains(Key.Left) || keys.Contains(Key.A))
            {
                X -= speed / TheSecretChroniclesGame.Fps; 
                animation.PlayAnimation("left");
            }
            else
            {
                animation.StopAnimation();
            }
        }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if(args.Key == Key.Enter)
            {
                ((Container)Parent).Children.OfType<Waypoint>().FirstOrDefault(x => x.BoundingBox.IntersectsWith(BoundingBox))?.Enter();
            }
            return base.OnKeyDown(state, args);
        }
    }
}
