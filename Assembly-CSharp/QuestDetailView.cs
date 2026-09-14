using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000747 RID: 1863
public class QuestDetailView : BaseView
{
	// Token: 0x0600312C RID: 12588 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x0600312D RID: 12589 RVA: 0x0001F35D File Offset: 0x0001D55D
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x0600312E RID: 12590 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x0600312F RID: 12591 RVA: 0x0001E200 File Offset: 0x0001C400
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003130 RID: 12592 RVA: 0x0001FFB2 File Offset: 0x0001E1B2
	public virtual void vmethod_5(Quest quest_0, QuestProgress questProgress_0)
	{
		this._onShowQuest = quest_0;
		this._onShowProgress = questProgress_0;
	}

	// Token: 0x06003131 RID: 12593 RVA: 0x0001FFC2 File Offset: 0x0001E1C2
	protected virtual void vmethod_6()
	{
		if (this._onShowProgress.mStatus == QuestState.InProgress)
		{
			QuestUIDataManager.smethod_0().method_8(this._onShowProgress.mQuestId);
		}
		NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
		this.Boolean_1 = false;
	}

	// Token: 0x06003132 RID: 12594 RVA: 0x0001FFF9 File Offset: 0x0001E1F9
	protected virtual void vmethod_7()
	{
		if (this._onShowProgress.mStatus == QuestState.Available)
		{
			QuestUIDataManager.smethod_0().method_9(this._onShowProgress.mQuestId);
		}
		NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
		this.Boolean_1 = false;
	}

	// Token: 0x06003133 RID: 12595 RVA: 0x00020030 File Offset: 0x0001E230
	protected virtual void vmethod_8()
	{
		this.Boolean_1 = false;
		NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
	}

	// Token: 0x06003134 RID: 12596 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_3()
	{
	}

	// Token: 0x06003135 RID: 12597 RVA: 0x000DFDF8 File Offset: 0x000DDFF8
	protected virtual void vmethod_9()
	{
		if (this._onShowProgress.mStatus == QuestState.Completed)
		{
			if (this._selectedReward.Count < this._onShowQuest.mOptionalRewardsCount)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Quest_Select_Reward")), null, new Delegate_EventProc(this.method_3));
				return;
			}
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
			QuestUIDataManager.smethod_0().method_10(this._onShowProgress.mQuestId, this._selectedReward.ToArray());
			this.Boolean_1 = false;
			if (NPC_UIFlowController.smethod_0().method_0().CurNPCAnimaMgr != null)
			{
				NPC_UIFlowController.smethod_0().method_0().CurNPCAnimaMgr.method_0(TownNPCAnimationManagerFSM.TownNpcAnimationType.FINISH);
			}
			GameObject curNPCCamera = NPC_UIFlowController.smethod_0().method_0().CurNPCCamera;
			if (curNPCCamera != null && curNPCCamera.activeSelf)
			{
				ParticleSystem[] componentsInChildren = curNPCCamera.GetComponentsInChildren<ParticleSystem>(true);
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					if (componentsInChildren[i].name == "PTL_Celebrate")
					{
						componentsInChildren[i].Play();
						return;
					}
					i++;
				}
			}
		}
	}

	// Token: 0x04002209 RID: 8713
	protected global::XsdSettings.TownNpc _NPCSetting;

	// Token: 0x0400220A RID: 8714
	protected Quest _onShowQuest;

	// Token: 0x0400220B RID: 8715
	protected QuestProgress _onShowProgress;

	// Token: 0x0400220C RID: 8716
	protected List<byte> _selectedReward;
}
