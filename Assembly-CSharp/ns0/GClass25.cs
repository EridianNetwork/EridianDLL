using System;
using System.Collections.Generic;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x0200078C RID: 1932
	public class GClass25 : GClass24
	{
		// Token: 0x0600331B RID: 13083 RVA: 0x000EABF4 File Offset: 0x000E8DF4
		public GClass25()
		{
			this.dictionary_1 = new Dictionary<string, string[]>();
			this.dictionary_1.Add("up", new string[] { "up" });
			this.dictionary_1.Add("over", new string[] { "over" });
			this.dictionary_1.Add("down", new string[] { "down" });
			this.dictionary_1.Add("release", new string[] { "release", "over" });
			this.dictionary_1.Add("out", new string[] { "out", "up" });
			this.dictionary_1.Add("disabled", new string[] { "disabled" });
			this.dictionary_1.Add("selecting", new string[] { "selecting", "over" });
			this.dictionary_1.Add("toggle", new string[] { "toggle", "up" });
			this.dictionary_0.Add(MouseEvent.CLICK, "UI_Select");
			this.dictionary_0.Add(GClass53.string_7, "UI_Select");
			this.dictionary_0.Add(MouseEvent.MOUSE_ENTER, "UI_World_Use_Over");
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x0600331C RID: 13084 RVA: 0x000214AA File Offset: 0x0001F6AA
		// (set) Token: 0x0600331D RID: 13085 RVA: 0x000214B2 File Offset: 0x0001F6B2
		public object Object_0
		{
			get
			{
				return this.object_0;
			}
			set
			{
				this.object_0 = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (set) Token: 0x0600331E RID: 13086 RVA: 0x000EADA4 File Offset: 0x000E8FA4
		public override bool Boolean_6
		{
			set
			{
				base.Boolean_6 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.mouseChildrenEnabled = false;
				}
				string text = ((!base.Boolean_6) ? "disabled" : "up");
				this.method_17(text);
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600331F RID: 13087 RVA: 0x000214BB File Offset: 0x0001F6BB
		// (set) Token: 0x06003320 RID: 13088 RVA: 0x000214C3 File Offset: 0x0001F6C3
		public virtual bool Boolean_2
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				this.bool_6 = value;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06003321 RID: 13089 RVA: 0x000214CC File Offset: 0x0001F6CC
		public string String_0
		{
			get
			{
				return this.string_1;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06003322 RID: 13090 RVA: 0x000214D4 File Offset: 0x0001F6D4
		// (set) Token: 0x06003323 RID: 13091 RVA: 0x000EADE8 File Offset: 0x000E8FE8
		public virtual bool Boolean_3
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
				if (this.Boolean_6)
				{
					if (this.bool_7)
					{
						this.method_17("selecting");
					}
					else
					{
						this.method_17("toggle");
					}
				}
				else
				{
					this.method_17("disabled");
				}
				this.vmethod_2();
				base.dispatchEvent(new GClass53(GClass53.string_4, true, false, 0, false));
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06003324 RID: 13092 RVA: 0x000214DC File Offset: 0x0001F6DC
		// (set) Token: 0x06003325 RID: 13093 RVA: 0x000214E4 File Offset: 0x0001F6E4
		public virtual GClass17 GClass17_0
		{
			get
			{
				return this.gclass17_0;
			}
			set
			{
				if (this.gclass17_0 != null)
				{
					this.gclass17_0.method_1(this);
				}
				this.gclass17_0 = value;
				if (this.gclass17_0 != null)
				{
					this.gclass17_0.method_0(this);
				}
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06003326 RID: 13094 RVA: 0x00021515 File Offset: 0x0001F715
		// (set) Token: 0x06003327 RID: 13095 RVA: 0x0002151D File Offset: 0x0001F71D
		public virtual string String_1
		{
			get
			{
				return this.string_2;
			}
			set
			{
				if (this.string_2 == value)
				{
					return;
				}
				this.string_2 = value;
				this.vmethod_8();
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06003328 RID: 13096 RVA: 0x0002153B File Offset: 0x0001F73B
		// (set) Token: 0x06003329 RID: 13097 RVA: 0x00021543 File Offset: 0x0001F743
		public virtual string String_2
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (this.string_0 == value)
				{
					return;
				}
				this.string_0 = value;
				((BadAssMovieClip)this.movieClip_0).vmethod_0();
				base.method_5();
			}
		}

		// Token: 0x0600332A RID: 13098 RVA: 0x000EAE4C File Offset: 0x000E904C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			if (this.movieClip_0 != null)
			{
				this.movieClip_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_10), false);
				this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_10), false);
			}
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x000EAEA4 File Offset: 0x000E90A4
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this.movieClip_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			this.movieClip_0.mouseChildrenEnabled = false;
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_12), false);
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_13), false);
			this.movieClip_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_14), false);
			this.movieClip_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_15), false);
			this.movieClip_0.addEventListener(GClass56.string_1, new EventDispatcher.EventCallback(this.method_11), false);
			this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
		}

		// Token: 0x0600332C RID: 13100 RVA: 0x000EAF88 File Offset: 0x000E9188
		protected override void vmethod_5()
		{
			if (this.vmethod_3(new string[] { GClass22.string_2 }))
			{
				if (this.string_3 != string.Empty && this.movieClip_0 != null)
				{
					this.movieClip_0.gotoAndPlay(this.string_3);
					this.string_3 = string.Empty;
				}
				this.vmethod_11();
				base.dispatchEvent(new GClass54(GClass54.string_0, false, true));
				base.method_5();
			}
			if (this.vmethod_3(new string[] { GClass22.string_3 }))
			{
				this.vmethod_9();
			}
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x000EB01C File Offset: 0x000E921C
		protected virtual void vmethod_8()
		{
			GClass17 gclass = GClass17.smethod_0(this.string_2);
			if (gclass == this.GClass17_0)
			{
				return;
			}
			this.GClass17_0 = gclass;
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x00021571 File Offset: 0x0001F771
		protected virtual void vmethod_9()
		{
			if (this.string_0 != null && this.textField_0 != null && this.textField_0.text != this.string_0)
			{
				this.textField_0.text = this.string_0;
			}
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x000215AC File Offset: 0x0001F7AC
		protected virtual void vmethod_10(CEvent cevent_0)
		{
			this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
			this.vmethod_9();
		}

		// Token: 0x06003330 RID: 13104 RVA: 0x000215CF File Offset: 0x0001F7CF
		protected virtual void vmethod_11()
		{
			if (!this.bool_0)
			{
				return;
			}
			this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
		}

		// Token: 0x06003331 RID: 13105 RVA: 0x000EB048 File Offset: 0x000E9248
		protected void method_10(CEvent cevent_0)
		{
			TextField textField = this.movieClip_0.getChildByName("textField") as TextField;
			if (this.textField_0 != textField)
			{
				this.textField_0 = textField;
				this.vmethod_9();
			}
		}

		// Token: 0x06003332 RID: 13106 RVA: 0x000EB084 File Offset: 0x000E9284
		protected void method_11(CEvent cevent_0)
		{
			string string_ = GClass53.string_7;
			if (this.Boolean_6)
			{
				this.method_17("down");
				GClass53 gclass = new GClass53(string_, true, false, 0, false);
				this.vmethod_7(gclass);
			}
		}

		// Token: 0x06003333 RID: 13107 RVA: 0x000EB0BC File Offset: 0x000E92BC
		protected void method_12(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent == null)
			{
				return;
			}
			if (!this.Boolean_6)
			{
				return;
			}
			this.method_17("over");
			mouseEvent.target = this;
			if (this.Boolean_3)
			{
				base.dispatchEvent(mouseEvent);
			}
			else
			{
				this.vmethod_7(mouseEvent);
			}
		}

		// Token: 0x06003334 RID: 13108 RVA: 0x000EB108 File Offset: 0x000E9308
		protected void method_13(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent == null)
			{
				return;
			}
			if (!this.Boolean_6)
			{
				return;
			}
			this.method_17("out");
			mouseEvent.target = this;
			base.dispatchEvent(mouseEvent);
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x000EB144 File Offset: 0x000E9344
		protected void method_14(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent == null)
			{
				return;
			}
			int buttonId = mouseEvent.buttonId;
			string text = ((buttonId != 1) ? GClass53.string_0 : GClass53.string_6);
			if (this.Boolean_6)
			{
				this.method_17("down");
				GClass53 gclass = new GClass53(text, true, false, buttonId, false);
				base.dispatchEvent(gclass);
			}
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x000EB19C File Offset: 0x000E939C
		protected void method_15(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent == null)
			{
				return;
			}
			if (!this.Boolean_6)
			{
				return;
			}
			int buttonId = mouseEvent.buttonId;
			this.method_17("release");
			if (buttonId == 1)
			{
				GClass53 gclass = new GClass53(GClass53.string_5, true, false, buttonId, false);
				this.vmethod_7(gclass);
				return;
			}
			this.vmethod_12();
			float time = Time.time;
			if (time - this.float_1 > 0.8f)
			{
				GClass53 gclass2 = new GClass53(MouseEvent.CLICK, true, false, buttonId, false);
				this.vmethod_7(gclass2);
				this.float_1 = time;
			}
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x000EB228 File Offset: 0x000E9428
		protected void method_16(CEvent cevent_0)
		{
			MouseEvent mouseEvent = cevent_0 as MouseEvent;
			if (mouseEvent == null)
			{
				return;
			}
			if (this.movieClip_0 == null)
			{
				return;
			}
			if (this.movieClip_0 != null && this.movieClip_0.contains(mouseEvent.target as DisplayObject))
			{
				return;
			}
			int buttonId = mouseEvent.buttonId;
			if (buttonId != 0)
			{
				return;
			}
			this.movieClip_0.stage.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_16), false);
			GClass53 gclass = new GClass53(GClass53.string_3, true, false, buttonId, false);
			base.dispatchEvent(gclass);
			if (!this.Boolean_6)
			{
				return;
			}
			if (this.bool_4)
			{
				this.method_17("release");
			}
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x000215F5 File Offset: 0x0001F7F5
		protected virtual void vmethod_12()
		{
			if (this.Boolean_2 && (!this.Boolean_3 || this.bool_5))
			{
				this.Boolean_3 = !this.Boolean_3;
			}
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000EB2CC File Offset: 0x000E94CC
		protected void method_17(string string_6)
		{
			this.string_1 = string_6;
			string[] array = this.method_18();
			string[] array2 = this.dictionary_1[string_6];
			if (array2 != null && array2.Length != 0)
			{
				foreach (string text in array)
				{
					foreach (string text2 in array2)
					{
						string text3 = text + text2;
						if (this.movieClip_0.getFrameLabel(text3) != 0)
						{
							this.string_3 = text3;
							base.method_6();
							return;
						}
					}
				}
				return;
			}
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x0002161E File Offset: 0x0001F81E
		protected string[] method_18()
		{
			return (!this.bool_7) ? this.string_4 : this.string_5;
		}

		// Token: 0x0400237A RID: 9082
		protected const float float_0 = 0.8f;

		// Token: 0x0400237B RID: 9083
		public bool bool_4;

		// Token: 0x0400237C RID: 9084
		public bool bool_5 = true;

		// Token: 0x0400237D RID: 9085
		protected object object_0;

		// Token: 0x0400237E RID: 9086
		protected bool bool_6;

		// Token: 0x0400237F RID: 9087
		protected string string_0;

		// Token: 0x04002380 RID: 9088
		protected string string_1;

		// Token: 0x04002381 RID: 9089
		protected GClass17 gclass17_0;

		// Token: 0x04002382 RID: 9090
		protected string string_2;

		// Token: 0x04002383 RID: 9091
		protected bool bool_7;

		// Token: 0x04002384 RID: 9092
		private Dictionary<string, string[]> dictionary_1;

		// Token: 0x04002385 RID: 9093
		protected string string_3 = string.Empty;

		// Token: 0x04002386 RID: 9094
		public TextField textField_0;

		// Token: 0x04002387 RID: 9095
		protected float float_1;

		// Token: 0x04002388 RID: 9096
		protected string[] string_4 = new string[] { string.Empty };

		// Token: 0x04002389 RID: 9097
		protected string[] string_5 = new string[]
		{
			"selected_",
			string.Empty
		};
	}
}
