using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using XsdSettings;

// Token: 0x0200048B RID: 1163
public class EquipmentInventoryEntityNpc : EquipmentInventoryEntity
{
	// Token: 0x17000196 RID: 406
	// (get) Token: 0x06001E9C RID: 7836 RVA: 0x00015555 File Offset: 0x00013755
	// (set) Token: 0x06001E9D RID: 7837 RVA: 0x0001555D File Offset: 0x0001375D
	public bool Boolean_0
	{
		get
		{
			return this.m_hasBerserkAura;
		}
		set
		{
			this.m_hasBerserkAura = value;
		}
	}

	// Token: 0x06001E9E RID: 7838 RVA: 0x000154B8 File Offset: 0x000136B8
	public override int vmethod_4()
	{
		return this.m_pouchList[0].method_5();
	}

	// Token: 0x06001E9F RID: 7839 RVA: 0x000154CB File Offset: 0x000136CB
	public override int vmethod_0()
	{
		return this.m_pouchList[0].method_4();
	}

	// Token: 0x06001EA0 RID: 7840 RVA: 0x00015566 File Offset: 0x00013766
	public override int vmethod_13(AmmoType ammoType_0 = AmmoType.SMG)
	{
		return 1000;
	}

	// Token: 0x06001EA1 RID: 7841 RVA: 0x00015566 File Offset: 0x00013766
	public override int vmethod_10(AmmoType ammoType_0 = AmmoType.SMG)
	{
		return 1000;
	}

