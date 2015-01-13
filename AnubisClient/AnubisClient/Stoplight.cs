using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace AnubisClient
{
    class Stoplight : RobotInterface
    {
        private Timer tmr;

        public Stoplight(Sock sock) : base(sock)
        {
            tmr = new Timer(2000);
            tmr.Elapsed += new ElapsedEventHandler(reset);
        }

        private void reset(Object sender, ElapsedEventArgs e)
        {
            tmr.Stop();
            sock_sendline_sync("e");
        }

        private void renew()
        {
            tmr.Stop();
            tmr.Start();
            sock_sendline_sync("s");
        }

        public override string getHeloString()
        {
            return "Stoplight";
        }

        public override void updateSkeleton(Joint3d[] skeleton)
        {
            renew();
        }

        public override void useNeutralSkeleton()
        {
            renew();
        }

        public override void useNullSkeleton()
        {
            renew();
        }

        public override void verifyRobot(EventHandler<GenericEventArgs<bool>> callback)
        {
            // Not Used
        }

        public override void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback)
        {
            // Not Used
        }

        public override void ping(EventHandler<GenericEventArgs<long>> callback)
        {
            Stopwatch timer = new Stopwatch();
            EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) =>
            {
                timer.Stop();
                callback(sender, new GenericEventArgs<long>(timer.ElapsedMilliseconds));
            };
            timer.Start();
            sock_invokeProto_solicitRobotResponse_async("pg", protocallback);
        }
    }
}
