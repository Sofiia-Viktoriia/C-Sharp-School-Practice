using PracticeProject;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "..\\..\\..\\yupdate.log";
        int ratio = FindErrors(path);
        if (ratio > 0)
        {
            Console.WriteLine($"All entries / entries with errors: {ratio}");
        }
    }

    public static int FindErrors(string path)
    {
        string line = string.Empty;
        int allEntries = 0;
        int errorEntries = 0;
        Regex enrtyRegex = new Regex(@".*\d{2}:\d{2}:\d{2} [DIE]:.*$");
        Regex errorRegex = new Regex(@".*\d{2}:\d{2}:\d{2} [E]:.*$");
        StreamReader? streamReader = null;
        FileStream? fileStream = null;
        StreamWriter? streamWriter = null;
        try
        {
            streamReader = File.OpenText(path);
            fileStream = File.OpenWrite("..\\..\\..\\error.log");
            streamWriter = new StreamWriter(fileStream);

            while ((line = streamReader.ReadLine()) != null)
            {
                if (enrtyRegex.IsMatch(line))
                {
                    allEntries++;
                }
                if (errorRegex.IsMatch(line))
                {
                    errorEntries++;
                    streamWriter.WriteLine(line);
                    CheckIfCritical(line);
                }
            }
            return allEntries / errorEntries;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return -1;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine($"There are no error entries in the file");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            return -1;
        }
        finally
        {
            try
            {
                streamReader?.Close();
                streamWriter?.Close();
                fileStream?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while closing the file: {ex.Message}");
            }
        }
    }

    public static void CheckIfCritical(string line)
    {
        try
        {
            if (line.Contains("CRITICAL ERROR"))
            {
                Console.WriteLine(line);
                throw new CriticalErrorException("Critical error found in the file.");
            }
        }
        catch (CriticalErrorException ex)
        {
            Console.WriteLine($"Critical Error: {ex.Message}");
        }
    }
}