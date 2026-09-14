using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200068F RID: 1679
public class InstanceBehaviour : MonoBehaviour
{
	// Token: 0x06002B77 RID: 11127 RVA: 0x0001CC99 File Offset: 0x0001AE99
	public static int smethod_0()
	{
		if (InstanceBehaviour.m_InstanceList.Count != 0)
		{
			return InstanceBehaviour.m_InstanceList[0];
		}
		return 0;
	}

	// Token: 0x06002B78 RID: 11128 RVA: 0x0001CCB4 File Offset: 0x0001AEB4
	public static bool smethod_1()
	{
		return InstanceBehaviour.m_InstanceList.Count != 0;
	}

	// Token: 0x06002B79 RID: 11129 RVA: 0x000CB4B0 File Offset: 0x000C96B0
	public static bool smethod_2()
	{
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(InstanceBehaviour.m_InstanceList[0]);
		if (playlist == null)
		{
			DebugUtils.Log(LogCategory.Network, "Trying to enter Playlist [" + InstanceBehaviour.m_InstanceList[0] + "]");
			return false;
		}
		return playlist.m_bossName != string.Empty;
	}

	// Token: 0x06002B7A RID: 11130 RVA: 0x000CB510 File Offset: 0x000C9710
	public static string smethod_3()
	{
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(InstanceBehaviour.m_InstanceList[0]);
		if (playlist == null)
		{
			DebugUtils.Log(LogCategory.Network, "Trying to enter Playlist [" + InstanceBehaviour.m_InstanceList[0] + "]");
			return string.Empty;
		}
		return playlist.m_bossName;
	}

