
#define NK_INCLUDE_VERTEX_BUFFER_OUTPUT
#define NK_INCLUDE_COMMAND_USERDATA
#define NK_ZERO_COMMAND_MEMORY
/* NK_BUFFER_DEFAULT_INITIAL_SIZE not defined => default 4k */

/* include default built-in fonts */
#define NK_INCLUDE_FONT_BAKING
#define NK_INCLUDE_DEFAULT_FONT

/* for my sins, I use GLFW - so: */
#define NK_KEYSTATE_BASED_INPUT

/* type assertions go badly on my cross-compiled MINGW64 build (to win, from linux), so do this! */
#if defined(__MINGW64__)
#define NK_INCLUDE_FIXED_TYPES
#endif
/* ...on other platforms, we'll let types be inferred and see how things go. */

#include "nuklear.h"

/* double-check mingw64 build */
#if defined(__MINGW64__)
NK_STATIC_ASSERT(sizeof(nk_size) == 8);
NK_STATIC_ASSERT(sizeof(nk_ptr) == 8);
#endif
