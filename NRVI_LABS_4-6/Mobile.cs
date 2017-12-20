using System;
using System.Timers;

namespace NRVI_LABS_4_6 {
    public class Mobile {
        private SMSProvider _smsProvider;
        public Storage Storage { get; set; }

        public Mobile() {
            _smsProvider = new SMSProvider();
            _smsProvider.SMSReceived += OnSMSReceived;

            Storage = new Storage();
        }

        private void OnSMSReceived(Message message) {
            Storage.AddMessage(message);
        }

        internal class SMSProvider {
            public delegate void SMSReceivedDelegate(Message message);
            public event SMSReceivedDelegate SMSReceived;

            private System.Timers.Timer _timer;
            private int _messageNumber = 1;
            
            public SMSProvider() {
                StartTimer();
            }

            private void RaiseSmsReceivedEvent(Message message) {
                var handler = SMSReceived;
                if (handler != null)
                    handler(message);
            }

            private void StartTimer() {
                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += OnTimerEvent;
                _timer.AutoReset = true;
                _timer.Enabled = true;
            }

            private void OnTimerEvent(Object source, ElapsedEventArgs e) {
                Random rand = new Random();
                double nextDouble = rand.NextDouble();
                string user = "Subscriber1";
                if (nextDouble < 0.33)
                    user = "Subscriber2";
                else if (nextDouble < 0.66)
                    user = "Subscriber3";

                Message msg = new Message { User = user, ReceivingTime = DateTime.Now, Text = "Message №" + _messageNumber++ + " received!" };
                RaiseSmsReceivedEvent(msg);
            }
        }
    }
}
