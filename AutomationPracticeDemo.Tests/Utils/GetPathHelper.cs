namespace AutomationPracticeDemo.Tests.Utils
{
    public class GetPathHelper
    {
        public string GetFilePathScreenShots()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../Screenshots/";
            string fullFilePath = Path.Combine(baseDirectory, relativePath);

            if (!Directory.Exists(fullFilePath))
            {
                Directory.CreateDirectory(fullFilePath);
            }
            return fullFilePath;
        }

        public string GetFilePathUpload()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../capybara.png";
            return Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        }
    }
}