	// Token: 0x06001EA2 RID: 7842 RVA: 0x0001556D File Offset: 0x0001376D
	public override byte vmethod_23()
	{
		return this.m_level;
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x00015566 File Offset: 0x00013766
	public override int vmethod_15(WeaponType weaponType_0)
	{
		return 1000;
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x00015575 File Offset: 0x00013775
	public void method_1(bool bool_0)
	{
		m_isHealing = (byte)(bool_0 ? 1 : 0);
	}
	// Token: 0x06001EA5 RID: 7845 RVA: 0x00015584 File Offset: 0x00013784
	public override int vmethod_6()
	{
		if (this.vmethod_26() != null)
		{
			return this.vmethod_26().m_shieldPoints.method_5();
		}
		return 0;
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x000155A6 File Offset: 0x000137A6
	public override int vmethod_7()
	{
		if (this.vmethod_26() != null)
		{
			return this.vmethod_26().m_shieldPoints.method_4();
		}
		return 0;
	}

	// Token: 0x06001EA7 RID: 7847 RVA: 0x0009724C File Offset: 0x0009544C
	public override void vmethod_9(int int_0)
	{
		EntityShield entityShield = this.vmethod_26();
		if (entityShield == null)
		{
			return;
		}
		entityShield.m_shieldPoints.method_8(int_0);
	}

	// Token: 0x06001EA8 RID: 7848 RVA: 0x00097278 File Offset: 0x00095478
	public override void vmethod_8(int int_0)
	{
		EntityShield entityShield = this.vmethod_26();
		if (entityShield == null)
		{
			return;
		}
		entityShield.m_shieldPoints.method_7(int_0);
	}

	// Token: 0x06001EA9 RID: 7849 RVA: 0x000155C8 File Offset: 0x000137C8
	public override EntityShield vmethod_26()
	{
		return this.m_shieldSlot.method_3() as EntityShield;
	}

	// Token: 0x06001EAA RID: 7850 RVA: 0x000155DA File Offset: 0x000137DA
	public override EntityWeapon vmethod_27()
	{
		return this.m_weaponSlot.method_3() as EntityWeapon;
	}

	// Token: 0x06001EAB RID: 7851 RVA: 0x000155DA File Offset: 0x000137DA
	public override EntityWeapon vmethod_28(byte byte_0)
	{
		return this.m_weaponSlot.method_3() as EntityWeapon;
	}

	// Token: 0x06001EAC RID: 7852 RVA: 0x000154DE File Offset: 0x000136DE
	public override void vmethod_1(int int_0)
	{
		this.m_pouchList[0].method_7(int_0);
	}

	// Token: 0x06001EAD RID: 7853 RVA: 0x000154F2 File Offset: 0x000136F2
	public override void vmethod_5(int int_0)
	{
		this.m_pouchList[0].method_8(int_0);
	}

	// Token: 0x06001EAE RID: 7854 RVA: 0x0001551A File Offset: 0x0001371A
	private void Awake()
	{
		this.m_pouchList.Clear();
		this.m_pouchList.Add(new Utils.PouchNetwork());
	}

	// Token: 0x06001EAF RID: 7855 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_32(byte byte_0, int int_0)
	{
	}

	// Token: 0x06001EB0 RID: 7856 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(byte byte_0, int int_0)
	{
	}

	// Token: 0x06001EB1 RID: 7857 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_3(int int_0)
	{
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x000155EC File Offset: 0x000137EC
	public override void vmethod_33(byte byte_0)
	{
		this.m_level = byte_0;
		this.m_isHealing = 0;
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x000155FC File Offset: 0x000137FC
	[RPC]
	public void RPC_ApplyShieldSetup(int maxShieldPoint, float regenerationCD, float regenerationRate)
	{
		this.m_shieldSetup = new NPCShieldSetup();
		this.m_shieldSetup.m_maxShieldPoints = maxShieldPoint;
		this.m_shieldSetup.m_regenerationCooldown = regenerationCD;
		this.m_shieldSetup.m_regenerationRate = regenerationRate;
		base.StartCoroutine(this.method_4());
	}

	// Token: 0x06001EB4 RID: 7860 RVA: 0x000972A4 File Offset: 0x000954A4
	public IEnumerator method_4()
	{
		while (vmethod_26() == null)
		{
			yield return 0;
		}
		EntityShield shield = vmethod_26();
		shield.method_17(m_shieldSetup.m_maxShieldPoints, m_shieldSetup.m_regenerationCooldown, m_shieldSetup.m_regenerationRate);
		shield.vmethod_63(GetComponent<EntityNpc>());
	}
	// Token: 0x06001EB5 RID: 7861 RVA: 0x000972C0 File Offset: 0x000954C0
	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		this.vmethod_35();
		if (stream.IsWriting)
		{
			stream.SendNext(this.m_level);
			stream.SendNext(this.m_isHealing);
			stream.SendNext(this.m_bMissionNpc);
			stream.SendNext(this.m_npcNameFromCluster);
			stream.SendNext(this.m_hasBerserkAura);
			int num = 0;
			if (this.vmethod_26() != null)
			{
				num = this.m_shieldSlot.method_3().vmethod_0();
			}
			stream.SendNext(num);
			if (num == 0)
			{
			}
			num = 0;
			if (this.m_weaponSlot.method_3())
			{
				num = this.m_weaponSlot.method_3().vmethod_0();
			}
			stream.SendNext(num);
		}
		else
		{
			this.m_level = (byte)stream.ReceiveNext();
			this.m_isHealing = (byte)stream.ReceiveNext();
			this.m_bMissionNpc = (bool)stream.ReceiveNext();
			this.m_npcNameFromCluster = (string)stream.ReceiveNext();
			this.m_hasBerserkAura = (bool)stream.ReceiveNext();
			int num2 = (int)stream.ReceiveNext();
			this.m_shieldSlot.method_0(num2, null);
			this.m_weaponSlot.method_0((int)stream.ReceiveNext(), null);
		}
	}

	// Token: 0x06001EB6 RID: 7862 RVA: 0x0001563A File Offset: 0x0001383A
	public override void vmethod_35()
	{
		base.vmethod_35();
		if (this.vmethod_26())
		{
			this.vmethod_26().m_shieldPoints.method_10();
		}
	}

	// Token: 0x06001EB7 RID: 7863 RVA: 0x0001565F File Offset: 0x0001385F
	public override void vmethod_36()
	{
		base.vmethod_36();
		if (this.vmethod_26())
		{
			this.vmethod_26().m_shieldPoints.method_11();
		}
	}

	// Token: 0x040013E7 RID: 5095
	protected byte m_level;

	// Token: 0x040013E8 RID: 5096
	protected byte m_isHealing;

	// Token: 0x040013E9 RID: 5097
	private bool m_hasBerserkAura;

	// Token: 0x040013EA RID: 5098
	public bool m_bMissionNpc;

	// Token: 0x040013EB RID: 5099
	[HideInInspector]
	public string m_npcNameFromCluster;

	// Token: 0x040013EC RID: 5100
	protected InventorySlot m_shieldSlot = new InventorySlot();

	// Token: 0x040013ED RID: 5101
	protected InventorySlot m_weaponSlot = new InventorySlot();

	// Token: 0x040013EE RID: 5102
	protected short m_lastShieldPointReceived;

	// Token: 0x040013EF RID: 5103
	private NPCShieldSetup m_shieldSetup;

	// Token: 0x0200048C RID: 1164
	private enum PouchType
	{
		// Token: 0x040013F1 RID: 5105
		LIFE
	}
}
