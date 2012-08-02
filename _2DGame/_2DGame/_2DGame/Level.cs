using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2DGame
{
    public class Level
    {
        public List<GameObject> sprites;
        public List<Camera> cameras;
        public Level(SpriteBatch spriteBatch, ContentManager Content)
        {

            sprites = new List<GameObject>();
            GameObject T = new DrawableGameObject(spriteBatch);
            ((DrawableGameObject)T).Load(Content);
            sprites.Add(T);
            cameras = new List<Camera>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (GameObject T in sprites)
            {
                T.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime)
        {
            foreach (Camera T in cameras)
            {
                
            }
            foreach (GameObject T in sprites)
            {
                T.Draw(gameTime);
            }
        }
    }
}
