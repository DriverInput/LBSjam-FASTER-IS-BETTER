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
    class Player : Object
    {
        int dir;

        public Player(Texture2D newTex, Vector2 newPos)
        {
            texture = newTex;
            position = newPos;
            width = 64;
            height = 64;
        }

        public override void Update()
        {
            if (KeyDown(Keys.A))
            {
                velocity.X = -1;
            }
            else if (KeyDown(Keys.D))
            {
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            if (KeyDown(Keys.W))
            {
                velocity.Y = -1;
            }
            else if (KeyDown(Keys.S))
            {
                velocity.Y = 1;
            }
            else
            {
                velocity.Y = 0;
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            position += velocity * 5;
        }

        private bool KeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
