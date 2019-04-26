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

namespace HugoMundo4
{
    class Walls
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Texture2D texture;
        Game game;

        public Walls(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;

            this.verts = new VertexPositionTexture[]
            {
                              
                //Frente
                new VertexPositionTexture(new Vector3(-5,8,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,4,0),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,4,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,8,0),Vector2.UnitY), 
                new VertexPositionTexture(new Vector3(5,8,0),Vector2.One), 
                new VertexPositionTexture(new Vector3(5,4,0),Vector2.UnitX), 

                new VertexPositionTexture(new Vector3(-5,4,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-1,0,0),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,0,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,4,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-1,4,0),Vector2.One),
                new VertexPositionTexture(new Vector3(-1,0,0),Vector2.UnitX),

                new VertexPositionTexture(new Vector3(5,4,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,0,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(1,0,0),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,4,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(1,0,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(1,4,0),Vector2.One),

                //Costas
                new VertexPositionTexture(new Vector3(-5,8,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,4,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,4,-12),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,8,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,8,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(5,4,-12),Vector2.UnitX),

                new VertexPositionTexture(new Vector3(-5,4,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-1,0,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,0,-12),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,4,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-1,4,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(-1,0,-12),Vector2.UnitX),

                new VertexPositionTexture(new Vector3(5,4,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,0,-12),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(1,0,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,4,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(1,0,-12),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(1,4,-12),Vector2.One),
               
                //Lateral 1
                new VertexPositionTexture(new Vector3(5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,0,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,0,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,2,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(5,2,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,0,0),Vector2.UnitX),

                new VertexPositionTexture(new Vector3(5,8,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,8,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,6,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,6,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(5,8,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,6,0),Vector2.UnitY),

                new VertexPositionTexture(new Vector3(5,6,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,6,-10),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,6,-10),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-10),Vector2.One),

                new VertexPositionTexture(new Vector3(5,6,-2),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,6,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-2),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,2,-2),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,6,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,0),Vector2.One),

                new VertexPositionTexture(new Vector3(5,6,-7),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-7),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,2,-7),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-5),Vector2.One),

                //Lateral 2
                new VertexPositionTexture(new Vector3(-5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,0,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,0,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,2,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,2,0),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,0,0),Vector2.UnitX),

                new VertexPositionTexture(new Vector3(-5,8,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,8,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,6,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,6,-12),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,8,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,6,0),Vector2.UnitY),

                new VertexPositionTexture(new Vector3(-5,6,-12),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,6,-10),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,2,-12),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,6,-10),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-10),Vector2.One),

                new VertexPositionTexture(new Vector3(-5,6,-2),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,6,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-2),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,2,-2),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,6,0),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,0),Vector2.One),

                new VertexPositionTexture(new Vector3(-5,6,-7),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-7),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,2,-7),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-5),Vector2.One),
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.effect = new BasicEffect(this.device);
            this.texture = this.game.Content.Load<Texture2D>(@"Textures\WoodWall");
        }

        public virtual void Draw(Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.TextureEnabled = true;
            this.effect.Texture = texture;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}

