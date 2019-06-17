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
    class Ship
    {
        #region variables
        GraphicsDevice device;

        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;

        short[] index;
        IndexBuffer indexBuffer;
        BasicEffect effect;

        protected Matrix world;
        protected Vector3 position;

        protected float angle;

        BoundingBox boundingBox;

        float speed;
        Vector3 oldPosition;

        #endregion

        public Ship(GraphicsDevice device, Vector3 position)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.position = position;
            this.angle = 0;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Brown), // 0
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Brown), // 1
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.Brown), // 2
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Brown), // 3
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Brown), // 4
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Brown), // 5
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Brown), // 6
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Brown), // 7
            };

            this.vertexBuffer = new VertexBuffer(this.device,
                                                 typeof(VertexPositionColor),
                                                 this.verts.Length,
                                                 BufferUsage.None);
            this.vertexBuffer.SetData<VertexPositionColor>(this.verts);

            this.index = new short[]
            {
                0, 1, 2, // front
                0, 2, 3,
                1, 5, 6, // rigth
                1, 6, 2,
                5, 4, 7, // back
                5, 7, 6,
                4, 0, 3, // left
                4, 3, 7,
                4, 5, 1, // up
                4, 1, 0,
                3, 2, 6, // down
                3, 6, 7,
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

            this.speed = 30;

            this.oldPosition = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Input(gameTime);
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

        private void Input(GameTime gameTime)
        {
            this.oldPosition = this.position;
            bool update = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.position += Vector3.Left * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.position += Vector3.Right * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.position += Vector3.Forward * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.position += Vector3.Backward * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (update)
            {
                this.UpdateBoundingBox();
            }
        }

        public void RestorePosition(GameTime gameTime)
        {
            this.position = this.oldPosition;

        }

    }
}