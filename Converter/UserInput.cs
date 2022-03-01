using System;

namespace Converter
{
	public class UserInput
	{
		/// <summary>
		/// Запрашивает информацию у пользователя
		/// </summary>
		/// <returns>Возвращает введённые пользователем значения</returns>
		public static ConvertInfo GetInput()
		{
			ConvertInfo info;

			Console.WriteLine ("Введите начальную валюту: ");
			info.StartValute = Console.ReadLine ();

			Console.WriteLine ("Введите конечную валюту: ");
			info.EndValute = Console.ReadLine ();

			Console.WriteLine ("Введите кол-во денег: ");
			info.amount = (int)Console.ReadLine ();

			return info;
		}
	}
}

