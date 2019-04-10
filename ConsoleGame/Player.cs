using System;

namespace ConsoleGame
{
    class Player : Sprite
    {
        private ConsolePrimitivesBuffer primitiveBuffer;
        private int x;
        private int y;
        private int lastX;
        private int lastY;
        private int acc;

        public Player()
        {
            x = 0;
            primitiveBuffer = new ConsolePrimitivesBuffer(1);

            primitiveBuffer.GetPrimitive(0).Graphics = 'O';
            primitiveBuffer.GetPrimitive(0).Foreground = ConsoleColor.Cyan;
            primitiveBuffer.GetPrimitive(0).X = 0;
            primitiveBuffer.GetPrimitive(0).Y = 0;
        }

        public override void Initialize()
        {
            y = Game.Renderer.Viewport.Height - 1;
        }

        public override void Update(int delta)
        {
            lastX = x;
            lastY = y;

            acc += delta;

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                if (acc > 10 & key.Key == ConsoleKey.RightArrow)
                {
                    acc = 0;

                    if(x < Game.Renderer.Viewport.Width - 1)
                        x++;
                }

                if (acc > 10 & key.Key == ConsoleKey.LeftArrow)
                {
                    acc = 0;

                    if(x > 0)
                        x--;
                }

                if(key.Key == ConsoleKey.Spacebar)
                {
                    var bullet = Game.SpriteManager.Create<Bullet>();
                    bullet.Position = new Vector2(x, y - 1);
                    bullet.Velocity = new Vector2(3, -8);

                    var bullet2 = Game.SpriteManager.Create<Bullet>();
                    bullet2.Position = new Vector2(x, y - 1);
                    bullet2.Velocity = new Vector2(-3, -8);

                    var bullet3 = Game.SpriteManager.Create<Bullet>();
                    bullet3.Position = new Vector2(x, y - 1);
                    bullet3.Velocity = new Vector2(0, -8);
                }
            }
        }

        public override void Draw(int delta)
        {
            Game.Renderer.Render(x, y, primitiveBuffer);
        }
    }
}
