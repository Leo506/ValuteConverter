using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Converter
{
	public class RateManager
	{
		const string rateFile = "rate.json";                              // Файл, в котором храняться курсы валют
		const string url = "https://www.cbr-xml-daily.ru/daily_json.js";  // Сайт с текущим курсом


		/// <summary>
		/// Обновляет текущий файл курса валют
		/// </summary>
		public static void UpdateRate()
		{
			Task<string> t = RequestAsync ();

			string result = t.Result;

			FileManager manager = new FileManager (rateFile);
			manager.WriteFile (result);
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

