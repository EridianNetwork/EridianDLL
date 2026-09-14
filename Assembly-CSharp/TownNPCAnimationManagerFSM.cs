using System;
using ns0;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class TownNPCAnimationManagerFSM : MonoBehaviour
{
	// Token: 0x06000178 RID: 376 RVA: 0x0003C898 File Offset: 0x0003AA98
	public void Start()
	{
		this.m_animator = base.GetComponentInChildren<Animator>();
		this.m_animator.applyRootMotion = false;
		this.m_animator.updateMode = AnimatorUpdateMode.Normal;
		this.m_animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		for (int i = 0; i < this.m_animator.layerCount; i++)
		{
			this.m_animator.SetLayerWeight(i, 1f);
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x0003C8FC File Offset: 0x0003AAFC
	public void Update()
	{
		if (!this.m_greetPending && !this.m_missionFinishPending && this.m_extraIdleAnimCount > 0)
		{
			if (global::UnityEngine.Random.Range(0f, 1f) < this.m_extraIdlePlayChance)
			{
				this.m_animator.SetBool("bIdleExtra", true);
				int num = (int)(global::UnityEngine.Random.Range(0f, 0.9999f) * (float)this.m_extraIdleAnimCount);
				this.m_animator.SetInteger("iIdleIndex", num);
			}
			else
			{
				this.m_animator.SetBool("bIdleExtra", false);
			}
		}
		if (MonoSingleton<AppManager>.Instance.method_0() != null && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCDialogView>() != null && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCDialogView>().method_5())
		{
			this.m_animator.SetBool("bIdleExtra", false);
		}
		if (this.m_greetPending)
		{
			this.m_animator.SetBool("bGreet", true);
			this.m_greetPending = false;
		}
		else
		{
			this.m_animator.SetBool("bGreet", false);
		}
		if (this.m_missionFinishPending)
		{
			this.m_animator.SetBool("bMissionComplete", true);
			this.m_missionFinishPending = false;
		}
		else
		{
			this.m_animator.SetBool("bMissionComplete", false);
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00003C09 File Offset: 0x00001E09
	public bool method_0(TownNPCAnimationManagerFSM.TownNpcAnimationType townNpcAnimationType_0)
	{
		if (townNpcAnimationType_0 == TownNPCAnimationManagerFSM.TownNpcAnimationType.GREET)
		{
			this.m_greetPending = true;
			return true;
		}
		if (townNpcAnimationType_0 == TownNPCAnimationManagerFSM.TownNpcAnimationType.FINISH)
		{
			this.m_missionFinishPending = true;
			return true;
		}
		return false;
	}

	// Token: 0x0400015F RID: 351
	private bool m_missionFinishPending;

	// Token: 0x04000160 RID: 352
	private bool m_greetPending;

	// Token: 0x04000161 RID: 353
	private Animator m_animator;

	// Token: 0x04000162 RID: 354
	public int m_extraIdleAnimCount;

	// Token: 0x04000163 RID: 355
	public float m_extraIdlePlayChance;

	// Token: 0x0200003B RID: 59
	public enum TownNpcAnimationType
	{
		// Token: 0x04000165 RID: 357
		NONE,
		// Token: 0x04000166 RID: 358
		IDLE,
		// Token: 0x04000167 RID: 359
		GREET,
		// Token: 0x04000168 RID: 360
		FINISH
	}
}
