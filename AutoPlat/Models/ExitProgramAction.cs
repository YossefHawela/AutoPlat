using AutoPlat.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models
{
    internal class ExitProgramAction : TriggerAction
    {
        internal override Task Fire()
        {
            Environment.Exit(0);
           return Task.CompletedTask;
        }
    }
}
