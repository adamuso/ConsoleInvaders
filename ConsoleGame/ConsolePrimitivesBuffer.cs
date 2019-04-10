using System;

namespace ConsoleGame
{
    public class ConsolePrimitivesBuffer
    {
        private ConsolePrimitive[] primitives;

        public int Count { get { return primitives.Length; } }

        public ConsolePrimitivesBuffer(int count)
        {
            Resize(count);
        }

        public void Resize(int count)
        {
            primitives = new ConsolePrimitive[count];

            for (int i = 0; i < count; i++)
                primitives[i] = new ConsolePrimitive();
        }

        public ConsolePrimitive GetPrimitive(int index) => primitives[index];
    }
}
