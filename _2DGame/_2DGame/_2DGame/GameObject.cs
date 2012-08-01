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


namespace _2DGame
{
    public class GameObject
    {
        public Vector2 GlobalPosition;
        public virtual void Draw(GameTime gameTime)
        {
        }
        public virtual void Update(GameTime gameTime)
        {
        }
    }
    public class DrawableGameObject:GameObject
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        public int Rotation;
        ///0 - право, 1 - лево, 2 - перед, 3 - зад
        public int FrameRate;
        public int CurrentFrame;
        public int CurrentTick;
        private static int FrameSize = 60;
        public int State;
        //0 - стоит
        //1 - идет
        KeyboardState state;
        public DrawableGameObject(SpriteBatch spriteBatch):base()
        {
            this.spriteBatch = spriteBatch;
            FrameRate = 3;
        }
        public void Load(ContentManager Content)
        {
            this.texture=Content.Load<Texture2D>("Sprites/NPC/Stand");
        }
        public override void Update(GameTime gameTime)
        {   
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Rotation = 1;                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Left))
            {
                State = 1;
            }
            else
            {
                if (!Keyboard.GetState().IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Left))
                {
                    State = 0;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Rotation = 0;                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Right))
            {
                State = 1;
            }
            else
            {
                if (!Keyboard.GetState().IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Right))
                    State = 0;
            }
            
            
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Rotation = 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Up))
            {
                State = 1;
            }
            else
            {
                if (!Keyboard.GetState().IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Up))
                    State = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Rotation = 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.Down))
            {
                State = 1;
            }
            else
            {
                if (!Keyboard.GetState().IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.Down))
                    State = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {

            }
            state = Keyboard.GetState();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, GlobalPosition, new Rectangle(CurrentFrame*FrameSize+State*FrameSize*5,Rotation*FrameSize,FrameSize,FrameSize),Color.White);
            CurrentTick++;
            if (CurrentTick >= FrameRate)
            {
                if (Rotation == 0&&State==1)
                    GlobalPosition.X++;
                if (Rotation == 1 && State == 1)
                    GlobalPosition.X--;
                if (Rotation == 2 && State == 1)
                    GlobalPosition.Y--;
                if (Rotation == 3 && State == 1)
                    GlobalPosition.Y++;
                if (CurrentFrame < 4)
                {
                    CurrentFrame++;
                }
                else
                    CurrentFrame = 0;
                CurrentTick = 0;
            }

            
        }
    }
    public class Level
    {
        public List<GameObject> sprites;
        public Level(SpriteBatch spriteBatch,ContentManager Content)
        {

            sprites = new List<GameObject>();
            GameObject T = new DrawableGameObject(spriteBatch);
            ((DrawableGameObject)T).Load(Content);
            sprites.Add(T);
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
            foreach (GameObject T in sprites)
            {
                T.Draw(gameTime);
            }
        }
    }
}
