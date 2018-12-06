using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elevator
{
    public class Elevator
    {
        private const int CAPACITY = 1;
        private Semaphore semaphore;

        public int CurrentFloor { get; set; }

        public Elevator()
        {
            this.semaphore = new Semaphore(CAPACITY, CAPACITY);
            this.CurrentFloor = 0;
        }

        public void Wait()
        {
            semaphore.WaitOne();
        }

        public void Leave()
        {
            semaphore.Release();
        }

        public void Move(int requestFloor)
        {
            
            Console.Write($"----Moved elevator from floor {this.CurrentFloor} to");
            if (this.CurrentFloor>requestFloor)
            {
                this.CurrentFloor--;
            }
            else
            {
                this.CurrentFloor++;
            }

            Thread.Sleep(1000);
            Console.WriteLine($" {this.CurrentFloor}");
        }
    }
}
