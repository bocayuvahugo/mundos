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

namespace HugoMundo1
{
    public class Triangle
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;

        public Triangle(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;
        
            this.verts = new VertexPositionColor[]
            {

                // Chao
                new VertexPositionColor(new Vector3(-16,-16,20),Color.GreenYellow),
                new VertexPositionColor(new Vector3(-16,-16,-8),Color.GreenYellow),
                new VertexPositionColor(new Vector3(16,-16,-8),Color.GreenYellow),
                new VertexPositionColor(new Vector3(-16,-16,20),Color.GreenYellow),
                new VertexPositionColor(new Vector3(16,-16,-8),Color.GreenYellow),
                new VertexPositionColor(new Vector3(16,-16,20),Color.GreenYellow),

                //Frente
                new VertexPositionColor(new Vector3(-5,-8,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-8,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-12,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,-12,0),Color.Silver),
                new VertexPositionColor(new Vector3(1,-16,0),Color.Silver),

                //Porta Frente
                new VertexPositionColor(new Vector3(-1,-12,0),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,-16,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-16,0),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,-12,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-16,0),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-12,0),Color.Wheat),
                
                //Costas
                new VertexPositionColor(new Vector3(-5,-8,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-8,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-8,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,12),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(-1,-16,12),Color.Silver),

                new VertexPositionColor(new Vector3(5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(1,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-12,12),Color.Silver),
                new VertexPositionColor(new Vector3(1,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(1,-12,12),Color.Silver),

                //Porta Costas
                new VertexPositionColor(new Vector3(-1,-12,12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-16,12),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,-16,12),Color.Wheat),
                new VertexPositionColor(new Vector3(-1,-12,12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-12,12),Color.Wheat),
                new VertexPositionColor(new Vector3(1,-16,12),Color.Wheat),

                //Lateral 1
                new VertexPositionColor(new Vector3(5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-16,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,-8,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-8,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,10),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,10),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,10),Color.Silver),

                new VertexPositionColor(new Vector3(5,-11,2),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,2),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,2),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,0),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,0),Color.Silver),

                new VertexPositionColor(new Vector3(5,-11,7),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,5),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,7),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,7),Color.Silver),
                new VertexPositionColor(new Vector3(5,-11,5),Color.Silver),
                new VertexPositionColor(new Vector3(5,-14,5),Color.Silver),

                //Janela de duas portas, lateral 1
                new VertexPositionColor(new Vector3(5,-11,5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,-11,3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(5,-14,5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,-14,5),Color.Indigo),
                new VertexPositionColor(new Vector3(5,-11,3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(5,-14,3.5f),Color.Indigo),

                new VertexPositionColor(new Vector3(5,-11,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-11,3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-11,3.5f),Color.MediumPurple),                

                //Janela de correr, lateral 1
                new VertexPositionColor(new Vector3(5,-11,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-11,7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-11,7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(5,-14,7),Color.MediumPurple),

                //Lateral 2
                new VertexPositionColor(new Vector3(-5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-16,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-16,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-8,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-8,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-8,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-11,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,10),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,12),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,10),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,10),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-11,2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,2),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,0),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,0),Color.Silver),

                new VertexPositionColor(new Vector3(-5,-11,7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,5),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,7),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-14,5),Color.Silver),
                new VertexPositionColor(new Vector3(-5,-11,5),Color.Silver),

                //Janela de duas portas, lateral 2
                new VertexPositionColor(new Vector3(-5,-11,5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,-14,5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,-11,3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,-14,5),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,-14,3.5f),Color.Indigo),
                new VertexPositionColor(new Vector3(-5,-11,3.5f),Color.Indigo),

                new VertexPositionColor(new Vector3(-5,-11,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-11,3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,2),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-11,3.5f),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,3.5f),Color.MediumPurple),

                //Janela de correr, lateral 2
                new VertexPositionColor(new Vector3(-5,-11,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-11,7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,10),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-14,7),Color.MediumPurple),
                new VertexPositionColor(new Vector3(-5,-11,7),Color.MediumPurple),


                //Laje
                new VertexPositionColor(new Vector3(-7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,-1),Color.Brown),

                new VertexPositionColor(new Vector3(7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,-1),Color.Brown),

                new VertexPositionColor(new Vector3(-7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,13),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,13),Color.Brown),

                new VertexPositionColor(new Vector3(-7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-7,-1),Color.Brown),
                new VertexPositionColor(new Vector3(-7,-8,-1),Color.Brown),
                new VertexPositionColor(new Vector3(7,-8,-1),Color.Brown),

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
                                                                    this.verts, 0, 62);
            }
        }
    }
}
