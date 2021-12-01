using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		public static async Task UpdatePuzzleFile(Puzzle puzzle)
		{
			var puzzleDirectory = $"{Directory.GetCurrentDirectory()}\\Data\\";
			var puzzleJson = await File.ReadAllTextAsync($"{puzzleDirectory}Day{puzzle.Day}.json");
			var previousPuzzle = JsonSerializer.Deserialize<Puzzle>(puzzleJson);
			if (previousPuzzle is not null)
			{
				previousPuzzle.SolutionA = puzzle.SolutionA;
				previousPuzzle.SolutionB = puzzle.SolutionB;
			}

			await File.WriteAllTextAsync($"{puzzleDirectory}{puzzle.Name}.json", JsonSerializer.Serialize(previousPuzzle));


		}

		public static List<Puzzle> GetPuzzles()
		{
			var puzzleDirectory = $"{Directory.GetCurrentDirectory()}\\Data\\";

			return (from day in Enumerable.Range(1, 25)
				where CheckPuzzleExists($"Day{day}")
				select File.ReadAllText($"{puzzleDirectory}Day{day}.json")
				into puzzleJson
				select JsonSerializer.Deserialize<Puzzle>(puzzleJson)).ToList();
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
