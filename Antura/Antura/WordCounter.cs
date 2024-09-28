using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Antura
{
    public class WordCounter : IWordCounter
    {
        private readonly string[] validFileTypes = [".txt"]; 
        public int CountFileNamesInText(string filePath)
        {
            if (!validFileTypes.Contains(Path.GetExtension(filePath)))
            {
                throw new ArgumentException($"Valid file types are: {string.Join(string.Empty, validFileTypes)}");
            }

            var counter = 0;
            try
            {
                var file = File.Open(filePath, FileMode.Open);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath).ToLower();
                using var reader = new StreamReader(file);
                string line;
                
                while ((line = reader.ReadLine()?.ToLower()) != null)
                {
                    counter += Regex.Matches(line, fileNameWithoutExtension).Count;
                }                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException was thrown with exception message: {ex.Message}");
                throw;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException was thrown with exception message: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception was thrown with exception message: {ex.Message}");
                throw;
            }
            return counter;
        }
    }
}
