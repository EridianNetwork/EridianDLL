using System;
using ns0;
using UnityEngine;

// Token: 0x020006A1 RID: 1697
public class WorldMapBehaviour : MonoBehaviour
{
	// Token: 0x06002C07 RID: 11271 RVA: 0x000CFF58 File Offset: 0x000CE158
	public void Start()
	{
		this.m_bMouseOver = false;
		this.m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		GameObject gameObject = GameObject.Find("World Map");
		Transform transform = gameObject.GetComponent<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			if (transform.GetChild(i).gameObject.name == "Material_Common_Cache")
			{
				this._CommonMaterial = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (transform.GetChild(i).gameObject.name == "Material_Lock_Cache")
			{
				this._LockMaterial = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (transform.GetChild(i).gameObject.name == "Material_Select_Cache")
			{
				this._SelectMaterial = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
		}
		this.m_MeshRender = base.gameObject.GetComponent<MeshRenderer>();
		transform = base.gameObject.GetComponent<Transform>();
		for (int j = 0; j < transform.childCount; j++)
		{
			if (transform.GetChild(j).gameObject.name == "PlayerLocated")
			{
				this._playerObj = transform.GetChild(j).gameObject;
			}
		}
	}

	// Token: 0x06002C08 RID: 11272 RVA: 0x000D00C8 File Offset: 0x000CE2C8
	public void method_0()
	{
		this.m_bLocked = LevelLockingManager.smethod_0().method_12(int.Parse(this.m_LevelID));
		if (this.m_bLocked)
		{
			this.m_MeshRender.material = this._LockMaterial;
		}
		else
		{
			this.m_MeshRender.material = this._CommonMaterial;
		}
		if (this.method_1())
		{
			if (!this._playerObj.activeSelf)
			{
				this._playerObj.SetActive(true);
			}
		}
		else
		{
			this._playerObj.SetActive(false);
		}
	}

	// Token: 0x06002C09 RID: 11273 RVA: 0x0001CF1D File Offset: 0x0001B11D
	public void OnMouseOver()
	{
		if (this.m_bLocked)
		{
			return;
		}
		if (!this.m_bMouseOver)
		{
			this.m_bMouseOver = true;
			this.m_MeshRender.material = this._SelectMaterial;
		}
	}

	// Token: 0x06002C0A RID: 11274 RVA: 0x0001CF48 File Offset: 0x0001B148
	public void OnMouseExit()
	{
		if (this.m_bLocked)
		{
			return;
		}
		if (this.m_bMouseOver)
		{
			this.m_bMouseOver = false;
			this.m_MeshRender.material = this._CommonMaterial;
		}
	}

	// Token: 0x06002C0B RID: 11275 RVA: 0x0001CF73 File Offset: 0x0001B173
	public void OnMouseUp()
	{
		if (this.m_bLocked)
		{
			return;
		}
		if (this.method_1())
		{
			return;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WorldMapSelectView>().Boolean_1 = false;
		MonoSingleton<GameFlowManager>.Instance.method_8(int.Parse(this.m_LevelID));
	}

	// Token: 0x06002C0C RID: 11276 RVA: 0x0001CFB1 File Offset: 0x0001B1B1
	private bool method_1()
	{
		return MonoSingleton<AppManager>.Instance.m_playlistId == int.Parse(this.m_LevelID);
	}

	// Token: 0x04001F14 RID: 7956
	private bool m_bMouseOver;

	// Token: 0x04001F15 RID: 7957
	private bool m_bLocked;

	// Token: 0x04001F16 RID: 7958
	private string m_LevelID;

	// Token: 0x04001F17 RID: 7959
	private MeshRenderer m_MeshRender;

	// Token: 0x04001F18 RID: 7960
	private Material _CommonMaterial;

	// Token: 0x04001F19 RID: 7961
	private Material _SelectMaterial;

	// Token: 0x04001F1A RID: 7962
	private Material _LockMaterial;

	// Token: 0x04001F1B RID: 7963
	private GameObject _playerObj;
}
