using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	public enum nk_anti_aliasing : byte {
		NK_ANTI_ALIASING_OFF,
		NK_ANTI_ALIASING_ON
	}

	[Flags]
	public enum nk_convert_result : byte {
		NK_CONVERT_SUCCESS = 0,
		NK_CONVERT_INVALID_PARAM = 1,
		NK_CONVERT_COMMAND_BUFFER_FULL = (1 << (1)),
		NK_CONVERT_VERTEX_BUFFER_FULL = (1 << (2)),
		NK_CONVERT_ELEMENT_BUFFER_FULL = (1 << (3))
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_draw_null_texture {
		nk_handle texture;
		nk_vec2 uv;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_convert_config {
		float global_alpha;
		nk_anti_aliasing line_AA;
		nk_anti_aliasing shape_AA;
		uint circle_segment_count;
		uint arc_segment_count;
		uint curve_segment_count;
		nk_draw_null_texture null_tex;
		nk_draw_vertex_layout_element* vertex_layout;
		IntPtr vertex_size;
		IntPtr vertex_alignment;
	}

	public enum nk_command_type : byte {
		NK_COMMAND_NOP,
		NK_COMMAND_SCISSOR,
		NK_COMMAND_LINE,
		NK_COMMAND_CURVE,
		NK_COMMAND_RECT,
		NK_COMMAND_RECT_FILLED,
		NK_COMMAND_RECT_MULTI_COLOR,
		NK_COMMAND_CIRCLE,
		NK_COMMAND_CIRCLE_FILLED,
		NK_COMMAND_ARC,
		NK_COMMAND_ARC_FILLED,
		NK_COMMAND_TRIANGLE,
		NK_COMMAND_TRIANGLE_FILLED,
		NK_COMMAND_POLYGON,
		NK_COMMAND_POLYGON_FILLED,
		NK_COMMAND_POLYLINE,
		NK_COMMAND_TEXT,
		NK_COMMAND_IMAGE,
		NK_COMMAND_CUSTOM
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command {
		nk_command_type ctype;
		IntPtr next_nksize;
		nk_handle userdata;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_scissor {
		nk_command header;
		short x;
		short y;
		ushort w;
		ushort h;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_line {
		nk_command header;
		ushort line_thickness;
		nk_vec2i begin;
		nk_vec2i end;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_curve {
		nk_command header;
		ushort line_thickness;
		nk_vec2i begin;
		nk_vec2i end;
		nk_vec2i ctrlA;
		nk_vec2i ctrlB;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_rect {
		nk_command header;
		ushort rounding;
		ushort line_thickness;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_rect_filled {
		nk_command header;
		ushort rounding;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_rect_multi_color {
		nk_command header;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_color left;
		nk_color top;
		nk_color bottom;
		nk_color right;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_triangle {
		nk_command header;
		ushort line_thickness;
		nk_vec2i a;
		nk_vec2i b;
		nk_vec2i c;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_triangle_filled {
		nk_command header;
		nk_vec2i a;
		nk_vec2i b;
		nk_vec2i c;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_circle {
		nk_command header;
		short x;
		short y;
		ushort line_thickness;
		ushort w;
		ushort h;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_circle_filled {
		nk_command header;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_arc {
		nk_command header;
		short cx;
		short cy;
		ushort r;
		ushort line_thickness;
		fixed float a[2];
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_arc_filled {
		nk_command header;
		short cx;
		short cy;
		ushort r;
		fixed float a[2];
		nk_color color;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_polygon {
		nk_command header;
		nk_color color;
		ushort line_thickness;
		ushort point_count;
		nk_vec2i firstPoint;  /* (fixed?) struct nk_vec2i points[1]; /* ????? * */
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_polygon_filled {
		nk_command header;
		nk_color color;
		ushort point_count;
		nk_vec2i firstPoint;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_polyline {
		nk_command header;
		nk_color color;
		ushort line_thickness;
		ushort point_count;
		nk_vec2i firstPoint;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_image {
		nk_command header;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_image img;
		nk_color col;
	}

	public delegate void nk_command_custom_callback(IntPtr canvas, short x, short y, ushort w, ushort h, nk_handle callback_data);

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_command_custom {
		nk_command header;
		short x;
		short y;
		ushort w;
		ushort h;
		nk_handle callback_data;
		nk_command_custom_callback callback;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_text {
		nk_command header;
		nk_user_font* font;
		nk_color background;
		nk_color foreground;
		short x;
		short y;
		ushort w;
		ushort h;
		float height;
		int length;
		byte stringFirstByte;
	}

	public enum nk_command_clipping : byte {
		NK_CLIPPING_OFF = nk_bool.nk_false,
		NK_CLIPPING_ON = nk_bool.nk_true
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_command_buffer {
		nk_buffer* baseBuf;
		nk_rect clip;
		int use_clipping;
		nk_handle userdata;
		IntPtr begin_nksize;
		IntPtr end_nksize;
		IntPtr last_nksize;
	}

	/* nk_draw_index -> nk_ushort */

	public enum nk_draw_list_stroke : byte {
		NK_STROKE_OPEN = nk_bool.nk_false,
		NK_STROKE_CLOSED = nk_bool.nk_true
	}

	public enum nk_draw_vertex_layout_attribute : byte {
		NK_VERTEX_POSITION,
		NK_VERTEX_COLOR,
		NK_VERTEX_TEXCOORD,
		NK_VERTEX_ATTRIBUTE_COUNT
	}

	public enum nk_draw_vertex_layout_format : byte {
		NK_FORMAT_SCHAR,
		NK_FORMAT_SSHORT,
		NK_FORMAT_SINT,
		NK_FORMAT_UCHAR,
		NK_FORMAT_USHORT,
		NK_FORMAT_UINT,
		NK_FORMAT_FLOAT,
		NK_FORMAT_DOUBLE,

		NK_FORMAT_COLOR_BEGIN,
		NK_FORMAT_R8G8B8 = NK_FORMAT_COLOR_BEGIN,
		NK_FORMAT_R16G15B16,
		NK_FORMAT_R32G32B32,

		NK_FORMAT_R8G8B8A8,
		NK_FORMAT_B8G8R8A8,
		NK_FORMAT_R16G15B16A16,
		NK_FORMAT_R32G32B32A32,
		NK_FORMAT_R32G32B32A32_FLOAT,
		NK_FORMAT_R32G32B32A32_DOUBLE,

		NK_FORMAT_RGB32,
		NK_FORMAT_RGBA32,
		NK_FORMAT_COLOR_END = NK_FORMAT_RGBA32,
		NK_FORMAT_COUNT
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_draw_vertex_layout_element {
		nk_draw_vertex_layout_attribute attribute;
		nk_draw_vertex_layout_format format;
		IntPtr offset_nksize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_draw_command {
		uint elem_count;
		nk_rect clip_rect;
		nk_handle texture;
		nk_handle userdata;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_draw_list {
		nk_rect clip_rect;
		fixed long circle_vtx_CastMeToVec2[12];
		nk_convert_config config;

		nk_buffer* buffer;
		nk_buffer* vertices;
		nk_buffer* elements;

		uint element_count;
		uint vertex_count;
		uint cmd_count;
		IntPtr cmd_offset_nksize;

		uint path_count;
		uint path_offset;

		nk_anti_aliasing line_AA;
		nk_anti_aliasing shape_AA;

		nk_handle userdata;
	}

	public static unsafe partial class NuklearNative
	{
		private delegate nk_command* nk__begin_t(nk_context* context);
		private static nk__begin_t _nk__begin = LFT<nk__begin_t>();
		public static nk_command* nk__begin(nk_context* context) => _nk__begin(context);

		private delegate nk_command* nk__next_t(nk_context* context, nk_command* command);
		private static nk__next_t _nk__next = LFT<nk__next_t>();
		public static nk_command* nk__next(nk_context* context, nk_command* command) => _nk__next(context, command);

		private delegate uint nk_convert_t(nk_context* context, nk_buffer* cmds, nk_buffer* vertices, nk_buffer* elements, nk_convert_config* ncc);
		private static nk_convert_t _nk_convert = LFT<nk_convert_t>();
		public static uint nk_convert(nk_context* context, nk_buffer* cmds, nk_buffer* vertices, nk_buffer* elements, nk_convert_config* ncc) => _nk_convert(context, cmds, vertices, elements, ncc);

		private delegate nk_draw_command* nk__draw_begin_t(nk_context* context, nk_buffer* buf);
		private static nk__draw_begin_t _nk__draw_begin = LFT<nk__draw_begin_t>();
		public static nk_draw_command* nk__draw_begin(nk_context* context, nk_buffer* buf) => _nk__draw_begin(context, buf);

		private delegate nk_draw_command* nk__draw_end_t(nk_context* context, nk_buffer* buf);
		private static nk__draw_end_t _nk__draw_end = LFT<nk__draw_end_t>();
		public static nk_draw_command* nk__draw_end(nk_context* context, nk_buffer* buf) => _nk__draw_end(context, buf);

		private delegate nk_draw_command* nk__draw_next_t(nk_draw_command* drawc, nk_buffer* buf, nk_context* context);
		private static nk__draw_next_t _nk__draw_next = LFT<nk__draw_next_t>();
		public static nk_draw_command* nk__draw_next(nk_draw_command* drawc, nk_buffer* buf, nk_context* context) => _nk__draw_next(drawc, buf, context);

		private delegate int nk_begin_t(nk_context* context, byte* title, nk_rect bounds, uint flags_nkflags);
		private static nk_begin_t _nk_begin = LFT<nk_begin_t>();
		public static int nk_begin(nk_context* context, byte* title, nk_rect bounds, uint flags_nkflags) => _nk_begin(context, title, bounds, flags_nkflags);

		private delegate void nk_end_t(nk_context* context);
		private static nk_end_t _nk_end = LFT<nk_end_t>();
		public static void nk_end(nk_context* context) => _nk_end(context);




		private delegate void nk_stroke_line_t(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float line_thickness, nk_color color);
		private delegate void nk_stroke_curve_t(nk_command_buffer* cbuf, float x, float y, float x1, float y1, float xa, float ya, float xb, float yb, float line_thickness, nk_color col);
		private delegate void nk_stroke_rect_t(nk_command_buffer* cbuf, nk_rect r, float rounding, float line_thickness, nk_color col);
		private delegate void nk_stroke_circle_t(nk_command_buffer* cbuf, nk_rect r, float line_thickness, nk_color col);
		private delegate void nk_stroke_arc_t(nk_command_buffer* cbuf, float cx, float cy, float radius, float a_min, float a_max, float line_thickness, nk_color col);
		private delegate void nk_stroke_triangle_t(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float x2, float y2, float line_thickness, nk_color col);
		private delegate void nk_stroke_polyline_t(nk_command_buffer* cbuf, float* points, int point_count, float line_thickness, nk_color col);
		private delegate void nk_stroke_polygon_t(nk_command_buffer* cbuf, float* points, int point_count, float line_thickness, nk_color col);

		private delegate void nk_fill_rect_t(nk_command_buffer* cbuf, nk_rect r, float rounding, nk_color col);
		private delegate void nk_fill_rect_multi_color_t(nk_command_buffer* cbuf, nk_rect r, nk_color left, nk_color top, nk_color right, nk_color bottom);
		private delegate void nk_fill_circle_t(nk_command_buffer* cbuf, nk_rect r, nk_color col);
		private delegate void nk_fill_arc_t(nk_command_buffer* cbuf, float cx, float cy, float radius, float a_min, float a_max, nk_color col);
		private delegate void nk_fill_triangle_t(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float x2, float y2, nk_color col);
		private delegate void nk_fill_polygon_t(nk_command_buffer* cbuf, float* pts, int point_count, nk_color col);

		private delegate void nk_draw_image_t(nk_command_buffer* cbuf, nk_rect r, nk_image* img, nk_color col);
		private delegate void nk_draw_text_t(nk_command_buffer* cbuf, nk_rect r, byte* text, int len, nk_user_font* userfont, nk_color col, nk_color col2);
		private delegate void nk_push_scissor_t(nk_command_buffer* cbuf, nk_rect r);
		private delegate void nk_push_custom_t(nk_command_buffer* cbuf, nk_rect r, nk_command_custom_callback cb, nk_handle userdata);





		private static nk_stroke_line_t _nk_stroke_line = LFT<nk_stroke_line_t>();
		private static nk_stroke_curve_t _nk_stroke_curve = LFT<nk_stroke_curve_t>();
		private static nk_stroke_rect_t _nk_stroke_rect = LFT<nk_stroke_rect_t>();
		private static nk_stroke_circle_t _nk_stroke_circle = LFT<nk_stroke_circle_t>();
		private static nk_stroke_arc_t _nk_stroke_arc = LFT<nk_stroke_arc_t>();
		private static nk_stroke_triangle_t _nk_stroke_triangle = LFT<nk_stroke_triangle_t>();
		private static nk_stroke_polyline_t _nk_stroke_polyline = LFT<nk_stroke_polyline_t>();
		private static nk_stroke_polygon_t _nk_stroke_polygon = LFT<nk_stroke_polygon_t>();
		private static nk_fill_rect_t _nk_fill_rect = LFT<nk_fill_rect_t>();
		private static nk_fill_rect_multi_color_t _nk_fill_rect_multi_color = LFT<nk_fill_rect_multi_color_t>();
		private static nk_fill_circle_t _nk_fill_circle = LFT<nk_fill_circle_t>();
		private static nk_fill_arc_t _nk_fill_arc = LFT<nk_fill_arc_t>();
		private static nk_fill_triangle_t _nk_fill_triangle = LFT<nk_fill_triangle_t>();
		private static nk_fill_polygon_t _nk_fill_polygon = LFT<nk_fill_polygon_t>();
		private static nk_draw_image_t _nk_draw_image = LFT<nk_draw_image_t>();
		private static nk_draw_text_t _nk_draw_text = LFT<nk_draw_text_t>();
		private static nk_push_scissor_t _nk_push_scissor = LFT<nk_push_scissor_t>();
		private static nk_push_custom_t _nk_push_custom = LFT<nk_push_custom_t>();




		public static void nk_stroke_line(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float line_thickness, nk_color color) => _nk_stroke_line(cbuf, x0, y0, x1, y1, line_thickness, color);
		public static void nk_stroke_curve(nk_command_buffer* cbuf, float x, float y, float x1, float y1, float xa, float ya, float xb, float yb, float line_thickness, nk_color col) => _nk_stroke_curve(cbuf, x, y, x1, y1, xa, ya, xb, yb, line_thickness, col);
		public static void nk_stroke_rect(nk_command_buffer* cbuf, nk_rect r, float rounding, float line_thickness, nk_color col) => _nk_stroke_rect(cbuf, r, rounding, line_thickness, col);
		public static void nk_stroke_circle(nk_command_buffer* cbuf, nk_rect r, float line_thickness, nk_color col) => _nk_stroke_circle(cbuf, r, line_thickness, col);
		public static void nk_stroke_arc(nk_command_buffer* cbuf, float cx, float cy, float radius, float a_min, float a_max, float line_thickness, nk_color col) => _nk_stroke_arc(cbuf, cx, cy, radius, a_min, a_max, line_thickness, col);
		public static void nk_stroke_triangle(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float x2, float y2, float line_thickness, nk_color col) => _nk_stroke_triangle(cbuf, x0, y0, x1, y1, x2, y2, line_thickness, col);
		public static void nk_stroke_polyline(nk_command_buffer* cbuf, float* points, int point_count, float line_thickness, nk_color col) => _nk_stroke_polyline(cbuf, points, point_count, line_thickness, col);
		public static void nk_stroke_polygon(nk_command_buffer* cbuf, float* points, int point_count, float line_thickness, nk_color col) => _nk_stroke_polygon(cbuf, points, point_count, line_thickness, col);
		public static void nk_fill_rect(nk_command_buffer* cbuf, nk_rect r, float rounding, nk_color col) => _nk_fill_rect(cbuf, r, rounding, col);
		public static void nk_fill_rect_multi_color(nk_command_buffer* cbuf, nk_rect r, nk_color left, nk_color top, nk_color right, nk_color bottom) => _nk_fill_rect_multi_color(cbuf, r, left, top, right, bottom);
		public static void nk_fill_circle(nk_command_buffer* cbuf, nk_rect r, nk_color col) => _nk_fill_circle(cbuf, r, col);
		public static void nk_fill_arc(nk_command_buffer* cbuf, float cx, float cy, float radius, float a_min, float a_max, nk_color col) => _nk_fill_arc(cbuf, cx, cy, radius, a_min, a_max, col);
		public static void nk_fill_triangle(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1, float x2, float y2, nk_color col) => _nk_fill_triangle(cbuf, x0, y0, x1, y1, x2, y2, col);
		public static void nk_fill_polygon(nk_command_buffer* cbuf, float* pts, int point_count, nk_color col) => _nk_fill_polygon(cbuf, pts, point_count, col);
		public static void nk_draw_image(nk_command_buffer* cbuf, nk_rect r, nk_image* img, nk_color col) => _nk_draw_image(cbuf, r, img, col);
		public static void nk_draw_text(nk_command_buffer* cbuf, nk_rect r, byte* text, int len, nk_user_font* userfont, nk_color col, nk_color col2) => _nk_draw_text(cbuf, r, text, len, userfont, col, col2);
		public static void nk_push_scissor(nk_command_buffer* cbuf, nk_rect r) => _nk_push_scissor(cbuf, r);
		public static void nk_push_custom(nk_command_buffer* cbuf, nk_rect r, nk_command_custom_callback cb, nk_handle userdata) => _nk_push_custom(cbuf, r, cb, userdata);






		private delegate void nk_draw_list_init_t(nk_draw_list* dl);
		private delegate void nk_draw_list_setup_t(nk_draw_list* dl, nk_convert_config* ncc, nk_buffer* cmds, nk_buffer* vertices, nk_buffer* elements, nk_anti_aliasing line_aa, nk_anti_aliasing shape_aa);
		private delegate void nk_draw_list_clear_t(nk_draw_list* dl);

		private delegate nk_draw_command* nk__draw_list_begin_t(nk_draw_list* dl, nk_buffer* buf);
		private delegate nk_draw_command* nk__draw_list_next_t(nk_draw_command* drawcmd, nk_buffer* buf, nk_draw_list* dl);
		private delegate nk_draw_command* nk__draw_list_end_t(nk_draw_list* dl, nk_buffer* buf);

		private delegate void nk_draw_list_path_clear_t(nk_draw_list* dl);
		private delegate void nk_draw_list_path_line_to_t(nk_draw_list* dl, nk_vec2 pos);
		private delegate void nk_draw_list_path_arc_to_fast_t(nk_draw_list* dl, nk_vec2 center, float radius, int a_min, int a_max);
		private delegate void nk_draw_list_path_arc_to_t(nk_draw_list* dl, nk_vec2 center, float radius, float a_min, float a_max, uint segments);
		private delegate void nk_draw_list_path_rect_to_t(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, float rounding);
		private delegate void nk_draw_list_path_curve_to_t(nk_draw_list* dl, nk_vec2 p2, nk_vec2 p3, nk_vec2 p4, uint num_segments);
		private delegate void nk_draw_list_path_fill_t(nk_draw_list* dl, nk_color col);
		private delegate void nk_draw_list_path_stroke_t(nk_draw_list* dl, nk_color col, nk_draw_list_stroke closed, float thickness);

		private delegate void nk_draw_list_stroke_line_t(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_color col, float thickness);
		private delegate void nk_draw_list_stroke_rect_t(nk_draw_list* dl, nk_rect rect, nk_color col, float rounding, float thickness);
		private delegate void nk_draw_list_stroke_triangle_t(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c, nk_color col, float thickness);
		private delegate void nk_draw_list_stroke_circle_t(nk_draw_list* dl, nk_vec2 center, float radius, nk_color col, uint segs, float thickness);
		private delegate void nk_draw_list_stroke_curve_t(nk_draw_list* dl, nk_vec2 p0, nk_vec2 cp0, nk_vec2 cp1, nk_vec2 p1, nk_color col, uint segments, float thickness);
		private delegate void nk_draw_list_stroke_poly_line_t(nk_draw_list* dl, nk_vec2* pnts, uint cnt, nk_color col, nk_draw_list_stroke stroke, float thickness, nk_anti_aliasing aa);

		private delegate void nk_draw_list_fill_rect_t(nk_draw_list* dl, nk_rect rect, nk_color col, float rounding);
		private delegate void nk_draw_list_fill_rect_multi_color_t(nk_draw_list* dl, nk_rect rect, nk_color left, nk_color top, nk_color right, nk_color bottom);
		private delegate void nk_draw_list_fill_triangle_t(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c, nk_color col);
		private delegate void nk_draw_list_fill_circle_t(nk_draw_list* dl, nk_vec2 center, float radius, nk_color col, uint segs);
		private delegate void nk_draw_list_fill_poly_convex_t(nk_draw_list* dl, nk_vec2* points, uint count, nk_color col, nk_anti_aliasing aa);

		private delegate void nk_draw_list_add_image_t(nk_draw_list* dl, nk_image texture, nk_rect rect, nk_color col);
		private delegate void nk_draw_list_add_text_t(nk_draw_list* dl, nk_user_font* userfont, nk_rect rect, byte* text, int len, float font_height, nk_color col);

		private delegate void nk_draw_list_push_userdata_t(nk_draw_list* dl, nk_handle userdata);





		private static nk_draw_list_init_t _nk_draw_list_init = LFT<nk_draw_list_init_t>();
		private static nk_draw_list_setup_t _nk_draw_list_setup = LFT<nk_draw_list_setup_t>();
		private static nk_draw_list_clear_t _nk_draw_list_clear = LFT<nk_draw_list_clear_t>();
		private static nk__draw_list_begin_t _nk__draw_list_begin = LFT<nk__draw_list_begin_t>();
		private static nk__draw_list_next_t _nk__draw_list_next = LFT<nk__draw_list_next_t>();
		private static nk__draw_list_end_t _nk__draw_list_end = LFT<nk__draw_list_end_t>();
		private static nk_draw_list_path_clear_t _nk_draw_list_path_clear = LFT<nk_draw_list_path_clear_t>();
		private static nk_draw_list_path_line_to_t _nk_draw_list_path_line_to = LFT<nk_draw_list_path_line_to_t>();
		private static nk_draw_list_path_arc_to_fast_t _nk_draw_list_path_arc_to_fast = LFT<nk_draw_list_path_arc_to_fast_t>();
		private static nk_draw_list_path_arc_to_t _nk_draw_list_path_arc_to = LFT<nk_draw_list_path_arc_to_t>();
		private static nk_draw_list_path_rect_to_t _nk_draw_list_path_rect_to = LFT<nk_draw_list_path_rect_to_t>();
		private static nk_draw_list_path_curve_to_t _nk_draw_list_path_curve_to = LFT<nk_draw_list_path_curve_to_t>();
		private static nk_draw_list_path_fill_t _nk_draw_list_path_fill = LFT<nk_draw_list_path_fill_t>();
		private static nk_draw_list_path_stroke_t _nk_draw_list_path_stroke = LFT<nk_draw_list_path_stroke_t>();
		private static nk_draw_list_stroke_line_t _nk_draw_list_stroke_line = LFT<nk_draw_list_stroke_line_t>();
		private static nk_draw_list_stroke_rect_t _nk_draw_list_stroke_rect = LFT<nk_draw_list_stroke_rect_t>();
		private static nk_draw_list_stroke_triangle_t _nk_draw_list_stroke_triangle = LFT<nk_draw_list_stroke_triangle_t>();
		private static nk_draw_list_stroke_circle_t _nk_draw_list_stroke_circle = LFT<nk_draw_list_stroke_circle_t>();
		private static nk_draw_list_stroke_curve_t _nk_draw_list_stroke_curve = LFT<nk_draw_list_stroke_curve_t>();
		private static nk_draw_list_stroke_poly_line_t _nk_draw_list_stroke_poly_line = LFT<nk_draw_list_stroke_poly_line_t>();
		private static nk_draw_list_fill_rect_t _nk_draw_list_fill_rect = LFT<nk_draw_list_fill_rect_t>();
		private static nk_draw_list_fill_rect_multi_color_t _nk_draw_list_fill_rect_multi_color = LFT<nk_draw_list_fill_rect_multi_color_t>();
		private static nk_draw_list_fill_triangle_t _nk_draw_list_fill_triangle = LFT<nk_draw_list_fill_triangle_t>();
		private static nk_draw_list_fill_circle_t _nk_draw_list_fill_circle = LFT<nk_draw_list_fill_circle_t>();
		private static nk_draw_list_fill_poly_convex_t _nk_draw_list_fill_poly_convex = LFT<nk_draw_list_fill_poly_convex_t>();
		private static nk_draw_list_add_image_t _nk_draw_list_add_image = LFT<nk_draw_list_add_image_t>();
		private static nk_draw_list_add_text_t _nk_draw_list_add_text = LFT<nk_draw_list_add_text_t>();
		private static nk_draw_list_push_userdata_t _nk_draw_list_push_userdata = LFT<nk_draw_list_push_userdata_t>();




		public static void nk_draw_list_init(nk_draw_list* dl) => _nk_draw_list_init(dl);
		public static void nk_draw_list_setup(nk_draw_list* dl, nk_convert_config* ncc, nk_buffer* cmds, nk_buffer* vertices, nk_buffer* elements, nk_anti_aliasing line_aa, nk_anti_aliasing shape_aa) => _nk_draw_list_setup(dl, ncc, cmds, vertices, elements, line_aa, shape_aa);
		public static void nk_draw_list_clear(nk_draw_list* dl) => _nk_draw_list_clear(dl);
		public static nk_draw_command* nk__draw_list_begin(nk_draw_list* dl, nk_buffer* buf) => _nk__draw_list_begin(dl, buf);
		public static nk_draw_command* nk__draw_list_next(nk_draw_command* drawcmd, nk_buffer* buf, nk_draw_list* dl) => _nk__draw_list_next(drawcmd, buf, dl);
		public static nk_draw_command* nk__draw_list_end(nk_draw_list* dl, nk_buffer* buf) => _nk__draw_list_end(dl, buf);
		public static void nk_draw_list_path_clear(nk_draw_list* dl) => _nk_draw_list_path_clear(dl);
		public static void nk_draw_list_path_line_to(nk_draw_list* dl, nk_vec2 pos) => _nk_draw_list_path_line_to(dl, pos);
		public static void nk_draw_list_path_arc_to_fast(nk_draw_list* dl, nk_vec2 center, float radius, int a_min, int a_max) => _nk_draw_list_path_arc_to_fast(dl, center, radius, a_min, a_max);
		public static void nk_draw_list_path_arc_to(nk_draw_list* dl, nk_vec2 center, float radius, float a_min, float a_max, uint segments) => _nk_draw_list_path_arc_to(dl, center, radius, a_min, a_max, segments);
		public static void nk_draw_list_path_rect_to(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, float rounding) => _nk_draw_list_path_rect_to(dl, a, b, rounding);
		public static void nk_draw_list_path_curve_to(nk_draw_list* dl, nk_vec2 p2, nk_vec2 p3, nk_vec2 p4, uint num_segments) => _nk_draw_list_path_curve_to(dl, p2, p3, p4, num_segments);
		public static void nk_draw_list_path_fill(nk_draw_list* dl, nk_color col) => _nk_draw_list_path_fill(dl, col);
		public static void nk_draw_list_path_stroke(nk_draw_list* dl, nk_color col, nk_draw_list_stroke closed, float thickness) => _nk_draw_list_path_stroke(dl, col, closed, thickness);
		public static void nk_draw_list_stroke_line(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_color col, float thickness) => _nk_draw_list_stroke_line(dl, a, b, col, thickness);
		public static void nk_draw_list_stroke_rect(nk_draw_list* dl, nk_rect rect, nk_color col, float rounding, float thickness) => _nk_draw_list_stroke_rect(dl, rect, col, rounding, thickness);
		public static void nk_draw_list_stroke_triangle(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c, nk_color col, float thickness) => _nk_draw_list_stroke_triangle(dl, a, b, c, col, thickness);
		public static void nk_draw_list_stroke_circle(nk_draw_list* dl, nk_vec2 center, float radius, nk_color col, uint segs, float thickness) => _nk_draw_list_stroke_circle(dl, center, radius, col, segs, thickness);
		public static void nk_draw_list_stroke_curve(nk_draw_list* dl, nk_vec2 p0, nk_vec2 cp0, nk_vec2 cp1, nk_vec2 p1, nk_color col, uint segments, float thickness) => _nk_draw_list_stroke_curve(dl, p0, cp0, cp1, p1, col, segments, thickness);
		public static void nk_draw_list_stroke_poly_line(nk_draw_list* dl, nk_vec2* pnts, uint cnt, nk_color col, nk_draw_list_stroke stroke, float thickness, nk_anti_aliasing aa) => _nk_draw_list_stroke_poly_line(dl, pnts, cnt, col, stroke, thickness, aa);
		public static void nk_draw_list_fill_rect(nk_draw_list* dl, nk_rect rect, nk_color col, float rounding) => _nk_draw_list_fill_rect(dl, rect, col, rounding);
		public static void nk_draw_list_fill_rect_multi_color(nk_draw_list* dl, nk_rect rect, nk_color left, nk_color top, nk_color right, nk_color bottom) => _nk_draw_list_fill_rect_multi_color(dl, rect, left, top, right, bottom);
		public static void nk_draw_list_fill_triangle(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c, nk_color col) => _nk_draw_list_fill_triangle(dl, a, b, c, col);
		public static void nk_draw_list_fill_circle(nk_draw_list* dl, nk_vec2 center, float radius, nk_color col, uint segs) => _nk_draw_list_fill_circle(dl, center, radius, col, segs);
		public static void nk_draw_list_fill_poly_convex(nk_draw_list* dl, nk_vec2* points, uint count, nk_color col, nk_anti_aliasing aa) => _nk_draw_list_fill_poly_convex(dl, points, count, col, aa);
		public static void nk_draw_list_add_image(nk_draw_list* dl, nk_image texture, nk_rect rect, nk_color col) => _nk_draw_list_add_image(dl, texture, rect, col);
		public static void nk_draw_list_add_text(nk_draw_list* dl, nk_user_font* userfont, nk_rect rect, byte* text, int len, float font_height, nk_color col) => _nk_draw_list_add_text(dl, userfont, rect, text, len, font_height, col);
		public static void nk_draw_list_push_userdata(nk_draw_list* dl, nk_handle userdata) => _nk_draw_list_push_userdata(dl, userdata);



	}
}
