using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    //Class to be able to monitor and provide locks on threads when needed,
    //thus when tow threads are trying to access the same information
    class Monitor
    {
        //instance of the monitor
        private static Monitor instance = null;

        //readonly padlock object
        private static readonly object padlock = new object();

        //private constructor of the monitor object
        private Monitor()
        {

        }

        //When lock on the instance requested
        public static Monitor Instance
        {
            //the lock
            get
            {   
                //Set the lock
                lock (padlock)
                {
                    //if the instance is null create such to manage the lock
                    if (instance==null)
                    {
                        instance = new Monitor();
                    }
                    return instance;
                }
            }
        }
    }
}
