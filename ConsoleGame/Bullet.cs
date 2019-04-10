using System;
using System.Linq;

namespace ConsoleGame
{
    public class Bullet : Sprite
    {
        protected ConsolePrimitivesBuffer primitivesBuffer;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public int X { get { return (int)Math.Round(Position.X); } }
        public int Y { get { return (int)Math.Round(Position.Y); } }

        public char Graphics { set { primitivesBuffer.GetPrimitive(0).Graphics = value; } }
        public ConsoleColor Color { set { primitivesBuffer.GetPrimitive(0).Foreground = value; } }

        public Bullet()
        {
            primitivesBuffer = new ConsolePrimitivesBuffer(1);

            primitivesBuffer.GetPrimitive(0).Foreground = ConsoleColor.Green;
            primitivesBuffer.GetPrimitive(0).Graphics = '^';
        }

        public override void Update(int delta)
        {
            base.Update(delta);

            Position += Velocity * (delta / 1000.0f);

            if (Position.Y <= 0)
                Destroy();

            if (Position.Y >= Game.Renderer.Viewport.Height)
                Destroy();

            var enemy = Game.SpriteManager.Sprites.OfType<Enemy>()
                .FirstOrDefault(en => en.X == X && en.Y == Y);

            if(enemy != null && !(this is EnemyBullet))
            {
                Destroy();
                enemy.Destroy();
            }

            var enemyBullet = Game.SpriteManager.Sprites.OfType<EnemyBullet>()
                .FirstOrDefault(en => en.X == X && en.Y == Y);

            if (enemyBullet != null && !(this is EnemyBullet))
            {
                Destroy();
                enemyBullet.Destroy();
            }
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
        }
    }
}
