using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Antura
{
    public class WordCounter : IWordCounter
    {
        public int CountFileNamesInText(string filePath)
        {
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException message: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
                throw;
            }
            return counter;
        }
    }
}
