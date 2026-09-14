using System;
using ns0;
using UnityEngine;

// Token: 0x02000685 RID: 1669
public class ClaptrapBehaviour : MonoBehaviour
{
	// Token: 0x06002B2C RID: 11052 RVA: 0x000C983C File Offset: 0x000C7A3C
	private void Start()
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == "PRO_Quest_eye_catch_icon")
			{
				m_IconObj = component.GetChild(i).gameObject;
				break;
			}
		}
		if (m_IconObj != null)
		{
			mOriginalScale = m_IconObj.transform.localScale;
			m_IconObj.transform.localScale = 2f * mOriginalScale;
			m_IconObj.SetActive(value: false);
		}
		else
		{
			m_IconObj = base.gameObject;
		}
	}
	// Token: 0x06002B2D RID: 11053 RVA: 0x000C98F8 File Offset: 0x000C7AF8
	private void Update()
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer() || !MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() || this.m_IconObj == null)
		{
			return;
		}
		BadAssFPSCamera badAssFPSCamera = (MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer).method_45();
		if (badAssFPSCamera && badAssFPSCamera.camera)
		{
			if (this.method_0(badAssFPSCamera.camera.WorldToViewportPoint(base.gameObject.transform.position)))
			{
				if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().Boolean_0)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_15(badAssFPSCamera.camera.WorldToScreenPoint(this.m_IconObj.transform.position), badAssFPSCamera.camera.WorldToViewportPoint(this.m_IconObj.transform.position), false, this.mIsBase, this.mTeamId);
				}
			}
			else if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_15(badAssFPSCamera.camera.WorldToScreenPoint(this.m_IconObj.transform.position), badAssFPSCamera.camera.WorldToViewportPoint(this.m_IconObj.transform.position), true, this.mIsBase, this.mTeamId);
			}
			return;
		}
	}

	// Token: 0x06002B2E RID: 11054 RVA: 0x000C9A7C File Offset: 0x000C7C7C
	protected bool method_0(Vector3 vector3_0)
	{
		return vector3_0.z >= 0f && (vector3_0.x > 0f && vector3_0.x < 1f && vector3_0.y > 0f && vector3_0.y < 1f);
	}

	// Token: 0x04001E5D RID: 7773
	public bool mIsBase;

	// Token: 0x04001E5E RID: 7774
	public int mTeamId = -1;

	// Token: 0x04001E5F RID: 7775
	private Vector3 mOriginalScale = new Vector3(1f, 1f, 1f);

	// Token: 0x04001E60 RID: 7776
	protected GameObject m_IconObj;
}
