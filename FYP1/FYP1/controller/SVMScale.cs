using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FYP1.controller
{
    class SVMScale
    {

        public List<List<double>> down;
        public List<List<double>> up;
        public List<List<double>> right;
        public List<List<double>> left;
        public List<List<double>> neutral;

        double lowPass = 50; int escape = 4;
        public double[][] downTrainData{ get; set; }
        public double[][] leftTrainData{ get; set; }
        public double[][] rightTrainData{ get; set; }
        public double[][] upTrainData{ get; set; }
        public double[][] neutralTrainData{ get; set; }

        double[][] downTestData;
        double[][] leftTestData;
        double[][] rightTestData;
        double[][] upTestData;
        double[][] neutralTestData;
        public bool fileExistance;
        public double max
        {
            get; set;
        }
        public double min
        {
            get;
            set;
        }
        public SVMScale()
        {
            min = 0;
            max = 0;
            down = new List<List<double>>();
            up = new List<List<double>>();
            left = new List<List<double>>();
            right = new List<List<double>>();
            neutral = new List<List<double>>();
            downTestData = leftTestData = upTestData = rightTestData = rightTrainData = leftTrainData = upTrainData = downTrainData = neutralTestData = neutralTrainData = null;
        }
        public bool buildSVMCorpusUpdated(string subName)
        {
            fileExistance = false;
            string filename = subName + "Train.csv";
            if (File.Exists(filename))
            {
                this.readTrainData(filename);
                fileExistance = true;
                writeSVMTransformData(subName);
            }
            return fileExistance;
        }
        public void readTrainData(string filename)
        {
            var reader = new StreamReader(File.OpenRead(filename ));
            List<string> listB = new List<string>();
            double tempD = 0;
            var line2 = reader.ReadLine();
            string line = "";
            var line1 = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = "";
                line = reader.ReadLine();
                var values = line.Split(',');
                if (values.Length > 1)
                {
                    List<string> tempList = values.ToList<string>();
                    var tempListCount = tempList.Count;
                    tempList.RemoveRange(tempList.Count - 1, 1);
                    tempListCount = tempList.Count;
                    List<double> l1 = tempList.Select(x => double.Parse(x)).ToList();
                    tempD = Double.Parse(values[0]);
                    if (tempD > 0)
                    {
                        if (values[values.Length-1].Equals("Down"))
                            down.Add(l1);
                        else if (values[values.Length-1].Equals("Up"))
                            up.Add(l1);
                        else if (values[values.Length-1].Equals("Left"))
                            left.Add(l1);
                        else if (values[values.Length-1].Equals("Right"))
                            right.Add(l1);
                        else if (values[values.Length-1].Equals("Neutral"))
                            neutral.Add(l1);
                    }
                }
            }
            if (right.Count > 0)
                rightTrainData = right.Select(a => a.ToArray()).ToArray();

            if (left.Count > 0)
                leftTrainData = left.Select(a => a.ToArray()).ToArray();

            if (up.Count > 0)
                upTrainData = up.Select(a => a.ToArray()).ToArray();

            if (down.Count > 0)
                downTrainData = down.Select(a => a.ToArray()).ToArray();

            if (neutral.Count > 0)
                neutralTrainData = neutral.Select(a => a.ToArray()).ToArray();                        
        }
        public bool buildSVMCorpus(string subName)
        {
            fileExistance = false;
            if (File.Exists(subName + "Neutral.csv"))
            {
                this.readData(subName + "Neutral");
                fileExistance = true;
            }
            if (File.Exists(subName + "Up.csv"))
            {
                this.readData(subName + "Up");
                fileExistance = true;
            }
            if (File.Exists(subName + "Down.csv"))
            {
                this.readData(subName + "Down");
                fileExistance = true;
            }
            if (File.Exists(subName + "Left.csv"))
            {
                this.readData(subName + "Left");
                fileExistance = true;
            }
            if (File.Exists(subName + "Right.csv"))
            {
                this.readData(subName + "Right");
                fileExistance = true;
            }
            return fileExistance;
        }
        public void readData(string filename)
        {
            var reader = new StreamReader(File.OpenRead(filename + ".csv"));
            List<string> listB = new List<string>();
            double tempD = 0;

            var line2 = reader.ReadLine();
            string line = "";
            var line1 = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = "";
                line = reader.ReadLine();
                var values = line.Split(',');
                if (values.Length > 1)
                {
                    List<string> tempList = values.ToList<string>();
                    var tempListCount = tempList.Count;
                    tempList.RemoveRange(tempList.Count-1, 1);
                    tempListCount = tempList.Count;
                    List<double> l1 = tempList.Select(x => double.Parse(x)).ToList();
                    tempD = Double.Parse(values[0]);
                    if (tempD > 0)
                    {
                        if (filename.Contains("Down"))
                            down.Add(l1);
                        else if (filename.Contains("Up"))
                            up.Add(l1);
                        else if (filename.Contains("Left"))
                            left.Add(l1);
                        else if (filename.Contains("Right"))
                            right.Add(l1);
                        else if (filename.Contains("Neutral"))
                            neutral.Add(l1);
                    }

                }
            }
            noTestData(filename);
        }
        public void noTestData(string filename)
        {
            if (filename.Contains("Up"))
            {
                upTrainData = new double[up.Count][];
                for (int i = 0; i < up.Count; i++)
                    upTrainData[i] = up.ElementAt(i).ToArray();
            }
            if (filename.Contains("Left"))
            {
                leftTrainData = new double[left.Count][];
                for (int i = 0; i < left.Count; i++)
                    leftTrainData[i] = left.ElementAt(i).ToArray();
            }
            if (filename.Contains("Down"))
            {
                downTrainData = new double[down.Count][];
                for (int i = 0; i < down.Count; i++)
                    downTrainData[i] = down.ElementAt(i).ToArray();
            }
            if (filename.Contains("Right"))
            {
                rightTrainData = new double[right.Count][];
                for (int i = 0; i < right.Count; i++)
                    rightTrainData[i] = right.ElementAt(i).ToArray();

            }
            if (filename.Contains("Neutral"))
            {
                neutralTrainData = new double[neutral.Count][];
                for (int i = 0; i < neutral.Count; i++)
                    neutralTrainData[i] = neutral.ElementAt(i).ToArray();
            }
        }
        public void separationTestTrainData(string filename)
        {
            if (filename.Contains("Up"))
            {
                int testPercentage = Convert.ToInt32(0.1 * up.Count);
                upTrainData = new double[up.Count - testPercentage][];
                upTestData = new double[testPercentage][];

                for (int i = 0, j = 0; i < up.Count; i++)
                    if (i < testPercentage)
                        upTestData[i] = up.ElementAt(i).ToArray();
                    else
                    {
                        upTrainData[j] = up.ElementAt(i).ToArray();
                        j++;
                    }
            }
            if (filename.Contains("Left"))
            {
                int testPercentage = Convert.ToInt32(0.1 * left.Count);
                leftTrainData = new double[left.Count - testPercentage][];
                leftTestData = new double[testPercentage][];

                for (int i = 0, j = 0; i < left.Count; i++)
                    if (i < testPercentage)
                        leftTestData[i] = left.ElementAt(i).ToArray();
                    else
                    {
                        leftTrainData[j] = left.ElementAt(i).ToArray();
                        j++;
                    }
            }
            if (filename.Contains("Down"))
            {
                int testPercentage = Convert.ToInt32(0.1 * down.Count);
                downTrainData = new double[down.Count - testPercentage][];
                downTestData = new double[testPercentage][];

                for (int i = 0, j = 0; i < down.Count; i++)
                    if (i < testPercentage)
                        downTestData[i] = down.ElementAt(i).ToArray();
                    else
                    {
                        downTrainData[j] = down.ElementAt(i).ToArray();
                        j++;
                    }
            }
            if (filename.Contains("Right"))
            {
                int testPercentage = Convert.ToInt32(0.1 * right.Count);
                rightTrainData = new double[right.Count - testPercentage][];
                rightTestData = new double[testPercentage][];

                for (int i = 0, j = 0; i < right.Count; i++)
                    if (i < testPercentage)
                        rightTestData[i] = right.ElementAt(i).ToArray();
                    else
                    {
                        rightTrainData[j] = right.ElementAt(i).ToArray();
                        j++;
                    }
            }
            if (filename.Contains("Neutral"))
            {
                int testPercentage = Convert.ToInt32(0.1 * neutral.Count);
                neutralTrainData = new double[neutral.Count - testPercentage][];
                neutralTestData = new double[testPercentage][];

                for (int i = 0, j = 0; i < neutral.Count; i++)
                    if (i < testPercentage)
                        neutralTestData[i] = neutral.ElementAt(i).ToArray();
                    else
                    {
                        neutralTrainData[j] = neutral.ElementAt(i).ToArray();
                        j++;
                    }
            }
        }
        public void scaleSVMData(string subName)
        {
            //writeSVMTransformData(subName + "SimpleTest");
            writeSVMTransformData(subName + "Simple");

            minDouble(rightTrainData);
            minDouble(upTrainData);
            minDouble(downTrainData);
            minDouble(leftTrainData);
            minDouble(neutralTrainData);

            minDouble(rightTestData);
            minDouble(upTestData);
            minDouble(downTestData);
            minDouble(leftTestData);
            minDouble(neutralTrainData);

            //minus minimum value from each feature value to make it greater than >0
            scaleData(rightTrainData);
            scaleData(upTrainData);
            scaleData(downTrainData);
            scaleData(leftTrainData);
            scaleData(neutralTrainData);

            scaleData(rightTestData);
            scaleData(upTestData);
            scaleData(downTestData);
            scaleData(leftTestData);
            scaleData(neutralTestData);

            maxDouble(rightTrainData);
            maxDouble(upTrainData);
            maxDouble(downTrainData);
            maxDouble(leftTrainData);
            maxDouble(neutralTrainData);

            maxDouble(rightTestData);
            maxDouble(upTestData);
            maxDouble(downTestData);
            maxDouble(leftTestData);
            maxDouble(neutralTestData);

            //now dividing each feature value by maximum of positive value /max
            scale2Data(rightTrainData);
            scale2Data(upTrainData);
            scale2Data(downTrainData);
            scale2Data(leftTrainData);
            scale2Data(neutralTrainData);

            scale2Data(rightTestData);
            scale2Data(upTestData);
            scale2Data(downTestData);
            scale2Data(leftTestData);
            scale2Data(neutralTestData);

            //writeSVMTransformData(subName + "ScaledTest");
            //writeSVMTransformData(subName );
        }
        public void scaleData(double[][] arr)
        {
            if (arr != null)
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] = arr[i][j] + (-1 * min);
                    }
        }
        public void scale2Data(double[][] arr)
        {
            if (arr != null)
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] = arr[i][j] / max;
                        if (arr[i][j] > 1)
                        {
                            arr[i][j] = 0;
                        }
                    }
        }
        public double maxDouble(double[][] arr)
        {
            if (arr != null)
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        if (max < arr[i][j] && arr[i][j] < 500)
                        {
                            max = arr[i][j];
                        }
                        else if (arr[i][j] > 500)
                        {
                            arr[i][j] = 500;
                            max = arr[i][j];
                        }
                    }
            return max;
        }
        public double minDouble(double[][] arr)
        {
            if (arr != null)
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        if (min > arr[i][j])
                        {
                            min = arr[i][j];
                        }
                    }
            return min;
        }
        public void writeSVMTransformData(string subName)
        {
            string path = @subName + "TrainSVM.txt";
            //string minMaxPath = subName + "MinMax.txt";
            // This text is added only once to the file.
            
            //using (StreamWriter sw1 = File.CreateText(minMaxPath))
            //{
            //    sw1.WriteLine(min + "," + max);
            //}

            using (StreamWriter sw = File.CreateText(path))
                {
                    //if (subName.Contains("Train"))
                        writeSVMTransformedTrainData(sw);
                    //else
                      //  writeSVMTransformedTestData(sw);
                }
            /*}

            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if (subName.Contains("Train"))
                        writeSVMTransformedTrainData(sw);
                    else
                        writeSVMTransformedTestData(sw);
                }
            }*/
        }
        public void writeSVMTransformedTrainData(StreamWriter sw)
        {
            string tempStr = "\0";
            if (neutralTrainData != null)
                for (int i = 0; i < neutralTrainData.Length; i++)
                {
                    tempStr = "";
                    //sw.Write("1");
                    for (int j = 0; j < neutralTrainData[i].Length; j++)
                    {
                        if (neutralTrainData[i][j] < lowPass)
                            tempStr= tempStr + " " + (j + 1) + ":" + neutralTrainData[i][j];
                            //sw.Write(" " + (j + 1) + ":" + neutralTrainData[i][j]);
                        else
                            j += escape;
                    }
                    if(tempStr.Length>5)
                    sw.WriteLine("1"+tempStr);
                }
            if (upTrainData != null)
                for (int i = 0; i < upTrainData.Length; i++)
                {
                    //sw.Write("2");
                    tempStr = "";
                    for (int j = 0; j < upTrainData[i].Length; j++)
                    {
                        if (upTrainData[i][j] < lowPass)
                            tempStr += " " + (j + 1) + ":" + upTrainData[i][j];
                            //sw.Write(" " + (j + 1) + ":" + upTrainData[i][j]);
                        else
                            j += escape;
                    }
                    if(tempStr.Length>5)
                    sw.WriteLine("2"+tempStr);
                }
            
            if (downTrainData != null)
                for (int i = 0; i < downTrainData.Length; i++)
                {
                    tempStr = "";
                    //sw.Write("3");
                    for (int j = 0; j < downTrainData[i].Length; j++)
                    {
                        if (downTrainData[i][j] < lowPass)
                            tempStr+=" " + (j + 1) + ":" + downTrainData[i][j];
                        else
                            j += escape;
                    }
                    if(tempStr.Length>5)
                    sw.WriteLine("3"+tempStr);
                }
            if (leftTrainData != null)
                for (int i = 0; i < leftTrainData.Length; i++)
                {
                    //sw.Write("4");
                    tempStr = "";
                    for (int j = 0; j < leftTrainData[i].Length; j++)
                    {
                        if (leftTrainData[i][j] < lowPass)
                            tempStr+=" " + (j + 1) + ":" + leftTrainData[i][j];
                        else
                            j += escape;
                    }
                    if (tempStr.Length > 5)
                        sw.WriteLine("4" + tempStr);
                }
            if (rightTrainData != null)
                for (int i = 0; i < rightTrainData.Length; i++)
                {
                    //sw.Write("5");
                    tempStr = "";
                    for (int j = 0; j < rightTrainData[i].Length; j++)
                    {
                        if (rightTrainData[i][j] < lowPass)
                            tempStr+=" " + (j + 1) + ":" + rightTrainData[i][j];
                        else
                            j += escape;
                    }
                    if(tempStr.Length>5)
                    sw.WriteLine("5"+tempStr);
                }
            
        }
        public void writeSVMTransformedTestData(StreamWriter sw)
        {
            if (upTestData != null)
                for (int i = 0; i < upTestData.Length; i++)
                {
                    sw.Write("1");
                    for (int j = 0; j < upTestData[i].Length; j++)
                    {
                        sw.Write(" " + (j + 1) + ":" + upTestData[i][j]);
                    }
                    sw.WriteLine();
                }

            if (downTestData != null)
                for (int i = 0; i < downTestData.Length; i++)
                {
                    sw.Write("2");
                    for (int j = 0; j < downTestData[i].Length; j++)
                    {
                        sw.Write(" " + (j + 1) + ":" + downTestData[i][j]);
                    }
                    sw.WriteLine();
                }
            if (leftTestData != null)
                for (int i = 0; i < leftTestData.Length; i++)
                {
                    sw.Write("3");
                    for (int j = 0; j < leftTestData[i].Length; j++)
                    {
                        sw.Write(" " + (j + 1) + ":" + leftTestData[i][j]);
                    }
                    sw.WriteLine();
                }
            if (rightTestData != null)
                for (int i = 0; i < rightTestData.Length; i++)
                {
                    sw.Write("4");
                    for (int j = 0; j < rightTestData[i].Length; j++)
                    {
                        sw.Write(" " + (j + 1) + ":" + rightTestData[i][j]);
                    }
                    sw.WriteLine();
                }
            if (neutralTestData != null)
                for (int i = 0; i < neutralTestData.Length; i++)
                {
                    sw.Write("5");
                    for (int j = 0; j < neutralTestData[i].Length; j++)
                    {
                        sw.Write(" " + (j + 1) + ":" + neutralTestData[i][j]);
                    }
                    sw.WriteLine();
                }
        }
    }
}
