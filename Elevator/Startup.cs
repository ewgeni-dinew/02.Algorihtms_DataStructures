using System;
using System.Collections.Generic;
using System.Threading;

namespace Elevator
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var elevator = new Elevator();

            var agents = new List<Agent>
            {
                new ConfidentialAgent(elevator),
                new SecretAgent(elevator),
                new TopSecretAgent(elevator)
            };

            var agentThreads = new List<Thread>();

            foreach (var a in agents)
            {
                var thread = new Thread(a.Go);
                thread.Start();
                agentThreads.Add(thread);
            }

            foreach (var t in agentThreads)
            {
                t.Join();
            }
        }
    }
}
