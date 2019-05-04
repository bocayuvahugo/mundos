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
    public class WindowA
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect basicEffect;
        Effect effect;
        Texture2D texture, textureSnow;
        Game game;
        float temp, count;
        bool morph;

        public WindowA(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;

            this.verts = new VertexPositionTexture[]
            {
                //Janela de duas portas, lateral 1
                new VertexPositionTexture(new Vector3(5,6,-2),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,2,-2),Vector2.One),
                new VertexPositionTexture(new Vector3(5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,2,-2),Vector2.One),
                new VertexPositionTexture(new Vector3(5,2,-3.5f),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(5,6,-3.5f),Vector2.Zero),

                new VertexPositionTexture(new Vector3(5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,2,-5),Vector2.One),
                new VertexPositionTexture(new Vector3(5,2,-5),Vector2.One),
                new VertexPositionTexture(new Vector3(5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(5,2,-3.5f),Vector2.UnitY),
                                        
                //Janela de duas portas, lateral 2
                new VertexPositionTexture(new Vector3(-5,6,-2),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,2,-2),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,2,-2),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,2,-3.5f),Vector2.UnitY),

                new VertexPositionTexture(new Vector3(-5,6,-5),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-5,2,-5),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,6,-3.5f),Vector2.Zero),
                new VertexPositionTexture(new Vector3(-5,2,-5),Vector2.One),
                new VertexPositionTexture(new Vector3(-5,2,-3.5f),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-5,6,-3.5f),Vector2.Zero),                
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.basicEffect = new BasicEffect(this.device);
            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\WindowA");
            this.textureSnow = this.game.Content.Load<Texture2D>(@"Textures\WindowASnow");

            temp = 0;
            count = temp;
            morph = false;

        }

        public virtual void Draw(Camera camera, GraphicsDevice graphicDevice)
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

            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(this.texture);
            this.effect.Parameters["colorTextureSnow"].SetValue(this.textureSnow);
            this.effect.Parameters["multi"].SetValue(this.temp);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicDevice.SamplerStates[0] = SamplerState.LinearClamp;
                graphicDevice.SamplerStates[1] = SamplerState.LinearClamp;

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}

