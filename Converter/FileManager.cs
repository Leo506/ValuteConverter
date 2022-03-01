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
			FileStream fs = new FileStream (fileName, FileMode.Create, FileAccess.Write);
			using (StreamWriter writer = new StreamWriter(fs))
			{
				writer.WriteLine (str);
			}

			fs.Close ();
			fs.Dispose ();
		}
	}
}

