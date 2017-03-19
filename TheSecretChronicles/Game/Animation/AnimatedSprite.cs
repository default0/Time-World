using OpenTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecretChronicles.Game.Animations
{
    public class AnimatedSprite : Sprite
    {
        private List<Animation> animations = new List<Animation>();
        private Animation currentAnimation;
        public bool IsPlaying { get; private set; }

        protected override void Update()
        {
            base.Update();

            Frame previousFrame = currentAnimation.CurrentFrame;
            if (IsPlaying)
            {
                currentAnimation.AdvanceTime(1000f / (float)Clock.FramesPerSecond);
            }
            if (previousFrame != currentAnimation.CurrentFrame)
            {
                changeFrame(previousFrame, currentAnimation.CurrentFrame);
            }


        }

        public void GoToFrame(int index)
        {
            currentAnimation.GoToFrame(index);
        }

        public void PlayAnimation(string name)
        {
            IsPlaying = true;
            if (currentAnimation.Name == name)
                return;

            Frame previousFrame = currentAnimation.CurrentFrame;
            currentAnimation = animations.Single(x => x.Name == name);
            currentAnimation.Reset();
            changeFrame(previousFrame, currentAnimation.CurrentFrame);
        }

        public void PauseAnimation()
        {
            IsPlaying = false;
        }

        public void StartAnimation()
        {
            IsPlaying = true;
        }

        public void ResetAnimation()
        {
            Frame previousFrame = currentAnimation.CurrentFrame;
            currentAnimation.Reset();
            if (previousFrame != currentAnimation.CurrentFrame)
                changeFrame(previousFrame, currentAnimation.CurrentFrame);
        }

        public void StopAnimation()
        {
            PauseAnimation();
            ResetAnimation();
        }

        private void changeFrame(Frame previousFrame, Frame currentFrame)
        {
            Texture = currentFrame.Texture;
            if (previousFrame.Mirrored.Horizontal != currentFrame.Mirrored.Horizontal)
                Scale = new Vector2(-Scale.X, Scale.Y);
            if (previousFrame.Mirrored.Vertical != currentFrame.Mirrored.Vertical)
                Scale = new Vector2(Scale.X, -Scale.Y);
        }

        public void AddAnimation(Animation animation)
        {
            animations.Add(animation);
            if (animations.Count == 1)
                currentAnimation = animation;
        }

        [BackgroundDependencyLoader]
        private void load()
        {

        }
    }
}

/**/
