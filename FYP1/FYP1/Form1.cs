using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using FYP1.controller;
using System.IO;

namespace FYP1
{
    public partial class Form1 : Form
    {
        bool Play_Stop=false;
        Thread td1,startRealtime;
        Signal training = new Signal();
        ICA ica = new ICA();
        PCA pca = new PCA();
        Signal signal = new Signal();
        SVM svm;
        long trainTime = 150000000;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            this.dirPic.Visible = true;
        }
        private static Form1 instance;

        private Form1(int i = 0) { }

        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form1(1);
                }
                return instance;
            }
        }
        private void btnTrain_Click(object sender, EventArgs e)
        {
            pnlTrain.Enabled = true;
            pnlTrain.BackColor = Color.White;
            pnlTest.BackColor = Color.Silver;
            pnlTest.Enabled = false;

            lblIDTrain.Text = Properties.Settings.Default.id.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            testPanelOn();
        }
        private void testPanelOn()
        {

            pnlTest.Enabled = true;
            pnlTest.BackColor = Color.White;
            pnlTrain.BackColor = Color.Silver;
            pnlTrain.Enabled = false;

            lblIDTrain.Text = Properties.Settings.Default.id.ToString();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameTrain.Text))
            {
                MessageBox.Show("Please enter your name!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameTrain.Focus();
                return;
            }
            if (cmbTrainType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select any mental command!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTrainType.Focus();
                return;
            }
            if (startRealtime != null)
                startRealtime.Abort();

            pnlTrain.Enabled = false;
            moveTrainObject();
            pnlTrain.Enabled = true;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.id = Properties.Settings.Default.id += 1;
        }
        private void moveTrainObject()
        {
            string name, id, type;
            name = txtNameTrain.Text;
            id = lblIDTrain.Text;
            long timespan = trainTime+30000000;
            type = cmbTrainType.SelectedItem.ToString();            
            //when device connected uncomment this
            progress.Minimum = 1;
            progress.Maximum = 100;
            progress.Step = 1;
            progress.Value = 1;
            progress.Visible = true;
            progress.MarqueeAnimationSpeed = 250;
            progress.Style = ProgressBarStyle.Blocks;
            progress.ForeColor = Color.GreenYellow;
            dirPic.Image = Properties.Resources.Picture2;
            int x = 512, y = 250,count=1;
            dirPic.Visible = true;
            var t1 = System.DateTime.Now.TimeOfDay.Add(new TimeSpan(timespan));
            if (cmbTrainType.SelectedIndex == 1)
            {
                x = 512; y = 500;
                while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
                {
                    y -= 4;
                    dirPic.Location = new Point(x, y);
                    this.Refresh();
                    System.Threading.Thread.Sleep(250);
                    if (count == 5)
                    {
                        td1 = new Thread(() => training.startUpdated(id, name, type,trainTime));
                        td1.Start();
                    }
                    count++;
                    progress.PerformStep();
                }
                //MessageBox.Show(""+count);
            }
            else if (cmbTrainType.SelectedIndex == 2)
            {
                x = 512; y = 100;
                while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
                {
                    y += 4;
                    dirPic.Location = new Point(x, y);
                    this.Refresh();
                    System.Threading.Thread.Sleep(250);
                    progress.PerformStep();
                    if (count == 5)
                        new Thread(() => training.startUpdated(id, name, type,trainTime)).Start();
                    count++;
                }
            }
            else if (cmbTrainType.SelectedIndex == 3)
            {
                x = 670; y = 263; //651 307673, 263699, 263
                avatar.Visible = true;
                dirPic.Visible = false;
                dirPic.BringToFront();
                while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
                {
                    x -= 5;
                    if (count % 5 == 0)
                        avatar.Image = Properties.Resources.bothL0;
                    else if (count % 5 == 1)
                        avatar.Image = Properties.Resources.bothL1;
                    else if (count % 5 == 2)
                        avatar.Image = Properties.Resources.bothL2;
                    else if (count % 5 == 3)
                        avatar.Image = Properties.Resources.bothL3;
                    else if (count % 5 == 4)
                        avatar.Image = Properties.Resources.bothL4;
                    avatar.Location = new Point(x, y);
                    //dirPic.Location = new Point(x, y);
                    this.Refresh();
                    System.Threading.Thread.Sleep(300);
                    progress.PerformStep();
                    if (count == 5)
                        new Thread(() => training.startUpdated(id, name, type, trainTime)).Start();
                    count++;
                }
                avatar.Visible = false;
                dirPic.Visible = true;
            }
            else if (cmbTrainType.SelectedIndex == 4)
            {
                x = 50; y = 263;
                hole.Visible = true;
                //avatar.Visible = true;
                //dirPic.Visible = false;
                //dirPic.BringToFront();
                hole.BringToFront();
                while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
                {
                    x += 3;
                    if (count % 5 == 0)
                        avatar.Image = Properties.Resources.bothR0;
                    else if (count % 5 == 1)
                        avatar.Image = Properties.Resources.bothR1;
                    else if (count % 5 == 2)
                        avatar.Image = Properties.Resources.bothR2;
                    else if (count % 5 == 3)
                        avatar.Image = Properties.Resources.bothR3;
                    else if (count % 5 == 4)
                        avatar.Image = Properties.Resources.bothR4;
                    if (count % 3 == 0)
                        hole.Image = Properties.Resources.holeL1;
                    else if (count % 3 == 1)
                        hole.Image = Properties.Resources.holeL2;
                    else
                        hole.Image = Properties.Resources.holeL3;
                    //avatar.Location = new Point(x, y);
                    dirPic.Location = new Point(x, y);
                    this.Refresh();
                    System.Threading.Thread.Sleep(50);
                    progress.PerformStep();
                    if (count == 5)
                        new Thread(() => training.startUpdated(id, name, type, trainTime)).Start();
                    count++;
                }
                hole.Visible = false;
                //avatar.Visible = false;
                //dirPic.Visible = true;
            }
            else if (cmbTrainType.SelectedIndex == 5)
            {
                x = 480; y = 255;
                while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1)
                {

                    dirPic.Location = new Point(x, y);
                    this.Refresh();
                    System.Threading.Thread.Sleep(250);
                    progress.PerformStep();
                    if (count == 5)
                        new Thread(() => training.startUpdated(id, name, type, trainTime)).Start();
                    count++;
                }
            }
            progress.Visible = false;
        }
        public void moveTestObject(string direction)
        {
            int x = dirPic.Location.X, y = dirPic.Location.Y;

            if (direction == "Down")
            {
                if (y < 500)
                {
                    y += 5;
                }
                else
                {
                    y = 255;
                }
            }
            else if (direction == "Up")
            {
                if (y > 100)
                {
                    y -= 5;
                }
                else
                {
                    y = 255;
                }
            }
            else if (direction == "Left")
            {
                if (x > 150)
                {
                    x -= 5;
                }
                else
                {
                    x = 512;
                }
            }
            else if (direction == "Right")
            {
                if (x < 950)
                {
                    x += 5;
                }
                else
                {
                    x = 512;
                }
            }
            dirPic.Invoke((MethodInvoker)(() => dirPic.Location = new Point(x, y)));
            this.Invoke((MethodInvoker)(() => this.Refresh()));
        }
        public void floatObject(int timer = 300000000)
        {
            var t1 = System.DateTime.Now.TimeOfDay.Add(new TimeSpan(timer));
            //dirPic.Invoke((MethodInvoker)(() => dirPic.Visible = true));
            //dirPic.Image = Properties.Resources.Picture2;
            int x = 480, y = 250, z = y;
            while (TimeSpan.Compare(t1, System.DateTime.Now.TimeOfDay) == 1 || true)
            {
                if (z < 265)
                {
                    y += 3;
                    if (y > 255)
                        z = y;
                }
                else
                {
                    y -= 3;
                    if (y < 245)
                        z = y;
                }
                dirPic.Invoke((MethodInvoker)(() => dirPic.Location = new Point(x, y)));
                this.Invoke((MethodInvoker)(() => this.Refresh()));
                System.Threading.Thread.Sleep(20);
            }

        }        
        private bool startRealTime()
        {
            bool bol=false;
            if (string.IsNullOrEmpty(txtNameTest.Text))
            {
                MessageBox.Show("Please enter your name!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameTest.Focus();
                return bol;
            }
            else
            if (cmbClassifier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any mental command!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbClassifier.Focus();
                return bol;
            }
            else if (cmbClassifier.SelectedIndex == 1)
            {
                signal = new Signal();
                if (td1 != null)
                    td1.Abort();
                if (startRealtime != null)
                {
                    startRealtime.Abort();
                    startRealtime = new Thread(() => signal.startRealtimeKNN("", txtNameTest.Text.ToString()));
                    startRealtime.Start();
                }
                else
                {
                    startRealtime = new Thread(() => signal.startRealtimeKNN("", txtNameTest.Text.ToString()));
                    startRealtime.Start();
                }
                bol = true;
            }
            else
            {
                if (td1.IsAlive)
                    td1.Suspend();
                if (startRealtime != null)
                {
                    startRealtime.Abort();
                    startRealtime = new Thread(() => signal.startRealtimeSVM("", txtNameTest.Text.ToString()));
                    startRealtime.Start();
                }
                else
                {
                    startRealtime = new Thread(() => signal.startRealtimeSVM("", txtNameTest.Text.ToString()));
                    startRealtime.Start();
                }
                bol = true;
            }
            return bol;
        }
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (!Play_Stop)
            {
                if (startRealTime())
                {
                    btnStartTest.BackgroundImage = Properties.Resources.stop;
                    Play_Stop = true;
                }
            }
            else
            {
                btnStartTest.BackgroundImage = Properties.Resources.Media_Controls_Play_icon;
                Play_Stop = false;
                if(startRealtime!= null)
                startRealtime.Abort();
                if (td1 != null)
                    td1.Resume();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    if(td1!= null)
                    td1.Abort();
                    if (startRealtime != null)
                        startRealtime.Abort();
                    break;
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the final year project\n of team Brain Readers", "About Us", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void pCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter name.", "File Name", "");
            //td1=new Thread(() => bol=pca.ExecutePCA1(name));
            //td1.Start();
            if (!pca.ExecutePCA1(name))
            {
                MessageBox.Show("The Record for the provided name does not exist!");
            }
            else
            {
                MessageBox.Show("PCA Done!");

                timer1.Interval = 50;
                progress.Visible = true;
                timer1.Start();
            }
            //use time bar here
        }
        private void iCPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (startRealTime())
                Mouse.minimize_all();
            else
                testPanelOn();
            /*string name = Microsoft.VisualBasic.Interaction.InputBox("Enter name with command.", "File Name", "");
            td2 = new Thread(() => ica.executeICA(name));
            td2.Start();
            */
            //use time bare here
        }
        public void moveCursor(string direction)
        {
            int x = Cursor.Position.X, y = Cursor.Position.Y;

            if (direction == "Down")
            {
                //if (y < 500)
                {
                    y += 5;
                }
            }
            else if (direction == "Up")
            {
                //if (y > 100)
                {
                    y -= 5;
                }
            }
            else if (direction == "Left")
            {
                //if (x > 150)
                {
                    x -= 5;
                }
            }
            else if (direction == "Right")
            {
                x += 5;
                /*if (x < 950)
                {
                    x += 5;
                }
                else
                {
                    x = 512;
                }*/
            }
            //dirPic.Invoke((MethodInvoker)(() => dirPic.Location = new Point(x, y)));
            //this.Invoke((MethodInvoker)(() => this.Refresh()));
            Cursor.Position = new Point(x, y);
        }
        double c = 1;
        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string train = Microsoft.VisualBasic.Interaction.InputBox("Enter Train Filename.", "File Name", "");
            string test = Microsoft.VisualBasic.Interaction.InputBox("Enter Test Filename.", "File Name", "");
            SVMScale svmtest = new SVMScale();
            bool ready = false;
            svm = new SVM();
            SVMScale svmScale = new SVMScale();
            ready = svm.buildSVMCorpus(train);
            c++;
            if (!ready)
            {
                svmScale.buildSVMCorpus(train);
                svmScale.scaleSVMData(train);
                ready=svm.buildSVMCorpus(train);
            }
            if (ready)
            {
                svmCrossFileAccuracy(train, svmtest, test);
            }
        }
        private void svmCrossFileAccuracy(string train,SVMScale svmtest,string test)
        {
            svmtest.buildSVMCorpus(test);
            double acc = 0, bacc = 0, c = 1;
            svm.C = 0.5;
            for (int i = 0; i < 10; i++)
            {
                svm.C += Math.Pow(i, 2);
                svm.buildSVMCorpus(train);
                acc = svmAllActions(svmtest);
                c = svm.C;
                if (bacc < acc)
                {
                    bacc = acc;
                }
            }
            MessageBox.Show("Accuracy SVM :" + (bacc) + " & C=" + c, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private double svmAllActions(SVMScale svmtest)
        {
            double tp = 0, total = 0;
            tp += svmAcc(svmtest.upTrainData, "Up");
            tp += svmAcc(svmtest.downTrainData, "Down");
            tp += svmAcc(svmtest.neutralTrainData, "Neutral");
            tp += svmAcc(svmtest.leftTrainData, "Left");
            tp += svmAcc(svmtest.rightTrainData, "Right");
            if (svmtest.leftTrainData != null)
                total += svmtest.leftTrainData.Length;
            if (svmtest.neutralTrainData != null)
                total += svmtest.neutralTrainData.Length;
            if (svmtest.downTrainData != null)
                total += svmtest.downTrainData.Length;
            if (svmtest.upTrainData != null)
                total += svmtest.upTrainData.Length;
            if (svmtest.rightTrainData != null)
                total += svmtest.rightTrainData.Length;
            return 100 * tp / total;
        }
        public double svmAcc(double[][] arr, string label)
        {
            double tp = 0;
            if (arr != null)
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (label.Equals(svm.svmRealTimeTest(arr[i])))
                        tp++;
                }
            return tp;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress.Minimum = 0;
            progress.Maximum = 160;
            if (progress.Value < progress.Maximum)
            {
                progress.Value = progress.Value + 1;
            }
            if (progress.Value == 159)
            {
                progress.Visible = false;
            }
        }

        private void cmbTrainType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void accurayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter name.", "File Name", "");

            double accuracy = 0; int fold = 0;
            for (fold = 0; fold < 5; fold++)
            {
                Accuracy acc = new Accuracy();
                if (acc.buildCrossValidationCorpus(name))
                {
                    accuracy += acc.calculateKNNAccuracy();
                    //MessageBox.Show((fold+1)+" Accuracy: " + accuracy);
                }
                else
                {
                    fold = 6;
                }
            }
            if (fold != 7)
            {
                accuracy /= fold;
                if (accuracy > 0)
                {
                    MessageBox.Show("Current Classifier is K-Nearest Neighbours (KNN) its Accuracy: " + accuracy + "%");
                }
            }
            else
            {
                MessageBox.Show("Record Data not found!\n There is no recorded data with provided subject name.\n You must take training! ");
            }
        }

        private void sVMScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter name.", "File Name", "");
            SVMScale svmScale = new SVMScale();

            svmScale.buildSVMCorpus(name);
            if (svmScale.fileExistance)
            {
                svmScale.scaleSVMData(name);
                MessageBox.Show("The data is successfully transformed for SVM application.");
            }
            else
                MessageBox.Show("Record Data not found!\n There is no recorded data with provided subject name");

        }

        private void sVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter name.", "File Name", "");
            SVM svm = new SVM();
            //svm.moldingSVM(name);
            svmClassifierPerformance(svm, name);
        }
        private void svmClassifierPerformance(SVM svm, string name)
        {
            double accuracy = 0;
            if (svm.buildSVMCorpus(name))
            {
                accuracy = svm.DoCrossValidationTest();
                if (accuracy > 0)
                {
                    MessageBox.Show("Current Classifier is Support Vector Machine (SVM), its Accuracy: " + accuracy * 100 + "%");
                }
            }
            else
            {
                SVMScale svmScale = new SVMScale();
                if (svmScale.buildSVMCorpus(name))
                {
                    if (svmScale.fileExistance)
                    {
                        svmScale.scaleSVMData(name);
                        svmClassifierPerformance(svm, name);
                        MessageBox.Show("The data is successfully transformed for SVM application.");
                    }
                }
                else
                    MessageBox.Show("Record Data not found!\n There is no recorded data with provided subject name");

            }
        }
        private void cmbClassifer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dirPic.Image = Properties.Resources.Picture2;
            hole.Visible = false;
            td1 = new Thread(() => floatObject());
            td1.Start();
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.Silver;
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {

            btnStart.BackColor = Color.Transparent;
        }

        private void dirPic_Click(object sender, EventArgs e)
        {

        }

        private bool isDataExist(string name, string type)
        {
            string data = name + " " + type;//this string store data to file
            string[] fileData = File.ReadAllLines(@"Data.txt");
            foreach (string entry in fileData)
            {
                if (string.Equals(data, entry))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
