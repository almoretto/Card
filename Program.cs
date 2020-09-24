using System;
using System.IO;
using CardExtractTreatment.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CardExtractTreatment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este sistema irá converter o extrato agrupado em parcelas!");
            Console.WriteLine("=============================================");
            Console.WriteLine("Por favor informe o caminho do arquivo abaixo");
            Console.WriteLine("Caminho e o arquivo não podem conter espaços ");
            Console.WriteLine("ou caracteres especiais recomendamos que seja");
            Console.WriteLine(@"colocado na pasta c:\temp\extrato.csv!");
            Console.WriteLine("=============================================");
            string path = @"" + Console.ReadLine();

            //Instances of lines of the file, and the class that will get the data
            List<string[]> lines = new List<string[]>();
            List<SafraPayEx> sPF = new List<SafraPayEx>();
            SafraPayEx safraPayEx;

            //temp variables to initiate SafraPayEx Class
            int exT, exEC, exPL, exNCAR;
            string aAAAMM, terminal, nSU, produto, modalidade, autori;
            DateTime dataVenda, hora;
            double valorBruto, taxaAdm;

            try
            {
                using FileStream fs = new FileStream(path, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine().Split(";"));

                    }
                }
                foreach (string[] l in lines)
                {
                    exT = int.Parse(l[0]);
                    exEC = int.Parse(l[1]);
                    aAAAMM = l[2];
                    terminal = l[3];
                    dataVenda = DateTime.Parse(l[4], CultureInfo.CurrentCulture);
                    hora = DateTime.Parse(l[5], CultureInfo.CurrentCulture);
                    nSU = l[6];
                    produto = l[7];
                    modalidade = l[8];
                    exPL = int.Parse(l[9]);
                    exNCAR = int.Parse(l[10]);
                    valorBruto = double.Parse(l[11], CultureInfo.CurrentCulture);
                    taxaAdm = double.Parse(l[12], CultureInfo.CurrentCulture);
                    autori = l[13];

                    safraPayEx = new SafraPayEx(exT, exEC, aAAAMM, terminal, dataVenda, hora, nSU,
                                produto, modalidade, exPL, exNCAR, valorBruto, taxaAdm, autori);
                    sPF.Add(safraPayEx);

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            try
            {
                string targetPath = Path.GetDirectoryName(path) + @"\Proc" + DateTime.Now.ToString("ddMMyyyyhhmm") + ".csv";

                using (StreamWriter sw = File.AppendText(targetPath))
                {
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
                    sb.Append("ParcelaAtual");
                    sw.WriteLine(sb.ToString());
                    //Data
                    foreach (SafraPayEx sp in sPF)
                    {
                        
                        for (int i = 1; i <= sp.ExPL; i++)
                        {
                            sb.Append(sp.ExT.ToString() + ";");
                            sb.Append(sp.ExEC.ToString() + ";");
                            sb.Append(sp.AAAAMM + ";");
                            sb.Append(sp.Terminal + ";");
                            sb.Append(sp.DataVenda.ToString("d", CultureInfo.CurrentCulture) + ";");
                            sb.Append(sp.Hora.ToString("T", CultureInfo.CurrentCulture) + ";");
                            sb.Append(sp.NSU + ";");
                            sb.Append(sp.Produto + ";");
                            sb.Append(sp.Modalidade + ";");
                            sb.Append(sp.ExPL.ToString() + ";");
                            sb.Append(sp.ExNCAR.ToString() + ";");
                            sb.Append((sp.ValorBruto / sp.ExPL).ToString("F2", CultureInfo.CurrentCulture) + ";");
                            sb.Append(sp.TaxaAdm.ToString("F2", CultureInfo.CurrentCulture) + ";");
                            sb.Append(sp.Autori + ";");
                            sb.Append((sp.ValorLiquido / sp.ExPL).ToString("F2", CultureInfo.CurrentCulture) + ";");
                            sb.Append(i.ToString() + "/" + sp.ExPL);
                            sw.WriteLine(sb.ToString());
                        }
                        
                    }
                    sw.WriteLine("Total de Regiatros" + sPF.Count.ToString());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

        }
    }
}

