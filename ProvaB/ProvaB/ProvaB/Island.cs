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

namespace ProvaB
{
    class Island
    {
        #region variables
        GraphicsDevice device;

        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;
        BasicEffect effect;
        short[] index;
        IndexBuffer indexBuffer;

        protected Matrix world;
        protected Vector3 position;

        protected float angle;

        BoundingBox boundingBox;        

        #endregion

        public Island(GraphicsDevice device, Vector3 position)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.position = position;
            this.angle = 0;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 10,-10, 10), Color.GreenYellow), // 2
                new VertexPositionColor(new Vector3(-10,-10, 10), Color.GreenYellow), // 3
                new VertexPositionColor(new Vector3( 10,-10,-10), Color.GreenYellow), // 6
                new VertexPositionColor(new Vector3(-10,-10,-10), Color.GreenYellow), // 7
            };

            this.vertexBuffer = new VertexBuffer(this.device,
                                                 typeof(VertexPositionColor),
                                                 this.verts.Length,
                                                 BufferUsage.None);
            this.vertexBuffer.SetData<VertexPositionColor>(this.verts);

            this.index = new short[]
            {
                0, 1, 2, // front
                1, 3, 2,
               
            };

            this.indexBuffer = new IndexBuffer(this.device,
                                               IndexElementSize.SixteenBits,
                                               this.index.Length,
                                               BufferUsage.None);
            this.indexBuffer.SetData<short>(this.index);

            this.effect = new BasicEffect(this.device);

            this.boundingBox = new BoundingBox();
            this.UpdateBoundingBox();

            Console.WriteLine(this.boundingBox.ToString());
        }

        public virtual void Update(GameTime gameTime)
        {

            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationX(this.angle);
            this.world *= Matrix.CreateRotationY(this.angle);
            this.world *= Matrix.CreateTranslation(this.position);
        }

        public virtual void Draw(Camera camera)
        {
            this.device.SetVertexBuffer(this.vertexBuffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                    this.verts, 0, this.verts.Length, this.index, 0, this.index.Length / 3);
            }
        }

        protected void UpdateBoundingBox()
        {
            this.boundingBox.Min = this.position - Vector3.One;
            this.boundingBox.Max = this.position + Vector3.One;
        }

        public BoundingBox GetBoundingBox()
        {
            return this.boundingBox;
        } 

    }
}
