using System;
using Core;
using ns0;
using Photon;
using UnityEngine;

// Token: 0x02000766 RID: 1894
public class ShootingTestMenu : global::Photon.MonoBehaviour, IDamageListener
{
	// Token: 0x06003230 RID: 12848 RVA: 0x0000311B File Offset: 0x0000131B
	public void Start()
	{
	}

	// Token: 0x06003231 RID: 12849 RVA: 0x000E31FC File Offset: 0x000E13FC
	public void method_0()
	{
		if (this.m_DamageManager == null && DamageManager.DamageManager_0 != null)
		{
			this.m_DamageManager = DamageManager.DamageManager_0;
			this.m_DamageManager.method_3(this);
		}
		if (this.m_targeting == null)
		{
			this.m_targeting = MonoSingleton<TargetingManager>.Instance;
		}
		if (this.m_entityPlayer == null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() != null)
		{
			this.m_entityPlayer = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
		}
		if (this.m_playerController == null && this.m_entityPlayer != null)
		{
			this.m_playerController = this.m_entityPlayer.GetComponent<PlayerController>();
		}
		if (this.m_entityPlayer != null)
		{
			this.m_weapon = this.m_entityPlayer.vmethod_16();
		}
		if (this.m_started && this.m_playerController != null && this.m_autoShooting && (double)Time.time > this.lastshot + this.interval)
		{
			if (this.m_bulletShot == this.m_maxShot)
			{
				DebugUtils.Log(LogCategory.GUI, string.Concat(new object[]
				{
					"shooting Auto Testing finished bulletShot:",
					this.m_bulletShot,
					" hitRate:",
					(float)this.m_hitcount / (float)this.m_bulletShot * 100f,
					"% feedback:",
					this.m_feedback,
					"s"
				}));
				this.Reset();
			}
			else
			{
				this.lastshot = (double)Time.time;
				if (this.m_playerController.method_34())
				{
					this.m_bulletShot++;
				}
			}
		}
	}

	// Token: 0x06003232 RID: 12850 RVA: 0x00020B20 File Offset: 0x0001ED20
	private void Reset()
	{
		this.m_started = false;
		this.m_bulletShot = 0;
		this.m_feedback = 0f;
		this.m_hitcount = 0;
	}

	// Token: 0x06003233 RID: 12851 RVA: 0x000E33E4 File Offset: 0x000E15E4
	private void method_1(int int_0)
	{
		this.m_autoAiming = GUILayout.Toggle(this.m_autoAiming, "AutoAiming", new GUILayoutOption[0]);
		this.m_autoShooting = GUILayout.Toggle(this.m_autoShooting, "AutoShooting", new GUILayoutOption[0]);
		this.m_noBulletSpray = GUILayout.Toggle(this.m_noBulletSpray, "NoBulletSpray", new GUILayoutOption[0]);
		GUILayout.Label(string.Format("maxShot: {0}", this.m_maxShot), new GUILayoutOption[0]);
		if (!this.m_started)
		{
			this.m_started = GUILayout.Button("Start", new GUILayoutOption[0]);
		}
		else
		{
			this.m_started ^= GUILayout.Button("Stop", new GUILayoutOption[0]);
		}
		if (GUILayout.Button("Reset", new GUILayoutOption[0]))
		{
			this.Reset();
		}
		GUILayout.Label(string.Format("bulletShot: {0}", this.m_bulletShot), new GUILayoutOption[0]);
		GUILayout.Label(string.Format("hitRate: {0}%", (this.m_bulletShot != 0) ? ((float)this.m_hitcount / (float)this.m_bulletShot * 100f) : 0f), new GUILayoutOption[0]);
		GUILayout.Label(string.Format("feedback: {0}s", this.m_feedback), new GUILayoutOption[0]);
		if (this.m_targeting != null)
		{
			this.m_targeting.m_autoAiming = this.m_autoAiming;
		}
		if (this.m_weapon != null && this.m_weapon.m_noBulletSpray != this.m_noBulletSpray)
		{
			this.m_weapon.m_noBulletSpray = this.m_noBulletSpray;
			object[] array = new object[]
			{
				this.m_weapon.vmethod_0(),
				this.m_noBulletSpray
			};
			base.photonView.method_4("RPC_RequestWeaponNoSpray", PhotonTargets.MasterClient, array);
		}
		if (GUI.changed)
		{
			this.m_WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}

	// Token: 0x06003234 RID: 12852 RVA: 0x000E35E0 File Offset: 0x000E17E0
	public void OnDamaged(DamageContext context)
	{
		if (this.m_started && context.m_damageInfo.m_from == this.m_weapon.m_owner.vmethod_0())
		{
			this.m_hitcount++;
			DebugUtils.Log(LogCategory.GUI, "SbGetDamage time:" + ((double)Time.time - this.lastshot));
			this.m_feedback += ((float)((double)Time.time - this.lastshot) - this.m_feedback) / (float)this.m_hitcount;
		}
	}

	// Token: 0x06003235 RID: 12853 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEntityKill(KillContext context)
	{
	}

	// Token: 0x0400229F RID: 8863
	public Rect m_WindowRect = new Rect(0f, 100f, 120f, 100f);

	// Token: 0x040022A0 RID: 8864
	public int m_WindowId = 102;

	// Token: 0x040022A1 RID: 8865
	public bool m_Visible = true;

	// Token: 0x040022A2 RID: 8866
	public bool m_autoAiming = true;

	// Token: 0x040022A3 RID: 8867
	public bool m_autoShooting = true;

	// Token: 0x040022A4 RID: 8868
	public bool m_noBulletSpray = true;

	// Token: 0x040022A5 RID: 8869
	public bool m_started;

	// Token: 0x040022A6 RID: 8870
	public int m_maxShot = 10;

	// Token: 0x040022A7 RID: 8871
	public int m_bulletShot;

	// Token: 0x040022A8 RID: 8872
	public float m_feedback;

	// Token: 0x040022A9 RID: 8873
	private int m_hitcount;

	// Token: 0x040022AA RID: 8874
	private double interval = 1.0;

	// Token: 0x040022AB RID: 8875
	private double lastshot;

	// Token: 0x040022AC RID: 8876
	private EntityPlayer m_entityPlayer;

	// Token: 0x040022AD RID: 8877
	private EntityWeapon m_weapon;

	// Token: 0x040022AE RID: 8878
	private TargetingManager m_targeting;

	// Token: 0x040022AF RID: 8879
	private PlayerController m_playerController;

	// Token: 0x040022B0 RID: 8880
	private DamageManager m_DamageManager;
}
