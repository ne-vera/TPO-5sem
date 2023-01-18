using PageObjects;

namespace Lab10WPageObject
{
    public class Tests : BaseTest
    {
        [Test]
        public void ICanWin()
        {
            StartPastebinPage startPastebin = new(driver);
            startPastebin.SendTextToInputTextArea("Hello from WebDriver");
            startPastebin.ClickSelectExpiration();
            startPastebin.ClickBtn10Minutes();
            startPastebin.SendTextToTitle("helloweb");
            startPastebin.ClickBtnCreateNewPaste();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            NewPastebinPage newPastebin = new(driver);
            string textFromInput = newPastebin.GetFirstLine();
            Assert.That(textFromInput, Is.EqualTo("Hello from WebDriver"));
        }

        [Test]
        public void BringItOn()
        {
            StartPastebinPage pastebinPage = new(driver);
            pastebinPage.SendTextToInputTextArea("git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")\ngit push origin master --force");

            pastebinPage.ClickSelectSintaxHighlighting();
            pastebinPage.ClickBtnBash();

            pastebinPage.ClickSelectExpiration();
            pastebinPage.ClickBtn10Minutes();

            pastebinPage.SendTextToTitle("how to gain dominance among developers");

            pastebinPage.ClickBtnCreateNewPaste();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            NewPastebinPage newPastebin = new(driver);
            string pageTitle = newPastebin.GetTitle();
            string inputText = newPastebin.GetTextFromInput();

            Assert.That(pageTitle, Is.EqualTo("how to gain dominance among developers - Pastebin.com"));
            Assert.That(inputText, Is.EqualTo("git config --global user.name  \"New Sheriff in Town\"git reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")git push origin master --force"));
        }
    }
}