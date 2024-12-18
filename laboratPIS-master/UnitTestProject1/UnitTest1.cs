using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIS1;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
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

        [TestMethod]
        public void CreateFromDescription_Employee4()
        {
            var description = "Employee,\"Морошкина Инна\",35,3000.00,2018.01.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.AreEqual(3000.00m, result.Salary, "Неверная зарплата");
        }

        [TestMethod]
        public void CreateFromDescription_Employee5()
        {
            var description = "Employee,\"Морошкина Инна\",35,50000.00,2021.06.01";
            var result = DataObjectFactory.CreateFromDescription(description) as Employee;

            Assert.AreEqual(new DateTime(2021, 6, 1), result.HireDate, "Неверная дата приема на работу");
        }

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

        [TestMethod]
        public void CreateFromDescription_Excep()
        {
            var description = "\"Currency\", \"USD\"";

            var ex = Assert.ThrowsException<ArgumentException>(() => DataObjectFactory.CreateFromDescription(description));
            Assert.AreEqual("Недостаточно свойств для создания объекта", ex.Message, "Сообщение об ошибке должно быть корректным");
        }

    }
}