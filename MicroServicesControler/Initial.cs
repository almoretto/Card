using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MicroServicesControler;
using MicroServicesControler.CardProcess.Services;

namespace MicroServicesControler
{
    public partial class Initial : Form
    {
        public Initial()
        {
            InitializeComponent();
        }


        private void FileProcess_Click(object sender, EventArgs e)
        {
            string path = @"" + FilePath.Text;
            //Instances of lines of the file, and the class that will get the data

            ProcessFile processFile;
            FileRW lines = new FileRW();
            StringBuilder sb = new StringBuilder();
            string targetPath;
            try
            {

                //Read
                processFile = new ProcessFile(lines.ReadFile(path));
                sb.AppendLine("Arquivo Lido com suscesso!");
                TextLog.AppendText(sb.ToString());
                //Process
                processFile.CreateConciliation(processFile.Spf);
                sb.AppendLine("Arquivo processado com sucesso!");
                TextLog.Clear();
                TextLog.AppendText(sb.ToString());
                //Write
                targetPath = lines.WriteFile(path, processFile.Conciliations);
                sb.AppendLine("Arquivo gravado com sucesso!");
                sb.AppendLine("Processo Finalizado!");
                TextLog.Clear();
                TextLog.AppendText(sb.ToString());
                //OpenFolder
                Process prc = new Process();
                prc.StartInfo.FileName = targetPath;
                prc.Start();
                path = Path.GetDirectoryName(targetPath);
                prc.StartInfo.WorkingDirectory = path;
                prc.StartInfo.FileName = path;
                prc.Start();
            }
            catch (IOException ex)
            {
                sb.AppendLine("An error occurred!!");
                sb.AppendLine(ex.Message);
                TextLog.Clear();
                TextLog.AppendText(sb.ToString());
            }
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            // define as propriedades do controle
            //OpenFileDialog
            FileSelector.Multiselect = true;
            FileSelector.Title = "Selecionar Arquivo";
            FileSelector.InitialDirectory = @"c:\temp";
            //filtra para exibir somente arquivos de imagens
            FileSelector.Filter = "Arquivos Separados por pontuação (*.CSV;*.TXT;*.TAB)|*.CSV;*.TXT;*.TAB|" + "All files (*.*)|*.*";
            FileSelector.CheckFileExists = true;
            FileSelector.CheckPathExists = true;
            FileSelector.FilterIndex = 2;
            FileSelector.RestoreDirectory = true;
            FileSelector.ReadOnlyChecked = true;
            FileSelector.ShowReadOnly = true;

            DialogResult dr = FileSelector.ShowDialog();

            if (dr == DialogResult.OK)
            {
                FilePath.Text += FileSelector.FileName;

            }
        }

    }
}
