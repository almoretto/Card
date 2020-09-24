using System;
using System.Collections.Generic;
using System.Text;

namespace CardExtractTreatment.Entities
{
    class ConciliationEx
    {
        public int ConT { get; set; }
        public int ConEC { get; set; }
        public string AAAAMM { get; set; }
        public string Terminal { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime Hora { get; set; }
        public string NSU { get; set; }
        public string Produto { get; set; }
        public string Modalidade { get; set; }
        public int ConParcela { get; set; }
        public int ConNCAR { get; set; }
        public double ValorBrutoParcela { get; set; }
        public double TaxaAdm { get; set; }
        public string Autori { get; set; }
        public double ValorLiquidoParcela { get; set; }

        public ConciliationEx(int conT, int conEC, string aAAAMM, string terminal, DateTime dataVenda, DateTime hora, string nSU,
            string produto, string modalidade, int conParcela, int conNCAR, double valorBrutoParcela, double taxaAdm, string autori)
        {
            ConT = conT;
            ConEC = conEC;
            AAAAMM = aAAAMM;
            Terminal = terminal;
            DataVenda = dataVenda;
            Hora = hora;
            NSU = nSU;
            Produto = produto;
            Modalidade = modalidade;
            ConParcela = conParcela;
            ConNCAR = conNCAR;
            ValorBrutoParcela = valorBrutoParcela;
            TaxaAdm = taxaAdm;
            Autori = autori;
            ValorLiquidoParcela = (1 - taxaAdm / 100) * valorBrutoParcela;
        }
    }
}
