using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000768 RID: 1896
public class SkillTreeMenu : MonoBehaviour
{
	// Token: 0x0600323B RID: 12859 RVA: 0x000E36D4 File Offset: 0x000E18D4
	private void Awake()
	{
		MonoSingleton<GameFlowManager>.Instance.method_1();
		float num = 10f;
		float num2 = 10f;
		int num3 = 5;
		this.m_treeLayout = new SkillTreeMenu.GUITreeLayout();
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (entityPlayer.PlayerSkillManage_0 is FirebirdManage)
		{
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.FirebirdFirstAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.FirebirdSecondAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.FireHeart, num3),
				new SkillItem(ESkillType.FireEater, num3),
				new SkillItem(ESkillType.Detonation, num3),
				new SkillItem(ESkillType.Sparkle, num3),
				new SkillItem(ESkillType.Resurrection, 5),
				new SkillItem(ESkillType.Glare, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.FireWings, num3),
				new SkillItem(ESkillType.Absorption, num3),
				new SkillItem(ESkillType.Retaliation, 5)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Ignition, num3),
				new SkillItem(ESkillType.UndyingFlames, num3),
				new SkillItem(ESkillType.DazzlingShots, 5)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Gifted, num3),
				new SkillItem(ESkillType.Ablaze, num3),
				new SkillItem(ESkillType.Energize, 5)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Ethereal, num3),
				new SkillItem(ESkillType.Astute, num3),
				new SkillItem(ESkillType.Deception, 5)
			}, num, num2);
		}
		else if (entityPlayer.PlayerSkillManage_0 is BerserkManage)
		{
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.BerserkFirstAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.BerserkSecondAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.BigPockets, num3),
				new SkillItem(ESkillType.BamBam, num3),
				new SkillItem(ESkillType.BerserkOverweight, num3),
				new SkillItem(ESkillType.BadTemper, num3),
				new SkillItem(ESkillType.PhantomShot, num3),
				new SkillItem(ESkillType.MagicBullet, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.CombatReload, num3),
				new SkillItem(ESkillType.Bloodlust, num3),
				new SkillItem(ESkillType.Retribution, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.RedFury, num3),
				new SkillItem(ESkillType.BURP, num3),
				new SkillItem(ESkillType.Discharge, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Boxer, num3),
				new SkillItem(ESkillType.Adrenaline, num3),
				new SkillItem(ESkillType.Desperation, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Tenacity, num3),
				new SkillItem(ESkillType.Relentless, num3),
				new SkillItem(ESkillType.Fortitude, num3)
			}, num, num2);
		}
		else if (entityPlayer.PlayerSkillManage_0 is TurretManage)
		{
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.TurretFirstAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.TurretSecondAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.SpeedyHands, num3),
				new SkillItem(ESkillType.SecretPouch, num3),
				new SkillItem(ESkillType.BionicLink, num3),
				new SkillItem(ESkillType.SupplyPack, num3),
				new SkillItem(ESkillType.Unison, num3),
				new SkillItem(ESkillType.Conservation, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.ShotPut, num3),
				new SkillItem(ESkillType.Bunker, num3),
				new SkillItem(ESkillType.Decompress, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Rocker, num3),
				new SkillItem(ESkillType.ShortCircuit, num3),
				new SkillItem(ESkillType.Aftershock, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.FirePowder, num3),
				new SkillItem(ESkillType.ShieldBomb, num3),
				new SkillItem(ESkillType.Battery, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Repulsor, num3),
				new SkillItem(ESkillType.Electrocute, num3),
				new SkillItem(ESkillType.Readiness, num3)
			}, num, num2);
		}
		else if (entityPlayer.PlayerSkillManage_0 is HunterManage)
		{
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.HunterFirstAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.HunterSecondAction, 1)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Swift, num3),
				new SkillItem(ESkillType.Intangible, num3),
				new SkillItem(ESkillType.VitalPoint, num3),
				new SkillItem(ESkillType.Exploit, num3),
				new SkillItem(ESkillType.Precision, num3),
				new SkillItem(ESkillType.Balanced, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Shift, num3),
				new SkillItem(ESkillType.Volatile, num3),
				new SkillItem(ESkillType.Booster, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Siphon, num3),
				new SkillItem(ESkillType.Bounty, num3),
				new SkillItem(ESkillType.Disorientate, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Continuity, num3),
				new SkillItem(ESkillType.ChargedShot, num3),
				new SkillItem(ESkillType.Redirect, num3)
			}, num, num2);
			this.m_treeLayout.method_0(new SkillItem[]
			{
				new SkillItem(ESkillType.Vigilance, num3),
				new SkillItem(ESkillType.Impedance, num3),
				new SkillItem(ESkillType.Scan, num3)
			}, num, num2);
		}
	}

	// Token: 0x0600323C RID: 12860 RVA: 0x00020BB1 File Offset: 0x0001EDB1
	public void method_0()
	{
		if (MonoSingleton<GameFlowManager>.Instance != null)
		{
			MonoSingleton<GameFlowManager>.Instance.method_0();
		}
	}

	// Token: 0x040022B5 RID: 8885
	private SkillTreeMenu.GUITreeLayout m_treeLayout;

	// Token: 0x02000769 RID: 1897
	public class GUITreeLayout
	{
		// Token: 0x0600323D RID: 12861 RVA: 0x00020BCA File Offset: 0x0001EDCA
		public GUITreeLayout()
		{
			this.m_skillTreeManager = MonoSingleton<Session>.Instance.GetComponent<PlayerSkillTreeManage>();
			this.m_btn_slowdown = new SkillTreeMenu.GUIButton_Slowdown();
		}

		// Token: 0x0600323E RID: 12862 RVA: 0x00020BF8 File Offset: 0x0001EDF8
		public void method_0(SkillItem[] skillItem_0, float float_0, float float_1)
		{
			this.m_lines.Add(new SkillTreeMenu.GUILineLayout(skillItem_0, float_0, float_1, this));
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x000E3D20 File Offset: 0x000E1F20
		public void method_1()
		{
			GUILayout.BeginArea(new Rect((float)((Screen.width - 800) / 2), 20f, 800f, 800f));
			foreach (SkillTreeMenu.GUILineLayout guilineLayout in this.m_lines)
			{
				guilineLayout.method_0();
				GUILayout.Space(10f);
			}
			this.m_btn_slowdown.method_0();
			GUILayout.EndArea();
		}

		// Token: 0x040022B6 RID: 8886
		public List<SkillTreeMenu.GUILineLayout> m_lines = new List<SkillTreeMenu.GUILineLayout>();

		// Token: 0x040022B7 RID: 8887
		public PlayerSkillTreeManage m_skillTreeManager;

		// Token: 0x040022B8 RID: 8888
		private SkillTreeMenu.GUIButton_Slowdown m_btn_slowdown;
	}

	// Token: 0x0200076A RID: 1898
	public class GUIButton_Slowdown
	{
		// Token: 0x06003241 RID: 12865 RVA: 0x000E3DEC File Offset: 0x000E1FEC
		public void method_0()
		{
			GUILayout.Space(12f);
			if (GUILayout.Button(this.m_dict[this.m_type], new GUILayoutOption[] { GUILayout.Width(200f) }))
			{
				this.m_type = ((this.m_type != MarkManager.ESlowdownType.BeingMarking) ? MarkManager.ESlowdownType.BeingMarking : MarkManager.ESlowdownType.InMarkState);
				MonoSingleton<Session>.Instance.GetComponent<PlayerSkillTreeManage>().method_1(this.m_type);
			}
		}

		// Token: 0x040022B9 RID: 8889
		private MarkManager.ESlowdownType m_type;

		// Token: 0x040022BA RID: 8890
		private Dictionary<MarkManager.ESlowdownType, string> m_dict = new Dictionary<MarkManager.ESlowdownType, string>
		{
			{
				MarkManager.ESlowdownType.BeingMarking,
				"slow down when being marking"
			},
			{
				MarkManager.ESlowdownType.InMarkState,
				"slow down when in mark state"
			}
		};
	}

	// Token: 0x0200076B RID: 1899
	public class GUILineLayout
	{
		// Token: 0x06003242 RID: 12866 RVA: 0x00020C0E File Offset: 0x0001EE0E
		public GUILineLayout(SkillItem[] skillItem_0, float float_0, float float_1, SkillTreeMenu.GUITreeLayout guitreeLayout_0)
		{
			this.m_items.AddRange(skillItem_0);
			this.m_left = float_0;
			this.m_pad = float_1;
			this.m_owner = guitreeLayout_0;
		}

		// Token: 0x06003243 RID: 12867 RVA: 0x000E3E58 File Offset: 0x000E2058
		public void method_0()
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(this.m_left);
			foreach (SkillItem skillItem in this.m_items)
			{
				if (GUILayout.Button(string.Format("{0} {1}", skillItem.method_0(), skillItem.Int32_0), new GUILayoutOption[0]))
				{
					if (skillItem.m_type == ESkillType.None)
					{
						continue;
					}
					skillItem.OnClick();
					this.m_owner.m_skillTreeManager.method_0(skillItem);
				}
				GUILayout.Space(this.m_pad);
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x040022BB RID: 8891
		public float m_pad = 10f;

		// Token: 0x040022BC RID: 8892
		public float m_left;

		// Token: 0x040022BD RID: 8893
		private List<SkillItem> m_items = new List<SkillItem>();

		// Token: 0x040022BE RID: 8894
		private SkillTreeMenu.GUITreeLayout m_owner;
	}
}
