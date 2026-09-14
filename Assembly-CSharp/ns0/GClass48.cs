using System;
using Core;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007A9 RID: 1961
	public class GClass48 : GClass24
	{
		// Token: 0x0600345B RID: 13403 RVA: 0x00022494 File Offset: 0x00020694
		protected override void vmethod_0()
		{
			base.vmethod_0();
			base.method_7(CEvent.CHANGED, "UI_Generic_InGame_Movement");
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x0600345C RID: 13404 RVA: 0x00021CCD File Offset: 0x0001FECD
		// (set) Token: 0x0600345D RID: 13405 RVA: 0x000EF928 File Offset: 0x000EDB28
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
				this.movieClip_0.mouseEnabled = (this.movieClip_0.mouseChildrenEnabled = this.Boolean_6);
				if (this.gclass25_0 != null)
				{
					this.gclass25_0.Boolean_6 = value;
				}
				if (this.gclass25_1 != null)
				{
					this.gclass25_1.Boolean_6 = value;
				}
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x0600345E RID: 13406 RVA: 0x000224AC File Offset: 0x000206AC
		// (set) Token: 0x0600345F RID: 13407 RVA: 0x000224B4 File Offset: 0x000206B4
		public float Single_0
		{
			get
			{
				return this.float_4;
			}
			set
			{
				this.float_4 = this.method_16(value);
				base.dispatchEvent(new GClass55(CEvent.CHANGED, this.float_4, false, true));
				this.vmethod_5();
				this.method_11();
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06003460 RID: 13408 RVA: 0x000224ED File Offset: 0x000206ED
		// (set) Token: 0x06003461 RID: 13409 RVA: 0x000224F5 File Offset: 0x000206F5
		public float Single_1
		{
			get
			{
				return this.float_3;
			}
			set
			{
				this.float_3 = value;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06003462 RID: 13410 RVA: 0x000224FE File Offset: 0x000206FE
		// (set) Token: 0x06003463 RID: 13411 RVA: 0x00022506 File Offset: 0x00020706
		public float Single_2
		{
			get
			{
				return this.float_2;
			}
			set
			{
				this.float_2 = value;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06003464 RID: 13412 RVA: 0x000224AC File Offset: 0x000206AC
		// (set) Token: 0x06003465 RID: 13413 RVA: 0x0002250F File Offset: 0x0002070F
		public float Single_3
		{
			get
			{
				return this.float_4;
			}
			set
			{
				this.float_4 = value;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06003466 RID: 13414 RVA: 0x00022518 File Offset: 0x00020718
		// (set) Token: 0x06003467 RID: 13415 RVA: 0x00022520 File Offset: 0x00020720
		public bool Boolean_0
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				this.method_10();
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06003468 RID: 13416 RVA: 0x0002252F File Offset: 0x0002072F
		// (set) Token: 0x06003469 RID: 13417 RVA: 0x00022537 File Offset: 0x00020737
		public float Single_4
		{
			get
			{
				return this.float_5;
			}
			set
			{
				this.float_5 = value;
				this.method_10();
			}
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x00022546 File Offset: 0x00020746
		private void method_10()
		{
			base.method_3(new string[] { GClass22.string_4 });
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000EF990 File Offset: 0x000EDB90
		protected override void vmethod_4()
		{
			base.vmethod_4();
			this.gclass25_0 = new GClass25();
			this.gclass25_1 = new GClass25();
			if (this.movieClip_0.getChildByName<MovieClip>("thumb") != null)
			{
				this.gclass25_0.method_0(this.movieClip_0.getChildByName<MovieClip>("thumb"));
				this.gclass25_0.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_12), false);
			}
			else
			{
				this.gclass25_0 = null;
			}
			this.gclass25_1.method_0(this.movieClip_0.getChildByName<MovieClip>("track"));
			this.gclass25_1.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_15), false);
			this.movieClip_0.mouseEnabled = (this.movieClip_0.mouseChildrenEnabled = this.Boolean_6);
			if (this.gclass25_0 != null)
			{
				this.gclass25_0.Boolean_6 = this.Boolean_6;
				this.gclass25_0.bool_4 = true;
			}
			if (this.gclass25_1 != null)
			{
				this.gclass25_1.Boolean_6 = this.Boolean_6;
			}
			this.method_11();
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000EFAB8 File Offset: 0x000EDCB8
		protected void method_11()
		{
			if (!this.Boolean_6)
			{
				return;
			}
			if (this.gclass25_1 == null || this.gclass25_0 == null)
			{
				return;
			}
			float num = this.gclass25_1.DisplayObjectContainer_0.width - this.float_0 - this.float_1;
			if (this.gclass25_0.DisplayObjectContainer_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "!--GUIError: Slider Error!! Button didn't bind any movie clip:");
				return;
			}
			this.gclass25_0.DisplayObjectContainer_0.x = (this.float_4 - this.float_2) / (this.float_3 - this.float_2) * num - this.gclass25_0.DisplayObjectContainer_0.width / 2f + this.float_0;
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x000EFB68 File Offset: 0x000EDD68
		protected void method_12(CEvent cevent_0)
		{
			this.bool_7 = true;
			this.float_6 = GClass20.GClass20_0.method_2(base.DisplayObjectContainer_0, new Vector2(base.DisplayObjectContainer_0.stage.mouseX, base.DisplayObjectContainer_0.stage.mouseY)).x - this.gclass25_0.DisplayObjectContainer_0.x - this.gclass25_0.DisplayObjectContainer_0.width / 2f;
			base.DisplayObjectContainer_0.stage.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_13), false);
			base.DisplayObjectContainer_0.stage.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_14), false);
		}

		// Token: 0x0600346E RID: 13422 RVA: 0x000EFC30 File Offset: 0x000EDE30
		protected void method_13(CEvent cevent_0)
		{
			float num = GClass20.GClass20_0.method_2(base.DisplayObjectContainer_0, new Vector2(base.DisplayObjectContainer_0.stage.mouseX, base.DisplayObjectContainer_0.stage.mouseY)).x - this.float_6;
			float num2 = base.DisplayObjectContainer_0.width - this.float_0 - this.float_1;
			float num3 = this.method_16((num - this.float_0) / num2 * (this.float_3 - this.float_2) + this.float_2);
			if (this.Single_0 == num3)
			{
				return;
			}
			this.float_4 = num3;
			this.method_11();
			if (this.bool_4)
			{
				GClass55 gclass = new GClass55(CEvent.CHANGED, this.float_4, false, true);
				this.vmethod_7(gclass);
			}
		}

		// Token: 0x0600346F RID: 13423 RVA: 0x000EFD04 File Offset: 0x000EDF04
		protected void method_14(CEvent cevent_0)
		{
			base.DisplayObjectContainer_0.stage.removeEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_13), false);
			base.DisplayObjectContainer_0.stage.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_14), false);
			if (!this.bool_4)
			{
				GClass55 gclass = new GClass55(CEvent.CHANGED, this.float_4, false, true);
				base.dispatchEvent(gclass);
			}
			this.float_7 = -1f;
			this.bool_7 = false;
			this.bool_6 = false;
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x000EFD98 File Offset: 0x000EDF98
		protected void method_15(CEvent cevent_0)
		{
			this.bool_6 = true;
			Vector2 vector = GClass20.GClass20_0.method_2(base.DisplayObjectContainer_0, new Vector2(base.DisplayObjectContainer_0.stage.mouseX, base.DisplayObjectContainer_0.stage.mouseY));
			float num = this.gclass25_1.DisplayObjectContainer_0.width - this.float_0 - this.float_1;
			float num2 = this.method_16((vector.x - this.float_0) / num * (this.float_3 - this.float_2) + this.float_2);
			if (this.Single_0 == num2)
			{
				return;
			}
			this.Single_0 = num2;
			if (!this.bool_4)
			{
				GClass55 gclass = new GClass55(CEvent.CHANGED, this.float_4, false, true);
				base.dispatchEvent(gclass);
			}
			this.float_6 = 0f;
			this.method_11();
			base.DisplayObjectContainer_0.stage.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_13), false);
			base.DisplayObjectContainer_0.stage.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_14), false);
		}

		// Token: 0x06003471 RID: 13425 RVA: 0x000EFEC0 File Offset: 0x000EE0C0
		private float method_16(float float_8)
		{
			float_8 = Mathf.Max(Mathf.Min(this.float_3, float_8), this.float_2);
			if (!this.Boolean_0)
			{
				return float_8;
			}
			return Mathf.Round(float_8 / this.Single_4) * this.Single_4;
		}

		// Token: 0x0400244B RID: 9291
		public bool bool_4 = true;

		// Token: 0x0400244C RID: 9292
		public string string_0 = "default";

		// Token: 0x0400244D RID: 9293
		public float float_0;

		// Token: 0x0400244E RID: 9294
		public float float_1;

		// Token: 0x0400244F RID: 9295
		protected float float_2;

		// Token: 0x04002450 RID: 9296
		protected float float_3 = 10f;

		// Token: 0x04002451 RID: 9297
		protected float float_4;

		// Token: 0x04002452 RID: 9298
		protected float float_5 = 1f;

		// Token: 0x04002453 RID: 9299
		protected bool bool_5;

		// Token: 0x04002454 RID: 9300
		protected float float_6;

		// Token: 0x04002455 RID: 9301
		protected float float_7;

		// Token: 0x04002456 RID: 9302
		protected bool bool_6;

		// Token: 0x04002457 RID: 9303
		protected bool bool_7;

		// Token: 0x04002458 RID: 9304
		public GClass25 gclass25_0;

		// Token: 0x04002459 RID: 9305
		public GClass25 gclass25_1;
	}
}
