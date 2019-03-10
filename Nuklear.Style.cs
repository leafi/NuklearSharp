using System;
using System.Runtime.InteropServices;

using nk_handle = System.IntPtr;

namespace NuklearSharp
{
	public enum nk_style_item_type {
		NK_STYLE_ITEM_COLOR,
		NK_STYLE_ITEM_IMAGE
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct nk_style_item_data {
		[FieldOffset(0)]
		public nk_color color;

		[FieldOffset(0)]
		public nk_image image;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_item {
		public nk_style_item_type type;
		public nk_style_item_data data;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_text {
		public nk_color color;
		public nk_vec2 padding;
	}

	public unsafe delegate void nk_style_drawbeginend(nk_command_buffer* cbuf, nk_handle userdata);

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_button {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_color text_background;
		public nk_color text_normal;
		public nk_color text_hover;
		public nk_color text_active;
		public uint text_alignment_nkflags;

		public float border;
		public float rounding;
		public nk_vec2 padding;
		public nk_vec2 image_padding;
		public nk_vec2 touch_padding;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_toggle {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_style_item cursor_normal;
		public nk_style_item cursor_hover;

		public nk_color text_normal;
		public nk_color text_hover;
		public nk_color text_active;
		public nk_color text_background;
		public uint text_alignment_nkflags;

		public nk_vec2 padding;
		public nk_vec2 touch_padding;
		public float spacing;
		public float border;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_selectable {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item pressed;

		public nk_style_item normal_active;
		public nk_style_item hover_active;
		public nk_style_item pressed_active;

		public nk_color text_normal;
		public nk_color text_hover;
		public nk_color text_pressed;

		public nk_color text_normal_active;
		public nk_color text_hover_active;
		public nk_color text_pressed_active;
		public nk_color text_background;
		public uint text_alignment_nkflags;

		public float rounding;
		public nk_vec2 padding;
		public nk_vec2 touch_padding;
		public nk_vec2 image_padding;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_slider {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_color bar_normal;
		public nk_color bar_hover;
		public nk_color bar_active;
		public nk_color bar_filled;

		public nk_style_item cursor_normal;
		public nk_style_item cursor_hover;
		public nk_style_item cursor_active;

		public float border;
		public float rounding;
		public float bar_height;
		public nk_vec2 padding;
		public nk_vec2 spacing;
		public nk_vec2 cursor_size;

		public int show_buttons;
		public nk_style_button inc_button;
		public nk_style_button dec_button;
		public nk_symbol_type inc_symbol;
		public nk_symbol_type dec_symbol;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_progress {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_style_item cursor_normal;
		public nk_style_item cursor_hover;
		public nk_style_item cursor_active;
		public nk_color cursor_border_color;

		public float rounding;
		public float border;
		public float cursor_border;
		public float cursor_rounding;
		public nk_vec2 padding;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_scrollbar {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_style_item cursor_normal;
		public nk_style_item cursor_hover;
		public nk_style_item cursor_active;
		public nk_color cursor_border_color;

		public float border;
		public float rounding;
		public float border_cursor;
		public float rounding_cursor;
		public nk_vec2 padding;

		public int show_buttons;
		public nk_style_button inc_button;
		public nk_style_button dec_button;
		public nk_symbol_type inc_symbol;
		public nk_symbol_type dec_symbol;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_edit {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;
		public nk_style_scrollbar scrollbar;

		public nk_color cursor_normal;
		public nk_color cursor_hover;
		public nk_color cursor_text_normal;
		public nk_color cursor_text_hover;

		public nk_color text_normal;
		public nk_color text_hover;
		public nk_color text_active;

		public nk_color selected_normal;
		public nk_color selected_hover;
		public nk_color selected_text_normal;
		public nk_color selected_text_hover;

		public float border;
		public float rounding;
		public float cursor_size;
		public nk_vec2 scrollbar_size;
		public nk_vec2 padding;
		public float row_padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_property {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_color label_normal;
		public nk_color label_hover;
		public nk_color label_active;

		public nk_symbol_type sym_left;
		public nk_symbol_type sym_right;

		public float border;
		public float rounding;
		public nk_vec2 padding;

		public nk_style_edit edit;
		public nk_style_button inc_button;
		public nk_style_button dec_button;

		public nk_handle userdata;
		public IntPtr draw_begin_nkStyleDrawBeginEnd;
		public IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_chart {
		public nk_style_item background;
		public nk_color border_color;
		public nk_color selected_color;
		public nk_color color;

		public float border;
		public float rounding;
		public nk_vec2 padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_combo {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;
		public nk_color border_color;

		public nk_color label_normal;
		public nk_color label_hover;
		public nk_color label_active;

		public nk_color symbol_normal;
		public nk_color symbol_hover;
		public nk_color symbol_active;

		public nk_style_button button;
		public nk_symbol_type sym_normal;
		public nk_symbol_type sym_hover;
		public nk_symbol_type sym_active;

		public float border;
		public float rounding;
		public nk_vec2 content_padding;
		public nk_vec2 button_padding;
		public nk_vec2 spacing;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_tab {
		public nk_style_item background;
		public nk_color border_color;
		public nk_color text;

		public nk_style_button tab_maximize_button;
		public nk_style_button tab_minimize_button;
		public nk_style_button node_maximize_button;
		public nk_style_button node_minimize_button;
		public nk_symbol_type sym_minimize;
		public nk_symbol_type sym_maximize;

		public float border;
		public float rounding;
		public float indent;
		public nk_vec2 padding;
		public nk_vec2 spacing;
	}

	public enum nk_style_header_align {
		NK_HEADER_LEFT,
		NK_HEADER_RIGHT
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_window_header {
		public nk_style_item normal;
		public nk_style_item hover;
		public nk_style_item active;

		public nk_style_button close_button;
		public nk_style_button minimize_button;
		public nk_symbol_type close_symbol;
		public nk_symbol_type minimize_symbol;
		public nk_symbol_type maximize_symbol;

		public nk_color label_normal;
		public nk_color label_hover;
		public nk_color label_active;

		public nk_style_header_align align;
		public nk_vec2 padding;
		public nk_vec2 label_padding;
		public nk_vec2 spacing;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_style_window {
		public nk_style_window_header header;
		public nk_style_item fixed_background;
		public nk_color background;

		public nk_color border_color;
		public nk_color popup_border_color;
		public nk_color combo_border_color;
		public nk_color contextual_border_color;
		public nk_color menu_border_color;
		public nk_color group_border_color;
		public nk_color tooltip_border_color;
		public nk_style_item scaler;

		public float border;
		public float combo_border;
		public float contextual_border;
		public float menu_border;
		public float group_border;
		public float tooltip_border;
		public float popup_border;
		public float min_row_height_padding;

		public float rounding;
		public nk_vec2 spacing;
		public nk_vec2 scrollbar_size;
		public nk_vec2 min_size;

		public nk_vec2 padding;
		public nk_vec2 group_padding;
		public nk_vec2 popup_padding;
		public nk_vec2 combo_padding;
		public nk_vec2 contextual_padding;
		public nk_vec2 menu_padding;
		public nk_vec2 tooltip_padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_style {
		public nk_user_font* font;

		/* fixed nk_cursor* cursors[(int)(nk_style_cursor.NK_CURSOR_COUNT)]; */
		public nk_cursor* cursorArrow;
		public nk_cursor* cursorText;
		public nk_cursor* cursorMove;
		public nk_cursor* cursorResizeV;
		public nk_cursor* cursorResizeH;
		public nk_cursor* cursorResizeTLDR;
		public nk_cursor* cursorResizeTRDL;

		public nk_cursor* cursor_active;
		public nk_cursor* cursor_last;
		public int cursor_visible;

		public nk_style_text text;
		public nk_style_button button;
		public nk_style_button contextual_button;
		public nk_style_button menu_button;
		public nk_style_toggle option;
		public nk_style_toggle checkbox;
		public nk_style_selectable selectable;
		public nk_style_slider slider;
		public nk_style_progress progress;
		public nk_style_property property;
		public nk_style_edit edit;
		public nk_style_chart chart;
		public nk_style_scrollbar scrollh;
		public nk_style_scrollbar scrollb;
		public nk_style_tab tab;
		public nk_style_combo combo;
		public nk_style_window window;
	}

	public enum nk_style_colors {
		NK_COLOR_TEXT,
		NK_COLOR_WINDOW,
		NK_COLOR_HEADER,
		NK_COLOR_BORDER,
		NK_COLOR_BUTTON,
		NK_COLOR_BUTTON_HOVER,
		NK_COLOR_BUTTON_ACTIVE,
		NK_COLOR_TOGGLE,
		NK_COLOR_TOGGLE_HOVER,
		NK_COLOR_TOGGLE_CURSOR,
		NK_COLOR_SELECT,
		NK_COLOR_SELECT_ACTIVE,
		NK_COLOR_SLIDER,
		NK_COLOR_SLIDER_CURSOR,
		NK_COLOR_SLIDER_CURSOR_HOVER,
		NK_COLOR_SLIDER_CURSOR_ACTIVE,
		NK_COLOR_PROPERTY,
		NK_COLOR_EDIT,
		NK_COLOR_EDIT_CURSOR,
		NK_COLOR_COMBO,
		NK_COLOR_CHART,
		NK_COLOR_CHART_COLOR,
		NK_COLOR_CHART_COLOR_HIGHLIGHT,
		NK_COLOR_SCROLLBAR,
		NK_COLOR_SCROLLBAR_CURSOR,
		NK_COLOR_SCROLLBAR_CURSOR_HOVER,
		NK_COLOR_SCROLLBAR_CURSOR_ACTIVE,
		NK_COLOR_TAB_HEADER,
		NK_COLOR_COUNT
	}

	public enum nk_style_cursor {
		NK_CURSOR_ARROW,
		NK_CURSOR_TEXT,
		NK_CURSOR_MOVE,
		NK_CURSOR_RESIZE_VERTICAL,
		NK_CURSOR_RESIZE_HORIZONTAL,
		NK_CURSOR_RESIZE_TOP_LEFT_DOWN_RIGHT,
		NK_CURSOR_RESIZE_TOP_RIGHT_DOWN_LEFT,
		NK_CURSOR_COUNT
	}




	public static unsafe partial class NuklearNative
	{
		private delegate void nk_style_default_t(nk_context* ctx);
		private delegate void nk_style_from_table_t(nk_context* ctx, nk_color* color);
		private delegate void nk_style_load_cursor_t(nk_context* ctx, nk_style_cursor scur, nk_cursor* cursor);
		private delegate void nk_style_load_all_cursors_t(nk_context* ctx, nk_cursor* cursor);
		private delegate byte* nk_style_get_color_by_name_t(nk_style_colors scol);
		private delegate void nk_style_set_font_t(nk_context* ctx, nk_user_font* userfont);
		private delegate int nk_style_set_cursor_t(nk_context* ctx, nk_style_cursor scur);
		private delegate void nk_style_show_cursor_t(nk_context* ctx);
		private delegate void nk_style_hide_cursor_t(nk_context* ctx);

		private delegate int nk_style_push_font_t(nk_context* ctx, nk_user_font* userfont);
		private delegate int nk_style_push_float_t(nk_context* ctx, float* f, float g);
		private delegate int nk_style_push_vec2_t(nk_context* ctx, nk_vec2* a, nk_vec2 b);
		private delegate int nk_style_push_style_item_t(nk_context* ctx, nk_style_item* sitem, nk_style_item sitem2);
		private delegate int nk_style_push_flags_t(nk_context* ctx, uint* a_nkflags, uint b_nkflags);
		private delegate int nk_style_push_color_t(nk_context* ctx, nk_color* a, nk_color b);

		private delegate int nk_style_pop_font_t(nk_context* ctx);
		private delegate int nk_style_pop_float_t(nk_context* ctx);
		private delegate int nk_style_pop_vec2_t(nk_context* ctx);
		private delegate int nk_style_pop_style_item_t(nk_context* ctx);
		private delegate int nk_style_pop_flags_t(nk_context* ctx);
		private delegate int nk_style_pop_color_t(nk_context* ctx);

		private delegate nk_color nk_rgb_t(int r, int g, int b);
		private delegate nk_color nk_rgb_iv_t(int* rgb);
		private delegate nk_color nk_rgb_bv_t(byte* rgb);
		private delegate nk_color nk_rgb_cf_t(nk_colorf c);
		private delegate nk_color nk_rgb_f_t(float r, float g, float b);
		private delegate nk_color nk_rgb_fv_t(float* rgb);
		private delegate nk_color nk_rgb_hex_t(byte* rgb);

		private delegate nk_color nk_rgba_t(int r, int g, int b, int a);
		private delegate nk_color nk_rgba_u32_t(uint rgba);
		private delegate nk_color nk_rgba_iv_t(int* rgba);
		private delegate nk_color nk_rgba_bv_t(byte* rgba);
		private delegate nk_color nk_rgba_cf_t(nk_colorf c);
		private delegate nk_color nk_rgba_f_t(float r, float g, float b, float a);
		private delegate nk_color nk_rgba_fv_t(float* rgba);
		private delegate nk_color nk_rgba_hex_t(float* hsv);

		private delegate nk_color nk_hsva_t(int h, int s, int v, int a);
		private delegate nk_color nk_hsva_iv_t(int* hsva);
		private delegate nk_color nk_hsva_bv_t(byte* hsva);
		private delegate nk_colorf nk_hsva_colorf_t(float h, float s, float v, float a);
		private delegate nk_colorf nk_hsva_colorfv_t(float* c);
		private delegate nk_color nk_hsva_f_t(float h, float s, float v, float a);
		private delegate nk_color nk_hsva_fv_t(float* hsva);

		private delegate void nk_color_f_t(out float r, out float g, out float b, out float a, nk_color src);
		private delegate void nk_color_fv_t(float* rgba_out, nk_color src);
		private delegate nk_colorf nk_color_cf_t(nk_color src);
		private delegate void nk_color_d_t(out double r, out double g, out double b, out double a, nk_color src);
		private delegate void nk_color_dv_t(double* rgba_out, nk_color src);

		private delegate uint nk_color_u32_t(nk_color src);
		private delegate void nk_color_hex_rgba_t(byte* output, nk_color src);
		private delegate void nk_color_hex_rgb_t(byte* output, nk_color src);

		private delegate void nk_color_hsv_i_t(out int h, out int s, out int v, nk_color src);
		private delegate void nk_color_hsv_b_t(out byte h, out byte s, out byte v, nk_color src);
		private delegate void nk_color_hsv_iv_t(int* hsv_out, nk_color src);
		private delegate void nk_color_hsv_bv_t(byte* hsv_out, nk_color src);
		private delegate void nk_color_hsv_f_t(out float h, out float s, out float v, nk_color src);
		private delegate void nk_color_hsv_fv_t(float* hsv_out, nk_color src);

		private delegate void nk_color_hsva_i_t(out int h, out int s, out int v, out int a, nk_color src);
		private delegate void nk_color_hsva_b_t(out byte h, out byte s, out byte v, out byte a, nk_color src);
		private delegate void nk_color_hsva_iv_t(int* hsva_out, nk_color src);
		private delegate void nk_color_hsva_bv_t(byte* hsva_out, nk_color src);
		private delegate void nk_color_hsva_f_t(out float h, out float s, out float v, out float a, nk_color src);
		private delegate void nk_color_hsva_fv_t(float* hsva_out, nk_color src);

		private delegate void nk_colorf_hsva_f_t(out float h, out float s, out float v, out float a, nk_colorf src);
		private delegate void nk_colorf_hsva_fv_t(float* hsva_out, nk_colorf src);













		private static nk_style_default_t _nk_style_default = LFT<nk_style_default_t>();
		private static nk_style_from_table_t _nk_style_from_table = LFT<nk_style_from_table_t>();
		private static nk_style_load_cursor_t _nk_style_load_cursor = LFT<nk_style_load_cursor_t>();
		private static nk_style_load_all_cursors_t _nk_style_load_all_cursors = LFT<nk_style_load_all_cursors_t>();
		private static nk_style_get_color_by_name_t _nk_style_get_color_by_name = LFT<nk_style_get_color_by_name_t>();
		private static nk_style_set_font_t _nk_style_set_font = LFT<nk_style_set_font_t>();
		private static nk_style_set_cursor_t _nk_style_set_cursor = LFT<nk_style_set_cursor_t>();
		private static nk_style_show_cursor_t _nk_style_show_cursor = LFT<nk_style_show_cursor_t>();
		private static nk_style_hide_cursor_t _nk_style_hide_cursor = LFT<nk_style_hide_cursor_t>();
		private static nk_style_push_font_t _nk_style_push_font = LFT<nk_style_push_font_t>();
		private static nk_style_push_float_t _nk_style_push_float = LFT<nk_style_push_float_t>();
		private static nk_style_push_vec2_t _nk_style_push_vec2 = LFT<nk_style_push_vec2_t>();
		private static nk_style_push_style_item_t _nk_style_push_style_item = LFT<nk_style_push_style_item_t>();
		private static nk_style_push_flags_t _nk_style_push_flags = LFT<nk_style_push_flags_t>();
		private static nk_style_push_color_t _nk_style_push_color = LFT<nk_style_push_color_t>();
		private static nk_style_pop_font_t _nk_style_pop_font = LFT<nk_style_pop_font_t>();
		private static nk_style_pop_float_t _nk_style_pop_float = LFT<nk_style_pop_float_t>();
		private static nk_style_pop_vec2_t _nk_style_pop_vec2 = LFT<nk_style_pop_vec2_t>();
		private static nk_style_pop_style_item_t _nk_style_pop_style_item = LFT<nk_style_pop_style_item_t>();
		private static nk_style_pop_flags_t _nk_style_pop_flags = LFT<nk_style_pop_flags_t>();
		private static nk_style_pop_color_t _nk_style_pop_color = LFT<nk_style_pop_color_t>();
		private static nk_rgb_t _nk_rgb = LFT<nk_rgb_t>();
		private static nk_rgb_iv_t _nk_rgb_iv = LFT<nk_rgb_iv_t>();
		private static nk_rgb_bv_t _nk_rgb_bv = LFT<nk_rgb_bv_t>();
		private static nk_rgb_cf_t _nk_rgb_cf = LFT<nk_rgb_cf_t>();
		private static nk_rgb_f_t _nk_rgb_f = LFT<nk_rgb_f_t>();
		private static nk_rgb_fv_t _nk_rgb_fv = LFT<nk_rgb_fv_t>();
		private static nk_rgb_hex_t _nk_rgb_hex = LFT<nk_rgb_hex_t>();
		private static nk_rgba_t _nk_rgba = LFT<nk_rgba_t>();
		private static nk_rgba_u32_t _nk_rgba_u32 = LFT<nk_rgba_u32_t>();
		private static nk_rgba_iv_t _nk_rgba_iv = LFT<nk_rgba_iv_t>();
		private static nk_rgba_bv_t _nk_rgba_bv = LFT<nk_rgba_bv_t>();
		private static nk_rgba_cf_t _nk_rgba_cf = LFT<nk_rgba_cf_t>();
		private static nk_rgba_f_t _nk_rgba_f = LFT<nk_rgba_f_t>();
		private static nk_rgba_fv_t _nk_rgba_fv = LFT<nk_rgba_fv_t>();
		private static nk_rgba_hex_t _nk_rgba_hex = LFT<nk_rgba_hex_t>();
		private static nk_hsva_t _nk_hsva = LFT<nk_hsva_t>();
		private static nk_hsva_iv_t _nk_hsva_iv = LFT<nk_hsva_iv_t>();
		private static nk_hsva_bv_t _nk_hsva_bv = LFT<nk_hsva_bv_t>();
		private static nk_hsva_colorf_t _nk_hsva_colorf = LFT<nk_hsva_colorf_t>();
		private static nk_hsva_colorfv_t _nk_hsva_colorfv = LFT<nk_hsva_colorfv_t>();
		private static nk_hsva_f_t _nk_hsva_f = LFT<nk_hsva_f_t>();
		private static nk_hsva_fv_t _nk_hsva_fv = LFT<nk_hsva_fv_t>();
		private static nk_color_f_t _nk_color_f = LFT<nk_color_f_t>();
		private static nk_color_fv_t _nk_color_fv = LFT<nk_color_fv_t>();
		private static nk_color_cf_t _nk_color_cf = LFT<nk_color_cf_t>();
		private static nk_color_d_t _nk_color_d = LFT<nk_color_d_t>();
		private static nk_color_dv_t _nk_color_dv = LFT<nk_color_dv_t>();
		private static nk_color_u32_t _nk_color_u32 = LFT<nk_color_u32_t>();
		private static nk_color_hex_rgba_t _nk_color_hex_rgba = LFT<nk_color_hex_rgba_t>();
		private static nk_color_hex_rgb_t _nk_color_hex_rgb = LFT<nk_color_hex_rgb_t>();
		private static nk_color_hsv_i_t _nk_color_hsv_i = LFT<nk_color_hsv_i_t>();
		private static nk_color_hsv_b_t _nk_color_hsv_b = LFT<nk_color_hsv_b_t>();
		private static nk_color_hsv_iv_t _nk_color_hsv_iv = LFT<nk_color_hsv_iv_t>();
		private static nk_color_hsv_bv_t _nk_color_hsv_bv = LFT<nk_color_hsv_bv_t>();
		private static nk_color_hsv_f_t _nk_color_hsv_f = LFT<nk_color_hsv_f_t>();
		private static nk_color_hsv_fv_t _nk_color_hsv_fv = LFT<nk_color_hsv_fv_t>();
		private static nk_color_hsva_i_t _nk_color_hsva_i = LFT<nk_color_hsva_i_t>();
		private static nk_color_hsva_b_t _nk_color_hsva_b = LFT<nk_color_hsva_b_t>();
		private static nk_color_hsva_iv_t _nk_color_hsva_iv = LFT<nk_color_hsva_iv_t>();
		private static nk_color_hsva_bv_t _nk_color_hsva_bv = LFT<nk_color_hsva_bv_t>();
		private static nk_color_hsva_f_t _nk_color_hsva_f = LFT<nk_color_hsva_f_t>();
		private static nk_color_hsva_fv_t _nk_color_hsva_fv = LFT<nk_color_hsva_fv_t>();
		private static nk_colorf_hsva_f_t _nk_colorf_hsva_f = LFT<nk_colorf_hsva_f_t>();
		private static nk_colorf_hsva_fv_t _nk_colorf_hsva_fv = LFT<nk_colorf_hsva_fv_t>();




		public static void nk_style_default(nk_context* ctx) => _nk_style_default(ctx);
		public static void nk_style_from_table(nk_context* ctx, nk_color* color) => _nk_style_from_table(ctx, color);
		public static void nk_style_load_cursor(nk_context* ctx, nk_style_cursor scur, nk_cursor* cursor) => _nk_style_load_cursor(ctx, scur, cursor);
		public static void nk_style_load_all_cursors(nk_context* ctx, nk_cursor* cursor) => _nk_style_load_all_cursors(ctx, cursor);
		public static byte* nk_style_get_color_by_name(nk_style_colors scol) => _nk_style_get_color_by_name(scol);
		public static void nk_style_set_font(nk_context* ctx, nk_user_font* userfont) => _nk_style_set_font(ctx, userfont);
		public static int nk_style_set_cursor(nk_context* ctx, nk_style_cursor scur) => _nk_style_set_cursor(ctx, scur);
		public static void nk_style_show_cursor(nk_context* ctx) => _nk_style_show_cursor(ctx);
		public static void nk_style_hide_cursor(nk_context* ctx) => _nk_style_hide_cursor(ctx);
		public static int nk_style_push_font(nk_context* ctx, nk_user_font* userfont) => _nk_style_push_font(ctx, userfont);
		public static int nk_style_push_float(nk_context* ctx, float* f, float g) => _nk_style_push_float(ctx, f, g);
		public static int nk_style_push_vec2(nk_context* ctx, nk_vec2* a, nk_vec2 b) => _nk_style_push_vec2(ctx, a, b);
		public static int nk_style_push_style_item(nk_context* ctx, nk_style_item* sitem, nk_style_item sitem2) => _nk_style_push_style_item(ctx, sitem, sitem2);
		public static int nk_style_push_flags(nk_context* ctx, uint* a_nkflags, uint b_nkflags) => _nk_style_push_flags(ctx, a_nkflags, b_nkflags);
		public static int nk_style_push_color(nk_context* ctx, nk_color* a, nk_color b) => _nk_style_push_color(ctx, a, b);
		public static int nk_style_pop_font(nk_context* ctx) => _nk_style_pop_font(ctx);
		public static int nk_style_pop_float(nk_context* ctx) => _nk_style_pop_float(ctx);
		public static int nk_style_pop_vec2(nk_context* ctx) => _nk_style_pop_vec2(ctx);
		public static int nk_style_pop_style_item(nk_context* ctx) => _nk_style_pop_style_item(ctx);
		public static int nk_style_pop_flags(nk_context* ctx) => _nk_style_pop_flags(ctx);
		public static int nk_style_pop_color(nk_context* ctx) => _nk_style_pop_color(ctx);
		public static nk_color nk_rgb(int r, int g, int b) => _nk_rgb(r, g, b);
		public static nk_color nk_rgb_iv(int* rgb) => _nk_rgb_iv(rgb);
		public static nk_color nk_rgb_bv(byte* rgb) => _nk_rgb_bv(rgb);
		public static nk_color nk_rgb_cf(nk_colorf c) => _nk_rgb_cf(c);
		public static nk_color nk_rgb_f(float r, float g, float b) => _nk_rgb_f(r, g, b);
		public static nk_color nk_rgb_fv(float* rgb) => _nk_rgb_fv(rgb);
		public static nk_color nk_rgb_hex(byte* rgb) => _nk_rgb_hex(rgb);
		public static nk_color nk_rgba(int r, int g, int b, int a) => _nk_rgba(r, g, b, a);
		public static nk_color nk_rgba_u32(uint rgba) => _nk_rgba_u32(rgba);
		public static nk_color nk_rgba_iv(int* rgba) => _nk_rgba_iv(rgba);
		public static nk_color nk_rgba_bv(byte* rgba) => _nk_rgba_bv(rgba);
		public static nk_color nk_rgba_cf(nk_colorf c) => _nk_rgba_cf(c);
		public static nk_color nk_rgba_f(float r, float g, float b, float a) => _nk_rgba_f(r, g, b, a);
		public static nk_color nk_rgba_fv(float* rgba) => _nk_rgba_fv(rgba);
		public static nk_color nk_rgba_hex(float* hsv) => _nk_rgba_hex(hsv);
		public static nk_color nk_hsva(int h, int s, int v, int a) => _nk_hsva(h, s, v, a);
		public static nk_color nk_hsva_iv(int* hsva) => _nk_hsva_iv(hsva);
		public static nk_color nk_hsva_bv(byte* hsva) => _nk_hsva_bv(hsva);
		public static nk_colorf nk_hsva_colorf(float h, float s, float v, float a) => _nk_hsva_colorf(h, s, v, a);
		public static nk_colorf nk_hsva_colorfv(float* c) => _nk_hsva_colorfv(c);
		public static nk_color nk_hsva_f(float h, float s, float v, float a) => _nk_hsva_f(h, s, v, a);
		public static nk_color nk_hsva_fv(float* hsva) => _nk_hsva_fv(hsva);
		public static void nk_color_f(out float r, out float g, out float b, out float a, nk_color src) => _nk_color_f(out r, out g, out b, out a, src);
		public static void nk_color_fv(float* rgba_out, nk_color src) => _nk_color_fv(rgba_out, src);
		public static nk_colorf nk_color_cf(nk_color src) => _nk_color_cf(src);
		public static void nk_color_d(out double r, out double g, out double b, out double a, nk_color src) => _nk_color_d(out r, out g, out b, out a, src);
		public static void nk_color_dv(double* rgba_out, nk_color src) => _nk_color_dv(rgba_out, src);
		public static uint nk_color_u32(nk_color src) => _nk_color_u32(src);
		public static void nk_color_hex_rgba(byte* output, nk_color src) => _nk_color_hex_rgba(output, src);
		public static void nk_color_hex_rgb(byte* output, nk_color src) => _nk_color_hex_rgb(output, src);
		public static void nk_color_hsv_i(out int h, out int s, out int v, nk_color src) => _nk_color_hsv_i(out h, out s, out v, src);
		public static void nk_color_hsv_b(out byte h, out byte s, out byte v, nk_color src) => _nk_color_hsv_b(out h, out s, out v, src);
		public static void nk_color_hsv_iv(int* hsv_out, nk_color src) => _nk_color_hsv_iv(hsv_out, src);
		public static void nk_color_hsv_bv(byte* hsv_out, nk_color src) => _nk_color_hsv_bv(hsv_out, src);
		public static void nk_color_hsv_f(out float h, out float s, out float v, nk_color src) => _nk_color_hsv_f(out h, out s, out v, src);
		public static void nk_color_hsv_fv(float* hsv_out, nk_color src) => _nk_color_hsv_fv(hsv_out, src);
		public static void nk_color_hsva_i(out int h, out int s, out int v, out int a, nk_color src) => _nk_color_hsva_i(out h, out s, out v, out a, src);
		public static void nk_color_hsva_b(out byte h, out byte s, out byte v, out byte a, nk_color src) => _nk_color_hsva_b(out h, out s, out v, out a, src);
		public static void nk_color_hsva_iv(int* hsva_out, nk_color src) => _nk_color_hsva_iv(hsva_out, src);
		public static void nk_color_hsva_bv(byte* hsva_out, nk_color src) => _nk_color_hsva_bv(hsva_out, src);
		public static void nk_color_hsva_f(out float h, out float s, out float v, out float a, nk_color src) => _nk_color_hsva_f(out h, out s, out v, out a, src);
		public static void nk_color_hsva_fv(float* hsva_out, nk_color src) => _nk_color_hsva_fv(hsva_out, src);
		public static void nk_colorf_hsva_f(out float h, out float s, out float v, out float a, nk_colorf src) => _nk_colorf_hsva_f(out h, out s, out v, out a, src);
		public static void nk_colorf_hsva_fv(float* hsva_out, nk_colorf src) => _nk_colorf_hsva_fv(hsva_out, src);



		private delegate nk_style_item nk_style_item_image_t(nk_image img);
		private delegate nk_style_item nk_style_item_color_t(nk_color col);
		private delegate nk_style_item nk_style_item_hide_t();



		private static nk_style_item_image_t _nk_style_item_image = LFT<nk_style_item_image_t>();
		private static nk_style_item_color_t _nk_style_item_color = LFT<nk_style_item_color_t>();
		private static nk_style_item_hide_t _nk_style_item_hide = LFT<nk_style_item_hide_t>();




		public static nk_style_item nk_style_item_image(nk_image img) => _nk_style_item_image(img);
		public static nk_style_item nk_style_item_color(nk_color col) => _nk_style_item_color(col);
		public static nk_style_item nk_style_item_hide() => _nk_style_item_hide();


	}
}
