using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS1
{
    /// <summary>
    /// Фабрика для создания объектов данных на основе строкового описания.
    /// </summary>
    public class DataObjectFactory
    {
        /// <summary>Создает объект данных из заданного описания.</summary>
        /// <param name="description">Описание объекта, представленное в виде строки, где каждый элемент разделен запятой.</param>
        /// <returns>Созданный объект данных, который может быть экземпляром <see cref="CurrencyRate" />,
        /// <see cref="Employee" /> или <see cref="BankingOperations" /> в зависимости от типа, указанного в описании.</returns>
        /// <exception cref="System.ArgumentException">Недостаточно свойств для создания объекта</exception>
        /// <exception cref="System.ArgumentException">Неизвестный тип объекта: {objectType}</exception>

        public static DataObject CreateFromDescription(string description)
        {
            string[] properties = description.Split(',');
            if (properties.Length < 4)
            {
                throw new ArgumentException("Недостаточно свойств для создания объекта");
            }
            string objectType = properties[0].Trim('"');

            switch (objectType)
            {
                case "Currency":
                    return CreateCurrency(properties);
                case "Employee":
                    return CreateEmployee(properties);
                case "BankingOperation":
                    return new BancingOperations
                    {
                        AccountNumber = properties[1],
                        Amount = decimal.Parse(properties[2], CultureInfo.InvariantCulture),
                        Date = DateTime.ParseExact(properties[3], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                        Type = properties[4]
                    };
                default: throw new ArgumentException($"Неизвестный тип объекта: {objectType}");
            }
        }
        /// <summary>Создает объект курса валюты на основе предоставленных частей.</summary>
        /// <param name="parts">Массив строк, содержащий свойства для создания объекта курса валюты.
        /// Должен содержать 4 элемента: тип валюты (например, "Currency"),
        /// название валюты, курс и дата.</param>
        /// <returns>Созданный объект <see cref="CurrencyRate" />.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество свойств недостаточно или
        /// если имя валюты пустое или короче 3 символов.</exception>

        private static CurrencyRate CreateCurrency(string[] parts)
        {
            if (parts.Length != 4)
            {
                throw new ArgumentException("Недостаточно свойств для создания объекта курса валют");
            }

            string currencyName = parts[1].Trim().Trim('"');

            if (string.IsNullOrWhiteSpace(currencyName) || currencyName.Length < 3)
            {
                throw new ArgumentException("Имя валюты должно содержать не менее 3 символов и не может быть пустым.");
            }

            return new CurrencyRate
            {
                CurrencyName1 = currencyName,
                Rate = decimal.Parse(parts[2].Trim().Trim('"'), CultureInfo.InvariantCulture),
                Date = DateTime.Parse(parts[3].Trim().Trim('"'), CultureInfo.InvariantCulture)
            };

        }
        /// <summary>
        /// Создает объект сотрудника на основе предоставленных свойств.
        /// </summary>
        /// /// <param name="properties">Массив строк, содержащий свойства для создания объекта Employee.
        /// Должен содержать 5 элементов: тип сотрудника (например, "Employee"), имя, возраст, зарплату и дату приема на работу.</param>
        /// <returns>Созданный объект <see cref="Employee"/>.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество свойств недостаточно, если имя пустое,
        /// если возраст вне диапазона от 18 до 65 или если зарплата отрицательная, 
        /// или если дата имеет неверный формат.</exception>
        private static Employee CreateEmployee(string[] properties)
        {
            if (properties.Length != 5)
            {
                throw new ArgumentException("Недостаточно свойств для создания объекта Employee.");
            }

            string name = properties[1].Trim().Trim('"');
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя сотрудника не может быть пустым");
            }
            if (!decimal.TryParse(properties[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salary) || salary < 0)
            {
                throw new ArgumentException("Зарплата должна быть положительным числом");
            }
            if (!int.TryParse(properties[2].Trim(), out int age) || age < 18 || age > 65)
            {
                throw new ArgumentException("Возраст должен быть числом в диапазоне от 18 до 65.");
            }
            if (!DateTime.TryParseExact(properties[4].Trim(), "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hireDate))
            {
                throw new ArgumentException("Неверный формат даты. Ожидается формат 'yyyy.MM.dd'");
            }

            return new Employee
            {
                Name = name,
                Age = age,
                Salary = salary,
                HireDate = hireDate
            };
        }

    }
}