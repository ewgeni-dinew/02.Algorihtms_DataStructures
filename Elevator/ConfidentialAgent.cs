using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class ConfidentialAgent : Agent
    {
        private const int CALL_FLOOR = 0;

        public override int[] PermissionFloors { get; set; }
          
        public ConfidentialAgent(Elevator elevator)
            : base(elevator, CALL_FLOOR)
        {
            this.PermissionFloors = new int[] { 0 };
        }  
    }
}
