using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Photon;
using UnityEngine;

// Token: 0x02000B10 RID: 2832
[AddComponentMenu("Miscellaneous/Photon View")]
public class PhotonView : global::Photon.MonoBehaviour
{
	// Token: 0x170007AE RID: 1966
	// (get) Token: 0x06004C8B RID: 19595 RVA: 0x00031C6D File Offset: 0x0002FE6D
	// (set) Token: 0x06004C8C RID: 19596 RVA: 0x00031C95 File Offset: 0x0002FE95
	public int Int32_0
	{
		get
		{
			if (this.prefixBackup == -1 && PhotonNetwork.networkingPeer != null)
			{
				this.prefixBackup = (int)PhotonNetwork.networkingPeer.currentLevelPrefix;
			}
			return this.prefixBackup;
		}
		set
		{
			this.prefixBackup = value;
		}
	}

	// Token: 0x170007AF RID: 1967
	// (get) Token: 0x06004C8D RID: 19597 RVA: 0x00031C9E File Offset: 0x0002FE9E
	// (set) Token: 0x06004C8E RID: 19598 RVA: 0x00031CC4 File Offset: 0x0002FEC4
	public object[] Object_0
	{
		get
		{
			if (!this.didAwake)
			{
				this.instantiationDataField = PhotonNetwork.networkingPeer.method_39(this.instantiationId);
			}
			return this.instantiationDataField;
		}
		set
		{
			this.instantiationDataField = value;
		}
	}

	// Token: 0x170007B0 RID: 1968
	// (get) Token: 0x06004C8F RID: 19599 RVA: 0x00031CCD File Offset: 0x0002FECD
	// (set) Token: 0x06004C90 RID: 19600 RVA: 0x001419D8 File Offset: 0x0013FBD8
	public int Int32_1
	{
		get
		{
			return this.m_viewID;
		}
		set
		{
			bool flag = this.didAwake && this.subId == 0;
			this.ownerId = value / PhotonNetwork.MAX_VIEW_IDS;
			this.subId = value % PhotonNetwork.MAX_VIEW_IDS;
			this.m_viewID = this.ownerId * PhotonNetwork.MAX_VIEW_IDS + this.subId;
			if (flag)
			{
				PhotonNetwork.networkingPeer.method_50(this);
			}
		}
	}

	// Token: 0x170007B1 RID: 1969
	// (get) Token: 0x06004C91 RID: 19601 RVA: 0x00031CD5 File Offset: 0x0002FED5
	public bool Boolean_0
	{
		get
		{
			return this.ownerId == 0;
		}
	}

	// Token: 0x170007B2 RID: 1970
	// (get) Token: 0x06004C92 RID: 19602 RVA: 0x00031CE0 File Offset: 0x0002FEE0
	public PhotonPlayer PhotonPlayer_0
	{
		get
		{
			if (this.m_owner == null)
			{
				this.m_owner = PhotonPlayer.smethod_0(this.ownerId);
			}
			return this.m_owner;
		}
	}

	// Token: 0x170007B3 RID: 1971
	// (get) Token: 0x06004C93 RID: 19603 RVA: 0x00031D01 File Offset: 0x0002FF01
	public int Int32_2
	{
		get
		{
			return this.ownerId;
		}
	}

	// Token: 0x170007B4 RID: 1972
	// (get) Token: 0x06004C94 RID: 19604 RVA: 0x00031D09 File Offset: 0x0002FF09
	public bool Boolean_1
	{
		get
		{
			return this.ownerId == PhotonNetwork.player.ActorId || (this.Boolean_0 && PhotonNetwork.isMasterClient);
		}
	}

	// Token: 0x170007B5 RID: 1973
	// (get) Token: 0x06004C95 RID: 19605 RVA: 0x00031D30 File Offset: 0x0002FF30
	// (set) Token: 0x06004C96 RID: 19606 RVA: 0x0000311B File Offset: 0x0000131B
	public int Int32_3
	{
		get
		{
			return this.grossSerializeSize + this.grossRPCSize;
		}
		private set
		{
		}
	}

