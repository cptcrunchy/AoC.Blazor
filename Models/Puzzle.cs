using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC.Blazor.Models
{
	public class Puzzle
	{
		public Puzzle()
		{
			
		}
		public Puzzle(string name, int day, string input)
		{
			Name = name;
			Day = day;
			Input = input;
		}
		public string Name { get; set; }
		public int Day { get; set; }
		public string SolutionA { get; set; }
		public string SolutionB { get; set; }

		public string Input { get; set; }

	}
}
