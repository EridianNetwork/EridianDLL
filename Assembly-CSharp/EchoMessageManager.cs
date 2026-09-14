using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000447 RID: 1095
public class EchoMessageManager : MonoSingleton<global::EchoMessageManager>
{
	// Token: 0x06001AF7 RID: 6903 RVA: 0x0008946C File Offset: 0x0008766C
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/EchoMessages");
		EchoMessagesSetup echoMessagesSetup = new XmlSerializer(typeof(EchoMessagesSetup)).Deserialize(new StringReader(textAsset.text)) as EchoMessagesSetup;
		Resources.UnloadAsset(textAsset);
		for (int i = 0; i < echoMessagesSetup.m_messages.Length; i++)
		{
			echoMessagesSetup.m_messages[i].m_localizedKey = echoMessagesSetup.m_messages[i].m_localizedText;
			echoMessagesSetup.m_messages[i].m_localizedText = LocalizedString.smethod_0(new LocalizedString(echoMessagesSetup.m_messages[i].m_localizedText));
			this.m_messages.Add(echoMessagesSetup.m_messages[i].m_id, echoMessagesSetup.m_messages[i]);
		}
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x00089528 File Offset: 0x00087728
	private void Update()
	{
		if (this.echoMessageIdRandomList.Count != 0)
		{
			if (this.displayTimer <= 0f)
			{
				this.displayTimer = 6f;
				this.randomListIndex = (this.randomListIndex + global::UnityEngine.Random.Range(1, this.echoMessageIdRandomList.Count)) % this.echoMessageIdRandomList.Count;
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8(this.echoMessageIdRandomList[this.randomListIndex]);
				return;
			}
			this.displayTimer -= Time.deltaTime;
		}
	}

	// Token: 0x06001AF9 RID: 6905 RVA: 0x00013939 File Offset: 0x00011B39
	public void method_0(string string_0)
	{
		this.echoMessageIdRandomList.Add(string_0);
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x00013947 File Offset: 0x00011B47
	public void method_1()
	{
		this.echoMessageIdRandomList.Clear();
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x000895B4 File Offset: 0x000877B4
	public EchoMessage method_2(string string_0)
	{
		EchoMessage echoMessage = null;
		this.m_messages.TryGetValue(string_0, out echoMessage);
		return echoMessage;
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x000895D4 File Offset: 0x000877D4
	public void RefreshLocalization()
	{
		foreach (EchoMessage echoMessage in this.m_messages.Values)
		{
			if (!string.IsNullOrEmpty(echoMessage.m_localizedKey))
			{
				echoMessage.m_localizedText = LocalizedString.smethod_0(new LocalizedString(echoMessage.m_localizedKey));
			}
		}
	}

	// Token: 0x040011D2 RID: 4562
	private const int DISPLAY_TIME = 6;

	// Token: 0x040011D3 RID: 4563
	private Dictionary<string, EchoMessage> m_messages = new Dictionary<string, EchoMessage>();

	// Token: 0x040011D4 RID: 4564
	private List<string> echoMessageIdRandomList = new List<string>();

	// Token: 0x040011D5 RID: 4565
	private float displayTimer;

	// Token: 0x040011D6 RID: 4566
	private int randomListIndex = -1;
}
