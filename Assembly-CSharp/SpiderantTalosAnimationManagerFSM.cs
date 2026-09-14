using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class SpiderantTalosAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000167 RID: 359 RVA: 0x0003C210 File Offset: 0x0003A410
	public override void Start()
	{
		base.Start();
		this.m_deathLayer = 1;
		this.m_entityTalos = base.GetComponent<EntityNpcSpiderantTalos>();
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_animEventHandlerList.Add("RadiusAttackHit", new AnimationManagerFSM.OnAnimEventHandler(this.OnRadiusAttackHit));
		this.method_32();
		this.m_bCanMoveTurn = true;
		SkinnedMeshRenderer componentInChildren = base.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.bounds.center.Set(0f, 0f, 0f);
		}
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0003C2B0 File Offset: 0x0003A4B0
	public override void vmethod_13(WeakPoint.PartInfo partInfo_0)
	{
		if (partInfo_0 == WeakPoint.PartInfo.Armor_Left)
		{
			base.method_24(this.m_entityTalos.m_armorLeft, false);
			this.method_31(this.m_entityTalos.m_armorLeft);
		}
		else if (partInfo_0 == WeakPoint.PartInfo.Armor_Right)
		{
			base.method_24(this.m_entityTalos.m_armorRight, false);
			this.method_31(this.m_entityTalos.m_armorRight);
		}
		else if (partInfo_0 == WeakPoint.PartInfo.Armor_Back)
		{
			base.method_24(this.m_entityTalos.m_armorBack, false);
			this.method_31(this.m_entityTalos.m_armorBack);
		}
	}

	// Token: 0x06000169 RID: 361 RVA: 0x0003C338 File Offset: 0x0003A538
	public void method_31(Transform transform_0)
	{
		if (this.m_VFXManager == null)
		{
			this.m_VFXManager = this.m_animationHost.GetComponent<VFXManager>();
		}
		WeakPoint componentInChildren = transform_0.gameObject.GetComponentInChildren<WeakPoint>();
		if (componentInChildren != null)
		{
			this.m_VFXManager.method_7(ENPCParticleType.E_IceBroken, componentInChildren.transform, true);
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00003B6B File Offset: 0x00001D6B
	public void method_32()
	{
		base.method_24(this.m_entityTalos.m_armorLeft, true);
		base.method_24(this.m_entityTalos.m_armorRight, true);
		base.method_24(this.m_entityTalos.m_armorBack, true);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0003C390 File Offset: 0x0003A590
	public void OnRadiusAttackHit()
	{
		AnimationRadiusAttackState animationRadiusAttackState = base.method_16(Utils.smethod_23(AnimationStateFSM.RadiusAttack)) as AnimationRadiusAttackState;
		if (animationRadiusAttackState != null)
		{
			animationRadiusAttackState.m_radiusAttackHit = true;
		}
	}

	// Token: 0x0400014F RID: 335
	private EntityNpcSpiderantTalos m_entityTalos;
}
