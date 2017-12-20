using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRVI_LABS_4_6;

namespace Tests {
    [TestClass]
    public class Lab4Tests {
        private readonly List<string> _subscribers = new List<string> { "Subscriber1", "Subscriber2", "Subscriber3" };
        private readonly List<string> _searchWords = new List<string> { "I am", "busy", "I" };

        private readonly MessageFormattingForm _form = new MessageFormattingForm();

        [TestMethod]
        public void TestSubscriberFilter() {
            List<Message> messages = new List<Message> {
                new Message {ReceivingTime = DateTime.Now, Text = "I am busy now!", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "You are welcome", User = "Subscriber3"},
                new Message {ReceivingTime = DateTime.Now, Text = "I'll find you!", User = "Subscriber3"},
                new Message {ReceivingTime = DateTime.Now, Text = "I am home, call me.", User = "Subscriber2"},
                new Message {ReceivingTime = DateTime.Now, Text = "Tomorrow after lunch I will be busy!", User = "Subscriber3"},
                new Message {ReceivingTime = DateTime.Now, Text = "Your cat ate my hamster!", User = "Subscriber1"},
            };
            
            foreach (string subscriber in _subscribers) {
                var messagesSubset = _form.GetMessages(messages, subscriber, "", DateTime.Today.AddYears(-1),
                    DateTime.Today.AddYears(1), FormattingType.And);

                foreach (Message message in messagesSubset) {
                    Assert.AreEqual(message.User, subscriber);
                }

                foreach (Message message in messages.Except(messagesSubset)) {
                    Assert.AreNotEqual(message.User, subscriber);
                }
            }

            var notExistingSubscriber = _form.GetMessages(messages, "NoName", "", DateTime.Today.AddYears(-1),
                DateTime.Today.AddYears(1), FormattingType.And);

            Assert.IsTrue(!notExistingSubscriber.Any());
        }

        [TestMethod]
        public void TestSearchWordFilter() {
            var messages = new List<Message> {
                new Message {ReceivingTime = DateTime.Now, Text = "I am busy now!", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "I'll find you!", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "I am home, call me.", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "Tomorrow after lunch I will be busy!", User = "Subscriber1"},
                new Message {ReceivingTime = DateTime.Now, Text = "Your cat ate my hamster!", User = "Subscriber1"},
            };

            foreach (string searchWord in _searchWords) {
                var messagesSubset = _form.GetMessages(messages, "Subscriber1", searchWord, DateTime.Today.AddYears(-1),
                    DateTime.Today.AddYears(1), FormattingType.And);

                foreach (Message message in messagesSubset) {
                    Assert.IsTrue(message.Text.Contains(searchWord));
                }

                foreach (Message message in messages.Except(messagesSubset)) {
                    Assert.IsFalse(message.Text.Contains(searchWord));
                }
            }

            var noResultsSearch = _form.GetMessages(messages, "Subscriber1", "door", DateTime.Today.AddYears(-1),
                DateTime.Today.AddYears(1), FormattingType.And);

            Assert.IsTrue(!noResultsSearch.Any());

            var allResultsSearch = _form.GetMessages(messages, "Subscriber1", "", DateTime.Today.AddYears(-1),
                DateTime.Today.AddYears(1), FormattingType.And);

            Assert.IsTrue(allResultsSearch.Count() == messages.Count);
        }

        [TestMethod]
        public void TestDatePeriodFilter() {
            var messages = new List<Message> {
                new Message {ReceivingTime = new DateTime(1971, 5, 3), Text = "I am busy now!", User = "Subscriber1"},
                new Message {ReceivingTime = new DateTime(1972, 4, 4), Text = "You are welcome", User = "Subscriber1"},
                new Message {ReceivingTime = new DateTime(1983, 9, 9), Text = "I'll find you!", User = "Subscriber1"},
                new Message {ReceivingTime = new DateTime(1989, 1, 2), Text = "I am home, call me.", User = "Subscriber1"},
                new Message {ReceivingTime = new DateTime(1951, 8, 12), Text = "Tomorrow after lunch I will be busy!", User = "Subscriber1"},
                new Message {ReceivingTime = new DateTime(1988, 8, 8), Text = "Your cat ate my hamster!", User = "Subscriber1"},
            };

            DateTime fromDate = new DateTime(1970, 1, 1);
            DateTime toDate = new DateTime(1980, 1, 1);
            var existingPeriod = _form.GetMessages(messages, "Subscriber1", "", fromDate, toDate, FormattingType.And);

            foreach (Message message in existingPeriod) {
                Assert.IsTrue(IsDateInPeriod(message.ReceivingTime, fromDate, toDate));
            }

            foreach (Message message in messages.Except(existingPeriod)) {
                Assert.IsFalse(IsDateInPeriod(message.ReceivingTime, fromDate, toDate));
            }

            fromDate = new DateTime(1990, 1, 1);
            toDate = new DateTime(1995, 1, 1);
            var notExistingPeriod = _form.GetMessages(messages, "Subscriber1", "", fromDate, toDate, FormattingType.And);
            
            Assert.IsTrue(!notExistingPeriod.Any());
        }

        private bool IsDateInPeriod(DateTime date, DateTime fromDate, DateTime toDate) {
            return date.CompareTo(fromDate) >= 0 && date.CompareTo(toDate) <= 0;
        }

        [TestMethod]
        public void TestIncomingMessages() {
            Mobile mobile = new Mobile();
            Assert.IsTrue(mobile.Storage.Messages.Count == 0);

            Thread.Sleep(1000);
            
            Assert.IsTrue(mobile.Storage.Messages.Count > 0);
        }

        [TestMethod]
        public void TestAddingMessage() {
            Mobile mobile = new Mobile();
            Message message = new Message {
                ReceivingTime = new DateTime(1971, 5, 3),
                Text = "I am busy now!",
                User = "Subscriber1"
            };

            mobile.Storage.AddMessage(message);

            Assert.IsTrue(mobile.Storage.Messages.Contains(message));
        }

        [TestMethod]
        public void TestRemovingMessage() {
            Mobile mobile = new Mobile();
            Message message = new Message {
                ReceivingTime = new DateTime(1971, 5, 3),
                Text = "I am busy now!",
                User = "Subscriber1"
            };

            mobile.Storage.AddMessage(message);

            Assert.IsTrue(mobile.Storage.Messages.Contains(message));

            mobile.Storage.RemoveMessage(message);

            Assert.IsFalse(mobile.Storage.Messages.Contains(message));
        }
    }
}
