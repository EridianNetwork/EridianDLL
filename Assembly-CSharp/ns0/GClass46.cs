using System;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007A4 RID: 1956
	public class GClass46 : GClass45
	{
		// Token: 0x06003409 RID: 13321 RVA: 0x00022009 File Offset: 0x00020209
		protected override void vmethod_0()
		{
			base.vmethod_0();
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600340A RID: 13322 RVA: 0x00022011 File Offset: 0x00020211
		// (set) Token: 0x0600340B RID: 13323 RVA: 0x00022019 File Offset: 0x00020219
		public override bool Boolean_6
		{
			get
			{
				return base.Boolean_6;
			}
			set
			{
				base.Boolean_6 = value;
				base.method_3(new string[] { GClass22.string_2 });
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600340C RID: 13324 RVA: 0x00022036 File Offset: 0x00020236
		// (set) Token: 0x0600340D RID: 13325 RVA: 0x0002203E File Offset: 0x0002023E
		public override int Int32_1
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
				this.method_24();
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x0600340E RID: 13326 RVA: 0x0002204D File Offset: 0x0002024D
		// (set) Token: 0x0600340F RID: 13327 RVA: 0x00022055 File Offset: 0x00020255
		public string String_0
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (value == this.string_1)
				{
					return;
				}
				this.string_1 = value;
			}
		}

		// Token: 0x06003410 RID: 13328 RVA: 0x0002206D File Offset: 0x0002026D
		public void method_12(CEvent cevent_0)
		{
			this.method_25(cevent_0);
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06003411 RID: 13329 RVA: 0x00022076 File Offset: 0x00020276
		public override int Int32_2
		{
			get
			{
				return Mathf.RoundToInt(this.movieClip_1.height - this.gclass25_0.DisplayObjectContainer_0.height + (float)this.int_1 + (float)this.int_0);
			}
		}

		// Token: 0x06003412 RID: 13330 RVA: 0x000EEB2C File Offset: 0x000ECD2C
		protected override void vmethod_4()
		{
			base.vmethod_4();
			this.movieClip_0.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.method_25), false);
			if (this.gclass25_1 != null)
			{
				this.gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15), false);
				this.gclass25_1.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_16), false);
			}
			if (this.gclass25_2 != null)
			{
				this.gclass25_2.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_17), false);
				this.gclass25_2.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_18), false);
			}
			this.gclass25_0.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_19), false);
			this.movieClip_1.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_22), false);
			this.movieClip_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_23), false);
		}

		// Token: 0x06003413 RID: 13331 RVA: 0x000220A9 File Offset: 0x000202A9
		protected void method_13()
		{
			this.Int32_1 -= this.int_5;
		}

		// Token: 0x06003414 RID: 13332 RVA: 0x000220BE File Offset: 0x000202BE
		protected void method_14()
		{
			this.Int32_1 += this.int_5;
		}

		// Token: 0x06003415 RID: 13333 RVA: 0x000220D3 File Offset: 0x000202D3
		protected override void vmethod_8()
		{
			this.gclass25_0.DisplayObjectContainer_0.y = this.movieClip_1.y - (float)this.int_0;
		}

		// Token: 0x06003416 RID: 13334 RVA: 0x000220F8 File Offset: 0x000202F8
		protected override void vmethod_9()
		{
			if (this.gclass25_0 is GClass24)
			{
				this.gclass25_0.vmethod_2();
			}
			this.vmethod_10();
		}

		// Token: 0x06003417 RID: 13335 RVA: 0x000EEC40 File Offset: 0x000ECE40
		protected override void vmethod_10()
		{
			float num = (float)(this.int_7 - this.int_3) / (float)(this.int_2 - this.int_3);
			float num2 = this.movieClip_1.y - (float)this.int_0;
			float num3 = num * (float)this.Int32_2 + num2;
			this.gclass25_0.DisplayObjectContainer_0.y = Mathf.Max(num2, Mathf.Min(this.movieClip_1.y + this.movieClip_1.height - this.gclass25_0.DisplayObjectContainer_0.height + (float)this.int_1, num3));
			bool flag = this.gclass25_0.Boolean_1 && this.Boolean_6;
			if (this.gclass25_1 != null)
			{
				this.gclass25_1.Boolean_6 = flag && this.int_7 > this.int_3;
				this.gclass25_1.vmethod_2();
			}
			if (this.gclass25_2 != null)
			{
				this.gclass25_2.Boolean_6 = flag && this.int_7 < this.int_2;
				this.gclass25_2.vmethod_2();
			}
		}

		// Token: 0x06003418 RID: 13336 RVA: 0x00022118 File Offset: 0x00020318
		protected void method_15(CEvent cevent_0)
		{
			this.method_13();
		}

		// Token: 0x06003419 RID: 13337 RVA: 0x00022118 File Offset: 0x00020318
		protected void method_16(CEvent cevent_0)
		{
			this.method_13();
		}

		// Token: 0x0600341A RID: 13338 RVA: 0x00022120 File Offset: 0x00020320
		protected void method_17(CEvent cevent_0)
		{
			this.method_14();
		}

		// Token: 0x0600341B RID: 13339 RVA: 0x00022120 File Offset: 0x00020320
		protected void method_18(CEvent cevent_0)
		{
			this.method_14();
		}

		// Token: 0x0600341C RID: 13340 RVA: 0x000EED54 File Offset: 0x000ECF54
		protected void method_19(CEvent cevent_0)
		{
			if (this.bool_4)
			{
				return;
			}
			this.bool_4 = true;
			this.movieClip_0.stage.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_20), false);
			this.movieClip_0.stage.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_21), false);
			this.vector2_0 = new Vector2(0f, this.movieClip_0.mouseY - this.gclass25_0.DisplayObjectContainer_0.y);
		}

		// Token: 0x0600341D RID: 13341 RVA: 0x000EEDE4 File Offset: 0x000ECFE4
		protected void method_20(CEvent cevent_0)
		{
			float num = (this.movieClip_0.mouseY - this.vector2_0.y - this.movieClip_1.y) / (float)this.Int32_2;
			this.Int32_1 = this.int_3 + Mathf.RoundToInt(num * (float)(this.int_2 - this.int_3));
		}

		// Token: 0x0600341E RID: 13342 RVA: 0x000EEE40 File Offset: 0x000ED040
		protected void method_21(CEvent cevent_0)
		{
			this.movieClip_0.stage.removeEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_20));
			this.movieClip_0.stage.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_21));
			this.bool_4 = false;
		}

		// Token: 0x0600341F RID: 13343 RVA: 0x000EEE98 File Offset: 0x000ED098
		protected void method_22(CEvent cevent_0)
		{
			if (this.String_0 == ScrollType.string_1)
			{
				float num = (this.movieClip_0.mouseY - this.gclass25_0.DisplayObjectContainer_0.height / 2f - this.movieClip_1.y) / (float)this.Int32_2;
				this.Int32_1 = Mathf.RoundToInt(num * (float)(this.int_2 - this.int_3) + (float)this.int_3);
				this.gclass25_0.dispatchEvent(new MouseEvent(MouseEvent.MOUSE_MOVE));
				this.gclass25_0.dispatchEvent(new MouseEvent(MouseEvent.MOUSE_DOWN));
				this.method_19(cevent_0);
				this.vector2_0 = new Vector2(0f, this.gclass25_0.DisplayObjectContainer_0.height / 2f);
			}
			if (!this.bool_4)
			{
				if (this.Int32_1 != this.int_9)
				{
					if (this.movieClip_0.mouseY > this.gclass25_0.DisplayObjectContainer_0.y && this.movieClip_0.mouseY < this.gclass25_0.DisplayObjectContainer_0.y + this.gclass25_0.DisplayObjectContainer_0.height)
					{
						return;
					}
					this.Int32_1 += ((this.gclass25_0.DisplayObjectContainer_0.y >= this.movieClip_0.mouseY) ? (-this.int_8) : this.int_8);
					return;
				}
			}
		}

		// Token: 0x06003420 RID: 13344 RVA: 0x000EF014 File Offset: 0x000ED214
		protected void method_23(CEvent cevent_0)
		{
			if (!this.bool_4)
			{
				if (this.Int32_1 != this.int_9)
				{
					if (this.movieClip_0.mouseY > this.gclass25_0.DisplayObjectContainer_0.y && this.movieClip_0.mouseY < this.gclass25_0.DisplayObjectContainer_0.y + this.gclass25_0.DisplayObjectContainer_0.height)
					{
						return;
					}
					this.Int32_1 += ((this.gclass25_0.DisplayObjectContainer_0.y >= this.movieClip_0.mouseY) ? (-this.int_8) : this.int_8);
					return;
				}
			}
		}

		// Token: 0x06003421 RID: 13345 RVA: 0x00022128 File Offset: 0x00020328
		protected void method_24()
		{
			if (this.object_0 != null && this.Boolean_6)
			{
				return;
			}
		}

		// Token: 0x06003422 RID: 13346 RVA: 0x000EF0C8 File Offset: 0x000ED2C8
		protected void method_25(CEvent cevent_0)
		{
			GClass56 gclass = cevent_0 as GClass56;
			this.Int32_1 -= ((gclass.float_0 <= 0f) ? (-1) : 1) * this.int_5;
		}

		// Token: 0x04002424 RID: 9252
		public int int_8 = 1;

		// Token: 0x04002425 RID: 9253
		protected Vector2 vector2_0;

		// Token: 0x04002426 RID: 9254
		protected string string_1 = ScrollType.string_0;

		// Token: 0x04002427 RID: 9255
		protected int int_9 = -1;

		// Token: 0x04002428 RID: 9256
		protected int int_10 = -1;

		// Token: 0x04002429 RID: 9257
		public GClass25 gclass25_1;

		// Token: 0x0400242A RID: 9258
		public GClass25 gclass25_2;
	}
}
