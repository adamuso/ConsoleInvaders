using System;

namespace ConsoleGame
{
    public class EnemyBullet : Bullet
    {
        public EnemyBullet()
        {
            primitivesBuffer.GetPrimitive(0).Graphics = '|';
            primitivesBuffer.GetPrimitive(0).Foreground = ConsoleColor.Magenta;
        }
    }
}