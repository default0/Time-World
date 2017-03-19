using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecretChronicles.Game.Animations
{
    public class Animation : IEnumerable<Frame>
    {
        public string Name { get; private set; }
        private List<Frame> frames = new List<Frame>(); 
        private float currentTime;
        public bool Loop = true;

        public float Duration { get; private set; }

        public Frame CurrentFrame
        {
            get
            {
                float time = currentTime;
                foreach (var frame in frames)
                {
                    time -= frame.Duration;
                    if (time <= 0f)
                        return frame;
                }
                return frames[frames.Count - 1];
            }

        }
        
        public Animation(string name)
        {
            this.Name = name;
        }

        public void Reset()
        {
            currentTime = 0;
        }

        public void Add(Frame frame)
        {
            frames.Add(frame);
            Duration += frame.Duration;
        }

        public void GoToFrame(int index)
        {
            currentTime = frames.Take(index).Sum(f => f.Duration);
        }

        public void AdvanceTime(float time)
        {
            currentTime += time;
            if (Loop)
            {
                currentTime %= Duration;
            }
        }

        public IEnumerator<Frame> GetEnumerator() => frames.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => frames.GetEnumerator();
    }
}
