using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	[StructLayout(LayoutKind.Sequential)]
	public struct nk_user_font_glyph {
		public nk_vec2 u;
		public nk_vec2 v;
		public nk_vec2 offset;
		public float width;
		public float height;
		public float xadvance;
	}

	public unsafe delegate float nk_text_width_f(nk_handle handle, float h, byte* s, int len);
	public unsafe delegate void nk_query_font_glyph_f(nk_handle handle, float font_height, nk_user_font_glyph* glyph, uint codepoint, uint next_codepoint);

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_user_font {
		public nk_handle userdata;
		public float height;
		public IntPtr widthfun_nkTextWidthF;
		public IntPtr queryfun_nkQueryFontGlyphF;
		public nk_handle texture;
	}

	public enum nk_font_coord_type {
		NK_COORD_UV,
		NK_COORD_PIXEL
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_baked_font {
		public float height;
		public float ascent;
		public float descent;
		public uint glyph_offset;
		public uint glyph_count;
		public uint* ranges;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font_config {
		public nk_font_config* next;
		public IntPtr ttf_blob;
		public IntPtr ttf_size;
		public byte ttf_data_owned_by_atlas;
		public byte merge_mode;
		public byte pixel_snap;
		public byte oversample_v;
		public byte oversample_h;
		public fixed byte padding[3];
		public float size;
		public nk_font_coord_type coord_type;
		public nk_vec2 spacing;
		public uint* range;
		public nk_baked_font* font;
		public uint fallback_glyph;

		public nk_font_config* n;
		public nk_font_config* p;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_font_glyph {
		public uint codepoint;
		public float xadvance;
		public float x0;
		public float y0;
		public float x1;
		public float y1;
		public float w;
		public float h;
		public float u0;
		public float v0;
		public float u1;
		public float v1;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font {
		public nk_font* next;
		public nk_user_font handle;
		public nk_baked_font info;
		public float scale;
		public nk_font_glyph* glyphs;
		public nk_font_glyph* fallback;
		public uint fallback_codepoint;
		public nk_handle texture;
		public nk_font_config* config;
	}

	public enum nk_font_atlas_format {
		NK_FONT_ATLAS_ALPHA8,
		NK_FONT_ATLAS_RGBA32
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font_atlas {
		public IntPtr pixel;
		public int tex_width;
		public int tex_height;

		public nk_allocator permanent;
		public nk_allocator temporary;

		public nk_recti custom;
		public nk_cursor cursorArrow;
		public nk_cursor cursorText;
		public nk_cursor cursorMove;
		public nk_cursor cursorResizeV;
		public nk_cursor cursorResizeH;
		public nk_cursor cursorResizeTLDR;
		public nk_cursor cursorResizeTRDL;

		public int glyph_count;
		public nk_font_glyph* glyphs;
		public nk_font* default_font;
		public nk_font* fonts;
		public nk_font_config* config;
		public int font_num;
	}

	public static unsafe partial class NuklearNative
	{
		private delegate uint* nk_font_default_glyph_ranges_t();
		private delegate uint* nk_font_chinese_glyph_ranges_t();
		private delegate uint* nk_font_cyrillic_glyph_ranges_t();
		private delegate uint* nk_font_korean_glyph_ranges_t();

		private delegate void nk_font_atlas_init_t(nk_font_atlas* atlas, nk_allocator* alloc);
		private delegate void nk_font_atlas_init_custom_t(nk_font_atlas* atlas, nk_allocator* persistent, nk_allocator* transient);
		private delegate void nk_font_atlas_begin_t(nk_font_atlas* atlas);
		private delegate nk_font_config nk_font_config_t(float pixel_height);
		private delegate nk_font* nk_font_atlas_add_t(nk_font_atlas* atlas, nk_font_config* fconfig);
		private delegate nk_font* nk_font_atlas_add_default_t(nk_font_atlas* atlas, float height, nk_font_config* fconfig);
		private delegate nk_font* nk_font_atlas_add_from_memory_t(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig);

		private delegate nk_font* nk_font_atlas_add_compressed_t(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig);
		private delegate nk_font* nk_font_atlas_add_compressed_base85_t(nk_font_atlas* atlas, byte* data, float height, nk_font_config* fconfig);
		private delegate IntPtr nk_font_atlas_bake_t(nk_font_atlas* atlas, int* width, int* height, nk_font_atlas_format afmt);
		private delegate void nk_font_atlas_end_t(nk_font_atlas* atlas, nk_handle tex, nk_draw_null_texture* drawnulltex);
		private delegate nk_font_glyph* nk_font_find_glyph_t(nk_font* font, uint unicode);
		private delegate void nk_font_atlas_cleanup_t(nk_font_atlas* atlas);
		private delegate void nk_font_atlas_clear_t(nk_font_atlas* atlas);


		private static nk_font_default_glyph_ranges_t _nk_font_default_glyph_ranges = LFT<nk_font_default_glyph_ranges_t>();
		private static nk_font_chinese_glyph_ranges_t _nk_font_chinese_glyph_ranges = LFT<nk_font_chinese_glyph_ranges_t>();
		private static nk_font_cyrillic_glyph_ranges_t _nk_font_cyrillic_glyph_ranges = LFT<nk_font_cyrillic_glyph_ranges_t>();
		private static nk_font_korean_glyph_ranges_t _nk_font_korean_glyph_ranges = LFT<nk_font_korean_glyph_ranges_t>();
		private static nk_font_atlas_init_t _nk_font_atlas_init = LFT<nk_font_atlas_init_t>();
		private static nk_font_atlas_init_custom_t _nk_font_atlas_init_custom = LFT<nk_font_atlas_init_custom_t>();
		private static nk_font_atlas_begin_t _nk_font_atlas_begin = LFT<nk_font_atlas_begin_t>();
		private static nk_font_config_t _nk_font_config = LFT<nk_font_config_t>();
		private static nk_font_atlas_add_t _nk_font_atlas_add = LFT<nk_font_atlas_add_t>();
		private static nk_font_atlas_add_default_t _nk_font_atlas_add_default = LFT<nk_font_atlas_add_default_t>();
		private static nk_font_atlas_add_from_memory_t _nk_font_atlas_add_from_memory = LFT<nk_font_atlas_add_from_memory_t>();
		private static nk_font_atlas_add_compressed_t _nk_font_atlas_add_compressed = LFT<nk_font_atlas_add_compressed_t>();
		private static nk_font_atlas_add_compressed_base85_t _nk_font_atlas_add_compressed_base85 = LFT<nk_font_atlas_add_compressed_base85_t>();
		private static nk_font_atlas_bake_t _nk_font_atlas_bake = LFT<nk_font_atlas_bake_t>();
		private static nk_font_atlas_end_t _nk_font_atlas_end = LFT<nk_font_atlas_end_t>();
		private static nk_font_find_glyph_t _nk_font_find_glyph = LFT<nk_font_find_glyph_t>();
		private static nk_font_atlas_cleanup_t _nk_font_atlas_cleanup = LFT<nk_font_atlas_cleanup_t>();
		private static nk_font_atlas_clear_t _nk_font_atlas_clear = LFT<nk_font_atlas_clear_t>();




		public static uint* nk_font_default_glyph_ranges() => _nk_font_default_glyph_ranges();
		public static uint* nk_font_chinese_glyph_ranges() => _nk_font_chinese_glyph_ranges();
		public static uint* nk_font_cyrillic_glyph_ranges() => _nk_font_cyrillic_glyph_ranges();
		public static uint* nk_font_korean_glyph_ranges() => _nk_font_korean_glyph_ranges();
		public static void nk_font_atlas_init(nk_font_atlas* atlas, nk_allocator* alloc) => _nk_font_atlas_init(atlas, alloc);
		public static void nk_font_atlas_init_custom(nk_font_atlas* atlas, nk_allocator* persistent, nk_allocator* transient) => _nk_font_atlas_init_custom(atlas, persistent, transient);
		public static void nk_font_atlas_begin(nk_font_atlas* atlas) => _nk_font_atlas_begin(atlas);
		public static nk_font_config nk_font_config(float pixel_height) => _nk_font_config(pixel_height);
		public static nk_font* nk_font_atlas_add(nk_font_atlas* atlas, nk_font_config* fconfig) => _nk_font_atlas_add(atlas, fconfig);
		public static nk_font* nk_font_atlas_add_default(nk_font_atlas* atlas, float height, nk_font_config* fconfig) => _nk_font_atlas_add_default(atlas, height, fconfig);
		public static nk_font* nk_font_atlas_add_from_memory(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig) => _nk_font_atlas_add_from_memory(atlas, memory, size, height, fconfig);
		public static nk_font* nk_font_atlas_add_compressed(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig) => _nk_font_atlas_add_compressed(atlas, memory, size, height, fconfig);
		public static nk_font* nk_font_atlas_add_compressed_base85(nk_font_atlas* atlas, byte* data, float height, nk_font_config* fconfig) => _nk_font_atlas_add_compressed_base85(atlas, data, height, fconfig);
		public static IntPtr nk_font_atlas_bake(nk_font_atlas* atlas, int* width, int* height, nk_font_atlas_format afmt) => _nk_font_atlas_bake(atlas, width, height, afmt);
		public static void nk_font_atlas_end(nk_font_atlas* atlas, nk_handle tex, nk_draw_null_texture* drawnulltex) => _nk_font_atlas_end(atlas, tex, drawnulltex);
		public static nk_font_glyph* nk_font_find_glyph(nk_font* font, uint unicode) => _nk_font_find_glyph(font, unicode);
		public static void nk_font_atlas_cleanup(nk_font_atlas* atlas) => _nk_font_atlas_cleanup(atlas);
		public static void nk_font_atlas_clear(nk_font_atlas* atlas) => _nk_font_atlas_clear(atlas);




	}
}
