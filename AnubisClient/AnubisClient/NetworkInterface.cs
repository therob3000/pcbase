using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;


namespace AnubisClient
{
    public class NetworkInterface
    {
        private Sock ssock;
        private Sock sssock;
        private BackgroundWorker NetCommWorker;
        private string _ReceivedMessage;

        public void NetworkInterface ()
        {
            NetCommWorker = new BackgroundWorker();
            NetCommWorker.WorkerReportsProgress = true;
            NetCommWorker.WorkerSupportsCancellation = true;
            NetCommWorker.DoWork += NetCommWorker_DoWork;
            NetCommWorker.ProgressChanged += NetCommWorker_ProgressChanged;
            NetCommWorker.RunWorkerCompleted += NetCommWorker_RunWorkerCompleted;

        }
                    
        private void NetCommWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int Interval = 10; //Interval in Miliseconds 
            try
            {
                ssock = new Sock(1337);
                ssock.Listen();
                NetCommWorker.ReportProgress(0, "Waiting for Client Connection");
                sssock = ssock.Accept();
                while (!NetCommWorker.CancellationPending)
                {
                    //string test = CommandBuilder.GetCurrentCommand();
                    sssock.sendline("sv " + CommandBuilder.GetCurrentCommand());
                    NetCommWorker.ReportProgress(0, "Command Sent");
                    /*   NetCommWorker.ReportProgress(0, "Attempting Read");
                       ReceivedMessage = sssock.readline();
                       NetCommWorker.ReportProgress(1, ReceivedMessage);*/

                    System.Threading.Thread.Sleep(Interval);

                }
            }
            catch (Exception ex)
            {
                NetCommWorker.ReportProgress(0, ex.Message);
                NetCommWorker.CancelAsync();
            }

        }

        /// <summary>
        /// Handles reporting information to the front panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Contains Percent property and UserState property</param>
        private void NetCommWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1) // Provides Returned Network Message to the front panel
            {

            }
            else
            { //Sends error feedback to front panel
                //ts_StatusStrip.Text = e.UserState.ToString();
            }
        }

        /// <summary>
        /// Is Run when the worker is finished. Handles Cleanup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetCommWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //ts_StatusStrip.Text = "Worker Shutdown";
            sssock.sendline("q");
            Thread.Sleep(10);
            ssock.close();
        }

        private string readData(string Paramater)
        {
            try
            {
                sssock.sendline("rd " + Paramater);
                return sssock.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }
        }

        private string readCommand()
        {
            try
            {
                sssock.sendline("rv");
                return sssock.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }
        }

    }
        

}
