using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace BHV
{
	// Token: 0x0200016C RID: 364
	public class BHVTask
	{
		// Token: 0x06000856 RID: 2134 RVA: 0x0000861D File Offset: 0x0000681D
		public BHVTask()
		{
			this.m_Status = BHVTaskStatus.INVALID;
			this.m_Type = BHVTaskType.INVALID;
			this.m_Layer = BHVTaskLayer.FULLBODY;
			this.bool_0 = false;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x00008641 File Offset: 0x00006841
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x00008649 File Offset: 0x00006849
		[XmlIgnore]
		public BHVTaskStatus m_Status { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x00008652 File Offset: 0x00006852
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0000865A File Offset: 0x0000685A
		[XmlIgnore]
		public BHVTaskType m_Type { get; protected set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x00008663 File Offset: 0x00006863
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x0000866B File Offset: 0x0000686B
		[XmlIgnore]
		public BHVTaskLayer m_Layer { get; protected set; }

		// Token: 0x0600085D RID: 2141 RVA: 0x00003C2E File Offset: 0x00001E2E
		public virtual BHVTaskParam vmethod_0()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00008674 File Offset: 0x00006874
		public static bool smethod_0(BHVTaskParam bhvtaskParam_0, BHVTask bhvtask_0)
		{
			return bhvtaskParam_0.m_Type == bhvtask_0.m_Type && bhvtaskParam_0.m_Layer == bhvtask_0.m_Layer;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00008695 File Offset: 0x00006895
		public virtual void vmethod_1(BHVTaskManager bhvtaskManager_1)
		{
			this.bhvtaskManager_0 = bhvtaskManager_1;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0005B7CC File Offset: 0x000599CC
		public virtual bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			bool flag;
			if ((flag = BHVTask.smethod_0(bhvtaskParam_0, this)) && bhvtaskParam_0 != null)
			{
				bhvtaskParam_0.vmethod_0();
			}
			return flag;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0000869E File Offset: 0x0000689E
		public virtual void Start()
		{
			this.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void Update(float deltaTime)
		{
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_3(bool bool_1)
		{
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0005B7F0 File Offset: 0x000599F0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(string.Empty);
			if (this.vmethod_0() != null)
			{
				stringBuilder.Append(string.Format("    {0}: #{1} - Type:{2} - Status:{3}\n", new object[]
				{
					this.m_Layer.ToString(),
					this.vmethod_0().m_UID.ToString(),
					this.m_Type.ToString(),
					this.m_Status.ToString()
				}));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040007EF RID: 2031
		protected BHVTaskManager bhvtaskManager_0;

		// Token: 0x040007F0 RID: 2032
		[XmlIgnore]
		public bool bool_0;

		// Token: 0x040007F1 RID: 2033
		[CompilerGenerated]
		private BHVTaskStatus bhvtaskStatus_0;

		// Token: 0x040007F2 RID: 2034
		[CompilerGenerated]
		private BHVTaskType bhvtaskType_0;

		// Token: 0x040007F3 RID: 2035
		[CompilerGenerated]
		private BHVTaskLayer bhvtaskLayer_0;
	}
}
