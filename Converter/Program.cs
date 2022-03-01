using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Converter
{
	class MainClass
	{
		const string menuString = "\n\t[1] - Обновить курс\n\t[2] - Конвертировать\nДействие: ";

		public static void Main (string[] args)
		{
			//Task<string> t = RequestAsync ();
			
			//string result = t.Result;
			//Console.WriteLine (result);

			//FileManager manager = new FileManager ("test.txt");
			//manager.WriteFile (result);

			//JObject json = JObject.Parse (result);
			//Console.WriteLine (json ["Valute"]["AUD"]["ID"].ToString());



			Console.WriteLine ("\t\tКОНВЕРТЕР ВАЛЮТ" + menuString);
			string action = Console.Read ();

			switch (action) 
			{
			case "1":
				RateManager.UpdateRate ();
				break;

			case "2":
				//ConvertInfo info = UserInput.GetInput ();
				break;

			default:
				Console.WriteLine ("Bye ;)");
				break;
			}
		}
	}
}
