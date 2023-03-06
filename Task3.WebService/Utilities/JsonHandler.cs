using System.Text.Json;

namespace Task3.WebService.Utilities
{
    public class JsonHandler : IJsonHandler
    {
        public string LoadJsonFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new NullReferenceException();

            filePath = Path.GetFullPath(filePath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            return File.ReadAllText(filePath);
        }

        public T ReadJson<T>(string json) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                throw new FormatException();
            }
        }
    }
}
