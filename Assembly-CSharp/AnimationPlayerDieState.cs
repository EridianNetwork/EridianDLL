using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class AnimationPlayerDieState : PlayerAnimationState
{
	// Token: 0x060003F7 RID: 1015 RVA: 0x00005895 File Offset: 0x00003A95
	public AnimationPlayerDieState()
	{
		this.StateName = "PlayerDie";
		this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.None;
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x000493A8 File Offset: 0x000475A8
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		this.m_AnimationManagerFSM.m_validateNextMovePosition = false;
		this.m_AnimationManagerFSM.Boolean_1 = false;
		this.m_AnimationManagerFSM.method_3(false);
		this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EPlayDeathAnimation;
		this.m_deathAnimationStarted = false;
		base.m_status = AnimationStatus.RUNNING;
		if (this.m_AnimationManagerFSM.m_upperBodyStateMachine != null)
		{
			this.m_AnimationManagerFSM.m_upperBodyStateMachine.method_1("Empty");
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x00049424 File Offset: 0x00047624
	public override void vmethod_1()
	{
		if (this.m_eHandleRagdollStep == AnimationPlayerDieState.EHandleRagdollStep.EPlayDeathAnimation)
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(this.m_deathLayerIndex);
			if (this.m_force < 35f)
			{
				if (this.m_deathAnimationStarted)
				{
					if (!this.m_animatorInfo.IsTag("Death") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f))
					{
						this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EStart;
					}
				}
				else
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("bIsDying", true);
					bool flag = this.m_AnimationManagerFSM.m_setup.m_settings.m_headShotDeathAnimCount > 0 && this.m_isHeadShot;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bHeadShot", flag);
					this.m_AnimationManagerFSM.Animator_0.SetInteger("iDeathAnimIndex", this.m_deathAnimIndex);
					if (this.m_animatorInfo.IsTag("Death"))
					{
						this.m_startTime = this.m_animatorInfo.normalizedTime;
						this.m_deathAnimationStarted = true;
						this.m_AnimationManagerFSM.Animator_0.SetBool("bIsDying", false);
					}
				}
			}
			else
			{
				this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EStart;
			}
		}
		if (this.m_eHandleRagdollStep == AnimationPlayerDieState.EHandleRagdollStep.EStart)
		{
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Save_Position);
			this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EReadyToComputeVelocity;
		}
		if (this.m_eHandleRagdollStep == AnimationPlayerDieState.EHandleRagdollStep.EReadyToComputeVelocity)
		{
			this.m_AnimationManagerFSM.Animator_0.enabled = false;
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Enable);
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.SetRagdollLayer);
			this.m_AnimationManagerFSM.method_2(RagdollOperationType.Compute_Velocity);
			this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EReadyToSetRigidbody;
		}
		if (this.m_eHandleRagdollStep == AnimationPlayerDieState.EHandleRagdollStep.EReadyToSetRigidbody)
		{
			this.method_22();
			this.m_eHandleRagdollStep = AnimationPlayerDieState.EHandleRagdollStep.EWaitRagdollFallDown;
		}
		if (this.m_eHandleRagdollStep == AnimationPlayerDieState.EHandleRagdollStep.EWaitRagdollFallDown)
		{
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x000495E0 File Offset: 0x000477E0
	public override void vmethod_2()
	{
		this.m_AnimationManagerFSM.vmethod_5();
		this.m_AnimationManagerFSM.method_2(RagdollOperationType.Disable);
		this.m_AnimationManagerFSM.method_2(RagdollOperationType.SetDefaultLayer);
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.enabled = true;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIsDying", false);
		}
		this.m_AnimationManagerFSM.method_3(true);
		base.vmethod_2();
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0004965C File Offset: 0x0004785C
	public void method_22()
	{
		if (this.m_force < 35f)
		{
			return;
		}
		Vector3 position = this.m_AnimationManagerFSM.transform.position;
		Skeleton skeleton = this.m_AnimationManagerFSM.m_entity.vmethod_17();
		Vector3 position2 = skeleton.method_7().position;
		Vector3 normalized = (position - this.m_explosionOrigin).normalized;
		if ((position - this.m_explosionOrigin).magnitude > 3f)
		{
			this.m_explosionOrigin = position - normalized * 3f;
		}
		float num = global::UnityEngine.Random.Range(0.1f, 2f);
		Vector3 vector = Vector3.Cross(normalized, normalized + Vector3.up).normalized;
		if (global::UnityEngine.Random.Range(-1f, 1f) < 0f)
		{
			vector *= -1f;
		}
		foreach (Transform transform in this.m_AnimationManagerFSM.m_rigidbodyTransforms)
		{
			if (transform.rigidbody != null)
			{
				if (this.m_force > 95f)
				{
					transform.rigidbody.AddExplosionForce(700f, this.m_explosionOrigin, 20f, num);
				}
				else if (this.m_force > 75f)
				{
					transform.rigidbody.AddExplosionForce(600f, this.m_explosionOrigin, 20f, num);
				}
				else if (this.m_force > 55f)
				{
					transform.rigidbody.AddExplosionForce(500f, this.m_explosionOrigin, 20f, num);
				}
				else if (this.m_force > 35f)
				{
					transform.rigidbody.AddForceAtPosition((position2 - this.m_explosionOrigin).normalized * 200f, position2 + vector);
				}
			}
		}
	}

	// Token: 0x040003D0 RID: 976
	private const string DEATH_TAG = "Death";

	// Token: 0x040003D1 RID: 977
	private AnimationPlayerDieState.EHandleRagdollStep m_eHandleRagdollStep;

	// Token: 0x040003D2 RID: 978
	private bool m_deathAnimationStarted;

	// Token: 0x040003D3 RID: 979
	public Vector3 m_explosionOrigin;

	// Token: 0x040003D4 RID: 980
	public float m_force;

	// Token: 0x040003D5 RID: 981
	public int m_deathAnimIndex;

	// Token: 0x040003D6 RID: 982
	private int m_deathLayerIndex = 2;

	// Token: 0x040003D7 RID: 983
	private float m_startTime;

	// Token: 0x040003D8 RID: 984
	public bool m_isHeadShot;

	// Token: 0x020000A8 RID: 168
	private enum EHandleRagdollStep
	{
		// Token: 0x040003DA RID: 986
		None,
		// Token: 0x040003DB RID: 987
		EStart,
		// Token: 0x040003DC RID: 988
		EReadyToComputeVelocity,
		// Token: 0x040003DD RID: 989
		EReadyToSetRigidbody,
		// Token: 0x040003DE RID: 990
		EPlayDeathAnimation,
		// Token: 0x040003DF RID: 991
		EWaitRagdollFallDown
	}
}
