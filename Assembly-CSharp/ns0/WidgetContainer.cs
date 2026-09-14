using System;
using System.Collections.Generic;
using Core;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B1 RID: 1969
	public class WidgetContainer : EventDispatcher
	{
		// Token: 0x060034DF RID: 13535 RVA: 0x00022B3E File Offset: 0x00020D3E
		public WidgetContainer()
		{
			this.displayObjectContainer_0.name = "WidgetContainer";
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x060034E0 RID: 13536 RVA: 0x00022B61 File Offset: 0x00020D61
		public DisplayObjectContainer DisplayObjectContainer_0
		{
			get
			{
				return this.displayObjectContainer_0;
			}
		}

		// Token: 0x060034E1 RID: 13537 RVA: 0x00022B69 File Offset: 0x00020D69
		public MovieClip method_0(MovieClip movieClip_0)
		{
			if (this.displayObjectContainer_0 == movieClip_0)
			{
				return movieClip_0;
			}
			this.displayObjectContainer_0 = movieClip_0;
			this.method_2(movieClip_0);
			this.vmethod_0();
			return this.displayObjectContainer_0 as MovieClip;
		}

		// Token: 0x060034E2 RID: 13538 RVA: 0x000F0C90 File Offset: 0x000EEE90
		public bool method_1()
		{
			MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
			if (movieClip == null)
			{
				return false;
			}
			this.method_2(movieClip);
			this.vmethod_0();
			return true;
		}

		// Token: 0x060034E3 RID: 13539 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnAddingToStage()
		{
		}

		// Token: 0x060034E4 RID: 13540 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnRemovedFromStage()
		{
		}

		// Token: 0x060034E5 RID: 13541 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_0()
		{
		}

		// Token: 0x060034E6 RID: 13542 RVA: 0x000F0CBC File Offset: 0x000EEEBC
		private void method_2(MovieClip movieClip_0)
		{
			if (movieClip_0 == null)
			{
				return;
			}
			List<DisplayObject> list = new List<DisplayObject>();
			for (int i = 0; i < movieClip_0.numChildren; i++)
			{
				list.Add(movieClip_0.getChildAt(i));
			}
			int j = 0;
			while (j < list.Count)
			{
				DisplayObject displayObject = null;
				DisplayObject displayObject2 = list[j];
				MovieClip movieClip = displayObject2 as MovieClip;
				if (movieClip != null)
				{
					Type type = GClass52.GClass52_0.method_0(movieClip.getSymbolName());
					if (type != null)
					{
						GDelegate7 gdelegate = new GDelegate7(this.OnWidgetInitialized);
						if (this.gdelegate7_0 != null)
						{
							gdelegate = this.gdelegate7_0;
						}
						if (gdelegate(ref movieClip, type))
						{
							goto IL_00DB;
						}
					}
					this.method_2(movieClip);
					displayObject = movieClip;
					goto IL_0095;
				}
				goto IL_0095;
				IL_00DB:
				j++;
				continue;
				IL_0095:
				if (displayObject == null)
				{
					displayObject = this.OnImportDisplayObject(movieClip_0, displayObject2);
				}
				if (displayObject == null)
				{
					DebugUtils.LogWarning(LogCategory.GUI, "!--GUIError: Movieclip Error!! Missed a movie named:" + displayObject2.name);
					movieClip_0.removeChild(displayObject2);
				}
				if (displayObject != null && displayObject != displayObject2)
				{
					movieClip_0.removeChild(displayObject2);
					movieClip_0.addChild(displayObject);
					goto IL_00DB;
				}
				goto IL_00DB;
			}
		}

		// Token: 0x060034E7 RID: 13543 RVA: 0x0000311D File Offset: 0x0000131D
		protected virtual bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			return false;
		}

		// Token: 0x060034E8 RID: 13544 RVA: 0x00022B95 File Offset: 0x00020D95
		protected virtual DisplayObject OnImportDisplayObject(MovieClip movieClip, DisplayObject child)
		{
			return child;
		}

		// Token: 0x0400248B RID: 9355
		protected DisplayObjectContainer displayObjectContainer_0 = new DisplayObjectContainer();

		// Token: 0x0400248C RID: 9356
		protected GDelegate7 gdelegate7_0;
	}
}
