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

namespace HugoMundo8
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
        Terrain terrain;
        Mill mill1;
        Mill mill2;
        TreeManager treeManager;
        Sea sea;
        int temp;
        bool morph;

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

            temp = 0;
            morph = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.camera = new Camera();
            this.terrain = new Terrain(GraphicsDevice, this);
            this.doors = new Doors(GraphicsDevice, this);
            this.windowA = new WindowA(GraphicsDevice, this);
            this.windowB = new WindowB(GraphicsDevice, this);
            this.walls = new Walls(GraphicsDevice, this);
            this.rooftop = new Rooftop(GraphicsDevice, this);
            this.mill1 = new Mill(GraphicsDevice, new Vector3(15, 0, -20), -45, this);
            this.mill2 = new Mill(GraphicsDevice, new Vector3(-15, 0, -20), 45, this);
            this.sea = new Sea(GraphicsDevice, this);
            this.treeManager = new TreeManager(GraphicsDevice, this, camera, new Vector3(15, 0, -35), 4, 4);

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
            this.treeManager.Update(gameTime, camera);
            this.sea.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {                      

            this.doors.Draw(this.camera);
            this.windowA.Draw(this.camera, GraphicsDevice);
            this.windowB.Draw(this.camera);
            this.rooftop.Draw(this.camera);
            this.walls.Draw(this.camera);
            this.terrain.Draw(this.camera);
            this.mill1.Draw(this.camera);
            this.mill2.Draw(this.camera);
            this.sea.Draw(this.camera);
            this.treeManager.Draw(this.camera);
            base.Draw(gameTime);
        }
    }
}
