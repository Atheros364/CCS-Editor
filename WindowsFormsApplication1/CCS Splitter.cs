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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog1.Filter = "css files (*.ccs)|*.ccs|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                //update textbox
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void splitallButton_Click(object sender, EventArgs e)
        {
            splitAll(textBox1.Text);
        }

        private void splitorderButton_Click(object sender, EventArgs e)
        {
            splitOrder(textBox1.Text);
        }

        private void splittimeButton_Click(object sender, EventArgs e)
        {
            splitTime(textBox1.Text);
        }

        private void splitAll(string filePath)
        {
            //Load the data, add the clip ID lines and output in new file
            string[] origFile = getText(filePath);
            if(origFile == null)//if the source file is bad don't go to next part, the user warning comes in getText
            {
                return;
            }

            //get the clip name
            string clipBaseName = origFile[2].Substring(2, origFile[2].Length - 3);

            //start outputting to a new file while modifying it
            // Set a variable to the My Documents path. 
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();

            //Start building the file
            int clipCount = 1;
            int segStart = 4;
            int segEnd = origFile.Length - 1;
            sb.AppendLine(origFile[0]);
            sb.AppendLine();
            for(int i = segStart; i < segEnd; i++)
            {
                sb.AppendLine("C(" + clipBaseName + clipCount + ")");
                sb.AppendLine(origFile[i]);
                sb.AppendLine();
                clipCount++;
            }


            // Write the stream contents to a new file named "editedclips.ccs".
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\editedclips.ccs"))
            {
                outfile.Write(sb.ToString());
            }

            Completed prompt = new Completed();
            prompt.ShowDialog();

        }

        private void splitOrder(string filePath)
        {
            //Load the data, add the clip ID lines and output in new file
            string[] origFile = getText(filePath);
            if (origFile == null)
            {
                return;
            }

            //get the clip name
            string clipBaseName = origFile[2].Substring(2, origFile[2].Length - 3);

            //start outputting to a new file while modifying it
            // Set a variable to the My Documents path. 
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();

            //Start building the file
            int clipCount = 1;
            int segStart = 4;
            int segEnd = origFile.Length - 1;
            sb.AppendLine(origFile[0]);//write in the transcript name through the first segment
            sb.AppendLine();
            sb.AppendLine("C(" + clipBaseName + clipCount + ")");
            clipCount++;
            sb.AppendLine(origFile[segStart]);

            for (int i = segStart + 1; i < segEnd; i++)//for every segment after compare its page/line to the one before, if it is less than split it
            {
                int firstPage = Convert.ToInt32(origFile[i - 1].Substring(0, 5));//grab all of the page/line numbers
                int firstLine = Convert.ToInt32(origFile[i - 1].Substring(6, 2));
                int secondPage = Convert.ToInt32(origFile[i].Substring(0, 5));
                int secondLine = Convert.ToInt32(origFile[i].Substring(6, 2));
                if (firstPage > secondPage)//add in a clip id if the first segment is greater than the second segment
                {
                    sb.AppendLine();
                    sb.AppendLine("C(" + clipBaseName + clipCount + ")");
                    clipCount++;
                }
                else if(firstPage == secondPage)
                {
                    if(firstLine > secondLine)
                    {
                        sb.AppendLine();
                        sb.AppendLine("C(" + clipBaseName + clipCount + ")");
                        clipCount++;
                    }
                }

                sb.AppendLine(origFile[i]);
            }

            // Write the stream contents to a new file named "editedclips.ccs".
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\editedclips.ccs"))
            {
                outfile.Write(sb.ToString());
            }

            Completed prompt = new Completed();
            prompt.ShowDialog();
        }

        private void splitTime(string filePath)
        {
            //TODO
            //Load the data, add the clip ID lines and output in new file
            string[] origFile = getText(filePath);
            string splitTime = textBox2.Text;

            if (origFile == null)//if the source file is bad don't go to next part, the user warning comes in getText
            {
                return;
            }
            int[] timeArray = getTime(splitTime);//get the text time into numbers
            Console.WriteLine(timeArray[0] + "," + timeArray[1] + "," + timeArray[2] + ",," + timeArray[3]);

            //get the clip name
            string clipBaseName = origFile[2].Substring(2, origFile[2].Length - 3);

            //start outputting to a new file while modifying it
            // Set a variable to the My Documents path. 
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();

            //Start building the file
            int clipCount = 1;
            int segStart = 4;
            int segEnd = origFile.Length - 1;
            sb.AppendLine(origFile[0]);//write in the transcript name through the first segment
            sb.AppendLine();
            sb.AppendLine("C(" + clipBaseName + clipCount + ")");
            clipCount++;
            sb.AppendLine(origFile[segStart]);

            //TODO find the split point and write all of the lines
            //go through and compare the times to the split time.
            //Keeps track of total length and when that is larger than split time, and when that is larger than running time, split the clip.
            for (int i = segStart + 1; i < segEnd; i++)
            {


            }

            // Write the stream contents to a new file named "editedclips.ccs".
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\editedclips.ccs"))
            {
                outfile.Write(sb.ToString());
            }

            Completed prompt = new Completed();
            prompt.ShowDialog();
        }

        private int[] getTime(string timeString)
        {
            //take a string input and output 4 time ints (hour,min,sec,millisec
            int timeHour = 0;
            int timeMin = 0;
            int timeSec = 0;
            int timeMSec = 0;
            string timeHourS = "00";
            string TimeMinS = "00";
            string timeSecS = "00";
            string timeMSecS = "00";
            int timeType = 0;
            int location = 0;
            try
            {
                for (int i = timeString.Length; i > 0; i--)
                {
                    if (timeType == 0)//if currently finding seconds
                    {
                        if (timeString[i - 1] == '.')//if it includes milliseconds
                        {
                            timeMSecS = timeString.Substring(i, timeString.Length - i);
                            timeMSec = Convert.ToInt32(timeMSecS);
                            location = i;
                        }
                        if (timeString[i - 1] == ':')
                        {

                            timeSecS = timeString.Substring(i, location - i - 1);
                            timeSec = Convert.ToInt32(timeSecS);
                            timeType++;
                            location = i;
                        }
                    }
                    else if (timeType == 1)//if currently finding minutes
                    {
                        if (timeString[i - 1] == ':')
                        {
                            TimeMinS = timeString.Substring(i, location - i - 1);
                            timeMin = Convert.ToInt32(TimeMinS);
                            timeType++;
                            location = i;
                        }
                    }
                }
                if (timeType == 1)//if there was one : the remaining numbers are minutes
                {
                    TimeMinS = timeString.Substring(0, location - 1);
                    timeMin = Convert.ToInt32(TimeMinS);
                }
                else if (timeType == 2)//if there were two : the remaining numbers are hours
                {
                    timeHourS = timeString.Substring(0, location - 1);
                    timeHour = Convert.ToInt32(timeHourS);
                }
            }
            catch (Exception e)//exception to catch any errors
            {
                Console.WriteLine("Invalid Time Code");
                InvalidTime prompt = new InvalidTime();
                prompt.ShowDialog();
                Console.WriteLine(e.Message);
                int[] returnValue0 = { 0, 0, 0, 0 };
                return returnValue0;
            }
            if (timeMin > 60 || timeSec > 60 || timeMSec > 1000)//catch if the times are too large
            {
                Console.WriteLine("Invalid Time Code");
                InvalidTime prompt = new InvalidTime();
                prompt.ShowDialog();
                int[] returnValue0 = { 0, 0, 0, 0 };
                return returnValue0;
            }
            int[] returnValue = { timeHour, timeMin, timeSec, timeMSec };
            return returnValue;
        }

        private string[] getText(string filePath)
        {
            //load all of the data from the .ccs into an array and return it, can return null if there is a problem.
            string[] origFile = null;
            try {
                StreamReader sReader = new StreamReader(filePath);//open file


                try // all inside a try to catch errors
                {
                    using (sReader)
                    {
                        var totalLines = 0;//count lines
                        while (sReader.ReadLine() != null)
                        {
                            totalLines++;
                        }
                        sReader.Close();
                        StreamReader sReader2 = new StreamReader(filePath);
                        origFile = new string[totalLines];//create array to hold lines
                        int Counter = 0;
                        string line;
                        while ((line = sReader2.ReadLine()) != null)//fill the array
                        {
                            origFile[Counter] = line;
                            Counter++;

                        }
                        sReader2.Close();
                        for (int i = 0; i <= totalLines - 1; i++)//output file for debug
                        {
                            Console.WriteLine(origFile[i]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    InvalidPath prompt = new InvalidPath();
                    prompt.ShowDialog();
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                InvalidPath prompt = new InvalidPath();
                prompt.ShowDialog();
                Console.WriteLine(e.Message);
            }

            return origFile;
        }
        private void timeBox_GotFocus(object sender, EventArgs e)//handles the default text for the time input
        {
            if (this.waterMarkActive)
            {
                this.waterMarkActive = false;
                this.textBox2.Text = "";
                this.textBox2.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void timeBox_LostFocus(object sender, EventArgs e)
        {
            if (!this.waterMarkActive && string.IsNullOrEmpty(this.textBox2.Text))
            {
                this.waterMarkActive = true;
                this.textBox2.Text = "H:MM:SS";
                this.textBox2.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
