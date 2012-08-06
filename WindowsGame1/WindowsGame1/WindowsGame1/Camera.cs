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
    class Camera
    {
        public Vector2 Position;
        public int Width;
        public int Height;
        public Camera(int width,int height)
        {
            Width = width;
            Height = height;
            Position = new Vector2(width / 2, height / 2);
        }
        public Camera(int width, int height,Vector2 Pos)
        {
            Width = width;
            Height = height;
            Position = Pos;
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.Position.X--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.Position.X++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.Position.Y++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.Position.Y--;
            }
            ///Движение камеры сюда
        }
        public void Draw(GameTime gameTime)
        {
            Rectangle rectangle = new Rectangle((int)Position.X - Width / 2, (int)Position.Y - Height / 2, Width, Height);
            int left = rectangle.Left / Map.CellWidth;
            int right = rectangle.Right / Map.CellWidth + 1;
            int top = rectangle.Top / Map.CellHeight;
            int bottom = rectangle.Bottom / Map.CellHeight + 1;
            if (left < 0)
                left = 0;
            if (top < 0)
                top = 0;
            for (int j = top; j < bottom&&j<Map.Height; j++)
            {
                for (int i = left; i < right&&i<Map.Width; i++)
                {
                    Vector2 mPos=new Vector2(i*Map.CellWidth,j*Map.CellHeight);
                    Map.Get(i, j).Draw(mPos-(this.Position - new Vector2(Width / 2, Height / 2)));
                }
            }
            for (int j = top / 10; j < bottom / 10+1 && j < Map.Height / 10; j++)
            {
                for (int i = left/10; i < right/10+1 && i < Map.Width/10; i++)
                {
                    for (int k = 0; k < Map.Zmap[i, j].sprites.Count; k++)
                    {
                        Map.Zmap[i, j].sprites[k].Draw(gameTime, Map.Zmap[i, j].sprites[k].Position-(this.Position-new Vector2(Width/2,Height/2)));
                    }
                }
            }
        }
    }
}
