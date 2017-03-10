using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using libsvm;
using System.Windows.Forms;

namespace FYP1.controller
{
    class SVM
    {
        public double C = 50;
        static double gamma = 0.000030518125;
        Dictionary<int, string> predictionDictionary;
        svm_problem _prob; svm_problem _test;
        C_SVC svm;
        double lowPass = 50;
        int escape = 4;
        SVMScale scale;
        bool fileExistance;
        svm_node[] svmnode;
        public SVM()
        {
            fileExistance = false;
            predictionDictionary = new Dictionary<int, string> { { 1, "Neutral" }, { 2, "Up" }, { 3, "Down" }, { 4, "Left" }, { 5, "Right" } };
            scale = new SVMScale();
            svmnode = new svm_node[25];
            int i = 0;
            for(;i<25;i++)
            {
                svmnode[i] = new svm_node();
                svmnode[i].index = i + 1;
            }
        }
        public bool buildSVMCorpus(string filename)
        {
            string trainDataPath = filename+"TrainSVM.txt";
            if (File.Exists(trainDataPath))
            {
                _prob = ProblemHelper.ReadProblem(trainDataPath);
                _test = ProblemHelper.ScaleProblem(_prob);
                svm = new C_SVC(_test, KernelHelper.LinearKernel(), C);
                ProblemHelper.WriteProblem(filename + "output.txt",_test);
                fileExistance = true;
               
            }

                return fileExistance;
        }
        public double buildSVMTestCorpus(string filename)
        {
            double total = 0, tp = 0;
            string trainDataPath = filename + "SimpleTrainSVM.txt";
            if (File.Exists(trainDataPath))
            {
                _test = ProblemHelper.ReadProblem(trainDataPath);
                _test = ProblemHelper.ScaleProblem(_test);
                svm_node[][] sn = _test.x;
                total = sn.Length;
                double[] lbls = _test.y;
                for (int i = 0; i < sn.Length; i++)
                {
                    if(_test.y[i]==svm.Predict(sn[i]))
                        tp++;
                }
                fileExistance = true;
                //ProblemHelper.WriteProblem(filename+"TestSVM.txt", _test);
            }else
            {
                SVMScale readyData = new SVMScale();
                readyData.buildSVMCorpus(filename);
                readyData.scaleSVMData(filename);
                buildSVMTestCorpus(filename);
            }
            return (tp/total)*100;
        }
        public double[] scaleData(double[] testData)
        {
            double[][] test = new double[1][];
            test[0] = new double[testData.Length];
            test[0] = testData;
            scale.minDouble(test);
            scale.scaleData(test);
            scale.maxDouble(test);
            scale.scale2Data(test);
            return test[0];
        }
        public double DoCrossValidationTest()
        {
            var cva = svm.GetCrossValidationAccuracy(5);
            return cva;
        }
        public double moldingSVM(string filename)
        {
            double acc = 0, vc = C, cv=C;
            double[] ac = new double[5];
            int cn = (int) C;
            for (int i = cn; i < cn + 5; i++)
            {
                SVM svm = new SVM();
                svm.buildSVMCorpus(filename);
                ac[i-cn]=svm.DoCrossValidationTest();
                C++;
            }
            acc = ac[0];
            for(int i=0;i<5;i++)
            {
                if (acc < ac[i])
                {
                    acc = ac[i];
                    vc = i;
                }
            }
            //MessageBox.Show("Highest Accuracy : " + (acc * 100) + " With Value of C: " + (cv + vc + 1));
            return acc;
        }
        public int svmAccuracy(List<List<double>> testData,string label)
        {
            int tp = 0;
            /*
            _prob = ProblemHelper.ReadAndScaleProblem(testData);
            double[][] svmv = _prob.x.ToArray<double>();
            MessageBox.Show("Prob_:" + _prob);
            for (int i = 0; i < svmv.GetLength(0); i++)
                for (int j = 0; j < svmv.; j++)
                    MessageBox.Show(svmv[i][j].value+"");
            /*if(testData!= null)
            {
                for(int i=0;i<testData.Length;i++)
                {
                    if(label.Equals(svmRealTimeTest(testData[i])))
                        tp++;
                }
            }*/
            return tp;
        }
        
        public string svmRealTimeTest(double[] testData)
        {
            int len = 0;
            for (int i = 0; i < testData.Length; i++)
                if (testData[i] < lowPass)
                    len++;
                else
                    i += escape;
            svm_problem tempProb = _prob;
            tempProb.x[0] = new svm_node[len];
            
            //testData=scaleData(testData);
            /*List<List<double>> testD = new List<List<double>>();
            testD.Add(testData);
            testData = new List<double>();
            double[] data1 = new double[] { 4, 13.465019915, 221.931854818, 34.448097045, 51.47996222,41.137614759, 15.230779949, 22.01443672, 32.395593998, 21.310546988, 0.988700891, 6.74993337, 5.037963203, 1.074775069, 0.615915165, 0.920866746, 6.755586104, 5.014666624, 2.568192279, 12.08015653, 03.931508695, 500, 500, 500, 1269.375212, 185.55572135 };
            for (int i = 0; i < data1.Length; i++)
                testData.Add(data1[i]);
            testD.Add(testData);
            */
            for (int i=0,j=0;i<len&&j<testData.Length;j++)
            {
                if (testData[j] < lowPass)
                {
                    tempProb.x[0][i] = new svm_node();
                    tempProb.x[0][i].value = testData[j];
                    tempProb.x[0][i].index = j+1;
                    i++;
                }
                else
                    j += escape;
            }
            
            //_test.y = new double[1];
            //_test.y[0] = 0 ;
            //_prob.x[0] = _test.x[0];
            if(len>0)
            tempProb = ProblemHelper.ScaleProblem(tempProb);
            //var predictY = svm.Predict(ProblemHelper.ScaleProblem(_test, 0, 1).x[0]);
            var predictY = svm.Predict(tempProb.x[0]);
            return predictionDictionary[(int)predictY];
        }
    }
}
