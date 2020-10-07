namespace MicroServicesControler
{
    partial class Initial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileSelector = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileProcess = new System.Windows.Forms.Button();
            this.SelectFile = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.TextLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSelector
            // 
            this.FileSelector.DefaultExt = "csv";
            this.FileSelector.FileName = "SelectedFile";
            this.FileSelector.InitialDirectory = "c:\\temp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Controle de MicroServiços";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileProcess);
            this.groupBox1.Controls.Add(this.SelectFile);
            this.groupBox1.Controls.Add(this.FilePath);
            this.groupBox1.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(16, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processamento SafraPay";
            // 
            // FileProcess
            // 
            this.FileProcess.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileProcess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileProcess.Image = global::MicroServicesControler.Properties.Resources.file_icon_129115;
            this.FileProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileProcess.Location = new System.Drawing.Point(423, 67);
            this.FileProcess.Name = "FileProcess";
            this.FileProcess.Size = new System.Drawing.Size(92, 25);
            this.FileProcess.TabIndex = 3;
            this.FileProcess.Text = "Processar";
            this.FileProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileProcess.UseVisualStyleBackColor = true;
            this.FileProcess.Click += new System.EventHandler(this.FileProcess_Click);
            // 
            // SelectFile
            // 
            this.SelectFile.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SelectFile.Image = global::MicroServicesControler.Properties.Resources.open_file_40455;
            this.SelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectFile.Location = new System.Drawing.Point(423, 36);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(92, 25);
            this.SelectFile.TabIndex = 4;
            this.SelectFile.TabStop = false;
            this.SelectFile.Text = "Selecionar";
            this.SelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // FilePath
            // 
            this.FilePath.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath.Location = new System.Drawing.Point(27, 36);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(390, 25);
            this.FilePath.TabIndex = 5;
            // 
            // TextLog
            // 
            this.TextLog.AcceptsReturn = true;
            this.TextLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLog.Location = new System.Drawing.Point(16, 177);
            this.TextLog.MaximumSize = new System.Drawing.Size(600, 200);
            this.TextLog.Multiline = true;
            this.TextLog.Name = "TextLog";
            this.TextLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextLog.Size = new System.Drawing.Size(549, 137);
            this.TextLog.TabIndex = 5;
            // 
            // Initial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(606, 338);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Initial";
            this.Text = "MicroservicesControler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.OpenFileDialog FileSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FileProcess;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.TextBox TextLog;
    }
}

