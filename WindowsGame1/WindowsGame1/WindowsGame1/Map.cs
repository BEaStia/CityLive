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
    public struct Map
    {
        public static int Width;
        public static int Height;
        public static int CellWidth;
        public static int CellHeight;
        public static Cell[,] map;
        public static Zone[,] Zmap;
        public Map(int width, int height)
        {
            ///Зона - 10 на 10
            Width = width;
            Height = height;
            CellHeight = ((Texture2D)Storage.Images["Background1"]).Height;
            CellWidth = ((Texture2D)Storage.Images["Background1"]).Width;
            Zmap = new Zone[Width / 10, Height / 10];

            //map = new Cell[Width, Height];
            for (int j = 0; j < Height/10; j++)
            {
                for (int i = 0; i < Width/10; i++)
                {
                    //map[i, j] = new Cell(i,j);
                    Zmap[i, j] = new Zone(10, 10, i, j);
                }
            }
        }
        public static Cell Get(int x, int y)
        {
            int X = x / 10;
            int Y = y / 10;
            return Zmap[X, Y][x-X*10, y-Y*10];        
        }

        public static void Set(int x, int y, Cell value)
        {
            int X = x / 10;
            int Y = y / 10;
            Zmap[X, Y].cells[x - X * 10, y - Y * 10] = value;
        }
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < Width / 10; i++)
            {
                for (int j = 0; j < Height / 10; j++)
                {
                    Zmap[i, j].Update(gameTime);
                }
            }
        }
    }
    public struct Cell
    {
        string Name;
        public Cell(string name)
        {
            Name = name;
            //X = x;
            //Y = y;
        }
        public void Draw(Vector2 Pos1)
        {
            Game1.spriteBatch.Draw((Texture2D)Storage.Images[Name], Pos1, Color.White);
        }
        
    }
    public struct Zone
    {
        public int X, Y;
        public Cell[,] cells;
        public List<GameObject> sprites;
        public Zone(int width, int height,int x,int y)
        {
            cells = new Cell[width, height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    cells[i, j] = new Cell("Background1");  
                }
            }
            X = x;
            Y = y;
            sprites = new List<GameObject>();
        }
        public Cell this[int x, int y]
        {
            get
            {
                return cells[x, y];
            }
            set
            {
                cells[x, y] = value;
            }
        }
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Update(gameTime);
            }
        }
    }
}
