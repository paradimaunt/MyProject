using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

namespace UnitTestProject
{
    public class Tests
    {
        private IWebDriver driver;


        private readonly By _numericField = By.XPath("//input[@id= 'amount']");//HomePage
        private readonly By _checkingiForThePresence = By.XPath("//input[@id='generate']");//HomePage
        private readonly By _checkingResult = By.XPath("//div[@id='lipsum']//p");//SearchResultPage
        private readonly By _bytesButton = By.XPath("//label[@for='bytes']");//HomePage
        private readonly By _changeLanguageToRussianButton = By.XPath("//a[@class='ru']");//HomePage
        private readonly By _checkingThePresenceOfAWordInAParagraph = By.XPath("//div[@id='Panes']//p[contains(text(), 'это текст')]");//SearchResultPage
        private readonly By _checkingThePresenceOfARowInAParagraph = By.XPath("//div[@id='lipsum']//p[contains(text(), 'Lorem ipsum')]");//SearchResultPage
        private readonly By _uncheckCkeckbox = By.XPath("//input[@id='start']");//HomePage
        private readonly By _wordsButton = By.XPath("//label[@for= 'words']");//HomePage
        
        

        [Test]
        public void SearchTextByParagraph()
        {
            IWebElement changeLanguageToRussianButton = driver.FindElement(_changeLanguageToRussianButton);
            changeLanguageToRussianButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement checkingThePresenceOfAWordInAParagraph = driver.FindElement(_checkingThePresenceOfAWordInAParagraph);
            string elementText = checkingThePresenceOfAWordInAParagraph.Text;
            Assert.IsTrue(elementText.Contains("Lorem Ipsum - это текст-\"рыба\""));

        }
        [Test]
        public void CheckingForTextByDefault()
        {
            IWebElement checkingiForThePresence = driver.FindElement(_checkingiForThePresence);
            checkingiForThePresence.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement checkingThePresenceOfARowInAParagraph = driver.FindElement(_checkingThePresenceOfARowInAParagraph);
            string elementText = checkingThePresenceOfARowInAParagraph.Text;
            Assert.IsTrue(elementText.Contains("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
        }
        [Test]
        public void Test3()
        {
            InputNumbersInTheFieldWodrs(10);
        }
        [Test]
        public void Test4()
        {
            InputNumbersInTheFieldWodrs(-1);
        }
        [Test]
        public void Test5()
        {
            InputNumbersInTheFieldWodrs(0);
        }
        [Test]
        public void Test6()
        {
            InputNumbersInTheFieldWodrs(5);
        }
        [Test]
        public void Test7()
        {
            InputNumbersInTheFieldWodrs(20);
        }
        [Test]
        public void Test8()
        {
            InputNumbersInTheFieldBytes(20);
        }
        [Test]
        public void Test9()
        {
            InputNumbersInTheFieldBytes(0);
        }
        [Test]
        public void Test10()
        {
            InputNumbersInTheFieldBytes(-5);
        }
        [Test]
        public void TestVerifyTheCheckbox()
        {
            IWebElement uncheckCkeckbox = driver.FindElement(_uncheckCkeckbox);
            uncheckCkeckbox.Click();
            IWebElement checkingiForThePresence = driver.FindElement(_checkingiForThePresence);
            checkingiForThePresence.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement CheckTheAbsenceOfALineInTheParagraph = driver.FindElement(_checkingResult);
            string elementText = CheckTheAbsenceOfALineInTheParagraph.Text;
            Assert.IsFalse(elementText.Contains("Lorem ipsum"));
        }
        [Test]
        public void CheckTheProbabilityOfTextAppearance()
        {
            IWebElement checkingiForThePresence = driver.FindElement(_checkingiForThePresence);
            checkingiForThePresence.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string text = driver.FindElement(_checkingResult).Text;
            string wordInParagraph = "lorem";
            List<string> paragraphs = text.Split(new string[] { "\n\r" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var checkForMatches = from paragraph in paragraphs
                                  where paragraph.ToLowerInvariant().Contains(wordInParagraph) == true
                                  select paragraph;
            int paragraphCount = checkForMatches.Count();
            int expected = 3;
            Assert.AreEqual(expected, paragraphCount);
        }
        public void InputNumbersInTheFieldWodrs(int numberOfWords)
        {

            IWebElement wordsButton = driver.FindElement(_wordsButton);
            wordsButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement numericField = driver.FindElement(_numericField);
            numericField.Click();
            numericField.Clear();
            numericField.SendKeys(numberOfWords.ToString());
            IWebElement checkingiForThePresence = driver.FindElement(_checkingiForThePresence);
            checkingiForThePresence.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement checkingWords = driver.FindElement(_checkingResult);
            string serchResult = checkingWords.Text;
            string[] arr = serchResult.Split(" ");
            Assert.AreEqual(numberOfWords, arr.Length, "Incorect Input");

        }
        public void InputNumbersInTheFieldBytes(int numberOfBytes)
        {
            IWebElement bytesButton = driver.FindElement(_bytesButton);
            bytesButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement numericField = driver.FindElement(_numericField);
            numericField.Click();
            numericField.Clear();
            numericField.SendKeys(numberOfBytes.ToString());
            IWebElement checkingiForThePresence = driver.FindElement(_checkingiForThePresence);
            checkingiForThePresence.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement checkingBytesResult = driver.FindElement(_checkingResult);
            int countSymbpls = checkingBytesResult.Text.ToCharArray().Length;
            Assert.AreEqual(numberOfBytes, countSymbpls, "Incorect Input");

        }
    }
}