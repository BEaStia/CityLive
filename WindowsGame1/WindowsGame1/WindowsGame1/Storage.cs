﻿using System;
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
using System.Collections;
namespace WindowsGame1
{
    /// <summary>
    /// Класс хранилища
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Хранение картинок
        /// </summary>
        public static Hashtable Images;
        /// <summary>
        /// Загрузка картинок
        /// </summary>
        /// <param name="Content">КонтентМенеджер</param>
        public void Load(ContentManager Content)
        {
            Images = new Hashtable();
            Images.Add("Sprites/Pedestrian/Stand",Content.Load<Texture2D>("Sprites/Pedestrian/Stand"));
            Images.Add("Sprites/Pedestrian/Move", Content.Load<Texture2D>("Sprites/Pedestrian/Move"));
            Images.Add("Sprites/Pedestrian/Shoot", Content.Load<Texture2D>("Sprites/Pedestrian/Shoot"));
            Images.Add("Sprites/Pedestrian/Die", Content.Load<Texture2D>("Sprites/Pedestrian/Die"));
            Images.Add("Background1", Content.Load<Texture2D>("Sprites/Asphalt"));            
        }
    }
}
