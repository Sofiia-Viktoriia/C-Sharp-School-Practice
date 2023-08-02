using PracticeProject;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "yupdate.log";
        int ratio = FindErrors(path);
        if (ratio > 0)
        {
            Console.WriteLine($"All entries / entries with errors: {ratio}");
        }
    }

    public static int FindErrors(string path)
    {
        string[] allRecords;
        string[] errorRecords;
        try
        {
            allRecords = ReadFile(path);
            errorRecords = FindErrorRecords(allRecords);
            WriteErrorRecordsToFile(errorRecords);
            CheckIfErrorRecordsAreCritical(errorRecords);
            return allRecords.Length / errorRecords.Length;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex}");
            return -1;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine($"There are no error entries in the file");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex}");
            return -1;
        }
    }

    public static void WriteErrorRecordsToFile(string[] records)
    {
        File.WriteAllLines("error.log", records);
    }

    public static string[] FindErrorRecords(string[] records)
    {
        Regex regex = new Regex(@"error", RegexOptions.IgnoreCase);
        return records.Where(record => regex.IsMatch(record)).ToArray();
    }

    public static string[] ReadFile(string path)
    {
        List<string> records = new List<string>();
        Regex enrtyRegex = new Regex(@"\d{2}:\d{2}:\d{2} .:");
        using (StreamReader streamReader = File.OpenText(path))
        {
            StringBuilder currentRecord = new StringBuilder();
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (enrtyRegex.IsMatch(line))
                {
                    if (currentRecord.Length > 0)
                    {
                        records.Add(currentRecord.ToString());
                        currentRecord.Clear();
                    }
                }
                currentRecord.Append(line);
            }

            if (currentRecord.Length > 0)
            {
                records.Add(currentRecord.ToString());
            }
        }
        return records.ToArray();
    }

    public static void CheckIfErrorRecordsAreCritical(string[] records)
    {
        foreach (string record in records)
        {
            try
            {
                if (record.Contains("CRITICAL ERROR"))
                {
                    Console.WriteLine(record);
                    throw new CriticalErrorException("Critical error found in the file.");
                }
            }
            catch (CriticalErrorException ex)
            {
                Console.WriteLine($"Critical Error: {ex}");
            }
        }
    }
}