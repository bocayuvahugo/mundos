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

namespace HugoMundo2
{
    class Floor
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;

        public Floor(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;

            this.verts = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-40,0,40),Color.GreenYellow),
                new VertexPositionColor(new Vector3(-40,0,-40),Color.GreenYellow),
                new VertexPositionColor(new Vector3(40,0,-40),Color.GreenYellow),
                new VertexPositionColor(new Vector3(-40,0,40),Color.GreenYellow),
                new VertexPositionColor(new Vector3(40,0,-40),Color.GreenYellow),
                new VertexPositionColor(new Vector3(40,0,40),Color.GreenYellow),
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
                                                                    this.verts, 0, 2);
            }
        }
    }
}
