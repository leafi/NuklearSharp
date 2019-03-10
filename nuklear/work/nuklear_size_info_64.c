#include "nuklear_impl.c"
#include "stdint.h"
#include "stdio.h"

int main() {
  
  printf("\nBefore we begin: SIZE OF UINTPTR_T: C# 8 bytes, C %lu bytes\n==========\n", sizeof(uintptr_t));
  printf("nk_allocation_type: c# size 4, C size %lu\n", sizeof(enum nk_allocation_type));
  if (4 != sizeof(enum nk_allocation_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_allocator: c# size 24, C size %lu\n", sizeof(struct nk_allocator));
  if (24 != sizeof(struct nk_allocator)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_anti_aliasing: c# size 4, C size %lu\n", sizeof(enum nk_anti_aliasing));
  if (4 != sizeof(enum nk_anti_aliasing)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_baked_font: c# size 32, C size %lu\n", sizeof(struct nk_baked_font));
  if (32 != sizeof(struct nk_baked_font)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_buffer: c# size 120, C size %lu\n", sizeof(struct nk_buffer));
  if (120 != sizeof(struct nk_buffer)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_buffer_allocation_type: c# size 4, C size %lu\n", sizeof(enum nk_buffer_allocation_type));
  if (4 != sizeof(enum nk_buffer_allocation_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_buffer_marker: c# size 16, C size %lu\n", sizeof(struct nk_buffer_marker));
  if (16 != sizeof(struct nk_buffer_marker)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_button_behavior: c# size 4, C size %lu\n", sizeof(enum nk_button_behavior));
  if (4 != sizeof(enum nk_button_behavior)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_buttons: c# size 4, C size %lu\n", sizeof(enum nk_buttons));
  if (4 != sizeof(enum nk_buttons)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_chart: c# size 180, C size %lu\n", sizeof(struct nk_chart));
  if (180 != sizeof(struct nk_chart)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_chart_event: c# size 4, C size %lu\n", sizeof(enum nk_chart_event));
  if (4 != sizeof(enum nk_chart_event)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_chart_slot: c# size 40, C size %lu\n", sizeof(struct nk_chart_slot));
  if (40 != sizeof(struct nk_chart_slot)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_chart_type: c# size 4, C size %lu\n", sizeof(enum nk_chart_type));
  if (4 != sizeof(enum nk_chart_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_clipboard: c# size 24, C size %lu\n", sizeof(struct nk_clipboard));
  if (24 != sizeof(struct nk_clipboard)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_collapse_states: c# size 4, C size %lu\n", sizeof(enum nk_collapse_states));
  if (4 != sizeof(enum nk_collapse_states)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_color: c# size 4, C size %lu\n", sizeof(struct nk_color));
  if (4 != sizeof(struct nk_color)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_color_format: c# size 4, C size %lu\n", sizeof(enum nk_color_format));
  if (4 != sizeof(enum nk_color_format)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_colorf: c# size 16, C size %lu\n", sizeof(struct nk_colorf));
  if (16 != sizeof(struct nk_colorf)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command: c# size 24, C size %lu\n", sizeof(struct nk_command));
  if (24 != sizeof(struct nk_command)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_arc: c# size 48, C size %lu\n", sizeof(struct nk_command_arc));
  if (48 != sizeof(struct nk_command_arc)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_arc_filled: c# size 48, C size %lu\n", sizeof(struct nk_command_arc_filled));
  if (48 != sizeof(struct nk_command_arc_filled)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_buffer: c# size 64, C size %lu\n", sizeof(struct nk_command_buffer));
  if (64 != sizeof(struct nk_command_buffer)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_circle: c# size 40, C size %lu\n", sizeof(struct nk_command_circle));
  if (40 != sizeof(struct nk_command_circle)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_circle_filled: c# size 40, C size %lu\n", sizeof(struct nk_command_circle_filled));
  if (40 != sizeof(struct nk_command_circle_filled)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_clipping: c# size 4, C size %lu\n", sizeof(enum nk_command_clipping));
  if (4 != sizeof(enum nk_command_clipping)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_curve: c# size 48, C size %lu\n", sizeof(struct nk_command_curve));
  if (48 != sizeof(struct nk_command_curve)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_custom: c# size 48, C size %lu\n", sizeof(struct nk_command_custom));
  if (48 != sizeof(struct nk_command_custom)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_image: c# size 64, C size %lu\n", sizeof(struct nk_command_image));
  if (64 != sizeof(struct nk_command_image)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_line: c# size 40, C size %lu\n", sizeof(struct nk_command_line));
  if (40 != sizeof(struct nk_command_line)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_polygon: c# size 40, C size %lu\n", sizeof(struct nk_command_polygon));
  if (40 != sizeof(struct nk_command_polygon)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_polygon_filled: c# size 40, C size %lu\n", sizeof(struct nk_command_polygon_filled));
  if (40 != sizeof(struct nk_command_polygon_filled)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_polyline: c# size 40, C size %lu\n", sizeof(struct nk_command_polyline));
  if (40 != sizeof(struct nk_command_polyline)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_rect: c# size 40, C size %lu\n", sizeof(struct nk_command_rect));
  if (40 != sizeof(struct nk_command_rect)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_rect_filled: c# size 40, C size %lu\n", sizeof(struct nk_command_rect_filled));
  if (40 != sizeof(struct nk_command_rect_filled)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_rect_multi_color: c# size 48, C size %lu\n", sizeof(struct nk_command_rect_multi_color));
  if (48 != sizeof(struct nk_command_rect_multi_color)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_scissor: c# size 32, C size %lu\n", sizeof(struct nk_command_scissor));
  if (32 != sizeof(struct nk_command_scissor)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_text: c# size 64, C size %lu\n", sizeof(struct nk_command_text));
  if (64 != sizeof(struct nk_command_text)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_triangle: c# size 48, C size %lu\n", sizeof(struct nk_command_triangle));
  if (48 != sizeof(struct nk_command_triangle)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_triangle_filled: c# size 40, C size %lu\n", sizeof(struct nk_command_triangle_filled));
  if (40 != sizeof(struct nk_command_triangle_filled)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_command_type: c# size 4, C size %lu\n", sizeof(enum nk_command_type));
  if (4 != sizeof(enum nk_command_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_button_behavior: c# size 136, C size %lu\n", sizeof(struct nk_config_stack_button_behavior));
  if (136 != sizeof(struct nk_config_stack_button_behavior)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_button_behavior_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_button_behavior_element));
  if (16 != sizeof(struct nk_config_stack_button_behavior_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_color: c# size 520, C size %lu\n", sizeof(struct nk_config_stack_color));
  if (520 != sizeof(struct nk_config_stack_color)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_color_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_color_element));
  if (16 != sizeof(struct nk_config_stack_color_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_flags: c# size 520, C size %lu\n", sizeof(struct nk_config_stack_flags));
  if (520 != sizeof(struct nk_config_stack_flags)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_flags_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_flags_element));
  if (16 != sizeof(struct nk_config_stack_flags_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_float: c# size 520, C size %lu\n", sizeof(struct nk_config_stack_float));
  if (520 != sizeof(struct nk_config_stack_float)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_float_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_float_element));
  if (16 != sizeof(struct nk_config_stack_float_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_style_item: c# size 648, C size %lu\n", sizeof(struct nk_config_stack_style_item));
  if (648 != sizeof(struct nk_config_stack_style_item)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_style_item_element: c# size 40, C size %lu\n", sizeof(struct nk_config_stack_style_item_element));
  if (40 != sizeof(struct nk_config_stack_style_item_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_user_font: c# size 136, C size %lu\n", sizeof(struct nk_config_stack_user_font));
  if (136 != sizeof(struct nk_config_stack_user_font)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_user_font_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_user_font_element));
  if (16 != sizeof(struct nk_config_stack_user_font_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_vec2: c# size 264, C size %lu\n", sizeof(struct nk_config_stack_vec2));
  if (264 != sizeof(struct nk_config_stack_vec2)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_config_stack_vec2_element: c# size 16, C size %lu\n", sizeof(struct nk_config_stack_vec2_element));
  if (16 != sizeof(struct nk_config_stack_vec2_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_configuration_stacks: c# size 2744, C size %lu\n", sizeof(struct nk_configuration_stacks));
  if (2744 != sizeof(struct nk_configuration_stacks)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_context: c# size 16640, C size %lu\n", sizeof(struct nk_context));
  if (16640 != sizeof(struct nk_context)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_convert_config: c# size 64, C size %lu\n", sizeof(struct nk_convert_config));
  if (64 != sizeof(struct nk_convert_config)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_convert_result: c# size 4, C size %lu\n", sizeof(enum nk_convert_result));
  if (4 != sizeof(enum nk_convert_result)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_cursor: c# size 40, C size %lu\n", sizeof(struct nk_cursor));
  if (40 != sizeof(struct nk_cursor)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_command: c# size 40, C size %lu\n", sizeof(struct nk_draw_command));
  if (40 != sizeof(struct nk_draw_command)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_list: c# size 248, C size %lu\n", sizeof(struct nk_draw_list));
  if (248 != sizeof(struct nk_draw_list)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_list_stroke: c# size 4, C size %lu\n", sizeof(enum nk_draw_list_stroke));
  if (4 != sizeof(enum nk_draw_list_stroke)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_null_texture: c# size 16, C size %lu\n", sizeof(struct nk_draw_null_texture));
  if (16 != sizeof(struct nk_draw_null_texture)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_vertex_layout_attribute: c# size 4, C size %lu\n", sizeof(enum nk_draw_vertex_layout_attribute));
  if (4 != sizeof(enum nk_draw_vertex_layout_attribute)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_vertex_layout_element: c# size 16, C size %lu\n", sizeof(struct nk_draw_vertex_layout_element));
  if (16 != sizeof(struct nk_draw_vertex_layout_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_draw_vertex_layout_format: c# size 4, C size %lu\n", sizeof(enum nk_draw_vertex_layout_format));
  if (4 != sizeof(enum nk_draw_vertex_layout_format)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_edit_events: c# size 4, C size %lu\n", sizeof(enum nk_edit_events));
  if (4 != sizeof(enum nk_edit_events)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_edit_flags: c# size 4, C size %lu\n", sizeof(enum nk_edit_flags));
  if (4 != sizeof(enum nk_edit_flags)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_edit_state: c# size 44, C size %lu\n", sizeof(struct nk_edit_state));
  if (44 != sizeof(struct nk_edit_state)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_edit_types: c# size 4, C size %lu\n", sizeof(enum nk_edit_types));
  if (4 != sizeof(enum nk_edit_types)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font: c# size 128, C size %lu\n", sizeof(struct nk_font));
  if (128 != sizeof(struct nk_font)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font_atlas: c# size 400, C size %lu\n", sizeof(struct nk_font_atlas));
  if (400 != sizeof(struct nk_font_atlas)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font_atlas_format: c# size 4, C size %lu\n", sizeof(enum nk_font_atlas_format));
  if (4 != sizeof(enum nk_font_atlas_format)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font_config: c# size 88, C size %lu\n", sizeof(struct nk_font_config));
  if (88 != sizeof(struct nk_font_config)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font_coord_type: c# size 4, C size %lu\n", sizeof(enum nk_font_coord_type));
  if (4 != sizeof(enum nk_font_coord_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_font_glyph: c# size 48, C size %lu\n", sizeof(struct nk_font_glyph));
  if (48 != sizeof(struct nk_font_glyph)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_glyph: c# size 4, C size %lu\n", sizeof( nk_glyph));
  if (4 != sizeof( nk_glyph)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_handle: c# size 8, C size %lu\n", sizeof( nk_handle));
  if (8 != sizeof( nk_handle)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_heading: c# size 4, C size %lu\n", sizeof(enum nk_heading));
  if (4 != sizeof(enum nk_heading)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_image: c# size 24, C size %lu\n", sizeof(struct nk_image));
  if (24 != sizeof(struct nk_image)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_input: c# size 360, C size %lu\n", sizeof(struct nk_input));
  if (360 != sizeof(struct nk_input)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_key: c# size 8, C size %lu\n", sizeof(struct nk_key));
  if (8 != sizeof(struct nk_key)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_keyboard: c# size 260, C size %lu\n", sizeof(struct nk_keyboard));
  if (260 != sizeof(struct nk_keyboard)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_keys: c# size 4, C size %lu\n", sizeof(enum nk_keys));
  if (4 != sizeof(enum nk_keys)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_layout_format: c# size 4, C size %lu\n", sizeof(enum nk_layout_format));
  if (4 != sizeof(enum nk_layout_format)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_list_view: c# size 40, C size %lu\n", sizeof(struct nk_list_view));
  if (40 != sizeof(struct nk_list_view)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_memory: c# size 16, C size %lu\n", sizeof(struct nk_memory));
  if (16 != sizeof(struct nk_memory)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_memory_status: c# size 48, C size %lu\n", sizeof(struct nk_memory_status));
  if (48 != sizeof(struct nk_memory_status)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_menu_state: c# size 24, C size %lu\n", sizeof(struct nk_menu_state));
  if (24 != sizeof(struct nk_menu_state)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_modify: c# size 4, C size %lu\n", sizeof(enum nk_modify));
  if (4 != sizeof(enum nk_modify)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_mouse: c# size 100, C size %lu\n", sizeof(struct nk_mouse));
  if (100 != sizeof(struct nk_mouse)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_mouse_button: c# size 16, C size %lu\n", sizeof(struct nk_mouse_button));
  if (16 != sizeof(struct nk_mouse_button)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_orientation: c# size 4, C size %lu\n", sizeof(enum nk_orientation));
  if (4 != sizeof(enum nk_orientation)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_page: c# size 528, C size %lu\n", sizeof(struct nk_page));
  if (528 != sizeof(struct nk_page)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_page_data: c# size 496, C size %lu\n", sizeof(union nk_page_data));
  if (496 != sizeof(union nk_page_data)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_page_element: c# size 512, C size %lu\n", sizeof(struct nk_page_element));
  if (512 != sizeof(struct nk_page_element)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_panel: c# size 448, C size %lu\n", sizeof(struct nk_panel));
  if (448 != sizeof(struct nk_panel)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_panel_flags: c# size 4, C size %lu\n", sizeof(enum nk_panel_flags));
  if (4 != sizeof(enum nk_panel_flags)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_panel_row_layout_type: c# size 4, C size %lu\n", sizeof(enum nk_panel_row_layout_type));
  if (4 != sizeof(enum nk_panel_row_layout_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_panel_set: c# size 4, C size %lu\n", sizeof(enum nk_panel_set));
  if (4 != sizeof(enum nk_panel_set)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_panel_type: c# size 4, C size %lu\n", sizeof(enum nk_panel_type));
  if (4 != sizeof(enum nk_panel_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_pool: c# size 72, C size %lu\n", sizeof(struct nk_pool));
  if (72 != sizeof(struct nk_pool)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_popup_buffer: c# size 40, C size %lu\n", sizeof(struct nk_popup_buffer));
  if (40 != sizeof(struct nk_popup_buffer)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_popup_state: c# size 96, C size %lu\n", sizeof(struct nk_popup_state));
  if (96 != sizeof(struct nk_popup_state)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_popup_type: c# size 4, C size %lu\n", sizeof(enum nk_popup_type));
  if (4 != sizeof(enum nk_popup_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_property_state: c# size 104, C size %lu\n", sizeof(struct nk_property_state));
  if (104 != sizeof(struct nk_property_state)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_rect: c# size 16, C size %lu\n", sizeof(struct nk_rect));
  if (16 != sizeof(struct nk_rect)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_recti: c# size 8, C size %lu\n", sizeof(struct nk_recti));
  if (8 != sizeof(struct nk_recti)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_row_layout: c# size 136, C size %lu\n", sizeof(struct nk_row_layout));
  if (136 != sizeof(struct nk_row_layout)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_scroll: c# size 8, C size %lu\n", sizeof(struct nk_scroll));
  if (8 != sizeof(struct nk_scroll)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_show_states: c# size 4, C size %lu\n", sizeof(enum nk_show_states));
  if (4 != sizeof(enum nk_show_states)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_str: c# size 128, C size %lu\n", sizeof(struct nk_str));
  if (128 != sizeof(struct nk_str)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style: c# size 7544, C size %lu\n", sizeof(struct nk_style));
  if (7544 != sizeof(struct nk_style)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_button: c# size 176, C size %lu\n", sizeof(struct nk_style_button));
  if (176 != sizeof(struct nk_style_button)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_chart: c# size 64, C size %lu\n", sizeof(struct nk_style_chart));
  if (64 != sizeof(struct nk_style_chart)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_colors: c# size 4, C size %lu\n", sizeof(enum nk_style_colors));
  if (4 != sizeof(enum nk_style_colors)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_combo: c# size 352, C size %lu\n", sizeof(struct nk_style_combo));
  if (352 != sizeof(struct nk_style_combo)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_cursor: c# size 4, C size %lu\n", sizeof(enum nk_style_cursor));
  if (4 != sizeof(enum nk_style_cursor)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_edit: c# size 800, C size %lu\n", sizeof(struct nk_style_edit));
  if (800 != sizeof(struct nk_style_edit)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_header_align: c# size 4, C size %lu\n", sizeof(enum nk_style_header_align));
  if (4 != sizeof(enum nk_style_header_align)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_item: c# size 32, C size %lu\n", sizeof(struct nk_style_item));
  if (32 != sizeof(struct nk_style_item)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_item_data: c# size 24, C size %lu\n", sizeof(union nk_style_item_data));
  if (24 != sizeof(union nk_style_item_data)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_item_type: c# size 4, C size %lu\n", sizeof(enum nk_style_item_type));
  if (4 != sizeof(enum nk_style_item_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_progress: c# size 256, C size %lu\n", sizeof(struct nk_style_progress));
  if (256 != sizeof(struct nk_style_progress)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_property: c# size 1312, C size %lu\n", sizeof(struct nk_style_property));
  if (1312 != sizeof(struct nk_style_property)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_scrollbar: c# size 616, C size %lu\n", sizeof(struct nk_style_scrollbar));
  if (616 != sizeof(struct nk_style_scrollbar)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_selectable: c# size 280, C size %lu\n", sizeof(struct nk_style_selectable));
  if (280 != sizeof(struct nk_style_selectable)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_slider: c# size 640, C size %lu\n", sizeof(struct nk_style_slider));
  if (640 != sizeof(struct nk_style_slider)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_tab: c# size 784, C size %lu\n", sizeof(struct nk_style_tab));
  if (784 != sizeof(struct nk_style_tab)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_text: c# size 12, C size %lu\n", sizeof(struct nk_style_text));
  if (12 != sizeof(struct nk_style_text)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_toggle: c# size 240, C size %lu\n", sizeof(struct nk_style_toggle));
  if (240 != sizeof(struct nk_style_toggle)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_window: c# size 720, C size %lu\n", sizeof(struct nk_style_window));
  if (720 != sizeof(struct nk_style_window)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_style_window_header: c# size 504, C size %lu\n", sizeof(struct nk_style_window_header));
  if (504 != sizeof(struct nk_style_window_header)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_symbol_type: c# size 4, C size %lu\n", sizeof(enum nk_symbol_type));
  if (4 != sizeof(enum nk_symbol_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_table: c# size 496, C size %lu\n", sizeof(struct nk_table));
  if (496 != sizeof(struct nk_table)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_align: c# size 4, C size %lu\n", sizeof(enum nk_text_align));
  if (4 != sizeof(enum nk_text_align)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_alignment: c# size 4, C size %lu\n", sizeof(enum nk_text_alignment));
  if (4 != sizeof(enum nk_text_alignment)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_edit: c# size 5384, C size %lu\n", sizeof(struct nk_text_edit));
  if (5384 != sizeof(struct nk_text_edit)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_edit_mode: c# size 4, C size %lu\n", sizeof(enum nk_text_edit_mode));
  if (4 != sizeof(enum nk_text_edit_mode)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_edit_type: c# size 4, C size %lu\n", sizeof(enum nk_text_edit_type));
  if (4 != sizeof(enum nk_text_edit_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_undo_record: c# size 12, C size %lu\n", sizeof(struct nk_text_undo_record));
  if (12 != sizeof(struct nk_text_undo_record)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_text_undo_state: c# size 5192, C size %lu\n", sizeof(struct nk_text_undo_state));
  if (5192 != sizeof(struct nk_text_undo_state)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_tree_type: c# size 4, C size %lu\n", sizeof(enum nk_tree_type));
  if (4 != sizeof(enum nk_tree_type)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_user_font: c# size 40, C size %lu\n", sizeof(struct nk_user_font));
  if (40 != sizeof(struct nk_user_font)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_user_font_glyph: c# size 36, C size %lu\n", sizeof(struct nk_user_font_glyph));
  if (36 != sizeof(struct nk_user_font_glyph)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_vec2: c# size 8, C size %lu\n", sizeof(struct nk_vec2));
  if (8 != sizeof(struct nk_vec2)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_vec2i: c# size 4, C size %lu\n", sizeof(struct nk_vec2i));
  if (4 != sizeof(struct nk_vec2i)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_widget_layout_states: c# size 4, C size %lu\n", sizeof(enum nk_widget_layout_states));
  if (4 != sizeof(enum nk_widget_layout_states)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_widget_states: c# size 4, C size %lu\n", sizeof(enum nk_widget_states));
  if (4 != sizeof(enum nk_widget_states)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_window: c# size 472, C size %lu\n", sizeof(struct nk_window));
  if (472 != sizeof(struct nk_window)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  printf("nk_window_flags: c# size 4, C size %lu\n", sizeof(enum nk_window_flags));
  if (4 != sizeof(enum nk_window_flags)) { printf("!!!!! ^^^^^ SIZE DIFFERS! ^^^^^ !!!!!\n"); }
  return 0;
}

