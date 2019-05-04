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

namespace HugoMundo7
{
    class Terrain
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer vBuffer;
        int[] indexes;
        IndexBuffer iBuffer;
        Effect effect;
        int row, column;
        Texture2D heightMapTexture, texture, textureSnow;
        Game game;
        float temp, count;
        bool morph;

        public Terrain(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;

            this.row = 200;
            this.column = 160;

            this.heightMapTexture = this.game.Content.Load<Texture2D>(@"Textures\HeightMap");
            Color[] colors = new Color[this.heightMapTexture.Width * this.heightMapTexture.Height];
            heightMapTexture.GetData<Color>(colors);

            this.verts = new VertexPositionTexture[row * column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int aux = i * column + j;

                    float v = i / (float)(row - 1);
                    float u = j / (float)(column - 1);

                    int vTex = (int)(v * (heightMapTexture.Height - 1));
                    int uTex = (int)(u * (heightMapTexture.Width - 1));

                    int auxTex = vTex * heightMapTexture.Width + uTex;

                    this.verts[aux] = new VertexPositionTexture(new Vector3(j - column / 2f, colors[auxTex].B / 10f, i - row / 2f), new Vector2(u, v));
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

            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Grass");
            this.textureSnow = this.game.Content.Load<Texture2D>(@"Textures\Snow");

            temp = 0;
            count = temp;
            morph = false;
        }
        public virtual void Draw(Camera camera)
        {
            count = temp;

            if(count > 1)
            {
                count = 1;
            }
            else if (count < 0.1f)
            {
                count = 0.1f;
            }

            if (temp >= 2 && !morph)
            {
                morph = true;
            }

            if (temp <= -1 && morph)
            {
                morph = false;
            }

            if (morph)
            {
                temp -= 0.001f;
            }
            else
            {
                temp += 0.001f;
            }

            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(this.texture);
            this.effect.Parameters["colorTextureSnow"].SetValue(this.textureSnow);
            this.effect.Parameters["multi"].SetValue(this.count);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, 
                                                                this.verts, 0, this.verts.Length, this.indexes, 0, this.indexes.Length / 3);

            }
        }
    }
}
