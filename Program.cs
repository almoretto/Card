using System;
using System.IO;
using CardExtractTreatment.Services;

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
            Console.Write("Caminho: ");
            string path = @"" + Console.ReadLine();

            //Instances of lines of the file, and the class that will get the data

            ProcessFile processFile;
            FileRW lines = new FileRW();

            try
            {
                //Read
                processFile = new ProcessFile(lines.ReadFile(path));
                Console.WriteLine("Arquivo Lido com suscesso!");
                Console.WriteLine();
                //Process
                processFile.CreateConciliation(processFile.Spf);
                Console.WriteLine("Arquivo processado com sucesso!");
                Console.WriteLine();
                //Write
                lines.WriteFile(path, processFile.Conciliations);
                Console.WriteLine("Arquivo convertido com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            

        }
    }
}

