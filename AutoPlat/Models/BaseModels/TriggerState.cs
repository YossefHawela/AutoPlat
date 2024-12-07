using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models.BaseModels
{
    internal enum TriggerState
    {
        /// <summary>
        /// trigger in idle state and is waiting for all conditions to be met
        /// </summary>
        Idle,
        /// <summary>
        /// All conditions is met and condition is ready to fire
        /// </summary>
        InFireState,
        /// <summary>
        /// Trigger fired and waiting for one condition to be false so it go back to idle.
        /// </summary>
        Fired
    }
}
