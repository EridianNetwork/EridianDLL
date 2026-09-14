using System;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class CrimsonLanceMedicAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000113 RID: 275 RVA: 0x0003AA60 File Offset: 0x00038C60
	public override void Start()
	{
		base.Start();
		this.m_isHumanoid = true;
		this.m_shotSoundType = global::UnityEngine.Random.Range(0f, 3f);
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_animEventHandlerList.Add("ThrowWeapon", new AnimationManagerFSM.OnAnimEventHandler(base.OnThrowWeapon));
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00003816 File Offset: 0x00001A16
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0003AAEC File Offset: 0x00038CEC
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = this.m_entity.vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
			NPCAnimationManagerFSM.smethod_0(this.m_AudioCtl, NPCAnimationManagerFSM.NPCSMGShootType.Chain, this.m_shotSoundType, ref this.m_lastShotSoundTime);
		}
	}

	// Token: 0x04000124 RID: 292
	public float m_lastShotSoundTime;

	// Token: 0x04000125 RID: 293
	private float m_shotSoundType;
}
