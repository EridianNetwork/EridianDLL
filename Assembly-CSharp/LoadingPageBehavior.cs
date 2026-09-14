using System;
using ns0;
using UnityEngine;

// Token: 0x02000765 RID: 1893
public class LoadingPageBehavior : MonoBehaviour
{
	// Token: 0x0600322C RID: 12844 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x0600322D RID: 12845 RVA: 0x00020B08 File Offset: 0x0001ED08
	private void Start()
	{
		this.m_startTime = Time.time;
		this.m_introAnimator = global::UnityEngine.Object.FindObjectOfType<Animator>();
	}

	// Token: 0x0600322E RID: 12846 RVA: 0x000E3104 File Offset: 0x000E1304
	private void Update()
	{
		AnimationInfo[] currentAnimationClipState = this.m_introAnimator.GetCurrentAnimationClipState(0);
		for (int i = 0; i < currentAnimationClipState.Length; i++)
		{
			AnimationClip clip = currentAnimationClipState[i].clip;
			if (clip != null)
			{
				this.m_duration = Mathf.Max(clip.length, this.m_duration);
			}
		}
		bool flag = Time.time - this.m_startTime > this.m_duration;
		if (!this.m_animIsDone && flag)
		{
			this.m_animIsDone = true;
			MonoSingleton<GameFlowManager>.Instance.OnLogoCutsceneFinished();
		}
	}

	// Token: 0x0400229B RID: 8859
	private bool m_animIsDone;

	// Token: 0x0400229C RID: 8860
	private Animator m_introAnimator;

	// Token: 0x0400229D RID: 8861
	private float m_duration = 1f;

	// Token: 0x0400229E RID: 8862
	private float m_startTime;
}
