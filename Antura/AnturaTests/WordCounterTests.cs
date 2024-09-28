using System;
using System.Dynamic;
using System.IO;
using Antura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class WordCounterTests
{
    private WordCounter _wordCounter;
    private string _testFilePath;

    [TestInitialize]
    public void Setup()
    {
        _wordCounter = new WordCounter();
        _testFilePath = "test.txt";
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }

    [TestMethod]
    public void CountFileNamesInText_FileExists_ReturnsCorrectCount()
    {
        // Arrange
        _testFilePath = "test.txt";
        var fileName = Path.GetFileNameWithoutExtension(_testFilePath);
        File.WriteAllText(_testFilePath,
        $"This is a {fileName}ing file. {fileName} appears here.\n" +
        $"{fileName} appears again on a new line.\n" +
        $"Nothing to see here.\n" +
        $"{fileName} should be counted again!");

        // Act
        var result = _wordCounter.CountFileNamesInText(_testFilePath);

        // Assert
        Assert.AreEqual(4, result, $"Expected 4, but actual was {result}");
    }

    [TestMethod]
    public void CountFileNamesInText_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Arrange
        var filePath = "nonexistent.txt";

        // Act & Assert
        Assert.ThrowsException<FileNotFoundException>(() => _wordCounter.CountFileNamesInText(filePath));
    }

    [TestMethod]
    public void CountFileNamesInText_FileTypeNotValid_ThrowsArgumentException()
    {
        // Arrange
        var filePath = "nonexistent.rtf";

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => _wordCounter.CountFileNamesInText(filePath));
    }

    [TestMethod]
    public void CountFileNamesInText_CaseInsensitiveCount_ReturnsCorrectCount()
    {
        // Arrange
        _testFilePath = "test.txt";
        var fileName = Path.GetFileNameWithoutExtension(_testFilePath);
        File.WriteAllText(_testFilePath, $"This is a {fileName} file. {fileName.ToUpper()} appears here. {fileName.ToLower()} again.");

        // Act
        var result = _wordCounter.CountFileNamesInText(_testFilePath);

        // Assert
        Assert.AreEqual(3, result, $"Expected 3, but actual was {result}");
    }

    [TestMethod]
    public void CountFileNamesInText_EmptyFile_ReturnsZero()
    {
        // Arrange
        _testFilePath = "empty.txt";
        File.WriteAllText(_testFilePath, string.Empty);

        // Act
        var result = _wordCounter.CountFileNamesInText(_testFilePath);

        // Assert
        Assert.AreEqual(0, result, $"Expected 0, but actual was {result}");
    }
}
