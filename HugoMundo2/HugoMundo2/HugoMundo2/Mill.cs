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

namespace HugoMundo2
{
    class Mill
    {
        protected GraphicsDevice device;

        protected Matrix world;
        protected Matrix world2;

        private float angle;

        VertexPositionColor[] verts, vertsHelix;
        VertexBuffer buffer, buffer2;
        BasicEffect effect, effect2;

        Vector3 position;
        float rotate;

        public Mill(GraphicsDevice device, Vector3 position, float rotate)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.world2 = Matrix.Identity;

            this.position = position;
            this.rotate = rotate;

            this.verts = new VertexPositionColor[]
            {

                //Frente
                new VertexPositionColor(new Vector3(-2,0,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,0,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,0,0), Color.DarkRed),

                //Lateral 1
                new VertexPositionColor(new Vector3(-2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,0,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,0), Color.DarkRed),

                //Lateral 2
                new VertexPositionColor(new Vector3(2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,0,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),

                //Topo
                new VertexPositionColor(new Vector3(-2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,0), Color.DarkRed),

                //Costas
                new VertexPositionColor(new Vector3(-2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,-2), Color.DarkRed),
                new VertexPositionColor(new Vector3(-2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,0,-8), Color.DarkRed),
                new VertexPositionColor(new Vector3(2,16,-2), Color.DarkRed),


                //Frente, eixo
                new VertexPositionColor(new Vector3(-0.25f,14.5f,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,14.5f,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,2), Color.Sienna),

                //Lateral 1, eixo
                new VertexPositionColor(new Vector3(-0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,0), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,14.5f,2), Color.Sienna),

                //Lateral 2, eixo
                new VertexPositionColor(new Vector3(0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,2), Color.Sienna),

                //Topo, eixo
                new VertexPositionColor(new Vector3(-0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,0), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,15,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,15,2), Color.Sienna),

                //Inferior, eixo
                new VertexPositionColor(new Vector3(-0.25f,14.5f,2), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(-0.25f,14.5f,2), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,0), Color.Sienna),
                new VertexPositionColor(new Vector3(0.25f,14.5f,2), Color.Sienna),
            };

            this.vertsHelix = new VertexPositionColor[]
            {

		        //Hélice 1
                new VertexPositionColor(new Vector3(0,0,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-4,2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-2,4,2), Color.Cornsilk),

                new VertexPositionColor(new Vector3(-4,2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-5,8,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-2,4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-4,2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-8,5,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-5,8,2), Color.Cornsilk),


                //Hélice 2
                new VertexPositionColor(new Vector3(0,0,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(2,4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(4,2,2), Color.Cornsilk),

                new VertexPositionColor(new Vector3(2,4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(5,8,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(4,2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(5,8,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(8,5,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(4,2,2), Color.Cornsilk),



                //Hélice 3
                new VertexPositionColor(new Vector3(0,0,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(4,-2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(2,-4,2), Color.Cornsilk),

                new VertexPositionColor(new Vector3(4,-2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(8,-5,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(2,-4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(5,-8,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(2,-4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(8,-5,2), Color.Cornsilk),

                //Hélice 4
                new VertexPositionColor(new Vector3(0,0,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-2,-4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-4,-2,2), Color.Cornsilk),

                new VertexPositionColor(new Vector3(-4,-2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-2,-4,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-5,-8,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-8,-5,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-4,-2,2), Color.Cornsilk),
                new VertexPositionColor(new Vector3(-5,-8,2), Color.Cornsilk),
            };

            this.buffer = new VertexBuffer(this.device,
                                               typeof(VertexPositionColor),
                                               this.verts.Length,
                                               BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.buffer2 = new VertexBuffer(this.device,
                                                       typeof(VertexPositionColor),
                                                       this.vertsHelix.Length,
                                                       BufferUsage.None);
            this.buffer2.SetData<VertexPositionColor>(this.vertsHelix);

            this.effect = new BasicEffect(this.device);
            this.effect2 = new BasicEffect(this.device);
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
            this.effect.VertexColorEnabled = true;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }

            this.device.SetVertexBuffer(this.buffer2);

            this.effect2.World = this.world2;
            this.effect2.View = camera.GetView();
            this.effect2.Projection = camera.GetProjection();
            this.effect2.VertexColorEnabled = true;

            foreach (EffectPass pass in this.effect2.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, this.vertsHelix, 0, this.vertsHelix.Length / 3);
            }
        }
    }
}