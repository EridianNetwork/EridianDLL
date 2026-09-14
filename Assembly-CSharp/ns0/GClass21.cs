using System;
using System.Collections.Generic;
using Core;
using pumpkin.display;

namespace ns0
{
	// Token: 0x020007AD RID: 1965
	public class GClass21
	{
		// Token: 0x060034B5 RID: 13493 RVA: 0x000228D0 File Offset: 0x00020AD0
		public GClass21(DisplayObjectContainer displayObjectContainer_1)
		{
			if (displayObjectContainer_1 != null)
			{
				this.dictionary_0 = new Dictionary<string, DisplayObjectContainer>();
				this.displayObjectContainer_0 = displayObjectContainer_1;
			}
		}

		// Token: 0x060034B6 RID: 13494 RVA: 0x00003197 File Offset: 0x00001397
		private GClass21()
		{
		}

		// Token: 0x060034B7 RID: 13495 RVA: 0x000228ED File Offset: 0x00020AED
		public void method_0()
		{
			this.displayObjectContainer_0.removeAllChildren();
			this.dictionary_0.Clear();
		}

		// Token: 0x060034B8 RID: 13496 RVA: 0x000F0860 File Offset: 0x000EEA60
		public int method_1(string string_0)
		{
			if (this.dictionary_0.ContainsKey(string_0))
			{
				return this.displayObjectContainer_0.getChildIndex(this.dictionary_0[string_0]);
			}
			DisplayObjectContainer displayObjectContainer = new DisplayObjectContainer();
			displayObjectContainer.name = string_0;
			int count = this.dictionary_0.Count;
			this.displayObjectContainer_0.addChildAt(displayObjectContainer, count);
			this.dictionary_0.Add(string_0, displayObjectContainer);
			return count;
		}

		// Token: 0x060034B9 RID: 13497 RVA: 0x00022905 File Offset: 0x00020B05
		public bool method_2(DisplayObject displayObject_0, string string_0)
		{
			if (!this.dictionary_0.ContainsKey(string_0))
			{
				DebugUtils.LogWarning(LogCategory.GUI, "You should create layer first: " + string_0);
				return false;
			}
			this.dictionary_0[string_0].addChild(displayObject_0);
			return true;
		}

		// Token: 0x060034BA RID: 13498 RVA: 0x0002293B File Offset: 0x00020B3B
		public bool method_3(DisplayObject displayObject_0, string string_0)
		{
			if (!this.dictionary_0.ContainsKey(string_0))
			{
				return false;
			}
			if (!this.dictionary_0[string_0].contains(displayObject_0))
			{
				return false;
			}
			this.dictionary_0[string_0].removeChild(displayObject_0);
			return true;
		}

		// Token: 0x060034BB RID: 13499 RVA: 0x000F08C8 File Offset: 0x000EEAC8
		public void method_4(DisplayObject displayObject_0)
		{
			foreach (KeyValuePair<string, DisplayObjectContainer> keyValuePair in this.dictionary_0)
			{
				if (keyValuePair.Value.contains(displayObject_0))
				{
					keyValuePair.Value.removeChild(displayObject_0);
					break;
				}
			}
		}

		// Token: 0x060034BC RID: 13500 RVA: 0x00022976 File Offset: 0x00020B76
		public void method_5(bool bool_0, string string_0)
		{
			if (!this.dictionary_0.ContainsKey(string_0))
			{
				return;
			}
			this.dictionary_0[string_0].visible = bool_0;
		}

		// Token: 0x04002477 RID: 9335
		private DisplayObjectContainer displayObjectContainer_0;

		// Token: 0x04002478 RID: 9336
		private Dictionary<string, DisplayObjectContainer> dictionary_0;
	}
}
