// See https://aka.ms/new-console-template for more information

using Antura;

if (args.Length > 0)
{
    string filePath = args[0];
    var wordCounter = new WordCounter();

	try
	{
        var nrOfFileNamesInText = wordCounter.CountFileNamesInText(filePath);
        Console.WriteLine("found " + nrOfFileNamesInText);
    }
	catch (Exception)
	{
        Console.WriteLine("Exception was thrown");
    }
    
    
}
else
{
    Console.WriteLine("No file path was provided.");
}

