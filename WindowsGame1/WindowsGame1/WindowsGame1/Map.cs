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
    public class Map
    {
        public static int Width;
        public static int Height;
        public static int CellWidth;
        public static int CellHeight;
        public static Cell[,] map;
        public Map(int width, int height,Texture2D texture)
        {
            Width = width;
            Height = height;
            CellHeight = texture.Height;
            CellWidth = texture.Width;
            Storage.Images.Add("Background1", texture);
            map = new Cell[Width, Height];
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    map[i, j] = new Cell(i,j);
                }
            }
        }
    }
    public class Cell
    {
        public List<GameObject> objects;
        public int X, Y;
        public Cell(int x,int y)
        {
            X = x;
            Y = y;
            objects = new List<GameObject>();
        }
        public void Draw(Vector2 Pos1)
        {
            Game1.spriteBatch.Draw((Texture2D)Storage.Images["Background1"], Pos1, Color.White);
        }
        
    }
}
