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
    class Bullet : Object
    {
        public Bullet(Texture2D newTex, Vector2 newPos, float newAngle)
        {
            texture = newTex;
            position = newPos;
            color = Color.Yellow;
            width = 8;
            height = 8;
            origin = Vector2.One * 4;
            //angle = newAngle;
            //velocity.X = (float)Math.Cos(MathHelper.ToRadians(newAngle));
            //velocity.Y = (float)Math.Sin(MathHelper.ToRadians(newAngle));
            Console.WriteLine("Spawned bullet");
        }

        public override void Update()
        {
            //position += velocity * Game1.globalTime;
        }
    }
}
