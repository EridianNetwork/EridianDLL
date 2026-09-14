using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using Photon;

// Token: 0x02000522 RID: 1314
public class LevelObjectSyncManager : MonoBehaviour
{
	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x060021E6 RID: 8678 RVA: 0x00017591 File Offset: 0x00015791
	public static LevelObjectSyncManager LevelObjectSyncManager_0
	{
		get
		{
			return LevelObjectSyncManager.s_instance;
		}
	}

	// Token: 0x060021E7 RID: 8679 RVA: 0x00017598 File Offset: 0x00015798
	private void Awake()
	{
		base.gameObject.transform.parent = MonoSingleton<Session>.Instance.transform;
		if (LevelObjectSyncManager.s_instance != null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "SessionInfo is already initialized");
		}
		LevelObjectSyncManager.s_instance = this;
	}

	// Token: 0x060021E8 RID: 8680 RVA: 0x000175D2 File Offset: 0x000157D2
	public int method_0(LevelObjectSync levelObjectSync_0)
	{
		this.m_levelObjects.Add(levelObjectSync_0);
		return this.m_levelObjects.Count - 1;
	}

	// Token: 0x060021E9 RID: 8681 RVA: 0x000175ED File Offset: 0x000157ED
	public bool method_1(int int_0, ref LevelObjectSync.LevelObjectSyncState levelObjectSyncState_0)
	{
		if (int_0 < this.m_bitArray.Length)
		{
			levelObjectSyncState_0 = ((!this.m_bitArray[int_0]) ? LevelObjectSync.LevelObjectSyncState.Deactivated : LevelObjectSync.LevelObjectSyncState.Activated);
			return true;
		}
		return false;
	}

	// Token: 0x060021EA RID: 8682 RVA: 0x00017614 File Offset: 0x00015814
	public void method_2()
	{
		this.m_levelObjects.Clear();
		this.m_bitArray = new BitArray(0);
	}

	// Token: 0x060021EB RID: 8683 RVA: 0x0001762D File Offset: 0x0001582D
	public int method_3()
	{
		if (this.m_levelObjects == null)
		{
			return 0;
		}
		return this.m_levelObjects.Count;
	}

	// Token: 0x060021EC RID: 8684 RVA: 0x000A1D7C File Offset: 0x0009FF7C
	public LevelObjectSync method_4(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_levelObjects.Count)
		{
			return this.m_levelObjects[int_0];
		}
		DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"LevelObjectSyncManager.GetLevelObjectFromID: id[",
			int_0,
			"] is invalid. Max Id is ",
			this.m_levelObjects.Count
		}));
		return null;
	}

	// Token: 0x060021ED RID: 8685 RVA: 0x000A1DE8 File Offset: 0x0009FFE8
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			if (this.m_bitArray.Length != this.m_levelObjects.Count)
			{
				this.m_bitArray = new BitArray(this.m_levelObjects.Count);
			}
			for (int i = 0; i < this.m_levelObjects.Count; i++)
			{
				this.m_bitArray[i] = this.m_levelObjects[i].method_2() == LevelObjectSync.LevelObjectSyncState.Activated;
			}
			int num = this.m_bitArray.Length / 8 + ((this.m_bitArray.Length % 8 <= 0) ? 0 : 1);
			if (this.m_bitArray.Length > 0 && this.m_byteArray.Length != num)
			{
				this.m_byteArray = new byte[num];
			}
			if (this.m_byteArray.Length > 0)
			{
				this.m_bitArray.CopyTo(this.m_byteArray, 0);
				for (int j = 0; j < this.m_byteArray.Length; j++)
				{
					stream.SendNext(this.m_byteArray[j]);
				}
			}
		}
		else if (stream.Count > 0)
		{
			this.m_byteArray = new byte[stream.Count];
			for (int k = 0; k < this.m_byteArray.Length; k++)
			{
				this.m_byteArray[k] = (byte)stream.ReceiveNext();
			}
			this.m_bitArray = new BitArray(this.m_byteArray);
			if (this.m_levelObjects.Count <= this.m_bitArray.Length)
			{
				for (int l = 0; l < this.m_levelObjects.Count; l++)
				{
					this.m_levelObjects[l].vmethod_0((!this.m_bitArray[l]) ? LevelObjectSync.LevelObjectSyncState.Deactivated : LevelObjectSync.LevelObjectSyncState.Activated);
				}
			}
		}
	}

	// Token: 0x04001692 RID: 5778
	private static LevelObjectSyncManager s_instance;

	// Token: 0x04001693 RID: 5779
	private List<LevelObjectSync> m_levelObjects = new List<LevelObjectSync>();

	// Token: 0x04001694 RID: 5780
	private BitArray m_bitArray = new BitArray(0);

	// Token: 0x04001695 RID: 5781
	private byte[] m_byteArray = new byte[0];
}
