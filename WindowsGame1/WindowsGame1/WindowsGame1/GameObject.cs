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
    /// Игровой объект
    /// </summary>
    public class GameObject:DrawableGameComponent
    {
        /// <summary>
        /// Name of the Object, Used for loading data
        /// </summary>
        public String Name;
        /// <summary>
        /// Анимация простоя
        /// </summary>
        Animation Stand;
        /// <summary>
        /// Анимация ходьбы
        /// </summary>
        Animation Move;
        /// <summary>
        /// Анимация стрельбы
        /// </summary>
        Animation Shoot;
        /// <summary>
        /// Анимация смерти
        /// </summary>
        Animation Die;
        /// <summary>
        /// Состояние объекта
        /// </summary>
        State state;
        /// <summary>
        /// Положение объекта
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// Угол поворота объекта
        /// </summary>
        public float Angle;
        /// <summary>
        /// Масштаб
        /// </summary>
        public float Scale;
        public GameObject(Game1 Game)
            : base(Game)
        {
            Name = "Pedestrian";
        }
        public void Load()
        {
            Stand = new Animation((Texture2D)Storage.Images["Sprites/" + Name + "/Stand"],100);
            Move = new Animation((Texture2D)Storage.Images["Sprites/" + Name + "/Move"],100);
            Shoot = new Animation((Texture2D)Storage.Images["Sprites/" + Name + "/Shoot"],100);
            Die = new Animation((Texture2D)Storage.Images["Sprites/" + Name + "/Die"],100);
            state = State.Stand;
            
            base.LoadContent();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime,Vector2 position)
        {
            switch (state)
            {
                case State.Stand: Stand.Draw(position, Scale, Angle); break;
                case State.Move: Move.Draw(position, Scale, Angle); break;
                case State.Shoot: Shoot.Draw(position, Scale, Angle); break;
                case State.Die: Die.Draw(position, Scale, Angle); break;
            }
            base.Draw(gameTime);
        }
    }
}
