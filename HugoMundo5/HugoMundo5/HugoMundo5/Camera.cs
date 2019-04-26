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

namespace HugoMundo5
{
    public class Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        private Vector3 rotation;

        private float translationSpeed = 40;
        private float rotationSpeed = 40;

        public Camera()
        {
            this.position = new Vector3 (0, 5, 20);
            this.target = Vector3.Zero;
            this.rotation = new Vector3(-15, 0, 0);
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            this.view = Matrix.CreateLookAt(position, target, up);
        }

        public void SetupProjection()
        {
            Screen screen = Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.GetWidth() / (float)screen.GetHeight(),
                                                                  0.1f,
                                                                  1000);
        }

        public void Update(GameTime gameTime)
        {

            this.SetupView(this.position, this.target, this.up);
            this.SetupProjection();

            this.CameraRotation(gameTime);
            this.CameraTranslation(gameTime);

            this.view = Matrix.Identity;
            this.view *= Matrix.CreateRotationX(MathHelper.ToRadians(rotation.X));
            this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(rotation.Y));

            this.view *= Matrix.CreateTranslation(this.position);
            this.view = Matrix.Invert(this.view);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }

        private void CameraRotation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.rotation.Y += this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.rotation.Y -= this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.rotation.X += this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.rotation.X -= this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
        }

        private void CameraTranslation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                this.position.Y += (float)Math.Sin(MathHelper.ToRadians(90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.position.Y -= (float)Math.Sin(MathHelper.ToRadians(90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.position.X -= (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z -= (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
        }
    }
}
