using System;
using UnityEngine;

// Token: 0x02000B3E RID: 2878
[AddComponentMenu("Effects/TKC/Animation Effect")]
public class AnimationEffect : ClonableEffectBase
{
	// Token: 0x06004E76 RID: 20086 RVA: 0x0014C5D0 File Offset: 0x0014A7D0
	public override void vmethod_1(EffectTrigger effectTrigger_0)
	{
		if (this.m_animation != null)
		{
			Animation animation = (Animation)global::UnityEngine.Object.Instantiate(this.m_animation);
			this.m_clone = animation.gameObject;
			if (this.m_isAdditive)
			{
				AnimationState animationState = animation[this.m_animationToPlay];
				animationState.wrapMode = WrapMode.Once;
				animationState.blendMode = AnimationBlendMode.Additive;
			}
			animation.Play(this.m_animationToPlay);
		}
	}

	// Token: 0x06004E77 RID: 20087 RVA: 0x0014C638 File Offset: 0x0014A838
	public override void vmethod_2()
	{
		if (this.m_animation != null && (this.m_restartWhenPlay || !this.m_animation.isPlaying))
		{
			if (this.m_isAdditive)
			{
				AnimationState animationState = this.m_animation[this.m_animationToPlay];
				animationState.wrapMode = WrapMode.Once;
				animationState.blendMode = AnimationBlendMode.Additive;
			}
			this.m_animation.Play(this.m_animationToPlay);
		}
	}

	// Token: 0x06004E78 RID: 20088 RVA: 0x00033146 File Offset: 0x00031346
	public override GameObject vmethod_0()
	{
		if (this.m_animation == null)
		{
			return null;
		}
		return this.m_animation.gameObject;
	}

	// Token: 0x04003A92 RID: 14994
	public Animation m_animation;

	// Token: 0x04003A93 RID: 14995
	public string m_animationToPlay = string.Empty;

	// Token: 0x04003A94 RID: 14996
	public bool m_restartWhenPlay = true;

	// Token: 0x04003A95 RID: 14997
	public bool m_isAdditive;
}
