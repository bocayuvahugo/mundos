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

namespace HugoMundo8
{
    class Sea
    {
        Game game;
        GraphicsDevice device;
        Matrix world;
        int row, column;
        VertexPositionTexture[] verts;
        VertexBuffer vBuffer;
        int[] indexes;
        IndexBuffer iBuffer;
        Effect effect;
        Texture2D texture;
        float time;
        float speed = 2;

        public Sea(GraphicsDevice device, Game game)
        {
            this.game = game;
            this.device = device;
            this.world = Matrix.Identity;
            /*this.world = Matrix.CreateRotationX(1.58f);
            this.world *= Matrix.CreateScale(20);
            this.world *= Matrix.CreateTranslation(0, -20, 40);*/

            this.row = 200;
            this.column = 150;

            this.verts = new VertexPositionTexture[row * column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int aux = i * column + j;

                    float v = i / (float)(row - 1);
                    float u = j / (float)(column - 1);

                    this.verts[aux] = new VertexPositionTexture(new Vector3(j - column / 2f, -0.5f, i - row / 2f), new Vector2(u,v));
                    //this.verts[aux] = new VertexPositionTexture(new Vector3((j - column / 2f), (-i + row / 2f) / 10f, 0), new Vector2(u, v));

                }
            }

            this.vBuffer = new VertexBuffer(this.game.GraphicsDevice, typeof(VertexPositionColorTexture), this.verts.Length, BufferUsage.None);
            this.vBuffer.SetData<VertexPositionTexture>(this.verts);

            this.indexes = new int[(row - 1) * (column - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    this.indexes[k++] = (short)(i * column + j);
                    this.indexes[k++] = (short)(i * column + (j + 1));
                    this.indexes[k++] = (short)((i + 1) * column + j);

                    this.indexes[k++] = (short)(i * column + j + 1);
                    this.indexes[k++] = (short)((i + 1) * column + (j + 1));
                    this.indexes[k++] = (short)((i + 1) * column + j);
                }
            }

            this.iBuffer = new IndexBuffer(this.game.GraphicsDevice, IndexElementSize.ThirtyTwoBits, this.indexes.Length, BufferUsage.None);
            this.iBuffer.SetData<int>(this.indexes);

            this.effect = this.game.Content.Load<Effect>(@"Effects\MotionEffect");

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Water");
        }

        public void Update(GameTime gameTime)
        {
            this.time += gameTime.ElapsedGameTime.Milliseconds / 2000f * this.speed;
        }

        public virtual void Draw(Camera camera)
        {
            this.device.SetVertexBuffer(this.vBuffer);

            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(this.texture);
            this.effect.Parameters["time"].SetValue(this.time);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                this.verts, 0, this.verts.Length, this.indexes, 0, this.indexes.Length / 3);
            }
        }
    }
}
