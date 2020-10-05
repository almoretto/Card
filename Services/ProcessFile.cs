using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using CardExtractTreatment.Entities;

namespace CardExtractTreatment.Services
{
    class ProcessFile
    {
        public List<string[]> File { get; set; }
        public SafraPayEx SafraPayEx { get; set; }
        public List<SafraPayEx> Spf { get; set; } = new List<SafraPayEx>();
        public List<ConciliationEx> Conciliations { get; set; } = new List<ConciliationEx>();


        //temp variables to initiate Classes
        int exT, exEC, exPL, exNCAR;
        static int retriveDays = 0;
        string aAAAMM, terminal, nSU, produto, modalidade, autori;
        DateTime dataVenda, hora, dataDeCredito, tempData;
        double valorBruto, taxaAdm, valorLiqParc, valorBrutoParcela;


        public ProcessFile(List<string[]> file)
        {
            File = file;
            ProcessFileEx(File);
        }

        public void ProcessFileEx(List<string[]> file)
        {
            foreach (string[] l in file)
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

                SafraPayEx = new SafraPayEx(exT, exEC, aAAAMM, terminal, dataVenda, hora, nSU,
                            produto, modalidade, exPL, exNCAR, valorBruto, taxaAdm, autori);
                Spf.Add(SafraPayEx);
            }
        }
        public void CreateConciliation(List<SafraPayEx> extract)
        {
            retriveDays = 0;
            ConciliationEx ex;
            foreach (SafraPayEx line in extract)
            {
                if (line.ExPL == 0)
                {
                    valorLiqParc = (1 - line.TaxaAdm / 100) * line.ValorBruto;
                    dataDeCredito = DateVerify(line.DataVenda.AddDays(1));

                    ex = new ConciliationEx(line.ExT, line.ExEC, line.AAAAMM, line.Terminal, line.DataVenda,
                        line.Hora, line.NSU, line.Produto, line.Modalidade, line.ExPL, line.ExNCAR, line.ValorBruto, line.TaxaAdm,
                        line.Autori, valorLiqParc, dataDeCredito, 1);
                    Conciliations.Add(ex);
                }
                else
                {

                    tempData = line.DataVenda;
                    for (int i = 1; i <= line.ExPL; i++)
                    {
                        valorBrutoParcela = line.ValorBruto / line.ExPL;
                        valorLiqParc = (1 - line.TaxaAdm / 100) * valorBrutoParcela;
                        dataDeCredito = DateVerify(tempData.AddDays(30 - retriveDays));
                        tempData = dataDeCredito;

                        ex = new ConciliationEx(line.ExT, line.ExEC, line.AAAAMM, line.Terminal, line.DataVenda,
                                 line.Hora, line.NSU, line.Produto, line.Modalidade, line.ExPL, line.ExNCAR, valorBrutoParcela, line.TaxaAdm,
                                 line.Autori, valorLiqParc, dataDeCredito, i);
                        Conciliations.Add(ex);
                    }

                }
            }


        }

        static DateTime DateVerify(DateTime date)
        {
            HashSet<DateTime> holydays = new HashSet<DateTime>
            {
                DateTime.ParseExact("01/01/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("16/02/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("02/04/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("21/04/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("01/05/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("03/06/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("07/09/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("12/10/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("02/11/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("15/11/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("25/12/2021", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("12/10/2020", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("02/11/2020", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("15/11/2020", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("25/12/2020", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("01/01/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("01/03/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("15/04/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("21/04/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("01/05/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("16/06/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("07/09/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("12/10/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("02/11/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("15/11/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("25/12/2022", "dd/MM/yyyy", CultureInfo.CurrentCulture),
                DateTime.ParseExact("12/10/2020", "dd/MM/yyyy", CultureInfo.CurrentCulture)
            };

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                DateTime tempDate = date.AddDays(2);
                if (holydays.Contains(tempDate))
                {
                    retriveDays = 3;
                    return date.AddDays(3);
                }
                else
                {
                    retriveDays = 2;
                    return date.AddDays(2);
                }

            }
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                DateTime tempDate = date.AddDays(1);
                if (holydays.Contains(tempDate))
                {
                    retriveDays = 2;
                    return date.AddDays(2);
                }
                else
                {
                    retriveDays = 1;
                    return date.AddDays(1);
                }
            }
            if (holydays.Contains(date))
            {
                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    retriveDays = 3;
                    return date.AddDays(3);
                }
                else
                {
                    retriveDays = 1;
                    return date.AddDays(1);
                }
            }
            else
            {
                retriveDays = 0;
                return date;
            }

        }

    }
}
