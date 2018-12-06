﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class SecretAgent : Agent
    {
        private const int CALL_FLOOR = 1;

        public override int[] PermissionFloors { get; set; }
       
        public SecretAgent(Elevator elevator)
            : base(elevator, CALL_FLOOR)
        {
            this.PermissionFloors = new int[] { 0, 1 };
        }
    }
}
