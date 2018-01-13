using System;
using System.Runtime.InteropServices;

using nk_glyph = System.Int32;
using nk_handle = System.IntPtr;

namespace NuklearSharp
{
	public enum nk_bool {
		nk_false,
		nk_true
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_color {
		public byte r;
		public byte g;
		public byte b;
		public byte a;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_colorf {
		public float r;
		public float g;
		public float b;
		public float a;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_vec2 {
		public float x;
		public float y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_vec2i {
		public short x;
		public short y;
	}

	
	[StructLayout(LayoutKind.Sequential)]
	public struct nk_rect {
		public float x;
		public float y;
		public float w;
		public float h;
	}

	
	[StructLayout(LayoutKind.Sequential)]
	public struct nk_recti {
		public short x;
		public short y;
		public short w;
		public short h;
	}

	// !!!!!!!!!!!!!!!!!!!
	// XXX: Short unions aren't marshalled properly. Use `using nk_glyph = System.Int32;`.
	// !!!!!!!!!!!!!!!!!!!
	/*[StructLayout(LayoutKind.Explicit)]
	public unsafe struct nk_glyph {
		[FieldOffset(0)]
		public fixed byte bytes[4];

		[FieldOffset(0)]
		public int glyph;
	}*/

	// !!!!!!!!!!!!
	// XXX: Short unions aren't marshalled properly. Use `using nk_handle = System.IntPtr;`.
	// !!!!!!!!!!!!
	/*[StructLayout(LayoutKind.Explicit)]
	public struct nk_handle {
		[FieldOffset(0)]
		public int id;
		[FieldOffset(0)]
		public IntPtr ptr;
	}*/

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_image {
		public nk_handle handle;
		public ushort w;
		public ushort h;
		public fixed ushort region[4];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_cursor {
		public nk_image img;
		public nk_vec2 size;
		public nk_vec2 offset;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_scroll {
		public uint x;
		public uint y;
	}

	/* ... */

	public enum nk_heading {
		NK_UP,
		NK_RIGHT,
		NK_DOWN,
		NK_LEFT
	}

	public enum nk_button_behavior {
		NK_BUTTON_DEFAULT,
		NK_BUTTON_REPEATER
	}

	public enum nk_modify {
		NK_FIXED = nk_bool.nk_false,
		NK_MODIFIABLE = nk_bool.nk_true
	}

	public enum nk_orientation {
		NK_VERTICAL,
		NK_HORIZONTAL
	}

	public enum nk_collapse_states {
		NK_MINIMIZED = nk_bool.nk_false,
		NK_MAXIMIZED = nk_bool.nk_true
	}

	public enum nk_show_states {
		NK_HIDDEN = nk_bool.nk_false,
		NK_SHOWN = nk_bool.nk_true
	}

	public enum nk_chart_type {
		NK_CHART_LINES,
		NK_CHART_COLUMN,
		NK_CHART_MAX
	}

	public enum nk_chart_event {
		NK_CHART_HOVERING = 0x01,
		NK_CHART_CLICKED = 0x02
	}

	public enum nk_color_format {
		NK_RGB,
		NK_RGBA
	}

	public enum nk_popup_type {
		NK_POPUP_STATIC,
		NK_POPUP_DYNAMIC
	}

	public enum nk_layout_format {
		NK_DYNAMIC,
		NK_STATIC
	}

	public enum nk_tree_type {
		NK_TREE_NODE,
		NK_TREE_TAB
	}


	public static unsafe partial class NuklearNative {

		private delegate nk_handle nk_handle_ptr_t(IntPtr ptr);
		private delegate nk_handle nk_handle_id_t(int id);
		private delegate nk_image nk_image_handle_t(nk_handle handle);
		private delegate nk_image nk_image_ptr_t(IntPtr ptr);
		private delegate nk_image nk_image_id_t(int id);
		private delegate int nk_image_is_subimage_t(nk_image* img);
		private delegate nk_image nk_subimage_ptr_t(IntPtr ptr, ushort w, ushort h, nk_rect sub_region);
		private delegate nk_image nk_subimage_id_t(int id, ushort w, ushort h, nk_rect sub_region);
		private delegate nk_image nk_subimage_handle_t(nk_handle handle, ushort w, ushort h, nk_rect sub_region);

		private delegate uint nk_murmur_hash_t(IntPtr key, int len, uint seed);
		private delegate void nk_triangle_from_direction_t(nk_vec2* result, nk_rect r, float pad_x, float pad_y, nk_heading heading);

		private delegate nk_vec2 nk_vec2i_t(int x, int y);
		private delegate nk_vec2 nk_vec2v_t(float* xy);
		private delegate nk_vec2 nk_vec2iv_t(int* xy);

		private delegate nk_rect nk_get_null_rect_t();
		private delegate nk_rect nk_recti_t(int x, int y, int w, int h);
		private delegate nk_rect nk_recta_t(nk_vec2 pos, nk_vec2 size);
		private delegate nk_rect nk_rectv_t(float* xywh);
		private delegate nk_rect nk_rectiv_t(int* xywh);
		private delegate nk_vec2 nk_rect_pos_t(nk_rect r);
		private delegate nk_vec2 nk_rect_size_t(nk_rect r);

		private static nk_handle_ptr_t _nk_handle_ptr = LFT<nk_handle_ptr_t>();
		private static nk_handle_id_t _nk_handle_id = LFT<nk_handle_id_t>();
		private static nk_image_handle_t _nk_image_handle = LFT<nk_image_handle_t>();
		private static nk_image_ptr_t _nk_image_ptr = LFT<nk_image_ptr_t>();
		private static nk_image_id_t _nk_image_id = LFT<nk_image_id_t>();
		private static nk_image_is_subimage_t _nk_image_is_subimage = LFT<nk_image_is_subimage_t>();
		private static nk_subimage_ptr_t _nk_subimage_ptr = LFT<nk_subimage_ptr_t>();
		private static nk_subimage_id_t _nk_subimage_id = LFT<nk_subimage_id_t>();
		private static nk_subimage_handle_t _nk_subimage_handle = LFT<nk_subimage_handle_t>();
		private static nk_murmur_hash_t _nk_murmur_hash = LFT<nk_murmur_hash_t>();
		private static nk_triangle_from_direction_t _nk_triangle_from_direction = LFT<nk_triangle_from_direction_t>();
		private static nk_vec2i_t _nk_vec2i = LFT<nk_vec2i_t>();
		private static nk_vec2v_t _nk_vec2v = LFT<nk_vec2v_t>();
		private static nk_vec2iv_t _nk_vec2iv = LFT<nk_vec2iv_t>();
		private static nk_get_null_rect_t _nk_get_null_rect = LFT<nk_get_null_rect_t>();
		private static nk_recti_t _nk_recti = LFT<nk_recti_t>();
		private static nk_recta_t _nk_recta = LFT<nk_recta_t>();
		private static nk_rectv_t _nk_rectv = LFT<nk_rectv_t>();
		private static nk_rectiv_t _nk_rectiv = LFT<nk_rectiv_t>();
		private static nk_rect_pos_t _nk_rect_pos = LFT<nk_rect_pos_t>();
		private static nk_rect_size_t _nk_rect_size = LFT<nk_rect_size_t>();




		public static nk_handle nk_handle_ptr(IntPtr ptr) => _nk_handle_ptr(ptr);
		public static nk_handle nk_handle_id(int id) => _nk_handle_id(id);
		public static nk_image nk_image_handle(nk_handle handle) => _nk_image_handle(handle);
		public static nk_image nk_image_ptr(IntPtr ptr) => _nk_image_ptr(ptr);
		public static nk_image nk_image_id(int id) => _nk_image_id(id);
		public static int nk_image_is_subimage(nk_image* img) => _nk_image_is_subimage(img);
		public static nk_image nk_subimage_ptr(IntPtr ptr, ushort w, ushort h, nk_rect sub_region) => _nk_subimage_ptr(ptr, w, h, sub_region);
		public static nk_image nk_subimage_id(int id, ushort w, ushort h, nk_rect sub_region) => _nk_subimage_id(id, w, h, sub_region);
		public static nk_image nk_subimage_handle(nk_handle handle, ushort w, ushort h, nk_rect sub_region) => _nk_subimage_handle(handle, w, h, sub_region);
		public static uint nk_murmur_hash(IntPtr key, int len, uint seed) => _nk_murmur_hash(key, len, seed);
		public static void nk_triangle_from_direction(nk_vec2* result, nk_rect r, float pad_x, float pad_y, nk_heading heading) => _nk_triangle_from_direction(result, r, pad_x, pad_y, heading);
		public static nk_vec2 nk_vec2i(int x, int y) => _nk_vec2i(x, y);
		public static nk_vec2 nk_vec2v(float* xy) => _nk_vec2v(xy);
		public static nk_vec2 nk_vec2iv(int* xy) => _nk_vec2iv(xy);
		public static nk_rect nk_get_null_rect() => _nk_get_null_rect();
		public static nk_rect nk_recti(int x, int y, int w, int h) => _nk_recti(x, y, w, h);
		public static nk_rect nk_recta(nk_vec2 pos, nk_vec2 size) => _nk_recta(pos, size);
		public static nk_rect nk_rectv(float* xywh) => _nk_rectv(xywh);
		public static nk_rect nk_rectiv(int* xywh) => _nk_rectiv(xywh);
		public static nk_vec2 nk_rect_pos(nk_rect r) => _nk_rect_pos(r);
		public static nk_vec2 nk_rect_size(nk_rect r) => _nk_rect_size(r);


	}

}
