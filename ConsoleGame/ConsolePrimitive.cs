using System;

namespace ConsoleGame
{
    public class ConsolePrimitive
    {
        private int lastX;
        private int lastY;
        private int x;
        private int y;
        private ConsoleColor foreground;
        private ConsoleColor background;
        private char graphics;

        public bool HasChanged { get; private set; }
        public ConsoleColor Foreground { get => foreground; set { foreground = value; HasChanged = true; } }
        public ConsoleColor Background { get => background; set { background = value; HasChanged = true; } }
        public int X { get => x; set { x = value; HasChanged = true; } }
        public int Y { get => y; set { y = value; HasChanged = true; } }
        public char Graphics { get => graphics; set { graphics = value; HasChanged = true; } }
        public int LastX { get => lastX; }
        public int LastY { get => lastY; }

        public void Store(int x, int y)
        {
            lastX = x;
            lastY = y;
        }
    }
}
