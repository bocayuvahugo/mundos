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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;
        Rooftop rooftop;
        WindowA windowA;
        WindowB windowB;
        Walls walls;
        Doors doors;
        Floor floor;
        Mill mill1;
        Mill mill2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            this.screen = Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.camera = new Camera();
            this.floor = new Floor(GraphicsDevice, this);
            this.doors = new Doors(GraphicsDevice, this);
            this.windowA = new WindowA(GraphicsDevice, this);
            this.windowB = new WindowB(GraphicsDevice, this);
            this.walls = new Walls(GraphicsDevice, this);
            this.rooftop = new Rooftop(GraphicsDevice, this);
            this.mill1 = new Mill(GraphicsDevice, new Vector3(20, 0, -20), -45, this);
            this.mill2 = new Mill(GraphicsDevice, new Vector3(-20, 0, -20), 45, this);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            this.mill1.Update(gameTime);
            this.mill2.Update(gameTime);
            this.camera.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.doors.Draw(this.camera);
            this.windowA.Draw(this.camera, GraphicsDevice);
            this.windowB.Draw(this.camera);
            this.rooftop.Draw(this.camera);
            this.walls.Draw(this.camera);
            this.floor.Draw(this.camera);
            this.mill1.Draw(this.camera);
            this.mill2.Draw(this.camera);

            base.Draw(gameTime);
        }
    }
}
