using System;
using System.IO;
using Photon;
using UnityEngine;

// Token: 0x02000AB8 RID: 2744
public class MarkBroadcast : global::Photon.MonoBehaviour
{
	// Token: 0x06004A73 RID: 19059 RVA: 0x00030B00 File Offset: 0x0002ED00
	private void Start()
	{
		this.m_markMgr = base.GetComponent<MarkManager>();
	}

	// Token: 0x06004A74 RID: 19060 RVA: 0x00135828 File Offset: 0x00133A28
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (!stream.IsWriting)
		{
			byte[] array = (byte[])stream.ReceiveNext();
			MemoryStream memoryStream = new MemoryStream();
			int num = array.Length / MarkManager.BroadcastMarkedInfo.smethod_0();
			memoryStream.Write(array, 0, array.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			int num2 = MarkManager.BroadcastMarkedInfo.smethod_0();
			for (int i = 0; i < num; i++)
			{
				byte[] array2 = new byte[num2];
				memoryStream.Read(array2, 0, num2);
				this.m_markMgr.OnGetMarkedInfo(MarkManager.BroadcastMarkedInfo.smethod_2(array2));
			}
		}
	}

	// Token: 0x06004A75 RID: 19061 RVA: 0x001358B0 File Offset: 0x00133AB0
	[RPC]
	private void RPC_H2A_ToggleMarking(int _id, float _slowdown, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.smethod_4(_id);
		if (entity)
		{
			entity.vmethod_57(_slowdown);
		}
	}

	// Token: 0x06004A76 RID: 19062 RVA: 0x001358D4 File Offset: 0x00133AD4
	[RPC]
	private void RPC_H2A_ToggleInMarkState(int _id, bool _inMarkState, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.smethod_4(_id);
		if (entity)
		{
			entity.vmethod_58(_inMarkState);
		}
	}

	// Token: 0x04003631 RID: 13873
	private MarkManager m_markMgr;
}
