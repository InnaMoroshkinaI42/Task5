using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS1
{
    public class Employee : DataObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Заработная плата: {Salary.ToString("C")}, " +
                $"Дата приема на работу: {HireDate.ToString("yyyy.MM.dd")}";
        }

        public override bool Equals(object obj)
        {
            return isEquals(obj as DataObject);
        }

        public bool Equals(DataObject other) 
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is Employee employee)
            {
                return this.Name == employee.Name &&
                       this.Age == employee.Age &&
                       this.Salary == employee.Salary &&
                       this.HireDate == employee.HireDate;
            }

            return false;
        }

        public bool isEquals(string description)
        {
            var properties = description.Split(',');

            if (properties.Length != 5)
            {
                throw new ArgumentException("Неверное описание для объекта Employee.");
            }

            string name = properties[1].Trim('"');
            int age = int.Parse(properties[2]);
            decimal salary = decimal.Parse(properties[3], CultureInfo.InvariantCulture);
            DateTime hireDate = DateTime.ParseExact(properties[4].Trim(), "yyyy.MM.dd", CultureInfo.InvariantCulture);

            return this.Name == name && this.Age == age && this.Salary == salary && this.HireDate == hireDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Salary, HireDate);
        }
    }
}
