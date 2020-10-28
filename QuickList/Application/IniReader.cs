﻿using System.Runtime.InteropServices;
using System.Text;

namespace Sander.QuickList.Application
{
	/// <summary>
	///     After https://code.msdn.microsoft.com/windowsdesktop/Reading-and-Writing-Values-85084b6a
	/// </summary>
	internal sealed class IniReader
	{
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string section, string key,
			string defaultValue, StringBuilder value, int size, string filePath);


		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WritePrivateProfileString(string section, string key,
			string value, string filePath);


		internal static string ReadValue(string section, string key, string filePath, string defaultValue = "")
		{
			var value = new StringBuilder(1024);
			GetPrivateProfileString(section, key, defaultValue, value, value.Capacity, filePath);
			return value.ToString();
		}


		internal static bool WriteValue(string section, string key, string value, string filePath)
		{
			return WritePrivateProfileString(section, key, value, filePath);
		}
	}
}
