namespace Task_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            downloadToDatabaseButton = new Button();
            getFileInformationButton = new Button();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            getClassesInformationButton = new Button();
            getGroupInformationButton = new Button();
            downloadedFilesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // downloadToDatabaseButton
            // 
            downloadToDatabaseButton.Location = new Point(28, 26);
            downloadToDatabaseButton.Name = "downloadToDatabaseButton";
            downloadToDatabaseButton.Size = new Size(215, 29);
            downloadToDatabaseButton.TabIndex = 0;
            downloadToDatabaseButton.Text = "Download to database";
            downloadToDatabaseButton.UseVisualStyleBackColor = true;
            downloadToDatabaseButton.Click += DownloadToDatabaseButton_Click;
            // 
            // getFileInformationButton
            // 
            getFileInformationButton.Location = new Point(28, 61);
            getFileInformationButton.Name = "getFileInformationButton";
            getFileInformationButton.Size = new Size(215, 56);
            getFileInformationButton.TabIndex = 1;
            getFileInformationButton.Text = "Get file information from database";
            getFileInformationButton.UseVisualStyleBackColor = true;
            getFileInformationButton.Click += GetFileInformationButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 235);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1775, 735);
            dataGridView1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(341, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(750, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 30);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "File Path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 79);
            label2.Name = "label2";
            label2.Size = new Size(211, 20);
            label2.TabIndex = 5;
            label2.Text = "File Name with extention(.xls) :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(485, 79);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(606, 27);
            textBox2.TabIndex = 6;
            // 
            // getClassesInformationButton
            // 
            getClassesInformationButton.Location = new Point(28, 123);
            getClassesInformationButton.Name = "getClassesInformationButton";
            getClassesInformationButton.Size = new Size(215, 29);
            getClassesInformationButton.TabIndex = 7;
            getClassesInformationButton.Text = "Get classes information";
            getClassesInformationButton.UseVisualStyleBackColor = true;
            getClassesInformationButton.Click += GetClassesInformationButton_Click;
            // 
            // getGroupInformationButton
            // 
            getGroupInformationButton.Location = new Point(28, 158);
            getGroupInformationButton.Name = "getGroupInformationButton";
            getGroupInformationButton.Size = new Size(215, 29);
            getGroupInformationButton.TabIndex = 8;
            getGroupInformationButton.Text = "Get group information";
            getGroupInformationButton.UseVisualStyleBackColor = true;
            getGroupInformationButton.Click += GetGroupInformationButton_Click;
            // 
            // downloadedFilesButton
            // 
            downloadedFilesButton.Location = new Point(28, 193);
            downloadedFilesButton.Name = "downloadedFilesButton";
            downloadedFilesButton.Size = new Size(215, 29);
            downloadedFilesButton.TabIndex = 9;
            downloadedFilesButton.Text = "Show downloaded files";
            downloadedFilesButton.UseVisualStyleBackColor = true;
            downloadedFilesButton.Click += DownloadedFilesButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1835, 982);
            Controls.Add(downloadedFilesButton);
            Controls.Add(getGroupInformationButton);
            Controls.Add(getClassesInformationButton);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(getFileInformationButton);
            Controls.Add(downloadToDatabaseButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button downloadToDatabaseButton;
        private Button getFileInformationButton;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button getClassesInformationButton;
        private Button getGroupInformationButton;
        private Button downloadedFilesButton;
    }
}