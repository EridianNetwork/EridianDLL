using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using XsdSettings;

// Token: 0x02000457 RID: 1111
public class EntityNpcSoldierTurret : EntityNpc
{
	// Token: 0x06001BB4 RID: 7092 RVA: 0x00013EB2 File Offset: 0x000120B2
	public Transform method_22(WeaponType weaponType_0)
	{
		if (weaponType_0 == WeaponType.SMG)
		{
			return this.m_SMGHolder;
		}
		return this.m_rightHandWeaponSlot;
	}

	// Token: 0x06001BB5 RID: 7093 RVA: 0x00013EC4 File Offset: 0x000120C4
	public override void Start()
	{
		base.Start();
		if (base.photonView.Object_0 != null)
		{
			this.m_teamID = (int)base.photonView.Object_0[2];
			base.StartCoroutine(this.method_23());
		}
	}

	// Token: 0x06001BB6 RID: 7094 RVA: 0x0008AE44 File Offset: 0x00089044
	private IEnumerator method_23()
	{
		while (vmethod_19() == null || vmethod_41() <= 0 || m_relatedPlayer == null)
		{
			yield return null;
		}
		for (int i = 0; i < 10; i++)
		{
			yield return null;
		}
		int newHP = (int)((float)vmethod_41() * m_relatedPlayer.method_72());
		float hpModifier = (float)base.photonView.Object_0[3];
		if (hpModifier > 1f)
		{
			newHP = (int)((float)newHP * hpModifier);
		}
		vmethod_38(newHP);
		vmethod_37(vmethod_41());
	}
	// Token: 0x06001BB7 RID: 7095 RVA: 0x0008AE60 File Offset: 0x00089060
	public override void vmethod_49()
	{
		int num = (1 << LayerMask.NameToLayer("Walkable")) | (1 << LayerMask.NameToLayer("Default"));
		base.method_5(num);
	}

	// Token: 0x06001BB8 RID: 7096 RVA: 0x0008AE94 File Offset: 0x00089094
	public string method_24()
	{
		string text = null;
		if (this.m_relatedPlayer != null)
		{
			text = this.m_relatedPlayer.vmethod_4();
		}
		if (string.IsNullOrEmpty(text))
		{
			text = "Soldier";
		}
		return "[" + text + "]";
	}

	// Token: 0x06001BB9 RID: 7097 RVA: 0x0008AEDC File Offset: 0x000890DC
	public override float vmethod_54(EntityWeapon entityWeapon_0, int int_0)
	{
		float num = base.vmethod_54(entityWeapon_0, int_0);
		if (entityWeapon_0 != null && this.m_relatedPlayer != null)
		{
			num = (float)PlayerSkillManage.smethod_0(this.m_relatedPlayer.vmethod_3(), num);
			num *= this.m_relatedPlayer.method_129();
		}
		return num;
	}

	// Token: 0x04001268 RID: 4712
	public Transform m_SMGHolder;
}
