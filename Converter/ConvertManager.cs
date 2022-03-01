using System;

namespace Converter
{
	public class ConvertManager
	{
		public static float Convert(ConvertInfo info)
		{
			float rate;
			if (RateManager.TryGetRate (info.StartValute, out rate)) 
			{
				float russianEqual = info.amount * rate;
				if (info.EndValute == "RUB")
					return russianEqual;

				if (RateManager.TryGetRate (info.EndValute, out rate)) 
					return russianEqual / rate;
			}

			return 0;
		}
	}
}

