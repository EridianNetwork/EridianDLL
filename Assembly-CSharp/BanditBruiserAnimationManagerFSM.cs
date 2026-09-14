using System;

// Token: 0x0200001E RID: 30
public class BanditBruiserAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000D6 RID: 214 RVA: 0x000399A0 File Offset: 0x00037BA0
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = true;
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
			this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
			this.m_animEventHandlerList.Add("ThrowWeapon", new AnimationManagerFSM.OnAnimEventHandler(base.OnThrowWeapon));
		}
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00003816 File Offset: 0x00001A16
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x000398CC File Offset: 0x00037ACC
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
		}
	}

	// Token: 0x04000100 RID: 256
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x04000101 RID: 257
	public float m_lastShotSoundTime;
}
