namespace ConsoleGame
{
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y) 
            : this()
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 vector, Vector2 vector2)
        {
            return new Vector2(vector.X + vector2.X, vector.Y + vector2.Y);
        }

        public static Vector2 operator *(Vector2 vector, float scalar)
        {
            return new Vector2(vector.X * scalar, vector.Y * scalar);
        }
    }
}