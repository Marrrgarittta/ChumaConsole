using System;

namespace ChumaConsole.ChumaClasses
{
    public abstract class Agent : IEquatable<Agent>
    {
        public readonly Guid id; // уникальный идентификатор агента
        public int X { get; set; } // координата X
        public int Y { get; set; } // координата Y
        public int Speed { get; set; } // скорость перемещения

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