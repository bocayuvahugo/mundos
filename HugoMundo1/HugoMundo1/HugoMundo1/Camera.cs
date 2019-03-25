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
    public class Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        public Camera()
        {
            this.position = Vector3.Right * 60;
            this.target = Vector3.Zero;
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            //this.view = Matrix.CreateLookAt(position, target, up);
            this.view = Matrix.CreateLookAt(new Vector3(-30, 0, 40), new Vector3(2, -8, 0), Vector3.Up);
        }

        public void SetupProjection()
        {
            Screen screen = Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.GetWidth() / (float)screen.GetHeight(),
                                                                  0.0000001f,
                                                                  1000);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }
    }
}
