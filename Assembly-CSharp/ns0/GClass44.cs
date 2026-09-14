using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x0200079C RID: 1948
	public class GClass44 : GClass24
	{
		// Token: 0x060033B2 RID: 13234 RVA: 0x00021B6C File Offset: 0x0001FD6C
		public GClass44()
		{
			GClass44.int_0++;
		}

		// Token: 0x1700028B RID: 651
		// (set) Token: 0x060033B4 RID: 13236 RVA: 0x00021BAD File Offset: 0x0001FDAD
		public Color Color_0
		{
			set
			{
				this.color_0 = value;
				if (this.movieClip_7 != null)
				{
					this.movieClip_7.colorTransform = this.color_0;
				}
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060033B5 RID: 13237 RVA: 0x00021BCF File Offset: 0x0001FDCF
		// (set) Token: 0x060033B6 RID: 13238 RVA: 0x00021BD7 File Offset: 0x0001FDD7
		public bool Boolean_0
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
				if (this.movieClip_3 != null)
				{
					this.movieClip_3.visible = this.bool_7;
				}
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060033B7 RID: 13239 RVA: 0x00021BF9 File Offset: 0x0001FDF9
		// (set) Token: 0x060033B8 RID: 13240 RVA: 0x00021C01 File Offset: 0x0001FE01
		public new bool Boolean_1
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				if (value && this.gclass43_0 != null)
				{
					this.bool_8 = true;
				}
				else
				{
					this.bool_8 = false;
				}
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060033B9 RID: 13241 RVA: 0x00021C1E File Offset: 0x0001FE1E
		// (set) Token: 0x060033BA RID: 13242 RVA: 0x00021C26 File Offset: 0x0001FE26
		public object Object_0
		{
			get
			{
				return this.object_1;
			}
			set
			{
				this.object_1 = value;
				this.method_19();
				base.dispatchEvent(new GClass55("dataChanged", this.object_1, true, false));
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060033BB RID: 13243 RVA: 0x00021C4E File Offset: 0x0001FE4E
		// (set) Token: 0x060033BC RID: 13244 RVA: 0x000ED644 File Offset: 0x000EB844
		public int Int32_0
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				if (this.textField_0 != null)
				{
					this.textField_0.text = Utility.smethod_5("x", Utility.smethod_8(this.Int32_0));
					this.textField_0.visible = this.int_3 > 0;
				}
			}
		}

		// Token: 0x060033BD RID: 13245 RVA: 0x00021C56 File Offset: 0x0001FE56
		public bool method_10()
		{
			return this.bool_4;
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060033BE RID: 13246 RVA: 0x00021C5E File Offset: 0x0001FE5E
		// (set) Token: 0x060033BF RID: 13247 RVA: 0x00021C66 File Offset: 0x0001FE66
		public string[] String_0
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				if (this.bool_0)
				{
					this.gclass42_0.String_0 = value;
				}
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060033C0 RID: 13248 RVA: 0x00021C83 File Offset: 0x0001FE83
		// (set) Token: 0x060033C1 RID: 13249 RVA: 0x00021C8B File Offset: 0x0001FE8B
		public bool Boolean_2
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				if (this.bool_0)
				{
					this.gclass25_0.Boolean_2 = value;
				}
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060033C2 RID: 13250 RVA: 0x00021CA8 File Offset: 0x0001FEA8
		// (set) Token: 0x060033C3 RID: 13251 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		public bool Boolean_3
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				this.bool_6 = value;
				if (this.bool_0)
				{
					this.gclass25_0.Boolean_3 = value;
				}
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060033C4 RID: 13252 RVA: 0x00021CCD File Offset: 0x0001FECD
		// (set) Token: 0x060033C5 RID: 13253 RVA: 0x00021CD5 File Offset: 0x0001FED5
		public override bool Boolean_6
		{
			get
			{
				return base.Boolean_6;
			}
			set
			{
				base.Boolean_6 = value;
				if (this.bool_0)
				{
					this.gclass25_0.Boolean_6 = this.bool_2;
					this.gclass42_0.Boolean_6 = this.bool_2;
				}
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060033C6 RID: 13254 RVA: 0x00021D08 File Offset: 0x0001FF08
		// (set) Token: 0x060033C7 RID: 13255 RVA: 0x00021D10 File Offset: 0x0001FF10
		public bool Boolean_4
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				this.bool_10 = value;
				if (this.movieClip_8 != null)
				{
					this.movieClip_8.visible = this.bool_10;
				}
			}
		}

		// Token: 0x060033C8 RID: 13256 RVA: 0x00021D32 File Offset: 0x0001FF32
		public void method_11(GClass44.GDelegate2 gdelegate2_1)
		{
			this.gdelegate2_0 = (GClass44.GDelegate2)Delegate.Combine(this.gdelegate2_0, gdelegate2_1);
		}

		// Token: 0x060033C9 RID: 13257 RVA: 0x000ED694 File Offset: 0x000EB894
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "button":
				this.gclass25_0 = new GClass25();
				this.gclass25_0.method_0(movieClip);
				flag = true;
				break;
			case "dragTarget":
				this.gclass42_0 = new GClass42();
				this.gclass42_0.method_0(movieClip);
				flag = true;
				break;
			case "icons":
				if (widgetType == typeof(GClass43))
				{
					this.gclass43_0 = new GClass43();
					this.gclass43_0.method_0(movieClip);
				}
				this.movieClip_1 = movieClip;
				this.movieClip_1.visible = this.object_1 != null;
				this.movieClip_1.mouseEnabled = false;
				flag = true;
				break;
			case "mcLoading":
				this.movieClip_3 = movieClip;
				this.movieClip_3.mouseEnabled = false;
				this.movieClip_3.visible = false;
				flag = true;
				break;
			case "mcNewMark":
				this.movieClip_4 = movieClip;
				this.movieClip_4.mouseEnabled = false;
				this.movieClip_4.visible = false;
				flag = true;
				break;
			case "mcMeltEffect":
				this.movieClip_5 = movieClip;
				this.movieClip_5.mouseEnabled = false;
				this.movieClip_5.visible = false;
				flag = true;
				break;
			case "mcUnlock":
				this.movieClip_6 = movieClip;
				this.movieClip_6.stop();
				this.movieClip_6.mouseEnabled = false;
				this.movieClip_6.visible = false;
				flag = true;
				break;
			case "mcRarity":
				this.movieClip_7 = movieClip;
				this.movieClip_7.visible = false;
				this.movieClip_7.mouseEnabled = false;
				this.movieClip_7.colorTransform = this.color_0;
				flag = true;
				break;
			case "mcLock":
				this.movieClip_8 = movieClip;
				this.movieClip_8.mouseEnabled = false;
				this.movieClip_8.visible = this.bool_10;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x060033CA RID: 13258 RVA: 0x000ED90C File Offset: 0x000EBB0C
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this.gclass42_0 == null)
			{
				this.gclass42_0 = new GClass42();
			}
			this.textField_0 = this.movieClip_0.getChildByName<TextField>("textNumber");
			if (this.textField_0 != null)
			{
				this.textField_0.visible = false;
			}
			this.method_12();
			this.method_33();
		}

		// Token: 0x060033CB RID: 13259 RVA: 0x000ED968 File Offset: 0x000EBB68
		private void method_12()
		{
			DragManagerLayer.Instance.addEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_22));
			this.gclass25_0.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_23));
			this.gclass25_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_14));
			this.gclass25_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_14));
			this.gclass25_0.addEventListener(GClass53.string_1, new EventDispatcher.EventCallback(this.method_14));
			this.gclass25_0.addEventListener(GClass53.string_2, new EventDispatcher.EventCallback(this.method_14));
			this.gclass25_0.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_14));
			this.gclass25_0.addEventListener(GClass53.string_5, new EventDispatcher.EventCallback(this.method_14));
			this.gclass42_0.addEventListener("drop", new EventDispatcher.EventCallback(this.method_14));
			this.gclass42_0.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_13));
			this.gclass42_0.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_13));
			this.gclass42_0.gdelegate1_0 = new GClass42.GDelegate1(this.method_20);
			this.gdelegate0_0 = new GClass42.GDelegate0(this.gclass42_0.method_11);
			this.gclass42_0.gdelegate0_0 = new GClass42.GDelegate0(this.method_21);
			this.gclass25_0.Boolean_2 = this.bool_5;
			this.gclass25_0.Boolean_3 = this.bool_6;
			this.gclass25_0.Boolean_6 = this.bool_2;
			this.gclass42_0.Boolean_6 = this.bool_2;
			this.gclass42_0.String_0 = this.string_1;
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_14));
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x00021D4B File Offset: 0x0001FF4B
		private void method_13(CEvent cevent_0)
		{
			this.gclass25_0.MovieClip_0.fireEvent(new MouseEvent(cevent_0.type, true, false));
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x00021D6A File Offset: 0x0001FF6A
		private void method_14(CEvent cevent_0)
		{
			if (this.object_1 == null && cevent_0.target == this.gclass25_0)
			{
				return;
			}
			if (!this.Boolean_6)
			{
				return;
			}
			cevent_0.target = this;
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x00021D9B File Offset: 0x0001FF9B
		public void method_15(GClass42.GDelegate0 gdelegate0_2)
		{
			this.gdelegate0_1 = gdelegate0_2;
		}

		// Token: 0x060033CF RID: 13263 RVA: 0x00021DA4 File Offset: 0x0001FFA4
		public void method_16()
		{
			if (DragManagerLayer.Instance.Boolean_0)
			{
				return;
			}
			this.method_18();
		}

		// Token: 0x060033D0 RID: 13264 RVA: 0x000039EC File Offset: 0x00001BEC
		private bool method_17()
		{
			return true;
		}

		// Token: 0x060033D1 RID: 13265 RVA: 0x000EDB74 File Offset: 0x000EBD74
		private void method_18()
		{
			GClass44.bool_9 = false;
			this.bool_4 = true;
			if (this.Boolean_1)
			{
				DragManagerLayer.Instance.method_0(this.gclass25_0.DisplayObjectContainer_0 as MovieClip, this.gclass43_0, this.Object_0, this, base.DisplayObjectContainer_0, true);
			}
			else
			{
				MovieClip movieClip = ((this.movieClip_2 == null) ? this.movieClip_1 : this.movieClip_2);
				DragManagerLayer.Instance.method_0(this.gclass25_0.DisplayObjectContainer_0 as MovieClip, movieClip, this.Object_0, this, base.DisplayObjectContainer_0, true);
			}
		}

		// Token: 0x060033D2 RID: 13266 RVA: 0x00021DB9 File Offset: 0x0001FFB9
		private void method_19()
		{
			if (this.gdelegate2_0 != null)
			{
				this.gdelegate2_0(this.object_1, this);
			}
		}

		// Token: 0x060033D3 RID: 13267 RVA: 0x00021DD5 File Offset: 0x0001FFD5
		private void method_20(object object_2)
		{
			base.dispatchEvent(new GClass55("drop", new GStruct0(false, object_2, null, this.object_1), true, false));
		}

		// Token: 0x060033D4 RID: 13268 RVA: 0x00021DFD File Offset: 0x0001FFFD
		private bool method_21(object object_2)
		{
			return this.Boolean_6 && this.gdelegate0_0(object_2) && (this.gdelegate0_1 == null || this.gdelegate0_1(object_2));
		}

		// Token: 0x060033D5 RID: 13269 RVA: 0x000EDC08 File Offset: 0x000EBE08
		private void method_22(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass == null)
			{
				return;
			}
			GStruct0 gstruct = (GStruct0)gclass.object_0;
			if (this.bool_4)
			{
				if (gstruct.object_2 == null || gstruct.bool_0)
				{
				}
				this.bool_4 = false;
				if (!gstruct.bool_0)
				{
					this.method_31();
				}
			}
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x000EDC5C File Offset: 0x000EBE5C
		private void method_23(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent.buttonId == 1)
			{
				this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_25));
				this.gclass25_0.addEventListener(GClass53.string_3, new EventDispatcher.EventCallback(this.method_24));
			}
			else
			{
				if (this.Object_0 == null)
				{
					return;
				}
				this.method_28();
				this.method_14(mouseEvent);
			}
		}

		// Token: 0x060033D7 RID: 13271 RVA: 0x00021E32 File Offset: 0x00020032
		private void method_24(CEvent cevent_0)
		{
			this.gclass25_0.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_25));
			this.gclass25_0.removeEventListener(GClass53.string_3, new EventDispatcher.EventCallback(this.method_24));
		}

		// Token: 0x060033D8 RID: 13272 RVA: 0x000EDCCC File Offset: 0x000EBECC
		private void method_25(CEvent cevent_0)
		{
			GClass53 gclass = cevent_0 as GClass53;
			if (gclass.buttonId == 1)
			{
				this.method_24(gclass);
				this.method_14(gclass);
			}
		}

		// Token: 0x060033D9 RID: 13273 RVA: 0x000EDCF8 File Offset: 0x000EBEF8
		private void method_26(CEvent cevent_0)
		{
			GClass53 gclass = cevent_0 as GClass53;
			if (gclass.buttonId == 1)
			{
				return;
			}
			this.method_30(gclass);
			this.method_14(gclass);
		}

		// Token: 0x060033DA RID: 13274 RVA: 0x000EDD24 File Offset: 0x000EBF24
		private void method_27(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent.buttonId == 1)
			{
				return;
			}
			if (Math.Abs(this.movieClip_0.mouseX - this.float_0) > (float)this.int_2 || Math.Abs(this.movieClip_0.mouseY - this.float_1) > (float)this.int_2)
			{
				this.method_29(mouseEvent);
			}
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x000EDD8C File Offset: 0x000EBF8C
		private void method_28()
		{
			this.float_0 = this.movieClip_0.mouseX;
			this.float_1 = this.movieClip_0.mouseY;
			this.gclass25_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_29));
			this.gclass25_0.addEventListener(GClass53.string_2, new EventDispatcher.EventCallback(this.method_29));
			this.gclass25_0.addEventListener(GClass53.string_3, new EventDispatcher.EventCallback(this.method_30));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_27));
		}

		// Token: 0x060033DC RID: 13276 RVA: 0x00021E6E File Offset: 0x0002006E
		private void method_29(CEvent cevent_0)
		{
			this.method_30(cevent_0);
			this.method_14(new CEvent("slash"));
		}

		// Token: 0x060033DD RID: 13277 RVA: 0x000EDE4C File Offset: 0x000EC04C
		private void method_30(CEvent cevent_0)
		{
			this.gclass25_0.removeEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_29));
			this.gclass25_0.removeEventListener(GClass53.string_2, new EventDispatcher.EventCallback(this.method_29));
			this.gclass25_0.removeEventListener(GClass53.string_3, new EventDispatcher.EventCallback(this.method_30));
			this.gclass25_0.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
			this.movieClip_0.removeEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_27));
		}

		// Token: 0x060033DE RID: 13278 RVA: 0x00021E87 File Offset: 0x00020087
		private void method_31()
		{
			GClass44.int_1 = 0;
			GClass44.bool_9 = true;
		}

		// Token: 0x060033DF RID: 13279 RVA: 0x000EDEEC File Offset: 0x000EC0EC
		private void method_32()
		{
			DragManagerLayer.Instance.removeEventListener("dragEnd", new EventDispatcher.EventCallback(this.method_22));
			GClass44.int_0--;
			if (!GClass44.bool_9)
			{
				GClass44.int_1--;
			}
			base.dispatchEvent(new GClass55("destroy", this.Object_0, true, false));
		}

		// Token: 0x060033E0 RID: 13280 RVA: 0x000EDF50 File Offset: 0x000EC150
		private void method_33()
		{
			if (DragManagerLayer.Instance.Boolean_0)
			{
				if (!this.method_21(DragManagerLayer.Instance.Object_0))
				{
					return;
				}
				this.gclass42_0.Boolean_1 = true;
				this.gclass42_0.method_13("up");
				this.gclass42_0.method_13("dragUp");
			}
		}

		// Token: 0x040023DF RID: 9183
		public object object_0;

		// Token: 0x040023E0 RID: 9184
		public string string_0 = "icons";

		// Token: 0x040023E1 RID: 9185
		private bool bool_4;

		// Token: 0x040023E2 RID: 9186
		private object object_1;

		// Token: 0x040023E3 RID: 9187
		private bool bool_5;

		// Token: 0x040023E4 RID: 9188
		private bool bool_6;

		// Token: 0x040023E5 RID: 9189
		private string[] string_1;

		// Token: 0x040023E6 RID: 9190
		public GClass25 gclass25_0;

		// Token: 0x040023E7 RID: 9191
		public GClass42 gclass42_0;

		// Token: 0x040023E8 RID: 9192
		public MovieClip movieClip_1;

		// Token: 0x040023E9 RID: 9193
		public MovieClip movieClip_2;

		// Token: 0x040023EA RID: 9194
		public MovieClip movieClip_3;

		// Token: 0x040023EB RID: 9195
		public MovieClip movieClip_4;

		// Token: 0x040023EC RID: 9196
		public MovieClip movieClip_5;

		// Token: 0x040023ED RID: 9197
		public MovieClip movieClip_6;

		// Token: 0x040023EE RID: 9198
		public MovieClip movieClip_7;

		// Token: 0x040023EF RID: 9199
		public GClass43 gclass43_0;

		// Token: 0x040023F0 RID: 9200
		protected Color color_0 = Color.white;

		// Token: 0x040023F1 RID: 9201
		protected bool bool_7;

		// Token: 0x040023F2 RID: 9202
		protected bool bool_8;

		// Token: 0x040023F3 RID: 9203
		protected MovieClip movieClip_8;

		// Token: 0x040023F4 RID: 9204
		private TextField textField_0;

		// Token: 0x040023F5 RID: 9205
		private GClass42.GDelegate0 gdelegate0_0;

		// Token: 0x040023F6 RID: 9206
		private GClass42.GDelegate0 gdelegate0_1;

		// Token: 0x040023F7 RID: 9207
		private static int int_0;

		// Token: 0x040023F8 RID: 9208
		private static int int_1;

		// Token: 0x040023F9 RID: 9209
		private static bool bool_9 = true;

		// Token: 0x040023FA RID: 9210
		private float float_0;

		// Token: 0x040023FB RID: 9211
		private float float_1;

		// Token: 0x040023FC RID: 9212
		private int int_2 = 20;

		// Token: 0x040023FD RID: 9213
		protected int int_3 = -1;

		// Token: 0x040023FE RID: 9214
		protected bool bool_10;

		// Token: 0x040023FF RID: 9215
		protected GClass44.GDelegate2 gdelegate2_0;

		// Token: 0x04002400 RID: 9216
		[CompilerGenerated]
		private static Dictionary<string, int> dictionary_1;

		// Token: 0x0200079D RID: 1949
		// (Invoke) Token: 0x060033E2 RID: 13282
		public delegate void GDelegate2(object itemData, GClass44 slot);
	}
}
