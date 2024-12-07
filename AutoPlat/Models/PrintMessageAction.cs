using AutoPlat.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models
{
    internal class PrintMessageAction : TriggerAction
    {

        internal string Message { get; set; }
        internal PrintMessageAction(string message) 
        {
            Message = message;
        }
        internal override Task Fire()
        {
            Console.WriteLine(Message);

            return Task.CompletedTask;
        }
    }
}
