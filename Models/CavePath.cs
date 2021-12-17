using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AoC.Blazor.Models
{
	public class CavePath
	{
		public (int x, int y) LastPosition { get; private set; }
		public int Risk { get; private set; }

		public CavePath((int x, int y) lastPosition)
		{
			LastPosition = lastPosition;
			Risk = 0;
		}

		public CavePath(CavePath currentPosition, (int x, int y) lastPosition, int addRisk)
		{
			LastPosition = lastPosition;
			Risk = currentPosition.Risk + addRisk;
		}
	}
}
