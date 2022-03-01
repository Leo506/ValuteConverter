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

			Console.WriteLine ("Введите начальную валюту: ");
			string start = Console.ReadLine ();

			Console.WriteLine ("Введите конечную валюту: ");
			string end = Console.ReadLine ();

			Console.WriteLine ("Введите кол-во денег: ");
			int amount = int.Parse(Console.ReadLine ());

			return new ConvertInfo() { StartValute = start, EndValute =  end, amount = amount };
		}
	}
}

