using System;
using System.IO;
using ns0;
using Photon;

// Token: 0x02000AB9 RID: 2745
public class MarkCollect : MonoBehaviour
{
	// Token: 0x17000781 RID: 1921
	// (get) Token: 0x06004A78 RID: 19064 RVA: 0x00030B0E File Offset: 0x0002ED0E
	public static MarkCollect MarkCollect_0
	{
		get
		{
			return MarkCollect.s_instance;
		}
	}

	// Token: 0x06004A79 RID: 19065 RVA: 0x00030B15 File Offset: 0x0002ED15
	private void Awake()
	{
		MarkCollect.s_instance = this;
	}

	// Token: 0x06004A7A RID: 19066 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06004A7B RID: 19067 RVA: 0x00030B1D File Offset: 0x0002ED1D
	private void Update()
	{
		this.method_0();
		this.method_1();
	}

	// Token: 0x06004A7C RID: 19068 RVA: 0x001358F8 File Offset: 0x00133AF8
	private void method_0()
	{
		if (this.m_synctype == MarkCollect.SyncType.Unknown)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				this.m_localplayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			}
			if (this.m_localplayer != null)
			{
				if (MonoSingleton<Session>.Instance.method_16())
				{
					this.m_synctype = MarkCollect.SyncType.Never;
				}
				else
				{
					this.m_skill = this.m_localplayer.PlayerSkillManage_0 as HunterManage;
					this.m_synctype = ((!(this.m_skill != null)) ? MarkCollect.SyncType.Never : MarkCollect.SyncType.Sync);
				}
			}
		}
	}

	// Token: 0x06004A7D RID: 19069 RVA: 0x0013599C File Offset: 0x00133B9C
	private void method_1()
	{
		bool flag;
		if ((flag = this.method_2()) != this.m_marked_lasttick)
		{
			int num = ((!flag) ? this.m_marked_id_lasttick : MonoSingleton<TargetingManager>.Instance.m_aimedEntity.vmethod_0());
			this.OnMarkStateChanged(num, flag);
		}
		else if (flag && this.m_marked_lasttick && MonoSingleton<TargetingManager>.Instance.m_aimedEntity.vmethod_0() != this.m_marked_id_lasttick)
		{
			this.OnMarkStateChanged(this.m_marked_id_lasttick, false);
			this.OnMarkStateChanged(MonoSingleton<TargetingManager>.Instance.m_aimedEntity.vmethod_0(), true);
		}
		this.m_marked_lasttick = flag;
		this.m_marked_id_lasttick = ((!flag) ? 0 : MonoSingleton<TargetingManager>.Instance.m_aimedEntity.vmethod_0());
		if (flag)
		{
			this.method_4("HunterSkill_Plane_Aiming");
		}
	}

	// Token: 0x06004A7E RID: 19070 RVA: 0x00135A54 File Offset: 0x00133C54
	public bool method_2()
	{
		bool flag = false;
		if (this.m_synctype == MarkCollect.SyncType.Sync && this.m_skill.method_14() && MonoSingleton<TargetingManager>.Instance && MonoSingleton<TargetingManager>.Instance.m_aimedEntity && MonoSingleton<TargetingManager>.Instance.m_aimedEntity.vmethod_9() != this.m_localplayer.vmethod_9())
		{
			flag = true;
		}
		return flag;
	}

	// Token: 0x06004A7F RID: 19071 RVA: 0x00030B2B File Offset: 0x0002ED2B
	public bool method_3(Entity entity_0)
	{
		return this.method_2() && MonoSingleton<TargetingManager>.Instance.m_aimedEntity == entity_0;
	}

	// Token: 0x06004A80 RID: 19072 RVA: 0x00135AB8 File Offset: 0x00133CB8
	public void OnMarkStateChanged(int _id, bool _ismark)
	{
		object[] array = new object[] { _id, _ismark };
		base.photonView.method_4("RPC_L2H_MarkCollect", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06004A81 RID: 19073 RVA: 0x00030B48 File Offset: 0x0002ED48
	public void OnMarkLevelChanged(Entity _marked)
	{
		if (this.method_3(_marked))
		{
			this.method_4("HunterSkill_Plane_Mark");
		}
	}

	// Token: 0x06004A82 RID: 19074 RVA: 0x00030B5E File Offset: 0x0002ED5E
	private void method_4(string string_0)
	{
		if (this.m_localplayer == null)
		{
			this.m_localplayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		}
		this.m_localplayer.vmethod_15().m_audioCtl.TriggerEventByName(string_0);
	}

	// Token: 0x06004A83 RID: 19075 RVA: 0x00135AF0 File Offset: 0x00133CF0
	public void method_5(Entity entity_0, Entity entity_1)
	{
		object[] array = new object[]
		{
			entity_0.vmethod_0(),
			entity_1.vmethod_0()
		};
		base.photonView.method_4("RPC_L2H_AutoMark", PhotonTargets.MasterClient, array);
	}

	// Token: 0x04003632 RID: 13874
	private static MarkCollect s_instance;

	// Token: 0x04003633 RID: 13875
	private MarkCollect.SyncType m_synctype;

	// Token: 0x04003634 RID: 13876
	private EntityPlayer m_localplayer;

	// Token: 0x04003635 RID: 13877
	private HunterManage m_skill;

	// Token: 0x04003636 RID: 13878
	private bool m_marked_lasttick;

	// Token: 0x04003637 RID: 13879
	private int m_marked_id_lasttick;

	// Token: 0x02000ABA RID: 2746
	public enum SyncType
	{
		// Token: 0x04003639 RID: 13881
		Unknown,
		// Token: 0x0400363A RID: 13882
		Never,
		// Token: 0x0400363B RID: 13883
		Sync
	}

	// Token: 0x02000ABB RID: 2747
	public class MarkInfoLocal
	{
		// Token: 0x06004A84 RID: 19076 RVA: 0x00030B9E File Offset: 0x0002ED9E
		public MarkInfoLocal(int int_0, float float_0, int int_1)
		{
			this.m_networkId = int_0;
			this.m_deltatime = float_0;
			this.m_frame = int_1;
		}

		// Token: 0x06004A86 RID: 19078 RVA: 0x00135B34 File Offset: 0x00133D34
		public byte[] method_0()
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes(this.m_networkId), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(this.m_deltatime), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(this.m_frame), 0, 4);
			return memoryStream.ToArray();
		}

		// Token: 0x06004A87 RID: 19079 RVA: 0x00135B88 File Offset: 0x00133D88
		public static MarkCollect.MarkInfoLocal smethod_0(byte[] byte_0)
		{
			MarkCollect.MarkInfoLocal markInfoLocal = new MarkCollect.MarkInfoLocal(0, 0f, 0);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_0, 0, byte_0.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(MarkCollect.MarkInfoLocal.buff_int, 0, 4);
			markInfoLocal.m_networkId = BitConverter.ToInt32(MarkCollect.MarkInfoLocal.buff_int, 0);
			memoryStream.Read(MarkCollect.MarkInfoLocal.buff_float, 0, 4);
			markInfoLocal.m_deltatime = BitConverter.ToSingle(MarkCollect.MarkInfoLocal.buff_float, 0);
			memoryStream.Read(MarkCollect.MarkInfoLocal.buff_int, 0, 4);
			markInfoLocal.m_frame = BitConverter.ToInt32(MarkCollect.MarkInfoLocal.buff_int, 0);
			return markInfoLocal;
		}

		// Token: 0x0400363C RID: 13884
		public int m_networkId;

		// Token: 0x0400363D RID: 13885
		public float m_deltatime;

		// Token: 0x0400363E RID: 13886
		public int m_frame;

		// Token: 0x0400363F RID: 13887
		private static byte[] buff_int = new byte[4];

		// Token: 0x04003640 RID: 13888
		private static byte[] buff_float = new byte[4];
	}
}
