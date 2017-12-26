using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	[StructLayout(LayoutKind.Sequential)]
	public struct nk_user_font_glyph {
		nk_vec2 u;
		nk_vec2 v;
		nk_vec2 offset;
		float width;
		float height;
		float xadvance;
	}

	public unsafe delegate float nk_text_width_f(nk_handle handle, float h, byte* s, int len);
	public unsafe delegate void nk_query_font_glyph_f(nk_handle handle, float font_height, nk_user_font_glyph* glyph, uint codepoint, uint next_codepoint);

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_user_font {
		nk_handle userdata;
		float height;
		IntPtr widthfun_nkTextWidthF;
		IntPtr queryfun_nkQueryFontGlyphF;
		nk_handle texture;
	}

	public enum nk_font_coord_type : byte {
		NK_COORD_UV,
		NK_COORD_PIXEL
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_baked_font {
		float height;
		float ascent;
		float descent;
		uint glyph_offset;
		uint glyph_count;
		uint* ranges;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font_config {
		nk_font_config* next;
		IntPtr ttf_blob;
		IntPtr ttf_size;
		byte ttf_data_owned_by_atlas;
		byte merge_mode;
		byte pixel_snap;
		byte oversample_v;
		byte oversample_h;
		fixed byte padding[3];
		float size;
		nk_font_coord_type coord_type;
		nk_vec2 spacing;
		uint* range;
		nk_baked_font* font;
		uint fallback_glyph;

		nk_font_config* n;
		nk_font_config* p;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_font_glyph {
		uint codepoint;
		float xadvance;
		float x0;
		float y0;
		float x1;
		float y1;
		float w;
		float h;
		float u0;
		float v0;
		float u1;
		float v1;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font {
		nk_font* next;
		nk_user_font handle;
		nk_baked_font info;
		float scale;
		nk_font_glyph* glyphs;
		nk_font_glyph* fallback;
		uint fallback_codepoint;
		nk_handle texture;
		nk_font_config* config;
	}

	public enum nk_font_atlas_format : byte {
		NK_FONT_ATLAS_ALPHA8,
		NK_FONT_ATLAS_RGBA32
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_font_atlas {
		IntPtr pixel;
		int tex_width;
		int tex_height;

		nk_allocator permanent;
		nk_allocator temporary;

		nk_recti custom;
		nk_cursor cursorArrow;
		nk_cursor cursorText;
		nk_cursor cursorMove;
		nk_cursor cursorResizeV;
		nk_cursor cursorResizeH;
		nk_cursor cursorResizeTLDR;
		nk_cursor cursorResizeTRDL;

		int glyph_count;
		nk_font_glyph* glyphs;
		nk_font* default_font;
		nk_font* fonts;
		nk_font_config* config;
		int font_num;
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
