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
    class Polis : Object
    {
        Random rnd = new Random();

        int fireRate = 0;
        int fireTimer = 128;

        public Polis(Texture2D newTex, Vector2 newPos)
        {
            texture = newTex;
            position = newPos - Vector2.One * 32;
            color = Color.Blue;
            width = 64;
            height = 64;
            fireTimer += rnd.Next(-32, 32);
        }
        public override void Update(){
        //    fireTimer++;

        //    if (fireTimer == fireRate)
        //    {
        //        fireRate = 0;
        //        fireTimer = (128 + rnd.Next(-32, 32));
        //        Game1.AddBullet(position, (float)Math.Atan2(480 - position.Y, 480 - position.Y));
        //    }
        }
    }
}
