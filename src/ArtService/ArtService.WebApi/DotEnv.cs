namespace ArtService.WebApi
{
    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($".env file not found: {filePath}");

            foreach (var line in File.ReadLines(filePath))
            {
                var trimmedLine = line.Trim();

                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;

                int separatorIndex = trimmedLine.IndexOf('=');
                if (separatorIndex < 0)
                    continue;

                var key = trimmedLine.Substring(0, separatorIndex).Trim();
                var value = trimmedLine.Substring(separatorIndex + 1).Trim();

                if (string.IsNullOrEmpty(key))
                    continue;

                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }

}
