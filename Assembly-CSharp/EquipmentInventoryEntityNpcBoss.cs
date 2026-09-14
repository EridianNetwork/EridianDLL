using System;
using System.Collections;
using Core;
using UnityEngine;

// Token: 0x02000490 RID: 1168
public class EquipmentInventoryEntityNpcBoss : EquipmentInventoryEntityNpc
{
	// Token: 0x06001EC9 RID: 7881 RVA: 0x000157C5 File Offset: 0x000139C5
	public NPCAnimationManagerFSM method_5()
	{
		if (this.m_animationManager == null)
		{
			this.m_animationManager = base.GetComponent<NPCAnimationManagerFSM>();
		}
		return this.m_animationManager;
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x000157E7 File Offset: 0x000139E7
	public override void Start()
	{
		base.Start();
		this.m_curphase = 1;
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x00097774 File Offset: 0x00095974
	public void method_6(byte byte_0, byte byte_1)
	{
		this.m_curphase = byte_0;
		this.m_phaseMin[(int)(this.m_curphase - 1)] = byte_1;
		if (this.m_curphase == 1)
		{
			this.m_phaseMax[0] = 100;
		}
		else if (this.m_curphase > 1 && this.m_curphase <= 3)
		{
			this.m_phaseMax[(int)(this.m_curphase - 1)] = this.m_phaseMin[(int)(this.m_curphase - 2)];
		}
	}

	// Token: 0x06001ECC RID: 7884 RVA: 0x000157F6 File Offset: 0x000139F6
	public byte method_7()
	{
		return this.m_curphase;
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x000157FE File Offset: 0x000139FE
	public byte method_8()
	{
		return this.m_phaseMin[(int)(this.m_curphase - 1)];
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x0001580F File Offset: 0x00013A0F
	public byte method_9()
	{
		return this.m_phaseMax[(int)(this.m_curphase - 1)];
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x000156C6 File Offset: 0x000138C6
	public override void vmethod_32(byte byte_0, int int_0)
	{
		this.vmethod_35();
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x000977E0 File Offset: 0x000959E0
	private void Awake()
	{
		this.m_pouchList.Clear();
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
	}

	// Token: 0x06001ED1 RID: 7889 RVA: 0x00097848 File Offset: 0x00095A48
	public override int vmethod_30(WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Back)
		{
			return this.m_pouchList[3].method_4();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Front)
		{
			return this.m_pouchList[4].method_4();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Left)
		{
			return this.m_pouchList[1].method_4();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Right)
		{
			return this.m_pouchList[2].method_4();
		}
		return base.vmethod_29(weakPoint_0);
	}

	// Token: 0x06001ED2 RID: 7890 RVA: 0x000978EC File Offset: 0x00095AEC
	public override int vmethod_29(WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Back)
		{
			return this.m_pouchList[3].method_5();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Front)
		{
			return this.m_pouchList[4].method_5();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Left)
		{
			return this.m_pouchList[1].method_5();
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.Armor_Right)
		{
			return this.m_pouchList[2].method_5();
		}
		return base.vmethod_29(weakPoint_0);
	}

	// Token: 0x06001ED3 RID: 7891 RVA: 0x00015820 File Offset: 0x00013A20
	private void method_10(WeakPoint weakPoint_0)
	{
		this.method_5().vmethod_13(weakPoint_0.m_partInfo);
		weakPoint_0.gameObject.SetActive(false);
	}

	// Token: 0x06001ED4 RID: 7892 RVA: 0x00097990 File Offset: 0x00095B90
	public override void vmethod_31(WeakPoint weakPoint_0, int int_0)
	{
		switch (weakPoint_0.m_partInfo)
		{
		case WeakPoint.PartInfo.Armor_Left:
			this.m_pouchList[1].method_8(int_0);
			break;
		case WeakPoint.PartInfo.Armor_Right:
			this.m_pouchList[2].method_8(int_0);
			break;
		case WeakPoint.PartInfo.Armor_Back:
			this.m_pouchList[3].method_8(int_0);
			break;
		case WeakPoint.PartInfo.Armor_Front:
			this.m_pouchList[4].method_8(int_0);
			break;
		default:
			DebugUtils.LogError(LogCategory.Gamelogic, "Unkown WeakPoint PartInfo!");
			break;
		}
		if (int_0 <= 0)
		{
			this.method_10(weakPoint_0);
		}
		base.vmethod_31(weakPoint_0, int_0);
	}

	// Token: 0x06001ED5 RID: 7893 RVA: 0x00097A2C File Offset: 0x00095C2C
	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.IsWriting)
		{
			stream.SendNext(this.m_curphase);
			stream.SendNext(this.m_phaseMin[(int)(this.m_curphase - 1)]);
			stream.SendNext(this.m_phaseMax[(int)(this.m_curphase - 1)]);
		}
		else
		{
			this.m_curphase = (byte)stream.ReceiveNext();
			this.m_phaseMin[(int)(this.m_curphase - 1)] = (byte)stream.ReceiveNext();
			this.m_phaseMax[(int)(this.m_curphase - 1)] = (byte)stream.ReceiveNext();
		}
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x00097AD8 File Offset: 0x00095CD8
	public override Hashtable vmethod_37()
	{
		Hashtable hashtable = new Hashtable();
		hashtable[0] = this.m_pouchList[3].method_4();
		hashtable[1] = this.m_pouchList[3].method_5();
		hashtable[2] = this.m_pouchList[4].method_4();
		hashtable[3] = this.m_pouchList[4].method_5();
		hashtable[4] = this.m_pouchList[1].method_4();
		hashtable[5] = this.m_pouchList[1].method_5();
		hashtable[6] = this.m_pouchList[2].method_4();
		hashtable[7] = this.m_pouchList[2].method_5();
		hashtable[8] = this.vmethod_0();
		hashtable[9] = this.vmethod_4();
		hashtable[10] = this.vmethod_7();
		hashtable[11] = this.vmethod_6();
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
		{
			"Boss.SerializeLifeAndShield life[",
			this.vmethod_4(),
			"/",
			this.vmethod_0(),
			"] - shield[",
			this.vmethod_6(),
			"/",
			this.vmethod_7(),
			"]"
		}));
		return hashtable;
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x00097CD0 File Offset: 0x00095ED0
	public override void vmethod_38(Hashtable hashtable_0)
	{
		this.vmethod_35();
		int num = (int)hashtable_0[0];
		int num2 = (int)hashtable_0[1];
		this.m_pouchList[3].method_7(num);
		this.m_pouchList[3].method_8(num2);
		num = (int)hashtable_0[2];
		num2 = (int)hashtable_0[3];
		this.m_pouchList[4].method_7(num);
		this.m_pouchList[4].method_8(num2);
		num = (int)hashtable_0[4];
		num2 = (int)hashtable_0[5];
		this.m_pouchList[1].method_7(num);
		this.m_pouchList[1].method_8(num2);
		num = (int)hashtable_0[6];
		num2 = (int)hashtable_0[7];
		this.m_pouchList[2].method_7(num);
		this.m_pouchList[2].method_8(num2);
		int num3 = (int)hashtable_0[8];
		int num4 = (int)hashtable_0[9];
		int num5 = (int)hashtable_0[10];
		int num6 = (int)hashtable_0[11];
		this.vmethod_1(num3);
		this.vmethod_5(num4);
		this.vmethod_8(num5);
		this.vmethod_9(num6);
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "Boss.UnSerializeLifeAndShield life[", num4, "/", num3, "] - shield[", num6, "/", num5, "]" }));
	}

	// Token: 0x040013FB RID: 5115
	[SerializeField]
	private int m_armorPointLeft = 100;

	// Token: 0x040013FC RID: 5116
	[SerializeField]
	private int m_armorPointRight = 100;

	// Token: 0x040013FD RID: 5117
	[SerializeField]
	private int m_armorPointBack = 100;

	// Token: 0x040013FE RID: 5118
	[SerializeField]
	private int m_armorPointFront;

	// Token: 0x040013FF RID: 5119
	protected byte m_curphase = 1;

	// Token: 0x04001400 RID: 5120
	protected byte[] m_phaseMax = new byte[3];

	// Token: 0x04001401 RID: 5121
	protected byte[] m_phaseMin = new byte[3];

	// Token: 0x04001402 RID: 5122
	private NPCAnimationManagerFSM m_animationManager;

	// Token: 0x02000491 RID: 1169
	private enum PouchType
	{
		// Token: 0x04001404 RID: 5124
		LIFE,
		// Token: 0x04001405 RID: 5125
		ARMORLEFT,
		// Token: 0x04001406 RID: 5126
		ARMORRIGHT,
		// Token: 0x04001407 RID: 5127
		ARMORBACK,
		// Token: 0x04001408 RID: 5128
		ARMORFRONT
	}
}
