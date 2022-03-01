using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Converter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Task<string> t = RequestAsync ();
			
			string result = t.Result;
			//Console.WriteLine (result);

			//FileManager manager = new FileManager ("test.txt");
			//manager.WriteFile (result);

			JObject json = JObject.Parse (result);
			Console.WriteLine (json ["Valute"]["AUD"]["ID"].ToString());
		}



		private static async Task<string> RequestAsync()
		{
			string responseString = "";
			// Адрес ресурса
			string url = "https://www.cbr-xml-daily.ru/daily_json.js";

			// Создание запроса к сайту
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);

			// Избавляемся от ошибки недоверия
			request.ServerCertificateValidationCallback = delegate {
				return true;
			};

			// Получение ответа
			HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync ();

			// Чтение ответа
			using (Stream stream = response.GetResponseStream ()) 
			{
				using (StreamReader reader = new StreamReader (stream)) 
				{
					responseString = reader.ReadToEnd ();
				}
			}

			response.Close ();
			return responseString;
		}
	}
}
