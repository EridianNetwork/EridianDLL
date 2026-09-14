using System;
using System.Collections.Generic;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B0 RID: 1968
	public class GClass51 : WidgetContainer
	{
		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060034D8 RID: 13528 RVA: 0x00022B19 File Offset: 0x00020D19
		public string String_0
		{
			get
			{
				if (this.string_0 == null)
				{
					this.string_0 = this.ToString();
				}
				return this.string_0;
			}
		}

		// Token: 0x170002CA RID: 714
		// (set) Token: 0x060034D9 RID: 13529 RVA: 0x000F0B74 File Offset: 0x000EED74
		public string String_1
		{
			set
			{
				if (value == string.Empty)
				{
					return;
				}
				MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
				if (movieClip == null)
				{
					return;
				}
				movieClip.addFrameScript(value, new EventDispatcher.EventCallback(this.vmethod_1));
			}
		}

		// Token: 0x060034DA RID: 13530 RVA: 0x000F0BB4 File Offset: 0x000EEDB4
		public MovieClip method_3(MovieClip movieClip_0, GDelegate7 gdelegate7_1)
		{
			this.gdelegate7_0 = gdelegate7_1;
			MovieClip movieClip = base.method_0(movieClip_0);
			this.list_0.Clear();
			return movieClip;
		}

		// Token: 0x060034DB RID: 13531 RVA: 0x000F0BDC File Offset: 0x000EEDDC
		public MovieClip method_4(MovieClip movieClip_0, string string_1, GDelegate7 gdelegate7_1 = null)
		{
			this.gdelegate7_0 = gdelegate7_1;
			MovieClip movieClip = base.method_0(movieClip_0);
			this.String_1 = string_1;
			return movieClip;
		}

		// Token: 0x060034DC RID: 13532 RVA: 0x00022B35 File Offset: 0x00020D35
		protected virtual void vmethod_1(CEvent cevent_0)
		{
			base.method_1();
		}

		// Token: 0x060034DD RID: 13533 RVA: 0x000F0C00 File Offset: 0x000EEE00
		protected override DisplayObject OnImportDisplayObject(MovieClip movieClip, DisplayObject child)
		{
			UnityTextField unityTextField = child as UnityTextField;
			if (unityTextField != null)
			{
				this.list_0.Add(unityTextField);
			}
			return base.OnImportDisplayObject(movieClip, child);
		}

		// Token: 0x060034DE RID: 13534 RVA: 0x000F0C2C File Offset: 0x000EEE2C
		public override void OnRemovedFromStage()
		{
			base.OnRemovedFromStage();
			foreach (UnityTextField unityTextField in this.list_0)
			{
				if (unityTextField.Boolean_0)
				{
					GClass58.GClass58_0.method_2();
				}
			}
		}

		// Token: 0x04002489 RID: 9353
		protected string string_0;

		// Token: 0x0400248A RID: 9354
		protected List<UnityTextField> list_0 = new List<UnityTextField>();
	}
}
