using System;

namespace NuklearSharp
{
	public unsafe delegate void nk_foreach_action(nk_command* c);
	public unsafe delegate void nk_draw_foreach_action(nk_draw_command* dc);

	public static unsafe partial class NuklearNative
	{
		public static void nk_foreach(nk_context* ctx, nk_foreach_action act)
		{
			nk_command* c = null;

			for (c = nk__begin(ctx); c != null; c = nk__next(ctx, c)) {
				act(c);
			}
		}

		public static void nk_draw_foreach(nk_context* ctx, nk_buffer* buf, nk_draw_foreach_action act)
		{
			nk_draw_command* dcmd = null;

			for (dcmd = nk__draw_begin(ctx, buf); dcmd != null; dcmd = nk__draw_next(dcmd, buf, ctx)) {
				act(dcmd);
			}
		}
	}
}
