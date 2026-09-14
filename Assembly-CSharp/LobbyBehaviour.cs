using System;
using ns0;
using UnityEngine;

// Token: 0x02000693 RID: 1683
public class LobbyBehaviour : MonoBehaviour
{
	// Token: 0x06002B9E RID: 11166 RVA: 0x000CBF38 File Offset: 0x000CA138
	public void Start()
	{
		m_bShowLight = false;
		m_bParticleEnable = false;
		m_bMouseOver = false;
		m_bLock = false;
		m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == "PTL_UnlockInstance")
			{
				m_UnlockParticle = component.GetChild(i).gameObject.particleSystem;
				break;
			}
		}
		base.gameObject.SetActive(value: false);
	}
	// Token: 0x06002B9F RID: 11167 RVA: 0x000CBFEC File Offset: 0x000CA1EC
	private void Update()
	{
		if (this.m_bParticleEnable)
		{
			if (!this.m_UnlockParticle.isPlaying)
			{
				this.method_7("PTL_UnlockInstance");
			}
			if ((double)this.m_UnlockParticle.time > 0.7 && !this.m_bShowLight)
			{
				if (LevelLockingManager.smethod_0().method_8(int.Parse(this.m_LevelID)))
				{
					this.method_6("Quest");
				}
				else
				{
					this.method_6("Normal");
				}
				this.m_bShowLight = true;
			}
		}
	}

	// Token: 0x06002BA0 RID: 11168 RVA: 0x000CC070 File Offset: 0x000CA270
	public void method_0()
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
		}
		this.m_bLock = LevelLockingManager.smethod_0().method_12(int.Parse(this.m_LevelID));
		if (!LevelLockingManager.smethod_0().method_1())
		{
			GameObject gameObject = GameObject.Find("LA");
			if (gameObject != null)
			{
				Transform transform = gameObject.transform.FindChild("Scenes/PRO_Looby_Logo");
				if (transform != null)
				{
					transform.gameObject.SetActive(false);
				}
			}
		}
		if (this.m_bLock)
		{
			this.method_2();
		}
		else if (!LevelLockingManager.smethod_0().method_1())
		{
			if (LevelLockingManager.smethod_0().method_2(int.Parse(this.m_LevelID)))
			{
				this.method_3();
			}
			else if (LevelLockingManager.smethod_0().method_8(int.Parse(this.m_LevelID)))
			{
				this.method_6("Quest");
			}
			else
			{
				this.method_6("Normal");
			}
		}
		else if (LevelLockingManager.smethod_0().method_8(int.Parse(this.m_LevelID)))
		{
			this.method_6("Quest");
		}
		else
		{
			this.method_6("Normal");
		}
	}

	// Token: 0x06002BA1 RID: 11169 RVA: 0x000CC198 File Offset: 0x000CA398
	public void OnMouseOver()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_11())
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0().Boolean_0)
		{
			return;
		}
		if (!this.m_bMouseOver)
		{
			this.m_bMouseOver = true;
			if (this.method_5("Normal") || this.method_5("Quest"))
			{
				this.method_6("MouseOver");
			}
		}
	}

	// Token: 0x06002BA2 RID: 11170 RVA: 0x000CC200 File Offset: 0x000CA400
	public void OnMouseExit()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_11())
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0().Boolean_0)
		{
			return;
		}
		if (this.m_bMouseOver)
		{
			this.m_bMouseOver = false;
			if (this.method_5("MouseOver"))
			{
				if (LevelLockingManager.smethod_0().method_8(int.Parse(this.m_LevelID)))
				{
					this.method_6("Quest");
				}
				else
				{
					this.method_6("Normal");
				}
			}
		}
	}

	// Token: 0x06002BA3 RID: 11171 RVA: 0x0001CD58 File Offset: 0x0001AF58
	public void method_1()
	{
		this.OnMouseExit();
	}

	// Token: 0x06002BA4 RID: 11172 RVA: 0x000CC27C File Offset: 0x000CA47C
	public void OnMouseUp()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_11())
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0().Boolean_0)
		{
			return;
		}
		if (this._EnterLevelProc != null && !this.m_bLock)
		{
			this._EnterLevelProc(int.Parse(this.m_LevelID));
		}
	}

	// Token: 0x06002BA5 RID: 11173 RVA: 0x0001CD60 File Offset: 0x0001AF60
	private void method_2()
	{
		this.method_6("Lock");
	}

	// Token: 0x06002BA6 RID: 11174 RVA: 0x0001CD6D File Offset: 0x0001AF6D
	private void method_3()
	{
		this.method_6("PTL_UnlockInstance");
	}

	// Token: 0x06002BA7 RID: 11175 RVA: 0x000CC2D4 File Offset: 0x000CA4D4
	private GameObject method_4(string string_0)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == string_0)
			{
				return component.GetChild(i).gameObject;
			}
		}
		return null;
	}

	// Token: 0x06002BA8 RID: 11176 RVA: 0x000CC328 File Offset: 0x000CA528
	private bool method_5(string string_0)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == string_0)
			{
				return component.GetChild(i).gameObject.activeSelf;
			}
		}
		return false;
	}

	// Token: 0x06002BA9 RID: 11177 RVA: 0x000CC380 File Offset: 0x000CA580
	private void method_6(string string_0)
	{
		if (this.m_bLock && string_0 != "Lock")
		{
			return;
		}
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name != string_0)
			{
				if (string_0 == "PTL_UnlockInstance")
				{
					if (this.m_bMouseOver && component.GetChild(i).gameObject.name == "MouseOver")
					{
						component.GetChild(i).gameObject.SetActive(false);
					}
					if (!this.m_bMouseOver && component.GetChild(i).gameObject.name == "Normal")
					{
						component.GetChild(i).gameObject.SetActive(false);
					}
					if (!this.m_bMouseOver && component.GetChild(i).gameObject.name == "Quest")
					{
						component.GetChild(i).gameObject.SetActive(false);
					}
				}
				else if (!(component.GetChild(i).gameObject.name == "PTL_UnlockInstance") || !this.m_bParticleEnable)
				{
					component.GetChild(i).gameObject.SetActive(false);
				}
			}
			else
			{
				component.GetChild(i).gameObject.SetActive(true);
				if (string_0 == "PTL_UnlockInstance")
				{
					this.m_bParticleEnable = true;
				}
			}
		}
	}

	// Token: 0x06002BAA RID: 11178 RVA: 0x000CC4FC File Offset: 0x000CA6FC
	private void method_7(string string_0)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == string_0)
			{
				component.GetChild(i).gameObject.SetActive(false);
				if (string_0 == "PTL_UnlockInstance")
				{
					this.m_bParticleEnable = false;
				}
			}
		}
		if (this.m_bMouseOver)
		{
			this.method_6("MouseOver");
		}
		else if (LevelLockingManager.smethod_0().method_8(int.Parse(this.m_LevelID)))
		{
			if (!this.method_5("Quest"))
			{
				this.method_6("Quest");
			}
		}
		else if (!this.method_5("Normal"))
		{
			this.method_6("Normal");
		}
	}

	// Token: 0x04001EB1 RID: 7857
	public string m_LightID;

	// Token: 0x04001EB2 RID: 7858
	private bool m_bShowLight;

	// Token: 0x04001EB3 RID: 7859
	private bool m_bParticleEnable;

	// Token: 0x04001EB4 RID: 7860
	private bool m_bMouseOver;

	// Token: 0x04001EB5 RID: 7861
	private bool m_bLock;

	// Token: 0x04001EB6 RID: 7862
	private string m_LevelID;

	// Token: 0x04001EB7 RID: 7863
	private ParticleSystem m_UnlockParticle;

	// Token: 0x04001EB8 RID: 7864
	public Delegate_EnterLevelProc _EnterLevelProc;
}
