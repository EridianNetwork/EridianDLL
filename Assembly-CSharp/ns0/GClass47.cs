using System;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007A8 RID: 1960
	public class GClass47 : GClass24
	{
		// Token: 0x06003439 RID: 13369 RVA: 0x00022260 File Offset: 0x00020460
		public GClass47(Rect rect_2)
		{
			this.rect_0 = rect_2;
		}

		// Token: 0x0600343A RID: 13370 RVA: 0x0002228C File Offset: 0x0002048C
		public GClass47()
		{
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x0600343B RID: 13371 RVA: 0x000222B1 File Offset: 0x000204B1
		// (set) Token: 0x0600343C RID: 13372 RVA: 0x000222B9 File Offset: 0x000204B9
		public Rect Rect_0
		{
			get
			{
				return this.rect_0;
			}
			set
			{
				this.rect_0 = value;
				this.method_12();
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x0600343D RID: 13373 RVA: 0x000222C8 File Offset: 0x000204C8
		// (set) Token: 0x0600343E RID: 13374 RVA: 0x000222D0 File Offset: 0x000204D0
		public Rect Rect_1
		{
			get
			{
				return this.rect_1;
			}
			set
			{
				this.rect_1 = value;
				this.method_12();
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x0600343F RID: 13375 RVA: 0x000222DF File Offset: 0x000204DF
		// (set) Token: 0x06003440 RID: 13376 RVA: 0x000222E7 File Offset: 0x000204E7
		public float Single_0
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
				this.float_7 = this.float_0;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06003441 RID: 13377 RVA: 0x000222FC File Offset: 0x000204FC
		// (set) Token: 0x06003442 RID: 13378 RVA: 0x00022304 File Offset: 0x00020504
		public float Single_1
		{
			get
			{
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
				this.float_8 = this.float_1;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06003443 RID: 13379 RVA: 0x00022319 File Offset: 0x00020519
		// (set) Token: 0x06003444 RID: 13380 RVA: 0x00022321 File Offset: 0x00020521
		public float Single_2
		{
			get
			{
				return this.float_2;
			}
			set
			{
				if (value > 0f)
				{
					this.float_2 = value;
				}
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06003445 RID: 13381 RVA: 0x00022332 File Offset: 0x00020532
		// (set) Token: 0x06003446 RID: 13382 RVA: 0x0002233A File Offset: 0x0002053A
		public virtual int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value > 0)
				{
					this.int_0 = value;
				}
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06003447 RID: 13383 RVA: 0x00022347 File Offset: 0x00020547
		// (set) Token: 0x06003448 RID: 13384 RVA: 0x0002234F File Offset: 0x0002054F
		public GClass46 GClass46_0
		{
			get
			{
				return this.gclass46_0;
			}
			set
			{
				this.gclass46_0 = value;
				this.method_10();
			}
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x000EF428 File Offset: 0x000ED628
		protected override void vmethod_0()
		{
			base.vmethod_0();
			if (this.movieClip_0 != null)
			{
				Rect rect = new Rect(0f, 0f, this.movieClip_0.width, this.movieClip_0.height);
				if (this.displayObject_0 != null)
				{
					Vector2 vector = GClass20.GClass20_0.method_2(this.movieClip_0, Vector2.zero);
					vector = GClass20.GClass20_0.method_2(this.displayObject_0.parent, vector);
					rect.x = vector.x;
					rect.y = vector.y;
				}
				this.Rect_0 = rect;
			}
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x000EF4C4 File Offset: 0x000ED6C4
		public virtual void vmethod_8(DisplayObject displayObject_1)
		{
			if (this.displayObject_0 != null)
			{
				this.displayObject_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_17));
				this.displayObject_0.removeEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.vmethod_9), false);
			}
			this.displayObject_0 = displayObject_1;
			if (this.displayObject_0 != null)
			{
				this.displayObject_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_17));
				this.displayObject_0.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.vmethod_9), false);
				this.float_7 = this.displayObject_0.x;
				this.float_8 = this.displayObject_0.y;
				this.method_15();
			}
		}

		// Token: 0x0600344B RID: 13387 RVA: 0x0002235E File Offset: 0x0002055E
		protected void method_10()
		{
			this.gclass46_0.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.vmethod_10));
		}

		// Token: 0x0600344C RID: 13388 RVA: 0x000EF588 File Offset: 0x000ED788
		protected virtual void vmethod_9(CEvent cevent_0)
		{
			GClass56 gclass = cevent_0 as GClass56;
			this.vmethod_13((float)((gclass.float_0 <= 0f) ? (-1) : 1) * this.Single_2);
		}

		// Token: 0x0600344D RID: 13389 RVA: 0x0002237E File Offset: 0x0002057E
		protected virtual void vmethod_10(CEvent cevent_0)
		{
			this.vmethod_14((float)(-(float)this.gclass46_0.Int32_1));
		}

		// Token: 0x0600344E RID: 13390 RVA: 0x00022393 File Offset: 0x00020593
		public virtual void vmethod_11()
		{
			this.method_11(0f, 0f);
		}

		// Token: 0x0600344F RID: 13391 RVA: 0x000223A5 File Offset: 0x000205A5
		public virtual void vmethod_12()
		{
			this.method_11(-this.float_5, -this.float_6);
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x000223BB File Offset: 0x000205BB
		public virtual void vmethod_13(float float_9)
		{
			if (this.string_0 == GClass18.string_1)
			{
				this.vmethod_15(0f, float_9);
			}
			else if (this.string_0 == GClass18.string_0)
			{
				this.vmethod_15(float_9, 0f);
			}
		}

		// Token: 0x06003451 RID: 13393 RVA: 0x000223FB File Offset: 0x000205FB
		public virtual void vmethod_14(float float_9)
		{
			if (this.string_0 == GClass18.string_1)
			{
				this.method_11(0f, float_9);
			}
			else if (this.string_0 == GClass18.string_0)
			{
				this.method_11(float_9, 0f);
			}
		}

		// Token: 0x06003452 RID: 13394 RVA: 0x0002243B File Offset: 0x0002063B
		public virtual void vmethod_15(float float_9, float float_10)
		{
			this.method_11(this.float_3 + float_9, this.float_4 + float_10);
		}

		// Token: 0x06003453 RID: 13395 RVA: 0x000EF5BC File Offset: 0x000ED7BC
		protected void method_11(float float_9, float float_10)
		{
			if (this.float_5 < 0f)
			{
				this.float_3 = Mathf.Min(Mathf.Max(this.float_5, float_9), 0f);
			}
			else
			{
				this.float_3 = Mathf.Max(Mathf.Min(this.float_5, float_9), 0f);
			}
			if (this.float_6 < 0f)
			{
				this.float_4 = Mathf.Min(Mathf.Max(this.float_6, float_10), 0f);
			}
			else
			{
				this.float_4 = Mathf.Max(Mathf.Min(this.float_6, float_10), 0f);
			}
			if (this.gclass46_0 != null)
			{
				if (this.string_0 == GClass18.string_1)
				{
					this.gclass46_0.Int32_1 = Mathf.Abs((int)this.float_4);
				}
				else if (this.string_0 == GClass18.string_0)
				{
					this.gclass46_0.Int32_1 = Mathf.Abs((int)this.float_3);
				}
			}
		}

		// Token: 0x06003454 RID: 13396 RVA: 0x000EF6B4 File Offset: 0x000ED8B4
		protected void method_12()
		{
			this.float_5 = this.Rect_0.width - this.Rect_1.width;
			this.float_6 = this.Rect_0.height - this.Rect_1.height;
			if (this.gclass46_0 != null)
			{
				this.gclass46_0.method_10(1, 0, Math.Abs((int)this.float_6), this.Int32_0);
			}
			this.method_13();
			this.method_11(0f, 0f);
		}

		// Token: 0x06003455 RID: 13397 RVA: 0x000EF744 File Offset: 0x000ED944
		protected void method_13()
		{
			if (this.gclass46_0 != null)
			{
				if (this.displayObject_0 != null && this.displayObject_0.visible)
				{
					this.gclass46_0.Boolean_1 = ((!(this.string_0 == GClass18.string_0)) ? (this.rect_1.y + this.rect_1.height > this.Rect_0.height) : (this.rect_1.x + this.rect_1.width > this.Rect_0.width));
				}
				else
				{
					this.gclass46_0.Boolean_1 = false;
				}
			}
		}

		// Token: 0x06003456 RID: 13398 RVA: 0x000EF7EC File Offset: 0x000ED9EC
		private void method_14()
		{
			DisplayObjectContainer displayObjectContainer = this.displayObject_0 as DisplayObjectContainer;
			if (displayObjectContainer != null)
			{
				float num = 0f;
				for (int i = 0; i < displayObjectContainer.numChildren; i++)
				{
					DisplayObject childAt = displayObjectContainer.getChildAt(i);
					if (childAt.visible)
					{
						num = Mathf.Max(num, childAt.y + childAt.height);
					}
				}
				this.method_16(new Rect(0f, 0f, this.Rect_1.width, num));
			}
		}

		// Token: 0x06003457 RID: 13399 RVA: 0x00022453 File Offset: 0x00020653
		public void method_15()
		{
			this.method_14();
		}

		// Token: 0x06003458 RID: 13400 RVA: 0x0002245B File Offset: 0x0002065B
		public void method_16(Rect rect_2)
		{
			this.Rect_1 = rect_2;
		}

		// Token: 0x06003459 RID: 13401 RVA: 0x000EF868 File Offset: 0x000EDA68
		protected void method_17(CEvent cevent_0)
		{
			this.displayObject_0.x = (float)((int)this.float_7 + (int)this.float_3);
			this.displayObject_0.y = (float)((int)this.float_8 + (int)this.float_4);
			if (this.float_5 >= 0f && this.float_6 >= 0f)
			{
				this.displayObject_0.hasClipRect = false;
			}
			else
			{
				this.displayObject_0.hasClipRect = true;
				this.displayObject_0.clipRect = new Rect((float)Math.Abs((int)this.float_3), (float)Math.Abs((int)this.float_4), this.Rect_0.width, this.Rect_0.height);
			}
		}

		// Token: 0x0400243C RID: 9276
		private Rect rect_0;

		// Token: 0x0400243D RID: 9277
		private Rect rect_1;

		// Token: 0x0400243E RID: 9278
		private float float_0;

		// Token: 0x0400243F RID: 9279
		private float float_1;

		// Token: 0x04002440 RID: 9280
		private float float_2 = 10f;

		// Token: 0x04002441 RID: 9281
		protected int int_0 = 8;

		// Token: 0x04002442 RID: 9282
		public string string_0 = GClass18.string_1;

		// Token: 0x04002443 RID: 9283
		private float float_3;

		// Token: 0x04002444 RID: 9284
		private float float_4;

		// Token: 0x04002445 RID: 9285
		public float float_5;

		// Token: 0x04002446 RID: 9286
		public float float_6;

		// Token: 0x04002447 RID: 9287
		private float float_7;

		// Token: 0x04002448 RID: 9288
		private float float_8;

		// Token: 0x04002449 RID: 9289
		protected GClass46 gclass46_0;

		// Token: 0x0400244A RID: 9290
		protected DisplayObject displayObject_0;
	}
}
