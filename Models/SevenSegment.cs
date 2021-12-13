using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Blazor.Models
{
	public class SevenSegment
	{
		public string One { get; set; }
		public string Three { get; set; }
		public string Four { get; set; }
		public string Six { get; set; }
		public string Seven { get; set; }
		public string Eight { get; set; }
		public string Nine { get; set; }

		private List<string> CodesOfSix = new ();
		private List<string> CodesOfFive = new ();
		public string[] Segments = new string[7];
		public string[] Codes = new string[10];
		
		public SevenSegment(List<string> signals)
		{
			foreach (var signal in signals)
			{
				switch (signal.Length)
				{
					case 2:
						One = signal;
						break;
					case 3:
						Seven = signal;
						break;
					case 4:
						Four = signal;
						break;
					case 7:
						Eight = signal;
						break;
					case 5:
						CodesOfFive.Add(signal);
						break;
					case 6:
						CodesOfSix.Add(signal);
						break;
				}
			}

			Segments[0] = string.Concat(Seven.Except(One));

			foreach (var signal in CodesOfSix)
			{
				if (signal.Except(Seven).Except(Four).Count() == 1) Nine = signal;
				if (signal.Except(Seven).Count() == 4) Six = signal;
			}

			Segments[4] = string.Concat(Eight.Except(Nine));
			Segments[6] = string.Concat(Eight.Except(Seven).Except(Four).Except(Segments[4]));
			
			foreach (var signal in CodesOfFive)
			{
				var segment = string.Concat(signal.Except(Seven).Except(Segments[6]));
				if (segment.Length == 1)
				{
					Three = signal;
					Segments[3] = segment;
					break;
				}
			}
			
			Segments[1] = string.Concat(Eight.Except(Three).Except(Segments[4]));
			Segments[2] = string.Concat(Eight.Except(Six));
			Segments[5] = string.Concat(One.Except(Segments[2]));
		}

		public int GetValue(List<string> outputs)
		{
			var valueBuilder = new StringBuilder();
			foreach (var output in outputs.Where(output => !string.IsNullOrEmpty(output)))
			{
				valueBuilder.Append(DecodeValue(output));
			}

			return int.Parse(valueBuilder.ToString());
		}

		private string DecodeValue(string output)
		{
			if (output.Length == 2) return "1";
			if (output.Length == 3) return "7";
			if (output.Length == 4) return "4";
			if (output.Length == 7) return "8";

			if (output.Length == 6)
			{
				if (!output.Contains(Segments[3])) return "0";
				
				return (!output.Contains(Segments[2])) ? "6" : "9";
			}

			if (output.Length == 5)
			{
				if (!output.Contains(Segments[5])) return "2";
				return (!output.Contains(Segments[1])) ? "3" : "5";
			}

			return null;
		}
	}
}
