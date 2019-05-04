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
    class Mill
    {
        protected GraphicsDevice device;

        protected Matrix world;
        protected Matrix world2;

        private float angle;

        VertexPositionTexture[] verts, vertsHelix;
        VertexBuffer buffer, buffer2;
        BasicEffect basicEffect, basicEffect2;
        Effect effect, effect2;
        Texture2D texture, texture2, textureSnow, textureSnow2;
        Game game;
        Vector3 position;
        float rotate, temp, count;
        bool morph;

        public Mill(GraphicsDevice device, Vector3 position, float rotate, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.world2 = Matrix.Identity;
            this.game = game;

            this.position = position;
            this.rotate = rotate;

            this.verts = new VertexPositionTexture[]
            {

                //Frente
                new VertexPositionTexture(new Vector3(-2,0,0), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,16,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,0,0), Vector2.One),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,0,0), Vector2.UnitY),

                //Lateral 1
                new VertexPositionTexture(new Vector3(-2,0,-8), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,16,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,0,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-2,0,-8), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-2,16,0), Vector2.Zero),

                //Lateral 2
                new VertexPositionTexture(new Vector3(2,0,-8), Vector2.One),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,0,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(2,0,-8), Vector2.One),
                new VertexPositionTexture(new Vector3(2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.Zero),

                //Topo
                new VertexPositionTexture(new Vector3(-2,16,0), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(2,16,-2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,16,0), Vector2.UnitY),

                //Costas
                new VertexPositionTexture(new Vector3(2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-2,16,-2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,0,-8), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(2,16,-2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-2,0,-8), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(2,0,-8), Vector2.One),

                //Lateral 1, eixo
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-0.25f,15,0), Vector2.One),
                new VertexPositionTexture(new Vector3(-0.25f,15,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-0.25f,15,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,2), Vector2.Zero),

                //Lateral 2, eixo
                new VertexPositionTexture(new Vector3(0.25f,14.5f,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0.25f,15,0), Vector2.One),
                new VertexPositionTexture(new Vector3(0.25f,15,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(0.25f,14.5f,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0.25f,15,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(0.25f,14.5f,2), Vector2.Zero),

                //Topo, eixo
                new VertexPositionTexture(new Vector3(-0.25f,15,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-0.25f,15,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0.25f,15,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-0.25f,15,2), Vector2.One),
                new VertexPositionTexture(new Vector3(0.25f,15,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0.25f,15,2), Vector2.UnitY),

                //Inferior, eixo
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0.25f,14.5f,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-0.25f,14.5f,2), Vector2.One),
                new VertexPositionTexture(new Vector3(0.25f,14.5f,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0.25f,14.5f,2), Vector2.UnitY),
            };

            this.vertsHelix = new VertexPositionTexture[]
            {

		        //Hélice 1
                new VertexPositionTexture(new Vector3(-2,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(0,-0.5f,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,-0.5f,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-2,-0.5f,2), Vector2.UnitX),              

                new VertexPositionTexture(new Vector3(-8,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-2,-2,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-8,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,-2,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-8,-2,2), Vector2.UnitX),

                //Hélice 2
                new VertexPositionTexture(new Vector3(0,2,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-0.5f,0,2), Vector2.One),
                new VertexPositionTexture(new Vector3(-0.5f,2,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0,2,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-0.5f,0,2), Vector2.One),
                
                new VertexPositionTexture(new Vector3(-2,8,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0,8,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(-2,2,2), Vector2.One),
                new VertexPositionTexture(new Vector3(0,8,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,2,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-2,2,2), Vector2.One),

                //Hélice 3
                new VertexPositionTexture(new Vector3(2,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(0,0.5f,2), Vector2.One),
                new VertexPositionTexture(new Vector3(2,0.5f,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(2,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,0.5f,2), Vector2.One),
                
                new VertexPositionTexture(new Vector3(8,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(2,2,2), Vector2.One),
                new VertexPositionTexture(new Vector3(8,2,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(8,0,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,2,2), Vector2.One),

                //Hélice 4
                new VertexPositionTexture(new Vector3(0,-2,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,0,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(0.5f,0,2), Vector2.One),
                new VertexPositionTexture(new Vector3(0.5f,-2,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0,-2,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0.5f,0,2), Vector2.One),
                

                new VertexPositionTexture(new Vector3(0,-8,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(0,-2,2), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(2,-2,2), Vector2.One),
                new VertexPositionTexture(new Vector3(2,-8,2), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(0,-8,2), Vector2.Zero),
                new VertexPositionTexture(new Vector3(2,-2,2), Vector2.One),
            };

            this.buffer = new VertexBuffer(this.device,
                                               typeof(VertexPositionTexture),
                                               this.verts.Length,
                                               BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.buffer2 = new VertexBuffer(this.device,
                                                       typeof(VertexPositionTexture),
                                                       this.vertsHelix.Length,
                                                       BufferUsage.None);
            this.buffer2.SetData<VertexPositionTexture>(this.vertsHelix);

            this.basicEffect = new BasicEffect(this.device);
            this.basicEffect2 = new BasicEffect(this.device);
            this.effect = this.game.Content.Load<Effect>(@"Effects\Effect1");
            this.effect2 = this.game.Content.Load<Effect>(@"Effects\Effect1");

            this.texture = this.game.Content.Load<Texture2D>(@"Textures\BrickWall");
            this.textureSnow = this.game.Content.Load<Texture2D>(@"Textures\BrickWallSnow");

            this.texture2 = this.game.Content.Load<Texture2D>(@"Textures\Helix");
            this.textureSnow2 = this.game.Content.Load<Texture2D>(@"Textures\HelixSnow");

            temp = 0;
            morph = false;

        }

        public virtual void Update(GameTime gameTime)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationY(rotate);
            this.world *= Matrix.CreateTranslation(position);

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
                Random r = new Random();
                float randomValue = r.Next(1, 4);
                angle += 4f + randomValue;
                float rValue = MathHelper.ToRadians(angle);
                this.world2 = Matrix.Identity;
                this.world2 *= Matrix.CreateRotationZ(rValue);
                this.world2 *= Matrix.CreateRotationY(rotate);
                this.world2 *= Matrix.CreateTranslation(new Vector3(0f, 14.75f, 0));
                this.world2 *= Matrix.CreateTranslation(position);
            }
            else
            {
                Random r = new Random();
                float randomValue = r.Next(6, 8);
                angle += 4f + randomValue;
                float rValue = MathHelper.ToRadians(angle);
                this.world2 = Matrix.Identity;
                this.world2 *= Matrix.CreateRotationZ(rValue);
                this.world2 *= Matrix.CreateRotationY(rotate);
                this.world2 *= Matrix.CreateTranslation(new Vector3(0f, 14.75f, 0));
                this.world2 *= Matrix.CreateTranslation(position);
            }

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

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }

            this.device.SetVertexBuffer(this.buffer2);

            this.effect2.CurrentTechnique = this.effect2.Techniques["Technique1"];
            this.effect2.Parameters["World"].SetValue(this.world2);
            this.effect2.Parameters["View"].SetValue(camera.GetView());
            this.effect2.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect2.Parameters["colorTexture"].SetValue(this.texture2);
            this.effect2.Parameters["colorTextureSnow"].SetValue(this.textureSnow2);
            this.effect2.Parameters["multi"].SetValue(this.temp);

            foreach (EffectPass pass in this.effect2.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.vertsHelix, 0, this.vertsHelix.Length / 3);
            }
        }
    }
}