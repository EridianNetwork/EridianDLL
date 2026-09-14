using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200047F RID: 1151
public class GuidanceTipsManager : MonoSingleton<GuidanceTipsManager>, ICharacterServiceNotificationListerner
{
	// Token: 0x06001E16 RID: 7702 RVA: 0x0000311B File Offset: 0x0000131B
	void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
	{
	}

	// Token: 0x06001E17 RID: 7703 RVA: 0x0000311B File Offset: 0x0000131B
	void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
	{
	}

	// Token: 0x06001E18 RID: 7704 RVA: 0x0000311B File Offset: 0x0000131B
	void ICharacterServiceNotificationListerner.OnSetCharacterSettings(int iResult)
	{
	}

	// Token: 0x06001E19 RID: 7705 RVA: 0x00015241 File Offset: 0x00013441
	void ICharacterServiceNotificationListerner.OnGetCharacterSettings(string strSettings)
	{
		DebugUtils.LogWarning(LogCategory.Gamelogic, "Load setting: = " + strSettings);
		this.method_1(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_27("learned"), ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_27("activetips"));
	}

	// Token: 0x06001E1A RID: 7706 RVA: 0x0000311B File Offset: 0x0000131B
	void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
	{
	}

	// Token: 0x06001E1B RID: 7707 RVA: 0x0000311B File Offset: 0x0000131B
	void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
	{
	}

