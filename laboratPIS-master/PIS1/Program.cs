using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PIS1
{
    class Program
    {
        private static List<DataObject> ReadObjectsFromFile(string fileName)
        {
            var objects = new List<DataObject>();
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            try
                            {
                                objects.Add(DataObjectFactory.CreateFromDescription(line));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при создании объекта из строки '{line}': {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            return objects;
        }
        private static void PrintObjects(IEnumerable<DataObject> objects)
        {
            foreach (var obj in objects)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void Main(string[] args)
        {
            var objects = ReadObjectsFromFile("objects.txt");
            PrintObjects(objects);
            Console.ReadKey();
        }
    }
}
