using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class AIInventory : MonoBehaviour, IPrefabManagerXmlSetup
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x000030F6 File Offset: 0x000012F6
	// (set) Token: 0x06000003 RID: 3 RVA: 0x000030FE File Offset: 0x000012FE
	public EntityWeapon m_weapon { get; private set; }

	// Token: 0x06000004 RID: 4 RVA: 0x000342A4 File Offset: 0x000324A4
	public bool imethod_0(XmlNode xmlNode_0)
	{
		if (xmlNode_0 == null)
		{
			return false;
		}
		XmlAttribute xmlAttribute = xmlNode_0.Attributes["IgnoreWeaponID"];
		if (xmlAttribute != null && !bool.TryParse(xmlAttribute.Value, out this.m_bIgnoreWeaponID))
		{
			return false;
		}
		this.m_weaponID[0] = -1;
		if (!this.m_bIgnoreWeaponID)
		{
			XmlAttribute xmlAttribute2 = xmlNode_0.Attributes["m_weaponID"];
			if (xmlAttribute2 != null && !int.TryParse(xmlAttribute2.Value, out this.m_weaponID[0]))
			{
				return false;
			}
		}
		this.m_shieldID = -1;
		XmlAttribute xmlAttribute3 = xmlNode_0.Attributes["m_shieldID"];
		return xmlAttribute3 == null || int.TryParse(xmlAttribute3.Value, out this.m_shieldID);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00003107 File Offset: 0x00001307
	public virtual void Start()
	{
		this.m_entity = base.GetComponent<EntityNpc>();
		this.method_1();
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00034350 File Offset: 0x00032550
	private void Update()
	{
		if (this.m_weapon == null)
		{
			this.m_weapon = this.m_entity.vmethod_19().vmethod_27();
		}
		if (this.m_weapon != null && !this.m_weapon.m_isReady)
		{
			this.m_weapon.method_49();
		}
		if (this.m_animationManager != null)
		{
			if (!this.m_isWeaponSetupComplete && this.m_weapon && this.m_weapon.m_isReady && this.m_animationManager != null)
			{
				this.m_weapon.method_54(this.m_entity);
				this.m_weapon.vmethod_63(this.m_entity);
				this.m_isWeaponSetupComplete = true;
				return;
			}
		}
		else
		{
			this.m_animationManager = base.GetComponent<AnimationManagerFSM>();
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0003441C File Offset: 0x0003261C
	private int method_0()
	{
		if (this.m_weaponID != null && this.m_weaponID.Length > 0)
		{
			int num = global::UnityEngine.Random.Range(0, this.m_weaponID.Length);
			return this.m_weaponID[num];
		}
		return -1;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1()
	{
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(int int_0)
	{
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000311D File Offset: 0x0000131D
	public bool method_3()
	{
		return false;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_4()
	{
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00034458 File Offset: 0x00032658
	public Vector3 method_5()
	{
		if (this.m_weapon != null)
		{
			return this.m_weapon.transform.position + Vector3.up * 0.15f;
		}
		if (base.gameObject)
		{
			return base.gameObject.transform.position;
		}
		return Vector3.zero;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00003120 File Offset: 0x00001320
	public void method_6()
	{
		if (this.m_weapon)
		{
			this.m_weapon.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00003140 File Offset: 0x00001340
	public void method_7()
	{
		if (this.m_weapon == null)
		{
			return;
		}
		NetworkManager.smethod_12(this.m_weapon);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000315C File Offset: 0x0000135C
	public bool method_8()
	{
		return !(this.m_weapon == null) && this.m_weapon.method_23();
	}

	// Token: 0x04000001 RID: 1
	public int[] m_weaponID = new int[] { -1 };

	// Token: 0x04000002 RID: 2
	public int m_shieldID = -1;

	// Token: 0x04000003 RID: 3
	public int m_test = -1;

	// Token: 0x04000004 RID: 4
	public bool m_bIgnoreWeaponID;

	// Token: 0x04000005 RID: 5
	private AnimationManagerFSM m_animationManager;

	// Token: 0x04000006 RID: 6
	private bool m_isWeaponSetupComplete;

	// Token: 0x04000007 RID: 7
	private EntityNpc m_entity;
}
