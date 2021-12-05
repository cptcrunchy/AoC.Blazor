using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Blazor.Models
{
	public class VentLine
	{
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }

		public static VentLine FromData(string data)
		{
			var coords = Regex.Split(data, @"\D+").Select(int.Parse).ToArray();
			return new VentLine { X1 = coords[0], Y1 = coords[1], X2 = coords[2], Y2 = coords[3] };
		}

		public List<(int, int)> GetCoordinates()
		{
			var x1 = Math.Min(X1, X2);
			var x2 = Math.Max(X1, X2);
			var y1 = Math.Min(Y1, Y2);
			var y2 = Math.Max(Y1, Y2);

			var xCoords = Enumerable.Range(x1, x2 - x1 + 1);
			var yCoords = Enumerable.Range(y1, y2 - y1 + 1);

			if (X1 > X2) xCoords = xCoords.Reverse();
			if (Y1 > Y2) yCoords = yCoords.Reverse();

			if (IsHorizontal()) return xCoords.Select(x => (x, Y1)).ToList();
			return IsVertical() ? yCoords.Select(y => (X1, y)).ToList() : xCoords.Zip(yCoords).ToList();
		}


		public bool IsHorizontal() => Y1 == Y2;
		public bool IsVertical() => X1 == X2;
		public bool IsDiagonal() => !IsHorizontal() && !IsVertical();
	}
}
