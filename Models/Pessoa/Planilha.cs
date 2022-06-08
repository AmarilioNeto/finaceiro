using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;

namespace projeto_financeiro.Models.Pessoa
{
    public class Planilha
    {
        //[Name("Cliente")]
        public string Cliente { get; set; }
       // [Name("Documento")]
        public string  Documento { get; set; }
       // [Name("Valor")]
        public float Valor { get; set; }
       // [Name("Vencto")]
        public string Vencto { get; set; }
       // [Name("VenctoCalc")]
        public string VenctoCalc { get; set; }
       // [Name("Dias")]
        public int Dias { get; set; }
       // [Name("Presente")]
        public float Presente { get; set; }
      //  [Name("idnfe")]
        public string  idnfe { get; set; }

       
    }
  
}
