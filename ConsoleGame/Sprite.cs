namespace ConsoleGame
{
    public class Sprite
    {
        public Game Game { get; set; }
        public bool IsDestroyed { get; protected set; }

        public virtual void Initialize()
        {

        }

        public virtual void Update(int delta)
        {
        }

        public virtual void Draw(int delta)
        {
        }

        public virtual void OnDestroyed()
        {

        }

        public void Destroy()
        {
            IsDestroyed = true;
        }
    }
}
