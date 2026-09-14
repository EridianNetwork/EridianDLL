using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class SkagAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000153 RID: 339 RVA: 0x0003BDA8 File Offset: 0x00039FA8
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = false;
		this.m_deathLayer = 1;
		this.m_bCanMoveTurn = true;
		this.m_bReadyToSpitball = false;
		this.m_bDashAttack = false;
		this.m_bSpitAttack = false;
		this.m_bCrushAttack = false;
		this.m_animEventHandlerList.Add("SpitBall", new AnimationManagerFSM.OnAnimEventHandler(this.OnSpitBall));
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_animEventHandlerList.Add("OnDashAttack", new AnimationManagerFSM.OnAnimEventHandler(this.OnDashAttack));
		this.m_animEventHandlerList.Add("OnSpitAttack", new AnimationManagerFSM.OnAnimEventHandler(this.OnSpitAttack));
		this.m_animEventHandlerList.Add("OnCrushAttack", new AnimationManagerFSM.OnAnimEventHandler(this.OnCrushAttack));
		this.m_animEventHandlerList.Add("StartPoisonSpit", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartPoisonSpit));
		this.m_animEventHandlerList.Add("StopPoisonSpit", new AnimationManagerFSM.OnAnimEventHandler(this.OnStopPoisonSpit));
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00003A76 File Offset: 0x00001C76
	public void OnSpitBall()
	{
		this.m_bReadyToSpitball = true;
	}

	// Token: 0x06000155 RID: 341 RVA: 0x00003A7F File Offset: 0x00001C7F
	public void OnDashAttack()
	{
		this.m_bDashAttack = true;
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00003A88 File Offset: 0x00001C88
	public void OnSpitAttack()
	{
		this.m_bSpitAttack = true;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00003A91 File Offset: 0x00001C91
	public void OnCrushAttack()
	{
		this.m_bCrushAttack = true;
		AIServiceUtility.AIServiceUtility_0.method_6();
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_10(ENPCParticleType.E_RadiusAttack, base.transform.position, true);
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00003ACB File Offset: 0x00001CCB
	public void OnStartPoisonSpit()
	{
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_5(ENPCParticleType.E_PoisonSpit, null, this.m_skeleton.method_7(), this.m_vZero, this.m_identityRot, -1f, true);
		}
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00003B07 File Offset: 0x00001D07
	public void OnStopPoisonSpit()
	{
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_13(ENPCParticleType.E_PoisonSpit);
		}
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0003BEBC File Offset: 0x0003A0BC
	public override GameObject vmethod_9()
	{
		if (!this.m_bReadyToSpitball)
		{
			return null;
		}
		base.method_18(ENPCParticleType.E_DamageSpitAtMouth, this.m_skeleton.method_7());
		GameObject gameObject = global::UnityEngine.Object.Instantiate(base.GetComponent<EntityNpc>().m_spawnObjPrefab, this.m_skeleton.method_7().position + base.gameObject.transform.forward * 0.3f, Quaternion.identity) as GameObject;
		if (gameObject != null)
		{
			this.m_bReadyToSpitball = false;
		}
		return gameObject;
	}

	// Token: 0x04000148 RID: 328
	[HideInInspector]
	public bool m_bReadyToSpitball;

	// Token: 0x04000149 RID: 329
	[HideInInspector]
	public bool m_bDashAttack;

	// Token: 0x0400014A RID: 330
	[HideInInspector]
	public bool m_bSpitAttack;

	// Token: 0x0400014B RID: 331
	[HideInInspector]
	public bool m_bCrushAttack;
}
