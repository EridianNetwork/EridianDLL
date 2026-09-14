using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020006DE RID: 1758
public class ParticleManager : MonoBehaviour
{
	// Token: 0x1400000D RID: 13
	// (add) Token: 0x06002E5A RID: 11866 RVA: 0x0001E9CC File Offset: 0x0001CBCC
	// (remove) Token: 0x06002E5B RID: 11867 RVA: 0x0001E9E5 File Offset: 0x0001CBE5
	public event ParticleManager.TimeLineCallBack Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.triggerCallBack = (ParticleManager.TimeLineCallBack)Delegate.Combine(this.triggerCallBack, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.triggerCallBack = (ParticleManager.TimeLineCallBack)Delegate.Remove(this.triggerCallBack, value);
		}
	}

	// Token: 0x1400000E RID: 14
	// (add) Token: 0x06002E5C RID: 11868 RVA: 0x0001E9FE File Offset: 0x0001CBFE
	// (remove) Token: 0x06002E5D RID: 11869 RVA: 0x0001EA17 File Offset: 0x0001CC17
	public event ParticleManager.TimeLineCallBack Event_1
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.finishCallBack = (ParticleManager.TimeLineCallBack)Delegate.Combine(this.finishCallBack, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.finishCallBack = (ParticleManager.TimeLineCallBack)Delegate.Remove(this.finishCallBack, value);
		}
	}

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06002E5F RID: 11871 RVA: 0x0001EA39 File Offset: 0x0001CC39
	// (set) Token: 0x06002E5E RID: 11870 RVA: 0x0001EA30 File Offset: 0x0001CC30
	public float Single_0
	{
		get
		{
			return this.m_triggerTime;
		}
		set
		{
			this.m_triggerTime = value;
		}
	}

	// Token: 0x06002E60 RID: 11872 RVA: 0x000D8464 File Offset: 0x000D6664
	public Transform method_0(string string_0 = "UI", string string_1 = "PTL")
	{
		this.uiParticleRoot = NPC_UIFlowController.smethod_0().method_0().CraftCamera.transform;
		int num = 0;
		while (this.uiParticleRoot != null && num < 10 && !(this.uiParticleRoot.name == string_0))
		{
			this.uiParticleRoot = this.uiParticleRoot.parent;
			num++;
		}
		if (this.uiParticleRoot != null)
		{
			ParticleSystem[] componentsInChildren = this.uiParticleRoot.GetComponentsInChildren<ParticleSystem>();
			this.m_particles.AddRange(componentsInChildren);
			this.rule = string_1;
			return this.uiParticleRoot;
		}
		return null;
	}

	// Token: 0x06002E61 RID: 11873 RVA: 0x0001EA41 File Offset: 0x0001CC41
	public void method_1()
	{
		this.m_activeParticles.Clear();
		this.m_activeParticles = null;
		this.m_particles.Clear();
		this.m_particles = null;
		this.triggerCallBack = null;
		this.finishCallBack = null;
	}

	// Token: 0x06002E62 RID: 11874 RVA: 0x000D8500 File Offset: 0x000D6700
	public void method_2()
	{
		if (this.m_targetParticle != null)
		{
			this.m_targetParticle.Stop();
			this.m_targetParticle.time = 0f;
			this.m_targetParticle.gameObject.SetActive(false);
		}
		for (int i = 0; i < this.m_particles.Count; i++)
		{
			if (this.m_particles[i] != null && this.m_particles[i].name.Contains(this.rule))
			{
				this.m_particles[i].Stop();
				this.m_particles[i].gameObject.SetActive(false);
			}
		}
		this.m_isAnimted = false;
	}

	// Token: 0x06002E63 RID: 11875 RVA: 0x0001EA75 File Offset: 0x0001CC75
	public void method_3(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_activeParticles.Count)
		{
			this.m_activeParticles[int_0].gameObject.SetActive(false);
		}
	}

	// Token: 0x06002E64 RID: 11876 RVA: 0x000D85C0 File Offset: 0x000D67C0
	public void method_4(string string_0, bool bool_0 = false, bool bool_1 = false, ParticleManager.TimeLineCallBack timeLineCallBack_0 = null)
	{
		if (this.uiParticleRoot == null)
		{
			this.method_0("UI", "PTL");
		}
		if (bool_1)
		{
			this.method_2();
			this.m_activeParticles.Clear();
		}
		if (string_0 != string.Empty)
		{
			this.m_targetParticle = this.method_5(string_0);
		}
		else if (timeLineCallBack_0 != null)
		{
			timeLineCallBack_0();
		}
		if (this.m_targetParticle != null)
		{
			this.m_targetParticle.gameObject.SetActive(true);
			if (bool_0)
			{
				this.m_targetParticle.loop = false;
				this.m_targetParticle.Play();
				if (this.m_triggerTime > 0f)
				{
					this.m_startTime = Time.time;
				}
				this.m_isAnimted = true;
				this.finishCallBack = (ParticleManager.TimeLineCallBack)Delegate.Combine(this.finishCallBack, timeLineCallBack_0);
			}
			else
			{
				this.m_targetParticle.renderer.enabled = true;
			}
			this.m_activeParticles.Add(this.m_targetParticle);
		}
	}

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06002E65 RID: 11877 RVA: 0x0001EAA0 File Offset: 0x0001CCA0
	public bool Boolean_0
	{
		get
		{
			return this.m_isAnimted;
		}
	}

	// Token: 0x06002E66 RID: 11878 RVA: 0x000D86C0 File Offset: 0x000D68C0
	private ParticleSystem method_5(string string_0)
	{
		return m_particles.Find((ParticleSystem particleSystem_0) => particleSystem_0.name == string_0);
	}
	// Token: 0x06002E67 RID: 11879 RVA: 0x000D86F4 File Offset: 0x000D68F4
	private void Update()
	{
		if (this.m_isAnimted && this.m_targetParticle != null)
		{
			if (!this.m_targetParticle.isPlaying)
			{
				if (this.finishCallBack != null)
				{
					this.m_targetParticle.Stop();
					this.m_targetParticle.gameObject.SetActive(false);
					this.m_targetParticle = null;
					this.finishCallBack();
				}
				this.m_isAnimted = false;
			}
			else if (this.m_triggerTime > 0f && Time.time - this.m_startTime >= this.m_triggerTime && this.triggerCallBack != null)
			{
				this.triggerCallBack();
				this.m_triggerTime = 0f;
			}
		}
	}

	// Token: 0x06002E68 RID: 11880 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x040020A1 RID: 8353
	private ParticleSystem m_targetParticle;

	// Token: 0x040020A2 RID: 8354
	private List<ParticleSystem> m_activeParticles = new List<ParticleSystem>();

	// Token: 0x040020A3 RID: 8355
	private List<ParticleSystem> m_particles = new List<ParticleSystem>();

	// Token: 0x040020A4 RID: 8356
	private string rule = string.Empty;

	// Token: 0x040020A5 RID: 8357
	private float m_startTime;

	// Token: 0x040020A6 RID: 8358
	private float m_triggerTime = 3f;

	// Token: 0x040020A7 RID: 8359
	private bool m_isAnimted;

	// Token: 0x040020A8 RID: 8360
	private Transform uiParticleRoot;

	// Token: 0x040020A9 RID: 8361
	private ParticleManager.TimeLineCallBack triggerCallBack;

	// Token: 0x040020AA RID: 8362
	private ParticleManager.TimeLineCallBack finishCallBack;

	// Token: 0x020006DF RID: 1759
	// (Invoke) Token: 0x06002E6A RID: 11882
	public delegate void TimeLineCallBack();
}
