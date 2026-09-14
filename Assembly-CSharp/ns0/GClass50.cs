using System;
using System.Collections.Generic;
using Core;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007AB RID: 1963
	public class GClass50 : GClass24
	{
		// Token: 0x0600347E RID: 13438 RVA: 0x000EFFAC File Offset: 0x000EE1AC
		public GClass50()
		{
			this.dictionary_0.Add(CEvent.CHANGED, "UI_Type");
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06003481 RID: 13441 RVA: 0x00022601 File Offset: 0x00020801
		// (set) Token: 0x06003480 RID: 13440 RVA: 0x000225E6 File Offset: 0x000207E6
		public List<char> List_0
		{
			get
			{
				return (this.textField_0 != null) ? ((UnityTextField)this.textField_0).restrictChars : null;
			}
			set
			{
				if (this.textField_0 != null)
				{
					((UnityTextField)this.textField_0).restrictChars = value;
				}
			}
		}

		// Token: 0x06003482 RID: 13442 RVA: 0x000F0048 File Offset: 0x000EE248
		protected override void vmethod_0()
		{
			base.vmethod_0();
			if (this.movieClip_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TextInput onInit() 'controlMC' is null! TextInput won't work!!!");
				return;
			}
			this.movieClip_0.mouseEnabled = (this.movieClip_0.mouseChildrenEnabled = this.Boolean_6);
			this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
			if (this.textField_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TextInput onConfiUI() 'textField' is not exist nor a TextField! TextInput won't have text!!!");
				return;
			}
			this.textFormat_1 = this.textField_0.textFormat;
			this.textFormat_0 = new TextFormat();
			this.textFormat_0.italic = true;
			this.textFormat_0.color = new Color(170f, 170f, 170f);
		}

		// Token: 0x170002B5 RID: 693
		// (set) Token: 0x06003483 RID: 13443 RVA: 0x0002261E File Offset: 0x0002081E
		public override bool Boolean_6
		{
			set
			{
				base.Boolean_6 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.mouseChildrenEnabled = value;
				}
				this.method_14(new string[] { this.String_2 });
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06003484 RID: 13444 RVA: 0x00022650 File Offset: 0x00020850
		// (set) Token: 0x06003485 RID: 13445 RVA: 0x000F0104 File Offset: 0x000EE304
		public virtual bool Boolean_2
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				this.bool_10 = value;
				if (value)
				{
					GClass58.GClass58_0.method_0(this);
				}
				else
				{
					GClass58.GClass58_0.method_1(this);
				}
				if (value && this.movieClip_0.stage != null)
				{
					this.movieClip_0.stage.focus = this.textField_0;
				}
				else if (this.movieClip_0.stage != null && this.movieClip_0.stage.focus == this.textField_0)
				{
					this.movieClip_0.stage.focus = null;
				}
			}
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x00022658 File Offset: 0x00020858
		public bool method_10()
		{
			return this.movieClip_0.stage.focus == this.textField_0;
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06003487 RID: 13447 RVA: 0x00022672 File Offset: 0x00020872
		// (set) Token: 0x06003488 RID: 13448 RVA: 0x000F0194 File Offset: 0x000EE394
		public virtual bool Boolean_3
		{
			get
			{
				return this.bool_9;
			}
			set
			{
				this.bool_9 = value;
				this.vmethod_9();
				if (this.bool_9 && this.Boolean_1)
				{
					this.movieClip_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_17), false);
				}
				else
				{
					this.movieClip_0.removeEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_17), false);
				}
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06003489 RID: 13449 RVA: 0x0002267A File Offset: 0x0002087A
		// (set) Token: 0x0600348A RID: 13450 RVA: 0x00022682 File Offset: 0x00020882
		public string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				base.method_5();
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x0600348B RID: 13451 RVA: 0x00022691 File Offset: 0x00020891
		// (set) Token: 0x0600348C RID: 13452 RVA: 0x00022699 File Offset: 0x00020899
		public string String_1
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				base.method_5();
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600348D RID: 13453 RVA: 0x000226A8 File Offset: 0x000208A8
		// (set) Token: 0x0600348E RID: 13454 RVA: 0x000226B0 File Offset: 0x000208B0
		public bool Boolean_0
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				this.vmethod_10();
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600348F RID: 13455 RVA: 0x000226BF File Offset: 0x000208BF
		// (set) Token: 0x06003490 RID: 13456 RVA: 0x000226C7 File Offset: 0x000208C7
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (this.textField_0 != null)
				{
					this.textField_0.maxChars = value;
				}
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06003491 RID: 13457 RVA: 0x000226E4 File Offset: 0x000208E4
		// (set) Token: 0x06003492 RID: 13458 RVA: 0x000226EC File Offset: 0x000208EC
		public new bool Boolean_1
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				if (this.textField_0 != null)
				{
					this.textField_0.type = ((!this.bool_5 || !this.Boolean_6) ? TextFieldType.DYNAMIC : TextFieldType.INPUT);
				}
				this.Boolean_3 = value;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06003493 RID: 13459 RVA: 0x0002272B File Offset: 0x0002092B
		public virtual int Int32_1
		{
			get
			{
				return this.string_0.Length;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06003494 RID: 13460 RVA: 0x00022738 File Offset: 0x00020938
		public string String_2
		{
			get
			{
				return this.Boolean_6 ? ((!this.Boolean_2) ? "default" : "default") : "disabled";
			}
		}

		// Token: 0x06003495 RID: 13461 RVA: 0x0002275D File Offset: 0x0002095D
		public virtual void vmethod_8(string string_5)
		{
			this.string_0 += string_5;
			base.method_5();
		}

		// Token: 0x06003496 RID: 13462 RVA: 0x000F01FC File Offset: 0x000EE3FC
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this.movieClip_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TextInput onConfiUI() 'controlMC' is null! TextInput won't work!!!");
				return;
			}
			this.movieClip_0.addEventListener(CEvent.REMOVED_FROM_STAGE, new EventDispatcher.EventCallback(this.method_11));
			if (this.textField_0 == null)
			{
				this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
				if (this.textField_0 == null)
				{
					DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TextInput onConfiUI() 'textField' is not exist nor a TextField! TextInput won't have text!!!");
				}
				this.textField_0.addEventListener(FocusEvent.FOCUS_IN, new EventDispatcher.EventCallback(this.method_12));
				this.textField_0.addEventListener(FocusEvent.FOCUS_OUT, new EventDispatcher.EventCallback(this.method_13));
			}
			if (this.Boolean_3 && this.Boolean_1)
			{
				this.movieClip_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_17), false);
			}
			this.method_14(new string[] { this.String_2, "default" });
		}

		// Token: 0x06003497 RID: 13463 RVA: 0x000F02FC File Offset: 0x000EE4FC
		protected override void vmethod_5()
		{
			if (this.vmethod_3(new string[] { GClass22.string_2 }))
			{
				if (this.string_2 != string.Empty && this.movieClip_0 != null)
				{
					this.movieClip_0.gotoAndPlay(this.string_2);
					this.string_2 = string.Empty;
				}
				this.vmethod_12();
				this.vmethod_10();
			}
			else if (this.vmethod_3(new string[] { GClass22.string_3 }))
			{
				this.vmethod_11();
			}
		}

		// Token: 0x06003498 RID: 13464 RVA: 0x00022777 File Offset: 0x00020977
		protected virtual void vmethod_9()
		{
			this.method_14(new string[] { this.String_2 });
		}

		// Token: 0x06003499 RID: 13465 RVA: 0x000F0380 File Offset: 0x000EE580
		protected virtual void vmethod_10()
		{
			if (this.textField_0 == null)
			{
				DebugUtils.Log(LogCategory.GUI, "UIWarning: TextInput updateTextField() 'textField' is not exist nor a TextField! TextInput won't have text!!!");
				return;
			}
			this.vmethod_11();
			this.textField_0.maxChars = this.int_0;
			this.textField_0.displayAsPassword = this.bool_4;
			this.textField_0.type = ((!this.bool_5 || !this.Boolean_6) ? TextFieldType.DYNAMIC : TextFieldType.INPUT);
			this.textField_0.removeEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_18), false);
			this.textField_0.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_18), false);
			if (this.textField_0.hasEventListener(FocusEvent.FOCUS_IN))
			{
				this.textField_0.removeEventListener(FocusEvent.FOCUS_IN, new EventDispatcher.EventCallback(this.method_12), false);
			}
			this.textField_0.addEventListener(FocusEvent.FOCUS_IN, new EventDispatcher.EventCallback(this.method_12), false);
		}

		// Token: 0x0600349A RID: 13466 RVA: 0x0002278E File Offset: 0x0002098E
		protected void method_11(CEvent cevent_0)
		{
			if (this.Boolean_2)
			{
				GClass58.GClass58_0.method_2();
			}
		}

		// Token: 0x0600349B RID: 13467 RVA: 0x000227A2 File Offset: 0x000209A2
		protected void method_12(CEvent cevent_0)
		{
			GClass58.GClass58_0.method_0(this);
		}

		// Token: 0x0600349C RID: 13468 RVA: 0x000227AF File Offset: 0x000209AF
		protected void method_13(CEvent cevent_0)
		{
			GClass58.GClass58_0.method_1(this);
		}

		// Token: 0x0600349D RID: 13469 RVA: 0x000F047C File Offset: 0x000EE67C
		protected virtual void vmethod_11()
		{
			if (this.bool_10 && this.bool_8)
			{
				this.textField_0.textFormat = this.textFormat_1;
				this.bool_8 = false;
			}
			if (this.string_0 != string.Empty)
			{
				this.textField_0.text = (this.bool_4 ? new string('*', this.string_0.Length) : this.string_0);
				return;
			}
			this.textField_0.text = string.Empty;
			if (!this.bool_10 && !this.bool_4 && this.string_3 != string.Empty)
			{
				this.textField_0.text = this.string_3;
				this.bool_8 = true;
				if (this.textFormat_0 != null)
				{
					this.textField_0.textFormat = this.textFormat_0;
				}
			}
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x000F0554 File Offset: 0x000EE754
		protected void method_14(string[] string_5)
		{
			foreach (string text in string_5)
			{
				if (this.movieClip_0.getFrameLabel(text) != 0)
				{
					this.string_1 = (this.string_2 = text);
					base.method_6();
					return;
				}
			}
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x000F059C File Offset: 0x000EE79C
		protected virtual void vmethod_12()
		{
			if (!this.bool_0)
			{
				return;
			}
			this.textField_0 = this.movieClip_0.getChildByName("textField") as TextField;
			if (this.textField_0 == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TextInput updateAfterStateChange() 'textField' is not exist nor a TextField! TextInput won't have text!!!");
			}
			if (this.bool_10)
			{
				this.movieClip_0.stage.focus = this.textField_0;
			}
		}

		// Token: 0x060034A0 RID: 13472 RVA: 0x000F0600 File Offset: 0x000EE800
		protected void method_15(CEvent cevent_0)
		{
			if (!(cevent_0 is MouseEvent))
			{
				return;
			}
			if (!this.Boolean_2 && this.Boolean_6)
			{
				this.method_14(new string[] { "over" });
				return;
			}
		}

		// Token: 0x060034A1 RID: 13473 RVA: 0x000F0640 File Offset: 0x000EE840
		protected void method_16(CEvent cevent_0)
		{
			if (!(cevent_0 is MouseEvent))
			{
				return;
			}
			if (!this.Boolean_2 && this.Boolean_6)
			{
				this.method_14(new string[] { "out", "default" });
				return;
			}
		}

		// Token: 0x060034A2 RID: 13474 RVA: 0x000F0688 File Offset: 0x000EE888
		protected void method_17(CEvent cevent_0)
		{
			if (!(cevent_0 is MouseEvent))
			{
				return;
			}
			if (!this.Boolean_2 && this.Boolean_6)
			{
				this.movieClip_0.stage.focus = this.textField_0;
				return;
			}
		}

		// Token: 0x060034A3 RID: 13475 RVA: 0x000227BC File Offset: 0x000209BC
		protected void method_18(CEvent cevent_0)
		{
			this.string_0 = this.textField_0.text;
			this.vmethod_7(new CEvent(CEvent.CHANGED));
		}

		// Token: 0x0400245E RID: 9310
		public TextFormat textFormat_0;

		// Token: 0x0400245F RID: 9311
		protected string string_0 = string.Empty;

		// Token: 0x04002460 RID: 9312
		protected bool bool_4;

		// Token: 0x04002461 RID: 9313
		protected int int_0;

		// Token: 0x04002462 RID: 9314
		protected bool bool_5 = true;

		// Token: 0x04002463 RID: 9315
		protected bool bool_6;

		// Token: 0x04002464 RID: 9316
		protected bool bool_7;

		// Token: 0x04002465 RID: 9317
		protected string string_1 = "default";

		// Token: 0x04002466 RID: 9318
		protected string string_2;

		// Token: 0x04002467 RID: 9319
		protected TextFormat textFormat_1;

		// Token: 0x04002468 RID: 9320
		protected bool bool_8 = true;

		// Token: 0x04002469 RID: 9321
		protected string string_3 = string.Empty;

		// Token: 0x0400246A RID: 9322
		protected bool bool_9;

		// Token: 0x0400246B RID: 9323
		protected bool bool_10;

		// Token: 0x0400246C RID: 9324
		protected string string_4 = "*";

		// Token: 0x0400246D RID: 9325
		public TextField textField_0;

		// Token: 0x0400246E RID: 9326
		public static List<char> list_0 = new List<char> { '\u00a0', '\u3000', ' ' };
	}
}
