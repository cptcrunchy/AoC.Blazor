using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AoC.Blazor.Models;

namespace AoC.Blazor.Services
{
	public class Utilities
	{

		public static async Task CreatePuzzleFile(Puzzle puzzle)
		{
			var puzzleDirectory = $"{Directory.GetCurrentDirectory()}\\Data\\";
			await using var createPuzzleStream = File.Create($"{puzzleDirectory}{puzzle.Name}.json");
			await JsonSerializer.SerializeAsync(createPuzzleStream, puzzle);
			await createPuzzleStream.DisposeAsync();
		}

		public static Puzzle GetPuzzleInput(string puzzleName)
		{
			var puzzleDirectory = $"{Directory.GetCurrentDirectory()}\\Data\\";
			if (!CheckPuzzleExists(puzzleName)) return new Puzzle();
			var puzzleJson = File.ReadAllText($"{puzzleDirectory}{puzzleName}.json");
			var puzzle = JsonSerializer.Deserialize<Puzzle>(puzzleJson);
			return puzzle ?? new Puzzle();
			
		}

		public static bool CheckPuzzleExists(string puzzleName)
		{
			var puzzleDirectory = $"{Directory.GetCurrentDirectory()}\\Data\\";
			return File.Exists($"{puzzleDirectory}{puzzleName}.json");
		}

		public static bool CheckDayPageExists(int number)
		{
			var daysDirectory = $"{Directory.GetCurrentDirectory()}\\Pages\\Days\\";
			return File.Exists($"{daysDirectory}Day{number}.razor");
		}
	}
}
