using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_PracticeTest1_Temperatures
{
    class Reading
    {
        // fields*******************************************************
        private string _date;
        private double _high;
        private double _low;

        // Constructor**************************************************
        /// <summary>
        /// Initialises the object to the values passed in
        /// </summary>
        /// <param name="date">The date of the reading</param>
        /// <param name="high">The high value for that date</param>
        /// <param name="low">The low value for that date</param>
        public Reading(string date, double high, double low)
        {
            Date = date;
            High = high;
            Low = low;
        }

        // Properties***************************************************

        /// <summary>
        /// Gets the date of the reading
        /// </summary>
        public string Date
        {
            get { return _date; }
            set
            {
                if (value != "")
                {
                    _date = value;
                }
                else
                {
                    throw new Exception("The date must be specified");
                }
            }
        }

        /// <summary>
        /// Gets and sets the high temperature value for that date
        /// </summary>
        public double High
        {
            get { return _high; }
            set { _high = value; }
        }

        /// <summary>
        /// Gets and sets the low value for that date
        /// </summary>
        public double Low
        {
            get { return _low; }
            set { _low = value; }
        }

        /// <summary>
        /// Gets all information about a reading
        /// </summary>
        /// <returns>All information as a neatly padded out string</returns>
        public override string ToString()
        {
            return Date.PadRight(15) + High.ToString().PadRight(10) + Low.ToString().PadRight(10) + AverageTemp();
        }

        /// <summary>
        /// Gets the average temperature for the date
        /// </summary>
        /// <returns>The average temperature</returns>
        public double AverageTemp()
        {
            return (High + Low) / 2;
        }
    }
}
