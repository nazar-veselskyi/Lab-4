using System;
using System.Collections.Generic;

namespace NRVI_LABS_4_6 {
    public class Message {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }

        public bool Equals(Message message) {
            return message.User == User && message.Text == Text && message.ReceivingTime == ReceivingTime;
        }

        public override bool Equals(object obj) {
            if (!(obj is Message))
                return false;

            return Equals((Message)obj);
        }

        public override int GetHashCode() {
            return User.GetHashCode() ^ Text.GetHashCode() ^ ReceivingTime.GetHashCode();
        }
    }
}
