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

namespace HugoMundo6
{
    class TreeManager
    {
        GraphicsDevice device;
        Matrix world;
        Game game;
        float x, z;

        Tree[] tree;
        int column, row;
        Camera camera;
        Vector3 position;

        public TreeManager(GraphicsDevice device, Game game, Camera camera, Vector3 position, int column, int row)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;
            this.camera = camera;
            this.position = position;
            this.column = column;
            this.row = row;
            this.tree = new Tree[row * column];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    x = position.X - i * 10;
                    z = position.Z - j * 10;
                    tree[row * i + j] = new Tree(device, game, new Vector3(x, 10, z));
                }
            }
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateTranslation(this.position);

            foreach (Tree t in tree)
            {
                t.Update(gameTime, camera);
            }

            BubbleSort();
        }

        public void BubbleSort()
        {
            for (int i = 0; i < tree.Length; i++)
            {
                for (int j = 0; j < tree.Length - 1; j++)
                {
                    if (tree[i].disCamera > tree[j].disCamera)
                    {
                        Tree aux = tree[i];
                        tree[i] = tree[j];
                        tree[j] = aux;
                    }
                }
            }
        }

        public void Draw(Camera camera)
        {
            foreach (Tree t in tree)
            {
                t.Draw(camera);
            }
        }
    }
}