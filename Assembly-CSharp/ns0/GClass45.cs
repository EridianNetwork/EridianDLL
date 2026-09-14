using System;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007A7 RID: 1959
	public class GClass45 : GClass24
	{
		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06003428 RID: 13352 RVA: 0x00021CCD File Offset: 0x0001FECD
		// (set) Token: 0x06003429 RID: 13353 RVA: 0x00022198 File Offset: 0x00020398
		public override bool Boolean_6
		{
			get
			{
				return base.Boolean_6;
			}
			set
			{
				if (value == base.Boolean_6)
				{
					return;
				}
				base.Boolean_6 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.gotoAndPlay((!this.Boolean_6) ? "disabled" : "default");
				}
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x0600342A RID: 13354 RVA: 0x000221D2 File Offset: 0x000203D2
		// (set) Token: 0x0600342B RID: 13355 RVA: 0x000EF104 File Offset: 0x000ED304
		public virtual int Int32_1
		{
			get
			{
				return this.int_7;
			}
			set
			{
				value = Math.Max(this.int_3, Math.Min(this.int_2, value));
				if (value == this.int_7)
				{
					return;
				}
				this.int_7 = value;
				base.dispatchEvent(new CEvent("Scrolling"));
				base.method_5();
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600342C RID: 13356 RVA: 0x000221DA File Offset: 0x000203DA
		// (set) Token: 0x0600342D RID: 13357 RVA: 0x000221E2 File Offset: 0x000203E2
		public int Int32_0
		{
			get
			{
				return this.int_4;
			}
			set
			{
				value = Math.Max(1, value);
				this.int_4 = value;
				base.method_4();
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600342E RID: 13358 RVA: 0x000221FC File Offset: 0x000203FC
		public bool Boolean_0
		{
			get
			{
				return this.string_0 == GClass18.string_0;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x0600342F RID: 13359 RVA: 0x0002220E File Offset: 0x0002040E
		// (set) Token: 0x06003430 RID: 13360 RVA: 0x00022216 File Offset: 0x00020416
		public object Object_0
		{
			get
			{
				return this.object_0;
			}
			set
			{
				this.object_0 = value;
				if (this.object_0 == null)
				{
					return;
				}
				this.method_11(null);
				base.method_3(null);
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06003431 RID: 13361 RVA: 0x000EF154 File Offset: 0x000ED354
		public virtual int Int32_2
		{
			get
			{
				int num = ((this.gclass25_0.DisplayObjectContainer_0.height >= 0f) ? Mathf.RoundToInt(this.gclass25_0.DisplayObjectContainer_0.height) : 0);
				return Mathf.RoundToInt((!this.Boolean_0) ? this.movieClip_0.height : this.movieClip_0.width) - num + this.int_1 + this.int_0;
			}
		}

		// Token: 0x06003432 RID: 13362 RVA: 0x00022236 File Offset: 0x00020436
		public void method_10(int int_8, int int_9, int int_10, int int_11 = -1)
		{
			this.int_6 = int_8;
			if (int_11 >= 0)
			{
				this.int_5 = int_11;
			}
			this.int_3 = int_9;
			this.int_2 = int_10;
			base.method_4();
		}

		// Token: 0x06003433 RID: 13363 RVA: 0x000EF1C8 File Offset: 0x000ED3C8
		protected override void vmethod_4()
		{
			base.vmethod_4();
			MovieClip childByName = this.movieClip_0.getChildByName<MovieClip>("thumb");
			if (childByName != null)
			{
				this.gclass25_0 = new GClass25();
				this.gclass25_0.method_0(childByName);
			}
			this.movieClip_1 = this.movieClip_0.getChildByName<MovieClip>("track");
			pumpkin.display.Sprite movieClip_ = this.movieClip_0;
			this.movieClip_0.mouseEnabled = true;
			movieClip_.mouseChildrenEnabled = true;
			if (this.movieClip_1 == null)
			{
				this.movieClip_1 = new MovieClip();
			}
			this.string_0 = ((this.movieClip_0.rotation == 0f || this.movieClip_0.rotation == 180f) ? GClass18.string_1 : GClass18.string_0);
		}

		// Token: 0x06003434 RID: 13364 RVA: 0x000EF280 File Offset: 0x000ED480
		protected override void vmethod_5()
		{
			if (this.vmethod_3(new string[] { GClass22.string_1 }))
			{
				this.vmethod_8();
				this.vmethod_9();
			}
			else if (this.vmethod_3(new string[] { GClass22.string_3 }))
			{
				this.vmethod_10();
			}
		}

		// Token: 0x06003435 RID: 13365 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_8()
		{
		}

		// Token: 0x06003436 RID: 13366 RVA: 0x000EF2D0 File Offset: 0x000ED4D0
		protected virtual void vmethod_9()
		{
			float num = (float)Math.Max(1, this.int_2 - this.int_3);
			float num2 = ((!this.Boolean_0) ? this.movieClip_0.height : this.movieClip_0.width) + (float)this.int_0 + (float)this.int_1;
			this.gclass25_0.DisplayObjectContainer_0.height = Mathf.Max((float)this.int_4, Mathf.Min(this.movieClip_0.height, (float)this.int_6 / num * num2));
			if (this.gclass25_0 is GClass24)
			{
				this.gclass25_0.vmethod_2();
			}
			this.vmethod_10();
		}

		// Token: 0x06003437 RID: 13367 RVA: 0x000EF378 File Offset: 0x000ED578
		protected virtual void vmethod_10()
		{
			float num;
			if (this.int_2 == this.int_3)
			{
				num = 0f;
			}
			else
			{
				num = (float)((this.int_7 - this.int_3) / (this.int_2 - this.int_3));
			}
			int num2 = Mathf.RoundToInt(num * (float)this.Int32_2);
			this.gclass25_0.DisplayObjectContainer_0.y = (float)Math.Max(-this.int_0, Math.Min(this.Int32_2 - this.int_0, num2));
			this.gclass25_0.Boolean_1 = this.int_2 != this.int_3 && this.int_6 >= 0 && this.int_2 != 0;
		}

		// Token: 0x06003438 RID: 13368 RVA: 0x0000311B File Offset: 0x0000131B
		protected void method_11(CEvent cevent_0)
		{
		}

		// Token: 0x0400242F RID: 9263
		public string string_0 = GClass18.string_1;

		// Token: 0x04002430 RID: 9264
		public int int_0;

		// Token: 0x04002431 RID: 9265
		public int int_1;

		// Token: 0x04002432 RID: 9266
		protected bool bool_4;

		// Token: 0x04002433 RID: 9267
		protected int int_2 = 10;

		// Token: 0x04002434 RID: 9268
		protected int int_3;

		// Token: 0x04002435 RID: 9269
		protected int int_4 = 10;

		// Token: 0x04002436 RID: 9270
		protected int int_5 = 1;

		// Token: 0x04002437 RID: 9271
		protected int int_6;

		// Token: 0x04002438 RID: 9272
		protected int int_7 = 5;

		// Token: 0x04002439 RID: 9273
		protected object object_0;

		// Token: 0x0400243A RID: 9274
		public GClass25 gclass25_0;

		// Token: 0x0400243B RID: 9275
		public MovieClip movieClip_1;
	}
}
