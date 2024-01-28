using System;

namespace ChumaConsole.ChumaClasses
{
    public abstract class Agent : IEquatable<Agent>
    {
        public readonly Guid id; // уникальный идентификатор агента
        private int _x;

        public int X // координата X
        {
            get => _x;
            set
            {
                if (value > 0)
                    _x = value;
                else
                    throw new ArgumentException("Координата X у агента по логике нашей программы, не может быть отрицательной!");
            }
        }

        private int _y;

        public int Y // координата Y
        {
            get => _y;
            set
            {
                if (value > 0)
                    _y = value;
                else
                    throw new ArgumentException("Координата Y у агента по логике нашей программы, не может быть отрицательной!");
            }
        }

        private int _speed;
        public int Speed // скорость перемещения
        {
            get => _speed;
            set
            {
                if (value > 0)
                {
                    if (value < 100)
                        _speed = value;
                    else
                        throw new ArgumentException("Скорость агента по логике нашей программы, не может быть более 100 единиц!");
                }
                else
                    throw new ArgumentException("Скорость по логике нашей программы, не может быть отрицательной!");
            }
        }

        public Agent(int x, int y, int speed, Guid id)
            => (X, Y, Speed, this.id) = (x, y, speed, id);

        /// <summary>
        /// Обновляет позицию агента
        /// </summary>
        /// <param name="timePassed"></param>
        public void UpdatePosition(double timePassed)
        {
            // изменяем координаты в соответствии со скоростью и временем
            X += (int)(Speed * timePassed);
            Y += (int)(Speed * timePassed);
        }

        /// <summary>
        /// Сериализует объект в формат Json
        /// </summary>
        /// <returns></returns>
        public abstract string SerializeToJson();

        // ниже переопределения методов для хранения и правильной обработки их в коллекциях (обязательно в паре GetHashCode и Equals)
        public override bool Equals(object obj) => base.Equals(obj);
        public bool Equals(Agent other) => other != null && id == other.id;
        public override int GetHashCode() => HashCode.Combine(id, X, Y, Speed);
    }
}