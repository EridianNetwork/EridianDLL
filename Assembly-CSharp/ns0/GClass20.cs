using System;
using Core;
using pumpkin.display;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007AC RID: 1964
	public class GClass20
	{
		// Token: 0x060034A4 RID: 13476 RVA: 0x000227DF File Offset: 0x000209DF
		private GClass20()
		{
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060034A5 RID: 13477 RVA: 0x00022808 File Offset: 0x00020A08
		public static GClass20 GClass20_0
		{
			get
			{
				if (GClass20.gclass20_0 == null)
				{
					GClass20.gclass20_0 = new GClass20();
				}
				return GClass20.gclass20_0;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060034A6 RID: 13478 RVA: 0x00022820 File Offset: 0x00020A20
		// (set) Token: 0x060034A7 RID: 13479 RVA: 0x00022828 File Offset: 0x00020A28
		public Stage Stage_0
		{
			get
			{
				return this.stage_0;
			}
			set
			{
				this.stage_0 = value;
				if (this.stage_0 != null)
				{
					if (this.gclass21_0 == null)
					{
						this.gclass21_0 = new GClass21(this.stage_0);
					}
				}
				else
				{
					this.gclass21_0 = null;
				}
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060034A8 RID: 13480 RVA: 0x0002285B File Offset: 0x00020A5B
		public float Single_0
		{
			get
			{
				return this.float_2;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060034A9 RID: 13481 RVA: 0x00022863 File Offset: 0x00020A63
		public float Single_1
		{
			get
			{
				return this.float_3;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060034AA RID: 13482 RVA: 0x0002286B File Offset: 0x00020A6B
		public float Single_2
		{
			get
			{
				return this.float_4;
			}
		}

		// Token: 0x060034AB RID: 13483 RVA: 0x000F06C8 File Offset: 0x000EE8C8
		public void OnScreenResize(float fSceenW, float fScreenH)
		{
			float num = fSceenW / 1280f;
			float num2 = fScreenH / 720f;
			this.float_2 = Mathf.Min(num, num2);
			this.float_3 = 1280f * num / this.float_2;
			this.float_4 = 720f * num2 / this.float_2;
		}

		// Token: 0x060034AC RID: 13484 RVA: 0x000F071C File Offset: 0x000EE91C
		private void method_0(DisplayObject displayObject_0, Vector2 vector2_0, ref Vector2 vector2_1)
		{
			if (displayObject_0 == null)
			{
				return;
			}
			vector2_1.x = vector2_0.x - displayObject_0.x;
			vector2_1.y = vector2_0.y - displayObject_0.y;
			this.method_0(displayObject_0.parent, vector2_1, ref vector2_1);
		}

		// Token: 0x060034AD RID: 13485 RVA: 0x000F0768 File Offset: 0x000EE968
		private void method_1(DisplayObject displayObject_0, Vector2 vector2_0, ref Vector2 vector2_1)
		{
			if (displayObject_0 == null)
			{
				return;
			}
			vector2_1.x = vector2_0.x + displayObject_0.x;
			vector2_1.y = vector2_0.y + displayObject_0.y;
			this.method_1(displayObject_0.parent, vector2_1, ref vector2_1);
		}

		// Token: 0x060034AE RID: 13486 RVA: 0x000F07B4 File Offset: 0x000EE9B4
		public Vector2 method_2(DisplayObject displayObject_0, Vector2 vector2_0)
		{
			Vector2 zero = Vector2.zero;
			this.method_0(displayObject_0, vector2_0, ref zero);
			return zero;
		}

		// Token: 0x060034AF RID: 13487 RVA: 0x000F07D4 File Offset: 0x000EE9D4
		public Vector2 method_3(DisplayObject displayObject_0, Vector2 vector2_0)
		{
			Vector2 zero = Vector2.zero;
			this.method_1(displayObject_0, vector2_0, ref zero);
			return zero;
		}

		// Token: 0x060034B0 RID: 13488 RVA: 0x000F07F4 File Offset: 0x000EE9F4
		public bool method_4(DisplayObject displayObject_0, string string_0)
		{
			if (this.Stage_0 != null && this.gclass21_0 != null)
			{
				this.gclass21_0.method_2(displayObject_0, string_0);
				return false;
			}
			DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[] { "FlashGlobal stage is ", this.stage_0, " or _layerManager is ", this.gclass21_0, "!!" }));
			return false;
		}

		// Token: 0x060034B1 RID: 13489 RVA: 0x00022873 File Offset: 0x00020A73
		public int method_5(string string_0)
		{
			if (this.gclass21_0 != null)
			{
				return this.gclass21_0.method_1(string_0);
			}
			return -1;
		}

		// Token: 0x060034B2 RID: 13490 RVA: 0x0002288B File Offset: 0x00020A8B
		public void method_6(DisplayObject displayObject_0, string string_0)
		{
			if (this.gclass21_0 != null)
			{
				this.gclass21_0.method_3(displayObject_0, string_0);
			}
		}

		// Token: 0x060034B3 RID: 13491 RVA: 0x000228A3 File Offset: 0x00020AA3
		public void method_7(DisplayObject displayObject_0)
		{
			if (this.gclass21_0 != null)
			{
				this.gclass21_0.method_4(displayObject_0);
			}
		}

		// Token: 0x060034B4 RID: 13492 RVA: 0x000228B9 File Offset: 0x00020AB9
		public void method_8(bool bool_0, string string_0)
		{
			if (this.gclass21_0 != null)
			{
				this.gclass21_0.method_5(bool_0, string_0);
			}
		}

		// Token: 0x0400246F RID: 9327
		public const float float_0 = 1280f;

		// Token: 0x04002470 RID: 9328
		public const float float_1 = 720f;

		// Token: 0x04002471 RID: 9329
		private static GClass20 gclass20_0;

		// Token: 0x04002472 RID: 9330
		protected Stage stage_0;

		// Token: 0x04002473 RID: 9331
		protected float float_2 = 1f;

		// Token: 0x04002474 RID: 9332
		public float float_3 = 1280f;

		// Token: 0x04002475 RID: 9333
		public float float_4 = 720f;

		// Token: 0x04002476 RID: 9334
		protected GClass21 gclass21_0;
	}
}
