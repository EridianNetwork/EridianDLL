using System;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007BC RID: 1980
	public class GClass59 : EventDispatcher
	{
		// Token: 0x06003517 RID: 13591 RVA: 0x000F1184 File Offset: 0x000EF384
		public static MovieClip smethod_0(MovieClip movieClip_0, string string_0, Vector2 vector2_0, MovieClip movieClip_1)
		{
			MovieClip movieClip = movieClip_0.parent as MovieClip;
			if (movieClip == null)
			{
				movieClip = movieClip_0;
			}
			if (movieClip_1 != null)
			{
				Vector2 vector = vector2_0;
				vector = GClass20.GClass20_0.method_3(movieClip_1, vector);
				vector = GClass20.GClass20_0.method_2(movieClip, vector);
				vector2_0.x = vector.x;
				vector2_0.y = vector.y;
			}
			MovieClip movieClip2 = new MovieClip();
			movieClip2.name = "popup" + GClass59.int_0++;
			movieClip2.x = vector2_0.x;
			movieClip2.y = vector2_0.y;
			movieClip.addChild(movieClip2);
			return movieClip2;
		}

		// Token: 0x06003518 RID: 13592 RVA: 0x00022E3F File Offset: 0x0002103F
		public static void smethod_1(MovieClip movieClip_0)
		{
			movieClip_0.parent.removeChild(movieClip_0);
		}

		// Token: 0x06003519 RID: 13593 RVA: 0x000F1228 File Offset: 0x000EF428
		public static void smethod_2(MovieClip movieClip_0, MovieClip movieClip_1, MovieClip movieClip_2, int int_1, int int_2)
		{
			if (movieClip_1 == null)
			{
				return;
			}
			MovieClip movieClip = movieClip_0.parent as MovieClip;
			if (movieClip != null)
			{
				movieClip = movieClip_0;
			}
			Vector2 vector = new Vector2((float)int_1, (float)int_2);
			vector = GClass20.GClass20_0.method_3(movieClip_2, vector);
			vector = GClass20.GClass20_0.method_2(movieClip, vector);
			movieClip_1.x = vector.x;
			movieClip_1.y = vector.y;
		}

		// Token: 0x0600351A RID: 13594 RVA: 0x000F128C File Offset: 0x000EF48C
		public static void smethod_3(MovieClip movieClip_0)
		{
			if (movieClip_0 == null)
			{
				return;
			}
			movieClip_0.x = GClass20.GClass20_0.Stage_0.width - movieClip_0.width / 2f;
			movieClip_0.y = GClass20.GClass20_0.Stage_0.height - movieClip_0.height / 2f;
		}

		// Token: 0x0600351B RID: 13595 RVA: 0x000F12E4 File Offset: 0x000EF4E4
		private static MovieClip smethod_4(MovieClip movieClip_0, string string_0, Vector2 vector2_0, MovieClip movieClip_1)
		{
			if (movieClip_1 != null)
			{
				Vector2 vector = new Vector2(vector2_0.x, vector2_0.y);
				vector = GClass20.GClass20_0.method_3(movieClip_1, vector);
				vector = GClass20.GClass20_0.method_2(movieClip_0, vector);
				vector2_0.x = vector.x;
				vector2_0.y = vector.y;
			}
			MovieClip movieClip = new MovieClip();
			movieClip.name = "popup" + GClass59.int_0++;
			movieClip.x = vector2_0.x;
			movieClip.y = vector2_0.y;
			movieClip_0.addChild(movieClip);
			return movieClip;
		}

		// Token: 0x040024B3 RID: 9395
		private static int int_0;
	}
}
