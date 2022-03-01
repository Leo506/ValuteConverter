using System;

namespace Converter
{
	public struct ConvertInfo
	{
		private string _startValute;  // Исходная валюта
		public string StartValute 
		{
			get { return _startValute; }
			set
			{ 
				if (value.Length != 3)
					throw new Exception ("Название валюты состоит из 3 букв");
				_startValute = value;
			}
		}

		private string _endValute;  // Конечная валюта
		public string EndValute
		{
			get { return _endValute; }
			set
			{
				if (value.Length != 3)
					throw new Exception ("Название валюты состоит из 3 букв");
				_endValute = value;
			}
		}

		public float amount { get; set; }

	}
}

