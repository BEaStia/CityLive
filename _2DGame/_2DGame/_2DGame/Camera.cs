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
    public class Camera
    {
        public int Width;
        public int Height;
        public Vector2 Position;
        public Map map;
        public void Draw(GameTime gameTime)
        {
            for (int i = (int)Position.X - Width / 2; i < (int)Position.X + Width / 2; i++)
            {
                for (int j = (int)Position.Y - Height / 2; j < (int)Position.Y + Height / 2; j++)
                {
                    if (map[i, j].Type == 0)
                    {
                        ///Если не список
                        ((DrawableGameObject)map[i, j]).Draw(gameTime, new Vector2(this.Width / 2, this.Height / 2) - ((DrawableGameObject)map[i, j]).GlobalPosition - this.Position);
                    }
                    else
                    {
                        foreach (DrawableGameObject T in ((List<DrawableGameObject>)map[i, j].Value))
                        {
                            T.Draw(gameTime, new Vector2(this.Width / 2, this.Height / 2) - ((DrawableGameObject)map[i, j]).GlobalPosition - this.Position);
                        }
                        ///Если список
                    }
                }
            }
        }
    }
}
