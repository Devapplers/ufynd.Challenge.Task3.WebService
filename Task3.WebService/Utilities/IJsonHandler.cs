namespace Task3.WebService.Utilities
{
    public interface IJsonHandler
    {
        public string LoadJsonFile(string filePath);

        public T ReadJson<T>(string json) where T : class;
    }
}