	// Token: 0x170007B6 RID: 1974
	// (get) Token: 0x06004C97 RID: 19607 RVA: 0x00031D3F File Offset: 0x0002FF3F
	// (set) Token: 0x06004C98 RID: 19608 RVA: 0x0000311B File Offset: 0x0000131B
	public int Int32_4
	{
		get
		{
			return this.grossSerializeSizeRCV + this.grossRPCSizeRCV;
		}
		private set
		{
		}
	}

	// Token: 0x06004C99 RID: 19609 RVA: 0x00031D4E File Offset: 0x0002FF4E
	public int method_0(PhotonPlayer photonPlayer_0)
	{
		if (photonPlayer_0 != null && this.m_lastUpdateTimePerPlayer.ContainsKey(photonPlayer_0))
		{
			return (int)(((double)Time.time - this.m_lastUpdateTimePerPlayer[photonPlayer_0]) * 1000.0);
		}
		return int.MaxValue;
	}

	// Token: 0x06004C9A RID: 19610 RVA: 0x00031D85 File Offset: 0x0002FF85
	public int method_1(PhotonPlayer photonPlayer_0)
	{
		if (photonPlayer_0 != null && this.m_updateIntervalPerPlayer.ContainsKey(photonPlayer_0))
		{
			return (int)(this.m_updateIntervalPerPlayer[photonPlayer_0] * 1000.0);
		}
		return int.MaxValue;
	}

	// Token: 0x06004C9B RID: 19611 RVA: 0x00141A3C File Offset: 0x0013FC3C
	public void Awake()
	{
		this.m_viewID = this.ownerId * PhotonNetwork.MAX_VIEW_IDS + this.subId;
		PhotonNetwork.networkingPeer.method_50(this);
		this.instantiationDataField = PhotonNetwork.networkingPeer.method_39(this.instantiationId);
		this.didAwake = true;
		this.bufferedRPC = new List<Pair<Hashtable, PhotonPlayer>>();
		this.preInstantiate = false;
		if (this.observed is IPhotonView)
		{
			IPhotonView photonView = (IPhotonView)this.observed;
			if (photonView.photonView == null)
			{
				photonView.photonView = this;
			}
		}
		this.m_outMessageInfo = new PhotonMessageInfo(PhotonNetwork.networkingPeer.mLocalActor, PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds, this);
	}

	// Token: 0x06004C9C RID: 19612 RVA: 0x00031DB5 File Offset: 0x0002FFB5
	public void OnApplicationQuit()
	{
		if (!AppManager.s_allowQuit)
		{
			return;
		}
		this.destroyedByPhotonNetworkOrQuit = true;
	}

	// Token: 0x06004C9D RID: 19613 RVA: 0x00141AEC File Offset: 0x0013FCEC
	public void OnDestroy()
	{
		PhotonNetwork.networkingPeer.method_51(this);
		if (!this.destroyedByPhotonNetworkOrQuit && !Application.isLoadingLevel)
		{
			if (this.instantiationId > 0)
			{
				DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
				{
					"OnDestroy() seems to be called without PhotonNetwork.Destroy()?! GameObject: ",
					base.gameObject,
					" Application.isLoadingLevel: ",
					Application.isLoadingLevel
				}));
			}
			else if (this.Int32_1 <= 0)
			{
				DebugUtils.LogWarning(LogCategory.Network, string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is 0. Was it ever (manually) set?", this));
			}
			else if (this.Boolean_1 && !PhotonNetwork.manuallyAllocatedViewIds.Contains(this.Int32_1))
			{
				DebugUtils.LogWarning(LogCategory.Network, string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is local (isMine) but not in manuallyAllocatedViewIds list. Use UnAllocateViewID() after you destroyed the PV.", this));
			}
		}
		if (PhotonNetwork.networkingPeer.instantiatedObjects.ContainsKey(this.instantiationId))
		{
			DebugUtils.LogWarning(LogCategory.Network, string.Format("OnDestroy for PhotonView {0} but GO is still in instantiatedObjects. instantiationId: {1}. Use PhotonNetwork.Destroy(). {2}", this, this.instantiationId, (!Application.isLoadingLevel) ? string.Empty : "Loading new scene caused this."));
		}
	}

