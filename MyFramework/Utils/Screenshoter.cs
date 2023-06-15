using OpenQA.Selenium;

namespace MyFramework.Utils
{
    public static class Screenshoter
    {
        public static void Capture(IWebDriver driver, string screenshotDirectory, string screenshotName)
        {            
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{screenshotName}_{timestamp}.png";
            string filePath = Path.Combine(screenshotDirectory, fileName);
            
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }
    }
}
