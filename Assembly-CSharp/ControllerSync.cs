using System;
using System.IO;
using ns0;
using UnityEngine;

// Token: 0x02000AAE RID: 2734
public class ControllerSync : MonoBehaviour, IPhotonSerializeView
{
	// Token: 0x1700077C RID: 1916
	// (get) Token: 0x06004A33 RID: 18995 RVA: 0x000308DE File Offset: 0x0002EADE
	// (set) Token: 0x06004A34 RID: 18996 RVA: 0x000308E6 File Offset: 0x0002EAE6
	public PhotonView photonView { get; set; }

	// Token: 0x06004A35 RID: 18997 RVA: 0x0013484C File Offset: 0x00132A4C
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null)
			{
				EntityPlayer entityPlayer = (EntityPlayer)localPlayer.GetEntity();
				if (entityPlayer != null)
				{
					if (entityPlayer.vmethod_25().PlayerState_0 != PlayerInfoSync.PlayerState.Spawned)
					{
						return;
					}
					InstanceInput component = entityPlayer.GetComponent<InstanceInput>();
					InputFrame[] array;
					component.FlushOutgoingInputs(out array);
					stream.SendNext(entityPlayer.transform.position);
					stream.SendNext(component.currentInput.m_flags);
					stream.SendNext(component.currentInput.m_yaw);
					stream.SendNext(component.currentInput.m_pitch);
					return;
				}
			}
		}
		else if (MonoSingleton<Session>.Instance != null)
		{
			PhotonPlayer sender = info.sender;
			if (sender != null)
			{
				PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(sender.ActorId);
				if (playerInfoSync)
				{
					Entity entity = playerInfoSync.GetEntity();
					if (entity)
					{
						InstanceInput component2 = entity.GetComponent<InstanceInput>();
						if (component2 != null)
						{
							Vector3 position = (Vector3)stream.ReceiveNext();
							byte flags = (byte)stream.ReceiveNext();
							float yaw = (float)stream.ReceiveNext();
							float pitch = (float)stream.ReceiveNext();
							entity.transform.position = position;
							InputFrame inputFrame = default(InputFrame);
							inputFrame.m_flags = flags;
							inputFrame.m_yaw = yaw;
							inputFrame.m_pitch = pitch;
							StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
							if (currentSession != null)
							{
								StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
								if (personalStatSheet != null)
								{
									personalStatSheet.SetPingQuality(NetworkManager.GetPingById(sender.ActorId));
								}
							}
							component2.EnqueueIncomingInputs(new InputFrame[] { inputFrame });
						}
					}
				}
			}
		}
	}

	// Token: 0x06004A36 RID: 18998 RVA: 0x001349C4 File Offset: 0x00132BC4
	private byte[] Serialize(InputFrame[] inputFrame_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < inputFrame_0.Length; i++)
		{
			memoryStream.Write(InputFrame.Serialize(inputFrame_0[i]), 0, InputFrame.FrameLength());
		}
		return memoryStream.ToArray();
	}

	// Token: 0x06004A37 RID: 18999 RVA: 0x00134A08 File Offset: 0x00132C08
	private void Deserialize(byte[] byte_0, out InputFrame[] inputFrame_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		int num = byte_0.Length / InputFrame.FrameLength();
		memoryStream.Write(byte_0, 0, byte_0.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		inputFrame_0 = new InputFrame[num];
		for (int i = 0; i < num; i++)
		{
			byte[] array = new byte[InputFrame.FrameLength()];
			memoryStream.Read(array, 0, InputFrame.FrameLength());
			inputFrame_0[i] = InputFrame.Deserialize(array);
		}
	}
}
