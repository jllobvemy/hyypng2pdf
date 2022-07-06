namespace hyypng2pdf
{
    partial class MainForm
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
            this.selectedFolderPath = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SuspendLayout();
            // 
            // selectedFolderPath
            // 
            this.selectedFolderPath.Location = new System.Drawing.Point(42, 43);
            this.selectedFolderPath.Name = "selectedFolderPath";
            this.selectedFolderPath.Size = new System.Drawing.Size(192, 23);
            this.selectedFolderPath.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(42, 160);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 15);
            this.statusLabel.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(42, 190);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(192, 23);
            this.progressBar.TabIndex = 2;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(265, 43);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(86, 23);
            this.selectFolderButton.TabIndex = 3;
            this.selectFolderButton.Text = "选择文件";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(265, 72);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(86, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "笨蛋生成！";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(265, 190);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "笨蛋保存！";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.selectedFolderPath);
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "笨蛋生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox selectedFolderPath;
        private Label statusLabel;
        private ProgressBar progressBar;
        private Button selectFolderButton;
        private Button generateButton;
        private Button saveButton;
    }
}