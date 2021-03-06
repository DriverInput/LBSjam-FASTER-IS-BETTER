﻿using System;
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
            width = 32;
            height = 32;
            color = Color.Red;
            origin = Vector2.One * width / 2;
        }

        public override void Update()
        {

            position.X = Mouse.GetState().X;
            position.Y = Mouse.GetState().Y;
        }

        private bool KeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
