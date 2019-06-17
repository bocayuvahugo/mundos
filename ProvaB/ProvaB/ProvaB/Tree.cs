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
    class Tree
    {
        #region variables
        GraphicsDevice device;

        Matrix world;
        Texture2D texture;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        short[] index;
        IndexBuffer iBuffer;
        Effect effect;
        Game game;

        #endregion

        public Tree(GraphicsDevice device, Vector3 position, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;


            this.verts = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-5,5,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,5,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,-5,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,-5,0), Vector2.One),
            };
            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.index = new short[]
            {
                0,1,2,
                1,3,2,
            };
            this.iBuffer = new IndexBuffer(this.device, IndexElementSize.SixteenBits, this.index.Length, BufferUsage.None);
            this.iBuffer.SetData<short>(this.index);

            this.effect = new BasicEffect(this.device);

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Tree");

            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");

        }
        public virtual void Draw(Camera camera, GraphicsDevice graphicDevice)
        {
            this.device.SetVertexBuffer(this.buffer);
            this.device.BlendState = BlendState.AlphaBlend;

            this.device.SetVertexBuffer(this.buffer);
            this.device.Indices = this.iBuffer;

            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["myTexture"].SetValue(this.texture);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicDevice.SamplerStates[0] = SamplerState.LinearClamp;
                this.device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                    this.verts, 0, this.verts.Length, this.index, 0, this.index.Length / 3);
            }
        }
        

    }
}
