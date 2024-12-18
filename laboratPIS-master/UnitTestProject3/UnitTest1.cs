using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIS1;
using System;

namespace UnitTestProject3
{
    /// <summary>Defines test class UnitTest1.</summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /// <summary>Defines the test method CreateFromDescription_CreatesCurrencyRate.</summary>
        [TestMethod]
        public void CreateFromDescription_CreatesCurrencyRate()
        {
           string description = "\"Currency\",\"USD\",\"1.0\",\"2023-01-01\"";
           var result = DataObjectFactory.CreateFromDescription(description);

           var currencyRate = (CurrencyRate)result;
            Assert.AreEqual("USD", currencyRate.CurrencyName1);
            Assert.AreEqual(1.0m, currencyRate.Rate);
            Assert.AreEqual(new DateTime(2023, 1, 1), currencyRate.Date);
        }

        /// <summary>Defines the test method CreateFromDescription_Excep.</summary>
        [TestMethod]
        public void CreateFromDescription_Excep()
        {
            var description = "\"Currency\", \"USD\"";

            var ex = Assert.ThrowsException<ArgumentException>(() => DataObjectFactory.CreateFromDescription(description));
            Assert.AreEqual("Недостаточно свойств для создания объекта", ex.Message, "Сообщение об ошибке должно быть корректным");
        }
        [TestMethod]
        public void CreateFromDescription_CurrencyRate()
        {
            var description = "Currency,\"USD\",87.54,2023.04.15";
            var result = DataObjectFactory.CreateFromDescription(description) as CurrencyRate;

            Assert.IsNotNull(result, "Результат должен быть не null");
            Assert.AreEqual("USD", result.CurrencyName1, "Неверное имя валюты");
            Assert.AreEqual(87.54m, result.Rate, "Неверный курс валюты");
            Assert.AreEqual(new DateTime(2023, 04, 15), result.Date, "Неверная дата");
        }
        [TestMethod]
        public void CreateFromDescription_Employee1()
        {
            var description = "Employee,\"Морошкина Инна\",35,50000.00,2018.01.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.IsNotNull(result, "Результат должен быть не null");
        }

        [TestMethod]
        public void CreateFromDescription_Employee2()
        {
            var description = "Employee,\"Иван Иванов\",35,50000.00,2018.01.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.AreEqual("Иван Иванов", result.Name, "Неверное имя сотрудника");
        }

        [TestMethod]
        public void CreateFromDescription_Employee3()
        {
            var description = "Employee,\"Морошкина Инна\",30,50000.00,2018.01.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.AreEqual(30, result.Age, "Неверный возраст");
        }
        /// <summary>Defines the test method CreateFromDescription_Employee4.</summary>
        [TestMethod]
        public void CreateFromDescription_Employee4()
        {
            var description = "Employee,\"Морошкина Инна\",35,3000.00,2018.01.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            
            bool areEqual = result.isEquals(description);
            Assert.IsTrue(areEqual, "Полученный объект Employee не совпадает с ожидаемым.");
        }

        /// <summary>Defines the test method CreateFromDescription_Employee5.</summary>
        [TestMethod]
        public void CreateFromDescription_Employee5()
        {
            var description = "Employee,\"Морошкина Инна\",35,50000.00,2021.06.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.AreEqual(new DateTime(2021, 6, 1), result.HireDate, "Неверная дата приема на работу");
        }

        /// <summary>Defines the test method CreateFromDescription_BankingOperation.</summary>
        [TestMethod]
        public void CreateFromDescription_BankingOperation()
        {
            var description = "BankingOperation,123456789,1500.50,2023.10.15,Deposit";
            var result = DataObjectFactory.CreateFromDescription(description) as BancingOperations;

            Assert.IsNotNull(result, "Результат должен быть не null");
            Assert.AreEqual("123456789", result.AccountNumber, "Неверный номер счета");
            Assert.AreEqual(1500.50m, result.Amount, "Неверная сумма операции");
            Assert.AreEqual(new DateTime(2023, 10, 15), result.Date, "Неверная дата операции");
            Assert.AreEqual("Deposit", result.Type, "Неверный тип операции");
        }
    }
}
