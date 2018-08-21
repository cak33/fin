using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adjusted_daily_file_parser
{
    public class AdjustedDailyFileParser
    {
        private static System.IO.StreamReader file;

        public static int timestap_column;
        public static int open_column;
        public static int high_column;
        public static int low_column;
        public static int close_column;
        public static int adjustedClose_column;
        public static int volume_column;
        public static int dividend_column;
        public static int splitCoefficient_column;
        public static int aboveRail_column;
        public static int belowRail_column;
        public static int SMAPoint_column;

        public AdjustedDailyFileParser(string filePath)
        {
            file = new System.IO.StreamReader(filePath);
            string headerLine = file.ReadLine();
            string[] headers = headerLine.Split(',');
            int i = 0;
            foreach (string column in headers)
            {
                if (column == "timestamp") { timestap_column = i; }
                else if (column == "open") { open_column = i; }
                else if (column == "high") { high_column = i; }
                else if (column == "low") { low_column = i; }
                else if (column == "close") { close_column = i; }
                else if (column == "adjusted_close") { adjustedClose_column = i; }
                else if (column == "volume") { volume_column = i; }                
                else if (column == "dividend_amount") { dividend_column = i; }
                else if (column == "split_coefficient") { splitCoefficient_column = i; }
                i++;
            }
            SMAPoint_column = i;
            aboveRail_column = i + 1;
            belowRail_column = i + 2;
        }

        public List<string[]> parseFile()
        {
            List<string[]> historicalData = new List<string[]>();

            int i = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] splitLine = line.Split(',');
                splitLine = addColumns(splitLine, 3);
                historicalData.Add(splitLine);
                i++;
            }

            return historicalData;
        }

        public string[] subArray(string[] originalArray, int index, int length)
        {
            string[] newArray = new string[length];
            Array.Copy(originalArray, index, newArray, 0, length);
            return newArray;
        }

        public string [] addColumns (string[] originalArray, int columnsToAdd)
        {
            int newLength = originalArray.Length + columnsToAdd;
            string[] newArray = new string[newLength];
            for (int i = 0; i < newLength; i ++)
            {
                if (i < originalArray.Length)
                {
                    newArray[i] = originalArray[i];
                } else
                {
                    newArray[i] = "";
                }
            } 
            return newArray;
        }

        public List<string[]> getDataOfInterest(List<string[]> fullDataSet, string startDate, string endDate)
        {
            bool endFound = false;
            List<string[]> relevantData = new List<string[]>();

            foreach (string[] entry in fullDataSet)
            {
                if (!endFound && entry[timestap_column] == endDate)
                {
                    endFound = true;
                }
                if (endFound && entry[timestap_column] == startDate)
                {
                    relevantData.Add(entry);
                    break;
                } else
                {
                    relevantData.Add(entry);
                }

            }
            return relevantData;
        }

        public int getLowIndex(int currIndex, int daysBelow)
        {
            int lowIndex;
            if (currIndex - daysBelow < 0 )
            {
                lowIndex = 0;
            }
            else
            {
                lowIndex = currIndex - daysBelow;
            }
            return lowIndex;
        }

        public void getRails(string[] entry, double SMA_Price,double railPercentage)
        {
            // calculate upper rail
            entry[aboveRail_column] = (SMA_Price * (1 + railPercentage)).ToString();

            // calculate lower rail
            entry[belowRail_column] = (SMA_Price * (1 - railPercentage)).ToString();
        }

        public List<string[]> calculateRails(List<string[]> data, int SMA, double railPercent)
        {
            double SMA_Price = 0.0;
            double sum = 0;
            int test = 0;
            for (int i = data.Count - 1; i >= 0; i --)
            {
                // get to where you can start a moving average 
                if (i > (data.Count) - SMA)
                {
                    string close_price = data[i][close_column];
                    sum += Convert.ToDouble(close_price);
                } 

                // Start the moving average
                else if (i == (data.Count) - SMA)
                {
                    string close_price = data[i][close_column];
                    sum += Convert.ToDouble(close_price);

                    // Calculate the SMA price
                    SMA_Price = sum / SMA;

                    // Set the SMA Price for our current entry
                    data[i][SMAPoint_column] = SMA_Price.ToString();

                    // Calc rails
                    getRails(data[i], SMA_Price, railPercent);
                }
                // Calculate the SMA
                else
                { 
                    // Subtract away value out of window
                    string closePriceToBeSubtracted = data[i + SMA][close_column];
                    sum -= Convert.ToDouble(Convert.ToDouble(closePriceToBeSubtracted));

                    // Add our new entry from today
                    string closePriceToBeAdded = data[i][close_column];
                    sum += Convert.ToDouble(closePriceToBeAdded);

                    // Calculate the SMA price
                    SMA_Price = sum / SMA;

                    // Set the SMA Price for our current entry
                    data[i][SMAPoint_column] = SMA_Price.ToString();

                    // Calc rails
                    getRails(data[i], SMA_Price, railPercent);
                }

            }
            return data;
        }

        public List<string[]> getBreakthroughs(List<string[]> data, double marginOfSaftey)
        {
            List<string[]> breakthroughs = new List<string[]>();
            for (int i = data.Count - 1; i >= 0; i--)
            {
                string[] brkString = new string[4];
                // factor out the first couple of data points that do not have SMA
                if (data[i][SMAPoint_column] != "")
                {
                    // Calculate margin of saftey above and below
                    double upperRailWithSaftey = Convert.ToDouble(data[i][aboveRail_column]) * (1 + marginOfSaftey);
                    double lowerRailWithSaftey = Convert.ToDouble(data[i][belowRail_column]) * (1 - marginOfSaftey);

                    if (Convert.ToDouble(data[i][close_column]) > upperRailWithSaftey)
                    {
                        brkString[0] = "UPPER";
                        brkString[1] = data[i][timestap_column];
                        brkString[2] = data[i][SMAPoint_column];
                        brkString[3] = data[i][close_column];

                        breakthroughs.Add(brkString);
                    }
                    else if (Convert.ToDouble(data[i][close_column]) < lowerRailWithSaftey)
                    {
                        brkString[0] = "LOWER";
                        brkString[1] = data[i][timestap_column];
                        brkString[2] = data[i][SMAPoint_column];
                        brkString[3] = data[i][close_column];

                        breakthroughs.Add(brkString);
                    }
                }
            }

            return breakthroughs;
        }

        public void writeBreakthroughs(List<string[]> breakthroughs, string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath))
            {
                file.WriteLine("Breakthrough Event,Date,SMA,ClosePrice");
                foreach (string[] entry in breakthroughs)
                {
                    string lineToWrite = entry[0] + "," + entry[1] + "," + entry[2] + "," + entry[3];
                    file.WriteLine(lineToWrite);
                }
            }
        }
    }
}
