using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class WidowmakerAnimationManagerFSM : SpiderantAnimationManagerFSM
{
	// Token: 0x0600017C RID: 380 RVA: 0x0003CA38 File Offset: 0x0003AC38
	public override void Start()
	{
		base.Start();
		m_deathLayer = 1;
		m_bCanMoveTurn = true;
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			Transform transform = componentsInChildren[i];
			if (transform.gameObject.name == "Bip01 Tail4")
			{
				m_tailTransform = transform;
				break;
			}
		}
		m_animEventHandlerList.Add("RadiusAttackHit", OnRadiusAttackHit);
		m_animEventHandlerList.Add("ThrowWebTrap", OnThrowWebTrap);
	}
	// Token: 0x0600017D RID: 381 RVA: 0x0003C390 File Offset: 0x0003A590
	public void OnRadiusAttackHit()
	{
		AnimationRadiusAttackState animationRadiusAttackState = base.method_16(Utils.smethod_23(AnimationStateFSM.RadiusAttack)) as AnimationRadiusAttackState;
		if (animationRadiusAttackState != null)
		{
			animationRadiusAttackState.m_radiusAttackHit = true;
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0003CAD8 File Offset: 0x0003ACD8
	public void OnThrowWebTrap()
	{
		AnimationWebTrapState animationWebTrapState = base.method_16(Utils.smethod_23(AnimationStateFSM.WebTrap)) as AnimationWebTrapState;
		if (animationWebTrapState != null)
		{
			animationWebTrapState.m_bThrowWebTrap = true;
		}
	}

	// Token: 0x04000169 RID: 361
	public Transform m_tailTransform;
}
