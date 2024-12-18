using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PIS1
{
    public class CurrencyRate: DataObject
    {
        public string CurrencyName1 { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"Название валюты 1:  {CurrencyName1} " +
                $"Курс:  {Rate}  Дата:  {Date.ToString("yyyy.MM.dd")}";
        }

    }
}
