﻿namespace RAGENativeUI.Utility
{
    using System.Drawing;

    using Rage;
    using Graphics = Rage.Graphics;

    public struct Font
    {
        public string Name { get; }
        public float Size { get; }
        private float height;
        public float Height
        {
            get
            {
                if (height == -1.0f && Name != null)
                    height = Common.GetFontHeight(Name, Size);
                return height;
            }
        }

        public Font(string name, float size)
        {
            Name = name;
            Size = size;
            height = -1.0f;
        }

        public SizeF Measure(string text)
        {
            return Graphics.MeasureText(text, Name, Size);
        }
    }
}