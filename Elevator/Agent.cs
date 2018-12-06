using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Elevator
{
    public abstract class Agent
    {
        private static readonly Random rand = new Random();

        public abstract int[] PermissionFloors  { get; set; }

        public string Name { get; set; }

        public Elevator Elevator { get; set; }

        public int CallFloor { get; set; }

        public int RequestFloor { get; set; }

        public bool InTheElevator { get; set; }

        public bool PressedFloorButton { get; set; }

        protected Agent(Elevator elevator, int callFloor)
        {
            this.CallFloor = callFloor;
            this.InTheElevator = false;
            this.PressedFloorButton = false;
            this.Elevator = elevator;
            this.Name = this.GetType().Name;
        }

        public void Go()
        {
            while (true)
            {              
                if (this.InTheElevator)
                {
                    if (!this.PressedFloorButton)
                    {
                        this.PressedFloorButton = true;

                        this.RequestFloor = this.GetRandomValue();
                        Console.WriteLine($"{this.Name} has requested floor {this.RequestFloor}.");
                    }
                    else if (this.RequestFloor.Equals(Elevator.CurrentFloor))
                    {
                        if (this.HasPermission())
                        {
                            this.PressedFloorButton = false;
                            this.InTheElevator = false;
                            Console.WriteLine($"+{this.Name} has arrived on the requested floor {this.RequestFloor}!" +
                                $" He leaves...");
                            this.CallFloor = this.Elevator.CurrentFloor;
                            this.Elevator.Leave();
                        }
                        else
                        {
                            this.PressedFloorButton = false;
                            Console.WriteLine($"!!!{this.Name} has no permission to enter the floor!");
                        }
                        continue;
                    }
                    this.Elevator.Move(this.RequestFloor);
                }
                else
                {
                    this.Elevator.Wait();
                    Console.WriteLine($"->{this.Name} has called the elevator to floor {this.CallFloor}.");
                    while (!this.CallFloor.Equals(this.Elevator.CurrentFloor))
                    {
                        this.Elevator.Move(this.CallFloor);
                    }
                    Console.WriteLine($"{this.Name} has entered the elevator!");
                    this.InTheElevator = true;
                }
            }
        }

        private int GetRandomValue()
        {
            int result;

            lock (rand)
            {
                result = rand.Next(0, 4);
            }

            if (result == this.Elevator.CurrentFloor)
            {
                return GetRandomValue();
            }

            return result;
        }

        private bool HasPermission()
        {
            foreach (var floor in this.PermissionFloors)
            {
                if (this.Elevator.CurrentFloor.Equals(floor))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
