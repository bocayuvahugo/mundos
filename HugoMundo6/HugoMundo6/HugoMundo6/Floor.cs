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

namespace HugoMundo6
{
    class Floor
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        Effect effect;
        Texture2D texture, textureSnow;
        Game game;
        float temp, count;
        bool morph;

        public Floor(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;
            
            this.verts = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-50,0,20),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-50,0,-100),Vector2.Zero),
                new VertexPositionTexture(new Vector3(50,0,-100),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(50,0,-100),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(50,0,20),Vector2.One),
                new VertexPositionTexture(new Vector3(-50,0,20),Vector2.UnitY),
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

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

            this.device.SetVertexBuffer(this.buffer);

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

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
