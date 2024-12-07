using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models.BaseModels
{
    internal abstract class TriggerAction
    {
        internal abstract Task Fire();

    }
}
