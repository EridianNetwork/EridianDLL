using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class CrimsonLanceDefenderAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600010D RID: 269 RVA: 0x0003A99C File Offset: 0x00038B9C
	public override void Start()
	{
		base.Start();
		this.m_isHumanoid = true;
		this.m_shotSoundType = global::UnityEngine.Random.Range(0f, 3f);
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00003816 File Offset: 0x00001A16
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x0600010F RID: 271 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0003AA0C File Offset: 0x00038C0C
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

	// Token: 0x04000122 RID: 290
	public float m_lastShotSoundTime;

	// Token: 0x04000123 RID: 291
	private float m_shotSoundType;
}
