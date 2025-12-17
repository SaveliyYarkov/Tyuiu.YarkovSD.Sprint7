using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tyuiu.YarkovSD.Sprint7.Project.V12.Lib
{
    public class DataServiceYSD
    {
        public class ComputerYSD
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Processor { get; set; }
            public double ClockSpeed { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public decimal Price { get; set; }
            public DateTime ReleaseDate { get; set; }

            public override string ToString()
            {
                return $"{Manufacturer} {Model} - {Processor} {ClockSpeed}GHz, {RAM}GB RAM, {HDD}GB HDD, {Price:C}";
            }
        }

        public class StatisticsYSD
        {
            public decimal TotalPrice { get; set; }
            public decimal AveragePrice { get; set; }
            public decimal MinPrice { get; set; }
            public decimal MaxPrice { get; set; }
            public double AverageRAM { get; set; }
            public double AverageHDD { get; set; }
            public double AverageClockSpeed { get; set; }
            public int TotalComputers { get; set; }
            public Dictionary<string, int> ManufacturerDistribution { get; set; }
            public Dictionary<string, int> ProcessorDistribution { get; set; }
        }

        public List<ComputerYSD> LoadComputersFromCsv(string filePath)
        {
            List<ComputerYSD> computers = new List<ComputerYSD>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не найден: {filePath}");
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                int startIndex = 0;
                if (lines.Length > 0 && (lines[0].ToLower().Contains("model") || lines[0].ToLower().Contains("модель")))
                {
                    startIndex = 1;
                }

                for (int i = startIndex; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] parts = line.Split(';');

                    if (parts.Length < 8)
                    {
                        parts = line.Split(',');
                    }

                    if (parts.Length >= 8)
                    {
                        try
                        {
                            ComputerYSD computer = new ComputerYSD();
                            computer.Model = parts[0].Trim();
                            computer.Manufacturer = parts[1].Trim();
                            computer.Processor = parts[2].Trim();
                            computer.ClockSpeed = ParseDouble(parts[3]);
                            computer.RAM = ParseInt(parts[4]);
                            computer.HDD = ParseInt(parts[5]);
                            computer.Price = ParseDecimal(parts[6]);
                            computer.ReleaseDate = ParseDate(parts[7]);

                            computers.Add(computer);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }

                if (computers.Count == 0)
                {
                    computers = GenerateDemoData();
                }

                return computers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при чтении файла: {ex.Message}", ex);
            }
        }

        public void SaveComputersToCsv(string filePath, List<ComputerYSD> computers)
        {
            if (computers == null || computers.Count == 0)
            {
                throw new ArgumentException("Список компьютеров пуст");
            }

            try
            {
                List<string> lines = new List<string>();
                lines.Add("Model;Manufacturer;Processor;ClockSpeed;RAM;HDD;Price;ReleaseDate");

                foreach (var computer in computers)
                {
                    string line = $"{computer.Model};{computer.Manufacturer};{computer.Processor};" +
                                 $"{computer.ClockSpeed.ToString(CultureInfo.InvariantCulture)};{computer.RAM};{computer.HDD};" +
                                 $"{computer.Price.ToString(CultureInfo.InvariantCulture)};{computer.ReleaseDate:yyyy-MM-dd}";
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении файла: {ex.Message}", ex);
            }
        }

        public StatisticsYSD CalculateStatistics(List<ComputerYSD> computers)
        {
            if (computers == null || computers.Count == 0)
            {
                throw new ArgumentException("Список компьютеров пуст");
            }

            StatisticsYSD stats = new StatisticsYSD();
            stats.TotalComputers = computers.Count;
            stats.TotalPrice = computers.Sum(c => c.Price);
            stats.AveragePrice = computers.Average(c => c.Price);
            stats.MinPrice = computers.Min(c => c.Price);
            stats.MaxPrice = computers.Max(c => c.Price);
            stats.AverageRAM = computers.Average(c => c.RAM);
            stats.AverageHDD = computers.Average(c => c.HDD);
            stats.AverageClockSpeed = computers.Average(c => c.ClockSpeed);
            stats.ManufacturerDistribution = computers
                .GroupBy(c => c.Manufacturer)
                .ToDictionary(g => g.Key, g => g.Count());
            stats.ProcessorDistribution = computers
                .GroupBy(c => c.Processor)
                .ToDictionary(g => g.Key, g => g.Count());

            return stats;
        }

        private double ParseDouble(string value)
        {
            if (double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                return result;

            if (double.TryParse(value, out result))
                return result;

            return 0;
        }

        private int ParseInt(string value)
        {
            if (int.TryParse(value, out int result))
                return result;

            return 0;
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            if (decimal.TryParse(value, out result))
                return result;

            return 0;
        }

        private DateTime ParseDate(string value)
        {
            string[] dateFormats = {
                "yyyy-MM-dd", "dd.MM.yyyy", "MM/dd/yyyy",
                "dd-MM-yyyy", "yyyy/MM/dd"
            };

            if (DateTime.TryParseExact(value, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;

            if (DateTime.TryParse(value, out result))
                return result;

            return DateTime.Now;
        }

        private List<ComputerYSD> GenerateDemoData()
        {
            List<ComputerYSD> demoData = new List<ComputerYSD>();

            ComputerYSD comp1 = new ComputerYSD();
            comp1.Model = "Inspiron 15";
            comp1.Manufacturer = "Dell";
            comp1.Processor = "Intel Core i5";
            comp1.ClockSpeed = 2.5;
            comp1.RAM = 8;
            comp1.HDD = 512;
            comp1.Price = 45000;
            comp1.ReleaseDate = new DateTime(2023, 1, 15);
            demoData.Add(comp1);

            ComputerYSD comp2 = new ComputerYSD();
            comp2.Model = "Pavilion 14";
            comp2.Manufacturer = "HP";
            comp2.Processor = "AMD Ryzen 5";
            comp2.ClockSpeed = 3.2;
            comp2.RAM = 16;
            comp2.HDD = 1000;
            comp2.Price = 55000;
            comp2.ReleaseDate = new DateTime(2023, 3, 20);
            demoData.Add(comp2);

            ComputerYSD comp3 = new ComputerYSD();
            comp3.Model = "ThinkPad X1";
            comp3.Manufacturer = "Lenovo";
            comp3.Processor = "Intel Core i7";
            comp3.ClockSpeed = 3.0;
            comp3.RAM = 16;
            comp3.HDD = 512;
            comp3.Price = 75000;
            comp3.ReleaseDate = new DateTime(2023, 2, 10);
            demoData.Add(comp3);

            ComputerYSD comp4 = new ComputerYSD();
            comp4.Model = "MacBook Pro";
            comp4.Manufacturer = "Apple";
            comp4.Processor = "Apple M2";
            comp4.ClockSpeed = 3.5;
            comp4.RAM = 16;
            comp4.HDD = 512;
            comp4.Price = 120000;
            comp4.ReleaseDate = new DateTime(2023, 6, 5);
            demoData.Add(comp4);

            ComputerYSD comp5 = new ComputerYSD();
            comp5.Model = "ZenBook 14";
            comp5.Manufacturer = "ASUS";
            comp5.Processor = "Intel Core i5";
            comp5.ClockSpeed = 2.8;
            comp5.RAM = 8;
            comp5.HDD = 256;
            comp5.Price = 48000;
            comp5.ReleaseDate = new DateTime(2023, 4, 12);
            demoData.Add(comp5);

            return demoData;
        }
    }
}