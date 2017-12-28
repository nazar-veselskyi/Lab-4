namespace NazarVeselskyi.Collections
{
    partial class MessageFormattingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.MessageListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubscriberComboBox = new System.Windows.Forms.ComboBox();
            this.FindMessageTextBox = new System.Windows.Forms.TextBox();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FormattingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MessageListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.MessageListView.Location = new System.Drawing.Point(12, 163);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(414, 299);
            this.MessageListView.TabIndex = 1;
            this.MessageListView.TileSize = new System.Drawing.Size(240, 30);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 100;
            // 
            // SubscriberComboBox
            // 
            this.SubscriberComboBox.FormattingEnabled = true;
            this.SubscriberComboBox.Items.AddRange(new object[] {
            "Subscriber1",
            "Subscriber2",
            "Subscriber3"});
            this.SubscriberComboBox.Location = new System.Drawing.Point(203, 23);
            this.SubscriberComboBox.Name = "SubscriberComboBox";
            this.SubscriberComboBox.Size = new System.Drawing.Size(200, 21);
            this.SubscriberComboBox.TabIndex = 2;
            // 
            // FindMessageTextBox
            // 
            this.FindMessageTextBox.Location = new System.Drawing.Point(203, 50);
            this.FindMessageTextBox.Name = "FindMessageTextBox";
            this.FindMessageTextBox.Size = new System.Drawing.Size(200, 20);
            this.FindMessageTextBox.TabIndex = 3;
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Location = new System.Drawing.Point(203, 88);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FromDateTimePicker.TabIndex = 4;
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Location = new System.Drawing.Point(203, 114);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.ToDateTimePicker.TabIndex = 5;
            // 
            // FormattingTypeComboBox
            // 
            this.FormattingTypeComboBox.FormattingEnabled = true;
            this.FormattingTypeComboBox.Items.AddRange(new object[] {
            "Formatting Type: AND",
            "Formatting Type: OR"});
            this.FormattingTypeComboBox.Location = new System.Drawing.Point(12, 114);
            this.FormattingTypeComboBox.Name = "FormattingTypeComboBox";
            this.FormattingTypeComboBox.Size = new System.Drawing.Size(175, 21);
            this.FormattingTypeComboBox.TabIndex = 6;
            // 
            // MessageFormattingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 474);
            this.Controls.Add(this.FormattingTypeComboBox);
            this.Controls.Add(this.ToDateTimePicker);
            this.Controls.Add(this.FromDateTimePicker);
            this.Controls.Add(this.FindMessageTextBox);
            this.Controls.Add(this.SubscriberComboBox);
            this.Controls.Add(this.MessageListView);
            this.Name = "MessageFormattingForm";
            this.Text = "Message Filtering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox SubscriberComboBox;
        private System.Windows.Forms.TextBox FindMessageTextBox;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.ComboBox FormattingTypeComboBox;
    }
}

