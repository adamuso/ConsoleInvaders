using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 36;
            Console.CursorVisible = false;

            Game game = new Game();

            game.Renderer.Viewport = new Viewport(35, 4, 30, 28);

            DrawBorder(game);

            game.Initialize();
            int ticks = Environment.TickCount;
            int delta = 0;

            while (true)
            {
                ticks = Environment.TickCount;

                game.Update(delta);
                game.Draw(delta);

                delta = Environment.TickCount - ticks;
            }
        }

        private static void DrawBorder(Game game)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.SetCursorPosition(game.Renderer.Viewport.X - 1, game.Renderer.Viewport.Y - 1);

            for (int i = 0; i < game.Renderer.Viewport.Width + 2; i++)
                Console.Write(" ");

            Console.SetCursorPosition(game.Renderer.Viewport.X - 1, game.Renderer.Viewport.Bottom + 1);

            for (int i = 0; i < game.Renderer.Viewport.Width + 2; i++)
                Console.Write(" ");

            for (int i = 0; i < game.Renderer.Viewport.Height + 2; i++)
            {
                Console.SetCursorPosition(game.Renderer.Viewport.X - 1, game.Renderer.Viewport.Y - 1 + i);
                Console.Write(" ");
            }

            for (int i = 0; i < game.Renderer.Viewport.Height + 2; i++)
            {
                Console.SetCursorPosition(game.Renderer.Viewport.Right + 1, game.Renderer.Viewport.Y - 1 + i);
                Console.Write(" ");
            }
        }
    }
}
