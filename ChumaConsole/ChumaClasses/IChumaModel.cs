namespace ChumaConsole.ChumaClasses
{
    public interface IChumaModel
    {
        void AddAgent(Agent agent);
        void RemoveAgent(Agent agent);
        bool IsCriticalDistance(Agent firstAgent, Agent secondAgent);
        void UpdateAgents(double timePassed);
    }
}