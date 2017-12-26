using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	[Flags]
	public enum nk_panel_flags
	{
		NK_WINDOW_BORDER = (1 << (0)),
		NK_WINDOW_MOVABLE = (1 << (1)),
		NK_WINDOW_SCALABLE = (1 << (2)),
		NK_WINDOW_CLOSABLE = (1 << (3)),
		NK_WINDOW_MINIMIZABLE = (1 << (4)),
		NK_WINDOW_NO_SCROLLBAR = (1 << (5)),
		NK_WINDOW_TITLE = (1 << (6)),
		NK_WINDOW_SCROLL_AUTO_HIDE = (1 << (7)),
		NK_WINDOW_BACKGROUND = (1 << (8)),
		NK_WINDOW_SCALE_LEFT = (1 << (9)),
		NK_WINDOW_NO_INPUT = (1 << (10))
	}

	[Flags]
	public enum nk_panel_type
	{
		NK_PANEL_WINDOW = (1 << (0)),
		NK_PANEL_GROUP = (1 << (1)),
		NK_PANEL_POPUP = (1 << (2)),
		NK_PANEL_CONTEXTUAL = (1 << (4)),
		NK_PANEL_COMBO = (1 << (5)),
		NK_PANEL_MENU = (1 << (6)),
		NK_PANEL_TOOLTIP = (1 << (7))
	}

	public enum nk_panel_set
	{
		NK_PANEL_SET_NONBLOCK = nk_panel_type.NK_PANEL_CONTEXTUAL | nk_panel_type.NK_PANEL_COMBO | nk_panel_type.NK_PANEL_MENU | nk_panel_type.NK_PANEL_TOOLTIP,
		NK_PANEL_SET_POPUP = NK_PANEL_SET_NONBLOCK | nk_panel_type.NK_PANEL_POPUP,
		NK_PANEL_SET_SUB = NK_PANEL_SET_POPUP | nk_panel_type.NK_PANEL_GROUP
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_chart_slot
	{
		nk_chart_type type;
		nk_color color;
		nk_color highlight;
		float min;
		float max;
		float range;
		int count;
		nk_vec2 last;
		int index;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_chart
	{
		int slot;
		float x;
		float y;
		float w;
		float h;
		nk_chart_slot slot0;
		nk_chart_slot slot1;
		nk_chart_slot slot2;
		nk_chart_slot slot3;
	}

	public enum nk_panel_row_layout_type
	{
		NK_LAYOUT_DYNAMIC_FIXED = 0,
		NK_LAYOUT_DYNAMIC_ROW,
		NK_LAYOUT_DYNAMIC_FREE,
		NK_LAYOUT_DYNAMIC,
		NK_LAYOUT_STATIC_FIXED,
		NK_LAYOUT_STATIC_ROW,
		NK_LAYOUT_STATIC_FREE,
		NK_LAYOUT_STATIC,
		NK_LAYOUT_TEMPLATE,
		NK_LAYOUT_COUNT
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_row_layout
	{
		nk_panel_row_layout_type type;
		int index;
		float height;
		float min_height;
		int columns;
		float* ratio;
		float item_width;
		float item_height;
		float item_offset;
		float filled;
		nk_rect item;
		int tree_depth;
		fixed float templates[16];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_popup_buffer
	{
		IntPtr begin_nksize;
		IntPtr parent_nksize;
		IntPtr last_nksize;
		IntPtr end_nksize;
		int active;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_menu_state
	{
		float x;
		float y;
		float w;
		float h;
		nk_scroll offset;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_panel
	{
		nk_panel_type type;
		uint flags_nkflags;
		nk_rect bounds;
		uint* offset_x;
		uint* offset_y;
		float at_x;
		float at_y;
		float max_x;
		float footer_height;
		float header_height;
		float border;
		uint has_scrolling;
		nk_rect clip;
		nk_menu_state menu;
		nk_row_layout row;
		nk_chart chart;
		nk_command_buffer* buffer;
		nk_panel* parent;
	}

	[Flags]
	public enum nk_window_flags : int
	{
		NK_WINDOW_PRIVATE = (1 << (11)),
		NK_WINDOW_DYNAMIC = NK_WINDOW_PRIVATE,
		NK_WINDOW_ROM = (1 << (12)),
		NK_WINDOW_NOT_INTERACTIVE = NK_WINDOW_ROM | nk_panel_flags.NK_WINDOW_NO_INPUT,
		NK_WINDOW_HIDDEN = (1 << (13)),
		NK_WINDOW_CLOSED = (1 << (14)),
		NK_WINDOW_MINIMIZED = (1 << (15)),
		NK_WINDOW_REMOVE_ROM = (1 << (16))
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_popup_state
	{
		nk_window* win;
		nk_panel_type type;
		nk_popup_buffer buf;
		uint name_nkhash;
		int active;
		uint combo_count;
		uint con_count;
		uint con_old;
		uint active_con;
		nk_rect header;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct nk_edit_state
	{
		uint name_nkhash;
		uint seq;
		uint old;
		int active;
		int prev;
		int cursor;
		int sel_start;
		int sel_end;
		nk_scroll scrollbar;
		byte mode;
		byte single_line;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_property_state
	{
		int active;
		int prev;
		fixed byte buffer[64];
		int length;
		int cursor;
		int select_start;
		int select_end;
		uint name_nkhash;
		uint seq;
		uint old;
		int state;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_window
	{
		uint seq;
		uint name_nkhash;
		fixed byte name_string[64];
		uint flags_nkflags;

		nk_rect bounds;
		nk_scroll scrollbar;
		nk_command_buffer buffer;
		nk_panel* layout;
		float scrollbar_hiding_timer;

		nk_property_state property;
		nk_popup_state popup;
		nk_edit_state edit;
		uint scrolled;

		nk_table* tables;
		uint table_count;

		nk_window* next;
		nk_window* prev;
		nk_window* parent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct nk_list_view {
		int begin;
		int end;
		int count;

		int total_height;
		nk_context* ctx;
		uint* scroll_pointer;
		uint scroll_value;
	}

	public enum nk_widget_layout_states {
		NK_WIDGET_INVALID,
		NK_WIDGET_VALID,
		NK_WIDGET_ROM
	}

	[Flags]
	public enum nk_widget_states {
		NK_WIDGET_STATE_MODIFIED = (1 << (1)),
		NK_WIDGET_STATE_INACTIVE = (1 << (2)),
		NK_WIDGET_STATE_ENTERED = (1 << (3)),
		NK_WIDGET_STATE_HOVER = (1 << (4)),
		NK_WIDGET_STATE_ACTIVED = (1 << (5)),
		NK_WIDGET_STATE_LEFT = (1 << (6)),
		NK_WIDGET_STATE_HOVERED = NK_WIDGET_STATE_HOVER | NK_WIDGET_STATE_MODIFIED,
		NK_WIDGET_STATE_ACTIVE = NK_WIDGET_STATE_ACTIVED | NK_WIDGET_STATE_MODIFIED
	}

	[Flags]
	public enum nk_text_align {
		NK_TEXT_ALIGN_LEFT = 0x01,
		NK_TEXT_ALIGN_CENTERED = 0x02,
		NK_TEXT_ALIGN_RIGHT = 0x04,
		NK_TEXT_ALIGN_TOP = 0x08,
		NK_TEXT_ALIGN_MIDDLE = 0x10,
		NK_TEXT_ALIGN_BOTTOM = 0x20
	}

	public enum nk_text_alignment {
		NK_TEXT_LEFT = nk_text_align.NK_TEXT_ALIGN_MIDDLE | nk_text_align.NK_TEXT_ALIGN_LEFT,
		NK_TEXT_CENTERED = nk_text_align.NK_TEXT_ALIGN_MIDDLE | nk_text_align.NK_TEXT_ALIGN_CENTERED,
		NK_TEXT_RIGHT = nk_text_align.NK_TEXT_ALIGN_MIDDLE | nk_text_align.NK_TEXT_ALIGN_RIGHT
	}

	[Flags]
	public enum nk_edit_flags {
		NK_EDIT_DEFAULT = 0,
		NK_EDIT_READ_ONLY = (1 << (0)),
		NK_EDIT_AUTO_SELECT = (1 << (1)),
		NK_EDIT_SIG_ENTER = (1 << (2)),
		NK_EDIT_ALLOW_TAB = (1 << (3)),
		NK_EDIT_NO_CURSOR = (1 << (4)),
		NK_EDIT_SELECTABLE = (1 << (5)),
		NK_EDIT_CLIPBOARD = (1 << (6)),
		NK_EDIT_CTRL_ENTER_NEWLINE = (1 << (7)),
		NK_EDIT_NO_HORIZONTAL_SCROLL = (1 << (8)),
		NK_EDIT_ALWAYS_INSERT_MODE = (1 << (9)),
		NK_EDIT_MULTILINE = (1 << (10)),
		NK_EDIT_GOTO_END_ON_ACTIVATE = (1 << (11))
	}

	public enum nk_edit_types {
		NK_EDIT_SIMPLE = nk_edit_flags.NK_EDIT_ALWAYS_INSERT_MODE,
		NK_EDIT_FIELD = NK_EDIT_SIMPLE | nk_edit_flags.NK_EDIT_SELECTABLE | nk_edit_flags.NK_EDIT_CLIPBOARD,
		NK_EDIT_BOX = nk_edit_flags.NK_EDIT_ALWAYS_INSERT_MODE | nk_edit_flags.NK_EDIT_SELECTABLE | nk_edit_flags.NK_EDIT_MULTILINE | nk_edit_flags.NK_EDIT_ALLOW_TAB | nk_edit_flags.NK_EDIT_CLIPBOARD,
		NK_EDIT_EDITOR = nk_edit_flags.NK_EDIT_SELECTABLE | nk_edit_flags.NK_EDIT_MULTILINE | nk_edit_flags.NK_EDIT_ALLOW_TAB | nk_edit_flags.NK_EDIT_CLIPBOARD
	}

	[Flags]
	public enum nk_edit_events {
		NK_EDIT_ACTIVE = (1 << (0)),
		NK_EDIT_INACTIVE = (1 << (1)),
		NK_EDIT_ACTIVATED = (1 << (2)),
		NK_EDIT_DEACTIVATED = (1 << (3)),
		NK_EDIT_COMMITED = (1 << (4))
	}

	public delegate float nk_value_getter_fun(IntPtr user, int index);

	public unsafe delegate void nk_item_getter_fun(IntPtr user, int i, byte** idk);

	public static unsafe partial class NuklearNative
	{
		private delegate nk_window* nk_window_find_t(nk_context* ctx, byte* name);
		private delegate nk_rect nk_window_get_bounds_t(nk_context* ctx);
		private delegate nk_vec2 nk_window_get_position_t(nk_context* ctx);
		private delegate nk_vec2 nk_window_get_size_t(nk_context* ctx);
		private delegate float nk_window_get_width_t(nk_context* ctx);
		private delegate float nk_window_get_height_t(nk_context* ctx);
		private delegate nk_panel* nk_window_get_panel_t(nk_context* ctx);
		private delegate nk_rect nk_window_get_content_region_t(nk_context* ctx);
		private delegate nk_vec2 nk_window_get_content_region_min_t(nk_context* ctx);
		private delegate nk_vec2 nk_window_get_content_region_max_t(nk_context* ctx);
		private delegate nk_vec2 nk_window_get_content_region_size_t(nk_context* ctx);
		private delegate nk_command_buffer* nk_window_get_canvas_t(nk_context* ctx);
		private delegate int nk_window_has_focus_t(nk_context* ctx);
		private delegate int nk_window_is_collapsed_t(nk_context* ctx, byte* name);
		private delegate int nk_window_is_closed_t(nk_context* ctx, byte* name);
		private delegate int nk_window_is_hidden_t(nk_context* ctx, byte* name);
		private delegate int nk_window_is_active_t(nk_context* ctx, byte* name);
		private delegate int nk_window_is_hovered_t(nk_context* ctx);
		private delegate int nk_window_is_any_hovered_t(nk_context* ctx);
		private delegate int nk_item_is_any_active_t(nk_context* ctx);
		private delegate void nk_window_set_bounds_t(nk_context* ctx, byte* name, nk_rect bounds);
		private delegate void nk_window_set_position_t(nk_context* ctx, byte* name, nk_vec2 pos);
		private delegate void nk_window_set_size_t(nk_context* ctx, byte* name, nk_vec2 sz);
		private delegate void nk_window_set_focus_t(nk_context* ctx, byte* name);
		private delegate void nk_window_close_t(nk_context* ctx, byte* name);
		private delegate void nk_window_collapse_t(nk_context* ctx, byte* name, nk_collapse_states state);
		private delegate void nk_window_collapse_if_t(nk_context* ctx, byte* name, nk_collapse_states state, int cond);
		private delegate void nk_window_show_t(nk_context* ctx, byte* name, nk_show_states state);
		private delegate void nk_window_show_if_t(nk_context* ctx, byte* name, nk_show_states state, int cond);


		private delegate int nk_group_begin_t(nk_context* ctx, byte* title, uint nkflags);
		private delegate int nk_group_scrolled_offset_begin_t(nk_context* ctx, uint* x_offset, uint* y_offset, byte* s, uint nkflags);
		private delegate int nk_group_scrolled_begin_t(nk_context* ctx, nk_scroll* scroll, byte* title, uint nkflags);
		private delegate void nk_group_scrolled_end_t(nk_context* ctx);
		private delegate void nk_group_end_t(nk_context* ctx);

		private delegate int nk_list_view_begin_t(nk_context* ctx, nk_list_view* nlv_out, byte* id, uint nkflags, int row_height, int row_count);
		private delegate void nk_list_view_end_t(nk_list_view* nlv);

		private delegate int nk_tree_push_hashed_t(nk_context* ctx, nk_tree_type tree_type, byte* title, nk_collapse_states initial_state, byte* hash, int len, int seed);
		private delegate int nk_tree_image_push_hashed_t(nk_context* ctx, nk_tree_type tree_type, nk_image img, byte* title, nk_collapse_states initial_state, byte* hash, int len, int seed);
		private delegate void nk_tree_pop_t(nk_context* ctx);
		private delegate int nk_tree_state_push_t(nk_context* ctx, nk_tree_type tree_type, byte* title, nk_collapse_states* state);
		private delegate int nk_tree_state_image_push_t(nk_context* ctx, nk_tree_type tree_type, nk_image img, byte* title, nk_collapse_states* state);
		private delegate void nk_tree_state_pop_t(nk_context* ctx);

		private delegate nk_widget_layout_states nk_widget_t(nk_rect* r, nk_context* ctx);
		private delegate nk_widget_layout_states nk_widget_fitting_t(nk_rect* r, nk_context* ctx, nk_vec2 v);
		private delegate nk_rect nk_widget_bounds_t(nk_context* ctx);
		private delegate nk_vec2 nk_widget_position_t(nk_context* ctx);
		private delegate nk_vec2 nk_widget_size_t(nk_context* ctx);
		private delegate float nk_widget_width_t(nk_context* ctx);
		private delegate float nk_widget_height_t(nk_context* ctx);
		private delegate int nk_widget_is_hovered_t(nk_context* ctx);
		private delegate int nk_widget_is_mouse_clicked_t(nk_context* ctx, nk_buttons buttons);
		private delegate int nk_widget_has_mouse_click_down_t(nk_context* ctx, nk_buttons buttons, int down);
		private delegate void nk_spacing_t(nk_context* ctx, int cols);



		private delegate void nk_text_t(nk_context* ctx, byte* s, int i, uint flags_nkflags);
		private delegate void nk_text_colored_t(nk_context* ctx, byte* s, int i, uint flags_nkflags, nk_color color);
		private delegate void nk_text_wrap_t(nk_context* ctx, byte* s, int i);
		private delegate void nk_text_wrap_colored_t(nk_context* ctx, byte* s, int i, nk_color color);
		private delegate void nk_label_t(nk_context* ctx, byte* s, uint align_nkflags);
		private delegate void nk_label_colored_t(nk_context* ctx, byte* s, uint align_nkflags, nk_color color);
		private delegate void nk_label_wrap_t(nk_context* ctx, byte* s);
		private delegate void nk_label_colored_wrap_t(nk_context* ctx, byte* s, nk_color color);
		private delegate void nk_image_t(nk_context* ctx, nk_image img);

		private delegate int nk_button_text_t(nk_context* ctx, byte* title, int len);
		private delegate int nk_button_label_t(nk_context* ctx, byte* title);
		private delegate int nk_button_color_t(nk_context* ctx, nk_color color);
		private delegate int nk_button_symbol_t(nk_context* ctx, nk_symbol_type symtype);
		private delegate int nk_button_image_t(nk_context* ctx, nk_image img);
		private delegate int nk_button_symbol_label_t(nk_context* ctx, nk_symbol_type stype, byte* s, uint text_alignment_nkflags);
		private delegate int nk_button_symbol_text_t(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags);
		private delegate int nk_button_image_label_t(nk_context* ctx, nk_image img, byte* s, uint text_alignment_nkflags);
		private delegate int nk_button_image_text_t(nk_context* ctx, nk_image img, byte* s, int i, uint alignment_nkflags);
		private delegate int nk_button_text_styled_t(nk_context* ctx, nk_style_button* bstyle, byte* title, int len);
		private delegate int nk_button_label_styled_t(nk_context* ctx, nk_style_button* bstyle, byte* title);
		private delegate int nk_button_symbol_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype);
		private delegate int nk_button_image_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_image img);
		private delegate int nk_button_symbol_text_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags);
		private delegate int nk_button_symbol_label_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype, byte* title, uint align_nkflags);
		private delegate int nk_button_image_label_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_image img, byte* s, uint text_alignment_nkflags);
		private delegate int nk_button_image_text_styled_t(nk_context* ctx, nk_style_button* bstyle, nk_image img, byte* s, int i, uint alignment_nkflags);
		private delegate void nk_button_set_behavior_t(nk_context* ctx, nk_button_behavior behavior);
		private delegate int nk_button_push_behavior_t(nk_context* ctx, nk_button_behavior behavior);
		private delegate int nk_button_pop_behavior_t(nk_context* ctx);

		private delegate int nk_check_label_t(nk_context* ctx, byte* s, int active);
		private delegate int nk_check_text_t(nk_context* ctx, byte* s, int i, int active);
		private delegate uint nk_check_flags_label_t(nk_context* ctx, byte* s, uint flags, uint val);
		private delegate uint nk_check_flags_text_t(nk_context* ctx, byte* s, int i, uint flags, uint val);
		private delegate int nk_checkbox_label_t(nk_context* ctx, byte* s, int* active);
		private delegate int nk_checkbox_text_t(nk_context* ctx, byte* s, int i, int* active);
		private delegate int nk_checkbox_flags_label_t(nk_context* ctx, byte* s, uint* flags, uint val);
		private delegate int nk_checkbox_flags_text_t(nk_context* ctx, byte* s, int i, uint* flags, uint val);

		private delegate int nk_radio_label_t(nk_context* ctx, byte* s, int* active);
		private delegate int nk_radio_text_t(nk_context* ctx, byte* s, int i, int* active);
		private delegate int nk_option_label_t(nk_context* ctx, byte* s, int active);
		private delegate int nk_option_text_t(nk_context* ctx, byte* s, int i, int active);

		private delegate int nk_selectable_label_t(nk_context* ctx, byte* s, uint align_nkflags, int* val);
		private delegate int nk_selectable_text_t(nk_context* ctx, byte* s, int i, uint align_nkflags, int* val);
		private delegate int nk_selectable_image_label_t(nk_context* ctx, nk_image img, byte* s, uint align_nkflags, int* val);
		private delegate int nk_selectable_image_text_t(nk_context* ctx, nk_image img, byte* s, int i, uint align_nkflags, int* val);
		private delegate int nk_select_label_t(nk_context* ctx, byte* s, uint align_nkflags, int val);
		private delegate int nk_select_text_t(nk_context* ctx, byte* s, int i, uint align_nkflags, int val);
		private delegate int nk_select_image_label_t(nk_context* ctx, nk_image img, byte* s, uint align_nkflags, int val);
		private delegate int nk_select_image_text_t(nk_context* ctx, nk_image img, byte* s, int i, uint align_nkflags, int val);

		private delegate float nk_slide_float_t(nk_context* ctx, float min, float val, float max, float step);
		private delegate int nk_slide_int_t(nk_context* ctx, int min, int val, int max, int step);
		private delegate int nk_slider_float_t(nk_context* ctx, float min, float* val, float max, float step);
		private delegate int nk_slider_int_t(nk_context* ctx, int min, int* val, int max, int step);

		private delegate int nk_progress_t(nk_context* ctx, IntPtr* cur_nksize, IntPtr max_nksize, int modifyable);
		private delegate IntPtr nk_prog_t(nk_context* ctx, IntPtr cur_nksize, IntPtr max_nksize, int modifyable);

		private delegate nk_color nk_color_picker_t(nk_context* ctx, nk_color color, nk_color_format cfmt);
		private delegate int nk_color_pick_t(nk_context* ctx, nk_color* color, nk_color_format cfmt);

		private delegate void nk_property_int_t(nk_context* ctx, byte* name, int min, int* val, int max, int step, float inc_per_pixel);
		private delegate void nk_property_float_t(nk_context* ctx, byte* name, float min, float* val, float max, float step, float inc_per_pixel);
		private delegate void nk_property_double_t(nk_context* ctx, byte* name, double min, double* val, double max, double step, float inc_per_pixel);
		private delegate int nk_propertyi_t(nk_context* ctx, byte* name, int min, int val, int max, int step, float inc_per_pixel);
		private delegate float nk_propertyf_t(nk_context* ctx, byte* name, float min, float val, float max, float step, float inc_per_pixel);
		private delegate double nk_propertyd_t(nk_context* ctx, byte* name, double min, double val, double max, double step, float inc_per_pixel);

		private delegate uint nk_edit_string_t(nk_context* ctx, uint flags_nkflags, byte* buffer, int* len, int max, nk_plugin_filter_t filterfun);
		private delegate uint nk_edit_string_zero_terminated_t(nk_context* ctx, uint flags_nkflags, byte* buffer, int max, nk_plugin_filter_t filterfun);
		private delegate uint nk_edit_buffer_t(nk_context* ctx, uint flags_nkflags, nk_text_edit* textedit, nk_plugin_filter_t filterfun);
		private delegate void nk_edit_focus_t(nk_context* ctx, uint flags_nkflags);
		private delegate void nk_edit_unfocus_t(nk_context* ctx);

		private delegate int nk_chart_begin_t(nk_context* ctx, nk_chart_type chatype, int num, float min, float max);
		private delegate int nk_chart_begin_colored_t(nk_context* ctx, nk_chart_type chatype, nk_color color, nk_color active, int num, float min, float max);
		private delegate void nk_chart_add_slot_t(nk_context* ctx, nk_chart_type chatype, int count, float min_value, float max_value);
		private delegate void nk_chart_add_slot_colored_t(nk_context* ctx, nk_chart_type chatype, nk_color color, nk_color active, int count, float min_value, float max_value);
		private delegate uint nk_chart_push_t(nk_context* ctx, float f);
		private delegate uint nk_chart_push_slot_t(nk_context* ctx, float f, int i);
		private delegate void nk_chart_end_t(nk_context* ctx);
		private delegate void nk_plot_t(nk_context* ctx, nk_chart_type chatype, float* values, int count, int offset);
		private delegate void nk_plot_function_t(nk_context* ctx, nk_chart_type chatype, IntPtr userdata, nk_value_getter_fun getterfun, int count, int offset);

		private delegate int nk_popup_begin_t(nk_context* ctx, nk_popup_type type, byte* s, uint flags_nkflags, nk_rect bounds);
		private delegate void nk_popup_close_t(nk_context* ctx);
		private delegate void nk_popup_end_t(nk_context* ctx);

		private delegate int nk_combo_t(nk_context* ctx, byte** items, int count, int selected, int item_height, nk_vec2 size);
		private delegate int nk_combo_separator_t(nk_context* ctx, byte* items_separated_by_separator, int separator, int selected, int count, int item_height, nk_vec2 size);
		private delegate int nk_combo_string_t(nk_context* ctx, byte* items_separated_by_zeros, int selected, int count, int item_height, nk_vec2 size);
		private delegate int nk_combo_callback_t(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata, int selected, int count, int item_height, nk_vec2 size);
		private delegate void nk_combobox_t(nk_context* ctx, byte** items, int count, int* selected, int item_height, nk_vec2 size);
		private delegate void nk_combobox_string_t(nk_context* ctx, byte* items_separated_by_zeros, int* selected, int count, int item_height, nk_vec2 size);
		private delegate void nk_combobox_separator_t(nk_context* ctx, byte* items_separated_by_separator, int separator, int* selected, int count, int item_height, nk_vec2 size);
		private delegate void nk_combobox_callback_t(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata, int* selected, int count, int item_height, nk_vec2 size);

		private delegate int nk_combo_begin_text_t(nk_context* ctx, char* selected, int i, nk_vec2 size);
		private delegate int nk_combo_begin_label_t(nk_context* ctx, char* selected, nk_vec2 size);
		private delegate int nk_combo_begin_color_t(nk_context* ctx, nk_color color, nk_vec2 size);
		private delegate int nk_combo_begin_symbol_t(nk_context* ctx, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_combo_begin_symbol_label_t(nk_context* ctx, char* selected, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_combo_begin_symbol_text_t(nk_context* ctx, char* selected, int i, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_combo_begin_image_t(nk_context* ctx, nk_image img, nk_vec2 size);
		private delegate int nk_combo_begin_image_label_t(nk_context* ctx, char* selected, nk_image img, nk_vec2 size);
		private delegate int nk_combo_begin_image_text_t(nk_context* ctx, char* selected, int i, nk_image img, nk_vec2 size);
		private delegate int nk_combo_item_label_t(nk_context* ctx, byte* s, uint alignment_nkflags);
		private delegate int nk_combo_item_text_t(nk_context* ctx, byte* s, int i, uint alignment_nkflags);
		private delegate int nk_combo_item_image_label_t(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags);
		private delegate int nk_combo_item_image_text_t(nk_context* ctx, nk_image img, byte* s, int i, uint alignment_nkflags);
		private delegate int nk_combo_item_symbol_label_t(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags);
		private delegate int nk_combo_item_symbol_text_t(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags);
		private delegate void nk_combo_close_t(nk_context* ctx);
		private delegate void nk_combo_end_t(nk_context* ctx);

		private delegate int nk_contextual_begin_t(nk_context* ctx, uint flags_nkflags, nk_vec2 v, nk_rect trigger_bounds);
		private delegate int nk_contextual_item_text_t(nk_context* ctx, byte* s, int i, uint align_nkflags);
		private delegate int nk_contextual_item_label_t(nk_context* ctx, byte* s, uint align_nkflags);
		private delegate int nk_contextual_item_image_label_t(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags);
		private delegate int nk_contextual_item_image_text_t(nk_context* ctx, nk_image img, byte* s, int len, uint alignment_nkflags);
		private delegate int nk_contextual_item_symbol_label_t(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags);
		private delegate int nk_contextual_item_symbol_text_t(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags);
		private delegate void nk_contextual_close_t(nk_context* ctx);
		private delegate void nk_contextual_end_t(nk_context* ctx);

		private delegate void nk_tooltip_t(nk_context* ctx, byte* s);

		private delegate int nk_tooltip_begin_t(nk_context* ctx, float width);
		private delegate void nk_tooltip_end_t(nk_context* ctx);

		private delegate void nk_menubar_begin_t(nk_context* ctx);
		private delegate void nk_menubar_end_t(nk_context* ctx);
		private delegate int nk_menu_begin_text_t(nk_context* ctx, byte* title, int title_len, uint align_nkflags, nk_vec2 size);
		private delegate int nk_menu_begin_label_t(nk_context* ctx, byte* s, uint align_nkflags, nk_vec2 size);
		private delegate int nk_menu_begin_image_t(nk_context* ctx, byte* s, nk_image img, nk_vec2 size);
		private delegate int nk_menu_begin_image_text_t(nk_context* ctx, byte* s, int slen, uint align_nkflags, nk_image img, nk_vec2 size);
		private delegate int nk_menu_begin_image_label_t(nk_context* ctx, byte* s, uint align_nkflags, nk_image img, nk_vec2 size);
		private delegate int nk_menu_begin_symbol_t(nk_context* ctx, byte* s, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_menu_begin_symbol_text_t(nk_context* ctx, byte* s, int slen, uint align_nkflags, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_menu_begin_symbol_label_t(nk_context* ctx, byte* s, uint align_nkflags, nk_symbol_type stype, nk_vec2 size);
		private delegate int nk_menu_item_text_t(nk_context* ctx, byte* s, int slen, uint align_nkflags);
		private delegate int nk_menu_item_label_t(nk_context* ctx, byte* s, uint alignment_nkflags);
		private delegate int nk_menu_item_image_label_t(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags);
		private delegate int nk_menu_item_image_text_t(nk_context* ctx, nk_image img, byte* s, int slen, uint alignment_nkflags);
		private delegate int nk_menu_item_symbol_text_t(nk_context* ctx, nk_symbol_type stype, byte* s, int slen, uint alignment_nkflags);
		private delegate int nk_menu_item_symbol_label_t(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags);
		private delegate void nk_menu_close_t(nk_context* ctx);
		private delegate void nk_menu_end_t(nk_context* ctx);






		private static nk_window_find_t _nk_window_find = LFT<nk_window_find_t>();
		private static nk_window_get_bounds_t _nk_window_get_bounds = LFT<nk_window_get_bounds_t>();
		private static nk_window_get_position_t _nk_window_get_position = LFT<nk_window_get_position_t>();
		private static nk_window_get_size_t _nk_window_get_size = LFT<nk_window_get_size_t>();
		private static nk_window_get_width_t _nk_window_get_width = LFT<nk_window_get_width_t>();
		private static nk_window_get_height_t _nk_window_get_height = LFT<nk_window_get_height_t>();
		private static nk_window_get_panel_t _nk_window_get_panel = LFT<nk_window_get_panel_t>();
		private static nk_window_get_content_region_t _nk_window_get_content_region = LFT<nk_window_get_content_region_t>();
		private static nk_window_get_content_region_min_t _nk_window_get_content_region_min = LFT<nk_window_get_content_region_min_t>();
		private static nk_window_get_content_region_max_t _nk_window_get_content_region_max = LFT<nk_window_get_content_region_max_t>();
		private static nk_window_get_content_region_size_t _nk_window_get_content_region_size = LFT<nk_window_get_content_region_size_t>();
		private static nk_window_get_canvas_t _nk_window_get_canvas = LFT<nk_window_get_canvas_t>();
		private static nk_window_has_focus_t _nk_window_has_focus = LFT<nk_window_has_focus_t>();
		private static nk_window_is_collapsed_t _nk_window_is_collapsed = LFT<nk_window_is_collapsed_t>();
		private static nk_window_is_closed_t _nk_window_is_closed = LFT<nk_window_is_closed_t>();
		private static nk_window_is_hidden_t _nk_window_is_hidden = LFT<nk_window_is_hidden_t>();
		private static nk_window_is_active_t _nk_window_is_active = LFT<nk_window_is_active_t>();
		private static nk_window_is_hovered_t _nk_window_is_hovered = LFT<nk_window_is_hovered_t>();
		private static nk_window_is_any_hovered_t _nk_window_is_any_hovered = LFT<nk_window_is_any_hovered_t>();
		private static nk_item_is_any_active_t _nk_item_is_any_active = LFT<nk_item_is_any_active_t>();
		private static nk_window_set_bounds_t _nk_window_set_bounds = LFT<nk_window_set_bounds_t>();
		private static nk_window_set_position_t _nk_window_set_position = LFT<nk_window_set_position_t>();
		private static nk_window_set_size_t _nk_window_set_size = LFT<nk_window_set_size_t>();
		private static nk_window_set_focus_t _nk_window_set_focus = LFT<nk_window_set_focus_t>();
		private static nk_window_close_t _nk_window_close = LFT<nk_window_close_t>();
		private static nk_window_collapse_t _nk_window_collapse = LFT<nk_window_collapse_t>();
		private static nk_window_collapse_if_t _nk_window_collapse_if = LFT<nk_window_collapse_if_t>();
		private static nk_window_show_t _nk_window_show = LFT<nk_window_show_t>();
		private static nk_window_show_if_t _nk_window_show_if = LFT<nk_window_show_if_t>();
		private static nk_group_begin_t _nk_group_begin = LFT<nk_group_begin_t>();
		private static nk_group_scrolled_offset_begin_t _nk_group_scrolled_offset_begin = LFT<nk_group_scrolled_offset_begin_t>();
		private static nk_group_scrolled_begin_t _nk_group_scrolled_begin = LFT<nk_group_scrolled_begin_t>();
		private static nk_group_scrolled_end_t _nk_group_scrolled_end = LFT<nk_group_scrolled_end_t>();
		private static nk_group_end_t _nk_group_end = LFT<nk_group_end_t>();
		private static nk_list_view_begin_t _nk_list_view_begin = LFT<nk_list_view_begin_t>();
		private static nk_list_view_end_t _nk_list_view_end = LFT<nk_list_view_end_t>();
		private static nk_tree_push_hashed_t _nk_tree_push_hashed = LFT<nk_tree_push_hashed_t>();
		private static nk_tree_image_push_hashed_t _nk_tree_image_push_hashed = LFT<nk_tree_image_push_hashed_t>();
		private static nk_tree_pop_t _nk_tree_pop = LFT<nk_tree_pop_t>();
		private static nk_tree_state_push_t _nk_tree_state_push = LFT<nk_tree_state_push_t>();
		private static nk_tree_state_image_push_t _nk_tree_state_image_push = LFT<nk_tree_state_image_push_t>();
		private static nk_tree_state_pop_t _nk_tree_state_pop = LFT<nk_tree_state_pop_t>();
		private static nk_widget_t _nk_widget = LFT<nk_widget_t>();
		private static nk_widget_fitting_t _nk_widget_fitting = LFT<nk_widget_fitting_t>();
		private static nk_widget_bounds_t _nk_widget_bounds = LFT<nk_widget_bounds_t>();
		private static nk_widget_position_t _nk_widget_position = LFT<nk_widget_position_t>();
		private static nk_widget_size_t _nk_widget_size = LFT<nk_widget_size_t>();
		private static nk_widget_width_t _nk_widget_width = LFT<nk_widget_width_t>();
		private static nk_widget_height_t _nk_widget_height = LFT<nk_widget_height_t>();
		private static nk_widget_is_hovered_t _nk_widget_is_hovered = LFT<nk_widget_is_hovered_t>();
		private static nk_widget_is_mouse_clicked_t _nk_widget_is_mouse_clicked = LFT<nk_widget_is_mouse_clicked_t>();
		private static nk_widget_has_mouse_click_down_t _nk_widget_has_mouse_click_down = LFT<nk_widget_has_mouse_click_down_t>();
		private static nk_spacing_t _nk_spacing = LFT<nk_spacing_t>();
		private static nk_text_t _nk_text = LFT<nk_text_t>();
		private static nk_text_colored_t _nk_text_colored = LFT<nk_text_colored_t>();
		private static nk_text_wrap_t _nk_text_wrap = LFT<nk_text_wrap_t>();
		private static nk_text_wrap_colored_t _nk_text_wrap_colored = LFT<nk_text_wrap_colored_t>();
		private static nk_label_t _nk_label = LFT<nk_label_t>();
		private static nk_label_colored_t _nk_label_colored = LFT<nk_label_colored_t>();
		private static nk_label_wrap_t _nk_label_wrap = LFT<nk_label_wrap_t>();
		private static nk_label_colored_wrap_t _nk_label_colored_wrap = LFT<nk_label_colored_wrap_t>();
		private static nk_image_t _nk_image = LFT<nk_image_t>();
		private static nk_button_text_t _nk_button_text = LFT<nk_button_text_t>();
		private static nk_button_label_t _nk_button_label = LFT<nk_button_label_t>();
		private static nk_button_color_t _nk_button_color = LFT<nk_button_color_t>();
		private static nk_button_symbol_t _nk_button_symbol = LFT<nk_button_symbol_t>();
		private static nk_button_image_t _nk_button_image = LFT<nk_button_image_t>();
		private static nk_button_symbol_label_t _nk_button_symbol_label = LFT<nk_button_symbol_label_t>();
		private static nk_button_symbol_text_t _nk_button_symbol_text = LFT<nk_button_symbol_text_t>();
		private static nk_button_image_label_t _nk_button_image_label = LFT<nk_button_image_label_t>();
		private static nk_button_image_text_t _nk_button_image_text = LFT<nk_button_image_text_t>();
		private static nk_button_text_styled_t _nk_button_text_styled = LFT<nk_button_text_styled_t>();
		private static nk_button_label_styled_t _nk_button_label_styled = LFT<nk_button_label_styled_t>();
		private static nk_button_symbol_styled_t _nk_button_symbol_styled = LFT<nk_button_symbol_styled_t>();
		private static nk_button_image_styled_t _nk_button_image_styled = LFT<nk_button_image_styled_t>();
		private static nk_button_symbol_text_styled_t _nk_button_symbol_text_styled = LFT<nk_button_symbol_text_styled_t>();
		private static nk_button_symbol_label_styled_t _nk_button_symbol_label_styled = LFT<nk_button_symbol_label_styled_t>();
		private static nk_button_image_label_styled_t _nk_button_image_label_styled = LFT<nk_button_image_label_styled_t>();
		private static nk_button_image_text_styled_t _nk_button_image_text_styled = LFT<nk_button_image_text_styled_t>();
		private static nk_button_set_behavior_t _nk_button_set_behavior = LFT<nk_button_set_behavior_t>();
		private static nk_button_push_behavior_t _nk_button_push_behavior = LFT<nk_button_push_behavior_t>();
		private static nk_button_pop_behavior_t _nk_button_pop_behavior = LFT<nk_button_pop_behavior_t>();
		private static nk_check_label_t _nk_check_label = LFT<nk_check_label_t>();
		private static nk_check_text_t _nk_check_text = LFT<nk_check_text_t>();
		private static nk_check_flags_label_t _nk_check_flags_label = LFT<nk_check_flags_label_t>();
		private static nk_check_flags_text_t _nk_check_flags_text = LFT<nk_check_flags_text_t>();
		private static nk_checkbox_label_t _nk_checkbox_label = LFT<nk_checkbox_label_t>();
		private static nk_checkbox_text_t _nk_checkbox_text = LFT<nk_checkbox_text_t>();
		private static nk_checkbox_flags_label_t _nk_checkbox_flags_label = LFT<nk_checkbox_flags_label_t>();
		private static nk_checkbox_flags_text_t _nk_checkbox_flags_text = LFT<nk_checkbox_flags_text_t>();
		private static nk_radio_label_t _nk_radio_label = LFT<nk_radio_label_t>();
		private static nk_radio_text_t _nk_radio_text = LFT<nk_radio_text_t>();
		private static nk_option_label_t _nk_option_label = LFT<nk_option_label_t>();
		private static nk_option_text_t _nk_option_text = LFT<nk_option_text_t>();
		private static nk_selectable_label_t _nk_selectable_label = LFT<nk_selectable_label_t>();
		private static nk_selectable_text_t _nk_selectable_text = LFT<nk_selectable_text_t>();
		private static nk_selectable_image_label_t _nk_selectable_image_label = LFT<nk_selectable_image_label_t>();
		private static nk_selectable_image_text_t _nk_selectable_image_text = LFT<nk_selectable_image_text_t>();
		private static nk_select_label_t _nk_select_label = LFT<nk_select_label_t>();
		private static nk_select_text_t _nk_select_text = LFT<nk_select_text_t>();
		private static nk_select_image_label_t _nk_select_image_label = LFT<nk_select_image_label_t>();
		private static nk_select_image_text_t _nk_select_image_text = LFT<nk_select_image_text_t>();
		private static nk_slide_float_t _nk_slide_float = LFT<nk_slide_float_t>();
		private static nk_slide_int_t _nk_slide_int = LFT<nk_slide_int_t>();
		private static nk_slider_float_t _nk_slider_float = LFT<nk_slider_float_t>();
		private static nk_slider_int_t _nk_slider_int = LFT<nk_slider_int_t>();
		private static nk_progress_t _nk_progress = LFT<nk_progress_t>();
		private static nk_prog_t _nk_prog = LFT<nk_prog_t>();
		private static nk_color_picker_t _nk_color_picker = LFT<nk_color_picker_t>();
		private static nk_color_pick_t _nk_color_pick = LFT<nk_color_pick_t>();
		private static nk_property_int_t _nk_property_int = LFT<nk_property_int_t>();
		private static nk_property_float_t _nk_property_float = LFT<nk_property_float_t>();
		private static nk_property_double_t _nk_property_double = LFT<nk_property_double_t>();
		private static nk_propertyi_t _nk_propertyi = LFT<nk_propertyi_t>();
		private static nk_propertyf_t _nk_propertyf = LFT<nk_propertyf_t>();
		private static nk_propertyd_t _nk_propertyd = LFT<nk_propertyd_t>();
		private static nk_edit_string_t _nk_edit_string = LFT<nk_edit_string_t>();
		private static nk_edit_string_zero_terminated_t _nk_edit_string_zero_terminated = LFT<nk_edit_string_zero_terminated_t>();
		private static nk_edit_buffer_t _nk_edit_buffer = LFT<nk_edit_buffer_t>();
		private static nk_edit_focus_t _nk_edit_focus = LFT<nk_edit_focus_t>();
		private static nk_edit_unfocus_t _nk_edit_unfocus = LFT<nk_edit_unfocus_t>();
		private static nk_chart_begin_t _nk_chart_begin = LFT<nk_chart_begin_t>();
		private static nk_chart_begin_colored_t _nk_chart_begin_colored = LFT<nk_chart_begin_colored_t>();
		private static nk_chart_add_slot_t _nk_chart_add_slot = LFT<nk_chart_add_slot_t>();
		private static nk_chart_add_slot_colored_t _nk_chart_add_slot_colored = LFT<nk_chart_add_slot_colored_t>();
		private static nk_chart_push_t _nk_chart_push = LFT<nk_chart_push_t>();
		private static nk_chart_push_slot_t _nk_chart_push_slot = LFT<nk_chart_push_slot_t>();
		private static nk_chart_end_t _nk_chart_end = LFT<nk_chart_end_t>();
		private static nk_plot_t _nk_plot = LFT<nk_plot_t>();
		private static nk_plot_function_t _nk_plot_function = LFT<nk_plot_function_t>();
		private static nk_popup_begin_t _nk_popup_begin = LFT<nk_popup_begin_t>();
		private static nk_popup_close_t _nk_popup_close = LFT<nk_popup_close_t>();
		private static nk_popup_end_t _nk_popup_end = LFT<nk_popup_end_t>();
		private static nk_combo_t _nk_combo = LFT<nk_combo_t>();
		private static nk_combo_separator_t _nk_combo_separator = LFT<nk_combo_separator_t>();
		private static nk_combo_string_t _nk_combo_string = LFT<nk_combo_string_t>();
		private static nk_combo_callback_t _nk_combo_callback = LFT<nk_combo_callback_t>();
		private static nk_combobox_t _nk_combobox = LFT<nk_combobox_t>();
		private static nk_combobox_string_t _nk_combobox_string = LFT<nk_combobox_string_t>();
		private static nk_combobox_separator_t _nk_combobox_separator = LFT<nk_combobox_separator_t>();
		private static nk_combobox_callback_t _nk_combobox_callback = LFT<nk_combobox_callback_t>();
		private static nk_combo_begin_text_t _nk_combo_begin_text = LFT<nk_combo_begin_text_t>();
		private static nk_combo_begin_label_t _nk_combo_begin_label = LFT<nk_combo_begin_label_t>();
		private static nk_combo_begin_color_t _nk_combo_begin_color = LFT<nk_combo_begin_color_t>();
		private static nk_combo_begin_symbol_t _nk_combo_begin_symbol = LFT<nk_combo_begin_symbol_t>();
		private static nk_combo_begin_symbol_label_t _nk_combo_begin_symbol_label = LFT<nk_combo_begin_symbol_label_t>();
		private static nk_combo_begin_symbol_text_t _nk_combo_begin_symbol_text = LFT<nk_combo_begin_symbol_text_t>();
		private static nk_combo_begin_image_t _nk_combo_begin_image = LFT<nk_combo_begin_image_t>();
		private static nk_combo_begin_image_label_t _nk_combo_begin_image_label = LFT<nk_combo_begin_image_label_t>();
		private static nk_combo_begin_image_text_t _nk_combo_begin_image_text = LFT<nk_combo_begin_image_text_t>();
		private static nk_combo_item_label_t _nk_combo_item_label = LFT<nk_combo_item_label_t>();
		private static nk_combo_item_text_t _nk_combo_item_text = LFT<nk_combo_item_text_t>();
		private static nk_combo_item_image_label_t _nk_combo_item_image_label = LFT<nk_combo_item_image_label_t>();
		private static nk_combo_item_image_text_t _nk_combo_item_image_text = LFT<nk_combo_item_image_text_t>();
		private static nk_combo_item_symbol_label_t _nk_combo_item_symbol_label = LFT<nk_combo_item_symbol_label_t>();
		private static nk_combo_item_symbol_text_t _nk_combo_item_symbol_text = LFT<nk_combo_item_symbol_text_t>();
		private static nk_combo_close_t _nk_combo_close = LFT<nk_combo_close_t>();
		private static nk_combo_end_t _nk_combo_end = LFT<nk_combo_end_t>();
		private static nk_contextual_begin_t _nk_contextual_begin = LFT<nk_contextual_begin_t>();
		private static nk_contextual_item_text_t _nk_contextual_item_text = LFT<nk_contextual_item_text_t>();
		private static nk_contextual_item_label_t _nk_contextual_item_label = LFT<nk_contextual_item_label_t>();
		private static nk_contextual_item_image_label_t _nk_contextual_item_image_label = LFT<nk_contextual_item_image_label_t>();
		private static nk_contextual_item_image_text_t _nk_contextual_item_image_text = LFT<nk_contextual_item_image_text_t>();
		private static nk_contextual_item_symbol_label_t _nk_contextual_item_symbol_label = LFT<nk_contextual_item_symbol_label_t>();
		private static nk_contextual_item_symbol_text_t _nk_contextual_item_symbol_text = LFT<nk_contextual_item_symbol_text_t>();
		private static nk_contextual_close_t _nk_contextual_close = LFT<nk_contextual_close_t>();
		private static nk_contextual_end_t _nk_contextual_end = LFT<nk_contextual_end_t>();
		private static nk_tooltip_t _nk_tooltip = LFT<nk_tooltip_t>();
		private static nk_tooltip_begin_t _nk_tooltip_begin = LFT<nk_tooltip_begin_t>();
		private static nk_tooltip_end_t _nk_tooltip_end = LFT<nk_tooltip_end_t>();
		private static nk_menubar_begin_t _nk_menubar_begin = LFT<nk_menubar_begin_t>();
		private static nk_menubar_end_t _nk_menubar_end = LFT<nk_menubar_end_t>();
		private static nk_menu_begin_text_t _nk_menu_begin_text = LFT<nk_menu_begin_text_t>();
		private static nk_menu_begin_label_t _nk_menu_begin_label = LFT<nk_menu_begin_label_t>();
		private static nk_menu_begin_image_t _nk_menu_begin_image = LFT<nk_menu_begin_image_t>();
		private static nk_menu_begin_image_text_t _nk_menu_begin_image_text = LFT<nk_menu_begin_image_text_t>();
		private static nk_menu_begin_image_label_t _nk_menu_begin_image_label = LFT<nk_menu_begin_image_label_t>();
		private static nk_menu_begin_symbol_t _nk_menu_begin_symbol = LFT<nk_menu_begin_symbol_t>();
		private static nk_menu_begin_symbol_text_t _nk_menu_begin_symbol_text = LFT<nk_menu_begin_symbol_text_t>();
		private static nk_menu_begin_symbol_label_t _nk_menu_begin_symbol_label = LFT<nk_menu_begin_symbol_label_t>();
		private static nk_menu_item_text_t _nk_menu_item_text = LFT<nk_menu_item_text_t>();
		private static nk_menu_item_label_t _nk_menu_item_label = LFT<nk_menu_item_label_t>();
		private static nk_menu_item_image_label_t _nk_menu_item_image_label = LFT<nk_menu_item_image_label_t>();
		private static nk_menu_item_image_text_t _nk_menu_item_image_text = LFT<nk_menu_item_image_text_t>();
		private static nk_menu_item_symbol_text_t _nk_menu_item_symbol_text = LFT<nk_menu_item_symbol_text_t>();
		private static nk_menu_item_symbol_label_t _nk_menu_item_symbol_label = LFT<nk_menu_item_symbol_label_t>();
		private static nk_menu_close_t _nk_menu_close = LFT<nk_menu_close_t>();
		private static nk_menu_end_t _nk_menu_end = LFT<nk_menu_end_t>();




		public static nk_window* nk_window_find(nk_context* ctx, byte* name) => _nk_window_find(ctx, name);
		public static nk_rect nk_window_get_bounds(nk_context* ctx) => _nk_window_get_bounds(ctx);
		public static nk_vec2 nk_window_get_position(nk_context* ctx) => _nk_window_get_position(ctx);
		public static nk_vec2 nk_window_get_size(nk_context* ctx) => _nk_window_get_size(ctx);
		public static float nk_window_get_width(nk_context* ctx) => _nk_window_get_width(ctx);
		public static float nk_window_get_height(nk_context* ctx) => _nk_window_get_height(ctx);
		public static nk_panel* nk_window_get_panel(nk_context* ctx) => _nk_window_get_panel(ctx);
		public static nk_rect nk_window_get_content_region(nk_context* ctx) => _nk_window_get_content_region(ctx);
		public static nk_vec2 nk_window_get_content_region_min(nk_context* ctx) => _nk_window_get_content_region_min(ctx);
		public static nk_vec2 nk_window_get_content_region_max(nk_context* ctx) => _nk_window_get_content_region_max(ctx);
		public static nk_vec2 nk_window_get_content_region_size(nk_context* ctx) => _nk_window_get_content_region_size(ctx);
		public static nk_command_buffer* nk_window_get_canvas(nk_context* ctx) => _nk_window_get_canvas(ctx);
		public static int nk_window_has_focus(nk_context* ctx) => _nk_window_has_focus(ctx);
		public static int nk_window_is_collapsed(nk_context* ctx, byte* name) => _nk_window_is_collapsed(ctx, name);
		public static int nk_window_is_closed(nk_context* ctx, byte* name) => _nk_window_is_closed(ctx, name);
		public static int nk_window_is_hidden(nk_context* ctx, byte* name) => _nk_window_is_hidden(ctx, name);
		public static int nk_window_is_active(nk_context* ctx, byte* name) => _nk_window_is_active(ctx, name);
		public static int nk_window_is_hovered(nk_context* ctx) => _nk_window_is_hovered(ctx);
		public static int nk_window_is_any_hovered(nk_context* ctx) => _nk_window_is_any_hovered(ctx);
		public static int nk_item_is_any_active(nk_context* ctx) => _nk_item_is_any_active(ctx);
		public static void nk_window_set_bounds(nk_context* ctx, byte* name, nk_rect bounds) => _nk_window_set_bounds(ctx, name, bounds);
		public static void nk_window_set_position(nk_context* ctx, byte* name, nk_vec2 pos) => _nk_window_set_position(ctx, name, pos);
		public static void nk_window_set_size(nk_context* ctx, byte* name, nk_vec2 sz) => _nk_window_set_size(ctx, name, sz);
		public static void nk_window_set_focus(nk_context* ctx, byte* name) => _nk_window_set_focus(ctx, name);
		public static void nk_window_close(nk_context* ctx, byte* name) => _nk_window_close(ctx, name);
		public static void nk_window_collapse(nk_context* ctx, byte* name, nk_collapse_states state) => _nk_window_collapse(ctx, name, state);
		public static void nk_window_collapse_if(nk_context* ctx, byte* name, nk_collapse_states state, int cond) => _nk_window_collapse_if(ctx, name, state, cond);
		public static void nk_window_show(nk_context* ctx, byte* name, nk_show_states state) => _nk_window_show(ctx, name, state);
		public static void nk_window_show_if(nk_context* ctx, byte* name, nk_show_states state, int cond) => _nk_window_show_if(ctx, name, state, cond);
		public static int nk_group_begin(nk_context* ctx, byte* title, uint nkflags) => _nk_group_begin(ctx, title, nkflags);
		public static int nk_group_scrolled_offset_begin(nk_context* ctx, uint* x_offset, uint* y_offset, byte* s, uint nkflags) => _nk_group_scrolled_offset_begin(ctx, x_offset, y_offset, s, nkflags);
		public static int nk_group_scrolled_begin(nk_context* ctx, nk_scroll* scroll, byte* title, uint nkflags) => _nk_group_scrolled_begin(ctx, scroll, title, nkflags);
		public static void nk_group_scrolled_end(nk_context* ctx) => _nk_group_scrolled_end(ctx);
		public static void nk_group_end(nk_context* ctx) => _nk_group_end(ctx);
		public static int nk_list_view_begin(nk_context* ctx, nk_list_view* nlv_out, byte* id, uint nkflags, int row_height, int row_count) => _nk_list_view_begin(ctx, nlv_out, id, nkflags, row_height, row_count);
		public static void nk_list_view_end(nk_list_view* nlv) => _nk_list_view_end(nlv);
		public static int nk_tree_push_hashed(nk_context* ctx, nk_tree_type tree_type, byte* title, nk_collapse_states initial_state, byte* hash, int len, int seed) => _nk_tree_push_hashed(ctx, tree_type, title, initial_state, hash, len, seed);
		public static int nk_tree_image_push_hashed(nk_context* ctx, nk_tree_type tree_type, nk_image img, byte* title, nk_collapse_states initial_state, byte* hash, int len, int seed) => _nk_tree_image_push_hashed(ctx, tree_type, img, title, initial_state, hash, len, seed);
		public static void nk_tree_pop(nk_context* ctx) => _nk_tree_pop(ctx);
		public static int nk_tree_state_push(nk_context* ctx, nk_tree_type tree_type, byte* title, nk_collapse_states* state) => _nk_tree_state_push(ctx, tree_type, title, state);
		public static int nk_tree_state_image_push(nk_context* ctx, nk_tree_type tree_type, nk_image img, byte* title, nk_collapse_states* state) => _nk_tree_state_image_push(ctx, tree_type, img, title, state);
		public static void nk_tree_state_pop(nk_context* ctx) => _nk_tree_state_pop(ctx);
		public static nk_widget_layout_states nk_widget(nk_rect* r, nk_context* ctx) => _nk_widget(r, ctx);
		public static nk_widget_layout_states nk_widget_fitting(nk_rect* r, nk_context* ctx, nk_vec2 v) => _nk_widget_fitting(r, ctx, v);
		public static nk_rect nk_widget_bounds(nk_context* ctx) => _nk_widget_bounds(ctx);
		public static nk_vec2 nk_widget_position(nk_context* ctx) => _nk_widget_position(ctx);
		public static nk_vec2 nk_widget_size(nk_context* ctx) => _nk_widget_size(ctx);
		public static float nk_widget_width(nk_context* ctx) => _nk_widget_width(ctx);
		public static float nk_widget_height(nk_context* ctx) => _nk_widget_height(ctx);
		public static int nk_widget_is_hovered(nk_context* ctx) => _nk_widget_is_hovered(ctx);
		public static int nk_widget_is_mouse_clicked(nk_context* ctx, nk_buttons buttons) => _nk_widget_is_mouse_clicked(ctx, buttons);
		public static int nk_widget_has_mouse_click_down(nk_context* ctx, nk_buttons buttons, int down) => _nk_widget_has_mouse_click_down(ctx, buttons, down);
		public static void nk_spacing(nk_context* ctx, int cols) => _nk_spacing(ctx, cols);
		public static void nk_text(nk_context* ctx, byte* s, int i, uint flags_nkflags) => _nk_text(ctx, s, i, flags_nkflags);
		public static void nk_text_colored(nk_context* ctx, byte* s, int i, uint flags_nkflags, nk_color color) => _nk_text_colored(ctx, s, i, flags_nkflags, color);
		public static void nk_text_wrap(nk_context* ctx, byte* s, int i) => _nk_text_wrap(ctx, s, i);
		public static void nk_text_wrap_colored(nk_context* ctx, byte* s, int i, nk_color color) => _nk_text_wrap_colored(ctx, s, i, color);
		public static void nk_label(nk_context* ctx, byte* s, uint align_nkflags) => _nk_label(ctx, s, align_nkflags);
		public static void nk_label_colored(nk_context* ctx, byte* s, uint align_nkflags, nk_color color) => _nk_label_colored(ctx, s, align_nkflags, color);
		public static void nk_label_wrap(nk_context* ctx, byte* s) => _nk_label_wrap(ctx, s);
		public static void nk_label_colored_wrap(nk_context* ctx, byte* s, nk_color color) => _nk_label_colored_wrap(ctx, s, color);
		public static void nk_image(nk_context* ctx, nk_image img) => _nk_image(ctx, img);
		public static int nk_button_text(nk_context* ctx, byte* title, int len) => _nk_button_text(ctx, title, len);
		public static int nk_button_label(nk_context* ctx, byte* title) => _nk_button_label(ctx, title);
		public static int nk_button_color(nk_context* ctx, nk_color color) => _nk_button_color(ctx, color);
		public static int nk_button_symbol(nk_context* ctx, nk_symbol_type symtype) => _nk_button_symbol(ctx, symtype);
		public static int nk_button_image(nk_context* ctx, nk_image img) => _nk_button_image(ctx, img);
		public static int nk_button_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s, uint text_alignment_nkflags) => _nk_button_symbol_label(ctx, stype, s, text_alignment_nkflags);
		public static int nk_button_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags) => _nk_button_symbol_text(ctx, stype, s, i, alignment_nkflags);
		public static int nk_button_image_label(nk_context* ctx, nk_image img, byte* s, uint text_alignment_nkflags) => _nk_button_image_label(ctx, img, s, text_alignment_nkflags);
		public static int nk_button_image_text(nk_context* ctx, nk_image img, byte* s, int i, uint alignment_nkflags) => _nk_button_image_text(ctx, img, s, i, alignment_nkflags);
		public static int nk_button_text_styled(nk_context* ctx, nk_style_button* bstyle, byte* title, int len) => _nk_button_text_styled(ctx, bstyle, title, len);
		public static int nk_button_label_styled(nk_context* ctx, nk_style_button* bstyle, byte* title) => _nk_button_label_styled(ctx, bstyle, title);
		public static int nk_button_symbol_styled(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype) => _nk_button_symbol_styled(ctx, bstyle, stype);
		public static int nk_button_image_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img) => _nk_button_image_styled(ctx, bstyle, img);
		public static int nk_button_symbol_text_styled(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags) => _nk_button_symbol_text_styled(ctx, bstyle, stype, s, i, alignment_nkflags);
		public static int nk_button_symbol_label_styled(nk_context* ctx, nk_style_button* bstyle, nk_symbol_type stype, byte* title, uint align_nkflags) => _nk_button_symbol_label_styled(ctx, bstyle, stype, title, align_nkflags);
		public static int nk_button_image_label_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img, byte* s, uint text_alignment_nkflags) => _nk_button_image_label_styled(ctx, bstyle, img, s, text_alignment_nkflags);
		public static int nk_button_image_text_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img, byte* s, int i, uint alignment_nkflags) => _nk_button_image_text_styled(ctx, bstyle, img, s, i, alignment_nkflags);
		public static void nk_button_set_behavior(nk_context* ctx, nk_button_behavior behavior) => _nk_button_set_behavior(ctx, behavior);
		public static int nk_button_push_behavior(nk_context* ctx, nk_button_behavior behavior) => _nk_button_push_behavior(ctx, behavior);
		public static int nk_button_pop_behavior(nk_context* ctx) => _nk_button_pop_behavior(ctx);
		public static int nk_check_label(nk_context* ctx, byte* s, int active) => _nk_check_label(ctx, s, active);
		public static int nk_check_text(nk_context* ctx, byte* s, int i, int active) => _nk_check_text(ctx, s, i, active);
		public static uint nk_check_flags_label(nk_context* ctx, byte* s, uint flags, uint val) => _nk_check_flags_label(ctx, s, flags, val);
		public static uint nk_check_flags_text(nk_context* ctx, byte* s, int i, uint flags, uint val) => _nk_check_flags_text(ctx, s, i, flags, val);
		public static int nk_checkbox_label(nk_context* ctx, byte* s, int* active) => _nk_checkbox_label(ctx, s, active);
		public static int nk_checkbox_text(nk_context* ctx, byte* s, int i, int* active) => _nk_checkbox_text(ctx, s, i, active);
		public static int nk_checkbox_flags_label(nk_context* ctx, byte* s, uint* flags, uint val) => _nk_checkbox_flags_label(ctx, s, flags, val);
		public static int nk_checkbox_flags_text(nk_context* ctx, byte* s, int i, uint* flags, uint val) => _nk_checkbox_flags_text(ctx, s, i, flags, val);
		public static int nk_radio_label(nk_context* ctx, byte* s, int* active) => _nk_radio_label(ctx, s, active);
		public static int nk_radio_text(nk_context* ctx, byte* s, int i, int* active) => _nk_radio_text(ctx, s, i, active);
		public static int nk_option_label(nk_context* ctx, byte* s, int active) => _nk_option_label(ctx, s, active);
		public static int nk_option_text(nk_context* ctx, byte* s, int i, int active) => _nk_option_text(ctx, s, i, active);
		public static int nk_selectable_label(nk_context* ctx, byte* s, uint align_nkflags, int* val) => _nk_selectable_label(ctx, s, align_nkflags, val);
		public static int nk_selectable_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int* val) => _nk_selectable_text(ctx, s, i, align_nkflags, val);
		public static int nk_selectable_image_label(nk_context* ctx, nk_image img, byte* s, uint align_nkflags, int* val) => _nk_selectable_image_label(ctx, img, s, align_nkflags, val);
		public static int nk_selectable_image_text(nk_context* ctx, nk_image img, byte* s, int i, uint align_nkflags, int* val) => _nk_selectable_image_text(ctx, img, s, i, align_nkflags, val);
		public static int nk_select_label(nk_context* ctx, byte* s, uint align_nkflags, int val) => _nk_select_label(ctx, s, align_nkflags, val);
		public static int nk_select_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int val) => _nk_select_text(ctx, s, i, align_nkflags, val);
		public static int nk_select_image_label(nk_context* ctx, nk_image img, byte* s, uint align_nkflags, int val) => _nk_select_image_label(ctx, img, s, align_nkflags, val);
		public static int nk_select_image_text(nk_context* ctx, nk_image img, byte* s, int i, uint align_nkflags, int val) => _nk_select_image_text(ctx, img, s, i, align_nkflags, val);
		public static float nk_slide_float(nk_context* ctx, float min, float val, float max, float step) => _nk_slide_float(ctx, min, val, max, step);
		public static int nk_slide_int(nk_context* ctx, int min, int val, int max, int step) => _nk_slide_int(ctx, min, val, max, step);
		public static int nk_slider_float(nk_context* ctx, float min, float* val, float max, float step) => _nk_slider_float(ctx, min, val, max, step);
		public static int nk_slider_int(nk_context* ctx, int min, int* val, int max, int step) => _nk_slider_int(ctx, min, val, max, step);
		public static int nk_progress(nk_context* ctx, IntPtr* cur_nksize, IntPtr max_nksize, int modifyable) => _nk_progress(ctx, cur_nksize, max_nksize, modifyable);
		public static IntPtr nk_prog(nk_context* ctx, IntPtr cur_nksize, IntPtr max_nksize, int modifyable) => _nk_prog(ctx, cur_nksize, max_nksize, modifyable);
		public static nk_color nk_color_picker(nk_context* ctx, nk_color color, nk_color_format cfmt) => _nk_color_picker(ctx, color, cfmt);
		public static int nk_color_pick(nk_context* ctx, nk_color* color, nk_color_format cfmt) => _nk_color_pick(ctx, color, cfmt);
		public static void nk_property_int(nk_context* ctx, byte* name, int min, int* val, int max, int step, float inc_per_pixel) => _nk_property_int(ctx, name, min, val, max, step, inc_per_pixel);
		public static void nk_property_float(nk_context* ctx, byte* name, float min, float* val, float max, float step, float inc_per_pixel) => _nk_property_float(ctx, name, min, val, max, step, inc_per_pixel);
		public static void nk_property_double(nk_context* ctx, byte* name, double min, double* val, double max, double step, float inc_per_pixel) => _nk_property_double(ctx, name, min, val, max, step, inc_per_pixel);
		public static int nk_propertyi(nk_context* ctx, byte* name, int min, int val, int max, int step, float inc_per_pixel) => _nk_propertyi(ctx, name, min, val, max, step, inc_per_pixel);
		public static float nk_propertyf(nk_context* ctx, byte* name, float min, float val, float max, float step, float inc_per_pixel) => _nk_propertyf(ctx, name, min, val, max, step, inc_per_pixel);
		public static double nk_propertyd(nk_context* ctx, byte* name, double min, double val, double max, double step, float inc_per_pixel) => _nk_propertyd(ctx, name, min, val, max, step, inc_per_pixel);
		public static uint nk_edit_string(nk_context* ctx, uint flags_nkflags, byte* buffer, int* len, int max, nk_plugin_filter_t filterfun) => _nk_edit_string(ctx, flags_nkflags, buffer, len, max, filterfun);
		public static uint nk_edit_string_zero_terminated(nk_context* ctx, uint flags_nkflags, byte* buffer, int max, nk_plugin_filter_t filterfun) => _nk_edit_string_zero_terminated(ctx, flags_nkflags, buffer, max, filterfun);
		public static uint nk_edit_buffer(nk_context* ctx, uint flags_nkflags, nk_text_edit* textedit, nk_plugin_filter_t filterfun) => _nk_edit_buffer(ctx, flags_nkflags, textedit, filterfun);
		public static void nk_edit_focus(nk_context* ctx, uint flags_nkflags) => _nk_edit_focus(ctx, flags_nkflags);
		public static void nk_edit_unfocus(nk_context* ctx) => _nk_edit_unfocus(ctx);
		public static int nk_chart_begin(nk_context* ctx, nk_chart_type chatype, int num, float min, float max) => _nk_chart_begin(ctx, chatype, num, min, max);
		public static int nk_chart_begin_colored(nk_context* ctx, nk_chart_type chatype, nk_color color, nk_color active, int num, float min, float max) => _nk_chart_begin_colored(ctx, chatype, color, active, num, min, max);
		public static void nk_chart_add_slot(nk_context* ctx, nk_chart_type chatype, int count, float min_value, float max_value) => _nk_chart_add_slot(ctx, chatype, count, min_value, max_value);
		public static void nk_chart_add_slot_colored(nk_context* ctx, nk_chart_type chatype, nk_color color, nk_color active, int count, float min_value, float max_value) => _nk_chart_add_slot_colored(ctx, chatype, color, active, count, min_value, max_value);
		public static uint nk_chart_push(nk_context* ctx, float f) => _nk_chart_push(ctx, f);
		public static uint nk_chart_push_slot(nk_context* ctx, float f, int i) => _nk_chart_push_slot(ctx, f, i);
		public static void nk_chart_end(nk_context* ctx) => _nk_chart_end(ctx);
		public static void nk_plot(nk_context* ctx, nk_chart_type chatype, float* values, int count, int offset) => _nk_plot(ctx, chatype, values, count, offset);
		public static void nk_plot_function(nk_context* ctx, nk_chart_type chatype, IntPtr userdata, nk_value_getter_fun getterfun, int count, int offset) => _nk_plot_function(ctx, chatype, userdata, getterfun, count, offset);
		public static int nk_popup_begin(nk_context* ctx, nk_popup_type type, byte* s, uint flags_nkflags, nk_rect bounds) => _nk_popup_begin(ctx, type, s, flags_nkflags, bounds);
		public static void nk_popup_close(nk_context* ctx) => _nk_popup_close(ctx);
		public static void nk_popup_end(nk_context* ctx) => _nk_popup_end(ctx);
		public static int nk_combo(nk_context* ctx, byte** items, int count, int selected, int item_height, nk_vec2 size) => _nk_combo(ctx, items, count, selected, item_height, size);
		public static int nk_combo_separator(nk_context* ctx, byte* items_separated_by_separator, int separator, int selected, int count, int item_height, nk_vec2 size) => _nk_combo_separator(ctx, items_separated_by_separator, separator, selected, count, item_height, size);
		public static int nk_combo_string(nk_context* ctx, byte* items_separated_by_zeros, int selected, int count, int item_height, nk_vec2 size) => _nk_combo_string(ctx, items_separated_by_zeros, selected, count, item_height, size);
		public static int nk_combo_callback(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata, int selected, int count, int item_height, nk_vec2 size) => _nk_combo_callback(ctx, getterfun, userdata, selected, count, item_height, size);
		public static void nk_combobox(nk_context* ctx, byte** items, int count, int* selected, int item_height, nk_vec2 size) => _nk_combobox(ctx, items, count, selected, item_height, size);
		public static void nk_combobox_string(nk_context* ctx, byte* items_separated_by_zeros, int* selected, int count, int item_height, nk_vec2 size) => _nk_combobox_string(ctx, items_separated_by_zeros, selected, count, item_height, size);
		public static void nk_combobox_separator(nk_context* ctx, byte* items_separated_by_separator, int separator, int* selected, int count, int item_height, nk_vec2 size) => _nk_combobox_separator(ctx, items_separated_by_separator, separator, selected, count, item_height, size);
		public static void nk_combobox_callback(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata, int* selected, int count, int item_height, nk_vec2 size) => _nk_combobox_callback(ctx, getterfun, userdata, selected, count, item_height, size);
		public static int nk_combo_begin_text(nk_context* ctx, char* selected, int i, nk_vec2 size) => _nk_combo_begin_text(ctx, selected, i, size);
		public static int nk_combo_begin_label(nk_context* ctx, char* selected, nk_vec2 size) => _nk_combo_begin_label(ctx, selected, size);
		public static int nk_combo_begin_color(nk_context* ctx, nk_color color, nk_vec2 size) => _nk_combo_begin_color(ctx, color, size);
		public static int nk_combo_begin_symbol(nk_context* ctx, nk_symbol_type stype, nk_vec2 size) => _nk_combo_begin_symbol(ctx, stype, size);
		public static int nk_combo_begin_symbol_label(nk_context* ctx, char* selected, nk_symbol_type stype, nk_vec2 size) => _nk_combo_begin_symbol_label(ctx, selected, stype, size);
		public static int nk_combo_begin_symbol_text(nk_context* ctx, char* selected, int i, nk_symbol_type stype, nk_vec2 size) => _nk_combo_begin_symbol_text(ctx, selected, i, stype, size);
		public static int nk_combo_begin_image(nk_context* ctx, nk_image img, nk_vec2 size) => _nk_combo_begin_image(ctx, img, size);
		public static int nk_combo_begin_image_label(nk_context* ctx, char* selected, nk_image img, nk_vec2 size) => _nk_combo_begin_image_label(ctx, selected, img, size);
		public static int nk_combo_begin_image_text(nk_context* ctx, char* selected, int i, nk_image img, nk_vec2 size) => _nk_combo_begin_image_text(ctx, selected, i, img, size);
		public static int nk_combo_item_label(nk_context* ctx, byte* s, uint alignment_nkflags) => _nk_combo_item_label(ctx, s, alignment_nkflags);
		public static int nk_combo_item_text(nk_context* ctx, byte* s, int i, uint alignment_nkflags) => _nk_combo_item_text(ctx, s, i, alignment_nkflags);
		public static int nk_combo_item_image_label(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags) => _nk_combo_item_image_label(ctx, img, s, alignment_nkflags);
		public static int nk_combo_item_image_text(nk_context* ctx, nk_image img, byte* s, int i, uint alignment_nkflags) => _nk_combo_item_image_text(ctx, img, s, i, alignment_nkflags);
		public static int nk_combo_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags) => _nk_combo_item_symbol_label(ctx, stype, s, alignment_nkflags);
		public static int nk_combo_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags) => _nk_combo_item_symbol_text(ctx, stype, s, i, alignment_nkflags);
		public static void nk_combo_close(nk_context* ctx) => _nk_combo_close(ctx);
		public static void nk_combo_end(nk_context* ctx) => _nk_combo_end(ctx);
		public static int nk_contextual_begin(nk_context* ctx, uint flags_nkflags, nk_vec2 v, nk_rect trigger_bounds) => _nk_contextual_begin(ctx, flags_nkflags, v, trigger_bounds);
		public static int nk_contextual_item_text(nk_context* ctx, byte* s, int i, uint align_nkflags) => _nk_contextual_item_text(ctx, s, i, align_nkflags);
		public static int nk_contextual_item_label(nk_context* ctx, byte* s, uint align_nkflags) => _nk_contextual_item_label(ctx, s, align_nkflags);
		public static int nk_contextual_item_image_label(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags) => _nk_contextual_item_image_label(ctx, img, s, alignment_nkflags);
		public static int nk_contextual_item_image_text(nk_context* ctx, nk_image img, byte* s, int len, uint alignment_nkflags) => _nk_contextual_item_image_text(ctx, img, s, len, alignment_nkflags);
		public static int nk_contextual_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags) => _nk_contextual_item_symbol_label(ctx, stype, s, alignment_nkflags);
		public static int nk_contextual_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i, uint alignment_nkflags) => _nk_contextual_item_symbol_text(ctx, stype, s, i, alignment_nkflags);
		public static void nk_contextual_close(nk_context* ctx) => _nk_contextual_close(ctx);
		public static void nk_contextual_end(nk_context* ctx) => _nk_contextual_end(ctx);
		public static void nk_tooltip(nk_context* ctx, byte* s) => _nk_tooltip(ctx, s);
		public static int nk_tooltip_begin(nk_context* ctx, float width) => _nk_tooltip_begin(ctx, width);
		public static void nk_tooltip_end(nk_context* ctx) => _nk_tooltip_end(ctx);
		public static void nk_menubar_begin(nk_context* ctx) => _nk_menubar_begin(ctx);
		public static void nk_menubar_end(nk_context* ctx) => _nk_menubar_end(ctx);
		public static int nk_menu_begin_text(nk_context* ctx, byte* title, int title_len, uint align_nkflags, nk_vec2 size) => _nk_menu_begin_text(ctx, title, title_len, align_nkflags, size);
		public static int nk_menu_begin_label(nk_context* ctx, byte* s, uint align_nkflags, nk_vec2 size) => _nk_menu_begin_label(ctx, s, align_nkflags, size);
		public static int nk_menu_begin_image(nk_context* ctx, byte* s, nk_image img, nk_vec2 size) => _nk_menu_begin_image(ctx, s, img, size);
		public static int nk_menu_begin_image_text(nk_context* ctx, byte* s, int slen, uint align_nkflags, nk_image img, nk_vec2 size) => _nk_menu_begin_image_text(ctx, s, slen, align_nkflags, img, size);
		public static int nk_menu_begin_image_label(nk_context* ctx, byte* s, uint align_nkflags, nk_image img, nk_vec2 size) => _nk_menu_begin_image_label(ctx, s, align_nkflags, img, size);
		public static int nk_menu_begin_symbol(nk_context* ctx, byte* s, nk_symbol_type stype, nk_vec2 size) => _nk_menu_begin_symbol(ctx, s, stype, size);
		public static int nk_menu_begin_symbol_text(nk_context* ctx, byte* s, int slen, uint align_nkflags, nk_symbol_type stype, nk_vec2 size) => _nk_menu_begin_symbol_text(ctx, s, slen, align_nkflags, stype, size);
		public static int nk_menu_begin_symbol_label(nk_context* ctx, byte* s, uint align_nkflags, nk_symbol_type stype, nk_vec2 size) => _nk_menu_begin_symbol_label(ctx, s, align_nkflags, stype, size);
		public static int nk_menu_item_text(nk_context* ctx, byte* s, int slen, uint align_nkflags) => _nk_menu_item_text(ctx, s, slen, align_nkflags);
		public static int nk_menu_item_label(nk_context* ctx, byte* s, uint alignment_nkflags) => _nk_menu_item_label(ctx, s, alignment_nkflags);
		public static int nk_menu_item_image_label(nk_context* ctx, nk_image img, byte* s, uint alignment_nkflags) => _nk_menu_item_image_label(ctx, img, s, alignment_nkflags);
		public static int nk_menu_item_image_text(nk_context* ctx, nk_image img, byte* s, int slen, uint alignment_nkflags) => _nk_menu_item_image_text(ctx, img, s, slen, alignment_nkflags);
		public static int nk_menu_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int slen, uint alignment_nkflags) => _nk_menu_item_symbol_text(ctx, stype, s, slen, alignment_nkflags);
		public static int nk_menu_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s, uint alignment_nkflags) => _nk_menu_item_symbol_label(ctx, stype, s, alignment_nkflags);
		public static void nk_menu_close(nk_context* ctx) => _nk_menu_close(ctx);
		public static void nk_menu_end(nk_context* ctx) => _nk_menu_end(ctx);







	}
}
