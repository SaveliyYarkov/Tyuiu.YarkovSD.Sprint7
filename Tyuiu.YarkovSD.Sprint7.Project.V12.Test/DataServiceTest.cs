using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.YarkovSD.Sprint7.Project.V12.Lib;

namespace Tyuiu.YarkovSD.Sprint7.Project.V12.Test
{
    [TestClass]
    public class DataServiceYSDTests
    {
        private DataServiceYSD dataService;
        private List<DataServiceYSD.ComputerYSD> testComputers;

        [TestInitialize]
        public void Initialize()
        {
            dataService = new DataServiceYSD();
            testComputers = CreateTestData();
        }

        private List<DataServiceYSD.ComputerYSD> CreateTestData()
        {
            var computers = new List<DataServiceYSD.ComputerYSD>();

            var comp1 = new DataServiceYSD.ComputerYSD();
            comp1.Model = "Inspiron 15";
            comp1.Manufacturer = "Dell";
            comp1.Processor = "Intel i5";
            comp1.ClockSpeed = 2.5;
            comp1.RAM = 8;
            comp1.HDD = 512;
            comp1.Price = 45000;
            comp1.ReleaseDate = new DateTime(2023, 1, 15);
            computers.Add(comp1);

            var comp2 = new DataServiceYSD.ComputerYSD();
            comp2.Model = "Pavilion 14";
            comp2.Manufacturer = "HP";
            comp2.Processor = "AMD Ryzen 5";
            comp2.ClockSpeed = 3.2;
            comp2.RAM = 16;
            comp2.HDD = 1000;
            comp2.Price = 55000;
            comp2.ReleaseDate = new DateTime(2023, 3, 20);
            computers.Add(comp2);

            var comp3 = new DataServiceYSD.ComputerYSD();
            comp3.Model = "ThinkPad X1";
            comp3.Manufacturer = "Lenovo";
            comp3.Processor = "Intel i7";
            comp3.ClockSpeed = 3.0;
            comp3.RAM = 16;
            comp3.HDD = 512;
            comp3.Price = 75000;
            comp3.ReleaseDate = new DateTime(2023, 2, 10);
            computers.Add(comp3);

            return computers;
        }

        [TestMethod]
        public void SaveAndLoadComputersFromCsv_ValidData_ReturnsCorrectCount()
        {
            // Arrange
            string testFilePath = "test_computers.csv";

            try
            {
                // Act
                dataService.SaveComputersToCsv(testFilePath, testComputers);
                var loadedComputers = dataService.LoadComputersFromCsv(testFilePath);

                // Assert
                Assert.AreEqual(testComputers.Count, loadedComputers.Count);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public void CalculateStatistics_ValidData_ReturnsCorrectValues()
        {
            // Arrange & Act
            var stats = dataService.CalculateStatistics(testComputers);

            // Assert
            Assert.AreEqual(3, stats.TotalComputers);
            Assert.AreEqual(175000, stats.TotalPrice); // 45000 + 55000 + 75000
            Assert.AreEqual(45000, stats.MinPrice);
            Assert.AreEqual(75000, stats.MaxPrice);
            Assert.AreEqual(13.33, stats.AverageRAM, 0.01); // (8+16+16)/3
            Assert.AreEqual(674.67, stats.AverageHDD, 0.01); // (512+1000+512)/3
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateStatistics_EmptyList_ThrowsException()
        {
            // Arrange
            var emptyList = new List<DataServiceYSD.ComputerYSD>();

            // Act & Assert
            dataService.CalculateStatistics(emptyList);
        }

        [TestMethod]
        public void LoadComputersFromCsv_FileNotExists_ThrowsFileNotFoundException()
        {
            // Arrange
            string nonExistentFile = "non_existent_file.csv";

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() =>
                dataService.LoadComputersFromCsv(nonExistentFile));
        }

        [TestMethod]
        public void SaveComputersToCsv_EmptyList_ThrowsArgumentException()
        {
            // Arrange
            string testFilePath = "empty_test.csv";
            var emptyList = new List<DataServiceYSD.ComputerYSD>();

            try
            {
                // Act & Assert
                Assert.ThrowsException<ArgumentException>(() =>
                    dataService.SaveComputersToCsv(testFilePath, emptyList));
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public void ComputerToString_ValidComputer_ReturnsCorrectString()
        {
            // Arrange
            var computer = testComputers[0];

            // Act
            string result = computer.ToString();

            // Assert
            StringAssert.Contains(result, "Dell");
            StringAssert.Contains(result, "Inspiron 15");
            StringAssert.Contains(result, "Intel i5");
        }

        [TestMethod]
        public void LoadComputersFromCsv_InvalidFormat_ReturnsDemoData()
        {
            // Arrange
            string invalidFile = "invalid_format.csv";
            File.WriteAllText(invalidFile, "invalid,data,here");

            try
            {
                // Act
                var computers = dataService.LoadComputersFromCsv(invalidFile);

                // Assert - должен вернуть демо-данные, так как файл некорректный
                Assert.IsTrue(computers.Count > 0);
            }
            finally
            {
                // Cleanup
                if (File.Exists(invalidFile))
                {
                    File.Delete(invalidFile);
                }
            }
        }

        [TestMethod]
        public void ParseDouble_ValidString_ReturnsCorrectValue()
        {
            // Этот тест проверяет внутренний метод ParseDouble через публичные методы

            // Arrange
            string testFile = "parse_test.csv";
            string csvContent = "Model1;Manufacturer1;Processor1;2,5;8;512;30000;2023-01-01\n" +
                               "Model2;Manufacturer2;Processor2;3.2;16;1000;50000;2023-02-01";
            File.WriteAllText(testFile, csvContent);

            try
            {
                // Act
                var computers = dataService.LoadComputersFromCsv(testFile);

                // Assert
                Assert.AreEqual(2, computers.Count);
                Assert.AreEqual(2.5, computers[0].ClockSpeed, 0.01);
                Assert.AreEqual(3.2, computers[1].ClockSpeed, 0.01);
            }
            finally
            {
                if (File.Exists(testFile))
                {
                    File.Delete(testFile);
                }
            }
        }

        [TestMethod]
        public void ParseDate_DifferentFormats_ReturnsCorrectDate()
        {
            // Arrange
            string testFile = "date_test.csv";
            string csvContent = "Model;Manufacturer;Processor;2.5;8;512;30000;2023-01-15\n" +
                               "Model;Manufacturer;Processor;2.5;8;512;30000;15.01.2023\n" +
                               "Model;Manufacturer;Processor;2.5;8;512;30000;01/15/2023";
            File.WriteAllText(testFile, csvContent);

            try
            {
                // Act
                var computers = dataService.LoadComputersFromCsv(testFile);

                // Assert
                Assert.AreEqual(3, computers.Count);
                // Все даты должны быть корректно распарсены
                foreach (var computer in computers)
                {
                    Assert.AreEqual(2023, computer.ReleaseDate.Year);
                    Assert.AreEqual(1, computer.ReleaseDate.Month);
                    Assert.AreEqual(15, computer.ReleaseDate.Day);
                }
            }
            finally
            {
                if (File.Exists(testFile))
                {
                    File.Delete(testFile);
                }
            }
        }
    }
}
