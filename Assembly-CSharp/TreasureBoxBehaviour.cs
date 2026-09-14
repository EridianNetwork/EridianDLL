using System;
using ns0;
using UnityEngine;

// Token: 0x0200069D RID: 1693
public class TreasureBoxBehaviour : MonoBehaviour
{
	// Token: 0x06002BF0 RID: 11248 RVA: 0x000CEF18 File Offset: 0x000CD118
	public void Start()
	{
		TreasureBoxBehaviour.m_bPlayOpenBox = false;
		TreasureBoxBehaviour.m_bNeedReplay = false;
		TreasureBoxBehaviour.m_RTexture = new RenderTexture(1280, 720, 24);
		TreasureBoxBehaviour.m_RTexture.name = "TreasureBox_RT";
		TreasureBoxBehaviour.m_RTexture.Create();
		if (base.gameObject != null)
		{
			TreasureBoxBehaviour.m_OpenAnimation = base.gameObject.GetComponent<Animation>();
			Transform component = base.gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name == "Camera")
				{
					TreasureBoxBehaviour.m_CameraObj = component.GetChild(i).gameObject;
					TreasureBoxBehaviour.m_Camera = TreasureBoxBehaviour.m_CameraObj.GetComponent<Camera>();
				}
				if (component.GetChild(i).gameObject.name == "Directional light")
				{
					TreasureBoxBehaviour.m_LightObj = component.GetChild(i).gameObject;
				}
				if (component.GetChild(i).gameObject.name == "Crate")
				{
					Transform component2 = component.GetChild(i).gameObject.GetComponent<Transform>();
					for (int j = 0; j < component2.childCount; j++)
					{
						if (component2.GetChild(j).gameObject.name == "PTL_KimBox")
						{
							TreasureBoxBehaviour.m_EffectObj = component2.GetChild(j).gameObject;
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x06002BF1 RID: 11249 RVA: 0x000CF080 File Offset: 0x000CD280
	private void Update()
	{
		if (TreasureBoxBehaviour.m_OpenAnimation.animation.isPlaying)
		{
			TreasureBoxBehaviour.m_Camera.Render();
		}
		else if (TreasureBoxBehaviour.m_bPlayOpenBox)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().vmethod_5(null);
			TreasureBoxBehaviour.m_bPlayOpenBox = false;
			TreasureBoxBehaviour.m_CameraObj.SetActive(false);
			if (TreasureBoxBehaviour.m_LightObj != null)
			{
				TreasureBoxBehaviour.m_LightObj.SetActive(false);
			}
			TreasureBoxBehaviour.m_EffectObj.SetActive(false);
			if (TreasureBoxBehaviour.m_bNeedReplay)
			{
				TreasureBoxBehaviour.m_bNeedReplay = false;
				TreasureBoxBehaviour.smethod_0();
			}
		}
	}

	// Token: 0x06002BF2 RID: 11250 RVA: 0x0001CECE File Offset: 0x0001B0CE
	private void OnDestroy()
	{
		if (TreasureBoxBehaviour.m_RTexture != null)
		{
			TreasureBoxBehaviour.m_RTexture.Release();
			TreasureBoxBehaviour.m_RTexture = null;
		}
	}

	// Token: 0x06002BF3 RID: 11251 RVA: 0x000CF10C File Offset: 0x000CD30C
	public static void smethod_0()
	{
		if (!TreasureBoxBehaviour.m_bPlayOpenBox)
		{
			TreasureBoxBehaviour.m_bPlayOpenBox = true;
			TreasureBoxBehaviour.m_CameraObj.SetActive(true);
			if (TreasureBoxBehaviour.m_LightObj != null)
			{
				TreasureBoxBehaviour.m_LightObj.SetActive(true);
			}
			TreasureBoxBehaviour.m_Camera.clearFlags = CameraClearFlags.Skybox;
			TreasureBoxBehaviour.m_Camera.targetTexture = TreasureBoxBehaviour.m_RTexture;
			TreasureBoxBehaviour.m_Camera.Render();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().vmethod_5(TreasureBoxBehaviour.m_RTexture);
			TreasureBoxBehaviour.m_OpenAnimation.animation.Play();
			TreasureBoxBehaviour.m_EffectObj.SetActive(true);
		}
		else
		{
			TreasureBoxBehaviour.m_bNeedReplay = true;
		}
	}

	// Token: 0x04001ED7 RID: 7895
	private static Camera m_Camera;

	// Token: 0x04001ED8 RID: 7896
	private static Animation m_OpenAnimation;

	// Token: 0x04001ED9 RID: 7897
	private static GameObject m_CameraObj;

	// Token: 0x04001EDA RID: 7898
	private static GameObject m_EffectObj;

	// Token: 0x04001EDB RID: 7899
	private static GameObject m_LightObj;

	// Token: 0x04001EDC RID: 7900
	public static bool m_bPlayOpenBox;

	// Token: 0x04001EDD RID: 7901
	public static bool m_bNeedReplay;

	// Token: 0x04001EDE RID: 7902
	public static RenderTexture m_RTexture;
}