	// Token: 0x06004C9E RID: 19614 RVA: 0x00031DC6 File Offset: 0x0002FFC6
	public void method_2(string string_0, PhotonTargets photonTargets_0, bool bool_0, params object[] object_0)
	{
		PhotonNetwork.RPC(this, string_0, photonTargets_0, bool_0, object_0);
	}

	// Token: 0x06004C9F RID: 19615 RVA: 0x00031DD3 File Offset: 0x0002FFD3
	public void method_3(string string_0, PhotonPlayer photonPlayer_0, bool bool_0, params object[] object_0)
	{
		PhotonNetwork.RPC(this, string_0, photonPlayer_0, bool_0, object_0);
	}

	// Token: 0x06004CA0 RID: 19616 RVA: 0x00031DE0 File Offset: 0x0002FFE0
	public void method_4(string string_0, PhotonTargets photonTargets_0, params object[] object_0)
	{
		PhotonNetwork.RPC(this, string_0, photonTargets_0, true, object_0);
	}

	// Token: 0x06004CA1 RID: 19617 RVA: 0x00031DEC File Offset: 0x0002FFEC
	public void method_5(string string_0, PhotonPlayer photonPlayer_0, params object[] object_0)
	{
		PhotonNetwork.RPC(this, string_0, photonPlayer_0, true, object_0);
	}

	// Token: 0x06004CA2 RID: 19618 RVA: 0x00031DF8 File Offset: 0x0002FFF8
	public static PhotonView smethod_0(Component component_0)
	{
		return component_0.GetComponent<PhotonView>();
	}

	// Token: 0x06004CA3 RID: 19619 RVA: 0x00031E00 File Offset: 0x00030000
	public static PhotonView smethod_1(GameObject gameObject_0)
	{
		return gameObject_0.GetComponent<PhotonView>();
	}

	// Token: 0x06004CA4 RID: 19620 RVA: 0x00031E08 File Offset: 0x00030008
	public static PhotonView smethod_2(int int_0)
	{
		return PhotonNetwork.networkingPeer.method_49(int_0);
	}

	// Token: 0x06004CA5 RID: 19621 RVA: 0x00141BEC File Offset: 0x0013FDEC
	public override string ToString()
	{
		string text;
		try
		{
			text = string.Format("View ({3}){0} on {1} {2}", new object[]
			{
				this.Int32_1,
				base.gameObject.name,
				(!this.Boolean_0) ? string.Empty : "(scene)",
				this.Int32_0
			});
		}
		catch (Exception)
		{
			text = string.Format("View ({0}) <unavailable>", this.Int32_0);
		}
		return text;
	}

	// Token: 0x06004CA6 RID: 19622 RVA: 0x00031E15 File Offset: 0x00030015
	public bool method_6()
	{
		return !this.m_outStream.IsStreamEmpty();
	}

	// Token: 0x06004CA7 RID: 19623 RVA: 0x00031E25 File Offset: 0x00030025
	public void method_7()
	{
		this.m_outStream.ClearStream();
	}

