using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005A3 RID: 1443
public class FpCameraEffectMgr
{
	// Token: 0x060024A4 RID: 9380 RVA: 0x00018F8B File Offset: 0x0001718B
	public void method_0(GameObject gameObject_0)
	{
		this.graphicMgrObj = gameObject_0;
		this.graphicMgrObj.AddComponent<FpCameraEffectBehaviour>();
	}

	// Token: 0x060024A5 RID: 9381 RVA: 0x000AF42C File Offset: 0x000AD62C
	public void Update()
	{
		if (!VFXManager.smethod_3())
		{
			return;
		}
		for (int i = this.lstParticleEffects.Count - 1; i >= 0; i--)
		{
			if (this.lstParticleEffects[i].m_timer.method_7() || (this.lstParticleEffects[i].m_particle != null && this.lstParticleEffects[i].m_particle.isStopped))
			{
				if (this.lstParticleEffects[i].m_particle != null)
				{
					this.lstParticleEffects[i].m_particle.Stop();
				}
				this.lstParticleEffects[i].m_particleGameObject.SetActive(false);
				this.lstParticleEffects.RemoveAt(i);
			}
		}
	}

	// Token: 0x060024A6 RID: 9382 RVA: 0x000AF4FC File Offset: 0x000AD6FC
	public void method_1()
	{
		for (int i = 0; i < this.lstParticleEffects.Count; i++)
		{
			if (this.lstParticleEffects[i].m_particle != null)
			{
				this.lstParticleEffects[i].m_particle.Stop();
			}
			this.lstParticleEffects[i].m_particleGameObject.SetActive(false);
		}
		this.lstParticleEffects.Clear();
	}

	// Token: 0x060024A7 RID: 9383 RVA: 0x000AF570 File Offset: 0x000AD770
	public bool method_2(EntityPlayer entityPlayer_0, ENPCParticleType enpcparticleType_0)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		VFXforNPC vfxforNPC = entityPlayer_0.VFXManager_0.method_12(enpcparticleType_0, 0);
		if (vfxforNPC == null)
		{
			return false;
		}
		if (vfxforNPC.m_particleGameObject == null)
		{
			return false;
		}
		vfxforNPC.m_particleGameObject.SetActive(false);
		if (vfxforNPC.m_particle != null)
		{
			vfxforNPC.m_particle.Stop();
		}
		this.lstParticleEffects.Remove(vfxforNPC);
		return true;
	}

	// Token: 0x060024A8 RID: 9384 RVA: 0x00018FA0 File Offset: 0x000171A0
	public bool method_3(EntityPlayer entityPlayer_0, ENPCParticleType enpcparticleType_0, float float_0 = 0f)
	{
		return this.method_4(entityPlayer_0, enpcparticleType_0, Vector3.zero, Quaternion.identity, float_0);
	}

	// Token: 0x060024A9 RID: 9385 RVA: 0x000AF5DC File Offset: 0x000AD7DC
	public bool method_4(EntityPlayer entityPlayer_0, ENPCParticleType enpcparticleType_0, Vector3 vector3_0, Quaternion quaternion_0, float float_0 = 0f)
	{
		if (!VFXManager.smethod_3())
		{
			return false;
		}
		VFXforNPC vfxforNPC = entityPlayer_0.VFXManager_0.method_12(enpcparticleType_0, 0);
		if (vfxforNPC == null)
		{
			return false;
		}
		if (vfxforNPC.m_particleGameObject == null)
		{
			return false;
		}
		vfxforNPC.m_particleGameObject.SetActive(true);
		if (vfxforNPC.m_particleGameObject.transform == null)
		{
			return false;
		}
		vfxforNPC.m_particleGameObject.transform.parent = entityPlayer_0.method_45().transform;
		vfxforNPC.m_particleGameObject.transform.localPosition = vector3_0;
		vfxforNPC.m_particleGameObject.transform.localRotation = quaternion_0;
		if (vfxforNPC.m_particle != null)
		{
			vfxforNPC.m_particle.Play();
		}
		if (vfxforNPC.m_audioEvent != string.Empty)
		{
			entityPlayer_0.VFXManager_0.m_audioCtl.TriggerEventByName(vfxforNPC.m_audioEvent);
		}
		if (float_0 > 0f)
		{
			vfxforNPC.m_timer.Start(float_0);
		}
		this.lstParticleEffects.Add(vfxforNPC);
		return true;
	}

	// Token: 0x040019CE RID: 6606
	private GameObject graphicMgrObj;

	// Token: 0x040019CF RID: 6607
	private List<VFXforNPC> lstParticleEffects = new List<VFXforNPC>();
}
