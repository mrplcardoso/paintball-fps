using UnityEngine;
using System.Collections.Generic;

public static class AvailableColors
{
	public enum ColorTag
	{ Red, Green, Blue, Yellow, Purple, Count }

	public static readonly Color red = Color.red;
	public static readonly Color blue = Color.blue;
	public static readonly Color green = Color.green;
	public static readonly Color yellow = Color.yellow;
	public static readonly Color purple = new Color(1, 0, 1, 1);
	//ordem fixa:(red, green, blue, alpha)

	public static readonly Dictionary<ColorTag, Color>
			colorMap = new Dictionary<ColorTag, Color>()
			{
						{ ColorTag.Red, red },
						{ ColorTag.Green, green },
						{ ColorTag.Blue, blue },
						{ ColorTag.Yellow, yellow },
						{ ColorTag.Purple, purple }
			};
}