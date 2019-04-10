using System;

namespace ConsoleGame
{
    class Enemy : Sprite
    {
        private ConsolePrimitivesBuffer primitivesBuffer;
        private int accX;
        private int accY;
        private int accShoot;

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { set { primitivesBuffer.GetPrimitive(0).Foreground = value; } }

        public Enemy()
        {
            primitivesBuffer = new ConsolePrimitivesBuffer(1);

            primitivesBuffer.GetPrimitive(0).Graphics = 'X';
            primitivesBuffer.GetPrimitive(0).Foreground = ConsoleColor.Red;
        }

        public override void Update(int delta)
        {
            base.Update(delta);

            accX += delta;
            accY += delta;
            accShoot += delta;

            if (accX > 500)
            {
                accX = 0;

                X += Game.Random.Next(0, 4) - 2;

                if (X >= Game.Renderer.Viewport.Width)
                    X = 0;

                if (X < 0)
                    X = Game.Renderer.Viewport.Width - 1;
            }

            if(accY > 800)
            {
                accY = 0;
                
                if (Y < Game.Renderer.Viewport.Height - 1)
                {
                    Y++;
                }
                else
                    IsDestroyed = true;
            }

            if (accShoot > 1000 && Game.Random.Next(0, 3) == 0)
            {
                accShoot = 0;

                var bullet = Game.SpriteManager.Create<EnemyBullet>();
                bullet.Position = new Vector2(X, Y + 1);
                bullet.Velocity = new Vector2(0, 8);
            }
            else if (accShoot > 1000)
                accShoot = 0;
        }

        public override void Draw(int delta)
        {
            base.Draw(delta);

            Game.Renderer.Render(X, Y, primitivesBuffer);
        }

        public override void OnDestroyed()
        {
            base.OnDestroyed();

            Game.Renderer.Clean(primitivesBuffer);

            if (Game.Random.Next(0, 8) == 0)
            { 
                var enemy1 = Game.SpriteManager.Create<Enemy>();
                var enemy2 = Game.SpriteManager.Create<Enemy>();

                enemy1.Color = ConsoleColor.Yellow;
                enemy2.Color = ConsoleColor.Yellow;

                enemy1.X = X - 1;
                enemy1.Y = Y;
                enemy2.X = X + 1;
                enemy2.Y = Y;

                if (enemy1.X < 0)
                    enemy1.X = 0;

                if (enemy2.X < 0)
                    enemy2.X = 0;

                if (enemy1.X >= Game.Renderer.Viewport.Width)
                    enemy1.X = Game.Renderer.Viewport.Width - 1;

                if (enemy2.X >= Game.Renderer.Viewport.Width)
                    enemy2.X = Game.Renderer.Viewport.Width - 1;
            }
        }
    }
}
