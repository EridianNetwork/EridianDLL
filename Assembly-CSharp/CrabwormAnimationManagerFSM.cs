using System;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class CrabwormAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000FF RID: 255 RVA: 0x0003A6AC File Offset: 0x000388AC
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_deathLayer = 1;
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		SkinnedMeshRenderer componentInChildren = base.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.updateWhenOffscreen = true;
		}
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000038D0 File Offset: 0x00001AD0
	public void method_31(bool bool_0)
	{
		if (this.m_dustPS == null)
		{
			return;
		}
		if (bool_0)
		{
			this.m_dustPS.Play();
		}
		else
		{
			this.m_dustPS.Stop();
		}
	}

	// Token: 0x06000101 RID: 257 RVA: 0x000038FC File Offset: 0x00001AFC
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.method_31(false);
	}

	// Token: 0x04000120 RID: 288
	public ParticleSystem m_dustPS;
}
