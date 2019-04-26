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

namespace HugoMundo3
{
    class Floor
    {
        protected GraphicsDevice device;
        protected Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Texture2D texture;
        Game game;

        public Floor(GraphicsDevice device, Game game)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;
            
            this.verts = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-40,0,40),Vector2.UnitY),
                new VertexPositionTexture(new Vector3(-40,0,-40),Vector2.Zero),
                new VertexPositionTexture(new Vector3(40,0,-40),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(40,0,-40),Vector2.UnitX),
                new VertexPositionTexture(new Vector3(40,0,40),Vector2.One),
                new VertexPositionTexture(new Vector3(-40,0,40),Vector2.UnitY),
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.effect = new BasicEffect(this.device);
            this.texture = this.game.Content.Load<Texture2D>(@"Textures\Grass");
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

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
