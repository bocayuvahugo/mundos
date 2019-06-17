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

namespace ProvaA
{
    class Letra
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;   


        public Letra(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;

            this.verts = new VertexPositionColor[]
            {
                //H
                new VertexPositionColor(new Vector3(-6,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-5,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-6,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-6,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-5,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-5,0,20),Color.Red),

                new VertexPositionColor(new Vector3(-5,3,20),Color.Red),
                new VertexPositionColor(new Vector3(-4,3,20),Color.Red),
                new VertexPositionColor(new Vector3(-5,2,20),Color.Red),
                new VertexPositionColor(new Vector3(-5,2,20),Color.Red),
                new VertexPositionColor(new Vector3(-4,3,20),Color.Red),
                new VertexPositionColor(new Vector3(-4,2,20),Color.Red),

                new VertexPositionColor(new Vector3(-4,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-3,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-4,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-4,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-3,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-3,0,20),Color.Red),

                //U
                new VertexPositionColor(new Vector3(-2,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-1,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-2,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-2,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-1,5,20),Color.Red),
                new VertexPositionColor(new Vector3(-1,0,20),Color.Red),

                new VertexPositionColor(new Vector3(-1,2,20),Color.Red),
                new VertexPositionColor(new Vector3(1,2,20),Color.Red),
                new VertexPositionColor(new Vector3(-1,0,20),Color.Red),
                new VertexPositionColor(new Vector3(-1,0,20),Color.Red),
                new VertexPositionColor(new Vector3(1,2,20),Color.Red),
                new VertexPositionColor(new Vector3(1,0,20),Color.Red),

                new VertexPositionColor(new Vector3(1,5,20),Color.Red),
                new VertexPositionColor(new Vector3(2,5,20),Color.Red),
                new VertexPositionColor(new Vector3(1,0,20),Color.Red),
                new VertexPositionColor(new Vector3(1,0,20),Color.Red),
                new VertexPositionColor(new Vector3(2,5,20),Color.Red),
                new VertexPositionColor(new Vector3(2,0,20),Color.Red),

                //G

                new VertexPositionColor(new Vector3(3,5,20),Color.Red),
                new VertexPositionColor(new Vector3(4,5,20),Color.Red),
                new VertexPositionColor(new Vector3(3,0,20),Color.Red),
                new VertexPositionColor(new Vector3(3,0,20),Color.Red),
                new VertexPositionColor(new Vector3(4,5,20),Color.Red),
                new VertexPositionColor(new Vector3(4,0,20),Color.Red),

                new VertexPositionColor(new Vector3(4,5,20),Color.Red),
                new VertexPositionColor(new Vector3(6,5,20),Color.Red),
                new VertexPositionColor(new Vector3(4,4,20),Color.Red),
                new VertexPositionColor(new Vector3(4,4,20),Color.Red),
                new VertexPositionColor(new Vector3(6,5,20),Color.Red),
                new VertexPositionColor(new Vector3(6,4,20),Color.Red),

                new VertexPositionColor(new Vector3(4,2,20),Color.Red),
                new VertexPositionColor(new Vector3(6,2,20),Color.Red),
                new VertexPositionColor(new Vector3(4,0,20),Color.Red),
                new VertexPositionColor(new Vector3(4,0,20),Color.Red),
                new VertexPositionColor(new Vector3(6,2,20),Color.Red),
                new VertexPositionColor(new Vector3(6,0,20),Color.Red),

                new VertexPositionColor(new Vector3(6,3,20),Color.Red),
                new VertexPositionColor(new Vector3(7,3,20),Color.Red),
                new VertexPositionColor(new Vector3(6,0,20),Color.Red),
                new VertexPositionColor(new Vector3(6,0,20),Color.Red),
                new VertexPositionColor(new Vector3(7,3,20),Color.Red),
                new VertexPositionColor(new Vector3(7,0,20),Color.Red),

                
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionColor),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.effect = new BasicEffect(this.device);

        }
        public virtual void Draw(Camera camera)
        {
           
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;


            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}