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
    /// <summary>
    /// Карта с содержимым
    /// </summary>
    public struct Map
    {
        /// <summary>
        /// Длина карты, в картинках
        /// </summary>
        public static int Width;
        /// <summary>
        /// Высота карты, в картинках
        /// </summary>
        public static int Height;
        /// <summary>
        /// Длина ячейки
        /// </summary>
        public static int CellWidth;
        /// <summary>
        /// Высота ячейки
        /// </summary>
        public static int CellHeight;
        /// <summary>
        /// Двумерный массив ячеек. В общем-то нафиг не нужен.
        /// </summary>
        public static Cell[,] map;
        /// <summary>
        /// Двумерный массив зон
        /// </summary>
        public static Zone[,] Zmap;
        /// <summary>
        /// Конструктор уровня
        /// </summary>
        /// <param name="width">Ширина в картинках</param>
        /// <param name="height">Высота в картинках</param>
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
        /// <summary>
        /// Автоматизированное добавление юнита
        /// </summary>
        /// <param name="obj">Вставляемый юнит, координата должна быть прописана в нем!!!</param>
        public static void AddUnit(GameObject obj)
        {
            Vector2 Pos = obj.Position;
            int X = (int)(Pos.X / 10 /Map.CellWidth);
            int Y = (int)(Pos.Y / 10/Map.CellHeight);
            Zmap[X, Y].sprites.Add(obj);
        }
        /// <summary>
        /// Получить ячейку по адресу
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <returns>Возвращает ячейку</returns>
        public static Cell Get(int x, int y)
        {
            int X = x / 10;
            int Y = y / 10;
            return Zmap[X, Y][x-X*10, y-Y*10];        
        }
        /// <summary>
        /// Вставить элемент покоординатам
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <param name="value">Устанавливаемая ячейка</param>
        public static void Set(int x, int y, Cell value)
        {
            int X = x / 10;
            int Y = y / 10;
            Zmap[X, Y].cells[x - X * 10, y - Y * 10] = value;
        }
        /// <summary>
        /// Обновление всего уровня
        /// </summary>
        /// <param name="gameTime">Игровое время</param>
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < Width / 10; i++)
            {
                for (int j = 0; j < Height / 10; j++)
                {
                    Zmap[i, j].Update(gameTime);//Обновление каждой зоны
                }
            }
        }
        
    }
    /// <summary>
    /// Ячейка
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Имя текстурки на фон
        /// </summary>
        string Name;
        public Cell(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Отрисовать по координатам
        /// </summary>
        /// <param name="Pos1">Положение</param>
        public void Draw(Vector2 Pos1)
        {   
            Game1.spriteBatch.Draw((Texture2D)Storage.Images[Name], Pos1, Color.White);
        }
        
    }
    /// <summary>
    /// Зона ячеек
    /// </summary>
    public struct Zone
    {
        /// <summary>
        /// Координаты по осям
        /// </summary>
        public int X, Y;
        /// <summary>
        /// Массив ячеек
        /// </summary>
        public Cell[,] cells;
        /// <summary>
        /// Список объектов в зоне
        /// </summary>
        public List<GameObject> sprites;
        /// <summary>
        /// Отрисовать объекты в зоне
        /// </summary>
        /// <param name="gameTime">Время</param>
        public void Draw(GameTime gameTime)
        {
            foreach (GameObject T in sprites)
            {
                T.Draw(gameTime);
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="width">Длина в картинках</param>
        /// <param name="height">Ширина в картинках</param>
        /// <param name="x">Положение по x</param>
        /// <param name="y">Положение по y</param>
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
        /// <summary>
        /// Получить ячейку
        /// </summary>
        /// <param name="x">координата по x</param>
        /// <param name="y">координата по y</param>
        /// <returns>Ячейка</returns>
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
        /// <summary>
        /// Обновить все спрайты
        /// </summary>
        /// <param name="gameTime">Время</param>
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Update(gameTime);
            }
        }
    }
}
