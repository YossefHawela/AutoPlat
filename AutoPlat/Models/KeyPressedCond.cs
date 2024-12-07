using AutoPlat.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models
{
    internal class KeyPressedCond : Condition
    {
        public ConsoleKey Key { get; set; }
        public KeyPressedCond(ConsoleKey key)
        {
            Key = key;
        }
        public override bool Met
        {
            get
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == Key)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