	// Token: 0x06002B7B RID: 11131 RVA: 0x000CB568 File Offset: 0x000C9768
	public void Start()
	{
		this.m_bMouseOver = false;
		this.m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		this.m_Animator = base.gameObject.GetComponent<Animator>();
		this.m_Animator.speed = 0f;
		GameObject gameObject = GameObject.Find("Instance Selection");
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
			if (transform.GetChild(i).gameObject.name == "Material_QuestExist")
			{
				this._questMaterial = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (transform.GetChild(i).gameObject.name == "Material_QuestBlue")
			{
				this._dailyQuestMaterial = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
		}
		this.m_MeshRender = base.gameObject.GetComponent<MeshRenderer>();
		transform = base.gameObject.GetComponent<Transform>();
		for (int j = 0; j < transform.childCount; j++)
		{
			if (transform.GetChild(j).gameObject.name == "Pro_Instance_QuestExist")
			{
				this._questObj = transform.GetChild(j).gameObject;
				return;
			}
		}
	}

	// Token: 0x06002B7C RID: 11132 RVA: 0x000CB76C File Offset: 0x000C996C
	public void method_0()
	{
		InstanceBehaviour.m_bCanClick = true;
		this.m_Animator.speed = 1f;
		this.m_Animator.CrossFade("Base Layer.Empty", 0.01f);
		this.m_bLocked = LevelLockingManager.smethod_0().method_12(int.Parse(this.m_LevelID));
		if (this.m_bLocked)
		{
			this.m_MeshRender.material = this._LockMaterial;
		}
		else
		{
			this.m_MeshRender.material = this._CommonMaterial;
		}
		if (this._questObj != null)
		{
			MeshRenderer component = this._questObj.GetComponent<MeshRenderer>();
			NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = QuestUIDataManager.smethod_0().method_19(int.Parse(this.m_LevelID), -1);
			if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				component.material = this._questMaterial;
				this._questObj.SetActive(true);
			}
			else if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				component.material = this._dailyQuestMaterial;
				this._questObj.SetActive(true);
			}
			else
			{
				this._questObj.SetActive(false);
			}
		}
	}

	// Token: 0x06002B7D RID: 11133 RVA: 0x0001CCC6 File Offset: 0x0001AEC6
	public static void smethod_4()
	{
		InstanceBehaviour.m_InstanceList.Clear();
	}

	// Token: 0x06002B7E RID: 11134 RVA: 0x000CB864 File Offset: 0x000C9A64
	public void OnMouseOver()
	{
		if (InstanceBehaviour.m_InstanceList.Contains(int.Parse(this.m_LevelID)))
		{
			InstanceBehaviour.m_FocusedOnSelected = true;
		}
		if (this.m_bLocked)
		{
			return;
		}
		if (!this.method_1())
		{
			return;
		}
		if (!this.m_bMouseOver)
		{
			this.m_bMouseOver = true;
			this.m_MeshRender.material = this._SelectMaterial;
		}
	}

	// Token: 0x06002B7F RID: 11135 RVA: 0x000CB8C0 File Offset: 0x000C9AC0
	public void OnMouseExit()
	{
		if (InstanceBehaviour.m_InstanceList.Contains(int.Parse(this.m_LevelID)))
		{
			InstanceBehaviour.m_FocusedOnSelected = false;
		}
		if (this.m_bLocked)
		{
			return;
		}
		if (!this.method_1())
		{
			return;
		}
		if (this.m_bMouseOver)
		{
			this.m_bMouseOver = false;
			this.m_MeshRender.material = this._CommonMaterial;
		}
	}

	// Token: 0x06002B80 RID: 11136 RVA: 0x0001CCD2 File Offset: 0x0001AED2
	private bool method_1()
	{
		return InstanceBehaviour.m_InstanceList.Count == 0 || InstanceBehaviour.m_InstanceList.Contains(int.Parse(this.m_LevelID));
	}

	// Token: 0x06002B81 RID: 11137 RVA: 0x000CB91C File Offset: 0x000C9B1C
	public static void smethod_5()
	{
		GameObject gameObject = GameObject.Find("Instance Selection");
		Transform component = gameObject.GetComponent<Transform>();
		TownInstanceSelectionControl.smethod_5(false);
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name.Contains("Pro_Instance_"))
			{
				int num = int.Parse(component.GetChild(i).gameObject.name.Substring(component.GetChild(i).gameObject.name.Length - 3, 3));
				if (InstanceBehaviour.m_InstanceList.Contains(num))
				{
					Animator component2 = component.GetChild(i).gameObject.GetComponent<Animator>();
					component2.speed = 1f;
					component2.CrossFade("Base Layer.Quit", 0.01f);
				}
			}
		}
		InstanceBehaviour.m_FocusedOnSelected = false;
		InstanceBehaviour.m_InstanceList.Clear();
	}

	// Token: 0x06002B82 RID: 11138 RVA: 0x000CB9F8 File Offset: 0x000C9BF8
	public void OnMouseUp()
	{
		if (this.m_bLocked)
		{
			return;
		}
		if (!this.method_1())
		{
			return;
		}
		if (InstanceBehaviour.m_bCanClick)
		{
			this.m_Animator.speed = 1f;
			TownInstanceSelectionControl.smethod_5(true);
			this.m_Animator.CrossFade("Base Layer.Start", 0.01f);
			InstanceBehaviour.m_InstanceList.Clear();
			InstanceBehaviour.m_InstanceList.Add(int.Parse(this.m_LevelID));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceView>().vmethod_5();
		}
	}

	// Token: 0x04001E9C RID: 7836
	public static bool m_FocusedOnSelected = false;

	// Token: 0x04001E9D RID: 7837
	private bool m_bMouseOver;

	// Token: 0x04001E9E RID: 7838
	private bool m_bLocked;

	// Token: 0x04001E9F RID: 7839
	private string m_LevelID;

	// Token: 0x04001EA0 RID: 7840
	private Animator m_Animator;

	// Token: 0x04001EA1 RID: 7841
	private MeshRenderer m_MeshRender;

	// Token: 0x04001EA2 RID: 7842
	private Material _CommonMaterial;

	// Token: 0x04001EA3 RID: 7843
	private Material _SelectMaterial;

	// Token: 0x04001EA4 RID: 7844
	private Material _LockMaterial;

	// Token: 0x04001EA5 RID: 7845
	private Material _dailyQuestMaterial;

	// Token: 0x04001EA6 RID: 7846
	private Material _questMaterial;

	// Token: 0x04001EA7 RID: 7847
	private GameObject _questObj;

	// Token: 0x04001EA8 RID: 7848
	public static bool m_bCanClick = true;

	// Token: 0x04001EA9 RID: 7849
	private static List<int> m_InstanceList = new List<int>();
}
