using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class TopSecretAgent : Agent
    {
        private const int CALL_FLOOR = 2;

        public override int[] PermissionFloors { get; set; }

        public TopSecretAgent(Elevator elevator)
            : base(elevator, CALL_FLOOR)
        {
            this.PermissionFloors = new int[] { 0, 1, 2, 3 };
        }
    }
}
