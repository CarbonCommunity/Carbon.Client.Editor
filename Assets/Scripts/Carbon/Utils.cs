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

		public struct GUIColorChange : IDisposable
		{
			public Color Color;
			public Color Original;
			public bool IsBackground;

			public static GUIColorChange New(Color color, bool background = true)
			{
				var change = new GUIColorChange
				{
					Color = color,
					IsBackground = background,
					Original = background ? GUI.backgroundColor : GUI.color
				};

				if (background)
				{
					GUI.backgroundColor = color;
				}
				else
				{
					GUI.color = color;
				}

				return change;
			}

			public void Dispose()
			{
				if (IsBackground)
				{
					GUI.backgroundColor = Original;
				}
				else
				{
					GUI.color = Original;
				}
			}
		}
		public struct GUIEnableChange : IDisposable
		{
			public bool Value;
			public bool Original;

			public static GUIEnableChange New(bool value)
			{
				var change = new GUIEnableChange
				{
					Value = value,
					Original = GUI.enabled
				};

				GUI.enabled = value;

				return change;
			}

			public void Dispose()
			{
				GUI.enabled = Original;
			}
		}
	}
}
