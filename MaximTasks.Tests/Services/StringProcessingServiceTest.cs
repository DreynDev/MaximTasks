using NUnit.Framework;
using Moq;
using MaximTasks.Services;
using MaximTasks.SortingAlgorithms;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MaximTasks.Tests
{
    public class StringProcessingServiceTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<RandomNumberGeneratorService> _mockRandomNumberGeneratorService;

        public StringProcessingServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockRandomNumberGeneratorService = new Mock<RandomNumberGeneratorService>();

            var appSettings = new Dictionary<string, string>
            {
                { "BlackList:0", "abc" } 
            };

            _mockConfiguration.Setup(c => c.GetSection("AppSettings")).Returns(
                new Mock<IConfigurationSection>().Object);
            _mockConfiguration.Setup(c => c["BlackList:0"]).Returns("abc");
        }

        [Test]
		[TestCase("dsgfsdgadsfsa", "quick")]
		[TestCase("hello", "tree")]
		[TestCase("world", "quick")]
        public void ProcessString_ValidInput_ReturnsCorrectResult(string input, string sortType)
        {
            var stringProcessingService = StringProcessingService.Instance;

            var result = Utility.ProcessString(input);  
            var longestVowelSubstring = Utility.GetLongestVowelSubstring(result); 
            var sortedString = QuickSortClass.SortedString(result);  

            var resultObj = stringProcessingService.ProcessString(input, sortType);

            dynamic dynamicResult = resultObj;
			
			var properties = dynamicResult.GetType().GetProperties();
			foreach (var property in properties)
			{
				if (property.Name == "message")
				{
					Assert.AreEqual("Результат успешно обработан", property.GetValue(dynamicResult));
				}
				else if (property.Name == "result")
				{
					Assert.AreEqual(result, property.GetValue(dynamicResult));
				}
				else if (property.Name == "longestVowelSubstring")
				{
					Assert.AreEqual(longestVowelSubstring, property.GetValue(dynamicResult));
				}
				else if (property.Name == "sortedString")
				{
					Assert.AreEqual(sortedString, property.GetValue(dynamicResult));
				}
			}
        }

        [Test]
		[TestCase(null)]
		[TestCase("")]
        public void ProcessString_EmptyInput_ThrowsArgumentException(string input)
        {
            var sortType = "quick";
            var stringProcessingService = StringProcessingService.Instance;

            var exception = Assert.Throws<ArgumentException>(() => stringProcessingService.ProcessString(input, sortType));
			Assert.That(exception.Message, Is.EqualTo("Ваша строка пустая"));
        }

        [Test]
		[TestCase("abc")]
		[TestCase("invalid")]
		[TestCase("t")]
        public void ProcessString_InvalidSortType_ThrowsArgumentException(string sortType)
        {
            var input = "apple";
            var stringProcessingService = StringProcessingService.Instance;

            var exception = Assert.Throws<ArgumentException>(() => stringProcessingService.ProcessString(input, sortType));
			Assert.That(exception.Message, Is.EqualTo("Некорректный выбор"));
        }

        [Test]
		[TestCase("abc")]
		[TestCase("edf")]
		[TestCase("rofl")]
        public void ProcessString_InputInBlackList_ThrowsArgumentException(string input)
        {
            var sortType = "quick";
            var stringProcessingService = StringProcessingService.Instance;

            var exception = Assert.Throws<ArgumentException>(() => stringProcessingService.ProcessString(input, sortType));
			Assert.That(exception.Message, Is.EqualTo($"Ошибка: слово '{input}' входит в черный список."));
        }
		
		[Test]
		[TestCase("abfdsf@sd")]
		[TestCase("abf/dsfsd")]
		[TestCase("abfds13fsd")]
        public void ProcessString_InvalidCharactersInInput_ThrowsArgumentException(string input)
        {
			var sortType = "quick";
            var stringProcessingService = StringProcessingService.Instance;

            var exception = Assert.Throws<ArgumentException>(() => stringProcessingService.ProcessString(input, sortType));
			Assert.IsTrue(exception.Message.Contains("Ошибка: были введены неподходящие символы"));
        }
    }
}
