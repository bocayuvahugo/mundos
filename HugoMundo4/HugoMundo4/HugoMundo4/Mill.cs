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

namespace HugoMundo4
{
    class Mill
    {
        protected GraphicsDevice device;

        protected Matrix world;
        protected Matrix world2;

        private float angle;

        VertexPositionTexture[] verts, vertsHelix;
        VertexBuffer buffer, buffer2;
        BasicEffect effect, effect2;
        Texture2D texture, texture2;
        Game game;
        Vector3 position;
        float rotate;

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

            this.effect = new BasicEffect(this.device);
            this.effect2 = new BasicEffect(this.device);
            this.texture = this.game.Content.Load<Texture2D>(@"Textures\BrickWall");
            this.texture2 = this.game.Content.Load<Texture2D>(@"Textures\Helix");

        }

        public virtual void Update(GameTime gameTime)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationY(rotate);
            this.world *= Matrix.CreateTranslation(position);


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

        public virtual void Draw(Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.TextureEnabled = true;
            this.effect.Texture = texture;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }

            this.device.SetVertexBuffer(this.buffer2);

            this.effect2.World = this.world2;
            this.effect2.View = camera.GetView();
            this.effect2.Projection = camera.GetProjection();
            this.effect2.TextureEnabled = true;
            this.effect2.Texture = texture2;

            foreach (EffectPass pass in this.effect2.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.vertsHelix, 0, this.vertsHelix.Length / 3);
            }
        }
    }
}