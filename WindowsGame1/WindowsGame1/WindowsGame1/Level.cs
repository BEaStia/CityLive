using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    class Level
    {
        public Map map;
        
        public void Load(ContentManager Content)
        {
            map = new Map(50, 50);
        }
        public void Update(GameTime gameTime)
        {
            map.Update(gameTime);
        }
    }
}
