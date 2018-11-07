﻿using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Sander.QuickList.Application
{
	internal static class Utils
	{
		/// <summary>
		/// Found from the internets, heavily modified for optimization and flexibility
		/// </summary>
		/// <param name="size">Size in bytes</param>
		/// <param name="numberFormat">Format of the returned number. Defaults to 0.##</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static string ReadableSize(long size, string numberFormat = "0.##")
		{
			size = Math.Abs(size);

			string suffix;
			float readable;
			switch (true)
			{
				case true when size >= 0x1000000000000000:
					suffix = "EB";
					readable = size >> 50;
					break;

				case true when size >= 0x4000000000000:

					suffix = "PB";
					readable = size >> 40;
					break;

				case true when size >= 0x10000000000:

					suffix = "TB";
					readable = size >> 30;
					break;

				case true when size >= 0x40000000:
					suffix = "GB";
					readable = size >> 20;
					break;

				case true when size >= 0x100000:
					suffix = "MB";
					readable = size >> 10;
					break;

				case true when size >= 0x400:
					suffix = "KB";
					readable = size;
					break;
				default:
					return FormattableString.Invariant($"{size.ToString(numberFormat, CultureInfo.InvariantCulture)}B");
			}

			return FormattableString.Invariant($"{(readable / 1024).ToString(numberFormat, CultureInfo.InvariantCulture)}{suffix}");
		}
	}
}
