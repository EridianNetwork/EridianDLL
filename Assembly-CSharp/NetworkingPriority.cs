using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B23 RID: 2851
public class NetworkingPriority
{
	// Token: 0x06004D66 RID: 19814 RVA: 0x00148C30 File Offset: 0x00146E30
	private NetworkingPriority()
	{
		this.priorityPerPlayer = new Dictionary<PhotonPlayer, Dictionary<PhotonView, NetworkingPriority.PriorityValue>>();
		this.orderedPhotonViewPerPlayer = new Dictionary<PhotonPlayer, List<PhotonView>>();
	}

	// Token: 0x170007C6 RID: 1990
	// (get) Token: 0x06004D67 RID: 19815 RVA: 0x000323D9 File Offset: 0x000305D9
	public static NetworkingPriority NetworkingPriority_0
	{
		get
		{
			if (NetworkingPriority.s_instance == null)
			{
				NetworkingPriority.s_instance = new NetworkingPriority();
			}
			return NetworkingPriority.s_instance;
		}
	}

	// Token: 0x06004D68 RID: 19816 RVA: 0x000323F1 File Offset: 0x000305F1
	public void method_0()
	{
		this.method_6();
	}

	// Token: 0x06004D69 RID: 19817 RVA: 0x00148C68 File Offset: 0x00146E68
	public List<PhotonView> method_1(PhotonPlayer photonPlayer_0)
	{
		if (this.priorityPerPlayer.ContainsKey(photonPlayer_0))
		{
			IOrderedEnumerable<KeyValuePair<PhotonView, NetworkingPriority.PriorityValue>> orderedEnumerable = this.priorityPerPlayer[photonPlayer_0].OrderBy<KeyValuePair<PhotonView, NetworkingPriority.PriorityValue>, int>(new Func<KeyValuePair<PhotonView, NetworkingPriority.PriorityValue>, int>(NetworkingPriority.smethod_0));
			List<PhotonView> list = null;
			if (!this.orderedPhotonViewPerPlayer.ContainsKey(photonPlayer_0))
			{
				list = new List<PhotonView>();
				this.orderedPhotonViewPerPlayer[photonPlayer_0] = list;
			}
			else
			{
				list = this.orderedPhotonViewPerPlayer[photonPlayer_0];
			}
			list.Clear();
			foreach (KeyValuePair<PhotonView, NetworkingPriority.PriorityValue> keyValuePair in orderedEnumerable)
			{
				list.Add(keyValuePair.Key);
			}
			return list;
		}
		return null;
	}

	// Token: 0x06004D6A RID: 19818 RVA: 0x00148D34 File Offset: 0x00146F34
	public void method_2(PhotonView photonView_0, PhotonPlayer photonPlayer_0)
	{
		Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary = null;
		this.priorityPerPlayer.TryGetValue(photonPlayer_0, out dictionary);
		if (dictionary != null)
		{
			int num = dictionary[photonView_0].runtime - 66;
			if (num < 0)
			{
				num = 0;
			}
			dictionary[photonView_0].runtime = num;
		}
	}

	// Token: 0x06004D6B RID: 19819 RVA: 0x00148D78 File Offset: 0x00146F78
	public void method_3(PhotonView photonView_0, PhotonPlayer photonPlayer_0)
	{
		Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary = null;
		this.priorityPerPlayer.TryGetValue(photonPlayer_0, out dictionary);
		if (dictionary != null)
		{
			dictionary[photonView_0].runtime = dictionary[photonView_0].evaluated;
		}
	}

	// Token: 0x06004D6C RID: 19820 RVA: 0x00148DB4 File Offset: 0x00146FB4
	public void OnRemovePhotonView(PhotonView view)
	{
		foreach (Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary in this.priorityPerPlayer.Values)
		{
			dictionary.Remove(view);
		}
		foreach (List<PhotonView> list in this.orderedPhotonViewPerPlayer.Values)
		{
			list.Remove(view);
		}
	}

	// Token: 0x06004D6D RID: 19821 RVA: 0x000323F9 File Offset: 0x000305F9
	public void method_4()
	{
		this.priorityPerPlayer.Clear();
		this.orderedPhotonViewPerPlayer.Clear();
	}

	// Token: 0x06004D6E RID: 19822 RVA: 0x00032411 File Offset: 0x00030611
	public void method_5(PhotonPlayer photonPlayer_0)
	{
		this.priorityPerPlayer.Remove(photonPlayer_0);
		this.orderedPhotonViewPerPlayer.Remove(photonPlayer_0);
	}

	// Token: 0x06004D6F RID: 19823 RVA: 0x0003242D File Offset: 0x0003062D
	private void method_6()
	{
		this.method_7(PhotonNetwork.player);
	}

