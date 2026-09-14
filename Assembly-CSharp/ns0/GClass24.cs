using System;
using System.Collections.Generic;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007AF RID: 1967
	public class GClass24 : WidgetContainer
	{
		// Token: 0x060034BF RID: 13503 RVA: 0x00022999 File Offset: 0x00020B99
		public GClass24()
		{
			this.movieClip_0 = null;
			this.dictionary_0 = new Dictionary<string, string>();
			this.hashSet_0 = new HashSet<string>();
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060034C0 RID: 13504 RVA: 0x000229C5 File Offset: 0x00020BC5
		// (set) Token: 0x060034C1 RID: 13505 RVA: 0x000229CD File Offset: 0x00020BCD
		public virtual bool Boolean_6
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (value == this.bool_2)
				{
					return;
				}
				this.bool_2 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.mouseEnabled = value;
				}
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060034C2 RID: 13506 RVA: 0x000229F4 File Offset: 0x00020BF4
		public virtual MovieClip MovieClip_0
		{
			get
			{
				return this.movieClip_0;
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060034C3 RID: 13507 RVA: 0x000229FC File Offset: 0x00020BFC
		// (set) Token: 0x060034C4 RID: 13508 RVA: 0x00022A04 File Offset: 0x00020C04
		public virtual bool Boolean_1
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.visible = this.bool_3;
				}
			}
		}

		// Token: 0x060034C5 RID: 13509 RVA: 0x00022A26 File Offset: 0x00020C26
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0 = this.displayObjectContainer_0 as MovieClip;
			this.method_3(null);
		}

		// Token: 0x060034C6 RID: 13510 RVA: 0x000F0994 File Offset: 0x000EEB94
		public void method_3(string[] string_0 = null)
		{
			if (string_0 != null && string_0.Length != 0)
			{
				uint num = 0U;
				while ((ulong)num < (ulong)((long)string_0.Length))
				{
					this.hashSet_0.Add(string_0[(int)((UIntPtr)num)]);
					num += 1U;
				}
			}
			else
			{
				this.hashSet_0.Add(GClass22.string_0);
			}
			if (!this.bool_1)
			{
				this.bool_1 = true;
				this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.vmethod_1), false);
			}
		}

		// Token: 0x060034C7 RID: 13511 RVA: 0x00022A46 File Offset: 0x00020C46
		protected virtual void vmethod_1(CEvent cevent_0)
		{
			this.vmethod_2();
		}

		// Token: 0x060034C8 RID: 13512 RVA: 0x000F0A0C File Offset: 0x000EEC0C
		public virtual void vmethod_2()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.vmethod_4();
			}
			this.movieClip_0.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.vmethod_1), false);
			if (!this.bool_1)
			{
				return;
			}
			this.vmethod_5();
			this.hashSet_0.Clear();
			this.bool_1 = false;
		}

		// Token: 0x060034C9 RID: 13513 RVA: 0x000F0A70 File Offset: 0x000EEC70
		protected virtual bool vmethod_3(string[] string_0)
		{
			if (!this.bool_1)
			{
				return false;
			}
			if (string_0.Length == 0)
			{
				return this.bool_1;
			}
			if (this.hashSet_0.Contains(GClass22.string_0))
			{
				return true;
			}
			foreach (string text in string_0)
			{
				if (this.hashSet_0.Contains(text))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060034CA RID: 13514 RVA: 0x00022A4E File Offset: 0x00020C4E
		public void method_4()
		{
			this.method_3(new string[] { GClass22.string_1 });
		}

		// Token: 0x060034CB RID: 13515 RVA: 0x00022A64 File Offset: 0x00020C64
		public void method_5()
		{
			this.method_3(new string[] { GClass22.string_3 });
		}

		// Token: 0x060034CC RID: 13516 RVA: 0x00022A7A File Offset: 0x00020C7A
		public void method_6()
		{
			this.method_3(new string[] { GClass22.string_2 });
		}

		// Token: 0x060034CD RID: 13517 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_4()
		{
		}

		// Token: 0x060034CE RID: 13518 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_5()
		{
		}

		// Token: 0x060034CF RID: 13519 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_6(CEvent cevent_0)
		{
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060034D0 RID: 13520 RVA: 0x00022A90 File Offset: 0x00020C90
		public Dictionary<string, string> Dictionary_0
		{
			get
			{
				return this.dictionary_0;
			}
		}

		// Token: 0x060034D1 RID: 13521 RVA: 0x00022A98 File Offset: 0x00020C98
		public void method_7(string string_0, string string_1)
		{
			if (!this.Dictionary_0.ContainsKey(string_0))
			{
				this.Dictionary_0.Add(string_0, string_1);
			}
			else
			{
				this.Dictionary_0[string_0] = string_1;
			}
		}

		// Token: 0x060034D2 RID: 13522 RVA: 0x00022AC4 File Offset: 0x00020CC4
		protected virtual void vmethod_7(CEvent cevent_0)
		{
			GClass61.GClass61_0.method_1(cevent_0, this.dictionary_0);
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060034D3 RID: 13523 RVA: 0x00022ADF File Offset: 0x00020CDF
		// (set) Token: 0x060034D4 RID: 13524 RVA: 0x000F0ACC File Offset: 0x000EECCC
		public GInterface1 GInterface1_0
		{
			get
			{
				return this.ginterface1_0;
			}
			set
			{
				if (value == null)
				{
					base.DisplayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_8));
					base.DisplayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_9));
				}
				else if (this.ginterface1_0 == null)
				{
					base.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_8));
					base.DisplayObjectContainer_0.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_9));
				}
				this.ginterface1_0 = value;
				base.dispatchEvent(new CEvent("tipsChange"));
			}
		}

		// Token: 0x060034D5 RID: 13525 RVA: 0x00022AE7 File Offset: 0x00020CE7
		protected void method_8(CEvent cevent_0)
		{
			GClass60.GClass60_0.method_0(this, this.GInterface1_0);
		}

		// Token: 0x060034D6 RID: 13526 RVA: 0x00022AFA File Offset: 0x00020CFA
		protected void method_9(CEvent cevent_0)
		{
			GClass60.GClass60_0.method_2();
		}

		// Token: 0x04002481 RID: 9345
		protected MovieClip movieClip_0;

		// Token: 0x04002482 RID: 9346
		public bool bool_0;

		// Token: 0x04002483 RID: 9347
		protected HashSet<string> hashSet_0;

		// Token: 0x04002484 RID: 9348
		protected bool bool_1;

		// Token: 0x04002485 RID: 9349
		protected bool bool_2 = true;

		// Token: 0x04002486 RID: 9350
		protected bool bool_3;

		// Token: 0x04002487 RID: 9351
		protected Dictionary<string, string> dictionary_0;

		// Token: 0x04002488 RID: 9352
		protected GInterface1 ginterface1_0;
	}
}
