using System;


namespace CardExtractTreatment.Entities
{
    class SafraPayEx
    {
        public int ExT { get; set; }
        public int ExEC { get; set; }
        public string AAAAMM { get; set; }
        public string Terminal { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime Hora { get; set; }
        public string NSU { get; set; }
        public string Produto { get; set; }
        public string Modalidade { get; set; }
        public int ExPL { get; set; }
        public int ExNCAR { get; set; }
        public double ValorBruto { get; set; }
        public double TaxaAdm { get; set; }
        public string Autori { get; set; }
        public double ValorLiquido { get; set; }

        public SafraPayEx(int exT, int exEC, string aAAAMM, string terminal, DateTime dataVenda, DateTime hora,
            string nSU, string produto, string modalidade, int exPL, int exNCAR, double valorBruto, double taxaAdm, string autori)
        {
            ExT = exT;
            ExEC = exEC;
            AAAAMM = aAAAMM;
            Terminal = terminal;
            DataVenda = dataVenda;
            Hora = hora;
            NSU = nSU;
            Produto = produto;
            Modalidade = modalidade;
            ExPL = exPL;
            ExNCAR = exNCAR;
            ValorBruto = valorBruto;
            TaxaAdm = taxaAdm;
            Autori = autori;
            ValorLiquido = (1 - taxaAdm / 100) * valorBruto;
        }


    }
}