	// Token: 0x06004D70 RID: 19824 RVA: 0x00148E54 File Offset: 0x00147054
	private void method_7(PhotonPlayer photonPlayer_0)
	{
		this.m_priority.priority = 0;
		Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary = null;
		if (!this.priorityPerPlayer.TryGetValue(photonPlayer_0, out dictionary))
		{
			dictionary = new Dictionary<PhotonView, NetworkingPriority.PriorityValue>();
			this.priorityPerPlayer.Add(photonPlayer_0, dictionary);
		}
		if (dictionary == null)
		{
			return;
		}
		if (PhotonNetwork.networkingPeer == null)
		{
			return;
		}
		List<PhotonView> list;
		PhotonNetwork.networkingPeer.method_8(out list);
		for (int i = 0; i < list.Count; i++)
		{
			PhotonView photonView = list[i];
			if (photonView.observed is IPhotonEvaluate)
			{
				IPhotonEvaluate photonEvaluate = (IPhotonEvaluate)photonView.observed;
				photonEvaluate.OnPhotonEvaluate(photonPlayer_0, ref this.m_priority);
				this.m_priority.priority = this.m_priority.priority + photonView.m_priority;
			}
			else
			{
				this.m_priority.priority = photonView.m_priority;
			}
			NetworkingPriority.PriorityValue priorityValue = null;
			if (dictionary.TryGetValue(photonView, out priorityValue))
			{
				priorityValue.evaluated = this.m_priority.priority;
			}
			else
			{
				dictionary.Add(photonView, new NetworkingPriority.PriorityValue(this.m_priority.priority, 0));
			}
			if (photonPlayer_0 == this.priorityInspector)
			{
				photonView.m_priorityRunTime = this.m_priority.priority;
			}
		}
	}

	// Token: 0x06004D71 RID: 19825 RVA: 0x00148F78 File Offset: 0x00147178
	public bool method_8(PhotonView photonView_0, PhotonPlayer photonPlayer_0, PhotonChannel photonChannel_0)
	{
		NetworkingPriority.PriorityValue priorityValue = null;
		Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary = null;
		this.priorityPerPlayer.TryGetValue(photonPlayer_0, out dictionary);
		if (dictionary != null && !dictionary.TryGetValue(photonView_0, out priorityValue))
		{
			priorityValue.runtime = photonView_0.m_priority;
		}
		return priorityValue.runtime <= photonChannel_0.m_priorityCeil.priority;
	}

	// Token: 0x06004D72 RID: 19826 RVA: 0x00148FC8 File Offset: 0x001471C8
	public int method_9(PhotonView photonView_0, PhotonPlayer photonPlayer_0)
	{
		if (photonPlayer_0 == null)
		{
			return -1;
		}
		NetworkingPriority.PriorityValue priorityValue = null;
		Dictionary<PhotonView, NetworkingPriority.PriorityValue> dictionary = null;
		this.priorityPerPlayer.TryGetValue(photonPlayer_0, out dictionary);
		if (dictionary != null && dictionary.TryGetValue(photonView_0, out priorityValue))
		{
			return priorityValue.runtime;
		}
		return -1;
	}

	// Token: 0x06004D73 RID: 19827 RVA: 0x0003243A File Offset: 0x0003063A
	[CompilerGenerated]
	private static int smethod_0(KeyValuePair<PhotonView, NetworkingPriority.PriorityValue> keyValuePair_0)
	{
		return keyValuePair_0.Value.runtime;
	}

	// Token: 0x040039FC RID: 14844
	private static NetworkingPriority s_instance;

	// Token: 0x040039FD RID: 14845
	public PhotonPlayer priorityInspector;

	// Token: 0x040039FE RID: 14846
	private Dictionary<PhotonPlayer, Dictionary<PhotonView, NetworkingPriority.PriorityValue>> priorityPerPlayer;

	// Token: 0x040039FF RID: 14847
	private Dictionary<PhotonPlayer, List<PhotonView>> orderedPhotonViewPerPlayer;

	// Token: 0x04003A00 RID: 14848
	private int evaluatedPlayer;

	// Token: 0x04003A01 RID: 14849
	private PhotonPriority m_priority = default(PhotonPriority);

	// Token: 0x02000B24 RID: 2852
	private class PriorityValue
	{
		// Token: 0x06004D74 RID: 19828 RVA: 0x00032448 File Offset: 0x00030648
		public PriorityValue(int int_0, int int_1)
		{
			this.evaluated = int_0;
			this.runtime = int_1;
		}

		// Token: 0x04003A03 RID: 14851
		public int evaluated;

		// Token: 0x04003A04 RID: 14852
		public int runtime;
	}
}