	// Token: 0x06004CA8 RID: 19624 RVA: 0x00141C78 File Offset: 0x0013FE78
	public void OnSerializeToStream()
	{
		this.m_outStream.ClearStream();
		if (this.observed is IPhotonSerializeView)
		{
			this.m_outMessageInfo.method_0();
			IPhotonSerializeView photonSerializeView = (IPhotonSerializeView)this.observed;
			photonSerializeView.OnPhotonSerializeView(this.m_outStream, this.m_outMessageInfo);
			if (this.m_outStream.Count == 0)
			{
				return;
			}
		}
		else if (this.observed is global::UnityEngine.MonoBehaviour)
		{
			global::UnityEngine.MonoBehaviour monoBehaviour = (global::UnityEngine.MonoBehaviour)this.observed;
			this.m_outMessageInfo.method_0();
			PhotonNetwork.networkingPeer.method_68(monoBehaviour, this.m_outStream, this.m_outMessageInfo);
			if (this.m_outStream.Count == 0)
			{
				return;
			}
		}
		else if (this.observed is Transform)
		{
			Transform transform = (Transform)this.observed;
			if (this.onSerializeTransformOption != OnSerializeTransform.OnlyPosition && this.onSerializeTransformOption != OnSerializeTransform.PositionAndRotation)
			{
				if (this.onSerializeTransformOption != OnSerializeTransform.All)
				{
					this.m_outStream.SendNext(null);
					goto IL_00FA;
				}
			}
			this.m_outStream.SendNext(transform.localPosition);
			IL_00FA:
			if (this.onSerializeTransformOption != OnSerializeTransform.OnlyRotation && this.onSerializeTransformOption != OnSerializeTransform.PositionAndRotation)
			{
				if (this.onSerializeTransformOption != OnSerializeTransform.All)
				{
					this.m_outStream.SendNext(null);
					goto IL_013B;
				}
			}
			this.m_outStream.SendNext(transform.localRotation);
			IL_013B:
			if (this.onSerializeTransformOption == OnSerializeTransform.OnlyScale || this.onSerializeTransformOption == OnSerializeTransform.All)
			{
				this.m_outStream.SendNext(transform.localScale);
			}
		}
		else
		{
			if (!(this.observed is Rigidbody))
			{
				DebugUtils.LogError(LogCategory.Network, "Observed type is not serializable: " + this.observed.GetType());
				return;
			}
			Rigidbody rigidbody = (Rigidbody)this.observed;
			if (this.onSerializeRigidBodyOption != OnSerializeRigidBody.OnlyAngularVelocity)
			{
				this.m_outStream.SendNext(rigidbody.velocity);
			}
			else
			{
				this.m_outStream.SendNext(null);
			}
			if (this.onSerializeRigidBodyOption != OnSerializeRigidBody.OnlyVelocity)
			{
				this.m_outStream.SendNext(rigidbody.angularVelocity);
			}
		}
	}

	// Token: 0x06004CA9 RID: 19625 RVA: 0x00141E70 File Offset: 0x00140070
	public void OnSerializeWrite()
	{
		if (!this.m_outStream.IsStreamEmpty())
		{
			this.m_fullContent = this.m_outStream.data.ToArray();
			this.m_compressedNum = 0;
			this.m_somethingLeftToSend = true;
			if (this.m_compressedBit == null)
			{
				this.m_compressedBit = new BolBitArray(this.m_fullContent.Length);
			}
			this.m_compressedBit.method_4();
			if (this.synchronization == ViewSynchronization.ReliableDeltaCompressed || this.synchronization == ViewSynchronization.UnreliableDeltaCompressed)
			{
				this.m_somethingLeftToSend = this.method_12(this.m_fullContent);
			}
			if (this.m_somethingLeftToSend)
			{
				this.lastTimeDataSend = (double)Time.time;
				this.lastOnSerializeSentFullData = this.m_fullContent;
			}
		}
	}

	// Token: 0x06004CAA RID: 19626 RVA: 0x00141F1C File Offset: 0x0014011C
	public void method_8(PhotonPlayer photonPlayer_0)
	{
		BolBitArray bolBitArray;
		if (this.accCompressedBitRecvPerPlayer.TryGetValue(photonPlayer_0, out bolBitArray))
		{
			bolBitArray.method_7(this.m_compressedBit);
		}
		else
		{
			this.accCompressedBitRecvPerPlayer[photonPlayer_0] = this.m_compressedBit.method_8();
		}
	}

	// Token: 0x06004CAB RID: 19627 RVA: 0x00141F60 File Offset: 0x00140160
	public Hashtable method_9()
	{
		this.m_outEventData.Clear();
		this.m_outEventData[(byte)0] = this.m_viewID;
		this.m_outEventData[(byte)1] = this.m_fullContent;
		return this.m_outEventData;
	}

