using System;
using Core;
using UnityEngine;

// Token: 0x02000053 RID: 83
public class AnimationDieState : AnimationManagerState
{
	// Token: 0x060001D9 RID: 473 RVA: 0x00003F32 File Offset: 0x00002132
	public AnimationDieState()
	{
		this.StateName = "Die";
		this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.None;
		this.m_fDieExitTime = 2f;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0003E030 File Offset: 0x0003C230
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		this.m_AnimationManagerFSM.vmethod_2();
		this.m_AnimationManagerFSM.m_validateNextMovePosition = false;
		this.m_AnimationManagerFSM.Boolean_1 = false;
		this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.EPlayDeathAnimation;
		this.m_deathAnimationStarted = false;
		base.m_status = AnimationStatus.RUNNING;
		if (this.m_AnimationManagerFSM.m_upperBodyStateMachine != null)
		{
			this.m_AnimationManagerFSM.m_upperBodyStateMachine.method_1("Empty");
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0003E0A8 File Offset: 0x0003C2A8
	public override void vmethod_1()
	{
		if (this.m_eHandleRagdollStep == AnimationDieState.EHandleRagdollStep.EPlayDeathAnimation)
		{
			bool flag = false;
			EntityNpc entityNpc = this.m_AnimationManagerFSM.m_entity as EntityNpc;
			if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx)
			{
				flag = this.m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
			}
			else
			{
				AnimationJumpAttackState animationJumpAttackState = this.m_AnimationManagerFSM.m_animationStateMachine.m_preState as AnimationJumpAttackState;
				if (this.m_force < 35f && animationJumpAttackState == null)
				{
					flag = this.m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
				}
				if (this.m_AnimationManagerFSM.m_rigidbodyTransforms.Count <= 0)
				{
					flag = this.m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
				}
			}
			if (flag)
			{
				if (this.m_deathAnimationStarted)
				{
					if (this.m_AnimationManagerFSM.method_9(this.m_AnimationManagerFSM.Animator_0, this.m_AnimationManagerFSM.m_deathLayer, "Death", 0.9f) == AnimationStatus.SUCCESS)
					{
						this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.EStart;
					}
				}
				else
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsDying", true);
					bool flag2 = this.m_AnimationManagerFSM.m_setup.m_settings.m_headShotDeathAnimCount > 0 && this.m_AnimationManagerFSM.m_damageType == DamageType.Death_Head;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bHeadShot", flag2);
					this.m_AnimationManagerFSM.Animator_0.SetInteger("iDeathAnimIndex", this.m_AnimationManagerFSM.m_iDeathAnimIndex);
					this.m_AnimationManagerFSM.method_7(1f);
					if (this.m_AnimationManagerFSM.m_deathLayer >= this.m_AnimationManagerFSM.Animator_0.layerCount)
					{
						DebugUtils.LogError(LogCategory.AI, string.Concat(new object[]
						{
							"invalid death Layer ",
							this.m_AnimationManagerFSM.m_deathLayer,
							this.m_AnimationManagerFSM.gameObject.name,
							this.m_AnimationManagerFSM.Animator_0.layerCount
						}));
					}
					if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(this.m_AnimationManagerFSM.m_deathLayer).IsTag("Death"))
					{
						this.m_deathAnimationStarted = true;
					}
				}
			}
			else
			{
				this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.EStart;
			}
		}
		if (this.m_eHandleRagdollStep == AnimationDieState.EHandleRagdollStep.EStart)
		{
			this.m_AnimationManagerFSM.OnDeath();
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Save_Position);
			this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.EReadyToComputeVelocity;
			BaseEventTriggerCtl audioCtl = this.m_AnimationManagerFSM.m_AudioCtl;
			if (audioCtl && !this.m_deathAnimationStarted)
			{
				audioCtl.vmethod_1(AudioEventName.Enemy_NormalDeath);
			}
		}
		if (this.m_eHandleRagdollStep == AnimationDieState.EHandleRagdollStep.EReadyToComputeVelocity)
		{
			this.m_AnimationManagerFSM.method_5(false);
			if (this.m_AnimationManagerFSM.Transform_0 != null)
			{
				SkinnedMeshRenderer component = this.m_AnimationManagerFSM.Transform_0.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					component.updateWhenOffscreen = true;
				}
			}
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Enable);
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Compute_Velocity);
			this.method_4();
			Utils.smethod_4(this.m_AnimationManagerFSM.transform, LayerMask.NameToLayer("Ragdoll"), true);
			this.m_eHandleRagdollStep = AnimationDieState.EHandleRagdollStep.EWaitRagdollFallDown;
		}
		if (this.m_eHandleRagdollStep == AnimationDieState.EHandleRagdollStep.EWaitRagdollFallDown)
		{
			if (this.m_fDieExitTime <= 0f)
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
			else
			{
				this.m_fDieExitTime -= Time.deltaTime;
			}
		}
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00003ED0 File Offset: 0x000020D0
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0003E3EC File Offset: 0x0003C5EC
	public void method_4()
	{
		if (this.m_AnimationManagerFSM == null || this.m_AnimationManagerFSM.m_rigidbodyTransforms == null || this.m_AnimationManagerFSM.m_rigidbodyTransforms.Count <= 0)
		{
			return;
		}
		if (this.m_force < 35f)
		{
			return;
		}
		Vector3 position = this.m_AnimationManagerFSM.transform.position;
		Vector3 position2 = this.m_AnimationManagerFSM.m_rigidbodyTransforms[0].position;
		Vector3 normalized = (position - this.m_explosionOrigin).normalized;
		Vector3 vector = Vector3.Cross(normalized, normalized + Vector3.up).normalized;
		if (global::UnityEngine.Random.Range(-1f, 1f) < 0f)
		{
			vector *= -1f;
		}
		float num = global::UnityEngine.Random.Range(0.1f, 2f);
		int count = this.m_AnimationManagerFSM.m_rigidbodyTransforms.Count;
		for (int i = 0; i < count; i++)
		{
			Transform transform = this.m_AnimationManagerFSM.m_rigidbodyTransforms[i];
			if (transform.rigidbody != null)
			{
				if (this.m_force > 95f)
				{
					transform.rigidbody.AddExplosionForce(240f, this.m_explosionOrigin, 20f, num);
				}
				else if (this.m_force > 75f)
				{
					transform.rigidbody.AddExplosionForce(220f, this.m_explosionOrigin, 20f, num);
				}
				else if (this.m_force > 55f)
				{
					transform.rigidbody.AddExplosionForce(200f, this.m_explosionOrigin, 15f, num);
				}
				else if (this.m_force > 35f)
				{
					transform.rigidbody.AddForceAtPosition((position2 - this.m_explosionOrigin).normalized * 200f, position2 + vector);
				}
			}
		}
	}

	// Token: 0x040001B5 RID: 437
	private const string DEATH_TAG = "Death";

	// Token: 0x040001B6 RID: 438
	private const string ZILLA_DEATH_TAG = "DieState";

	// Token: 0x040001B7 RID: 439
	private AnimationDieState.EHandleRagdollStep m_eHandleRagdollStep;

	// Token: 0x040001B8 RID: 440
	private bool m_deathAnimationStarted;

	// Token: 0x040001B9 RID: 441
	private float m_fDieExitTime;

	// Token: 0x040001BA RID: 442
	public Vector3 m_explosionOrigin;

	// Token: 0x040001BB RID: 443
	public float m_force;

	// Token: 0x02000054 RID: 84
	private enum EHandleRagdollStep
	{
		// Token: 0x040001BD RID: 445
		None,
		// Token: 0x040001BE RID: 446
		EStart,
		// Token: 0x040001BF RID: 447
		EReadyToComputeVelocity,
		// Token: 0x040001C0 RID: 448
		EReadyToSetRigidbody,
		// Token: 0x040001C1 RID: 449
		EPlayDeathAnimation,
		// Token: 0x040001C2 RID: 450
		EWaitRagdollFallDown
	}
}
