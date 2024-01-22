using ChumaConsole.ChumaClasses;
using System;

namespace ChumaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var model = new ChumaModel();

            var person1 = new Person(1, 1, 5, true, Guid.NewGuid());
            var person2 = new Person(13, 9, 2, false, Guid.NewGuid());
            var doctor = new Doctor (20, 22, 1, Guid.NewGuid());

            model.AddAgent(person1);
            model.AddAgent(person2);
            model.AddAgent(doctor);

            for (int i = 0; i < 8; i++)
            {
                model.UpdateAgents(0.5); // обновляем модель каждые 0.5 секунды

                Console.WriteLine($"Person 1: ({person1.X}, {person1.Y}), Infected: {person1.IsInfected}");
                Console.WriteLine($"Person 2: ({person2.X}, {person2.Y}), Infected: {person2.IsInfected}");
                Console.WriteLine($"Doctor: ({doctor.X}, {doctor.Y})");
            }
        }
    }
}