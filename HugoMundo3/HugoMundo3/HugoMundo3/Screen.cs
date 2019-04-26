﻿using System;
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
    public class Screen
    {
        private int WIDTH;
        private int HEIGHT;
        private static Screen instance;

        private Screen()
        {
        }

        public static Screen GetInstance()
        {
            if (instance == null)
            {
                instance = new Screen();
            }

            return instance;
        }

        public void SetWidth(int width)
        {
            WIDTH = width;
        }

        public int GetWidth()
        {
            return WIDTH;
        }

        public void SetHeight(int height)
        {
            HEIGHT = height;
        }

        public int GetHeight()
        {
            return HEIGHT;
        }
    }
}
