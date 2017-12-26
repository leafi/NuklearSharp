using System.Collections.Generic;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace NuklearSharp
{
    public static partial class NuklearNative
    {
        public static unsafe string GetStringUTF8Z(byte* stringStart)
        {
            int characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }

		public static string MakeSizeDebugComparerC()
		{
			// Produces a .c file that when compiled & run should help compare sizes of structures
			// Useful for debugging, or so I hope... as of writing my nk_context struct is a few hundred bytes out

			Dictionary<string, int> sizes = new Dictionary<string, int>();

			var ass = Assembly.GetAssembly(typeof(NuklearNative));
			foreach (var ty in ass.DefinedTypes) {
				if (ty.IsValueType && !ty.IsEnum && ty.Name.StartsWith("nk_", System.StringComparison.Ordinal) && !ty.Name.Contains("<") && !ty.Name.Contains("`")) {
					sizes[ty.Name] = Marshal.SizeOf(ty.UnderlyingSystemType);
				}
			}


			StringBuilder sb = new StringBuilder();
			sb.AppendLine("#include \"nuklear_impl.c\"");
			sb.AppendLine("#include \"stdint.h\"");
			sb.AppendLine("#include \"stdio.h\"");
			sb.AppendLine();
			sb.AppendLine("int main() {");
			sb.AppendLine("  ");
			sb.AppendLine($"  printf(\"\\nBefore we begin: SIZE OF UINTPTR_T: C# {UIntPtr.Size} bytes, C %lu bytes\\n==========\\n\", sizeof(uintptr_t));");
			var lkeys = new List<string>(sizes.Keys);
			lkeys.Sort();
			foreach (var k in lkeys) {
				string structPfx = (k == "nk_style_item_data") ? "union" : ((k == "nk_handle") || (k == "nk_glyph")) ? "" : "struct";
				sb.AppendLine($"  printf(\"{k}: c# size {sizes[k]}, C size %lu\\n\", sizeof({structPfx} {k}));");
				sb.AppendLine($"  if ({sizes[k]} != sizeof({structPfx} {k})) {{ printf(\"!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\\n\"); }}");
			}
			sb.AppendLine("  return 0;");
			sb.AppendLine("}");
			sb.AppendLine();

			return sb.ToString();
		}
    }
}
