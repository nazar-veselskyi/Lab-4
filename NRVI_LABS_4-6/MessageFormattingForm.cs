using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NazarVeselskyi.Collections {
    public enum FormattingType {
        And,
        Or
    }

    public partial class MessageFormattingForm : Form {
        private readonly Mobile _mobile;
        private FormattingType _formattingType = FormattingType.And;

        public MessageFormattingForm() {
            InitializeComponent();

            SubscriberComboBox.SelectedIndex = 0;
            SubscriberComboBox.SelectedIndexChanged += OnSubscriberSelected;

            FindMessageTextBox.TextChanged += OnFindMessageChanged;

            FromDateTimePicker.Value = FromDateTimePicker.MinDate;
            ToDateTimePicker.Value = FromDateTimePicker.MaxDate;
            FromDateTimePicker.ValueChanged += OnDateChanged;
            ToDateTimePicker.ValueChanged += OnDateChanged;

            FormattingTypeComboBox.SelectedIndex = 0;
            FormattingTypeComboBox.SelectedIndexChanged += OnFormattingTypeChanged;

            _mobile = new Mobile();
            _mobile.Storage.SMSAdded += OnSmsAdded;
        }

        private void OnSmsAdded(Message message) {
            if (InvokeRequired) {
                Invoke(new Storage.SMSAddedDelegate(OnSmsAdded), message);
                return;
            }

            ShowMessages(GetMessages(_mobile.Storage.Messages, SubscriberComboBox.Text, FindMessageTextBox.Text, FromDateTimePicker.Value, ToDateTimePicker.Value, _formattingType));
        }

        private void ShowMessages(IEnumerable<Message> messages) {
            MessageListView.Items.Clear();
            for (int i = 0; i < messages.Count(); i++) {
                var message = messages.ElementAt(i);
                if (_formattingType == FormattingType.And) {
                    MessageListView.Items.Add(new ListViewItem(new[] { message.User, message.Text}));
                }
                else {
                    if (SubscriberComboBox.SelectedIndex == 0
                        || message.User == SubscriberComboBox.Text
                        || message.Text.Contains(FindMessageTextBox.Text)
                        || (FromDateTimePicker.Value.CompareTo(message.ReceivingTime) < 0
                            && ToDateTimePicker.Value.CompareTo(message.ReceivingTime) > 0)) {
                        MessageListView.Items.Add(new ListViewItem(new[] {message.User, message.Text}));
                    }
                }
            }
        }

        private void OnSubscriberSelected(object obj, EventArgs eventArgs) {
            ShowMessages(GetMessages(_mobile.Storage.Messages, SubscriberComboBox.Text, FindMessageTextBox.Text, FromDateTimePicker.Value, ToDateTimePicker.Value, _formattingType));
        }

        private void OnFindMessageChanged(object obj, EventArgs eventArgs) {
            ShowMessages(GetMessages(_mobile.Storage.Messages, SubscriberComboBox.Text, FindMessageTextBox.Text, FromDateTimePicker.Value, ToDateTimePicker.Value, _formattingType));
        }

        private void OnDateChanged(object obj, EventArgs eventArgs) {
            ShowMessages(GetMessages(_mobile.Storage.Messages, SubscriberComboBox.Text, FindMessageTextBox.Text, FromDateTimePicker.Value, ToDateTimePicker.Value, _formattingType));
        }

        private void OnFormattingTypeChanged(object obj, EventArgs eventArgs) {
            _formattingType = FormattingTypeComboBox.SelectedIndex == 0 ? FormattingType.And : FormattingType.Or;
            ShowMessages(GetMessages(_mobile.Storage.Messages, SubscriberComboBox.Text, FindMessageTextBox.Text, FromDateTimePicker.Value, ToDateTimePicker.Value, _formattingType));
        }

        public IEnumerable<Message> GetMessages(IEnumerable<Message> allMessages, string subscriber, string text, DateTime fromDate, DateTime toDate, FormattingType fType) {
            if (fType == FormattingType.And) {
                return from mess in allMessages
                       where mess.User == subscriber
                       && mess.Text.Contains(text)
                       && mess.ReceivingTime.CompareTo(fromDate) >= 0
                       && mess.ReceivingTime.CompareTo(toDate) <= 0
                       select mess;
            }

            return from mess in allMessages
                where mess.User == subscriber
                      || mess.Text.Contains(text)
                      || (mess.ReceivingTime.CompareTo(fromDate) >= 0 && mess.ReceivingTime.CompareTo(toDate) <= 0)
                select mess;
        }
    }
}
