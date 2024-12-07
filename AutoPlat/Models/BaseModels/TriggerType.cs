using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models.BaseModels
{

    /// <summary>
    /// The mechanism of triger firing
    /// </summary>
    internal enum TriggerType
    {
        /// <summary>
        /// Continue firing until one condition is not met 
        /// </summary>
        MultibeFire,
        /// <summary>
        /// Fire only once when conditions met, refire again when but in idle state and condions met.
        /// </summary>
        SingleFire
    }
}
