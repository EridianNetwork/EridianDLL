using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class GuardianWraithAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000124 RID: 292 RVA: 0x0003B05C File Offset: 0x0003925C
	public void method_31()
	{
		EntityNpc component = base.gameObject.GetComponent<EntityNpc>();
		this.m_leftSword = component.m_leftHandWeaponSlot.gameObject;
		this.m_rightSword = component.m_rightHandWeaponSlot.gameObject;
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00003983 File Offset: 0x00001B83
	public override bool vmethod_12()
	{
		return this.m_isSwordVisible;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0003B098 File Offset: 0x00039298
	public override void vmethod_11(bool bool_0)
	{
		if (this.m_leftSword == null)
		{
			this.method_31();
		}
		if (bool_0)
		{
			this.m_rightSword.SetActive(false);
			this.m_leftSword.SetActive(false);
			this.m_isSwordVisible = false;
		}
		else if (!this.m_isSwordVisible)
		{
			this.m_rightSword.SetActive(true);
			this.m_leftSword.SetActive(true);
			this.m_isSwordVisible = true;
			if (this.m_VFXManager != null)
			{
				this.m_VFXManager.method_4(ENPCParticleType.E_WeaponAppear, 10f, false);
			}
		}
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0003B128 File Offset: 0x00039328
	public override void Start()
	{
		base.Start();
		this.m_isHumanoid = false;
		this.m_canUseFacingLogic = true;
		this.m_deathLayer = 2;
		this.m_isSwordVisible = true;
		this.vmethod_11(true);
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0000375F File Offset: 0x0000195F
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0003B17C File Offset: 0x0003937C
	public override GameObject vmethod_10(int int_0)
	{
		GameObject gameObject = null;
		if (base.Animator_0.GetFloat("fThrowWeaponCurve") > 0.15f)
		{
			gameObject = global::UnityEngine.Object.Instantiate(base.GetComponent<EntityNpc>().m_spawnObjPrefab, this.m_skeleton.method_7().position + base.gameObject.transform.forward * 0.3f, Quaternion.identity) as GameObject;
		}
		return gameObject;
	}

	// Token: 0x0600012A RID: 298 RVA: 0x0000398B File Offset: 0x00001B8B
	public override void OnDeath()
	{
		this.vmethod_11(true);
		if (this.m_VFXManager != null)
		{
			this.m_VFXManager.method_15();
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0003B1F4 File Offset: 0x000393F4
	public override void vmethod_14()
	{
		Vector3 vector;
		vector.x = 0f;
		vector.y = 1f;
		vector.z = 0f;
		this.m_VFXManager.method_9(ENPCParticleType.E_Fuse, base.transform.position + vector, Quaternion.identity, true);
	}

	// Token: 0x0600012C RID: 300 RVA: 0x0003B24C File Offset: 0x0003944C
	public override void vmethod_15()
	{
		Vector3 vector;
		vector.x = 0f;
		vector.y = 1f;
		vector.z = 0f;
		this.m_VFXManager.method_9(ENPCParticleType.E_Spawn, base.transform.position + vector, Quaternion.identity, true);
	}

	// Token: 0x04000131 RID: 305
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x04000132 RID: 306
	private GameObject m_leftSword;

	// Token: 0x04000133 RID: 307
	private GameObject m_rightSword;

	// Token: 0x04000134 RID: 308
	private bool m_isSwordVisible = true;
}
