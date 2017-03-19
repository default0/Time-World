using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheSecretChronicles.Game
{
    public class Level : Container
    {
        private static Dictionary<string, Action<Level, string>> settingsPropertySetters;
        static Level()
        {
            settingsPropertySetters = new Dictionary<string, Action<Level, string>>()
            {
                { "lvl_author", (Action<Level, string>)typeof(Level).GetProperty("Author").SetMethod.CreateDelegate(typeof(Action<Level, string>)) },
                { "lvl_version", (Action<Level, string>)typeof(Level).GetProperty("Version").SetMethod.CreateDelegate(typeof(Action<Level, string>)) },
                { "lvl_music", (Action<Level, string>)typeof(Level).GetProperty("Music").SetMethod.CreateDelegate(typeof(Action<Level, string>)) },
                { "lvl_description", (Action<Level, string>)typeof(Level).GetProperty("Description").SetMethod.CreateDelegate(typeof(Action<Level, string>)) },
                { "lvl_difficulty", (lvl, text) => { lvl.Difficulty = int.Parse(text); } },
            };
        }

        public string Author { get; set; }
        public string Version { get; set; }
        public string Music { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }

        public int CamLimitX { get; set; }
        public int CamLimitY { get; set; }
        public int CamLimitW { get; set; }
        public int CamLimitH { get; set; }

        public double CamFixedHorizontalVelocity { get; set; }

        public Level(string levelFilePath = null)
        {
            if (levelFilePath != null)
                LoadData(levelFilePath);
        }

        public void LoadData(string path)
        {
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                while(reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;

                    switch(reader.Name)
                    {
                        case "settings":
                            loadSettings(reader.ReadSubtree());
                            break;
                    }
                    ;
                }
            }
        }

        private void loadSettings(XmlReader reader)
        {
            while(reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element)
                    continue;

                reader.GetAttribute("name");
                reader.GetAttribute("value");
            }
        }
    }
}
