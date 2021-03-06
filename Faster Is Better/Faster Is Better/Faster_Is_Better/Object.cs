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
    abstract class Object
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle? sourceRectangle = null;

        public int width;
        public int height;
        public Color color;
        public float angle;
        public float angleOffset;
        public Vector2 origin;

        public int speed = 8;

        public int windowWidth;
        public int windowHeight;

        public Vector2 velocity;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, width, height);
            }
        }

        private int currentFrame = 0;
        public int CurrentFrame
        {
            get
            {
                return currentFrame;
            }
            set
            {
                if (value < maxFrame)
                    currentFrame = value;
                else if (value == maxFrame)
                    currentFrame = 0;
            }
        }
        public int currentAnimation;

        private int frameTimer;
        public int FrameTimer
        {
            get
            {
                return frameTimer;
            }
            set
            {
                if (value <= maxFrameTimer)
                    frameTimer = value;
                else if (value >= maxFrameTimer)
                {
                    frameTimer = 0;
                    CurrentFrame++;
                }
            }
        }

        public abstract void Update();

        public int maxFrameTimer = 5;

        public int maxFrame { get { return (texture.Width / width) - 1; } }
        public int maxAnimation { get { return (texture.Height / height) - 1; } }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, rectangle, sourceRectangle, color, angle + angleOffset, origin, SpriteEffects.None, 1f);
        }

        public static Vector2 RectangleToRectangle(float x1, float y1, int w1, int h1, float x2, float y2, int w2, int h2)
        {
            float dw = 0.5f * (w1 + w2);
            float dh = 0.5f * (h1 + h2);
            float dx = (x1) - (x2 + w2 / 2);
            float dy = (y1) - (y2 + h2 / 2);

            if (Math.Abs(dx) <= dw && Math.Abs(dy) <= dh)
            {
                float wy = dw * dy;
                float hx = dh * dx;

                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        y1 = y2 + h2;

                    }
                    else
                    {

                        x1 = x2 - w1;
                    }
                }
                else
                {
                    if (wy > -hx)
                    {
                        x1 = x2 + w2;
                    }
                    else
                    {
                        y1 = y2 - h1;
                    }
                }
            }

            return new Vector2(x1, y1);
        }
    }
}
