using System;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class PlayerInfoSync : MonoBehaviour, IPhotonView, IPhotonSerializeView
{
	// Token: 0x14000009 RID: 9
	// (add) Token: 0x060020A4 RID: 8356 RVA: 0x00016AA0 File Offset: 0x00014CA0
	// (remove) Token: 0x060020A5 RID: 8357 RVA: 0x00016AB9 File Offset: 0x00014CB9
	public event PlayerInfoSync.OnPlayerStateChanged_Handler Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnPlayerStateChanged = (PlayerInfoSync.OnPlayerStateChanged_Handler)Delegate.Combine(this.OnPlayerStateChanged, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnPlayerStateChanged = (PlayerInfoSync.OnPlayerStateChanged_Handler)Delegate.Remove(this.OnPlayerStateChanged, value);
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x060020A6 RID: 8358 RVA: 0x00016AD2 File Offset: 0x00014CD2
	// (set) Token: 0x060020A7 RID: 8359 RVA: 0x00016ADA File Offset: 0x00014CDA
	public PhotonView photonView { get; set; }

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x060020A8 RID: 8360 RVA: 0x00016AE3 File Offset: 0x00014CE3
	// (set) Token: 0x060020A9 RID: 8361 RVA: 0x00016AEB File Offset: 0x00014CEB
	public PlayerInfoSync.PlayerState PlayerState_0
	{
		get
		{
			return this.m_inner_playerstate;
		}
		set
		{
			if (this.m_inner_playerstate != value)
			{
				this.m_inner_playerstate = value;
				if (this.OnPlayerStateChanged != null)
				{
					this.OnPlayerStateChanged();
				}
			}
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x060020AA RID: 8362 RVA: 0x00016B10 File Offset: 0x00014D10
	// (set) Token: 0x060020AB RID: 8363 RVA: 0x00016B18 File Offset: 0x00014D18
	public int m_bondCurrency { get; private set; }

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x060020AC RID: 8364 RVA: 0x00016B21 File Offset: 0x00014D21
	// (set) Token: 0x060020AD RID: 8365 RVA: 0x00016B29 File Offset: 0x00014D29
	public PhotonPlayer m_photonPlayer { get; private set; }

	// Token: 0x060020AE RID: 8366 RVA: 0x0009F6D8 File Offset: 0x0009D8D8
	public void Awake()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "PlayerInfoSync.Awake() - " + Time.realtimeSinceStartup);
		this.m_isReadyToSync_Host = false;
		Session prop_ = MonoSingleton<Session>.Instance;
		if (prop_ != null)
		{
			prop_.method_27(this);
			base.gameObject.transform.parent = prop_.m_playerDirectory.transform;
		}
	}

	// Token: 0x060020AF RID: 8367 RVA: 0x00016B32 File Offset: 0x00014D32
	public bool IsMyActor()
	{
		return this.m_id == NetworkManager.GetActorId();
	}

	// Token: 0x060020B0 RID: 8368 RVA: 0x00016B41 File Offset: 0x00014D41
	public PhotonPlayer method_1()
	{
		return this.m_photonPlayer;
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x0009F738 File Offset: 0x0009D938
	public int method_2()
	{
		return Convert.ToInt32(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x0009F770 File Offset: 0x0009D970
	public void method_3(object[] object_0, PhotonPlayer photonPlayer_0)
	{
		this.m_photonPlayer = photonPlayer_0;
		this.m_id = (int)object_0[0];
		this.m_name = (string)object_0[1];
		this.m_accountId = (int)object_0[2];
		this.m_characterId = (int)object_0[3];
		this.m_exp = (int)object_0[4];
		this.PlayerState_0 = PlayerInfoSync.PlayerState.None;
		this.m_UtCstartTime = this.method_2();
		MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_6(this);
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			SessionInfo sessionInfo_ = SessionInfo.SessionInfo_0;
			if (sessionInfo_ != null)
			{
				this.m_avatarDna = MonoSingleton<PlayerManager>.Instance.method_2().m_avatarDna;
				sessionInfo_.method_2(0);
			}
		}
		if (this.photonView.Boolean_1)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "mine");
		}
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x00016B49 File Offset: 0x00014D49
	public void OnDestroy()
	{
		if (MonoSingleton<StatisticsManager>.Instance)
		{
			MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_7(this);
		}
		if (MonoSingleton<Session>.Instance)
		{
			MonoSingleton<Session>.Instance.method_28(this);
		}
	}

	// Token: 0x060020B4 RID: 8372 RVA: 0x00016B7E File Offset: 0x00014D7E
	public void method_4(int int_0)
	{
		if (int_0 == this.m_bondCurrency)
		{
			return;
		}
		this.m_bondCurrency = int_0;
		if (this.IsMyActor())
		{
			ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_22();
		}
	}

	// Token: 0x060020B5 RID: 8373 RVA: 0x00016BA3 File Offset: 0x00014DA3
	public Entity GetEntity()
	{
		return this.m_entity;
	}

	// Token: 0x060020B6 RID: 8374 RVA: 0x00016BAB File Offset: 0x00014DAB
	public void method_6(Entity entity_0)
	{
		this.m_entity = entity_0;
	}

	// Token: 0x060020B7 RID: 8375 RVA: 0x0009F840 File Offset: 0x0009DA40
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			if (!this.m_isReadyToSync_Host)
			{
				return;
			}
			stream.SendNext(this.m_id);
			stream.SendNext(this.m_name);
			stream.SendNext(this.m_accountId);
			stream.SendNext(this.m_characterId);
			int num = MonoSingleton<LevelingManager>.Instance.method_3(this.m_avatarDna.method_5(), this.m_exp);
			stream.SendNext(MonoSingleton<LevelingManager>.Instance.method_4(this.m_avatarDna.method_5(), num));
			stream.SendNext((byte)this.m_teamID);
			stream.SendNext((byte)this.m_groupId);
			stream.SendNext((byte)this.PlayerState_0);
			stream.SendNext(this.m_isPlayingCutscene);
			stream.SendNext((byte)this.m_antiAddictionLevel);
			stream.SendNext(this.m_avatarDna.Clone());
		}
		else
		{
			this.m_id = (int)stream.ReceiveNext();
			this.m_name = (string)stream.ReceiveNext();
			this.m_accountId = (int)stream.ReceiveNext();
			this.m_characterId = (int)stream.ReceiveNext();
			int num2 = (int)stream.ReceiveNext();
			this.m_teamID = (int)((byte)stream.ReceiveNext());
			this.m_groupId = (int)((byte)stream.ReceiveNext());
			this.PlayerState_0 = (PlayerInfoSync.PlayerState)((byte)stream.ReceiveNext());
			this.m_isPlayingCutscene = (bool)stream.ReceiveNext();
			this.m_antiAddictionLevel = (AntiAddiction.Level)((byte)stream.ReceiveNext());
			this.m_avatarDna = (AvatarDNA)stream.ReceiveNext();
			if (!this.IsMyActor())
			{
				this.m_exp = num2;
			}
			MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_6(this);
			StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(this);
			if (personalStatSheet != null)
			{
				personalStatSheet.method_8(Mathf.Max(0, num2 - this.m_exp));
			}
		}
	}

	// Token: 0x060020B8 RID: 8376 RVA: 0x00016BB4 File Offset: 0x00014DB4
	[RPC]
	private void RPC_OnReceiveMoney(int bondCurrency)
	{
		this.method_4(bondCurrency);
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x0009FA4C File Offset: 0x0009DC4C
	[RPC]
	private void RPC_OnReceiveExp(int exp)
	{
		int num = MonoSingleton<LevelingManager>.Instance.method_3(this.m_avatarDna.method_5(), this.m_exp);
		int num2 = MonoSingleton<LevelingManager>.Instance.method_3(this.m_avatarDna.method_5(), exp);
		this.m_exp = exp;
		StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(this);
		if (personalStatSheet != null)
		{
			personalStatSheet.method_8(Mathf.Max(0, exp - this.m_exp));
		}
		if (num2 > num)
		{
			MonoSingleton<MessageRelayManager>.Instance.RelayMessage("OnLevelUp", this);
		}
	}

	// Token: 0x04001525 RID: 5413
	private PlayerInfoSync.PlayerState m_inner_playerstate;

	// Token: 0x04001526 RID: 5414
	public int m_id;

	// Token: 0x04001527 RID: 5415
	public string m_name;

	// Token: 0x04001528 RID: 5416
	public int m_accountId;

	// Token: 0x04001529 RID: 5417
	public int m_characterId;

	// Token: 0x0400152A RID: 5418
	public int m_exp;

	// Token: 0x0400152B RID: 5419
	public AvatarDNA m_avatarDna;

	// Token: 0x0400152C RID: 5420
	public int m_teamID;

	// Token: 0x0400152D RID: 5421
	public int m_groupId;

	// Token: 0x0400152E RID: 5422
	public bool m_isInvulnerable;

	// Token: 0x0400152F RID: 5423
	public bool m_canLevelUp = true;

	// Token: 0x04001530 RID: 5424
	public bool m_isPlayingCutscene;

	// Token: 0x04001531 RID: 5425
	public AntiAddiction.Level m_antiAddictionLevel;

	// Token: 0x04001532 RID: 5426
	public int m_UtCstartTime;

	// Token: 0x04001533 RID: 5427
	private Entity m_entity;

	// Token: 0x04001534 RID: 5428
	private int m_previousExp;

	// Token: 0x04001535 RID: 5429
	public bool m_isReadyToSync_Host;

	// Token: 0x04001536 RID: 5430
	private PlayerInfoSync.OnPlayerStateChanged_Handler OnPlayerStateChanged;

	// Token: 0x020004BA RID: 1210
	public enum PlayerState
	{
		// Token: 0x0400153B RID: 5435
		None,
		// Token: 0x0400153C RID: 5436
		PlayerReady,
		// Token: 0x0400153D RID: 5437
		MapReady,
		// Token: 0x0400153E RID: 5438
		PlayerAndMapReady,
		// Token: 0x0400153F RID: 5439
		Spawning,
		// Token: 0x04001540 RID: 5440
		Spawned
	}

	// Token: 0x020004BB RID: 1211
	// (Invoke) Token: 0x060020BB RID: 8379
	public delegate void OnPlayerStateChanged_Handler();
}
