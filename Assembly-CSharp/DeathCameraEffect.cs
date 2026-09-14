using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200059F RID: 1439
public class DeathCameraEffect : MonoBehaviour
{
	// Token: 0x06002490 RID: 9360 RVA: 0x00018E3B File Offset: 0x0001703B
	private void Start()
	{
		this.method_0();
	}

	// Token: 0x06002491 RID: 9361 RVA: 0x00018E43 File Offset: 0x00017043
	private void method_0()
	{
		DeathCameraEffect.s_StopTime = this.mGrayTime + this.mBlurBlackTime;
		this.mGrayModifyPerSecond = 1f / this.mGrayTime;
	}

	// Token: 0x06002492 RID: 9362 RVA: 0x00018E69 File Offset: 0x00017069
	private void TriggerEffectByName(string name)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (name == "PlayDeath")
		{
			this.method_1();
		}
		else if (name == "PlayRevive")
		{
			this.method_3();
		}
	}

	// Token: 0x06002493 RID: 9363 RVA: 0x000AED40 File Offset: 0x000ACF40
	private void method_1()
	{
		if (this.m_death)
		{
			return;
		}
		this.mEntityPlay = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
		this.m_camera = this.mEntityPlay.method_45().camera;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		this.method_0();
		this.m_death = true;
		this.m_originCameraCullingMask = this.m_camera.cullingMask;
		this.m_originCameraClearFlags = this.m_camera.clearFlags;
		this.mRootObj = base.gameObject.transform.parent.gameObject;
		this.mDeathEffect = this.mRootObj.AddComponent<DeathEffect>();
		this.mDeathEffect.shader = Shader.Find("Custom/DeathEffect");
		this.mDeathEffect.lumScenePara = this.lumScenePara;
		this.mDeathEffect.lumFpsPara = this.lumFpsPara;
		this.mTotalUpdateTime = 0f;
		this.method_7();
		this.mOriginFov = this.m_camera.fieldOfView;
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_18().method_0(this.m_camera, false);
		}
		BadAssFPSCamera component = this.m_camera.GetComponent<BadAssFPSCamera>();
		if (component != null)
		{
			component.enabled = false;
		}
		this.needPlayParticle = true;
		this.mParticleCam = base.gameObject.AddComponent<Camera>();
		this.method_2();
		if (this.mAnimPaused)
		{
			this.mEntityPlay.method_87(true);
		}
		WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		this.mfpOriFov = componentInChildren.method_1().fieldOfView;
		MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Npc, out this.mNpcEntities);
		this.mDeathEffect.enabled = false;
	}

	// Token: 0x06002494 RID: 9364 RVA: 0x000AEEF8 File Offset: 0x000AD0F8
	private void method_2()
	{
		Utils.smethod_14(ref this.m_camera, ref this.mParticleCam);
		this.mParticleCam.cullingMask = 8192;
		this.mParticleCam.depth = 0.05f;
		this.mParticleCam.clearFlags = CameraClearFlags.Depth;
		this.mParticleCam.hdr = true;
		this.mParticleCam.renderingPath = RenderingPath.Forward;
	}

	// Token: 0x06002495 RID: 9365 RVA: 0x000AEF5C File Offset: 0x000AD15C
	public void method_3()
	{
		if (!this.m_death)
		{
			return;
		}
		this.m_death = false;
		global::UnityEngine.Object.Destroy(this.mParticleCam);
		this.mParticleCam = null;
		WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		componentInChildren.method_1().fieldOfView = this.mfpOriFov;
		componentInChildren.method_3();
		this.method_4(componentInChildren.method_0());
		if (this.mAnimPaused)
		{
			this.mEntityPlay.method_87(false);
		}
		this.mEntityPlay = null;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(true);
		this.m_camera.cullingMask = this.m_originCameraCullingMask;
		this.m_camera.clearFlags = this.m_originCameraClearFlags;
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_18().method_0(this.m_camera, true);
		}
		if (this.mDeathEffect != null)
		{
			global::UnityEngine.Object.Destroy(this.mDeathEffect);
			this.mDeathEffect = null;
		}
		if (this.mNpcEntities != null)
		{
			for (int i = 0; i < this.mNpcEntities.Count; i++)
			{
				EntityNpc entityNpc = this.mNpcEntities[i] as EntityNpc;
				if (entityNpc != null)
				{
					AnimationManagerFSM animationManagerFSM = entityNpc.vmethod_12() as AnimationManagerFSM;
					if (animationManagerFSM != null)
					{
						animationManagerFSM.method_6();
					}
				}
			}
			this.mNpcEntities = null;
		}
		BadAssFPSCamera component = this.m_camera.GetComponent<BadAssFPSCamera>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	// Token: 0x06002496 RID: 9366 RVA: 0x000AF0C4 File Offset: 0x000AD2C4
	private void FixedUpdate()
	{
		if (this.mDeathEffect != null)
		{
			this.mTotalUpdateTime += Time.deltaTime;
			this.mCurStatUpdateTime += Time.deltaTime;
			DeathCameraEffect.DEATH_STAT death_STAT = this.mCurStat;
			if (death_STAT != DeathCameraEffect.DEATH_STAT.STAT_GRAY)
			{
				if (death_STAT == DeathCameraEffect.DEATH_STAT.STAT_BLUR_BLACK)
				{
					this.method_6();
				}
			}
			else
			{
				this.method_5();
			}
			if (this.needPlayParticle && this.mTotalUpdateTime > this.mPlayParticlTime)
			{
				this.method_9();
			}
		}
	}

	// Token: 0x06002497 RID: 9367 RVA: 0x000AF140 File Offset: 0x000AD340
	private void method_4(Matrix4x4 matrix4x4_0)
	{
		if (this.mEntityPlay == null)
		{
			return;
		}
		EntityWeapon entityWeapon = this.mEntityPlay.vmethod_16();
		if (entityWeapon == null)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren = entityWeapon.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			skinnedMeshRenderer.castShadows = false;
			foreach (Material material in skinnedMeshRenderer.materials)
			{
				material.SetMatrix("_ProjMat", matrix4x4_0);
			}
			if (skinnedMeshRenderer.material != null)
			{
				skinnedMeshRenderer.material.SetMatrix("_ProjMat", matrix4x4_0);
			}
		}
		Transform transform = this.mEntityPlay.method_60();
		if (transform == null)
		{
			return;
		}
		Renderer component = transform.gameObject.GetComponent<SkinnedMeshRenderer>();
		if (component != null && component.materials != null)
		{
			for (int k = 0; k < component.materials.Length; k++)
			{
				component.materials[k].SetMatrix("_ProjMat", matrix4x4_0);
			}
		}
	}

	// Token: 0x06002498 RID: 9368 RVA: 0x00018EA0 File Offset: 0x000170A0
	private void method_5()
	{
		if (this.mCurStatUpdateTime < this.mGrayTime)
		{
			this.mDeathEffect.saturation -= this.mGrayModifyPerSecond * Time.fixedDeltaTime;
		}
		else
		{
			this.method_8();
		}
	}

	// Token: 0x06002499 RID: 9369 RVA: 0x000AF250 File Offset: 0x000AD450
	private void method_6()
	{
		if (this.mParticleCam != null)
		{
			this.method_2();
		}
		if (this.mCurStatUpdateTime < this.mBlurBlackTime)
		{
			float num = this.mModifySceneFovPerSec * Time.fixedDeltaTime;
			if (this.m_camera.fieldOfView < this.mMaxSceneFov)
			{
				this.m_camera.fieldOfView += num;
			}
			WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			componentInChildren.method_1().fieldOfView -= num * this.mFpFovSpeedCurve.Evaluate(this.mCurStatUpdateTime);
			if (componentInChildren.method_1().fieldOfView > this.mMinFpFpv)
			{
				componentInChildren.method_3();
				this.method_4(componentInChildren.method_0());
			}
			this.mDeathEffect.lumOffset = this.mChangeToBlackCurve.Evaluate(this.mCurStatUpdateTime);
		}
		else
		{
			this.m_camera.fieldOfView = this.mOriginFov;
		}
	}

	// Token: 0x0600249A RID: 9370 RVA: 0x00018ED6 File Offset: 0x000170D6
	private void method_7()
	{
		this.method_10(DeathCameraEffect.DEATH_STAT.STAT_GRAY);
		this.mDeathEffect.statIndex = 0;
		this.mDeathEffect.saturation = 1f;
	}

	// Token: 0x0600249B RID: 9371 RVA: 0x000AF33C File Offset: 0x000AD53C
	private void method_8()
	{
		this.method_10(DeathCameraEffect.DEATH_STAT.STAT_BLUR_BLACK);
		this.mDeathEffect.statIndex = 1;
		this.mDeathEffect.blurAmount = this.mBlurAmout;
		this.mDeathEffect.extraBlur = this.mExtraBlur;
		this.mDeathEffect.lumOffset = 1f;
	}

	// Token: 0x0600249C RID: 9372 RVA: 0x00018EFB File Offset: 0x000170FB
	private void method_9()
	{
		this.mDeathEffect.BroadcastMessage("TriggerEffectByName", "DeathParticle", SendMessageOptions.DontRequireReceiver);
		this.needPlayParticle = false;
	}

	// Token: 0x0600249D RID: 9373 RVA: 0x00018F1A File Offset: 0x0001711A
	private void method_10(DeathCameraEffect.DEATH_STAT death_STAT_0)
	{
		this.mCurStat = death_STAT_0;
		this.mCurStatUpdateTime = 0f;
	}

	// Token: 0x040019A7 RID: 6567
	private const int DEATH_LAYER = 8192;

	// Token: 0x040019A8 RID: 6568
	private CameraClearFlags m_originCameraClearFlags = CameraClearFlags.Skybox;

	// Token: 0x040019A9 RID: 6569
	private int m_originCameraCullingMask;

	// Token: 0x040019AA RID: 6570
	private bool m_death;

	// Token: 0x040019AB RID: 6571
	private Camera m_camera;

	// Token: 0x040019AC RID: 6572
	private Camera mParticleCam;

	// Token: 0x040019AD RID: 6573
	private DeathCameraEffect.DEATH_STAT mCurStat;

	// Token: 0x040019AE RID: 6574
	private DeathEffect mDeathEffect;

	// Token: 0x040019AF RID: 6575
	private GameObject mRootObj;

	// Token: 0x040019B0 RID: 6576
	public float mGrayTime = 3f;

	// Token: 0x040019B1 RID: 6577
	private float mGrayModifyPerSecond;

	// Token: 0x040019B2 RID: 6578
	public float mBlurBlackTime = 3f;

	// Token: 0x040019B3 RID: 6579
	public float mModifySceneFovPerSec = 100f;

	// Token: 0x040019B4 RID: 6580
	public AnimationCurve mChangeToBlackCurve;

	// Token: 0x040019B5 RID: 6581
	public float mPlayParticlTime = 3f;

	// Token: 0x040019B6 RID: 6582
	public float mBlurAmout = 0.8f;

	// Token: 0x040019B7 RID: 6583
	private bool needPlayParticle = true;

	// Token: 0x040019B8 RID: 6584
	public bool mExtraBlur;

	// Token: 0x040019B9 RID: 6585
	private float mOriginFov;

	// Token: 0x040019BA RID: 6586
	private float mTotalUpdateTime;

	// Token: 0x040019BB RID: 6587
	private float mCurStatUpdateTime;

	// Token: 0x040019BC RID: 6588
	public float lumScenePara = 1f;

	// Token: 0x040019BD RID: 6589
	public float lumFpsPara = 1f;

	// Token: 0x040019BE RID: 6590
	public static float s_StopTime = 7f;

	// Token: 0x040019BF RID: 6591
	private EntityPlayer mEntityPlay;

	// Token: 0x040019C0 RID: 6592
	private float mfpOriFov;

	// Token: 0x040019C1 RID: 6593
	public float mMaxSceneFov = 120f;

	// Token: 0x040019C2 RID: 6594
	private float mMinFpFpv = 3f;

	// Token: 0x040019C3 RID: 6595
	public AnimationCurve mFpFovSpeedCurve;

	// Token: 0x040019C4 RID: 6596
	public bool mAnimPaused;

	// Token: 0x040019C5 RID: 6597
	private List<Entity> mNpcEntities;

	// Token: 0x020005A0 RID: 1440
	private enum DEATH_STAT
	{
		// Token: 0x040019C7 RID: 6599
		STAT_NOT_START,
		// Token: 0x040019C8 RID: 6600
		STAT_GRAY,
		// Token: 0x040019C9 RID: 6601
		STAT_BLUR_BLACK,
		// Token: 0x040019CA RID: 6602
		STAT_PLAY_PARTICLE
	}
}
