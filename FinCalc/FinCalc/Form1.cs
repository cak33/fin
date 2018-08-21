using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adjusted_daily_file_parser;

namespace FinCalc
{
    public partial class Form1 : Form
    {
        List<string[]> historicalData = new List<string[]>();
        List<string[]> breakthroughs = new List<string[]>();
        string outputFile;
        AdjustedDailyFileParser parse;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void loadBtn_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = openFile.FileName;

                parse = new AdjustedDailyFileParser(file);
                historicalData = parse.parseFile();
            }
        }

        private void calc_Btn_Click(object sender, EventArgs e)
        {
            if (outputFile == "")
            {
                MessageBox.Show("Please select and output file");
            }
            else if (historicalData.Count == 0)
            {
                MessageBox.Show("Please select a data file");
            }
            else
            {
                string startDate, endDate, railPercentage, movingAverage, marginOfSaftey;
                startDate = startDate_TxtBox.Text;
                endDate = endDate_TxtBox.Text;
                railPercentage = railPercentage_TxtBox.Text;
                movingAverage = movingAvg_TxtBox.Text;
                marginOfSaftey = marginSaftey_TxtBox.Text;

                // get data between dates
                historicalData = parse.getDataOfInterest(historicalData, startDate, endDate);
                historicalData = parse.calculateRails(historicalData, Convert.ToInt16(movingAverage), Convert.ToDouble(railPercentage));
                breakthroughs = parse.getBreakthroughs(historicalData, Convert.ToDouble(marginOfSaftey));
                parse.writeBreakthroughs(breakthroughs, outputFile);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputFile = openFile.FileName;
            }
        }
    }
}
