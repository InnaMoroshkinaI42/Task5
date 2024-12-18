using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS1
{
    /// <summary>Class BancingOperations.
    /// Implements the <see cref="PIS1.DataObject" /></summary>
    public class BancingOperations: DataObject
    {
        /// <summary>Gets or sets the account number.</summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"Банковский счет №{AccountNumber}, тип - {Type}, стоимость которого составляет:  {Amount.ToString("C")}, " +
                $"Дата: {Date.ToString("yyyy.MM.dd")}";
        }    
    }
}
