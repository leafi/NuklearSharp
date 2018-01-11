using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_str
	{
		public nk_buffer buffer;
		public int len;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_clipboard {
		public nk_handle userdata;
		public IntPtr pastefun_nkPluginPasteT;
		public IntPtr copyfun_nkPluginCopyT;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_text_undo_record {
		public int iwhere;
		public short insert_length;
		public short delete_length;
		public short char_storage;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_text_undo_state {
		// fixed nk_text_undo_record undo_rec[99];
		public fixed short undo_rec_nkTextUndoRecord[99 * 6]; // ...?
		public fixed uint undo_char[999];
		public short undo_point;
		public short redo_point;
		public short undo_char_point;
		public short redo_char_point;
	}

	public enum nk_text_edit_type {
		NK_TEXT_EDIT_SINGLE_LINE,
		NK_TEXT_EDIT_MULTI_LINE
	}

	public enum nk_text_edit_mode {
		NK_TEXT_EDIT_MODE_VIEW,
		NK_TEXT_EDIT_MODE_INSERT,
		NK_TEXT_EDIT_MODE_REPLACE
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_text_edit {
		public nk_clipboard clip;
		public nk_str str;
		public IntPtr filter_nkPluginFilterT;
		public nk_vec2 scrollbar;

		public int cursor;
		public int select_start;
		public int select_end;
		public byte mode;
		public byte cursor_at_end_of_line;
		public byte initialized;
		public byte has_preferred_x;
		public byte single_line;
		public byte active;
		public byte padding1;
		public float preferred_x;
		public nk_text_undo_state undo;
	}

	public static unsafe partial class NuklearNative
	{
		private delegate void nk_str_init_t(nk_str* str, nk_allocator* allocator, IntPtr size);
		private delegate void nk_str_init_fixed_t(nk_str* str, IntPtr memory, IntPtr size);
		private delegate void nk_str_clear_t(nk_str* str);
		private delegate void nk_str_free_t(nk_str* str);

		private delegate int nk_str_append_text_char_t(nk_str* str, byte* s, int slen);
		private delegate int nk_str_append_str_char_t(nk_str* str, byte* s);
		private delegate int nk_str_append_text_utf8_t(nk_str* str, byte* s, int slen);
		private delegate int nk_str_append_str_utf8_t(nk_str* str, byte* s);
		private delegate int nk_str_append_text_runes_t(nk_str* str, uint* runes, int len);
		private delegate int nk_str_append_str_runes_t(nk_str* str, uint* runes);

		private delegate int nk_str_insert_at_char_t(nk_str* str, int pos, byte* s, int slen);
		private delegate int nk_str_insert_at_rune_t(nk_str* str, int pos, byte* s, int slen);

		private delegate int nk_str_insert_text_char_t(nk_str* str, int pos, byte* s, int slen);
		private delegate int nk_str_insert_str_char_t(nk_str* str, int pos, byte* s);
		private delegate int nk_str_insert_text_utf8_t(nk_str* str, int pos, byte* s, int slen);
		private delegate int nk_str_insert_str_utf8_t(nk_str* str, int pos, byte* s);
		private delegate int nk_str_insert_text_runes_t(nk_str* str, int pos, uint* runes, int slen);
		private delegate int nk_str_insert_str_runes_t(nk_str* str, int pos, uint* runes);

		private delegate void nk_str_remove_chars_t(nk_str* str, int len);
		private delegate void nk_str_remove_runes_t(nk_str* str, int len);
		private delegate void nk_str_delete_chars_t(nk_str* str, int pos, int len);
		private delegate void nk_str_delete_runes_t(nk_str* str, int pos, int len);

		private delegate byte* nk_str_at_char_t(nk_str* str, int pos);
		private delegate byte* nk_str_at_rune_t(nk_str* str, int pos, uint* unicode, int* len);
		private delegate uint nk_str_rune_at_t(nk_str* str, int pos);
		private delegate char* nk_str_at_char_const_t(nk_str* str, int pos);
		private delegate char* nk_str_at_const_t(nk_str* str, int pos, uint* unicode, int* len);

		private delegate char* nk_str_get_t(nk_str* str);
		private delegate char* nk_str_get_const_t(nk_str* str);
		private delegate int nk_str_len_t(nk_str* str);
		private delegate int nk_str_len_char_t(nk_str* str);

		private delegate int nk_filter_default_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_ascii_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_float_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_decimal_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_hex_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_oct_t(nk_text_edit* te, uint unicode);
		private delegate int nk_filter_binary_t(nk_text_edit* te, uint unicode);

		private delegate void nk_textedit_init_t(nk_text_edit* te, nk_allocator* alloc, IntPtr size);
		private delegate void nk_textedit_init_fixed_t(nk_text_edit* te, IntPtr memory, IntPtr size);
		private delegate void nk_textedit_free_t(nk_text_edit* te);
		private delegate void nk_textedit_text_t(nk_text_edit* te, byte* s, int total_len);
		private delegate void nk_textedit_delete_t(nk_text_edit* te, int where, int len);
		private delegate void nk_textedit_delete_selection_t(nk_text_edit* te);
		private delegate void nk_textedit_select_all_t(nk_text_edit* te);
		private delegate int nk_textedit_cut_t(nk_text_edit* te);
		private delegate int nk_textedit_paste_t(nk_text_edit* te, byte* s, int len);
		private delegate void nk_textedit_undo_t(nk_text_edit* te);
		private delegate void nk_textedit_redo_t(nk_text_edit* te);




		private static nk_str_init_t _nk_str_init = LFT<nk_str_init_t>();
		private static nk_str_init_fixed_t _nk_str_init_fixed = LFT<nk_str_init_fixed_t>();
		private static nk_str_clear_t _nk_str_clear = LFT<nk_str_clear_t>();
		private static nk_str_free_t _nk_str_free = LFT<nk_str_free_t>();
		private static nk_str_append_text_char_t _nk_str_append_text_char = LFT<nk_str_append_text_char_t>();
		private static nk_str_append_str_char_t _nk_str_append_str_char = LFT<nk_str_append_str_char_t>();
		private static nk_str_append_text_utf8_t _nk_str_append_text_utf8 = LFT<nk_str_append_text_utf8_t>();
		private static nk_str_append_str_utf8_t _nk_str_append_str_utf8 = LFT<nk_str_append_str_utf8_t>();
		private static nk_str_append_text_runes_t _nk_str_append_text_runes = LFT<nk_str_append_text_runes_t>();
		private static nk_str_append_str_runes_t _nk_str_append_str_runes = LFT<nk_str_append_str_runes_t>();
		private static nk_str_insert_at_char_t _nk_str_insert_at_char = LFT<nk_str_insert_at_char_t>();
		private static nk_str_insert_at_rune_t _nk_str_insert_at_rune = LFT<nk_str_insert_at_rune_t>();
		private static nk_str_insert_text_char_t _nk_str_insert_text_char = LFT<nk_str_insert_text_char_t>();
		private static nk_str_insert_str_char_t _nk_str_insert_str_char = LFT<nk_str_insert_str_char_t>();
		private static nk_str_insert_text_utf8_t _nk_str_insert_text_utf8 = LFT<nk_str_insert_text_utf8_t>();
		private static nk_str_insert_str_utf8_t _nk_str_insert_str_utf8 = LFT<nk_str_insert_str_utf8_t>();
		private static nk_str_insert_text_runes_t _nk_str_insert_text_runes = LFT<nk_str_insert_text_runes_t>();
		private static nk_str_insert_str_runes_t _nk_str_insert_str_runes = LFT<nk_str_insert_str_runes_t>();
		private static nk_str_remove_chars_t _nk_str_remove_chars = LFT<nk_str_remove_chars_t>();
		private static nk_str_remove_runes_t _nk_str_remove_runes = LFT<nk_str_remove_runes_t>();
		private static nk_str_delete_chars_t _nk_str_delete_chars = LFT<nk_str_delete_chars_t>();
		private static nk_str_delete_runes_t _nk_str_delete_runes = LFT<nk_str_delete_runes_t>();
		private static nk_str_at_char_t _nk_str_at_char = LFT<nk_str_at_char_t>();
		private static nk_str_at_rune_t _nk_str_at_rune = LFT<nk_str_at_rune_t>();
		private static nk_str_rune_at_t _nk_str_rune_at = LFT<nk_str_rune_at_t>();
		private static nk_str_at_char_const_t _nk_str_at_char_const = LFT<nk_str_at_char_const_t>();
		private static nk_str_at_const_t _nk_str_at_const = LFT<nk_str_at_const_t>();
		private static nk_str_get_t _nk_str_get = LFT<nk_str_get_t>();
		private static nk_str_get_const_t _nk_str_get_const = LFT<nk_str_get_const_t>();
		private static nk_str_len_t _nk_str_len = LFT<nk_str_len_t>();
		private static nk_str_len_char_t _nk_str_len_char = LFT<nk_str_len_char_t>();
		private static nk_filter_default_t _nk_filter_default = LFT<nk_filter_default_t>();
		private static nk_filter_ascii_t _nk_filter_ascii = LFT<nk_filter_ascii_t>();
		private static nk_filter_float_t _nk_filter_float = LFT<nk_filter_float_t>();
		private static nk_filter_decimal_t _nk_filter_decimal = LFT<nk_filter_decimal_t>();
		private static nk_filter_hex_t _nk_filter_hex = LFT<nk_filter_hex_t>();
		private static nk_filter_oct_t _nk_filter_oct = LFT<nk_filter_oct_t>();
		private static nk_filter_binary_t _nk_filter_binary = LFT<nk_filter_binary_t>();
		private static nk_textedit_init_t _nk_textedit_init = LFT<nk_textedit_init_t>();
		private static nk_textedit_init_fixed_t _nk_textedit_init_fixed = LFT<nk_textedit_init_fixed_t>();
		private static nk_textedit_free_t _nk_textedit_free = LFT<nk_textedit_free_t>();
		private static nk_textedit_text_t _nk_textedit_text = LFT<nk_textedit_text_t>();
		private static nk_textedit_delete_t _nk_textedit_delete = LFT<nk_textedit_delete_t>();
		private static nk_textedit_delete_selection_t _nk_textedit_delete_selection = LFT<nk_textedit_delete_selection_t>();
		private static nk_textedit_select_all_t _nk_textedit_select_all = LFT<nk_textedit_select_all_t>();
		private static nk_textedit_cut_t _nk_textedit_cut = LFT<nk_textedit_cut_t>();
		private static nk_textedit_paste_t _nk_textedit_paste = LFT<nk_textedit_paste_t>();
		private static nk_textedit_undo_t _nk_textedit_undo = LFT<nk_textedit_undo_t>();
		private static nk_textedit_redo_t _nk_textedit_redo = LFT<nk_textedit_redo_t>();




		public static void nk_str_init(nk_str* str, nk_allocator* allocator, IntPtr size) => _nk_str_init(str, allocator, size);
		public static void nk_str_init_fixed(nk_str* str, IntPtr memory, IntPtr size) => _nk_str_init_fixed(str, memory, size);
		public static void nk_str_clear(nk_str* str) => _nk_str_clear(str);
		public static void nk_str_free(nk_str* str) => _nk_str_free(str);
		public static int nk_str_append_text_char(nk_str* str, byte* s, int slen) => _nk_str_append_text_char(str, s, slen);
		public static int nk_str_append_str_char(nk_str* str, byte* s) => _nk_str_append_str_char(str, s);
		public static int nk_str_append_text_utf8(nk_str* str, byte* s, int slen) => _nk_str_append_text_utf8(str, s, slen);
		public static int nk_str_append_str_utf8(nk_str* str, byte* s) => _nk_str_append_str_utf8(str, s);
		public static int nk_str_append_text_runes(nk_str* str, uint* runes, int len) => _nk_str_append_text_runes(str, runes, len);
		public static int nk_str_append_str_runes(nk_str* str, uint* runes) => _nk_str_append_str_runes(str, runes);
		public static int nk_str_insert_at_char(nk_str* str, int pos, byte* s, int slen) => _nk_str_insert_at_char(str, pos, s, slen);
		public static int nk_str_insert_at_rune(nk_str* str, int pos, byte* s, int slen) => _nk_str_insert_at_rune(str, pos, s, slen);
		public static int nk_str_insert_text_char(nk_str* str, int pos, byte* s, int slen) => _nk_str_insert_text_char(str, pos, s, slen);
		public static int nk_str_insert_str_char(nk_str* str, int pos, byte* s) => _nk_str_insert_str_char(str, pos, s);
		public static int nk_str_insert_text_utf8(nk_str* str, int pos, byte* s, int slen) => _nk_str_insert_text_utf8(str, pos, s, slen);
		public static int nk_str_insert_str_utf8(nk_str* str, int pos, byte* s) => _nk_str_insert_str_utf8(str, pos, s);
		public static int nk_str_insert_text_runes(nk_str* str, int pos, uint* runes, int slen) => _nk_str_insert_text_runes(str, pos, runes, slen);
		public static int nk_str_insert_str_runes(nk_str* str, int pos, uint* runes) => _nk_str_insert_str_runes(str, pos, runes);
		public static void nk_str_remove_chars(nk_str* str, int len) => _nk_str_remove_chars(str, len);
		public static void nk_str_remove_runes(nk_str* str, int len) => _nk_str_remove_runes(str, len);
		public static void nk_str_delete_chars(nk_str* str, int pos, int len) => _nk_str_delete_chars(str, pos, len);
		public static void nk_str_delete_runes(nk_str* str, int pos, int len) => _nk_str_delete_runes(str, pos, len);
		public static byte* nk_str_at_char(nk_str* str, int pos) => _nk_str_at_char(str, pos);
		public static byte* nk_str_at_rune(nk_str* str, int pos, uint* unicode, int* len) => _nk_str_at_rune(str, pos, unicode, len);
		public static uint nk_str_rune_at(nk_str* str, int pos) => _nk_str_rune_at(str, pos);
		public static char* nk_str_at_char_const(nk_str* str, int pos) => _nk_str_at_char_const(str, pos);
		public static char* nk_str_at_const(nk_str* str, int pos, uint* unicode, int* len) => _nk_str_at_const(str, pos, unicode, len);
		public static char* nk_str_get(nk_str* str) => _nk_str_get(str);
		public static char* nk_str_get_const(nk_str* str) => _nk_str_get_const(str);
		public static int nk_str_len(nk_str* str) => _nk_str_len(str);
		public static int nk_str_len_char(nk_str* str) => _nk_str_len_char(str);
		public static int nk_filter_default(nk_text_edit* te, uint unicode) => _nk_filter_default(te, unicode);
		public static int nk_filter_ascii(nk_text_edit* te, uint unicode) => _nk_filter_ascii(te, unicode);
		public static int nk_filter_float(nk_text_edit* te, uint unicode) => _nk_filter_float(te, unicode);
		public static int nk_filter_decimal(nk_text_edit* te, uint unicode) => _nk_filter_decimal(te, unicode);
		public static int nk_filter_hex(nk_text_edit* te, uint unicode) => _nk_filter_hex(te, unicode);
		public static int nk_filter_oct(nk_text_edit* te, uint unicode) => _nk_filter_oct(te, unicode);
		public static int nk_filter_binary(nk_text_edit* te, uint unicode) => _nk_filter_binary(te, unicode);
		public static void nk_textedit_init(nk_text_edit* te, nk_allocator* alloc, IntPtr size) => _nk_textedit_init(te, alloc, size);
		public static void nk_textedit_init_fixed(nk_text_edit* te, IntPtr memory, IntPtr size) => _nk_textedit_init_fixed(te, memory, size);
		public static void nk_textedit_free(nk_text_edit* te) => _nk_textedit_free(te);
		public static void nk_textedit_text(nk_text_edit* te, byte* s, int total_len) => _nk_textedit_text(te, s, total_len);
		public static void nk_textedit_delete(nk_text_edit* te, int where, int len) => _nk_textedit_delete(te, where, len);
		public static void nk_textedit_delete_selection(nk_text_edit* te) => _nk_textedit_delete_selection(te);
		public static void nk_textedit_select_all(nk_text_edit* te) => _nk_textedit_select_all(te);
		public static int nk_textedit_cut(nk_text_edit* te) => _nk_textedit_cut(te);
		public static int nk_textedit_paste(nk_text_edit* te, byte* s, int len) => _nk_textedit_paste(te, s, len);
		public static void nk_textedit_undo(nk_text_edit* te) => _nk_textedit_undo(te);
		public static void nk_textedit_redo(nk_text_edit* te) => _nk_textedit_redo(te);



	}
}
