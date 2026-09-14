using System;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class EntityClassMode : EntityObject
{
	// Token: 0x17000169 RID: 361
	// (get) Token: 0x06001B56 RID: 6998 RVA: 0x00013BB0 File Offset: 0x00011DB0
	// (set) Token: 0x06001B57 RID: 6999 RVA: 0x00013BB8 File Offset: 0x00011DB8
	public ClassModeAttribute m_attribute { get; private set; }

	// Token: 0x06001B58 RID: 7000 RVA: 0x00013BC1 File Offset: 0x00011DC1
	protected override void Awake()
	{
		base.Awake();
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x00089C80 File Offset: 0x00087E80
	public override void Start()
	{
		base.Start();
		if (this.m_dna == null)
		{
			ItemDNA itemDNA = this.vmethod_7()[0] as ItemDNA;
			if (itemDNA != null)
			{
				this.m_dna = itemDNA.method_8();
				this.m_attribute = this.m_dna.m_attribute;
				SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
				if (this.m_dna.m_material >= 0 && componentInChildren != null && this.m_dna.m_material < componentInChildren.materials.Length)
				{
					componentInChildren.material = componentInChildren.materials[this.m_dna.m_material];
				}
			}
		}
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x00013BC9 File Offset: 0x00011DC9
	public void method_16(ClassModeDNA classModeDNA_0)
	{
		this.m_dna = classModeDNA_0;
		this.m_attribute = this.m_dna.m_attribute;
	}

	// Token: 0x06001B5B RID: 7003 RVA: 0x00013BE3 File Offset: 0x00011DE3
	public ClassModeDNA method_17()
	{
		return this.m_dna;
	}

	// Token: 0x06001B5C RID: 7004 RVA: 0x00013BEB File Offset: 0x00011DEB
	public override void vmethod_63(Entity entity_0)
	{
		base.method_15(entity_0);
	}

	// Token: 0x06001B5D RID: 7005 RVA: 0x00089D1C File Offset: 0x00087F1C
	public void method_18(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return;
		}
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton == null)
		{
			return;
		}
		if (this.m_dna == null)
		{
			return;
		}
		Transform transform = skeleton.method_6(this.m_dna.m_cmType);
		if (transform == null)
		{
			return;
		}
		base.transform.parent = transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		Collider component = base.GetComponent<Collider>();
		if (component != null)
		{
			component.enabled = false;
		}
		Rigidbody component2 = base.GetComponent<Rigidbody>();
		if (component2 != null)
		{
			global::UnityEngine.Object.Destroy(component2);
		}
		base.gameObject.SetActive(true);
		this.vmethod_65();
	}

	// Token: 0x040011F2 RID: 4594
	public ClassModeDNA m_dna;
}
