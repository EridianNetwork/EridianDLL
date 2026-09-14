using System;
using System.Collections.Generic;
using Core;
using pumpkin.events;

namespace ns0
{
	// Token: 0x0200078F RID: 1935
	public class GClass42 : GClass24
	{
		// Token: 0x06003359 RID: 13145 RVA: 0x00021785 File Offset: 0x0001F985
		public GClass42()
		{
			this.bool_3 = false;
			this.gdelegate0_0 = new GClass42.GDelegate0(this.method_11);
			this.gdelegate1_0 = new GClass42.GDelegate1(this.method_12);
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x000217B8 File Offset: 0x0001F9B8
		private void method_10()
		{
			DragManagerLayer.Instance.removeEventListener("dragBegin", new EventDispatcher.EventCallback(this.method_14));
			DragManagerLayer.Instance.removeEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_15));
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600335B RID: 13147 RVA: 0x000217F2 File Offset: 0x0001F9F2
		// (set) Token: 0x0600335C RID: 13148 RVA: 0x000217FF File Offset: 0x0001F9FF
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

		// Token: 0x0600335D RID: 13149 RVA: 0x00021810 File Offset: 0x0001FA10
		public bool method_11(object object_0)
		{
			return object_0 == null || this.list_0 == null || this.list_0.Contains(string.Empty);
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x00021721 File Offset: 0x0001F921
		public void method_12(object object_0)
		{
			base.dispatchEvent(new GClass55("drop", object_0, true, false));
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x00021830 File Offset: 0x0001FA30
		public void method_13(string string_0)
		{
			if (this.movieClip_0 != null)
			{
				this.movieClip_0.gotoAndStop(string_0);
			}
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x000EB7E0 File Offset: 0x000E99E0
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this.movieClip_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			this.movieClip_0.mouseChildrenEnabled = false;
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_17), false);
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_18), false);
			DragManagerLayer.Instance.addEventListener("dragBegin", new EventDispatcher.EventCallback(this.method_14));
			DragManagerLayer.Instance.addEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_15));
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x000EB888 File Offset: 0x000E9A88
		private void method_14(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (!this.gdelegate0_0(gclass.object_0))
			{
				return;
			}
			this.Boolean_1 = true;
			this.movieClip_0.gotoAndStop("up");
			this.movieClip_0.gotoAndStop("dragUp");
		}

		// Token: 0x06003362 RID: 13154 RVA: 0x000EB8D8 File Offset: 0x000E9AD8
		private void method_15(CEvent cevent_0)
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
					this.gdelegate1_0(gstruct.object_0);
				}
			}
		}

		// Token: 0x06003363 RID: 13155 RVA: 0x00021846 File Offset: 0x0001FA46
		private void method_16()
		{
			DragManagerLayer.Instance.object_0 = null;
			DragManagerLayer.Instance.method_10();
		}

		// Token: 0x06003364 RID: 13156 RVA: 0x0002185D File Offset: 0x0001FA5D
		private void method_17(CEvent cevent_0)
		{
			this.movieClip_0.gotoAndPlay("over");
			DragManagerLayer.Instance.object_0 = this;
			DragManagerLayer.Instance.method_10();
		}

		// Token: 0x06003365 RID: 13157 RVA: 0x000EB790 File Offset: 0x000E9990
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

		// Token: 0x06003366 RID: 13158 RVA: 0x00021771 File Offset: 0x0001F971
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.visible = false;
		}

		// Token: 0x04002392 RID: 9106
		private List<string> list_0;

		// Token: 0x04002393 RID: 9107
		public GClass42.GDelegate0 gdelegate0_0;

		// Token: 0x04002394 RID: 9108
		public GClass42.GDelegate1 gdelegate1_0;

		// Token: 0x02000790 RID: 1936
		// (Invoke) Token: 0x06003368 RID: 13160
		public delegate bool GDelegate0(object data);

		// Token: 0x02000791 RID: 1937
		// (Invoke) Token: 0x0600336C RID: 13164
		public delegate void GDelegate1(object data);
	}
}
