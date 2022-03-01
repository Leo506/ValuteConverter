using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

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


		/// <summary>
		/// Пробует получить курс определенной валюты
		/// </summary>
		/// <returns><c>true</c>, Если получилось взять курс, <c>false</c> иначе.</returns>
		/// <param name="valute">Валюта, курс которой ищется</param>
		/// <param name="rate">Куда записать курс</param>
		public static bool TryGetRate(string valute, out float rate)
		{
			FileManager manager = new FileManager (rateFile);
			string json = manager.ReadFile ();

			JObject jsonObj = JObject.Parse (json);

			try
			{
				rate = float.Parse(jsonObj["Valute"][valute]["Value"].ToString());
				return true;
			}

			catch 
			{
				rate = -1;
				return false;
			}
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

