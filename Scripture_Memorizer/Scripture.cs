using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class Scripture
{
	//private string _fileName = "scripture_list.csv";
	//private string[] _scripture; //= System.IO.File.ReadAllLines("scripture_list.csv");
	private List<VerseData> _scripture;

	public Scripture(string filePath)
	{
		Load(filePath);
	}

	private void Load(string filePath)
	{
		try
		{
			//_scripture = System.IO.File.ReadAllLines(filePath);
			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				_scripture = csv.GetRecords<VerseData>().ToList();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Error loading the CSV file: " + e.Message);
			//_scripture = new string[0]; //Set to empty if there is an error.
			_scripture = new List<VerseData>();
		}
	}

	public string Verse()
    {
		Random random = new();
		int index = random.Next(0, _scripture.Count);
		return $"{_scripture[index].Reference}\n{_scripture[index].Verse}\n";

		// foreach (var verseData in _scripture)
		// {
		// 	Console.WriteLine($"{verseData.Reference}\n{verseData.Verse}\n");
		// }

        // foreach (string line in _scripture)
        // {
        //     string[] parts = line.Split(",");

        //     if (parts.Length >= 2)
        //     {
        //         string reference = parts[0];
        //         string verse = parts[1];
        //         Console.WriteLine($"{reference}\n{verse}\n");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid CSV format for line: " + line);
        //     }
        // }
    }
}