	// Token: 0x06004CAC RID: 19628 RVA: 0x00141FB4 File Offset: 0x001401B4
	public Hashtable method_10()
	{
		this.m_outEventData.Clear();
		if (this.m_somethingLeftToSend)
		{
			this.m_outEventData[(byte)0] = this.m_viewID;
			if (this.m_compressedNum == 0)
			{
				this.m_outEventData[(byte)1] = this.m_fullContent;
			}
			else
			{
				this.m_outEventData[(byte)2] = this.m_compressedContent;
				if (this.valuesThatAreChangedToNull.Count != 0)
				{
					this.m_outEventData[(byte)3] = this.valuesThatAreChangedToNull.ToArray();
				}
			}
		}
		return this.m_outEventData;
	}

	// Token: 0x06004CAD RID: 19629 RVA: 0x00142058 File Offset: 0x00140258
	public Hashtable method_11(PhotonPlayer photonPlayer_0, bool bool_0)
	{
		this.m_outEventData.Clear();
		if (this.m_somethingLeftToSend || bool_0)
		{
			this.m_outEventData[(byte)0] = this.m_viewID;
			if (!bool_0 && this.m_compressedNum != 0 && this.accCompressedBitRecvPerPlayer[photonPlayer_0].method_3(this.m_compressedBit))
			{
				this.m_outEventData[(byte)2] = this.m_compressedContent;
				if (this.valuesThatAreChangedToNull.Count != 0)
				{
					this.m_outEventData[(byte)3] = this.valuesThatAreChangedToNull.ToArray();
				}
			}
			else
			{
				this.m_outEventData[(byte)1] = this.m_fullContent;
			}
			if (this.accCompressedBitRecvPerPlayer[photonPlayer_0].size != this.m_compressedBit.size)
			{
				this.accCompressedBitRecvPerPlayer[photonPlayer_0].method_2(this.m_compressedBit.size);
			}
			this.accCompressedBitRecvPerPlayer[photonPlayer_0].method_5();
			if (PhotonNetwork.networkingPeer.TrafficStatsEnabled)
			{
				this.grossSerializeSize += Utils.smethod_8(this.m_outEventData);
			}
		}
		return this.m_outEventData;
	}

