using System;
using ns0;
using UnityEngine;

// Token: 0x02000535 RID: 1333
public class WorldMapSelectionController
{
	// Token: 0x06002250 RID: 8784 RVA: 0x000179DD File Offset: 0x00015BDD
	public static bool smethod_0()
	{
		return WorldMapSelectionController._cameraObj != null && WorldMapSelectionController._cameraObj.activeSelf;
	}

	// Token: 0x06002251 RID: 8785 RVA: 0x000179F8 File Offset: 0x00015BF8
	public static void smethod_1()
	{
		if (WorldMapSelectionController._cameraObj != null && WorldMapSelectionController._cameraObj.activeSelf)
		{
			WorldMapSelectionController._cameraObj.SetActive(false);
			WorldMapSelectionController.smethod_3(false);
		}
	}

	// Token: 0x06002252 RID: 8786 RVA: 0x000A337C File Offset: 0x000A157C
	public static void smethod_2()
	{
		GameObject gameObject = GameObject.Find("World Map");
		if (gameObject)
		{
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name == "InstanceSelectionCamera_Floasm")
				{
					WorldMapSelectionController._cameraObj = component.GetChild(i).gameObject;
				}
				else if (component.GetChild(i).gameObject.name.Contains("Pro_Instance_"))
				{
					WorldMapBehaviour component2 = component.GetChild(i).gameObject.GetComponent<WorldMapBehaviour>();
					if (component2 != null)
					{
						component2.method_0();
					}
				}
			}
			bool activeSelf = WorldMapSelectionController._cameraObj.activeSelf;
			WorldMapSelectionController._cameraObj.SetActive(!activeSelf);
			WorldMapSelectionController.smethod_3(!activeSelf);
			MonoSingleton<AppManager>.Instance.method_0().method_15(!activeSelf, "WorldMapSelectionController");
			if (!activeSelf)
			{
				TownBehaviour.m_bCheckWorldMap = true;
			}
		}
	}

	// Token: 0x06002253 RID: 8787 RVA: 0x000A2BFC File Offset: 0x000A0DFC
	public static void smethod_3(bool bool_0)
	{
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (entityPlayer)
		{
			entityPlayer.method_59(bool_0);
		}
	}

	// Token: 0x040016DC RID: 5852
	private static GameObject _cameraObj;
}
