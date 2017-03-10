using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Emotiv;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace FYP1.controller
{
    class Signal
    {
        int userID = -1;
        string filename;// = "AverageBandPowers.csv";
        PCA pca;
        KNN knn;
        SVM svm;
        SVMScale svmscale;
        public Signal()
        {
            pca = new PCA();
            knn = new KNN();
            svm = new SVM();
            svmscale = new SVMScale();
        }
        void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("User Added Event has occured");
            userID = (int)e.userId;
            EmoEngine.Instance.IEE_FFTSetWindowingType((uint)userID, EdkDll.IEE_WindowingTypes.IEE_HAMMING);
        }
        static void engine_FacialExpressionEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;

            Single timeFromStart = es.GetTimeFromStart();

            EdkDll.IEE_FacialExpressionAlgo_t[] expAlgoList = {
                                                      EdkDll.IEE_FacialExpressionAlgo_t.FE_WINK_LEFT,
                                                      EdkDll.IEE_FacialExpressionAlgo_t.FE_WINK_RIGHT
                                                      };
            Boolean[] isExpActiveList = new Boolean[expAlgoList.Length];

            Boolean isLeftWink = es.FacialExpressionIsLeftWink();
            Boolean isRightWink = es.FacialExpressionIsRightWink();
            for (int i = 0; i < expAlgoList.Length; ++i)
            {
                isExpActiveList[i] = es.FacialExpressionIsActive(expAlgoList[i]);
            }

            if (isLeftWink)
            {
                Mouse.LeftClick();
                MessageBox.Show("Left Clicked!");
            }

            if (isRightWink)
            {
                Mouse.RightClick();
                MessageBox.Show("Right Clicked!");
            }
        }
        public bool startRealtimeKNN(string id, string name)
        {
            EmoEngine engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.FacialExpressionEmoStateUpdated += new EmoEngine.FacialExpressionEmoStateUpdatedEventHandler(engine_FacialExpressionEmoStateUpdated);
            engine.Connect();
            EdkDll.IEE_DataChannel_t[] channelList = new EdkDll.IEE_DataChannel_t[7] { EdkDll.IEE_DataChannel_t.IED_AF3, EdkDll.IEE_DataChannel_t.IED_AF4, EdkDll.IEE_DataChannel_t.IED_T7,
                                               EdkDll.IEE_DataChannel_t.IED_T8, EdkDll.IEE_DataChannel_t.IED_O1,EdkDll.IEE_DataChannel_t.IED_GYROX,EdkDll.IEE_DataChannel_t.IED_GYROY };
            bool ready = false;
            ready = knn.buildKNNCorpus(name);
            IntPtr state = new IntPtr(1);
            Thread newThread;
            int itr = 0;
            double[] alpha = new double[1];
            double[] low_beta = new double[1];
            double[] high_beta = new double[1];
            double[] gamma = new double[1];
            double[] theta = new double[1];
            double[] data = new double[25];
            while (ready)
            {
                itr++;
                engine.ProcessEvents(10);

                if (userID < 0) continue;
                for (int i = 0, j = 0; i < 5; i++)
                {
                    engine.IEE_GetAverageBandPowers((uint)userID, channelList[i], theta, alpha, low_beta, high_beta, gamma);
                    data[j++] = theta[0];
                    data[j++] = alpha[0];
                    data[j++] = low_beta[0];
                    data[j++] = high_beta[0];
                    data[j++] = gamma[0];
                }
                if (data[0] != 0 && data[24] != 0)
                {
                    newThread = new Thread(() => Form1.Instance.moveTestObject(knn.knnClassifier(data)));
                    newThread.Start();
                }
                Thread.Sleep(500);
            }
            return ready;
        }
        bool ready = false;
        public bool startRealtimeSVM(string id, string name)
        {
            EmoEngine engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.FacialExpressionEmoStateUpdated += new EmoEngine.FacialExpressionEmoStateUpdatedEventHandler(engine_FacialExpressionEmoStateUpdated);
            engine.Connect();
            EdkDll.IEE_DataChannel_t[] channelList = new EdkDll.IEE_DataChannel_t[7] { EdkDll.IEE_DataChannel_t.IED_AF3, EdkDll.IEE_DataChannel_t.IED_AF4, EdkDll.IEE_DataChannel_t.IED_T7,
                                               EdkDll.IEE_DataChannel_t.IED_T8, EdkDll.IEE_DataChannel_t.IED_O1,EdkDll.IEE_DataChannel_t.IED_GYROX,EdkDll.IEE_DataChannel_t.IED_GYROY };            
            if (!ready)
            {
                svmscale.buildSVMCorpusUpdated(name);
                //svmscale.scaleSVMData(name);
                ready = svm.buildSVMCorpus(name);
                startRealtimeSVM(id, name);
            }
            IntPtr state = new IntPtr(1);
            Thread newThread;
            int itr = 0;
            state = EdkDll.IS_Create();
            double[] alpha = new double[1];
            double[] low_beta = new double[1];
            double[] high_beta = new double[1];
            double[] gamma = new double[1];
            double[] theta = new double[1];
            double[] data = new double[25];          
            while (ready)
            {
                itr++;
                engine.ProcessEvents(2);
                if (userID < 0) continue;
                for (int i = 0, j = 0; i < 5; i++)
                {
                    engine.IEE_GetAverageBandPowers((uint)userID, channelList[i], theta, alpha, low_beta, high_beta, gamma);
                    data[j++] = theta[0];
                    data[j++] = alpha[0];
                    data[j++] = low_beta[0];
                    data[j++] = high_beta[0];
                    data[j++] = gamma[0];
                }
                //up simple data taken form karrarUp.csv
                //data = new double[] { 4.651620563, 5.212359266, 10.90409395, 5.157308481, 4.170539408, 5.10950104, 6.035994062,
                //[ 2.254629381, 1.60659665,  1.328094785, 1.882520841, 1.027082428, 2.57410163,  2.209505082, 1.17652227,  0.9200791,   0.524185866, 2.047865372, 1.76506681,  1.091739745, 0.690766561, 0.820688245, 1.643871005, 5.476966707, 1.084435047, 1.055108772, 0.556177084, 335.9026309, 186.3244237, 140.337729,  67.65089061, 25.64029729 ];
                if (data[0] != 0 && data[24] != 0)
                {
                    newThread = new Thread(() => Form1.Instance.moveTestObject(svm.svmRealTimeTest(data)));
                    newThread.Start();
                }
                Thread.Sleep(250);
                //ready = false;
            }

            return ready;
        }
        public void start(string id, string name, string type,long trainTime)
        {
            string header = "Theta, Alpha, Low_beta, High_beta, Gamma, Channel";
            name = name + type + ".csv";
            filename = name;
            if (!File.Exists(filename))
            {
                using (StreamWriter file = File.CreateText(filename))
                {
                    file.WriteLine(header);
                    writeDataFile(file,trainTime);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    writeDataFile(sw,trainTime);
                }
            }   
        }
        public void writeDataFile(StreamWriter file, long trainTime)
        {
            EmoEngine engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.Connect();
            EdkDll.IEE_DataChannel_t[] channelList = new EdkDll.IEE_DataChannel_t[5] { EdkDll.IEE_DataChannel_t.IED_AF3, EdkDll.IEE_DataChannel_t.IED_AF4, EdkDll.IEE_DataChannel_t.IED_T7, EdkDll.IEE_DataChannel_t.IED_T8, EdkDll.IEE_DataChannel_t.IED_O1 };
            int itr = 0;
            var t1 = System.DateTime.Now.TimeOfDay.Add(new TimeSpan(trainTime));

            while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
            {
                engine.ProcessEvents(10);
                if (userID < 0) continue;
                double[] alpha = new double[1];
                double[] low_beta = new double[1];
                double[] high_beta = new double[1];
                double[] gamma = new double[1];
                double[] theta = new double[1];
                for (int i = 0; i < 5; i++)
                {
                    engine.IEE_GetAverageBandPowers((uint)userID, channelList[i], theta, alpha, low_beta, high_beta, gamma);
                    if (itr > 3)
                    {
                        file.Write(theta[0] + ",");
                        file.Write(alpha[0] + ",");
                        file.Write(low_beta[0] + ",");
                        file.Write(high_beta[0] + ",");
                        file.Write(gamma[0] + ",");
                    }
                    //      Console.WriteLine("Theta: " + theta[0]);
                }
                if (itr > 3)
                {
                    if (filename.Contains("Up"))
                        file.WriteLine("Up");
                    else if (filename.Contains("Down"))
                        file.WriteLine("Down");
                    else if (filename.Contains("Left"))
                        file.WriteLine("Left");
                    else if (filename.Contains("Right"))
                        file.WriteLine("Right");
                    else if (filename.Contains("Neutral"))
                        file.WriteLine("Neutral");
                }
                itr++;
                Thread.Sleep(500);
            }
            file.Close();
            engine.Disconnect();
        }
        public void startUpdated(string id, string name, string type, long trainTime)
        {
            string header = "Theta, Alpha, Low_beta, High_beta, Gamma, Channel,Theta, Alpha, Low_beta, High_beta, Gamma, Channel,Theta, Alpha, Low_beta, High_beta, Gamma, Channel,Theta, Alpha, Low_beta, High_beta, Gamma, Channel,Theta, Alpha, Low_beta, High_beta, Gamma, Channel";
            name = name + "Train.csv";
            filename = name;
            if (!File.Exists(filename))
            {
                using (StreamWriter file = File.CreateText(filename))
                {
                    file.WriteLine(header);
                    writeDataFile(file,type, trainTime);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    writeDataFile(sw,type, trainTime);
                }
            }
        }
        public void writeDataFile(StreamWriter file,string type, long trainTime)
        {
            EmoEngine engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.Connect();
            EdkDll.IEE_DataChannel_t[] channelList = new EdkDll.IEE_DataChannel_t[5] { EdkDll.IEE_DataChannel_t.IED_AF3, EdkDll.IEE_DataChannel_t.IED_AF4, EdkDll.IEE_DataChannel_t.IED_T7, EdkDll.IEE_DataChannel_t.IED_T8, EdkDll.IEE_DataChannel_t.IED_O1 };
            int itr = 0;
            var t1 = System.DateTime.Now.TimeOfDay.Add(new TimeSpan(trainTime));

            while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
            {
                engine.ProcessEvents(10);
                if (userID < 0) continue;
                double[] alpha = new double[1];
                double[] low_beta = new double[1];
                double[] high_beta = new double[1];
                double[] gamma = new double[1];
                double[] theta = new double[1];
                for (int i = 0; i < 5; i++)
                {
                    engine.IEE_GetAverageBandPowers((uint)userID, channelList[i], theta, alpha, low_beta, high_beta, gamma);
                    if (itr > 3)
                    {
                        file.Write(theta[0] + ",");
                        file.Write(alpha[0] + ",");
                        file.Write(low_beta[0] + ",");
                        file.Write(high_beta[0] + ",");
                        file.Write(gamma[0] + ",");
                    }
                    //      Console.WriteLine("Theta: " + theta[0]);
                }
                if (itr > 3)
                {
                    if (type.Equals("Up"))
                        file.WriteLine("Up");
                    else if (type.Equals("Down"))
                        file.WriteLine("Down");
                    else if (type.Equals("Left"))
                        file.WriteLine("Left");
                    else if (type.Equals("Right"))
                        file.WriteLine("Right");
                    else if (type.Equals("Neutral"))
                        file.WriteLine("Neutral");
                }
                itr++;
                Thread.Sleep(500);
            }
            file.Close();
            engine.Disconnect();
        }
    }
}
