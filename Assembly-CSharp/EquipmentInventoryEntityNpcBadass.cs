using System;
using System.Collections;
using Core;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class EquipmentInventoryEntityNpcBadass : EquipmentInventoryEntityNpc
{
	// Token: 0x06001EBF RID: 7871 RVA: 0x000156A4 File Offset: 0x000138A4
	public NPCAnimationManagerFSM method_5()
	{
		if (this.m_animationManager == null)
		{
			this.m_animationManager = base.GetComponent<NPCAnimationManagerFSM>();
		}
		return this.m_animationManager;
	}

	// Token: 0x06001EC0 RID: 7872 RVA: 0x000156C6 File Offset: 0x000138C6
	public override void vmethod_32(byte byte_0, int int_0)
	{
		this.vmethod_35();
	}

	// Token: 0x06001EC1 RID: 7873 RVA: 0x000156CE File Offset: 0x000138CE
	private void Awake()
	{
		this.m_pouchList.Clear();
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
	}

	// Token: 0x06001EC2 RID: 7874 RVA: 0x000156FB File Offset: 0x000138FB
	public override int vmethod_30(WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.ExtraPart)
		{
			return this.m_pouchList[1].method_4();
		}
		return base.vmethod_29(weakPoint_0);
	}

	// Token: 0x06001EC3 RID: 7875 RVA: 0x00015731 File Offset: 0x00013931
	public override int vmethod_29(WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return base.vmethod_29(weakPoint_0);
		}
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.ExtraPart)
		{
			return this.m_pouchList[1].method_5();
		}
		return base.vmethod_29(weakPoint_0);
	}

	// Token: 0x06001EC4 RID: 7876 RVA: 0x00015767 File Offset: 0x00013967
	private void method_6(WeakPoint weakPoint_0)
	{
		this.method_5().vmethod_13(weakPoint_0.m_partInfo);
		weakPoint_0.gameObject.SetActive(false);
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x000974DC File Offset: 0x000956DC
	public override void vmethod_31(WeakPoint weakPoint_0, int int_0)
	{
		WeakPoint.PartInfo partInfo = weakPoint_0.m_partInfo;
		if (partInfo != WeakPoint.PartInfo.ExtraPart)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Unkown WeakPoint PartInfo!");
		}
		else
		{
			this.m_pouchList[1].method_8(int_0);
		}
		if (int_0 <= 0)
		{
			this.method_6(weakPoint_0);
		}
		base.vmethod_31(weakPoint_0, int_0);
	}

	// Token: 0x06001EC6 RID: 7878 RVA: 0x00097528 File Offset: 0x00095728
	public override Hashtable vmethod_37()
	{
		Hashtable hashtable = new Hashtable();
		hashtable[0] = this.m_pouchList[1].method_4();
		hashtable[1] = this.m_pouchList[1].method_5();
		hashtable[2] = this.vmethod_0();
		hashtable[3] = this.vmethod_4();
		hashtable[4] = this.vmethod_7();
		hashtable[5] = this.vmethod_6();
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

	// Token: 0x06001EC7 RID: 7879 RVA: 0x00097650 File Offset: 0x00095850
	public override void vmethod_38(Hashtable hashtable_0)
	{
		this.vmethod_35();
		int num = (int)hashtable_0[0];
		int num2 = (int)hashtable_0[1];
		this.m_pouchList[1].method_7(num);
		this.m_pouchList[1].method_8(num2);
		int num3 = (int)hashtable_0[2];
		int num4 = (int)hashtable_0[3];
		int num5 = (int)hashtable_0[4];
		int num6 = (int)hashtable_0[5];
		this.vmethod_1(num3);
		this.vmethod_5(num4);
		this.vmethod_8(num5);
		this.vmethod_9(num6);
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "Boss.UnSerializeLifeAndShield life[", num4, "/", num3, "] - shield[", num6, "/", num5, "]" }));
	}

	// Token: 0x040013F6 RID: 5110
	[SerializeField]
	private int m_extraPartLifePoint = 1;

	// Token: 0x040013F7 RID: 5111
	private NPCAnimationManagerFSM m_animationManager;

	// Token: 0x0200048F RID: 1167
	private enum PouchType
	{
		// Token: 0x040013F9 RID: 5113
		LIFE,
		// Token: 0x040013FA RID: 5114
		ExtraPartLife
	}
}
