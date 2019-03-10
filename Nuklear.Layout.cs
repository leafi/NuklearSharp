using System;
using System.Runtime.InteropServices;

namespace NuklearSharp
{
	public static unsafe partial class NuklearNative
	{
		private delegate void nk_layout_set_min_row_height_t(nk_context* ctx, float height);
		private delegate void nk_layout_reset_min_row_height_t(nk_context* ctx);
		private delegate nk_rect nk_layout_widget_bounds_t(nk_context* ctx);
		private delegate float nk_layout_ratio_from_pixel_t(nk_context* ctx, float pixel_width);
		private delegate void nk_layout_row_dynamic_t(nk_context* ctx, float height, int cols);
		private delegate void nk_layout_row_static_t(nk_context* ctx, float height, int item_width, int cols);
		private delegate void nk_layout_row_begin_t(nk_context* ctx, nk_layout_format fmt, float row_height, int cols);
		private delegate void nk_layout_row_push_t(nk_context* ctx, float val);
		private delegate void nk_layout_row_end_t(nk_context* ctx);
		private delegate void nk_layout_row_t(nk_context* ctx, nk_layout_format fmt, float height, int cols, float* ratio);
		private delegate void nk_layout_row_template_begin_t(nk_context* ctx, float row_height);
		private delegate void nk_layout_row_template_push_dynamic_t(nk_context* ctx);
		private delegate void nk_layout_row_template_push_variable_t(nk_context* ctx, float min_width);
		private delegate void nk_layout_row_template_push_static_t(nk_context* ctx, float width);
		private delegate void nk_layout_row_template_end_t(nk_context* ctx);
		private delegate void nk_layout_space_begin_t(nk_context* ctx, nk_layout_format fmt, float height, int widget_count);
		private delegate void nk_layout_space_push_t(nk_context* ctx, nk_rect bounds);
		private delegate void nk_layout_space_end_t(nk_context* ctx);
		private delegate nk_rect nk_layout_space_bounds_t(nk_context* ctx);
		private delegate nk_vec2 nk_layout_space_to_screen_t(nk_context* ctx, nk_vec2 v);
		private delegate nk_vec2 nk_layout_space_to_local_t(nk_context* ctx, nk_vec2 v);
		private delegate nk_rect nk_layout_space_rect_to_screen_t(nk_context* ctx, nk_rect r);
		private delegate nk_rect nk_layout_space_rect_to_local_t(nk_context* ctx, nk_rect r);



		private static nk_layout_set_min_row_height_t _nk_layout_set_min_row_height = LFT<nk_layout_set_min_row_height_t>();
		private static nk_layout_reset_min_row_height_t _nk_layout_reset_min_row_height = LFT<nk_layout_reset_min_row_height_t>();
		private static nk_layout_widget_bounds_t _nk_layout_widget_bounds = LFT<nk_layout_widget_bounds_t>();
		private static nk_layout_ratio_from_pixel_t _nk_layout_ratio_from_pixel = LFT<nk_layout_ratio_from_pixel_t>();
		private static nk_layout_row_dynamic_t _nk_layout_row_dynamic = LFT<nk_layout_row_dynamic_t>();
		private static nk_layout_row_static_t _nk_layout_row_static = LFT<nk_layout_row_static_t>();
		private static nk_layout_row_begin_t _nk_layout_row_begin = LFT<nk_layout_row_begin_t>();
		private static nk_layout_row_push_t _nk_layout_row_push = LFT<nk_layout_row_push_t>();
		private static nk_layout_row_end_t _nk_layout_row_end = LFT<nk_layout_row_end_t>();
		private static nk_layout_row_t _nk_layout_row = LFT<nk_layout_row_t>();
		private static nk_layout_row_template_begin_t _nk_layout_row_template_begin = LFT<nk_layout_row_template_begin_t>();
		private static nk_layout_row_template_push_dynamic_t _nk_layout_row_template_push_dynamic = LFT<nk_layout_row_template_push_dynamic_t>();
		private static nk_layout_row_template_push_variable_t _nk_layout_row_template_push_variable = LFT<nk_layout_row_template_push_variable_t>();
		private static nk_layout_row_template_push_static_t _nk_layout_row_template_push_static = LFT<nk_layout_row_template_push_static_t>();
		private static nk_layout_row_template_end_t _nk_layout_row_template_end = LFT<nk_layout_row_template_end_t>();
		private static nk_layout_space_begin_t _nk_layout_space_begin = LFT<nk_layout_space_begin_t>();
		private static nk_layout_space_push_t _nk_layout_space_push = LFT<nk_layout_space_push_t>();
		private static nk_layout_space_end_t _nk_layout_space_end = LFT<nk_layout_space_end_t>();
		private static nk_layout_space_bounds_t _nk_layout_space_bounds = LFT<nk_layout_space_bounds_t>();
		private static nk_layout_space_to_screen_t _nk_layout_space_to_screen = LFT<nk_layout_space_to_screen_t>();
		private static nk_layout_space_to_local_t _nk_layout_space_to_local = LFT<nk_layout_space_to_local_t>();
		private static nk_layout_space_rect_to_screen_t _nk_layout_space_rect_to_screen = LFT<nk_layout_space_rect_to_screen_t>();
		private static nk_layout_space_rect_to_local_t _nk_layout_space_rect_to_local = LFT<nk_layout_space_rect_to_local_t>();

