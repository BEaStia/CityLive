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
        public int Width;
        public int Height;
        public Cell[,] map;
        public Map(int width, int height,Texture2D texture)
        {
            Width = width;
            Height = height;
            map = new Cell[Width, Height];
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    map[i, j] = new Cell(texture,i,j);
                }
            }
        }
    }
    public class Cell
    {
        public List<GameObject> objects;
        public Texture2D BackGround;
        public int X, Y;
        public Cell(Texture2D bg,int x,int y)
        {
            X = x;
            Y = y;
            BackGround = bg;
            objects = new List<GameObject>();
        }
        
    }
}
