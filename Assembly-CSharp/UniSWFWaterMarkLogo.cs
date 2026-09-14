using System;
using UnityEngine;

// Token: 0x02000B99 RID: 2969
public class UniSWFWaterMarkLogo : MonoBehaviour
{
	// Token: 0x0600501F RID: 20511 RVA: 0x00155470 File Offset: 0x00153670
	private void OnGUI()
	{
		Rect rect = new Rect((float)(Screen.width - this.m_SplashLogo.width) - this.padding, (float)(Screen.height - this.m_SplashLogo.height) - this.padding, (float)this.m_SplashLogo.width, (float)this.m_SplashLogo.height);
		if (Event.current.type.Equals(EventType.Repaint))
		{
			Graphics.DrawTexture(rect, this.m_SplashLogo, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, 0.25f));
		}
	}

	// Token: 0x04003D00 RID: 15616
	public Texture m_SplashLogo;

	// Token: 0x04003D01 RID: 15617
	public float padding = 10f;

	// Token: 0x04003D02 RID: 15618
	protected float m_LastLogoClick;
}
