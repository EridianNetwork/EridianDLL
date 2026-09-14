using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using XsdSettings;

namespace ns0
{
	// Token: 0x020002B9 RID: 697
	public class EchoMessageManager : MonoSingleton<EchoMessageManager>
	{
		// Token: 0x06000EF9 RID: 3833 RVA: 0x000742B0 File Offset: 0x000724B0
		private void Start()
		{
			for (int i = 0; i < this.queue_0.Length; i++)
			{
				this.queue_0[i] = new Queue<UIMessage>();
			}
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0000D24B File Offset: 0x0000B44B
		public UIMessage method_0(UIMessage.GEnum1 genum1_0)
		{
			return this.uimessage_0[(int)genum1_0];
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0000D255 File Offset: 0x0000B455
		public UIMessage[] method_1()
		{
			return this.uimessage_0;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x000742E0 File Offset: 0x000724E0
		public void method_2(UIMessage uimessage_1)
		{
			this.queue_0[(int)uimessage_1.m_type].Enqueue(uimessage_1);
			EchoMessage echoMessage = new EchoMessage();
			echoMessage.m_localizedText = uimessage_1.m_text;
			if (uimessage_1.m_displayCountDown)
			{
				this.method_7(new EchoMessage
				{
					m_displayTargets = new DisplayTarget[] { DisplayTarget.Countdown },
					m_localizedText = uimessage_1.m_duration.ToString()
				});
			}
			if (uimessage_1.m_text != string.Empty)
			{
				echoMessage.m_displayTargets = new DisplayTarget[] { DisplayTarget.LevelNotification };
				this.method_7(echoMessage);
			}
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00074374 File Offset: 0x00072574
		public void method_3(string string_0, DisplayTarget displayTarget_0)
		{
			EchoMessage echoMessage = new EchoMessage();
			echoMessage.m_localizedText = string_0;
			if (!string.IsNullOrEmpty(string_0))
			{
				echoMessage.m_displayTargets = new DisplayTarget[] { displayTarget_0 };
				this.method_7(echoMessage);
			}
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x000743B0 File Offset: 0x000725B0
		public void method_4()
		{
			for (int i = 0; i < this.queue_0.Length; i++)
			{
				this.uimessage_0[i] = null;
				this.queue_0[i].Clear();
			}
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x000743E8 File Offset: 0x000725E8
		public void Update()
		{
			float time = Time.time;
			for (int i = 0; i < this.uimessage_0.Length; i++)
			{
				if (this.uimessage_0[i] != null)
				{
					if (this.uimessage_0[i].m_decayDate < time)
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<EchoMessageView>().vmethod_6(this.uimessage_0[i]);
						this.uimessage_0[i] = null;
					}
					else
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<EchoMessageView>().vmethod_7(this.uimessage_0[i]);
					}
				}
			}
			for (int j = 0; j < this.uimessage_0.Length; j++)
			{
				if (this.uimessage_0[j] == null && this.queue_0[j].Count > 0)
				{
					this.uimessage_0[j] = this.queue_0[j].Dequeue();
					this.uimessage_0[j].m_decayDate = time + this.uimessage_0[j].m_duration;
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<EchoMessageView>().vmethod_5(this.uimessage_0[j]);
				}
			}
			this.method_9();
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x000744EC File Offset: 0x000726EC
		public void method_5(DisplayTarget displayTarget_0, GInterface0 ginterface0_0)
		{
			if (!this.dictionary_0.ContainsKey(displayTarget_0))
			{
				this.dictionary_0.Add(displayTarget_0, new List<GInterface0>());
			}
			if (!this.dictionary_0[displayTarget_0].Contains(ginterface0_0))
			{
				this.dictionary_0[displayTarget_0].Add(ginterface0_0);
			}
			if (!this.list_0.Contains(ginterface0_0))
			{
				this.list_0.Add(ginterface0_0);
			}
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00074558 File Offset: 0x00072758
		public void method_6(GInterface0 ginterface0_0)
		{
			foreach (KeyValuePair<DisplayTarget, List<GInterface0>> keyValuePair in this.dictionary_0)
			{
				if (keyValuePair.Value.Contains(ginterface0_0))
				{
					keyValuePair.Value.Remove(ginterface0_0);
				}
			}
			if (this.list_0.Contains(ginterface0_0))
			{
				this.list_0.Remove(ginterface0_0);
			}
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x000745DC File Offset: 0x000727DC
		public void method_7(EchoMessage echoMessage_0)
		{
			foreach (DisplayTarget displayTarget in echoMessage_0.m_displayTargets)
			{
				if (this.dictionary_0.ContainsKey(displayTarget))
				{
					foreach (GInterface0 ginterface in this.dictionary_0[displayTarget])
					{
						ginterface.imethod_0(echoMessage_0);
					}
				}
			}
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00074660 File Offset: 0x00072860
	public void method_8(string string_0)
	{
		if (!(ns0.MonoSingleton<global::EchoMessageManager>.Instance == null))
		{
			EchoMessage echoMessage = ns0.MonoSingleton<global::EchoMessageManager>.Instance.method_2(string_0);
			if (echoMessage != null)
			{
				method_7(echoMessage);
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.GUI, "Can not find echo message of " + string_0);
			}
		}
	}
		// Token: 0x06000F04 RID: 3844 RVA: 0x000746A4 File Offset: 0x000728A4
		protected void method_9()
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				this.list_0[i].Update();
			}
		}

		// Token: 0x04000D5A RID: 3418
		private Queue<UIMessage>[] queue_0 = new Queue<UIMessage>[6];

		// Token: 0x04000D5B RID: 3419
		private UIMessage[] uimessage_0 = new UIMessage[6];

		// Token: 0x04000D5C RID: 3420
		protected Dictionary<DisplayTarget, List<GInterface0>> dictionary_0 = new Dictionary<DisplayTarget, List<GInterface0>>();

		// Token: 0x04000D5D RID: 3421
		protected List<GInterface0> list_0 = new List<GInterface0>();
	}
}
