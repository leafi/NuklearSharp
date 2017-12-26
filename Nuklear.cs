using System;
using NativeLibraryLoader;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	public static unsafe partial class NuklearNative
	{
		private static readonly NativeLibrary nk_nklib = LoadNk();

		private static NativeLibrary LoadNk()
		{
			string[] names;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				names = new[] { "Nuklear.dll" };
			} else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
				names = new[] {
					"libnuklear.so",
					"libnuklear.so.0"
				};
			} else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
				names = new[] { "libnuklear.dylib" };
			} else {
				names = new[] { "Nuklear.dll" };
			}

			return new NativeLibrary(names);
		}

		private static T LoadFunction<T>(string name)
		{
			return nk_nklib.LoadFunction<T>(name);
		}

		private static T LFT<T>()
		{
			var s = nameof(T);
			if (s.EndsWith("_t", StringComparison.Ordinal) && !s.Contains(".")) {
				return LoadFunction<T>(s.Substring(0, s.Length - 2));
			} else {
				throw new ArgumentException("<T> passed to LFT<T> (which is LoadFunction<T> shorthand) must be like some_fun_t (=> which yields name: some_fun) and not the given '" + s + "'");
			}
		}

		/*
		 * nk_char -> char
		 * nk_uchar -> unsigned char
		 * nk_byte -> unsigned char
		 * nk_short -> signed short
		 * nk_ushort -> unsigned short
		 * nk_int -> signed int
		 * nk_uint -> unsigned int
		 * nk_size -> unsigned long (!!! IntPtr)
		 * nk_ptr -> unsigned long (!!! IntPtr)
		 * 
		 * nk_hash -> uint
		 * nk_flags -> uint
		 * nk_rune -> uint
		 */

	}
}
