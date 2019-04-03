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
    public class House
    {
        protected GraphicsDevice device;
        protected Matrix world;

        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;

        public House(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;

            this.verts = new VertexPositionColor[]
            {
                              
                //Frente
                new VertexPositionColor(new Vector3(-5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,0,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,4,0),Color.Silver),

                //Porta Frente
                new VertexPositionColor(new Vector3(-1,4,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,0,0),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,0,0),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,4,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,4,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,0,0),Color.Wheat),

                //Costas
                new VertexPositionColor(new Vector3(-5,8,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,8,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,8,-12),Color.Silver),

                new VertexPositionColor(new Vector3(-5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,4,-12),Color.Silver),

                new VertexPositionColor(new Vector3(5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(1,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(1,4,-12),Color.Silver),
                new VertexPositionColor(new Vector3(1,0,-12),Color.Silver),

                //Porta Costas
                new VertexPositionColor(new Vector3(-1,4,-12),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,0,-12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,0,-12),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,0,-12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,0,-12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,4,-12),Color.Wheat),

                //Lateral 1
                new VertexPositionColor(new Vector3(5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,0,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,8,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-10),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-10),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-10),Color.Silver),

                new VertexPositionColor(new Vector3(5,6,-2),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-2),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-2),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,6,-7),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-5),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-7),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-7),Color.Silver),
                new VertexPositionColor(new Vector3(5,6,-5),Color.Silver),
                new VertexPositionColor(new Vector3(5,2,-5),Color.Silver),

                //Janela de duas portas, lateral 1
                new VertexPositionColor(new Vector3(5,6,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,6,-3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(5,2,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,2,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,6,-3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(5,2,-3.5f),Color.Indigo),

                new VertexPositionColor(new Vector3(5,6,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,6,-3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,6,-3.5f),Color.MediumPurple),                

                //Janela de correr, lateral 1
                new VertexPositionColor(new Vector3(5,6,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,6,-7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,6,-7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,2,-7),Color.MediumPurple),

                //Lateral 2
                new VertexPositionColor(new Vector3(-5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,0,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,0,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,0,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,8,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,8,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,6,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-10),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-10),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-10),Color.Silver),

                new VertexPositionColor(new Vector3(-5,6,-2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,6,-7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-5),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,6,-5),Color.Silver),
                new VertexPositionColor(new Vector3(-5,2,-5),Color.Silver),

                //Janela de duas portas, lateral 2
                new VertexPositionColor(new Vector3(-5,6,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,2,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,6,-3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,2,-5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,2,-3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,6,-3.5f),Color.Indigo),

                new VertexPositionColor(new Vector3(-5,6,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,6,-3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,6,-3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-3.5f),Color.MediumPurple),

                //Janela de correr, lateral 2
                new VertexPositionColor(new Vector3(-5,6,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,6,-7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,2,-7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,6,-7),Color.MediumPurple),


                //Laje
                new VertexPositionColor(new Vector3(-7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,-13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,1),Color.Brown),

                new VertexPositionColor(new Vector3(7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,1),Color.Brown),

                new VertexPositionColor(new Vector3(-7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,-13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,-13),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,-13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,9,1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,8,1),Color.Brown),
                new VertexPositionColor(new Vector3(7,8,1),Color.Brown),

            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionColor),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.effect = new BasicEffect(this.device);
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

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}

