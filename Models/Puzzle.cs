namespace AoC.Blazor.Models
{
	public class Puzzle
	{
		public Puzzle()
		{
			
		}
		public Puzzle(string name, int day, bool isPractice, string input)
		{
			Name = name;
			Day = day;
			IsPractice = isPractice;
			Input = input;
		}
		public string Name { get; set; }
		public int Day { get; set; }
		public string SolutionA { get; set; }
		public string SolutionB { get; set; }
		public bool IsPractice { get; set; }
		public string Input { get; set; }
		

	}
}
