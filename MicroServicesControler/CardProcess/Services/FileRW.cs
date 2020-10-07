using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using MicroServicesControler.CardProcess.Entities;

namespace MicroServicesControler.CardProcess.Services
{
    class FileRW
    {
        //Reading Method Parameter: File Path, Output: List of String Arrays
        public List<string[]> ReadFile(string path)
        {
            List<string[]> lines = new List<string[]>();
            using FileStream fs = new FileStream(path, FileMode.Open);
            using (StreamReader sr = new StreamReader(fs))
            {
               
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine().Split(';'));
                    Console.Write(".");
                }
                lines.RemoveAt(0);
                Console.WriteLine();
                foreach (string[] item in lines)
                {
                    string hour;
                    hour = item[5].Replace(".", ":");
                    item[5] = hour;
                }
            }
            return lines;
        }
        //Writing Method parameter: File Path and List of processed records ConciliantionEx, output void, 
        //creates file in same folder with name Proc[DateHour].csv
        public string WriteFile(string path, List<ConciliationEx> cEx)
        {
            string targetPath = Path.GetDirectoryName(path) + @"\Proc" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".csv";

            using StreamWriter sw = File.AppendText(targetPath);
            StringBuilder sb = new StringBuilder();
            //Header
            sb.Append("T;");
            sb.Append("EC;");
            sb.Append("AAAAMM;");
            sb.Append("Terminal;");
            sb.Append("DataVenda;");
            sb.Append("Hora;");
            sb.Append("NSU;");
            sb.Append("Produto;");
            sb.Append("Modalidade;");
            sb.Append("ExPL;");
            sb.Append("ExNCAR;");
            sb.Append("ValorBrutoDaParcela;");
            sb.Append("TaxaAdm;");
            sb.Append("Autorizacao;");
            sb.Append("ValorLiquidoDaParcela;");
            sb.Append("DataDeCredito");
            sb.Append("ParcelaAtual");
            sw.WriteLine(sb.ToString());
            //Data
            sb.Clear();
            foreach (ConciliationEx sp in cEx)
            {
                sb.Append(sp.ConT.ToString() + ";");
                sb.Append(sp.ConEC.ToString() + ";");
                sb.Append(sp.AAAAMM + ";");
                sb.Append(sp.Terminal + ";");
                sb.Append(sp.DataVenda.ToString("d", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.Hora.ToString("T", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.NSU + ";");
                sb.Append(sp.Produto + ";");
                sb.Append(sp.Modalidade + ";");
                sb.Append(sp.ConParcela.ToString() + ";");
                sb.Append(sp.ConNCAR.ToString() + ";");
                sb.Append((sp.ValorBrutoParcela).ToString("F2", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.TaxaAdm.ToString("F2", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.Autori + ";");
                sb.Append((sp.ValorLiquidoParcela).ToString("F2", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.DataDeCredito.ToString("d", CultureInfo.CurrentCulture) + ";");
                sb.Append(sp.ParcelaAtual.ToString());
                sw.WriteLine(sb.ToString());
                sb.Clear();
            }
         
            sw.WriteLine("Total de Regiatros" + cEx.Count.ToString());
            return targetPath;
        }

    }
}
