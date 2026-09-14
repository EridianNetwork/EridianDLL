using System;
using Core;
using UnityEngine;

namespace Photon
{
	// Token: 0x02000B2B RID: 2859
	public class MonoBehaviour : UnityEngine.MonoBehaviour
	{
		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06004D96 RID: 19862 RVA: 0x000325C1 File Offset: 0x000307C1
		public PhotonView photonView
		{
			get
			{
				return PhotonView.smethod_0(this);
			}
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06004D97 RID: 19863 RVA: 0x000325C9 File Offset: 0x000307C9
		public new PhotonView networkView
		{
			get
			{
				DebugUtils.LogWarning(LogCategory.Network, "Why are you still using networkView? should be PhotonView?");
				return PhotonView.smethod_0(this);
			}
		}
	}
}
