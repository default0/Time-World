using osu.Framework.Graphics.Textures;
using System.IO;

namespace TheSecretChronicles.Game.Animations
{
    public class Frame
    {
        public float Duration;
        public Texture Texture { get; private set; }
        public (bool Horizontal, bool Vertical) Mirrored;


        public Frame(float duration, string texturePath)
        {
            Duration = duration;
            Texture = TextureLoader.FromStream(File.OpenRead(texturePath));
        }

        
    }
}