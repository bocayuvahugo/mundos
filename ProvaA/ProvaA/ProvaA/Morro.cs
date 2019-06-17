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
    class Morro
    {
        protected GraphicsDevice device;
        protected Matrix world;

        VertexPositionTexture[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        Effect effect;
        short row, column;
        Texture2D heightMapTexture, texture;
        Game game;

        public Morro(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;

            this.row = 50;
            this.column = 50;         

            this.indexes = new short[(row - 1) * (column - 1) * 2 * 3];

            short k = 0;
            for (short i = 0; i < row - 1; i++)
            {
                for (short j = 0; j < column - 1; j++)
                {
                    this.indexes[k++] = (short) (i * column + j);
                    this.indexes[k++] = (short) (i * column + (j + 1));
                    this.indexes[k++] = (short) ((i + 1) * column + j);

                    this.indexes[k++] = (short) (i * column + j + 1);
                    this.indexes[k++] = (short) ((i + 1) * column + (j + 1));
                    this.indexes[k++] = (short) ((i + 1) * column + j);
                }
            }

            this.iBuffer = new IndexBuffer(this.device, IndexElementSize.SixteenBits, this.indexes.Length, BufferUsage.None);
            this.iBuffer.SetData<short>(this.indexes);
           
            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");

            this.heightMapTexture = this.game.Content.Load<Texture2D>(@"Textures\heightMap");

            Color[] colors = new Color[this.heightMapTexture.Width * this.heightMapTexture.Height];
            heightMapTexture.GetData<Color>(colors);

            this.verts = new VertexPositionTexture[row * column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int aux = i * column + j;

                    float _i = i / (float)(row - 1);
                    float _j = j / (float)(column - 1);

                    int _iTex = (int)(_i * (heightMapTexture.Height - 1));
                    int _jTex = (int)(_j * (heightMapTexture.Width - 1));

                    int _auxTex = _iTex * heightMapTexture.Width + _jTex;

                    this.verts[aux] = new VertexPositionTexture(new Vector3(j - (column - 1) / 2f, colors[_auxTex].B / 10f, i - row / 2f), new Vector2(0,1));
                }
            }

            this.vBuffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.vBuffer.SetData<VertexPositionTexture>(this.verts);

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Grass");

        }
        public virtual void Draw(Camera camera)
        {
            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            //this.effect.Parameters["colorTexture"].SetValue(this.texture);
            

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList,
                                                            this.verts,
                                                            0,
                                                            this.verts.Length,
                                                            this.indexes,
                                                            0,
                                                            this.indexes.Length / 3);
            }
        }
    }
}
