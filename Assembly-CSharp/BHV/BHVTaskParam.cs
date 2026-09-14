using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Core;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200016A RID: 362
	public abstract class BHVTaskParam
	{
		// Token: 0x06000848 RID: 2120 RVA: 0x000085B4 File Offset: 0x000067B4
		public BHVTaskParam()
		{
			this.m_Type = BHVTaskType.INVALID;
			this.m_Layer = BHVTaskLayer.FULLBODY;
			this.m_UID = -1;
			this.bool_0 = false;
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x000085D8 File Offset: 0x000067D8
		// (set) Token: 0x0600084A RID: 2122 RVA: 0x000085E0 File Offset: 0x000067E0
		public BHVTaskType m_Type { get; protected set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x000085E9 File Offset: 0x000067E9
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x000085F1 File Offset: 0x000067F1
		public BHVTaskLayer m_Layer { get; protected set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x000085FA File Offset: 0x000067FA
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x00008602 File Offset: 0x00006802
		public int m_UID { get; set; }

		// Token: 0x0600084F RID: 2127 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_0()
		{
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_1()
		{
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0005B690 File Offset: 0x00059890
		public virtual void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			if (bool_1)
			{
				data_0.int_0 = this.m_UID;
				data_0.bhvtaskType_0 = this.m_Type;
				data_0.bhvtaskLayer_0 = this.m_Layer;
				data_0.bool_0 = this.bool_0;
			}
			else
			{
				this.m_UID = data_0.int_0;
				this.m_Type = data_0.bhvtaskType_0;
				this.m_Layer = data_0.bhvtaskLayer_0;
				this.bool_0 = data_0.bool_0;
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0005B70C File Offset: 0x0005990C
		protected static GameObject smethod_0(int int_3)
		{
			if (int_3 != -1)
			{
				BadAssNetworkView badAssNetworkView = BadAssNetworkView.smethod_3(int_3);
				if (badAssNetworkView != null)
				{
					return badAssNetworkView.gameObject;
				}
			}
			return null;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0005B738 File Offset: 0x00059938
		protected static int smethod_1(GameObject gameObject_0)
		{
			if (gameObject_0 != null)
			{
				Entity component = gameObject_0.GetComponent<Entity>();
				if (component != null)
				{
					return component.vmethod_0();
				}
			}
			return -1;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0005B768 File Offset: 0x00059968
		public static BHVTaskParam smethod_2(string string_0)
		{
			BHVTaskParam bhvtaskParam = null;
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Type type = executingAssembly.GetType("BHV.BHVTaskParam" + string_0);
				bhvtaskParam = (BHVTaskParam)Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.AI, ex.ToString() + " " + string_0);
				bhvtaskParam = null;
			}
			return bhvtaskParam;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0000860B File Offset: 0x0000680B
		public static BHVTaskParam smethod_3(BHVTaskType bhvtaskType_1)
		{
			return BHVTaskParam.smethod_2(bhvtaskType_1.ToString());
		}

		// Token: 0x040007E3 RID: 2019
		public const int int_0 = -1;

		// Token: 0x040007E4 RID: 2020
		public const int int_1 = -1;

		// Token: 0x040007E5 RID: 2021
		public bool bool_0;

		// Token: 0x040007E6 RID: 2022
		[CompilerGenerated]
		private BHVTaskType bhvtaskType_0;

		// Token: 0x040007E7 RID: 2023
		[CompilerGenerated]
		private BHVTaskLayer bhvtaskLayer_0;

		// Token: 0x040007E8 RID: 2024
		[CompilerGenerated]
		private int int_2;
	}
}
