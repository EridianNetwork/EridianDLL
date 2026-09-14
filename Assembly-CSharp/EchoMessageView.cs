using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020006B3 RID: 1715
public class EchoMessageView : BaseView
{
	// Token: 0x06002D26 RID: 11558 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002D27 RID: 11559 RVA: 0x000D4348 File Offset: 0x000D2548
	public override void OnTestGUI()
	{
		Rect rect = default(Rect);
		GUIStyle guistyle = new GUIStyle();
		guistyle.alignment = TextAnchor.MiddleCenter;
		guistyle.fontStyle = FontStyle.Normal;
		guistyle.normal.textColor = Color.white;
		if (this.m_messages == null)
		{
			return;
		}
		UIMessage uimessage = this.m_messages[0];
		if (uimessage != null)
		{
			rect.Set(100f, 0f, 700f, 200f);
			guistyle.fontSize = 40;
			GUI.Label(rect, uimessage.m_text, guistyle);
		}
		uimessage = this.m_messages[4];
		if (uimessage != null)
		{
			rect.Set((float)(Screen.width - 150), 100f, 80f, 30f);
			guistyle.fontSize = 20;
			GUI.Label(rect, uimessage.m_text, guistyle);
		}
		uimessage = this.m_messages[5];
		if (uimessage != null)
		{
			rect.Set((float)(Screen.width - 150), 100f, 80f, 30f);
			guistyle.fontSize = 20;
			GUI.Label(rect, uimessage.m_text, guistyle);
		}
		uimessage = this.m_messages[3];
		if (uimessage != null)
		{
			rect.Set((float)(Screen.width / 2), 5f, 40f, 30f);
			guistyle.fontSize = 30;
			if (uimessage.m_displayCountDown)
			{
				int num = (int)(uimessage.m_decayDate - Time.time) + 1;
				GUI.Label(rect, uimessage.m_text + num, guistyle);
			}
			else
			{
				GUI.Label(rect, uimessage.m_text, guistyle);
			}
		}
	}

	// Token: 0x06002D28 RID: 11560 RVA: 0x0001DC48 File Offset: 0x0001BE48
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002D29 RID: 11561 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002D2A RID: 11562 RVA: 0x0001DFCA File Offset: 0x0001C1CA
	public virtual void vmethod_5(UIMessage uimessage_0)
	{
		this.m_messages = MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_1();
	}

	// Token: 0x06002D2B RID: 11563 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(UIMessage uimessage_0)
	{
	}

	// Token: 0x06002D2C RID: 11564 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7(UIMessage uimessage_0)
	{
	}

	// Token: 0x06002D2D RID: 11565 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8(float float_0)
	{
	}

	// Token: 0x04001FBB RID: 8123
	public static readonly float DEFAUL_DURATION = 5f;

	// Token: 0x04001FBC RID: 8124
	protected UIMessage[] m_messages;
}
