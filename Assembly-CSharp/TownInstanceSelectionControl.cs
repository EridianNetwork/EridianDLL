using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000532 RID: 1330
public class TownInstanceSelectionControl
{
	// Token: 0x0600222E RID: 8750 RVA: 0x0001787B File Offset: 0x00015A7B
	public static bool smethod_0()
	{
		return TownInstanceSelectionControl._cameraObj != null && TownInstanceSelectionControl._cameraObj.activeSelf;
	}

	// Token: 0x0600222F RID: 8751 RVA: 0x00017896 File Offset: 0x00015A96
	public static void smethod_1()
	{
		if (TownInstanceSelectionControl._cameraObj != null)
		{
			InstanceBehaviour.smethod_5();
			TownInstanceSelectionControl.smethod_5(false);
			TownInstanceSelectionControl._cameraObj.SetActive(false);
			TownInstanceSelectionControl.smethod_3(false);
		}
	}

	// Token: 0x06002230 RID: 8752 RVA: 0x000A2B24 File Offset: 0x000A0D24
	public static void smethod_2()
	{
		GameObject gameObject = GameObject.Find("Instance Selection");
		if (gameObject)
		{
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name == "InstanceSelectionCamera_Floasm")
				{
					TownInstanceSelectionControl._cameraObj = component.GetChild(i).gameObject;
				}
				else if (component.GetChild(i).gameObject.name.Contains("Pro_Instance_"))
				{
					InstanceBehaviour component2 = component.GetChild(i).gameObject.GetComponent<InstanceBehaviour>();
					if (component2 != null)
					{
						component2.method_0();
					}
				}
			}
			bool activeSelf;
			if (activeSelf = TownInstanceSelectionControl._cameraObj.activeSelf)
			{
				TownInstanceSelectionControl.smethod_1();
			}
			TownInstanceSelectionControl._cameraObj.SetActive(!activeSelf);
			TownInstanceSelectionControl.smethod_3(!activeSelf);
		}
	}

	// Token: 0x06002231 RID: 8753 RVA: 0x000A2BFC File Offset: 0x000A0DFC
	public static void smethod_3(bool bool_0)
	{
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (entityPlayer)
		{
			entityPlayer.method_59(bool_0);
		}
	}

	// Token: 0x06002232 RID: 8754 RVA: 0x000A2C30 File Offset: 0x000A0E30
	public static List<int> smethod_4()
	{
		TownInstanceSelectionControl.m_InstanceList.Clear();
		GameObject gameObject = GameObject.Find("Instance Selection");
		if (gameObject)
		{
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name.Contains("Pro_Instance_"))
				{
					int num = int.Parse(component.GetChild(i).gameObject.name.Substring(component.GetChild(i).gameObject.name.Length - 3, 3));
					TownInstanceSelectionControl.m_InstanceList.Add(num);
				}
			}
		}
		return TownInstanceSelectionControl.m_InstanceList;
	}

	// Token: 0x06002233 RID: 8755 RVA: 0x000A2CD4 File Offset: 0x000A0ED4
	public static void smethod_5(bool bool_0)
	{
		if (TownInstanceSelectionControl._cameraObj != null)
		{
			DepthOfFieldScatter component = TownInstanceSelectionControl._cameraObj.GetComponent<DepthOfFieldScatter>();
			if (component != null && component.enabled != bool_0)
			{
				component.enabled = bool_0;
			}
		}
	}

	// Token: 0x06002234 RID: 8756 RVA: 0x000178C1 File Offset: 0x00015AC1
	public static void smethod_6()
	{
		if (TownInstanceSelectionControl._mapCameraObj != null)
		{
			TownInstanceSelectionControl._mapCameraObj.SetActive(false);
			TownInstanceSelectionControl.smethod_3(false);
			TownInstanceSelectionControl.smethod_8(MonoSingleton<AppManager>.Instance.m_playlistId);
		}
	}

	// Token: 0x06002235 RID: 8757 RVA: 0x000A2D14 File Offset: 0x000A0F14
	public static void smethod_7()
	{
		GameObject gameObject = GameObject.Find("Final_World_Map");
		if (gameObject)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name == "InstanceSelectionCamera_Floasm")
				{
					TownInstanceSelectionControl._mapCameraObj = component.GetChild(i).gameObject;
				}
				if (component.GetChild(i).gameObject.name.StartsWith("WorldMap_"))
				{
					Transform component2 = component.GetChild(i).gameObject.GetComponent<Transform>();
					for (int j = 0; j < component2.childCount; j++)
					{
						NewInstanceSelBehaviour component3 = component2.GetChild(j).gameObject.GetComponent<NewInstanceSelBehaviour>();
						if (component3 != null)
						{
							if (!LevelLockingManager.smethod_0().method_12(component3.m_nInstanceId) && GroupManager.smethod_0().method_20())
							{
								component2.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								component2.GetChild(j).gameObject.SetActive(false);
							}
						}
					}
				}
			}
			if (TownInstanceSelectionControl._mapCameraObj != null)
			{
				bool activeSelf = TownInstanceSelectionControl._mapCameraObj.activeSelf;
				TownInstanceSelectionControl._mapCameraObj.SetActive(!activeSelf);
				TownInstanceSelectionControl.smethod_3(!activeSelf);
			}
		}
	}

	// Token: 0x06002236 RID: 8758 RVA: 0x000A2E70 File Offset: 0x000A1070
	public static void smethod_8(int int_0)
	{
		GameObject gameObject = GameObject.Find("Final_World_Map");
		if (gameObject)
		{
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name.StartsWith("WorldMap_"))
				{
					TownObjectBehaviour component2 = component.GetChild(i).gameObject.GetComponent<TownObjectBehaviour>();
					if (component2 != null)
					{
						if (component2.m_nTownId == int_0)
						{
							component.GetChild(i).gameObject.SetActive(true);
						}
						else
						{
							component.GetChild(i).gameObject.SetActive(false);
						}
					}
					else
					{
						component.GetChild(i).gameObject.SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x040016CE RID: 5838
	private static GameObject _cameraObj = null;

	// Token: 0x040016CF RID: 5839
	protected static List<int> m_InstanceList = new List<int>();

	// Token: 0x040016D0 RID: 5840
	private static GameObject _mapCameraObj = null;
}
