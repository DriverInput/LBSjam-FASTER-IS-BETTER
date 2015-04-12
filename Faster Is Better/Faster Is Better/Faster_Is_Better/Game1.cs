using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Faster_Is_Better
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static List<object> objects = new List<object>();

        Texture2D texture;

        public static float globalTime = 1f;//0.5f;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 480*2;
            graphics.PreferredBackBufferHeight = 480*2;
            Content.RootDirectory = "Content";
            Mouse.SetPosition(1920/2,1080/2);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            texture = Content.Load<Texture2D>("Player");
            objects.Add(new Player(texture, new Vector2(320 - 16, 240 - 16)));
            for (int i = 0; i < 360; i += 10)
            {
                objects.Add(new Polis(texture, new Vector2(480 + (float)Math.Cos(MathHelper.ToRadians(i)) * 420, 480 + (float)Math.Sin(MathHelper.ToRadians(i)) * 420)));
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                objects.Add(new Bullet(texture, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), 0));
            }

            foreach (Object obj in objects)
            {
                obj.Update();
            }

            base.Update(gameTime);
        }

        //public static void AddBullet(Vector2 newPos, float newAngle)
        //{
        //    objects.Add(new Bullet(texture, newPos, newAngle));
        //}

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            foreach (Object obj in objects)
            {
                obj.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
