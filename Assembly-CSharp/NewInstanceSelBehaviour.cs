using System;
using ns0;
using UnityEngine;

// Token: 0x02000697 RID: 1687
public class NewInstanceSelBehaviour : MonoBehaviour
{
	// Token: 0x06002BC6 RID: 11206 RVA: 0x000CCDC8 File Offset: 0x000CAFC8
	public void Start()
	{
		GameObject gameObject = GameObject.Find("Final_World_Map");
		Transform component = gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == "InstanceSelectionCamera_Floasm")
			{
				m_camera = component.GetChild(i).gameObject.GetComponent<Camera>();
				break;
			}
		}
		GameObject gameObject2 = null;
		Transform transform = base.gameObject.transform;
		for (int j = 0; j < transform.childCount; j++)
		{
			if (transform.GetChild(j).gameObject.name == "UIPosition")
			{
				gameObject2 = transform.GetChild(j).gameObject;
				break;
			}
		}
		if (gameObject2 != null)
		{
			int nTownId = base.gameObject.transform.parent.gameObject.GetComponent<TownObjectBehaviour>().m_nTownId;
			InstanceMapSelectControl.smethod_5(nTownId, m_nInstanceId);
			(ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>() as uniNewInstanceSelectView).method_4(m_bIsTown, m_nInstanceId, nTownId, m_camera.WorldToScreenPoint(gameObject2.transform.position).x, (float)Screen.height - m_camera.WorldToScreenPoint(gameObject2.transform.position).y);
		}
	}
	// Token: 0x04001ECA RID: 7882
	public bool m_bIsTown;

	// Token: 0x04001ECB RID: 7883
	public int m_nInstanceId = 1;

	// Token: 0x04001ECC RID: 7884
	private Camera m_camera;
}
