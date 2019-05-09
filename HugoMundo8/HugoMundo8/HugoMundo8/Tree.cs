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
    public class Tree
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        Effect effect;
        IndexBuffer iBuffer;
        short[] indexes;
        Texture2D texture, textureSnow;
        Game game;
        float temp, count;
        public float disCamera;
        bool morph;
        Vector3 position;


        public Tree(GraphicsDevice device, Game game, Vector3 position)
        {
            this.device = device;
            this.position = position;
            this.world = Matrix.Identity;
            this.world = Matrix.CreateTranslation(position);
            this.game = game;

            this.verts = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-5,8,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,8,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,-8,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,-8,0), Vector2.One),
            };
            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.indexes = new short[]
            {
                0,1,2,
                1,3,2,
            };
            this.iBuffer = new IndexBuffer(this.device, IndexElementSize.SixteenBits, this.indexes.Length, BufferUsage.None);
            this.iBuffer.SetData<short>(this.indexes);

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Tree");
            this.textureSnow = this.game.Content.Load<Texture2D>(@"Textures\TreeSnow");

            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");
                        
            temp = 0;
            count = temp;
            morph = false;
        }
        public void Update(GameTime gameTime, Camera camera)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateConstrainedBillboard(this.position, camera.position, Vector3.Up, new Nullable<Vector3>(), new Nullable<Vector3>());

            disCamera = Vector3.Distance(this.position, camera.position);

        }

        public virtual void Draw(Camera camera)
        {
            count = temp;

            if (count > 0.8f)
            {
                count = 0.8f;
            }
            else if (count < 0.2f)
            {
                count = 0.2f;
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

            this.device.SetVertexBuffer(this.buffer);
            this.device.BlendState = BlendState.AlphaBlend;
            this.device.Indices = this.iBuffer;

            this.effect.CurrentTechnique = effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(texture);
            this.effect.Parameters["colorTextureSnow"].SetValue(textureSnow);
            this.effect.Parameters["multi"].SetValue(this.temp);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length, this.indexes, 0, 2);
            }
        }
    }
}