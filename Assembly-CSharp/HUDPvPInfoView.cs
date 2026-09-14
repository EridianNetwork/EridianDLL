using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006B6 RID: 1718
public class HUDPvPInfoView : BaseView
{
	// Token: 0x06002D36 RID: 11574 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x06002D37 RID: 11575 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnTestGUI()
	{
	}

	// Token: 0x06002D38 RID: 11576 RVA: 0x0001E012 File Offset: 0x0001C212
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		DebugUtils.Log(LogCategory.GUI, "----------------SetVisible");
	}

	// Token: 0x06002D39 RID: 11577 RVA: 0x0001E027 File Offset: 0x0001C227
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_killingInfoQueue = new Queue<HUDPvPInfoView.KillInfo>();
		this.m_scoreInfoQueue = new Queue<HUDPvPInfoView.ScoreInfo>();
	}

	// Token: 0x06002D3A RID: 11578 RVA: 0x0001E045 File Offset: 0x0001C245
	public virtual void Update(float fDeltaTime)
	{
		this.vmethod_7(fDeltaTime);
		this.vmethod_8(fDeltaTime);
	}

	// Token: 0x06002D3B RID: 11579 RVA: 0x0001D78C File Offset: 0x0001B98C
	public override void vmethod_3()
	{
		base.vmethod_3();
	}

	// Token: 0x06002D3C RID: 11580 RVA: 0x0001E055 File Offset: 0x0001C255
	protected void method_3(bool bool_0 = true)
	{
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.vmethod_5), false);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.vmethod_5));
		}
	}

	// Token: 0x06002D3D RID: 11581 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x06002D3E RID: 11582 RVA: 0x000D45E4 File Offset: 0x000D27E4
	public virtual void vmethod_6()
	{
		HUDPvPInfoView.m_PlayerTeamMap.Clear();
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			HUDPvPInfoView.m_PlayerTeamMap.Add(list[i].m_characterId, list[i].m_teamID);
		}
	}

	// Token: 0x06002D3F RID: 11583 RVA: 0x0001E095 File Offset: 0x0001C295
	protected virtual void vmethod_7(float float_0)
	{
		this.m_killInfoVisible = false;
		if (this.m_killingInfoQueue.Count != 0 && this.m_killInfoShowTime > 0f)
		{
			this.m_killInfoShowTime -= float_0;
			this.m_killInfoVisible = true;
			return;
		}
	}

	// Token: 0x06002D40 RID: 11584 RVA: 0x0001E0CE File Offset: 0x0001C2CE
	protected void method_4(bool bool_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_20(bool_0);
	}

	// Token: 0x06002D41 RID: 11585 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_8(float float_0)
	{
	}

	// Token: 0x06002D42 RID: 11586 RVA: 0x000D463C File Offset: 0x000D283C
	public void method_5(PlayerInfoSync playerInfoSync_0, PlayerInfoSync playerInfoSync_1, AttackSubType attackSubType_0, List<ScoringActionType> list_0, bool bool_0)
	{
		HUDPvPInfoView.KillInfo killInfo = new HUDPvPInfoView.KillInfo();
		killInfo.strKiller = playerInfoSync_0.m_name;
		killInfo.strVictim = playerInfoSync_1.m_name;
		killInfo.attackSubType = attackSubType_0;
		this.m_killInfoShowTime = 7f;
		killInfo.scoringActionList = new List<ScoringActionType>(list_0);
		this.m_killingInfoQueue.Enqueue(killInfo);
		if (this.m_killingInfoQueue.Count >= HUDPvPInfoView.m_sMaxKillInfoCount)
		{
			this.m_killingInfoQueue.Dequeue();
		}
		this.m_bKillInfoNeedUpdate = true;
		if (bool_0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				HUDPvPInfoView.ScoreInfo scoreInfo = new HUDPvPInfoView.ScoreInfo();
				scoreInfo.iScore = MonoSingleton<ScoringManager>.Instance.method_7(list_0[i], playerInfoSync_0.GetEntity(), playerInfoSync_1.GetEntity());
				scoreInfo.fTimeLeft = 4f;
				scoreInfo.ScoringType = list_0[i];
				this.m_scoreInfoQueue.Enqueue(scoreInfo);
			}
		}
	}

	// Token: 0x06002D43 RID: 11587 RVA: 0x000D471C File Offset: 0x000D291C
	public void method_6(int int_0)
	{
		string text = "BaseMarkerA";
		string text2 = "BaseMarkerB";
		GameObject gameObject = GameObject.Find(text);
		if (gameObject != null)
		{
			MapObjectMark component = gameObject.GetComponent<MapObjectMark>();
			ClaptrapBehaviour component2 = gameObject.GetComponent<ClaptrapBehaviour>();
			if (component != null && component2 != null)
			{
				component.enabled = int_0 > 0 && int_0 != component2.mTeamId;
			}
		}
		GameObject gameObject2 = GameObject.Find(text2);
		if (gameObject2 != null)
		{
			MapObjectMark component3 = gameObject2.GetComponent<MapObjectMark>();
			ClaptrapBehaviour component4 = gameObject2.GetComponent<ClaptrapBehaviour>();
			if (component3 != null && component4 != null)
			{
				component3.enabled = int_0 > 0 && int_0 != component4.mTeamId;
			}
		}
	}

	// Token: 0x06002D44 RID: 11588 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_9()
	{
	}

	// Token: 0x06002D45 RID: 11589 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_10(bool bool_0)
	{
	}

	// Token: 0x06002D46 RID: 11590 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_11()
	{
	}

	// Token: 0x06002D47 RID: 11591 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_12()
	{
	}

	// Token: 0x06002D48 RID: 11592 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_13(int int_0)
	{
	}

	// Token: 0x06002D49 RID: 11593 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_14()
	{
	}

	// Token: 0x06002D4A RID: 11594 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15(Vector3 vector3_0, Vector3 vector3_1, bool bool_0, bool bool_1 = false, int int_0 = 0)
	{
	}

	// Token: 0x04001FC4 RID: 8132
	private const float m_killInfoDurationInSec = 7f;

	// Token: 0x04001FC5 RID: 8133
	private const float m_scoreInfoDurationInSec = 4f;

	// Token: 0x04001FC6 RID: 8134
	protected Queue<HUDPvPInfoView.KillInfo> m_killingInfoQueue = new Queue<HUDPvPInfoView.KillInfo>();

	// Token: 0x04001FC7 RID: 8135
	protected Queue<HUDPvPInfoView.ScoreInfo> m_scoreInfoQueue = new Queue<HUDPvPInfoView.ScoreInfo>();

	// Token: 0x04001FC8 RID: 8136
	protected static Dictionary<int, int> m_PlayerTeamMap = new Dictionary<int, int>();

	// Token: 0x04001FC9 RID: 8137
	public bool m_bKillInfoNeedUpdate;

	// Token: 0x04001FCA RID: 8138
	protected bool m_killInfoVisible;

	// Token: 0x04001FCB RID: 8139
	private float m_killInfoShowTime;

	// Token: 0x04001FCC RID: 8140
	public static int m_sMaxKillInfoCount = 7;

	// Token: 0x04001FCD RID: 8141
	public static int m_sMaxScoreInfoCount = 5;

	// Token: 0x020006B7 RID: 1719
	public class KillInfo
	{
		// Token: 0x04001FCE RID: 8142
		public string strKiller;

		// Token: 0x04001FCF RID: 8143
		public string strVictim;

		// Token: 0x04001FD0 RID: 8144
		public AttackSubType attackSubType;

		// Token: 0x04001FD1 RID: 8145
		public List<ScoringActionType> scoringActionList;
	}

	// Token: 0x020006B8 RID: 1720
	public class ScoreInfo
	{
		// Token: 0x04001FD2 RID: 8146
		public int iScore;

		// Token: 0x04001FD3 RID: 8147
		public float fTimeLeft;

		// Token: 0x04001FD4 RID: 8148
		public ScoringActionType ScoringType;
	}
}
