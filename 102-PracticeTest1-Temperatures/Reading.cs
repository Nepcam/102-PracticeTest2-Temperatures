using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_PracticeTest1_Temperatures
{
    class Reading
    {
        // fields
        private string _date;
        private double _high;
        private double _low;

        // Constructor
        /// <summary>
        /// Initialises the object to the values passed in
        /// </summary>
        /// <param name="date">The date of the reading</param>
        /// <param name="high">The high value for that date</param>
        /// <param name="low">The low value for that date</param>
        public Reading(string date, double high, double low)
        {
            if (date != "")
            {
                _date = date;
            }
            else
            {
                throw new Exception("The date must be specified");
            }


        }
    }
}
