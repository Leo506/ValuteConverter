using System;
using System.IO;

namespace Converter
{
	public class FileManager
	{
		private string fileName;

		/// <summary>
		/// Создаёт новый экземпляр менеджера файлов
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		public FileManager (string fileName)
		{
			this.fileName = fileName;
		}


		/// <summary>
		/// Записывает строку в файл
		/// </summary>
		/// <param name="str">Строка</param>
		public void WriteFile(string str)
		{
			FileStream fs = null;
			try
			{
				fs = new FileStream (fileName, FileMode.Create, FileAccess.Write);
				using (StreamWriter writer = new StreamWriter(fs))
				{
					writer.WriteLine (str);
				}
			}
			finally 
			{
				if (fs != null) 
				{
					fs.Close ();
					fs.Dispose ();
					fs = null;
				}
			}
		}


		/// <summary>
		/// Читает содержимое файла с курсом валют
		/// </summary>
		/// <returns>Строка - содержимое файла</returns>
		public string ReadFile()
		{
			FileStream fs = null;
			string result = "";
			try
			{
				fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				using (StreamReader reader = new StreamReader(fs))
				{
					result = reader.ReadToEnd();
				}
			}

			finally 
			{
				if (fs != null) 
				{
					fs.Close ();
					fs.Dispose ();
					fs = null;
				}
			}

			return result;
		}
	}
}

