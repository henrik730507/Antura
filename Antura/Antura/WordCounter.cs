using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                using StreamReader reader = new StreamReader(file);
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase))
                        counter++;
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
