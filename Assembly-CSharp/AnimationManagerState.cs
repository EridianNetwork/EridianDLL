using System;
using ns0;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class AnimationManagerState : AnimationStateBase
{
	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600022B RID: 555 RVA: 0x0000427C File Offset: 0x0000247C
	// (set) Token: 0x0600022C RID: 556 RVA: 0x00004284 File Offset: 0x00002484
	public AnimationStatus m_status { get; protected set; }

	// Token: 0x0600022D RID: 557 RVA: 0x0000428D File Offset: 0x0000248D
	public virtual void vmethod_3(AnimationManagerFSM animationManagerFSM_0)
	{
		this.StateMachine = animationManagerFSM_0.m_animationStateMachine;
		this.m_AnimationManagerFSM = animationManagerFSM_0;
		this.m_status = AnimationStatus.INVALID;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0003FA70 File Offset: 0x0003DC70
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		this.m_status = AnimationStatus.RUNNING;
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", false);
		}
		if (!this.m_VFXManager)
		{
			this.m_VFXManager = this.m_AnimationManagerFSM.m_VFXManager;
		}
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_1()
	{
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void FixedUpdate()
	{
	}

	// Token: 0x06000231 RID: 561 RVA: 0x000042A9 File Offset: 0x000024A9
	public override void vmethod_2()
	{
		this.m_status = AnimationStatus.SUCCESS;
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x000042DA File Offset: 0x000024DA
	public bool method_1(AnimatorStateInfo animatorStateInfo_0, float float_2, float float_3)
	{
		return animatorStateInfo_0.normalizedTime >= Mathf.Floor(float_2) + float_3;
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0003FAD8 File Offset: 0x0003DCD8
	public bool method_2(AnimatorStateInfo animatorStateInfo_0, string string_1, float float_2)
	{
		if (!animatorStateInfo_0.IsTag(string_1))
		{
			return false;
		}
		float num = animatorStateInfo_0.normalizedTime - (float)Mathf.FloorToInt(animatorStateInfo_0.normalizedTime);
		return num > float_2;
	}

	// Token: 0x06000234 RID: 564 RVA: 0x0003FB10 File Offset: 0x0003DD10
	public bool method_3(Vector3 vector3_0)
	{
		NavMeshHit navMeshHit;
		if (NavMesh.SamplePosition(vector3_0, out navMeshHit, 0.5f, 2147483647))
		{
			Vector3 vector = vector3_0 - navMeshHit.position;
			vector.y = 0f;
			if (vector.sqrMagnitude < 0.01f)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000202 RID: 514
	public AnimationManagerFSM m_AnimationManagerFSM;

	// Token: 0x04000203 RID: 515
	public VFXManager m_VFXManager;

	// Token: 0x04000204 RID: 516
	public Vector3 m_destinationFacing = Vector3.zero;

	// Token: 0x04000205 RID: 517
	public float m_destinationDistanceFactor;

	// Token: 0x04000206 RID: 518
	public Vector3 m_destinationPosition = Vector3.zero;

	// Token: 0x04000207 RID: 519
	public float m_turnAngle;
}
