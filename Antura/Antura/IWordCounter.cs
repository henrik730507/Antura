using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antura
{
    public interface IWordCounter
    {
        /// <summary>
        /// Counts the occurrences of the file name (without extension) in the specified text file.
        /// </summary>
        /// <param name="filePath">The path to the text file.</param>
        /// <returns>The count of occurrences of the file name in the text.</returns>
        int CountFileNamesInText(string filePath);
    }
}
