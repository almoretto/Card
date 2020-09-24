using System;
using System.IO;
using CardExtractTreatment.Entities;
using CardExtractTreatment.Services;
using System.Collections.Generic;
using System.Globalization;

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
            List<string[]> lines = new List<string[]>();
            List<SafraPayEx> sPF = new List<SafraPayEx>();
            SafraPayEx safraPayEx;
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
            /* try
             {
                 string[] lines = File.ReadAllLines(sourcePath);
                 using (StreamWriter sw = File.AppendText(targetPath))
                 {
                     foreach (string line in lines)
                     {
                         sw.WriteLine(line.ToUpper());
                     }
                 }
             }
             catch (IOException e)
             {
                 Console.WriteLine("An error occurred");
                 Console.WriteLine(e.Message);
             }*/
        }
    }
}

