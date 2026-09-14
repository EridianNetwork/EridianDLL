using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000168 RID: 360
	public sealed class BHVTaskParamSync
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x0000855A File Offset: 0x0000675A
		public BHVTaskParamSync()
		{
			this.data_0 = new BHVTaskParamSync.Data();
			this.data_0.Reset();
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00008578 File Offset: 0x00006778
		internal bool method_0()
		{
			return this.data_0 != null && this.data_0.method_0();
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00008590 File Offset: 0x00006790
		internal void method_1(PhotonStream photonStream_0)
		{
			if (this.data_0 != null)
			{
				this.data_0.method_1(photonStream_0);
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0005B29C File Offset: 0x0005949C
		internal BHVTaskParam method_2()
		{
			if (this.method_0())
			{
				BHVTaskParam bhvtaskParam = BHVTaskParam.smethod_3(this.data_0.bhvtaskType_0);
				if (bhvtaskParam != null)
				{
					bhvtaskParam.vmethod_2(ref this.data_0, false);
					return bhvtaskParam;
				}
			}
			return null;
		}

		// Token: 0x040007CB RID: 1995
		public BHVTaskParamSync.Data data_0;

		// Token: 0x02000169 RID: 361
		public class Data
		{
			// Token: 0x06000845 RID: 2117 RVA: 0x0005B2D8 File Offset: 0x000594D8
			public void Reset()
			{
				this.int_0 = -1;
				this.bhvtaskType_0 = BHVTaskType.INVALID;
				this.bool_0 = false;
				this.bhvtaskLayer_0 = BHVTaskLayer.INVALID;
				this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
				this.bhvfireStyle_0 = BHVFireStyle.INVALID;
				this.bhvstance_0 = BHVStance.INVALID;
				this.bhvstressLevel_0 = BHVStressLevel.INVALID;
				this.bhvmovementSpeed_0 = BHVMovementSpeed.INVALID;
				this.animationStateFSM_0 = AnimationStateFSM.Invalid;
				this.float_0 = -1f;
				this.int_1 = -1;
				this.int_2 = -1;
				this.int_3 = -1;
				this.bool_1 = false;
				this.bool_2 = false;
				this.bool_3 = false;
				this.int_4 = 0;
			}

			// Token: 0x06000846 RID: 2118 RVA: 0x000085A6 File Offset: 0x000067A6
			internal bool method_0()
			{
				return this.bhvtaskType_0 != BHVTaskType.INVALID;
			}

			// Token: 0x06000847 RID: 2119 RVA: 0x0005B368 File Offset: 0x00059568
			internal void method_1(PhotonStream photonStream_0)
			{
				if (photonStream_0.IsWriting)
				{
					photonStream_0.SendNext(this.int_0);
					photonStream_0.SendNext(this.bhvtaskType_0);
					photonStream_0.SendNext(this.bhvtaskLayer_0);
					photonStream_0.SendNext(this.bool_0);
					photonStream_0.SendNext(this.coverHeight_0);
					photonStream_0.SendNext(this.bhvfireStyle_0);
					photonStream_0.SendNext(this.bhvstance_0);
					photonStream_0.SendNext(this.bhvstressLevel_0);
					photonStream_0.SendNext(this.bhvmovementSpeed_0);
					photonStream_0.SendNext(this.animationStateFSM_0);
					photonStream_0.SendNext(this.float_0);
					photonStream_0.SendNext(this.int_1);
					photonStream_0.SendNext(this.int_2);
					photonStream_0.SendNext(this.int_3);
					photonStream_0.SendNext(this.bool_1);
					photonStream_0.SendNext(this.bool_2);
					photonStream_0.SendNext(this.bool_3);
					photonStream_0.SendNext(this.vector3_0);
					photonStream_0.SendNext(this.vector3_1);
					photonStream_0.SendNext(this.vector3_2);
					photonStream_0.SendNext(this.vector3_3);
					photonStream_0.SendNext(this.int_4);
					photonStream_0.SendNext(this.string_0);
				}
				else
				{
					this.int_0 = (int)photonStream_0.ReceiveNext();
					this.bhvtaskType_0 = (BHVTaskType)((int)photonStream_0.ReceiveNext());
					this.bhvtaskLayer_0 = (BHVTaskLayer)((int)photonStream_0.ReceiveNext());
					this.bool_0 = (bool)photonStream_0.ReceiveNext();
					this.coverHeight_0 = (CoverSlot.CoverHeight)((int)photonStream_0.ReceiveNext());
					this.bhvfireStyle_0 = (BHVFireStyle)((int)photonStream_0.ReceiveNext());
					this.bhvstance_0 = (BHVStance)((int)photonStream_0.ReceiveNext());
					this.bhvstressLevel_0 = (BHVStressLevel)((int)photonStream_0.ReceiveNext());
					this.bhvmovementSpeed_0 = (BHVMovementSpeed)((int)photonStream_0.ReceiveNext());
					this.animationStateFSM_0 = (AnimationStateFSM)((int)photonStream_0.ReceiveNext());
					this.float_0 = (float)photonStream_0.ReceiveNext();
					this.int_1 = (int)photonStream_0.ReceiveNext();
					this.int_2 = (int)photonStream_0.ReceiveNext();
					this.int_3 = (int)photonStream_0.ReceiveNext();
					this.bool_1 = (bool)photonStream_0.ReceiveNext();
					this.bool_2 = (bool)photonStream_0.ReceiveNext();
					this.bool_3 = (bool)photonStream_0.ReceiveNext();
					this.vector3_0 = (Vector3)photonStream_0.ReceiveNext();
					this.vector3_1 = (Vector3)photonStream_0.ReceiveNext();
					this.vector3_2 = (Vector3)photonStream_0.ReceiveNext();
					this.vector3_3 = (Vector3)photonStream_0.ReceiveNext();
					this.int_4 = (int)photonStream_0.ReceiveNext();
					this.string_0 = (string)photonStream_0.ReceiveNext();
				}
			}

			// Token: 0x040007CC RID: 1996
			public BHVTaskType bhvtaskType_0;

			// Token: 0x040007CD RID: 1997
			public BHVTaskLayer bhvtaskLayer_0;

			// Token: 0x040007CE RID: 1998
			public int int_0;

			// Token: 0x040007CF RID: 1999
			public bool bool_0;

			// Token: 0x040007D0 RID: 2000
			public CoverSlot.CoverHeight coverHeight_0;

			// Token: 0x040007D1 RID: 2001
			public BHVFireStyle bhvfireStyle_0;

			// Token: 0x040007D2 RID: 2002
			public BHVStance bhvstance_0;

			// Token: 0x040007D3 RID: 2003
			public BHVStressLevel bhvstressLevel_0;

			// Token: 0x040007D4 RID: 2004
			public BHVMovementSpeed bhvmovementSpeed_0;

			// Token: 0x040007D5 RID: 2005
			public AnimationStateFSM animationStateFSM_0;

			// Token: 0x040007D6 RID: 2006
			public float float_0;

			// Token: 0x040007D7 RID: 2007
			public int int_1;

			// Token: 0x040007D8 RID: 2008
			public int int_2;

			// Token: 0x040007D9 RID: 2009
			public int int_3;

			// Token: 0x040007DA RID: 2010
			public Vector3 vector3_0;

			// Token: 0x040007DB RID: 2011
			public Vector3 vector3_1;

			// Token: 0x040007DC RID: 2012
			public Vector3 vector3_2;

			// Token: 0x040007DD RID: 2013
			public Vector3 vector3_3;

			// Token: 0x040007DE RID: 2014
			public bool bool_1;

			// Token: 0x040007DF RID: 2015
			public bool bool_2;

			// Token: 0x040007E0 RID: 2016
			public bool bool_3;

			// Token: 0x040007E1 RID: 2017
			public int int_4;

			// Token: 0x040007E2 RID: 2018
			public string string_0;
		}
	}
}
