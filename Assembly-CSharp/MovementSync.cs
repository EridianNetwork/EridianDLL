using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000ABE RID: 2750
public class MovementSync : MonoBehaviour, IPhotonView, IPhotonSerializeView, IPhotonEvaluate
{
	// Token: 0x17000785 RID: 1925
	// (get) Token: 0x06004A97 RID: 19095 RVA: 0x00030C75 File Offset: 0x0002EE75
	// (set) Token: 0x06004A98 RID: 19096 RVA: 0x00030C7D File Offset: 0x0002EE7D
	public PhotonView photonView { get; set; }

	// Token: 0x17000786 RID: 1926
	// (get) Token: 0x06004A99 RID: 19097 RVA: 0x00030C86 File Offset: 0x0002EE86
	// (set) Token: 0x06004A9A RID: 19098 RVA: 0x00030C8E File Offset: 0x0002EE8E
	public Vector3 localVelocity { get; private set; }

	// Token: 0x17000787 RID: 1927
	// (get) Token: 0x06004A9B RID: 19099 RVA: 0x00030C97 File Offset: 0x0002EE97
	// (set) Token: 0x06004A9C RID: 19100 RVA: 0x00030C9F File Offset: 0x0002EE9F
	public Vector3 Velocity { get; private set; }

	// Token: 0x06004A9D RID: 19101 RVA: 0x00030CA8 File Offset: 0x0002EEA8
	public Vector3 GetVelocity()
	{
		return this.Velocity;
	}

	// Token: 0x06004A9E RID: 19102 RVA: 0x00030CB0 File Offset: 0x0002EEB0
	public Vector3 GetInterpolatedVelocity()
	{
		if (this.m_interpolater == null)
		{
			return Vector3.zero;
		}
		return this.m_interpolater.method_12();
	}

	// Token: 0x17000788 RID: 1928
	// (get) Token: 0x06004A9F RID: 19103 RVA: 0x00030CCB File Offset: 0x0002EECB
	// (set) Token: 0x06004AA0 RID: 19104 RVA: 0x00030CDE File Offset: 0x0002EEDE
	public float Single_0
	{
		get
		{
			return this.m_interpolater.method_4() / 2f;
		}
		private set
		{
			this.Single_0 = value;
		}
	}

	// Token: 0x06004AA1 RID: 19105 RVA: 0x00135E0C File Offset: 0x0013400C
	private void Awake()
	{
		this.m_clientTimePos = new RingBuffer(3000, true);
		this.m_hostTimePos = new RingBuffer(300, true);
		this.m_clientOfHostTimePos = new RingBuffer(300, true);
		this.m_interpolater = new InterpolateManager(this, null);
		this.m_extrapolatedBuffer = new RingBuffer(300, true);
	}

	// Token: 0x06004AA2 RID: 19106 RVA: 0x00135E6C File Offset: 0x0013406C
	private void Start()
	{
		this.m_entity = base.GetComponent<Entity>();
		this.m_characterMotor = (IBadAssCharacterMotor)base.GetComponent(typeof(IBadAssCharacterMotor));
		if (!NetworkManager.smethod_5() && this.photonView != null && !this.photonView.Boolean_1)
		{
			this.myPosAtServerTime = this.correctPlayerPos;
		}
		this.m_interpolater.method_3(this.m_entity.vmethod_14());
	}

	// Token: 0x06004AA3 RID: 19107 RVA: 0x00135EE4 File Offset: 0x001340E4
	public byte BuildAnimationFlags(EntityPlayer entityPlayer_0)
	{
		if (entityPlayer_0 == null)
		{
			return 0;
		}
		if (entityPlayer_0.method_43() == null)
		{
			return 0;
		}
		byte b = 0;
		if (entityPlayer_0.method_43().IsRunning())
		{
			b |= 1;
		}
		if (entityPlayer_0.method_43().IsCrouching())
		{
			b |= 64;
		}
		if (entityPlayer_0.method_43().IsJumping())
		{
			b |= 2;
		}
		if (entityPlayer_0.method_43().IsMoving())
		{
			b |= 4;
		}
		if (entityPlayer_0.method_43().IsAiming())
		{
			b |= 128;
		}
		return b;
	}

