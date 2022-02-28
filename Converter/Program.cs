using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Converter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Task t = Task.Run (RequestAsync);
			t.Wait ();
		}



		private static async Task RequestAsync()
		{
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
					string line = "";
					while ((line = reader.ReadLine()) != null) 
					{
						Console.WriteLine (line);	
					}
				}
			}

			response.Close ();
		}
	}
}
