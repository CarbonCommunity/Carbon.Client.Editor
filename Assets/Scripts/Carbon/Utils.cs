using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Carbon.Client
{
	public static class CarbonUtils
	{
		public static string GetRecursiveName(Transform transform, string strEndName = "")
		{
			var text = transform.name;

			if (!string.IsNullOrEmpty(strEndName))
			{
				text = text + "/" + strEndName;
			}

			if (transform.parent != null)
			{
				text = GetRecursiveName(transform.parent, text);
			}

			return text;
		}

		public static float Percentage(this int value, int total, float percent = 100)
		{
			return (float)Math.Round((double)percent * value) / total;
		}
		public static uint ManifestHash(this string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return 0u;
			}
			 
			return BitConverter.ToUInt32(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str)), 0);
		}
	}
}
