using System;
using System.Collections.Generic;

namespace ChumaConsole.ChumaClasses
{
    public class ChumaModel : IChumaModel
    {
        private const int CRITICAL_DISTANCE = 10;

        public readonly HashSet<Agent> agents = new HashSet<Agent>(); // множество агентов модели
        public void AddAgent(Agent agent) => agents.Add(agent);
        public void RemoveAgent(Agent agent) => agents.Remove(agent);
        public bool IsCriticalDistance(Agent firstAgent, Agent secondAgent) 
            => Math.Sqrt(Math.Pow(firstAgent.X - secondAgent.X, 2) + Math.Pow(firstAgent.Y - secondAgent.Y, 2)) <= CRITICAL_DISTANCE;
 
        /// <summary>
        /// Обновляет положение агентов
        /// </summary>
        /// <param name="timePassed"></param>
        public void UpdateAgents(double timePassed)
        {
            // обновляем положение всех агентов
            foreach (var agent in agents)
            {
                agent.UpdatePosition(timePassed);

                // проверяем наличие зараженных и лечим их
                foreach (var otherAgent in agents)
                {
                    if (agent != otherAgent // это не тот же самый агент
                        && IsCriticalDistance(agent, otherAgent)) // расстояние, на котором можно заразиться
                    {
                        if (agent is Person person) // первый - это человек?
                        {
                            if (otherAgent is Doctor doctor) // второй доктор? 
                            {
                                doctor.TryHeal(person); // если да - пробуем лечить первого
                            }
                            else // оба люди
                            {
                                // пытаются заразить друг друга
                                person.TryInfect(otherAgent);
                                ((Person)otherAgent).TryInfect(person);
                            }
                        }
                        else // это был доктор
                        {
                            if(otherAgent is Person otherPerson) // второй - человек?
                                ((Doctor)agent).TryHeal(otherPerson); // если да, то пробуем лечить его
                            // иначе это два доктора (лечить и заражать никого не нужно)
                        }
                    }
                }
            }
        }
    }
}