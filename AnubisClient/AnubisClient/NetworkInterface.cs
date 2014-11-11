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
    //Needs to be written to act as a network listener. This will handle any new connections.
    public class NetworkInterface
    {
        private Sock ssock;
        private Sock sssock;
        private BackgroundWorker NetCommWorker;

        public event EventHandler<Sock> connectionAccepted;
        public event EventHandler<string> netInterfaceMessage;

        public NetworkInterface ()
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
            try
            {
                ssock = new Sock(1337);                    
                ssock.Listen();
                NetCommWorker.ReportProgress(0, "Waiting for Client Connection");
                
                while (!NetCommWorker.CancellationPending)
                {

                    sssock = ssock.Accept();
                    NetCommWorker.ReportProgress(1, sssock);

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
            if (e.ProgressPercentage == 1) //ReturnS NEW socket object
            {
                // raise connectionAccepted event
                if (connectionAccepted != null)
                {
                    connectionAccepted(this, (Sock)e.UserState);
                }
            }
            else if (e.ProgressPercentage == 0)
            { //Sends error feedback to front panel
                if (netInterfaceMessage != null)
                {
                    netInterfaceMessage(this, (string)e.UserState);
                }
            }
        }

        /// <summary>
        /// Is Run when the worker is finished. Handles Cleanup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetCommWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ssock.close();
        }

        public void StartThread()
        {
            if (!NetCommWorker.IsBusy)
                NetCommWorker.RunWorkerAsync();
        }

    }
        

}
