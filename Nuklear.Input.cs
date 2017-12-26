using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	public enum nk_keys : byte {
		NK_KEY_NONE,
		NK_KEY_SHIFT,
		NK_KEY_CTRL,
		NK_KEY_DEL,
		NK_KEY_ENTER,
		NK_KEY_TAB,
		NK_KEY_BACKSPACE,
		NK_KEY_COPY,
		NK_KEY_CUT,
		NK_KEY_PASTE,
		NK_KEY_UP,
		NK_KEY_DOWN,
		NK_KEY_LEFT,
		NK_KEY_RIGHT,

		NK_KEY_TEXT_INSERT_MODE,
		NK_KEY_TEXT_REPLACE_MODE,
		NK_KEY_TEXT_RESET_MODE,
		NK_KEY_TEXT_LINE_START,
		NK_KEY_TEXT_LINE_END,
		NK_KEY_TEXT_START,
		NK_KEY_TEXT_END,
		NK_KEY_TEXT_UNDO,
		NK_KEY_TEXT_REDO,
		NK_KEY_TEXT_SELECT_ALL,
		NK_KEY_TEXT_WORD_LEFT,
		NK_KEY_TEXT_WORD_RIGHT,

		NK_KEY_SCROLL_START,
		NK_KEY_SCROLL_END,
		NK_KEY_SCROLL_DOWN,
		NK_KEY_SCROLL_UP,
		NK_KEY_MAX
	}

	public enum nk_buttons : byte {
		NK_BUTTON_LEFT,
		NK_BUTTON_MIDDLE,
		NK_BUTTON_RIGHT,
		NK_BUTTON_DOUBLE,
		NK_BUTTON_MAX
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_mouse_button {
		int down;
		uint clicked;
		nk_vec2 clicked_pos;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_mouse {
		/* fixed nk_mouse_button buttons[(int)(nk_buttons.NK_BUTTON_MAX)]; */
		nk_mouse_button buttonLeft;
		nk_mouse_button buttonMiddle;
		nk_mouse_button buttonRight;
		nk_mouse_button buttonDouble;

		nk_vec2 pos;
		nk_vec2 prev;
		nk_vec2 delta;
		nk_vec2 scroll_delta;

		byte grab;
		byte grabbed;
		byte ungrab;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_key {
		int down;
		uint clicked;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_keyboard {
		fixed long keysCastMeToNkKey[(int)(nk_keys.NK_KEY_MAX)];
		fixed byte text[16];
		int text_len;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_input {
		nk_keyboard keyboard;
		nk_mouse mouse;
	}

	public static unsafe partial class NuklearNative
	{
		private delegate void nk_input_begin_t(nk_context* context);
		private static nk_input_begin_t _nk_input_begin = LoadFunction<nk_input_begin_t>("nk_input_begin");
		public static void nk_input_begin(nk_context* context) => _nk_input_begin(context);

		private delegate void nk_input_motion_t(nk_context* context, int x, int y);
		private static nk_input_motion_t _nk_input_motion = LoadFunction<nk_input_motion_t>("nk_input_motion");
		public static void nk_input_motion(nk_context* context, int x, int y) => _nk_input_motion(context, x, y);

		private delegate void nk_input_key_t(nk_context* context, nk_keys keys, int down);
		private static nk_input_key_t _nk_input_key = LoadFunction<nk_input_key_t>("nk_input_key");
		public static void nk_input_key(nk_context* context, nk_keys keys, int down) => _nk_input_key(context, keys, down);

		private delegate void nk_input_button_t(nk_context* context, nk_buttons buttons, int x, int y, int down);
		private static nk_input_button_t _nk_input_button = LoadFunction<nk_input_button_t>("nk_input_button");
		public static void nk_input_button(nk_context* context, nk_buttons buttons, int x, int y, int down) => _nk_input_button(context, buttons, x, y, down);

		private delegate void nk_input_scroll_t(nk_context* context, nk_vec2 val);
		private static nk_input_scroll_t _nk_input_scroll = LoadFunction<nk_input_scroll_t>("nk_input_scroll");
		public static void nk_input_scroll(nk_context* context, nk_vec2 val) => _nk_input_scroll(context, val);

		private delegate void nk_input_char_t(nk_context* context, byte c);
		private static nk_input_char_t _nk_input_char = LFT<nk_input_char_t>();
		public static void nk_input_char(nk_context* context, byte c) => _nk_input_char(context, c);

		private delegate void nk_input_glyph_t(nk_context* context, nk_glyph glyph);
		private static nk_input_glyph_t _nk_input_glyph = LFT<nk_input_glyph_t>();
		public static void nk_input_glyph(nk_context* context, nk_glyph glyph) => _nk_input_glyph(context, glyph);

		private delegate void nk_input_unicode_t(nk_context* context, uint rune);
		private static nk_input_unicode_t _nk_input_unicode = LFT<nk_input_unicode_t>();
		public static void nk_input_unicode(nk_context* context, uint rune) => _nk_input_unicode(context, rune);

		private delegate void nk_input_end_t(nk_context* context);
		private static nk_input_end_t _nk_input_end = LFT<nk_input_end_t>();
		public static void nk_input_end(nk_context* context) => _nk_input_end(context);




		private delegate int nk_input_has_mouse_click_t(nk_input* inp, nk_buttons buttons);
		private delegate int nk_input_has_mouse_click_in_rect_t(nk_input* inp, nk_buttons buttons, nk_rect r);
		private delegate int nk_input_has_mouse_click_down_in_rect_t(nk_input* inp, nk_buttons buttons, nk_rect r, int down);
		private delegate int nk_input_is_mouse_click_in_rect_t(nk_input* inp, nk_buttons buttons, nk_rect r);
		private delegate int nk_input_is_mouse_click_down_in_rect_t(nk_input* inp, nk_buttons id, nk_rect b, int down);
		private delegate int nk_input_any_mouse_click_in_rect_t(nk_input* inp, nk_rect r);
		private delegate int nk_input_is_mouse_prev_hovering_rect_t(nk_input* inp, nk_rect r);
		private delegate int nk_input_is_mouse_hovering_rect_t(nk_input* inp, nk_rect r);
		private delegate int nk_input_mouse_clicked_t(nk_input* inp, nk_buttons buttons, nk_rect r);
		private delegate int nk_input_is_mouse_down_t(nk_input* inp, nk_buttons buttons);
		private delegate int nk_input_is_mouse_pressed_t(nk_input* inp, nk_buttons buttons);
		private delegate int nk_input_is_mouse_released_t(nk_input* inp, nk_buttons buttons);
		private delegate int nk_input_is_key_pressed_t(nk_input* inp, nk_keys keys);
		private delegate int nk_input_is_key_released_t(nk_input* inp, nk_keys keys);
		private delegate int nk_input_is_key_down_t(nk_input* inp, nk_keys keys);




		private static nk_input_has_mouse_click_t _nk_input_has_mouse_click = LFT<nk_input_has_mouse_click_t>();
		private static nk_input_has_mouse_click_in_rect_t _nk_input_has_mouse_click_in_rect = LFT<nk_input_has_mouse_click_in_rect_t>();
		private static nk_input_has_mouse_click_down_in_rect_t _nk_input_has_mouse_click_down_in_rect = LFT<nk_input_has_mouse_click_down_in_rect_t>();
		private static nk_input_is_mouse_click_in_rect_t _nk_input_is_mouse_click_in_rect = LFT<nk_input_is_mouse_click_in_rect_t>();
		private static nk_input_is_mouse_click_down_in_rect_t _nk_input_is_mouse_click_down_in_rect = LFT<nk_input_is_mouse_click_down_in_rect_t>();
		private static nk_input_any_mouse_click_in_rect_t _nk_input_any_mouse_click_in_rect = LFT<nk_input_any_mouse_click_in_rect_t>();
		private static nk_input_is_mouse_prev_hovering_rect_t _nk_input_is_mouse_prev_hovering_rect = LFT<nk_input_is_mouse_prev_hovering_rect_t>();
		private static nk_input_is_mouse_hovering_rect_t _nk_input_is_mouse_hovering_rect = LFT<nk_input_is_mouse_hovering_rect_t>();
		private static nk_input_mouse_clicked_t _nk_input_mouse_clicked = LFT<nk_input_mouse_clicked_t>();
		private static nk_input_is_mouse_down_t _nk_input_is_mouse_down = LFT<nk_input_is_mouse_down_t>();
		private static nk_input_is_mouse_pressed_t _nk_input_is_mouse_pressed = LFT<nk_input_is_mouse_pressed_t>();
		private static nk_input_is_mouse_released_t _nk_input_is_mouse_released = LFT<nk_input_is_mouse_released_t>();
		private static nk_input_is_key_pressed_t _nk_input_is_key_pressed = LFT<nk_input_is_key_pressed_t>();
		private static nk_input_is_key_released_t _nk_input_is_key_released = LFT<nk_input_is_key_released_t>();
		private static nk_input_is_key_down_t _nk_input_is_key_down = LFT<nk_input_is_key_down_t>();




		public static int nk_input_has_mouse_click(nk_input* inp, nk_buttons buttons) => _nk_input_has_mouse_click(inp, buttons);
		public static int nk_input_has_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r) => _nk_input_has_mouse_click_in_rect(inp, buttons, r);
		public static int nk_input_has_mouse_click_down_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r, int down) => _nk_input_has_mouse_click_down_in_rect(inp, buttons, r, down);
		public static int nk_input_is_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r) => _nk_input_is_mouse_click_in_rect(inp, buttons, r);
		public static int nk_input_is_mouse_click_down_in_rect(nk_input* inp, nk_buttons id, nk_rect b, int down) => _nk_input_is_mouse_click_down_in_rect(inp, id, b, down);
		public static int nk_input_any_mouse_click_in_rect(nk_input* inp, nk_rect r) => _nk_input_any_mouse_click_in_rect(inp, r);
		public static int nk_input_is_mouse_prev_hovering_rect(nk_input* inp, nk_rect r) => _nk_input_is_mouse_prev_hovering_rect(inp, r);
		public static int nk_input_is_mouse_hovering_rect(nk_input* inp, nk_rect r) => _nk_input_is_mouse_hovering_rect(inp, r);
		public static int nk_input_mouse_clicked(nk_input* inp, nk_buttons buttons, nk_rect r) => _nk_input_mouse_clicked(inp, buttons, r);
		public static int nk_input_is_mouse_down(nk_input* inp, nk_buttons buttons) => _nk_input_is_mouse_down(inp, buttons);
		public static int nk_input_is_mouse_pressed(nk_input* inp, nk_buttons buttons) => _nk_input_is_mouse_pressed(inp, buttons);
		public static int nk_input_is_mouse_released(nk_input* inp, nk_buttons buttons) => _nk_input_is_mouse_released(inp, buttons);
		public static int nk_input_is_key_pressed(nk_input* inp, nk_keys keys) => _nk_input_is_key_pressed(inp, keys);
		public static int nk_input_is_key_released(nk_input* inp, nk_keys keys) => _nk_input_is_key_released(inp, keys);
		public static int nk_input_is_key_down(nk_input* inp, nk_keys keys) => _nk_input_is_key_down(inp, keys);



	}
}
