using System;
using System.Collections.Generic;
using Core;
using pumpkin.events;

namespace ns0
{
	// Token: 0x0200078E RID: 1934
	public class GClass41 : GClass24
	{
		// Token: 0x0600334A RID: 13130 RVA: 0x000216CD File Offset: 0x0001F8CD
		public GClass41()
		{
			this.bool_3 = false;
		}

		// Token: 0x0600334B RID: 13131 RVA: 0x000EB52C File Offset: 0x000E972C
		~GClass41()
		{
			DragManagerLayer.Instance.removeEventListener("dragBegin", new EventDispatcher.EventCallback(this.method_12));
			DragManagerLayer.Instance.removeEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_13));
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x0600334C RID: 13132 RVA: 0x000216E3 File Offset: 0x0001F8E3
		// (set) Token: 0x0600334D RID: 13133 RVA: 0x000216F0 File Offset: 0x0001F8F0
		public string[] String_0
		{
			get
			{
				return this.list_0.ToArray();
			}
			set
			{
				if (value != null)
				{
					this.list_0 = new List<string>(value);
				}
			}
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x00021701 File Offset: 0x0001F901
		public bool method_10(object object_0)
		{
			return object_0 == null || this.list_0 == null || this.list_0.Contains(string.Empty);
		}

		// Token: 0x0600334F RID: 13135 RVA: 0x00021721 File Offset: 0x0001F921
		public void method_11(object object_0)
		{
			base.dispatchEvent(new GClass55("drop", object_0, true, false));
		}

		// Token: 0x06003350 RID: 13136 RVA: 0x000EB58C File Offset: 0x000E978C
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this.movieClip_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_17), false);
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_18), false);
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_14), false);
			DragManagerLayer.Instance.addEventListener("dragBegin", new EventDispatcher.EventCallback(this.method_12));
			DragManagerLayer.Instance.addEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_13));
		}

		// Token: 0x06003351 RID: 13137 RVA: 0x000EB644 File Offset: 0x000E9844
		private void method_12(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (!this.method_10(gclass))
			{
				return;
			}
			this.Boolean_1 = true;
		}

		// Token: 0x06003352 RID: 13138 RVA: 0x000EB66C File Offset: 0x000E986C
		private void method_13(CEvent cevent_0)
		{
			this.Boolean_1 = false;
			this.movieClip_0.gotoAndStop("dragUp");
			this.movieClip_0.gotoAndStop("up");
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass != null)
			{
				GStruct0 gstruct = (GStruct0)gclass.object_0;
				if (gstruct.object_2 == this && !gstruct.bool_0)
				{
					this.method_11(gstruct.object_0);
				}
			}
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x000EB6D8 File Offset: 0x000E98D8
		private void method_14(CEvent cevent_0)
		{
			DragManagerLayer.Instance.object_0 = this;
			DragManagerLayer.Instance.method_10();
			this.float_0 = this.movieClip_0.mouseX;
			this.float_1 = this.movieClip_0.mouseY;
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_15), false);
		}

		// Token: 0x06003354 RID: 13140 RVA: 0x000EB73C File Offset: 0x000E993C
		private void method_15(CEvent cevent_0)
		{
			if (Math.Abs(this.movieClip_0.mouseX - this.float_0) > (float)this.int_0 || Math.Abs(this.movieClip_0.mouseY - this.float_1) > (float)this.int_0)
			{
				this.method_16();
			}
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x00021737 File Offset: 0x0001F937
		private void method_16()
		{
			DragManagerLayer.Instance.object_0 = null;
			DragManagerLayer.Instance.method_10();
			this.movieClip_0.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x0002175F File Offset: 0x0001F95F
		private void method_17(CEvent cevent_0)
		{
			this.movieClip_0.gotoAndPlay("over");
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x000EB790 File Offset: 0x000E9990
		private void method_18(CEvent cevent_0)
		{
			if (!(cevent_0 is MouseEvent))
			{
				return;
			}
			this.movieClip_0.gotoAndPlay("up");
			this.movieClip_0.gotoAndPlay("out");
			DragManagerLayer.Instance.object_0 = null;
			DragManagerLayer.Instance.method_10();
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x00021771 File Offset: 0x0001F971
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.visible = false;
		}

		// Token: 0x0400238E RID: 9102
		private List<string> list_0;

		// Token: 0x0400238F RID: 9103
		private float float_0;

		// Token: 0x04002390 RID: 9104
		private float float_1;

		// Token: 0x04002391 RID: 9105
		private int int_0 = 2;
	}
}
