using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020004A4 RID: 1188
public class MarkManager : MonoBehaviour
{
	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06001FDB RID: 8155 RVA: 0x00016197 File Offset: 0x00014397
	public static MarkManager MarkManager_0
	{
		get
		{
			return MarkManager.s_instance;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06001FDC RID: 8156 RVA: 0x0001619E File Offset: 0x0001439E
	public MarkBroadcast MarkBroadcast_0
	{
		get
		{
			return this.m_broadcast;
		}
	}

	// Token: 0x06001FDD RID: 8157 RVA: 0x000161A6 File Offset: 0x000143A6
	private void Awake()
	{
		MarkManager.s_instance = this;
		this.m_titleCrl = new MarkTitleController();
		this.m_titleCrl.method_0();
		this.m_broadcast = base.GetComponent<MarkBroadcast>();
	}

	// Token: 0x06001FDE RID: 8158 RVA: 0x000161D0 File Offset: 0x000143D0
	private void LateUpdate()
	{
		this.m_titleCrl.OnLateUpdate();
	}

	// Token: 0x06001FDF RID: 8159 RVA: 0x000161DD File Offset: 0x000143DD
	public void OnGetMarkedInfo(MarkManager.BroadcastMarkedInfo _info)
	{
		this.m_receiveBuffer[_info.m_entity_id] = _info;
		this.m_titleCrl.OnGetTitleInfo(_info);
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x0000311D File Offset: 0x0000131D
	public bool method_0(Entity entity_0)
	{
		return false;
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x00003727 File Offset: 0x00001927
	public MarkManager.BroadcastMarkedInfo method_1()
	{
		return null;
	}

	// Token: 0x06001FE2 RID: 8162 RVA: 0x000161FD File Offset: 0x000143FD
	public float method_2()
	{
		return (float)this.m_markProgress_client / 100f;
	}

	// Token: 0x0400148E RID: 5262
	public const int m_MaxMarkNum = 3;

	// Token: 0x0400148F RID: 5263
	private static MarkManager s_instance;

	// Token: 0x04001490 RID: 5264
	public MarkTitleController m_titleCrl;

	// Token: 0x04001491 RID: 5265
	private MarkBroadcast m_broadcast;

	// Token: 0x04001492 RID: 5266
	public MarkManager.ESlowdownType m_slowdown_type;

	// Token: 0x04001493 RID: 5267
	public Dictionary<int, MarkManager.BroadcastMarkedInfo> m_broadcastBuffer = new Dictionary<int, MarkManager.BroadcastMarkedInfo>();

	// Token: 0x04001494 RID: 5268
	private Dictionary<int, MarkManager.BroadcastMarkedInfo> m_receiveBuffer = new Dictionary<int, MarkManager.BroadcastMarkedInfo>();

	// Token: 0x04001495 RID: 5269
	public int m_markProgress_client;

	// Token: 0x020004A5 RID: 1189
	public enum ESlowdownType
	{
		// Token: 0x04001497 RID: 5271
		BeingMarking,
		// Token: 0x04001498 RID: 5272
		InMarkState
	}

	// Token: 0x020004A6 RID: 1190
	public class BroadcastMarkedInfo
	{
		// Token: 0x06001FE3 RID: 8163 RVA: 0x0001620C File Offset: 0x0001440C
		public BroadcastMarkedInfo(int int_0, int int_1)
		{
			this.m_entity_id = int_0;
			this.m_mark_level = int_1;
		}

		// Token: 0x06001FE4 RID: 8164 RVA: 0x00016222 File Offset: 0x00014422
		public static int smethod_0()
		{
			return 8;
		}

		// Token: 0x06001FE5 RID: 8165 RVA: 0x00016225 File Offset: 0x00014425
		public Entity method_0()
		{
			if (this.m_entity == null)
			{
				this.m_entity = BadAssNetworkView.smethod_4(this.m_entity_id);
			}
			return this.m_entity;
		}

		// Token: 0x06001FE6 RID: 8166 RVA: 0x0009BF34 File Offset: 0x0009A134
		public static byte[] smethod_1(MarkManager.BroadcastMarkedInfo broadcastMarkedInfo_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes(broadcastMarkedInfo_0.m_entity_id), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(broadcastMarkedInfo_0.m_mark_level), 0, 4);
			return memoryStream.ToArray();
		}

		// Token: 0x06001FE7 RID: 8167 RVA: 0x0009BF74 File Offset: 0x0009A174
		public static MarkManager.BroadcastMarkedInfo smethod_2(byte[] byte_0)
		{
			MarkManager.BroadcastMarkedInfo broadcastMarkedInfo = new MarkManager.BroadcastMarkedInfo(0, 0);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_0, 0, byte_0.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[4];
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_entity_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_mark_level = BitConverter.ToInt32(array, 0);
			return broadcastMarkedInfo;
		}

		// Token: 0x04001499 RID: 5273
		public int m_entity_id;

		// Token: 0x0400149A RID: 5274
		public int m_mark_level;

		// Token: 0x0400149B RID: 5275
		private Entity m_entity;
	}
}
