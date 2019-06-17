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

namespace ProvaB
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Island> islandList = new List<Island>();
        Mill mill;
        Camera camera;
        Screen screen;
        BasicEffect effect;
        Ship ship;
        Tree tree;

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
            GraphicsDevice.RasterizerState = rs;
            this.screen = Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.effect = new BasicEffect(GraphicsDevice);

            this.camera = new Camera();
            this.tree = new Tree(GraphicsDevice, new Vector3(50, 0, 0), this);
            this.ship = new Ship(GraphicsDevice, new Vector3(25,0,60));

            this.islandList.Add(new Island(GraphicsDevice, new Vector3(50, 0, 50))); 
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(50, 0, 0)));
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(50, 0,-50)));

            this.islandList.Add(new Island(GraphicsDevice, new Vector3(0, 0, 50)));
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(0, 0, 0)));
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(0, 0, -50)));

            this.islandList.Add(new Island(GraphicsDevice, new Vector3(-50, 0, 50)));
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(-50, 0, 0)));
            this.islandList.Add(new Island(GraphicsDevice, new Vector3(-50, 0,-50)));

            this.mill = new Mill(GraphicsDevice, new Vector3(50, -10, 50), -45, this);      
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            this.ship.Update(gameTime);
            this.mill.Update(gameTime);          

            foreach (Island c in this.islandList)
            {
                c.Update(gameTime);
            }      

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.ship.Draw(this.camera);
            this.mill.Draw(this.camera, GraphicsDevice);
            this.tree.Draw(this.camera, GraphicsDevice);

            foreach (Island c in this.islandList)
            {
                c.Draw(this.camera);
            }
            
            base.Draw(gameTime);
        }
    }
}
