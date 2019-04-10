using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class SpriteManager
    {
        private readonly Game game;
        private readonly List<Sprite> sprites;
        private int enemyCount;
        private int acc;

        internal List<Sprite> Sprites => sprites;

        public SpriteManager(Game game)
        {
            this.game = game;

            sprites = new List<Sprite>();
        }

        public void Update(int delta)
        {
            acc += delta;

            for (int i = 0; i < Sprites.Count; i++)
            {
                Sprites[i].Update(delta);

                if(Sprites[i].IsDestroyed)
                {
                    if (Sprites[i] is Enemy)
                        enemyCount--;

                    Sprites[i].OnDestroyed();
                    Sprites.RemoveAt(i);
                    i--;
                }

                if(enemyCount < 10 && acc > 1000)
                {
                    acc = 0;
                    
                    var enemy = Create<Enemy>();
                    enemy.X = game.Random.Next(0, game.Renderer.Viewport.Width);
                    enemy.Y = 0;

                    enemyCount++;
                }
            }
        }

        public void Draw(int delta)
        {
            for (int i = 0; i < Sprites.Count; i++)
            {
                Sprites[i].Draw(delta);
            }
            }

        public T Create<T>() where T : Sprite, new()
        {
            T sprite = new T();
            sprite.Game = game;
            sprite.Initialize();
            Sprites.Add(sprite);

            return sprite;
        }
    }
}
