using System;
using System.Collections.Generic;
using pumpkin.events;

namespace ns0
{
	// Token: 0x0200078D RID: 1933
	public class GClass17 : EventDispatcher
	{
		// Token: 0x0600333B RID: 13115 RVA: 0x00021636 File Offset: 0x0001F836
		public GClass17(string string_1)
		{
			this.string_0 = string_1;
			this.list_0 = new List<GClass25>();
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x000EB35C File Offset: 0x000E955C
		public static GClass17 smethod_0(string string_1)
		{
			GClass17 gclass;
			if (GClass17.dictionary_0.ContainsKey(string_1.ToLower()))
			{
				gclass = GClass17.dictionary_0[string_1.ToLower()];
			}
			else
			{
				gclass = new GClass17(string_1);
				GClass17.dictionary_0.Add(string_1.ToLower(), gclass);
			}
			return gclass;
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x0600333E RID: 13118 RVA: 0x0002165C File Offset: 0x0001F85C
		public int Int32_0
		{
			get
			{
				return this.list_0.Count;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x0600333F RID: 13119 RVA: 0x00021669 File Offset: 0x0001F869
		public object Object_0
		{
			get
			{
				return (this.gclass25_0 != null) ? this.gclass25_0.Object_0 : null;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06003340 RID: 13120 RVA: 0x00021681 File Offset: 0x0001F881
		public int Int32_1
		{
			get
			{
				return this.list_0.IndexOf(this.gclass25_0);
			}
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x000EB3AC File Offset: 0x000E95AC
		public void method_0(GClass25 gclass25_1)
		{
			this.method_1(gclass25_1);
			this.list_0.Add(gclass25_1);
			if (gclass25_1.Boolean_3)
			{
				this.method_4(gclass25_1, true);
			}
			gclass25_1.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_6), false);
			gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7), false);
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x000EB410 File Offset: 0x000E9610
		public void method_1(GClass25 gclass25_1)
		{
			this.list_0.Remove(gclass25_1);
			gclass25_1.removeEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_6), false);
			gclass25_1.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7), false);
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x00021694 File Offset: 0x0001F894
		public GClass25 method_2(int int_0)
		{
			return this.list_0[int_0];
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x000EB45C File Offset: 0x000E965C
		public bool method_3(int int_0, bool bool_0 = true)
		{
			bool flag = false;
			GClass25 gclass = this.list_0[int_0];
			if (gclass != null)
			{
				gclass.Boolean_3 = bool_0;
				flag = true;
			}
			return flag;
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x000EB488 File Offset: 0x000E9688
		protected void method_4(GClass25 gclass25_1, bool bool_0 = true)
		{
			if (bool_0 && gclass25_1 == this.gclass25_0)
			{
				return;
			}
			bool flag = !bool_0 && gclass25_1 == this.gclass25_0 && gclass25_1.bool_5;
			GClass25 gclass = this.gclass25_0;
			if (bool_0)
			{
				this.gclass25_0 = gclass25_1;
			}
			if (bool_0 && gclass != null)
			{
				gclass.Boolean_3 = false;
			}
			if (flag)
			{
				this.gclass25_0 = null;
			}
			else if (!bool_0)
			{
				return;
			}
			base.dispatchEvent(new CEvent(CEvent.CHANGED));
		}

		// Token: 0x06003346 RID: 13126 RVA: 0x000216A2 File Offset: 0x0001F8A2
		public bool method_5(GClass25 gclass25_1)
		{
			return this.list_0.Contains(gclass25_1);
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x000EB4F8 File Offset: 0x000E96F8
		protected void method_6(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass.Boolean_3)
			{
				this.method_4(gclass, true);
			}
			else
			{
				this.method_4(gclass, false);
			}
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_7(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x000216BA File Offset: 0x0001F8BA
		protected void method_8(CEvent cevent_0)
		{
			this.method_1(cevent_0.target as GClass25);
		}

		// Token: 0x0400238A RID: 9098
		public static Dictionary<string, GClass17> dictionary_0 = new Dictionary<string, GClass17>();

		// Token: 0x0400238B RID: 9099
		public string string_0;

		// Token: 0x0400238C RID: 9100
		public GClass25 gclass25_0;

		// Token: 0x0400238D RID: 9101
		protected List<GClass25> list_0;
	}
}
