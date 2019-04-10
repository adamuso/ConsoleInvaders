using System;

namespace ConsoleGame
{
    public class ConsoleRenderer
    {
        public Viewport Viewport { get; set; }

        public ConsoleRenderer()
        {
            Viewport = new Viewport(0, 0, Console.WindowWidth, Console.WindowHeight);
        }

        public void Render(int x, int y, ConsolePrimitivesBuffer buffer)
        {
            for (int i = 0; i < buffer.Count; i++)
            {
                var primitive = buffer.GetPrimitive(i);

                if (!primitive.HasChanged)
                    continue;

                if (primitive.LastX != primitive.X + x || primitive.LastY != primitive.Y + y)
                {
                    Console.SetCursorPosition(primitive.LastX, primitive.LastY);
                    Console.Write(" ");
                }

                if (primitive.X + x < 0 ||
                    primitive.X + x >= Viewport.Width ||
                    primitive.Y + y < 0 ||
                    primitive.Y + y >= Viewport.Height)
                    continue;

                primitive.Store(Viewport.Left + primitive.X + x, Viewport.Top + primitive.Y + y);

                Console.SetCursorPosition(Viewport.Left + primitive.X + x, Viewport.Top + primitive.Y + y);
                Console.ForegroundColor = primitive.Foreground;
                Console.BackgroundColor = primitive.Background;

                Console.Write(primitive.Graphics);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Clean(ConsolePrimitivesBuffer buffer)
        {
            for (int i = 0; i < buffer.Count; i++)
            {
                var primitive = buffer.GetPrimitive(i);

                Console.SetCursorPosition(primitive.LastX, primitive.LastY);
                Console.Write(" ");
            }
        }
    }
}
