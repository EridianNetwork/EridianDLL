using System;
using UnityEngine;

namespace ns0
{
	// Token: 0x02000276 RID: 630
	public class MessageRelayManager : MonoSingleton<MessageRelayManager>
	{
		// Token: 0x06000D6E RID: 3438 RVA: 0x0000C753 File Offset: 0x0000A953
		private void OnLevelWasLoaded(int level)
		{
			this.gameObject_0 = GameObject.Find("Gameplay");
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0000C765 File Offset: 0x0000A965
		public void RelayMessage(string string_0, object object_0 = null)
		{
			MonoSingleton<AppManager>.Instance.BroadcastMessage(string_0, object_0, SendMessageOptions.DontRequireReceiver);
			if (this.gameObject_0 != null)
			{
				this.gameObject_0.BroadcastMessage(string_0, object_0, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x04000C33 RID: 3123
		private GameObject gameObject_0;
	}
}
