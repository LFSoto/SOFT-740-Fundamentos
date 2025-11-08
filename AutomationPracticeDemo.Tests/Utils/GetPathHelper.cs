namespace AutomationPracticeDemo.Tests.Utils
{
    public class GetPathHelper
    {
        public string GetFilePathUpload(string fileName)
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../"+fileName+"";
            return Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        }
    }
}
