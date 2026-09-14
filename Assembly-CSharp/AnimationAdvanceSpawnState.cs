using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class AnimationAdvanceSpawnState : AnimationManagerState
{
	// Token: 0x0600018B RID: 395 RVA: 0x0003CB04 File Offset: 0x0003AD04
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", true);
			}
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 1f);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("FaceAngle", 0f);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsMoveBackward", false);
		}
		this.m_spawnAnimationStarted = false;
		this.m_AnimationManagerFSM.m_validateNextMovePosition = false;
		base.m_status = AnimationStatus.RUNNING;
		this.m_spawnStep = AnimationAdvanceSpawnState.EAdvanceSpawnStep.WalkForward;
		this.m_colliderTriggered = false;
		this.m_walkOnNavMeshDuration = 0.3f;
		this.m_checkTriggerTime = 0f;
		if (this.m_AnimationManagerFSM.m_isHumanoid)
		{
			CollisionManager component = this.m_AnimationManagerFSM.gameObject.GetComponent<CollisionManager>();
			if (component != null)
			{
				Collider collider = component.method_13();
				if (collider != null)
				{
					this.m_rigidbody = collider.gameObject.AddComponent<Rigidbody>();
					if (this.m_rigidbody != null)
					{
						this.m_rigidbody.useGravity = false;
						this.m_rigidbody.isKinematic = true;
					}
				}
			}
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0003CC5C File Offset: 0x0003AE5C
	public override void vmethod_1()
	{
		if (base.m_status == AnimationStatus.SUCCESS)
		{
			return;
		}
		if (this.m_spawnStep == AnimationAdvanceSpawnState.EAdvanceSpawnStep.WalkForward)
		{
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_checkTriggerTime += Time.deltaTime;
				if (this.m_colliderTriggered || this.m_checkTriggerTime > 2.5f)
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsLiftCurtain", true);
					this.m_spawnStep = AnimationAdvanceSpawnState.EAdvanceSpawnStep.LiftCurtain;
				}
			}
			else if (base.method_3(this.m_AnimationManagerFSM.transform.position))
			{
				this.m_walkOnNavMeshDuration -= Time.deltaTime;
				if (this.m_walkOnNavMeshDuration <= 0f)
				{
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
		}
		else if (this.m_spawnStep == AnimationAdvanceSpawnState.EAdvanceSpawnStep.LiftCurtain)
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (this.m_spawnAnimationStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("AdvacneSpawn"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsLiftCurtain", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("AdvacneSpawn"))
			{
				this.m_spawnAnimationStarted = true;
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsLiftCurtain", false);
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0003CDD8 File Offset: 0x0003AFD8
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.m_isHumanoid)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsLiftCurtain", false);
		}
		this.m_AnimationManagerFSM.m_validateNextMovePosition = true;
		base.m_status = AnimationStatus.SUCCESS;
		if (this.m_rigidbody != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_rigidbody);
		}
	}

	// Token: 0x0400016A RID: 362
	private const string SPAWN_TAG = "AdvacneSpawn";

	// Token: 0x0400016B RID: 363
	private float m_walkOnNavMeshDuration;

	// Token: 0x0400016C RID: 364
	private bool m_spawnAnimationStarted;

	// Token: 0x0400016D RID: 365
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400016E RID: 366
	private float m_startTime;

	// Token: 0x0400016F RID: 367
	public AnimationAdvanceSpawnState.EAdvanceSpawnStep m_spawnStep;

	// Token: 0x04000170 RID: 368
	public bool m_colliderTriggered;

	// Token: 0x04000171 RID: 369
	private float m_checkTriggerTime;

	// Token: 0x04000172 RID: 370
	private Rigidbody m_rigidbody;

	// Token: 0x0200003F RID: 63
	public enum EAdvanceSpawnStep
	{
		// Token: 0x04000174 RID: 372
		Disabled,
		// Token: 0x04000175 RID: 373
		WalkForward,
		// Token: 0x04000176 RID: 374
		LiftCurtain
	}
}