		public static void nk_layout_set_min_row_height(nk_context* ctx, float height) => _nk_layout_set_min_row_height(ctx, height);
		public static void nk_layout_reset_min_row_height(nk_context* ctx) => _nk_layout_reset_min_row_height(ctx);
		public static nk_rect nk_layout_widget_bounds(nk_context* ctx) => _nk_layout_widget_bounds(ctx);
		public static float nk_layout_ratio_from_pixel(nk_context* ctx, float pixel_width) => _nk_layout_ratio_from_pixel(ctx, pixel_width);
		public static void nk_layout_row_dynamic(nk_context* ctx, float height, int cols) => _nk_layout_row_dynamic(ctx, height, cols);
		public static void nk_layout_row_static(nk_context* ctx, float height, int item_width, int cols) => _nk_layout_row_static(ctx, height, item_width, cols);
		public static void nk_layout_row_begin(nk_context* ctx, nk_layout_format fmt, float row_height, int cols) => _nk_layout_row_begin(ctx, fmt, row_height, cols);
		public static void nk_layout_row_push(nk_context* ctx, float val) => _nk_layout_row_push(ctx, val);
		public static void nk_layout_row_end(nk_context* ctx) => _nk_layout_row_end(ctx);
		public static void nk_layout_row(nk_context* ctx, nk_layout_format fmt, float height, int cols, float* ratio) => _nk_layout_row(ctx, fmt, height, cols, ratio);
		public static void nk_layout_row_template_begin(nk_context* ctx, float row_height) => _nk_layout_row_template_begin(ctx, row_height);
		public static void nk_layout_row_template_push_dynamic(nk_context* ctx) => _nk_layout_row_template_push_dynamic(ctx);
		public static void nk_layout_row_template_push_variable(nk_context* ctx, float min_width) => _nk_layout_row_template_push_variable(ctx, min_width);
		public static void nk_layout_row_template_push_static(nk_context* ctx, float width) => _nk_layout_row_template_push_static(ctx, width);
		public static void nk_layout_row_template_end(nk_context* ctx) => _nk_layout_row_template_end(ctx);
		public static void nk_layout_space_begin(nk_context* ctx, nk_layout_format fmt, float height, int widget_count) => _nk_layout_space_begin(ctx, fmt, height, widget_count);
		public static void nk_layout_space_push(nk_context* ctx, nk_rect bounds) => _nk_layout_space_push(ctx, bounds);
		public static void nk_layout_space_end(nk_context* ctx) => _nk_layout_space_end(ctx);
		public static nk_rect nk_layout_space_bounds(nk_context* ctx) => _nk_layout_space_bounds(ctx);
		public static nk_vec2 nk_layout_space_to_screen(nk_context* ctx, nk_vec2 v) => _nk_layout_space_to_screen(ctx, v);
		public static nk_vec2 nk_layout_space_to_local(nk_context* ctx, nk_vec2 v) => _nk_layout_space_to_local(ctx, v);
		public static nk_rect nk_layout_space_rect_to_screen(nk_context* ctx, nk_rect r) => _nk_layout_space_rect_to_screen(ctx, r);
		public static nk_rect nk_layout_space_rect_to_local(nk_context* ctx, nk_rect r) => _nk_layout_space_rect_to_local(ctx, r);

	}
}
