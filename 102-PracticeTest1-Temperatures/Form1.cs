using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _102_PracticeTest1_Temperatures
{
    public partial class Form1 : Form
    {
        //Name:
        //ID:

        List<Reading> temperaturesList = new List<Reading>();
        public Form1()
        {
            InitializeComponent();
        }

        public void UdateListBox()
        {
            listBoxData.Items.Clear();

            //for (int i = 0; i < temperaturesList.Count; i++)
            //{
            //    listBoxData.Items.Add(temperaturesList[i]);
            //}

            // the object 'r' is pointing to the temperaturesList<> (reference variable)
            foreach(Reading r in temperaturesList)
            {
                // you can change values in a list 
                //r.High = 100;
                //r.Low = 100;
                listBoxData.Items.Add(r);
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the file reader
            StreamReader reader;
            // variable to read a line
            string line = "";
            // array to handle the splitting of values from the csv
            string[] csvArray;

            string date = "";
            double high = 0;
            double low = 0;

            // opens the file
            openFileDialog1.Filter = "CSV Files|*.csv|ALL Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader = File.OpenText(openFileDialog1.FileName);
                while (!reader.EndOfStream)
                {
                    try
                    {
                        // read a line from the file
                        line = reader.ReadLine();
                        // split the line using an array
                        csvArray = line.Split(',');
                        // check if the array has the correct number of elements in that line
                        if (csvArray.Length == 3)
                        {
                            // extract the values out
                            date = csvArray[0];
                            high = double.Parse(csvArray[1]);
                            low = double.Parse(csvArray[2]);

                            // create an object and add to the temperatureList
                            Reading r = new Reading(date, high, low);
                            temperaturesList.Add(r);
                            // another way of creating an object an adding it to the List
                            //temperaturesList.Add(new Reading(date, high, low));

                        }
                        else
                        {
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: " + line);
                    }
                }
                reader.Close();
                MessageBox.Show(temperaturesList.Count.ToString());

                UdateListBox();
            }
        }
    }
}
