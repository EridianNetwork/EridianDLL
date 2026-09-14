using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class AnimationPlayerFireState : PlayerAnimationState
{
	// Token: 0x06000402 RID: 1026 RVA: 0x0000594C File Offset: 0x00003B4C
	public AnimationPlayerFireState()
	{
		this.StateName = "PlayerFire";
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000595F File Offset: 0x00003B5F
	private PlayerBehavior PlayerBehavior_0
	{
		get
		{
			if (this.m_inner_playerBehavior == null)
			{
				this.m_inner_playerBehavior = base.method_21().GetComponent<PlayerBehavior>();
			}
			return this.m_inner_playerBehavior;
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00049908 File Offset: 0x00047B08
	public void method_22()
	{
		if (this.m_AnimManager == null)
		{
			this.m_AnimManager = this.m_AnimationManagerFSM as PlayerAnimationManagerFSM;
		}
		this.m_AnimManager.m_fireTiming.Event_0 += this.method_26;
		this.m_AnimManager.m_fireTiming.Event_1 += this.method_24;
		this.m_AnimManager.m_fireTiming.Event_2 += this.method_28;
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00049988 File Offset: 0x00047B88
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_weaponMode = ((PlayerAnimationManagerFSM)this.m_AnimationManagerFSM).method_29();
		if (base.Boolean_0)
		{
			base.method_11("fWeaponMode", this.m_weaponMode);
			base.method_10("bFromAimFire", false);
		}
		base.method_17("fWeaponMode", this.m_weaponMode);
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x000499F4 File Offset: 0x00047BF4
	public override void vmethod_1()
	{
		this.m_animatorInfo = base.method_15(base.Boolean_0, 1);
		if (this.m_AnimManager.m_fireTiming.method_0() && this.m_animatorInfo.IsTag("Fire"))
		{
			this.method_27(false);
		}
		if (this.PlayerBehavior_0.IsFiring())
		{
			this.m_fireHolding_duration += Time.deltaTime;
		}
		else
		{
			this.m_fireHolding_duration = 0f;
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00049A6C File Offset: 0x00047C6C
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		this.m_fireHolding_duration = 0f;
		this.method_25(false, 0f);
		this.method_27(false);
		if (base.Boolean_0)
		{
			base.method_10("bFromFire", true);
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x00005986 File Offset: 0x00003B86
	public float method_23()
	{
		return this.m_fireHolding_duration;
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0000598E File Offset: 0x00003B8E
	private void method_24(float float_2)
	{
		if (this.method_29())
		{
			return;
		}
		this.method_25(true, float_2);
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00049ABC File Offset: 0x00047CBC
	private void method_25(bool bool_1, float float_2)
	{
		if (!this.m_AnimManager.vmethod_24())
		{
			if (base.Boolean_0)
			{
				base.method_10("bFire", false);
			}
			base.method_16("bFire", false);
			return;
		}
		if (base.Boolean_0)
		{
			base.method_10("bFire", bool_1);
			base.method_11("fFireSpeed", float_2);
		}
		base.method_16("bFire", bool_1);
		base.method_17("fFireSpeed", float_2);
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x000059A1 File Offset: 0x00003BA1
	private void method_26()
	{
		if (this.method_29())
		{
			return;
		}
		this.method_27(true);
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00049B38 File Offset: 0x00047D38
	private void method_27(bool bool_1)
	{
		if (!this.m_AnimManager.vmethod_24())
		{
			if (base.Boolean_0)
			{
				base.method_10("bFire", false);
			}
			base.method_16("bFire", false);
			return;
		}
		if (base.Boolean_0 && base.Animator_0 != null && !base.Animator_0.GetBool("bRecoilExit_1st"))
		{
			base.method_10("bFire", bool_1);
		}
		base.method_16("bFire", bool_1);
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x000059B3 File Offset: 0x00003BB3
	private void method_28()
	{
		if (this.method_29())
		{
			return;
		}
		this.method_25(false, 0f);
		this.method_27(false);
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x000059D1 File Offset: 0x00003BD1
	private bool method_29()
	{
		return this.PlayerBehavior_0.IsAiming();
	}

	// Token: 0x040003E5 RID: 997
	private const string FIRE_TAG = "Fire";

	// Token: 0x040003E6 RID: 998
	private const int FIRE_LAYER = 1;

	// Token: 0x040003E7 RID: 999
	private PlayerAnimationManagerFSM m_AnimManager;

	// Token: 0x040003E8 RID: 1000
	private float m_weaponMode;

	// Token: 0x040003E9 RID: 1001
	private float m_fireHolding_duration;

	// Token: 0x040003EA RID: 1002
	private PlayerBehavior m_inner_playerBehavior;
}
