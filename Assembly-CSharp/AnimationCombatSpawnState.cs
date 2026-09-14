using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class AnimationCombatSpawnState : AnimationManagerState
{
	// Token: 0x060001A8 RID: 424 RVA: 0x0003D63C File Offset: 0x0003B83C
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			}
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", this.m_moveSpeed);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("FaceAngle", 0f);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsMoveBackward", false);
		}
		this.m_AnimationManagerFSM.m_validateNextMovePosition = false;
		this.m_spawnStep = ECombatSpawnStep.WalkBeforeSpawn;
		this.m_colliderTriggered = false;
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

	// Token: 0x060001A9 RID: 425 RVA: 0x0003D774 File Offset: 0x0003B974
	public override void vmethod_1()
	{
		if (this.m_spawnStep == ECombatSpawnStep.WalkBeforeSpawn)
		{
			if (base.method_3(this.m_AnimationManagerFSM.transform.position))
			{
				this.m_spawnStep = ECombatSpawnStep.WalkAfterSpawn;
				this.m_startTime = Time.time;
			}
		}
		else if (this.m_spawnStep == ECombatSpawnStep.WalkAfterSpawn && Time.time - this.m_startTime >= this.m_walkAfterSpawnTime)
		{
			base.m_status = AnimationStatus.SUCCESS;
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00003D26 File Offset: 0x00001F26
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.m_validateNextMovePosition = true;
		if (this.m_rigidbody != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_rigidbody);
		}
	}

	// Token: 0x04000198 RID: 408
	private const string SPAWN_TAG = "CombatSpawn";

	// Token: 0x04000199 RID: 409
	public ECombatSpawnStep m_spawnStep;

	// Token: 0x0400019A RID: 410
	public bool m_colliderTriggered;

	// Token: 0x0400019B RID: 411
	public float m_walkAfterSpawnTime = 0.5f;

	// Token: 0x0400019C RID: 412
	public float m_moveSpeed;

	// Token: 0x0400019D RID: 413
	private float m_startTime;

	// Token: 0x0400019E RID: 414
	private Rigidbody m_rigidbody;
}
