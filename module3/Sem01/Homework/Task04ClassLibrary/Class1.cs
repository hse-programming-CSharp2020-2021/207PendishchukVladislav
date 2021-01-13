using System;

namespace Task04ClassLibrary
{
    public class Robot
    {
        // класс для представления робота
        int x, y; // положение робота на плоскости 

        public int X { get => x; }
        public int Y { get => y; }

        public void Right() { x++; }      // направо
        public void Left() { x--; }      // налево
        public void Forward() { y++; }  // вперед
        public void Backward() { y--; }  // назад

        public string Position()
        {  // сообщить координаты
            return String.Format("The Robot position: x={0}, y={1}", x, y);
        }
    }

    public delegate void Steps();
}