	// Token: 0x06004AA4 RID: 19108 RVA: 0x00135F70 File Offset: 0x00134170
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
			if (this.m_entity == null)
			{
				return;
			}
			if (entityPlayer != null && entityPlayer.vmethod_25() == null)
			{
				return;
			}
			if (entityPlayer != null && entityPlayer.vmethod_25().PlayerState_0 != PlayerInfoSync.PlayerState.Spawned)
			{
				return;
			}
			stream.SendNext(base.transform.position);
			stream.SendNext((short)(base.transform.localEulerAngles.y * 100f));
			if (entityPlayer != null)
			{
				stream.SendNext(entityPlayer.method_43().currentInput.m_frameNum);
				stream.SendNext(this.BuildAnimationFlags(entityPlayer));
				stream.SendNext((short)entityPlayer.method_43().currentInput.m_pitch16);
			}
			else if (this.m_entity is EntityNpc)
			{
				stream.SendNext((short)(this.m_animationTime * 100f));
				stream.SendNext((short)(this.m_speed * 100f));
				stream.SendNext((short)(this.m_turnAngle * 100f));
			}
		}
		else
		{
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			short num = (short)stream.ReceiveNext();
			float num2 = (float)((ushort)num / 100);
			int num3 = 0;
			EntityPlayer entityPlayer2 = this.m_entity as EntityPlayer;
			if (entityPlayer2 != null)
			{
				num3 = (int)stream.ReceiveNext();
				byte b = (byte)stream.ReceiveNext();
				short num4 = (short)stream.ReceiveNext();
				PlayerInfoSync playerInfoSync = entityPlayer2.vmethod_25();
				if (playerInfoSync != null && !playerInfoSync.IsMyActor())
				{
					((PlayerAnimationManagerFSM)entityPlayer2.vmethod_12()).method_40(b, num4);
				}
			}
			else if (this.m_entity is EntityNpc)
			{
				short num5 = (short)stream.ReceiveNext();
				this.m_animationTime = (float)((ushort)num5 / 100);
				num5 = (short)stream.ReceiveNext();
				this.m_speed = (float)((ushort)num5 / 100);
				num5 = (short)stream.ReceiveNext();
				this.m_turnAngle = (float)num5 / 100f;
			}
			this.correctPlayerRot = Quaternion.Euler(0f, num2, 0f);
			this.m_lastRecvClientTime = (double)Time.time;
			TimePos timePos = new TimePos(this.m_lastRecvClientTime, this.correctPlayerPos, this.correctPlayerRot, info.Double_0, num3);
			TimePos timePos2 = (TimePos)this.m_hostTimePos.PeekLast();
			if (timePos2 == null || timePos2.m_frameNum != timePos.m_frameNum || timePos2.m_networkTimeStamp != timePos.m_networkTimeStamp)
			{
				if (timePos.m_networkTimeStamp >= this.m_teleportNetworkTimeStamp)
				{
					this.m_hostTimePos.Enqueue(timePos);
					this.m_interpolater.OnNewTPArrived(timePos);
				}
			}
		}
	}

	// Token: 0x06004AA5 RID: 19109 RVA: 0x00136260 File Offset: 0x00134460
	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
		Session prop_ = MonoSingleton<Session>.Instance;
		if (prop_ != null)
		{
			if (prop_.method_16())
			{
				PlayerInfoSync playerInfoSync = prop_.TryGetPlayerInfoSyncById(player.ActorId);
				if (playerInfoSync != null)
				{
					Entity entity = playerInfoSync.GetEntity();
					if (entity != null)
					{
						float num = Vector3.Distance(entity.transform.position, base.transform.position);
						priority.priority = Mathf.Max(40 * (int)num, 500);
						if (this.m_entity is EntityPlayer && this.m_entity.vmethod_25().m_id == player.ActorId)
						{
							priority.priority = 130;
						}
					}
				}
			}
			priority.priority = 0;
		}
		this.lastEvaluatedPriority = priority.priority;
	}

	// Token: 0x06004AA6 RID: 19110 RVA: 0x00136324 File Offset: 0x00134524
	private void FixedUpdate()
	{
		if (this.m_entity != null && this.m_teleportRequests.Count > 0)
		{
			for (int i = 0; i < this.m_teleportRequests.Count; i++)
			{
				this.ApplyTeleport(this.m_teleportRequests[i].m_pos, this.m_teleportRequests[i].m_rot);
			}
			this.m_teleportRequests.Clear();
		}
		int num = Time.frameCount;
		if (this.m_entity is EntityPlayer)
		{
			num = (this.m_entity as EntityPlayer).method_43().currentInput.m_frameNum;
		}
		TimePos timePos = new TimePos((double)Time.time, base.transform.position, num);
		if (this.m_clientTimePos.GetCount() == 0)
		{
			this.m_clientTimePos.Enqueue(timePos);
		}
		else
		{
			TimePos timePos2 = (TimePos)this.m_clientTimePos.PeekLast();
			if (!timePos2.Equals(timePos))
			{
				this.m_clientTimePos.Enqueue(timePos);
			}
		}
		if (!NetworkManager.smethod_5())
		{
			if (this.photonView != null)
			{
				if (this.m_entity.vmethod_26())
				{
					this.ApplyLocalPredictedPosition();
				}
				else if (this.m_followServerMovement)
				{
					this.ApplyServerInterpolatedPosition();
				}
			}
		}
		else
		{
			int count = this.m_clientTimePos.GetCount();
			if (count > 4)
			{
				TimePos timePos3 = (TimePos)this.m_clientTimePos.PeekAt(count - 1);
				TimePos timePos4 = (TimePos)this.m_clientTimePos.PeekAt(count - 5);
				Vector3 vector = timePos3.m_position - timePos4.m_position;
				double num2 = timePos3.m_time - timePos4.m_time;
				this.Velocity = vector / (float)num2;
				this.localVelocity = base.transform.InverseTransformDirection(this.Velocity);
			}
			else
			{
				this.localVelocity = Vector3.zero;
				this.Velocity = Vector3.zero;
			}
		}
		if (this.m_enableFallProtection)
		{
			this.method_12();
		}
	}

	// Token: 0x06004AA7 RID: 19111 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x06004AA8 RID: 19112 RVA: 0x00136518 File Offset: 0x00134718
	private void ApplyTeleport(Vector3 vector3_0, Quaternion quaternion_0)
	{
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
		{
			"DoTeleportMe ",
			this.m_entity.name,
			" - before : pos ",
			base.transform.position,
			" - rot ",
			base.transform.rotation,
			" teleportRot:",
			quaternion_0
		}));
		base.transform.position = vector3_0;
		if (this.m_entity is EntityPlayer)
		{
			(this.m_entity as EntityPlayer).method_100(quaternion_0);
		}
		else
		{
			base.transform.rotation = quaternion_0;
			if (this.m_entity != null && this.m_entity.vmethod_12() != null)
			{
				this.m_entity.vmethod_12().OnTeleportMe(vector3_0);
			}
		}
		this.m_clientTimePos.Clear();
		this.m_hostTimePos.Clear();
		this.m_interpolater.method_7();
		this.m_clientOfHostTimePos.Clear();
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
		{
			"DoTeleportMe ",
			this.m_entity.name,
			" - after : pos ",
			base.transform.position,
			" - rot ",
			base.transform.rotation
		}));
		this.m_teleporting = false;
	}

	// Token: 0x06004AA9 RID: 19113 RVA: 0x00136690 File Offset: 0x00134890
	[RPC]
	private void RPC_TeleportMe(Vector3 teleportPos, Quaternion teleportRot, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
		{
			"RPC_TeleportMe  teleportPos: ",
			teleportPos,
			" teleportRot:",
			teleportRot,
			"at:",
			Time.time
		}));
		this.m_teleportRequests.Add(new MovementSync.TeleportRequest(teleportPos, teleportRot));
		this.m_teleporting = true;
		this.m_teleportTimeStamp = Time.fixedTime;
		this.m_teleportNetworkTimeStamp = info.Double_0;
	}

	// Token: 0x06004AAA RID: 19114 RVA: 0x00136718 File Offset: 0x00134918
	public void method_4(Vector3 vector3_0, Quaternion quaternion_0)
	{
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "RequestTeleportMe", vector3_0, ":", quaternion_0 }));
		if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_autoTestCase))
		{
			base.transform.position = vector3_0;
			if (this.m_entity is EntityPlayer)
			{
				(this.m_entity as EntityPlayer).method_100(quaternion_0);
			}
			else
			{
				base.transform.rotation = quaternion_0;
			}
		}
		object[] array = new object[] { vector3_0, quaternion_0 };
		if (this.photonView != null)
		{
			this.photonView.method_4("RPC_TeleportMe", PhotonTargets.All, array);
		}
	}

	// Token: 0x06004AAB RID: 19115 RVA: 0x00030CE7 File Offset: 0x0002EEE7
	public void method_5(bool bool_0)
	{
		this.m_followServerMovement = bool_0;
	}

	// Token: 0x06004AAC RID: 19116 RVA: 0x001367DC File Offset: 0x001349DC
	private void ApplyServerInterpolatedPosition()
	{
		int count = this.m_clientTimePos.GetCount();
		if (count > 4)
		{
			TimePos timePos = (TimePos)this.m_clientTimePos.PeekAt(count - 1);
			TimePos timePos2 = (TimePos)this.m_clientTimePos.PeekAt(count - 5);
			Vector3 vector = timePos.m_position - timePos2.m_position;
			double num = timePos.m_time - timePos2.m_time;
			this.Velocity = vector / (float)num;
			this.localVelocity = base.transform.InverseTransformDirection(this.Velocity);
		}
		else
		{
			this.localVelocity = Vector3.zero;
			this.Velocity = Vector3.zero;
		}
		if (!this.photonView.Boolean_1)
		{
			Vector3 position = base.transform.position;
			Quaternion rotation = base.transform.rotation;
			if (!this.m_interpolater.method_5(ref position, ref rotation))
			{
				this.m_extrapolatedBuffer.Enqueue(position);
			}
			base.transform.position = position;
			base.transform.rotation = rotation;
			int i = this.m_hostTimePos.GetCount();
			while (i >= 2)
			{
				TimePos timePos3 = (TimePos)this.m_hostTimePos.PeekAt(i - 1);
				if (!timePos3.m_position.AlmostEquals(base.transform.position, 0.001f))
				{
					i--;
				}
				else
				{
					if (this.m_listener != null)
					{
						this.m_listener.OnMvtSyncReachPosition(timePos3);
						break;
					}
					break;
				}
			}
		}
	}

	// Token: 0x06004AAD RID: 19117 RVA: 0x00136950 File Offset: 0x00134B50
	private void ApplyLocalPredictedPosition()
	{
		TimePos timePos = (TimePos)m_hostTimePos.PeekLast();
		if (timePos == null || timePos.m_frameNum == -1)
		{
			return;
		}
		if (m_lastProcessedHostTP == null)
		{
			m_lastProcessedHostTP = timePos;
		}
		if (m_lastProcessedHostTP.m_frameNum < timePos.m_frameNum)
		{
			int num = 0;
			m_lastHostNetworkTime = timePos.m_networkTimeStamp;
			double num2 = timePos.m_networkTimeStamp - (double)((float)offset * Time.fixedDeltaTime) - m_lastProcessedHostTP.m_networkTimeStamp;
			num = (int)(num2 / (double)Time.fixedDeltaTime);
			if (num2 - (double)((float)num * Time.fixedDeltaTime) > 0.01600000075995922)
			{
				num++;
			}
			offset += num - (timePos.m_frameNum - offset - m_lastProcessedHostTP.m_frameNum);
			m_lastProcessedHostTP = timePos;
			m_lastHostNetworkTime = timePos.m_networkTimeStamp;
		}
		else
		{
			if (m_lastProcessedHostTP.m_frameNum != timePos.m_frameNum)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "host movement order corrupted:" + timePos.m_frameNum + " should >" + m_lastProcessedHostTP.m_frameNum);
				return;
			}
			if (m_lastHostNetworkTime > timePos.m_networkTimeStamp)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "host movement order corrupted:" + timePos.m_networkTimeStamp + " should >" + m_lastHostNetworkTime);
				return;
			}
			if (!(m_lastHostNetworkTime < timePos.m_networkTimeStamp))
			{
				return;
			}
			int num3 = 0;
			m_lastHostNetworkTime = timePos.m_networkTimeStamp;
			double num4 = timePos.m_networkTimeStamp - (double)((float)offset * Time.fixedDeltaTime) - m_lastProcessedHostTP.m_networkTimeStamp;
			num3 = (int)(num4 / (double)Time.fixedDeltaTime);
			if (num4 - (double)((float)num3 * Time.fixedDeltaTime) > 0.01600000075995922)
			{
				num3++;
			}
			offset += num3;
		}
		Debug.smethod_9(timePos.m_position, Vector3.up, Color.white, 10f);
		bool flag = false;
		if (timePos.m_frameNum <= 0)
		{
			return;
		}
		int num5 = m_clientTimePos.GetCount() - 1;
		while (num5 >= 0)
		{
			TimePos timePos2 = (TimePos)m_clientTimePos.PeekAt(num5);
			if (timePos2.m_frameNum != timePos.m_frameNum)
			{
				num5--;
				continue;
			}
			TimePos timePos3 = timePos2;
			TimePos timePos4 = null;
			float num6 = Vector3.Distance(timePos.m_position, timePos2.m_position);
			if (offset > 0)
			{
				for (int i = -1; i <= offset + 1; i++)
				{
					if (num5 + i < m_clientTimePos.GetCount())
					{
						timePos4 = (TimePos)m_clientTimePos.PeekAt(num5 + i);
						if (timePos4 != null && (double)Vector3.Distance(timePos.m_position, timePos4.m_position) < (double)num6 - 0.1)
						{
							num6 = Vector3.Distance(timePos.m_position, timePos4.m_position);
							timePos3 = timePos4;
						}
					}
				}
			}
			if (offset < 0)
			{
				for (int num7 = 1; num7 >= offset - 1; num7--)
				{
					if (num5 + num7 < m_clientTimePos.GetCount())
					{
						timePos4 = (TimePos)m_clientTimePos.PeekAt(num5 + num7);
						if (timePos4 != null && (double)Vector3.Distance(timePos.m_position, timePos4.m_position) < (double)num6 - 0.1)
						{
							num6 = Vector3.Distance(timePos.m_position, timePos4.m_position);
							timePos3 = timePos4;
						}
					}
				}
			}
			offset = timePos3.m_frameNum - timePos.m_frameNum;
			myPosAtServerTime = timePos3.m_position;
			m_clientOfHostTimePos.Enqueue(new TimePos(timePos3));
			flag = true;
			break;
		}
		if (flag && m_correctingPos)
		{
			Vector3 vector = timePos.m_position - myPosAtServerTime;
			for (int num8 = m_clientTimePos.GetCount() - 1; num8 >= num5; num8--)
			{
				TimePos timePos5 = (TimePos)m_clientTimePos.PeekAt(num8);
				Ray ray = new Ray(timePos5.m_position, vector);
				if (m_characterMotor.imethod_9(ray.origin, ray.direction, vector.magnitude, out var raycastHit_))
				{
					DebugUtils.Log(LogCategory.Network, string.Concat("corrector:", vector.magnitude, " through ", raycastHit_.collider, ":", raycastHit_.distance));
					vector = vector.normalized * Mathf.Max(0f, raycastHit_.distance);
				}
				Debug.smethod_9(timePos5.m_position, vector, Color.green, 100f);
				timePos5.m_position += vector;
			}
			m_LastCorrectDis = vector.magnitude;
			TimePos timePos6 = (TimePos)m_clientTimePos.PeekLast();
			base.transform.position = timePos6.m_position;
		}
		else
		{
			m_LastCorrectDis = 0f;
		}
	}
	// Token: 0x06004AAE RID: 19118 RVA: 0x0000311D File Offset: 0x0000131D
	private bool method_8(RingBuffer ringBuffer_0, double double_0, ref Vector3 vector3_0)
	{
		return false;
	}

	// Token: 0x06004AAF RID: 19119 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_9()
	{
	}

	// Token: 0x06004AB0 RID: 19120 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_10()
	{
	}

	// Token: 0x06004AB1 RID: 19121 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_11()
	{
	}

	// Token: 0x06004AB2 RID: 19122 RVA: 0x00136E94 File Offset: 0x00135094
	private void method_12()
	{
		Vector3 vector = this.m_entity.vmethod_50();
		if (this.m_entity is EntityPlayer && base.transform.position.y + 0.4f < vector.y)
		{
			base.transform.position = vector;
		}
	}

	// Token: 0x06004AB3 RID: 19123 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_13(IMvtSyncListener imvtSyncListener_0)
	{
	}

	// Token: 0x06004AB4 RID: 19124 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_14()
	{
	}

	// Token: 0x06004AB5 RID: 19125 RVA: 0x00136EE8 File Offset: 0x001350E8
	private void OnDrawGizmos()
	{
		if (this.drawHostTP && this.m_hostTimePos != null)
		{
			int num = 0;
			int num2 = this.m_hostTimePos.GetCount() - 1;
			while (num2 >= 0 && num < 30)
			{
				TimePos timePos = (TimePos)this.m_hostTimePos.PeekAt(num2);
				Gizmos.color = Color.black;
				Gizmos.DrawSphere(timePos.m_position, 0.06f);
				num++;
				num2--;
			}
		}
		if (this.drawClientTP && this.m_clientTimePos != null)
		{
			int num3 = 0;
			int num4 = this.m_clientTimePos.GetCount() - 1;
			while (num4 >= 0 && num3 < 30)
			{
				num3++;
				TimePos timePos2 = (TimePos)this.m_clientTimePos.PeekAt(num4);
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(timePos2.m_position, 0.055f);
				num4--;
			}
		}
		if (this.drawExtraClientTP && this.m_clientTimePos != null)
		{
			int num5 = 0;
			int num6 = this.m_extrapolatedBuffer.GetCount() - 1;
			while (num6 >= 0 && num5 < 30)
			{
				num5++;
				Gizmos.color = Color.red;
				Gizmos.DrawSphere((Vector3)this.m_extrapolatedBuffer.PeekAt(num6), 0.055f);
				num6--;
			}
		}
		if (this.m_clientOfHostTimePos != null)
		{
			int num7 = 0;
			int num8 = this.m_clientOfHostTimePos.GetCount() - 1;
			while (num8 >= 0 && num7 < 30)
			{
				num7++;
				TimePos timePos3 = (TimePos)this.m_clientOfHostTimePos.PeekAt(num8);
				Gizmos.color = Color.magenta;
				Gizmos.DrawSphere(timePos3.m_position, 0.05f);
				num8--;
			}
		}
		Gizmos.DrawRay(new Ray(base.gameObject.transform.position, this.localVelocity));
	}

	// Token: 0x04003646 RID: 13894
	[HideInInspector]
	public float m_animationTime;

	// Token: 0x04003647 RID: 13895
	[HideInInspector]
	public float m_speed;

	// Token: 0x04003648 RID: 13896
	[HideInInspector]
	public float m_turnAngle;

	// Token: 0x04003649 RID: 13897
	public bool m_debug;

	// Token: 0x0400364A RID: 13898
	public bool drawHostTP = true;

	// Token: 0x0400364B RID: 13899
	public bool drawClientTP = true;

	// Token: 0x0400364C RID: 13900
	public bool drawExtraClientTP = true;

	// Token: 0x0400364D RID: 13901
	public bool m_correctingPos = true;

	// Token: 0x0400364E RID: 13902
	private RingBuffer m_clientTimePos;

	// Token: 0x0400364F RID: 13903
	private RingBuffer m_hostTimePos;

	// Token: 0x04003650 RID: 13904
	private RingBuffer m_clientOfHostTimePos;

	// Token: 0x04003651 RID: 13905
	private RingBuffer m_extrapolatedBuffer;

	// Token: 0x04003652 RID: 13906
	private Entity m_entity;

	// Token: 0x04003653 RID: 13907
	private double m_lastHostNetworkTime;

	// Token: 0x04003654 RID: 13908
	private TimePos m_lastProcessedHostTP;

	// Token: 0x04003655 RID: 13909
	private IBadAssCharacterMotor m_characterMotor;

	// Token: 0x04003656 RID: 13910
	private InterpolateManager m_interpolater;

	// Token: 0x04003657 RID: 13911
	public int lastEvaluatedPriority;

	// Token: 0x04003658 RID: 13912
	private List<MovementSync.TeleportRequest> m_teleportRequests = new List<MovementSync.TeleportRequest>();

	// Token: 0x04003659 RID: 13913
	public MovementSync.BlendingType m_blendingType;

	// Token: 0x0400365A RID: 13914
	private IMvtSyncListener m_listener;

	// Token: 0x0400365B RID: 13915
	private Vector3 correctPlayerPos = Vector3.zero;

	// Token: 0x0400365C RID: 13916
	private Quaternion correctPlayerRot = Quaternion.identity;

	// Token: 0x0400365D RID: 13917
	private double m_lastRecvClientTime;

	// Token: 0x0400365E RID: 13918
	public double m_serverPackThreshold = 0.20000000298023224;

	// Token: 0x0400365F RID: 13919
	public float m_disThreshold = 0.2f;

	// Token: 0x04003660 RID: 13920
	public float m_blendfactor = 0.2f;

	// Token: 0x04003661 RID: 13921
	public float m_MaxDisByBlend = 1f;

	// Token: 0x04003662 RID: 13922
	private Vector3 myPosAtServerTime = default(Vector3);

	// Token: 0x04003663 RID: 13923
	public bool m_enableMoveLog;

	// Token: 0x04003664 RID: 13924
	public bool m_enableMoveLine;

	// Token: 0x04003665 RID: 13925
	public bool m_enableFallProtection = true;

	// Token: 0x04003666 RID: 13926
	private bool m_followServerMovement = true;

	// Token: 0x04003667 RID: 13927
	public float m_LastCorrectDis;

	// Token: 0x04003668 RID: 13928
	private bool m_teleporting;

	// Token: 0x04003669 RID: 13929
	private float m_teleportTimeStamp;

	// Token: 0x0400366A RID: 13930
	private double m_teleportNetworkTimeStamp = double.NegativeInfinity;

	// Token: 0x0400366B RID: 13931
	private int offset;

	// Token: 0x02000ABF RID: 2751
	private class TeleportRequest
	{
		// Token: 0x06004AB6 RID: 19126 RVA: 0x00030CF0 File Offset: 0x0002EEF0
		public TeleportRequest(Vector3 vector3_0, Quaternion quaternion_0)
		{
			this.m_pos = vector3_0;
			this.m_rot = quaternion_0;
		}

		// Token: 0x0400366F RID: 13935
		public Vector3 m_pos;

		// Token: 0x04003670 RID: 13936
		public Quaternion m_rot;
	}

	// Token: 0x02000AC0 RID: 2752
	public enum BlendingType
	{
		// Token: 0x04003672 RID: 13938
		Perpendicular,
		// Token: 0x04003673 RID: 13939
		Simple,
		// Token: 0x04003674 RID: 13940
		None
	}
}
