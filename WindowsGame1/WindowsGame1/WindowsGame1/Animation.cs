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

namespace WindowsGame1
{
    /// <summary>
    /// Анимация
    /// </summary>
    class Animation
    {
        /// <summary>
        /// Текстура для отрисовки
        /// </summary>
        Texture2D texture;
        /// <summary>
        /// Количество кадров
        /// </summary>
        int FrameCount;
        /// <summary>
        /// Номер кадра
        /// </summary>
        int FrameNumber;
        /// <summary>
        /// Текущий тик таймера между кадрами
        /// </summary>
        int Tick;
        /// <summary>
        /// Лимит тиков
        /// </summary>
        int MaxTicks;
        /// <summary>
        /// Высота кадра, она же ширина
        /// </summary>
        int FrameHeight;

        public Animation(Texture2D texture, int timer)
        {
            this.texture = texture;
            FrameHeight = texture.Height;
            FrameCount = texture.Width / texture.Height;
            MaxTicks = timer;
        }
        public void Draw(Vector2 Position,float Scale,float Angle)
        {
            Tick++;
            if (Tick >= MaxTicks)
            {
                Tick = 0;
                FrameNumber++;
                if (FrameNumber >= FrameCount)
                {
                    FrameNumber = 0;
                }
            }
            Game1.spriteBatch.Draw(texture, Position, new Rectangle(FrameHeight * FrameNumber, 0, FrameHeight, FrameHeight), Color.White, Angle, new Vector2(FrameHeight / 2, FrameHeight / 2), Scale, SpriteEffects.None, 1.0f);
        }
    }
}
