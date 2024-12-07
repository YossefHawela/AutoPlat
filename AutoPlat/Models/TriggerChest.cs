using AutoPlat.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Models
{

    /// <summary>
    /// Container of set of trigers and the one that updates all the trigers state.
    /// </summary>
    internal class TriggerChest
    {
        private int _milliSeconds= 16;
        private Thread? _thread;
        private ManualResetEvent resetEvent = new ManualResetEvent(true);

        public List<Trigger> Triggers { get; private set; } = new List<Trigger>();
        public int MilliSeconds => _milliSeconds;


        /// <summary>
        /// Start updating Triggers every selected milliSeconds 
        /// </summary>
        /// <param name="milliSeconds"></param>
        public void StartUpdate(int milliSeconds)
        {
            _milliSeconds = milliSeconds;

            _thread = new Thread(Loop);

            _thread.Start();
            
        }

        /// <summary>
        /// Conutine excuting the Tirggers 
        /// </summary>
        public void ResumeUpdate()
        {
            resetEvent.Set();

        }

        /// <summary>
        /// Stops excuting the Tirggers 
        /// </summary>
        public void PauseUpdate()
        {
            resetEvent.Reset();
        }


        private void Loop()
        {
            while (true)
            {
                resetEvent.WaitOne();

                foreach (var trigger in Triggers) Task.Run(trigger.Update);
                Thread.Sleep(_milliSeconds);
            }
        }


    }



}