	// Token: 0x06001E1C RID: 7708 RVA: 0x00095B80 File Offset: 0x00093D80
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/GuidanceTips");
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GuidanceTipsSetup));
		this.m_guidanceTipsSetup = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as GuidanceTipsSetup;
		Resources.UnloadAsset(textAsset);
		this.Reset();
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this);
	}

	// Token: 0x06001E1D RID: 7709 RVA: 0x00095BE0 File Offset: 0x00093DE0
	private void Reset()
	{
		this.m_teachableTips.Clear();
		this.m_activeTips.Clear();
		this.m_learnedTips.Clear();
		for (int i = 0; i < this.m_guidanceTipsSetup.m_tips.Length; i++)
		{
			this.m_teachableTips.Add(this.m_guidanceTipsSetup.m_tips[i]);
		}
	}

	// Token: 0x06001E1E RID: 7710 RVA: 0x00095C40 File Offset: 0x00093E40
	private void method_0()
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < m_guidanceTipsSetup.m_tips.Length; i++)
		{
			GuidanceTip guidanceTip = m_guidanceTipsSetup.m_tips[i];
			for (int j = 0; j < m_learnedTips.Count; j++)
			{
				if (guidanceTip.m_id == m_learnedTips[j].m_id)
				{
					list.Add(i);
					break;
				}
			}
			for (int k = 0; k < m_activeTips.Count; k++)
			{
				if (guidanceTip.m_id == m_activeTips[k].m_id)
				{
					list2.Add(i);
					break;
				}
			}
		}
		ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_26("learned", list);
		ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_26("activetips", list2);
		m_needSave = false;
	}
	// Token: 0x06001E1F RID: 7711 RVA: 0x00095D30 File Offset: 0x00093F30
	public void method_1(List<int> list_0, List<int> list_1)
	{
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[] { "GuidanceTipsManager.LoadLearnings[", list_1.Count, "][", list_0.Count, "]" }));
		this.Reset();
		for (int i = 0; i < list_0.Count; i++)
		{
			int num = Mathf.Clamp(list_0[i], 0, this.m_guidanceTipsSetup.m_tips.Length - 1);
			this.m_teachableTips.Remove(this.m_guidanceTipsSetup.m_tips[num]);
			this.m_learnedTips.Add(this.m_guidanceTipsSetup.m_tips[num]);
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			int num2 = Mathf.Clamp(list_1[j], 0, this.m_guidanceTipsSetup.m_tips.Length - 1);
			this.m_teachableTips.Remove(this.m_guidanceTipsSetup.m_tips[num2]);
			this.m_activeTips.Add(this.m_guidanceTipsSetup.m_tips[num2]);
		}
	}

	// Token: 0x06001E20 RID: 7712 RVA: 0x00095E48 File Offset: 0x00094048
	private void Update()
	{
		if (this.m_needSave)
		{
			this.method_0();
		}
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			return;
		}
		if (this.m_activeTips.Count > 0 && this.m_isTimeToShine)
		{
			DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
			{
				"GuidanceTipsManager.Show Tip[",
				this.m_activeTips[0].m_id,
				"][",
				this.m_activeTips.Count,
				"][",
				this.m_teachableTips.Count,
				"]"
			}));
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8(this.m_activeTips[0].m_echoMsgId);
			this.m_tipTimer.Start(GuidanceTipsManager.s_repeatTime);
			this.m_isTimeToShine = false;
			if (this.m_activeTips[0].m_id == "guidance_friend")
			{
				MonoSingleton<GuidanceTipsManager>.Instance.method_2(this.m_activeTips[0].m_id);
			}
		}
		if (this.m_tipTimer.method_7() || !this.m_tipTimer.method_6())
		{
			this.m_isTimeToShine = true;
		}
	}

	// Token: 0x06001E21 RID: 7713 RVA: 0x00095F90 File Offset: 0x00094190
	public void method_2(string string_0)
	{
		for (int i = this.m_activeTips.Count; i > 0; i--)
		{
			GuidanceTip guidanceTip = this.m_activeTips[i - 1];
			if (guidanceTip.m_id == string_0)
			{
				this.m_activeTips.Remove(guidanceTip);
				this.m_learnedTips.Add(guidanceTip);
				DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"GuidanceTipsManager.CloseTip[",
					guidanceTip.m_id,
					"][",
					this.m_activeTips.Count,
					"][",
					this.m_teachableTips.Count,
					"]"
				}));
				this.m_needSave |= true;
				this.m_isTimeToShine = true;
				return;
			}
		}
	}

	// Token: 0x06001E22 RID: 7714 RVA: 0x00096060 File Offset: 0x00094260
	private bool method_3(GuidanceTip guidanceTip_0, TipTrigger tipTrigger_0, int int_0)
	{
		if (guidanceTip_0.m_trigger != tipTrigger_0)
		{
			return false;
		}
		switch (tipTrigger_0)
		{
		case TipTrigger.LevelUp:
		case TipTrigger.SpentSkillPoint:
			return guidanceTip_0.m_value == int_0;
		case TipTrigger.ObtainWeapon:
		case TipTrigger.ObtainShield:
		case TipTrigger.ObtainClassMod:
		case TipTrigger.CanInteractWithPlayer:
		case TipTrigger.ReceiveMail:
		case TipTrigger.UnlockNewInstance:
			return true;
		default:
			return false;
		}
	}

	// Token: 0x06001E23 RID: 7715 RVA: 0x000960B0 File Offset: 0x000942B0
	private void OnTipTrigger(TipTrigger tipTriggerType, int value = 0)
	{
		for (int i = this.m_teachableTips.Count; i > 0; i--)
		{
			GuidanceTip guidanceTip = this.m_teachableTips[i - 1];
			if (this.method_3(guidanceTip, tipTriggerType, value))
			{
				this.m_activeTips.Add(guidanceTip);
				this.m_teachableTips.Remove(guidanceTip);
				DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"GuidanceTipsManager.OnTipTrigger[",
					guidanceTip.m_id,
					"][",
					this.m_activeTips.Count,
					"][",
					this.m_teachableTips.Count,
					"]"
				}));
				this.m_needSave |= true;
				this.m_isTimeToShine = true;
				return;
			}
		}
	}

	// Token: 0x06001E24 RID: 7716 RVA: 0x0009617C File Offset: 0x0009437C
	private void OnLevelUp(PlayerInfoSync player)
	{
		if (!player.IsMyActor())
		{
			return;
		}
		int num = MonoSingleton<LevelingManager>.Instance.method_3(player.m_avatarDna.method_5(), player.m_exp);
		this.OnTipTrigger(TipTrigger.LevelUp, num);
	}

	// Token: 0x06001E25 RID: 7717 RVA: 0x000961B8 File Offset: 0x000943B8
	public void OnObtainItem(ItemDNA item)
	{
		if (item == null)
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			return;
		}
		if (item.method_3(ItemType.Weapon))
		{
			this.OnTipTrigger(TipTrigger.ObtainWeapon, 0);
		}
		else if (item.method_3(ItemType.Shield))
		{
			this.OnTipTrigger(TipTrigger.ObtainShield, 0);
		}
		else if (item.method_3(ItemType.ClassMode))
		{
			this.OnTipTrigger(TipTrigger.ObtainClassMod, 0);
		}
	}

	// Token: 0x06001E26 RID: 7718 RVA: 0x00015278 File Offset: 0x00013478
	public void OnCanInteractWithPlayer()
	{
		this.OnTipTrigger(TipTrigger.CanInteractWithPlayer, 0);
	}

	// Token: 0x06001E27 RID: 7719 RVA: 0x00015282 File Offset: 0x00013482
	public void OnReceiveMail()
	{
		this.OnTipTrigger(TipTrigger.ReceiveMail, 0);
	}

	// Token: 0x06001E28 RID: 7720 RVA: 0x0001528C File Offset: 0x0001348C
	public void OnUnlockNewInstance()
	{
		this.OnTipTrigger(TipTrigger.UnlockNewInstance, 0);
	}

	// Token: 0x06001E29 RID: 7721 RVA: 0x00015296 File Offset: 0x00013496
	public void OnSpentSkillPoint(int value)
	{
		this.OnTipTrigger(TipTrigger.SpentSkillPoint, value);
	}

	// Token: 0x040013B5 RID: 5045
	private bool m_needSave;

	// Token: 0x040013B6 RID: 5046
	private static float s_repeatTime = 30f;

	// Token: 0x040013B7 RID: 5047
	private bool m_isTimeToShine;

	// Token: 0x040013B8 RID: 5048
	private GuidanceTipsSetup m_guidanceTipsSetup;

	// Token: 0x040013B9 RID: 5049
	private List<GuidanceTip> m_teachableTips = new List<GuidanceTip>();

	// Token: 0x040013BA RID: 5050
	private List<GuidanceTip> m_activeTips = new List<GuidanceTip>();

	// Token: 0x040013BB RID: 5051
	private List<GuidanceTip> m_learnedTips = new List<GuidanceTip>();

	// Token: 0x040013BC RID: 5052
	private Utils.Timer m_tipTimer = new Utils.Timer();
}
