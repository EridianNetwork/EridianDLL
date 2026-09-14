using System;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class Action
{
	// Token: 0x1700015D RID: 349
	// (get) Token: 0x060019F3 RID: 6643 RVA: 0x0001328B File Offset: 0x0001148B
	// (set) Token: 0x060019F4 RID: 6644 RVA: 0x00013293 File Offset: 0x00011493
	public float m_actionDelay { get; private set; }

	// Token: 0x060019F5 RID: 6645 RVA: 0x0001329C File Offset: 0x0001149C
	public virtual void Start(Entity entity)
	{
		this.m_entity = entity;
		this.m_actionDelay = 0f;
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_0(this, entity);
	}

	// Token: 0x060019F6 RID: 6646 RVA: 0x000132BC File Offset: 0x000114BC
	public virtual void vmethod_0(Entity entity_0)
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_1(this);
		this.m_entity = null;
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x000132D0 File Offset: 0x000114D0
	public void method_0()
	{
		if (Time.time - this.m_actionTimeStamp > 0.03333f && Time.fixedTime - this.m_actionTimeStampFX > 0.03333f && this.m_isEntityAction)
		{
			this.method_4();
		}
		this.method_1();
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x0008696C File Offset: 0x00084B6C
	private void method_1()
	{
		this.LastActionMessage = (global::Action.ActionMessage)this.m_actionBuffer.PeekAt(0);
		if (this.LastActionMessage != null)
		{
			if (this.LastActionMessage.m_isEcho)
			{
				if (this.LastActionMessage.m_sender.ActorId != NetworkManager.GetActorId())
				{
					this.m_param = this.LastActionMessage.m_param;
					(this as Echo).OnEcho();
				}
				this.m_actionBuffer.Dequeue();
				return;
			}
			Entity entity = this.m_entity;
			if (this.m_entity is EntityWeapon)
			{
				entity = (this.m_entity as EntityWeapon).m_owner;
			}
			EntityPlayer entityPlayer = entity as EntityPlayer;
			if (entityPlayer)
			{
				bool flag = true;
				EntityPlayer relatedPlayer = entityPlayer.m_relatedPlayer;
				if (relatedPlayer != null && NetworkManager.smethod_3())
				{
					int frameNum = relatedPlayer.method_43().currentInput.m_frameNum;
					flag = this.LastActionMessage.m_frameNum <= frameNum || frameNum == 0;
				}
				if (this.m_isLocalAction)
				{
					flag = true;
				}
				if (flag)
				{
					this.m_actionDelay = 0f;
					if (!this.m_isLocalAction)
					{
						this.m_actionDelay = Time.time - this.LastActionMessage.m_time + (float)this.LastActionMessage.m_TimeDelayInNetwork;
						if (relatedPlayer)
						{
							this.m_actionDelay += InterpolateManager.GetDefaultInterpolationTime() + NetworkManager.GetPingById(relatedPlayer.vmethod_25().m_id) / 2f;
						}
					}
					if (!this.m_isActionRunning && this.LastActionMessage.m_actionOrCut)
					{
						this.m_param = this.LastActionMessage.m_param;
						this.vmethod_5();
					}
					if (this.m_isActionRunning && !this.LastActionMessage.m_actionOrCut)
					{
						this.vmethod_4();
					}
					this.m_isActionRunning = this.LastActionMessage.m_actionOrCut;
					this.m_actionBuffer.Dequeue();
				}
			}
			else
			{
				float num = 0f;
				if (this.m_isLocalAction)
				{
					num = Mathf.Min(NetworkManager.smethod_9(), 1f);
				}
				if (Time.time - this.LastActionMessage.m_time > num)
				{
					if (!this.m_isActionRunning && this.LastActionMessage.m_actionOrCut)
					{
						this.m_param = this.LastActionMessage.m_param;
						this.vmethod_5();
					}
					if (this.m_isActionRunning && !this.LastActionMessage.m_actionOrCut)
					{
						this.vmethod_4();
					}
					this.m_isActionRunning = this.LastActionMessage.m_actionOrCut;
					this.m_actionBuffer.Dequeue();
				}
			}
		}
		if (this.m_isActionRunning)
		{
			this.vmethod_3();
		}
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x0001330C File Offset: 0x0001150C
	public virtual void vmethod_1(int int_0)
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_14(this.method_5(), this.m_entity, int_0, 0);
	}

	// Token: 0x060019FA RID: 6650 RVA: 0x00013326 File Offset: 0x00011526
	public virtual void vmethod_2(Vector3 vector3_0)
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_15(this.method_5(), this.m_entity, vector3_0, 0);
	}

	// Token: 0x060019FB RID: 6651 RVA: 0x00013340 File Offset: 0x00011540
	public void method_2(int int_0)
	{
		if (!this.m_isEntityAction)
		{
			AuthoritativeActionManager.AuthoritativeActionManager_0.method_11(this.method_5(), this.m_entity, int_0);
			this.m_isEntityAction = true;
		}
		this.m_actionTimeStamp = Time.time;
		this.m_actionTimeStampFX = Time.fixedTime;
	}

	// Token: 0x060019FC RID: 6652 RVA: 0x0001337E File Offset: 0x0001157E
	public void method_3(Vector3 vector3_0)
	{
		if (!this.m_isEntityAction)
		{
			AuthoritativeActionManager.AuthoritativeActionManager_0.method_12(this.method_5(), this.m_entity, vector3_0);
			this.m_isEntityAction = true;
		}
		this.m_actionTimeStamp = Time.time;
		this.m_actionTimeStampFX = Time.fixedTime;
	}

	// Token: 0x060019FD RID: 6653 RVA: 0x000133BC File Offset: 0x000115BC
	private void method_4()
	{
		if (this.m_isEntityAction)
		{
			AuthoritativeActionManager.AuthoritativeActionManager_0.method_13(this.method_5(), this.m_entity, 0);
			this.m_isEntityAction = false;
		}
	}

	// Token: 0x060019FE RID: 6654 RVA: 0x00086BEC File Offset: 0x00084DEC
	public virtual void OnStartAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x00086C28 File Offset: 0x00084E28
	public virtual void OnStartAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, Vector3 param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
	}

	// Token: 0x06001A00 RID: 6656 RVA: 0x00086C64 File Offset: 0x00084E64
	public virtual void OnStopAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(false, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
	}

	// Token: 0x06001A01 RID: 6657 RVA: 0x00086CA0 File Offset: 0x00084EA0
	public virtual void OnSingleAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(false, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
	}

	// Token: 0x06001A02 RID: 6658 RVA: 0x00086D00 File Offset: 0x00084F00
	public virtual void OnSingleAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, Vector3 param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(false, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, false));
	}

	// Token: 0x06001A03 RID: 6659 RVA: 0x00086D60 File Offset: 0x00084F60
	public virtual void OnEchoCall(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, true));
	}

	// Token: 0x06001A04 RID: 6660 RVA: 0x00086D9C File Offset: 0x00084F9C
	public virtual void OnEchoCall(bool local, double networkTimestamp, double networkDelayTime, int frameCount, Vector3 param, PhotonPlayer sender)
	{
		this.m_isLocalAction = local;
		this.m_actionBuffer.Enqueue(new global::Action.ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param, sender, true));
	}

	// Token: 0x06001A05 RID: 6661 RVA: 0x000133E4 File Offset: 0x000115E4
	public int method_5()
	{
		return AuthoritativeActionManager.AuthoritativeActionManager_0.method_2(this);
	}

	// Token: 0x06001A06 RID: 6662 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_3()
	{
	}

	// Token: 0x06001A07 RID: 6663 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_4()
	{
	}

	// Token: 0x06001A08 RID: 6664 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x04001170 RID: 4464
	private RingBuffer m_actionBuffer = new RingBuffer(10, false);

	// Token: 0x04001171 RID: 4465
	protected Entity m_entity;

	// Token: 0x04001172 RID: 4466
	private bool m_isEntityAction;

	// Token: 0x04001173 RID: 4467
	private float m_actionTimeStamp;

	// Token: 0x04001174 RID: 4468
	private float m_actionTimeStampFX;

	// Token: 0x04001175 RID: 4469
	private bool m_isActionRunning;

	// Token: 0x04001176 RID: 4470
	private bool m_isLocalAction;

	// Token: 0x04001177 RID: 4471
	protected global::Action.ActionMessage LastActionMessage;

	// Token: 0x04001178 RID: 4472
	protected object m_param;

	// Token: 0x02000412 RID: 1042
	public class ActionMessage
	{
		// Token: 0x06001A09 RID: 6665 RVA: 0x00086DD8 File Offset: 0x00084FD8
		public ActionMessage(bool bool_0, float float_0, double double_0, double double_1, int int_0, object object_0, PhotonPlayer photonPlayer_0, bool bool_1 = false)
		{
			this.m_actionOrCut = bool_0;
			this.m_time = float_0;
			this.m_TimeDelayInNetwork = double_1;
			this.m_frameNum = int_0;
			this.m_param = object_0;
			this.m_networkTimeStamp = double_0;
			this.m_sender = photonPlayer_0;
			this.m_isEcho = bool_1;
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06001A0A RID: 6666 RVA: 0x000133F1 File Offset: 0x000115F1
		// (set) Token: 0x06001A0B RID: 6667 RVA: 0x000133F9 File Offset: 0x000115F9
		public bool m_actionOrCut { get; private set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06001A0C RID: 6668 RVA: 0x00013402 File Offset: 0x00011602
		// (set) Token: 0x06001A0D RID: 6669 RVA: 0x0001340A File Offset: 0x0001160A
		public float m_time { get; private set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06001A0E RID: 6670 RVA: 0x00013413 File Offset: 0x00011613
		// (set) Token: 0x06001A0F RID: 6671 RVA: 0x0001341B File Offset: 0x0001161B
		public double m_TimeDelayInNetwork { get; private set; }

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06001A10 RID: 6672 RVA: 0x00013424 File Offset: 0x00011624
		// (set) Token: 0x06001A11 RID: 6673 RVA: 0x0001342C File Offset: 0x0001162C
		public double m_networkTimeStamp { get; private set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06001A12 RID: 6674 RVA: 0x00013435 File Offset: 0x00011635
		// (set) Token: 0x06001A13 RID: 6675 RVA: 0x0001343D File Offset: 0x0001163D
		public int m_frameNum { get; private set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06001A14 RID: 6676 RVA: 0x00013446 File Offset: 0x00011646
		// (set) Token: 0x06001A15 RID: 6677 RVA: 0x0001344E File Offset: 0x0001164E
		public object m_param { get; private set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06001A16 RID: 6678 RVA: 0x00013457 File Offset: 0x00011657
		// (set) Token: 0x06001A17 RID: 6679 RVA: 0x0001345F File Offset: 0x0001165F
		public PhotonPlayer m_sender { get; private set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x00013468 File Offset: 0x00011668
		// (set) Token: 0x06001A19 RID: 6681 RVA: 0x00013470 File Offset: 0x00011670
		public bool m_isEcho { get; private set; }
	}
}
