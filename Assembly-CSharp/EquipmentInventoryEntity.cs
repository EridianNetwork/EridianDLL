using System;
using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x02000487 RID: 1159
public abstract class EquipmentInventoryEntity : global::Photon.MonoBehaviour
{
	// Token: 0x06001E68 RID: 7784
	public abstract int vmethod_0();

	// Token: 0x06001E69 RID: 7785
	public abstract void vmethod_1(int int_0);

	// Token: 0x06001E6A RID: 7786 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_2()
	{
		return 0;
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_3(int int_0)
	{
	}

	// Token: 0x06001E6C RID: 7788
	public abstract int vmethod_4();

	// Token: 0x06001E6D RID: 7789
	public abstract void vmethod_5(int int_0);

	// Token: 0x06001E6E RID: 7790 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_6()
	{
		return 0;
	}

	// Token: 0x06001E6F RID: 7791 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_7()
	{
		return 0;
	}

	// Token: 0x06001E70 RID: 7792 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8(int int_0)
	{
	}

	// Token: 0x06001E71 RID: 7793 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_9(int int_0)
	{
	}

	// Token: 0x06001E72 RID: 7794 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_10(AmmoType ammoType_0 = AmmoType.SMG)
	{
		return 0;
	}

	// Token: 0x06001E73 RID: 7795 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_11(WeaponType weaponType_0)
	{
		return 0;
	}

	// Token: 0x06001E74 RID: 7796 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_12(WeaponType weaponType_0)
	{
		return 0;
	}

	// Token: 0x06001E75 RID: 7797 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_13(AmmoType ammoType_0 = AmmoType.SMG)
	{
		return 0;
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_14(int int_0, AmmoType ammoType_0 = AmmoType.SMG)
	{
	}

	// Token: 0x06001E77 RID: 7799 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_15(WeaponType weaponType_0)
	{
		return 0;
	}

	// Token: 0x06001E78 RID: 7800 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_16(int int_0, WeaponType weaponType_0)
	{
	}

	// Token: 0x06001E79 RID: 7801 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_17(int int_0, WeaponType weaponType_0)
	{
	}

	// Token: 0x06001E7A RID: 7802 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_18()
	{
		return 0;
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_19()
	{
		return 0;
	}

	// Token: 0x06001E7C RID: 7804 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_20(int int_0)
	{
	}

	// Token: 0x06001E7D RID: 7805 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_21()
	{
		return 0;
	}

	// Token: 0x06001E7E RID: 7806 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_22(int int_0)
	{
	}

	// Token: 0x06001E7F RID: 7807 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual byte vmethod_23()
	{
		return 0;
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual EquipmentInventoryEntity.PropertyFlags vmethod_24()
	{
		return EquipmentInventoryEntity.PropertyFlags.None;
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_25(EquipmentInventoryEntity.PropertyFlags propertyFlags_0)
	{
	}

	// Token: 0x06001E82 RID: 7810 RVA: 0x00003727 File Offset: 0x00001927
	public virtual EntityShield vmethod_26()
	{
		return null;
	}

	// Token: 0x06001E83 RID: 7811 RVA: 0x00003727 File Offset: 0x00001927
	public virtual EntityWeapon vmethod_27()
	{
		return null;
	}

	// Token: 0x06001E84 RID: 7812 RVA: 0x00003727 File Offset: 0x00001927
	public virtual EntityWeapon vmethod_28(byte byte_0)
	{
		return null;
	}

	// Token: 0x06001E85 RID: 7813 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_29(WeakPoint weakPoint_0)
	{
		return 0;
	}

	// Token: 0x06001E86 RID: 7814 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual int vmethod_30(WeakPoint weakPoint_0)
	{
		return 0;
	}

	// Token: 0x06001E87 RID: 7815 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_31(WeakPoint weakPoint_0, int int_0)
	{
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_32(byte byte_0, int int_0)
	{
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_33(byte byte_0)
	{
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x00015483 File Offset: 0x00013683
	public virtual void Start()
	{
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_1(base.GetComponent<Entity>());
		}
	}

	// Token: 0x06001E8B RID: 7819 RVA: 0x00014B67 File Offset: 0x00012D67
	private void OnDestroy()
	{
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_2(base.GetComponent<Entity>());
		}
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x00097050 File Offset: 0x00095250
	public virtual bool vmethod_34(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return false;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		return !(playerInfoSync == null) && playerInfoSync.IsMyActor();
	}

	// Token: 0x06001E8D RID: 7821 RVA: 0x00097090 File Offset: 0x00095290
	public virtual void vmethod_35()
	{
		foreach (Utils.PouchNetwork pouchNetwork in this.m_pouchList)
		{
			pouchNetwork.method_10();
		}
	}

	// Token: 0x06001E8E RID: 7822 RVA: 0x000970E4 File Offset: 0x000952E4
	public virtual void vmethod_36()
	{
		foreach (Utils.PouchNetwork pouchNetwork in this.m_pouchList)
		{
			pouchNetwork.method_11();
		}
	}

	// Token: 0x06001E8F RID: 7823 RVA: 0x00097138 File Offset: 0x00095338
	public virtual Hashtable vmethod_37()
	{
		Hashtable hashtable = new Hashtable();
		hashtable[0] = this.vmethod_0();
		hashtable[1] = this.vmethod_4();
		hashtable[2] = this.vmethod_7();
		hashtable[3] = this.vmethod_6();
		return hashtable;
	}

	// Token: 0x06001E90 RID: 7824 RVA: 0x000971A8 File Offset: 0x000953A8
	public virtual void vmethod_38(Hashtable hashtable_0)
	{
		int num = (int)hashtable_0[0];
		int num2 = (int)hashtable_0[1];
		int num3 = (int)hashtable_0[2];
		int num4 = (int)hashtable_0[3];
		this.vmethod_1(num);
		this.vmethod_5(num2);
		this.vmethod_8(num3);
		this.vmethod_9(num4);
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x0009721C File Offset: 0x0009541C
	public void method_0()
	{
		Hashtable hashtable = this.vmethod_37();
		base.photonView.method_4("RPC_SendLifeAndShield", PhotonTargets.Others, new object[] { hashtable });
	}

	// Token: 0x06001E92 RID: 7826 RVA: 0x000154A1 File Offset: 0x000136A1
	[RPC]
	protected void RPC_SendLifeAndShield(Hashtable data)
	{
		this.vmethod_35();
		this.vmethod_38(data);
	}

	// Token: 0x040013D8 RID: 5080
	protected Entity m_entity;

	// Token: 0x040013D9 RID: 5081
	protected List<Utils.PouchNetwork> m_pouchList = new List<Utils.PouchNetwork>();

	// Token: 0x02000488 RID: 1160
	public enum PropertyFlags
	{
		// Token: 0x040013DB RID: 5083
		None,
		// Token: 0x040013DC RID: 5084
		InBattle,
		// Token: 0x040013DD RID: 5085
		Flag1,
		// Token: 0x040013DE RID: 5086
		Flag2 = 4,
		// Token: 0x040013DF RID: 5087
		Flag3 = 8,
		// Token: 0x040013E0 RID: 5088
		Flag4 = 16,
		// Token: 0x040013E1 RID: 5089
		Flag5 = 32,
		// Token: 0x040013E2 RID: 5090
		Flag6 = 64,
		// Token: 0x040013E3 RID: 5091
		Flag7 = 128,
		// Token: 0x040013E4 RID: 5092
		All = 2147483647
	}
}