	// Token: 0x06004CAE RID: 19630 RVA: 0x0014218C File Offset: 0x0014038C
	public void OnSerializeRead(Hashtable data, PhotonPlayer sender, int networkTime, short correctPrefix)
	{
		if (this.Int32_0 > 0 && (int)correctPrefix != this.Int32_0)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Received OnSerialization for view ID ", this.Int32_1, " with prefix ", correctPrefix, ". Our prefix is ", this.Int32_0 }));
			return;
		}
		if (!this.preInstantiate && this.group != 0 && !PhotonNetwork.networkingPeer.allowedReceivingGroups.Contains(this.group))
		{
			return;
		}
		if (PhotonNetwork.networkingPeer.TrafficStatsEnabled)
		{
			this.grossSerializeSizeRCV += Utils.smethod_8(data);
		}
		if (!this.method_13(this, sender, data))
		{
			DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "Skipping packet for ", base.name, " [", this.Int32_1, "] as we haven't received a full packet for delta compression yet. This is OK if it happens for the first few frames after joining a game." }));
			return;
		}
		this.lastOnSerializeDataReceived = data;
		if (sender != null)
		{
			this.lastOnSerializeDataRecvPerPlayer[sender] = data;
		}
		if (this.observed is IPhotonSerializeView)
		{
			object[] array = data[(byte)1] as object[];
			PhotonStream photonStream = new PhotonStream(false, array);
			PhotonMessageInfo photonMessageInfo = new PhotonMessageInfo(sender, networkTime, this);
			IPhotonSerializeView photonSerializeView = (IPhotonSerializeView)this.observed;
			photonSerializeView.OnPhotonSerializeView(photonStream, photonMessageInfo);
		}
		else if (this.observed is global::UnityEngine.MonoBehaviour)
		{
			object[] array2 = data[(byte)1] as object[];
			global::UnityEngine.MonoBehaviour monoBehaviour = (global::UnityEngine.MonoBehaviour)this.observed;
			PhotonStream photonStream2 = new PhotonStream(false, array2);
			PhotonMessageInfo photonMessageInfo2 = new PhotonMessageInfo(sender, networkTime, this);
			PhotonNetwork.networkingPeer.method_68(monoBehaviour, photonStream2, photonMessageInfo2);
		}
		else if (this.observed is Transform)
		{
			object[] array3 = data[(byte)1] as object[];
			Transform transform = (Transform)this.observed;
			if (array3.Length >= 1 && array3[0] != null)
			{
				transform.localPosition = (Vector3)array3[0];
			}
			if (array3.Length >= 2 && array3[1] != null)
			{
				transform.localRotation = (Quaternion)array3[1];
			}
			if (array3.Length >= 3 && array3[2] != null)
			{
				transform.localScale = (Vector3)array3[2];
			}
		}
		else if (this.observed is Rigidbody)
		{
			object[] array4 = data[(byte)1] as object[];
			Rigidbody rigidbody = (Rigidbody)this.observed;
			if (array4.Length >= 1 && array4[0] != null)
			{
				rigidbody.velocity = (Vector3)array4[0];
			}
			if (array4.Length >= 2 && array4[1] != null)
			{
				rigidbody.angularVelocity = (Vector3)array4[1];
			}
		}
		else if (!this.preInstantiate)
		{
			DebugUtils.LogError(LogCategory.Network, "Type of observed is unknown when receiving.");
		}
		this.lastTimeDataRecv = Time.time;
	}

	// Token: 0x06004CAF RID: 19631 RVA: 0x0014245C File Offset: 0x0014065C
	private bool method_12(object[] object_0)
	{
		this.m_compressedNum = 0;
		if (this.lastOnSerializeSentFullData == null)
		{
			return true;
		}
		object[] array = this.lastOnSerializeSentFullData;
		if (object_0 == null)
		{
			return false;
		}
		if (array.Length != object_0.Length)
		{
			this.m_compressedBit.method_2(object_0.Length);
			return true;
		}
		if (this.m_compressedContent == null || object_0.Length != this.m_compressedContent.Length)
		{
			this.m_compressedContent = new object[object_0.Length];
		}
		Array.Clear(this.m_compressedContent, 0, this.m_compressedContent.Length);
		this.valuesThatAreChangedToNull.Clear();
		for (int i = 0; i < this.m_compressedContent.Length; i++)
		{
			object obj = object_0[i];
			object obj2 = array[i];
			if (this.method_14(obj, obj2))
			{
				this.m_compressedNum++;
				this.m_compressedBit.method_0(i, false);
			}
			else
			{
				this.m_compressedContent[i] = object_0[i];
				if (obj == null)
				{
					this.valuesThatAreChangedToNull.Add(i);
				}
			}
		}
		return this.m_compressedNum <= 0 || this.m_compressedNum != object_0.Length;
	}

	// Token: 0x06004CB0 RID: 19632 RVA: 0x00142558 File Offset: 0x00140758
	private bool method_13(PhotonView photonView_0, PhotonPlayer photonPlayer_0, Hashtable hashtable_0)
	{
		if (hashtable_0.ContainsKey((byte)1))
		{
			return true;
		}
		if (photonPlayer_0 == null)
		{
			return false;
		}
		Hashtable hashtable = null;
		if (!photonView_0.lastOnSerializeDataRecvPerPlayer.TryGetValue(photonPlayer_0, out hashtable))
		{
			return false;
		}
		if (hashtable == null)
		{
			return false;
		}
		object[] array = hashtable_0[(byte)2] as object[];
		if (array == null)
		{
			return false;
		}
		int[] array2 = hashtable_0[(byte)3] as int[];
		if (array2 == null)
		{
			array2 = new int[0];
		}
		object[] array3 = photonView_0.lastOnSerializeDataRecvPerPlayer[photonPlayer_0][(byte)1] as object[];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null && !array2.Contains(i))
			{
				object obj = array3[i];
				array[i] = obj;
			}
		}
		hashtable_0[(byte)1] = array;
		return true;
	}

	// Token: 0x06004CB1 RID: 19633 RVA: 0x00142620 File Offset: 0x00140820
	private bool method_14(object object_0, object object_1)
	{
		if (object_0 == null || object_1 == null)
		{
			return object_0 == null && object_1 == null;
		}
		if (!object_0.Equals(object_1))
		{
			if (object_0 is Vector3)
			{
				Vector3 vector = (Vector3)object_0;
				Vector3 vector2 = (Vector3)object_1;
				if (vector.AlmostEquals(vector2, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is Vector2)
			{
				Vector2 vector3 = (Vector2)object_0;
				Vector2 vector4 = (Vector2)object_1;
				if (vector3.AlmostEquals(vector4, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is Quaternion)
			{
				Quaternion quaternion = (Quaternion)object_0;
				Quaternion quaternion2 = (Quaternion)object_1;
				if (quaternion.AlmostEquals(quaternion2, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is float)
			{
				float num = (float)object_0;
				float num2 = (float)object_1;
				if (num.AlmostEquals(num2, PhotonNetwork.precisionForFloatSynchronization))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x06004CB2 RID: 19634 RVA: 0x001426F4 File Offset: 0x001408F4
	private void Update()
	{
		if (this.observed is IPhotonView)
		{
			IPhotonView photonView = (IPhotonView)this.observed;
			if (photonView.photonView == null)
			{
				photonView.photonView = this;
			}
		}
	}

	// Token: 0x06004CB3 RID: 19635 RVA: 0x00142730 File Offset: 0x00140930
	public void method_15(string string_0, int int_0)
	{
		this.grossRPCSize += int_0;
		if (this.sizePerMethod.ContainsKey(string_0))
		{
			Dictionary<string, int> dictionary2;
			Dictionary<string, int> dictionary = (dictionary2 = this.sizePerMethod);
			int num = dictionary2[string_0];
			dictionary[string_0] = num + int_0;
		}
		else
		{
			this.sizePerMethod[string_0] = int_0;
		}
	}

	// Token: 0x06004CB4 RID: 19636 RVA: 0x00142784 File Offset: 0x00140984
	public void method_16(string string_0, int int_0)
	{
		this.grossRPCSizeRCV += int_0;
		if (this.sizePerMethodRCV.ContainsKey(string_0))
		{
			Dictionary<string, int> dictionary2;
			Dictionary<string, int> dictionary = (dictionary2 = this.sizePerMethodRCV);
			int num = dictionary2[string_0];
			dictionary[string_0] = num + int_0;
		}
		else
		{
			this.sizePerMethodRCV[string_0] = int_0;
		}
	}

	// Token: 0x06004CB5 RID: 19637 RVA: 0x00031E32 File Offset: 0x00030032
	public bool method_17()
	{
		return base.enabled && this.synchronization != ViewSynchronization.Off && this.observed != null;
	}

	// Token: 0x06004CB6 RID: 19638 RVA: 0x001427D8 File Offset: 0x001409D8
	public void method_18(PhotonPlayer photonPlayer_0)
	{
		this.lastOnSerializeDataSentPerPlayer.Remove(photonPlayer_0);
		this.lastOnSerializeDataRecvPerPlayer.Remove(photonPlayer_0);
		this.m_lastUpdateTimePerPlayer.Remove(photonPlayer_0);
		this.m_updateIntervalPerPlayer.Remove(photonPlayer_0);
		this.accCompressedBitRecvPerPlayer.Remove(photonPlayer_0);
	}

	// Token: 0x040037F3 RID: 14323
	public int subId;

	// Token: 0x040037F4 RID: 14324
	public int ownerId;

	// Token: 0x040037F5 RID: 14325
	private int m_viewID;

	// Token: 0x040037F6 RID: 14326
	private PhotonPlayer m_owner;

	// Token: 0x040037F7 RID: 14327
	[NonSerialized]
	public List<Pair<Hashtable, PhotonPlayer>> bufferedRPC;

	// Token: 0x040037F8 RID: 14328
	public int group;

	// Token: 0x040037F9 RID: 14329
	public int prefixBackup = -1;

	// Token: 0x040037FA RID: 14330
	public int m_priority;

	// Token: 0x040037FB RID: 14331
	public int m_priorityRunTime;

	// Token: 0x040037FC RID: 14332
	[NonSerialized]
	public bool preInstantiate;

	// Token: 0x040037FD RID: 14333
	[NonSerialized]
	public bool firstSent = true;

	// Token: 0x040037FE RID: 14334
	private object[] instantiationDataField;

	// Token: 0x040037FF RID: 14335
	protected internal Dictionary<PhotonPlayer, object[]> lastOnSerializeDataSentPerPlayer = new Dictionary<PhotonPlayer, object[]>();

	// Token: 0x04003800 RID: 14336
	protected internal Dictionary<PhotonPlayer, Hashtable> lastOnSerializeDataRecvPerPlayer = new Dictionary<PhotonPlayer, Hashtable>();

	// Token: 0x04003801 RID: 14337
	protected internal Dictionary<PhotonPlayer, double> m_lastUpdateTimePerPlayer = new Dictionary<PhotonPlayer, double>();

	// Token: 0x04003802 RID: 14338
	protected internal Dictionary<PhotonPlayer, double> m_updateIntervalPerPlayer = new Dictionary<PhotonPlayer, double>();

	// Token: 0x04003803 RID: 14339
	protected internal BolBitArray m_compressedBit;

	// Token: 0x04003804 RID: 14340
	protected internal Dictionary<PhotonPlayer, BolBitArray> accCompressedBitRecvPerPlayer = new Dictionary<PhotonPlayer, BolBitArray>();

	// Token: 0x04003805 RID: 14341
	protected internal Hashtable lastOnSerializeDataReceived;

	// Token: 0x04003806 RID: 14342
	protected internal object[] lastOnSerializeSentFullData;

	// Token: 0x04003807 RID: 14343
	protected internal object[] lastOnSerializeSentCmpsData;

	// Token: 0x04003808 RID: 14344
	public double lastTimeDataSend;

	// Token: 0x04003809 RID: 14345
	public float lastTimeDataRecv;

	// Token: 0x0400380A RID: 14346
	public Component observed;

	// Token: 0x0400380B RID: 14347
	public SynchronizationDir synchronizationDir;

	// Token: 0x0400380C RID: 14348
	public ViewSynchronization synchronization;

	// Token: 0x0400380D RID: 14349
	public OnSerializeTransform onSerializeTransformOption = OnSerializeTransform.PositionAndRotation;

	// Token: 0x0400380E RID: 14350
	public OnSerializeRigidBody onSerializeRigidBodyOption = OnSerializeRigidBody.All;

	// Token: 0x0400380F RID: 14351
	private PhotonStream m_outStream = new PhotonStream(true, null);

	// Token: 0x04003810 RID: 14352
	private PhotonMessageInfo m_outMessageInfo;

	// Token: 0x04003811 RID: 14353
	private Hashtable m_outEventData = new Hashtable();

	// Token: 0x04003812 RID: 14354
	private object[] m_fullContent;

	// Token: 0x04003813 RID: 14355
	private object[] m_compressedContent;

	// Token: 0x04003814 RID: 14356
	private int m_compressedNum;

	// Token: 0x04003815 RID: 14357
	private List<int> valuesThatAreChangedToNull = new List<int>();

	// Token: 0x04003816 RID: 14358
	private bool m_somethingLeftToSend;

	// Token: 0x04003817 RID: 14359
	public int instantiationId;

	// Token: 0x04003818 RID: 14360
	private bool didAwake;

	// Token: 0x04003819 RID: 14361
	protected internal bool destroyedByPhotonNetworkOrQuit;

	// Token: 0x0400381A RID: 14362
	public int grossSerializeSize;

	// Token: 0x0400381B RID: 14363
	public int grossRPCSize;

	// Token: 0x0400381C RID: 14364
	public Dictionary<string, int> sizePerMethod = new Dictionary<string, int>();

	// Token: 0x0400381D RID: 14365
	public int grossSerializeSizeRCV;

	// Token: 0x0400381E RID: 14366
	public int grossRPCSizeRCV;

	// Token: 0x0400381F RID: 14367
	public Dictionary<string, int> sizePerMethodRCV = new Dictionary<string, int>();
}
