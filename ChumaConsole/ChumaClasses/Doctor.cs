using Newtonsoft.Json;
using System;

namespace ChumaConsole.ChumaClasses
{
    // Класс для врача
    public class Doctor : Agent
    {
        public Doctor(int x, int y, int speed, Guid id) : base(x, y, speed, id)
        {
        }

        public void TryHeal(Person person)
        {
            // если переданный человек заражен, то он излечивается
            if (person.IsInfected)
            {
                person.SetInfectedState(false);
            }
        }

        public override string SerializeToJson() => JsonConvert.SerializeObject(this);
    }
}