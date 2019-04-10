using System;
using System.Linq;

namespace ConsoleGame
{
    public class Game
    {
        public Random Random { get; set; }
        public SpriteManager SpriteManager { get; private set;}
        public ConsoleRenderer Renderer { get; private set; }

        public Game()
        {
            Random = new Random();
            Renderer = new ConsoleRenderer();
            SpriteManager = new SpriteManager(this);
        }

        public void Initialize()
        {
            SpriteManager.Create<Player>();
        }

        public void Update(int delta)
        {
            SpriteManager.Update(delta);
        }

        public void Draw(int delta)
        {
            SpriteManager.Draw(delta);
        }
    }
}
