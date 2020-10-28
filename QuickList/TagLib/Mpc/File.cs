﻿using System;

namespace Sander.QuickList.TagLib.Mpc
{
	/// <summary>
	///     This class extends <see cref="TagLib.NonContainer.File" /> to
	///     provide tagging and properties support for MusePack files.
	/// </summary>
	/// <remarks>
	///     A <see cref="TagLib.Ape.Tag" /> will be added automatically to
	///     any file that doesn't contain one. This change does not effect
	///     the file and can be reversed using the following method:
	///     <c>file.RemoveTags (file.TagTypes &amp; ~file.TagTypesOnDisk);</c>
	/// </remarks>
	[SupportedMimeType("taglib/mpc", "mpc")]
	[SupportedMimeType("taglib/mp+", "mp+")]
	[SupportedMimeType("taglib/mpp", "mpp")]
	public sealed class File : NonContainer.File
	{
		/// <summary>
		///     Constructs and initializes a new instance of
		///     <see
		///         cref="File" />
		///     for a specified path in the local file
		///     system and specified read style.
		/// </summary>
		/// <param name="path">
		///     A <see cref="string" /> object containing the path of the
		///     file to use in the new instance.
		/// </param>
		/// <param name="propertiesStyle">
		///     A <see cref="ReadStyle" /> value specifying at what level
		///     of accuracy to read the media properties, or
		///     <see
		///         cref="ReadStyle.None" />
		///     to ignore the properties.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="path" /> is <see langword="null" />.
		/// </exception>
		public File(string path, ReadStyle propertiesStyle)
			: base(path, propertiesStyle)
		{
		}


		/// <summary>
		///     Constructs and initializes a new instance of
		///     <see
		///         cref="File" />
		///     for a specified path in the local file
		///     system with an average read style.
		/// </summary>
		/// <param name="path">
		///     A <see cref="string" /> object containing the path of the
		///     file to use in the new instance.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="path" /> is <see langword="null" />.
		/// </exception>
		public File(string path) : base(path)
		{
		}


		/// <summary>
		///     Constructs and initializes a new instance of
		///     <see
		///         cref="File" />
		///     for a specified file abstraction and
		///     specified read style.
		/// </summary>
		/// <param name="abstraction">
		///     A <see cref="TagLib.File.IFileAbstraction" /> object to use when
		///     reading from and writing to the file.
		/// </param>
		/// <param name="propertiesStyle">
		///     A <see cref="ReadStyle" /> value specifying at what level
		///     of accuracy to read the media properties, or
		///     <see
		///         cref="ReadStyle.None" />
		///     to ignore the properties.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="abstraction" /> is <see langword="null" />.
		/// </exception>
		public File(IFileAbstraction abstraction,
			ReadStyle propertiesStyle)
			: base(abstraction, propertiesStyle)
		{
		}


		/// <summary>
		///     Constructs and initializes a new instance of
		///     <see
		///         cref="File" />
		///     for a specified file abstraction with an
		///     average read style.
		/// </summary>
		/// <param name="abstraction">
		///     A <see cref="TagLib.File.IFileAbstraction" /> object to use when
		///     reading from and writing to the file.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="abstraction" /> is <see langword="null" />.
		/// </exception>
		public File(IFileAbstraction abstraction)
			: base(abstraction)
		{
		}


		/// <summary>
		///     Reads format specific information at the end of the
		///     file.
		/// </summary>
		/// <param name="end">
		///     A <see cref="long" /> value containing the seek position
		///     at which the media data ends and the tags begin.
		/// </param>
		/// <param name="propertiesStyle">
		///     A <see cref="ReadStyle" /> value specifying at what level
		///     of accuracy to read the media properties, or
		///     <see
		///         cref="ReadStyle.None" />
		///     to ignore the properties.
		/// </param>
		protected override void ReadEnd(long end,
			ReadStyle propertiesStyle)
		{
		}


		/// <summary>
		///     Reads the audio properties from the file represented by
		///     the current instance.
		/// </summary>
		/// <param name="start">
		///     A <see cref="long" /> value containing the seek position
		///     at which the tags end and the media data begins.
		/// </param>
		/// <param name="end">
		///     A <see cref="long" /> value containing the seek position
		///     at which the media data ends and the tags begin.
		/// </param>
		/// <param name="propertiesStyle">
		///     A <see cref="ReadStyle" /> value specifying at what level
		///     of accuracy to read the media properties, or
		///     <see
		///         cref="ReadStyle.None" />
		///     to ignore the properties.
		/// </param>
		/// <returns>
		///     A <see cref="TagLib.Properties" /> object describing the
		///     media properties of the file represented by the current
		///     instance.
		/// </returns>
		protected override Properties ReadProperties(long start,
			long end,
			ReadStyle propertiesStyle)
		{
			var header = new StreamHeader(this,
				end - start);

			return new Properties(TimeSpan.Zero, header);
		}
	}
}
