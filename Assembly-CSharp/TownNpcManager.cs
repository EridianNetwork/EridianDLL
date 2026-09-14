using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000565 RID: 1381
public class TownNpcManager : MonoSingleton<TownNpcManager>
{
	// Token: 0x0600238B RID: 9099 RVA: 0x000A8E58 File Offset: 0x000A7058
	private void Start()
	{
		string text = null;
		try
		{
			string text2 = Path.Combine(Application.dataPath, "../overrides/TownNpcSetup_override.xml");
			if (File.Exists(text2))
			{
				text = File.ReadAllText(text2);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.System, "TownNpcSetup override read failed: " + ex.Message);
		}
		if (text == null)
		{
			TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/TownNpcSetup");
			text = textAsset.text;
			Resources.UnloadAsset(textAsset);
		}
		using (StringReader stringReader = new StringReader(text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TownNpcSetup));
			this.m_npcsSetup = xmlSerializer.Deserialize(stringReader) as TownNpcSetup;
		}
	}

	// Token: 0x0600238C RID: 9100 RVA: 0x000A8F14 File Offset: 0x000A7114
	public global::XsdSettings.TownNpc method_0(int int_0)
	{
		for (int i = 0; i < this.m_npcsSetup.m_npcs.Length; i++)
		{
			if (this.m_npcsSetup.m_npcs[i].m_id == int_0)
			{
				return this.m_npcsSetup.m_npcs[i];
			}
		}
		return null;
	}

	// Token: 0x0600238D RID: 9101 RVA: 0x000A8F60 File Offset: 0x000A7160
	public NpcTitleMgr.NPC_ICON_TYPE method_1(int int_0)
	{
		NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = QuestUIDataManager.smethod_0().method_16(int_0);
		if (npc_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE)
		{
			global::XsdSettings.TownNpc townNpc = this.method_0(int_0);
			if (townNpc != null && townNpc.m_occupations != null && townNpc.m_occupations.Length != 0)
			{
				switch (townNpc.m_occupations[0])
				{
				case NpcOccupation.Crafting:
				case NpcOccupation.Melting:
				case NpcOccupation.WeaponUpgrade:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_CRAFT;
					break;
				case NpcOccupation.CoinShieldShop:
				case NpcOccupation.ClassModeShop:
				case NpcOccupation.WeaponShop:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SHOP;
					break;
				case NpcOccupation.Mail:
					npc_ICON_TYPE = ((ServiceWrapperBase<MailServiceWrapper>.Instance.method_2() <= 0) ? NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL : NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW);
					break;
				case NpcOccupation.Guild:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_GUILD;
					break;
				case NpcOccupation.Warehouse:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_WAREHOUSE;
					break;
				case NpcOccupation.PvP:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PVP;
					break;
				case NpcOccupation.OutfitShop:
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SHOP;
					break;
				}
			}
		}
		return npc_ICON_TYPE;
	}

	// Token: 0x04001835 RID: 6197
	public TownNpcSetup m_npcsSetup;
}
