using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x020008A4 RID: 2212
public class uniSkillTreeView : SkillTreeView
{
	// Token: 0x06003CBA RID: 15546 RVA: 0x0011F358 File Offset: 0x0011D558
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		uniSkillTreeView.SkillNodeTips.smethod_0();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Skill_Tree.swf", "whole", new FuncLoad(this.method_6));
		this.method_7();
	}

	// Token: 0x06003CBB RID: 15547 RVA: 0x0011F3A8 File Offset: 0x0011D5A8
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._dicSkillIcon.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		this._skillTreeRoot = null;
		this._root = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Skill_Tree.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Skill_Tree_icon.swf");
	}

	// Token: 0x06003CBC RID: 15548 RVA: 0x0011F420 File Offset: 0x0011D620
	private void method_6(MovieClip movieClip_0)
	{
		this._mcRoot = movieClip_0;
		this._mcRoot.visible = false;
		this._mcRoot.stopAll();
		this._mcRoot.addFrameScript("KeyFrame_1", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("KeyFrame_2", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("KeyFrame_4", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_9));
		this._mcRoot.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_10));
		this._root = new GClass51();
		this._skillTreeRoot = new uniSkillTreeView.SkillTreePanel();
		this._skillTreeRoot.addEventListener(uniSkillTreeView.EVT_ONCLICK_SKILLSLOT, new EventDispatcher.EventCallback(this.method_13));
		this._skillTreeRoot.addEventListener(uniSkillTreeView.EVT_ONCLICK_CLOSE, new EventDispatcher.EventCallback(this.method_12));
		this._skillTreeRoot.addEventListener(uniSkillTreeView.EVT_ONCLICK_RESET, new EventDispatcher.EventCallback(this.method_11));
		MovieClip childByName = this._mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
		{
			this._skillTreeRoot.method_0(childByName);
			this._skillTreeRoot.method_5();
			this._skillTreeRoot.method_1();
		}
		this._root.method_0(this._mcRoot);
		this._bActive = true;
	}

	// Token: 0x06003CBD RID: 15549 RVA: 0x0011F5D4 File Offset: 0x0011D7D4
	protected void method_7()
	{
		if (this._skillTreeData == null)
		{
			return;
		}
		foreach (SkillTreeView.SkillNodeGroup skillNodeGroup in this._skillTreeData.method_2())
		{
			if (skillNodeGroup.Int32_0 != 0)
			{
				foreach (SkillTreeView.SkillTierSegment skillTierSegment in skillNodeGroup.method_2())
				{
					if (skillTierSegment.Int32_0 != 1)
					{
						if (skillTierSegment.Int32_0 != 2)
						{
							foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in skillTierSegment.method_1())
							{
								if (skillNodeContainer.Skill_0 != null)
								{
									(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Skill_Tree_icon.swf", skillNodeContainer.Skill_0.m_icon, new FuncLoad(this.method_8));
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06003CBE RID: 15550 RVA: 0x00028E75 File Offset: 0x00027075
	private void method_8(MovieClip movieClip_0)
	{
		if (movieClip_0 == null)
		{
			return;
		}
		movieClip_0.name = movieClip_0.getSymbolName();
		if (!this._dicSkillIcon.ContainsKey(movieClip_0.name))
		{
			this._dicSkillIcon.Add(movieClip_0.name, movieClip_0);
		}
	}

	// Token: 0x06003CBF RID: 15551 RVA: 0x0011F70C File Offset: 0x0011D90C
	private void method_9(CEvent cevent_0)
	{
		MovieClip childByName = this._mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
		{
			this._skillTreeRoot.method_6(this._skillTreeData, this._dicSkillIcon);
		}
	}

	// Token: 0x06003CC0 RID: 15552 RVA: 0x00028EAC File Offset: 0x000270AC
	private void method_10(CEvent cevent_0)
	{
		this._mcRoot.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
	}

	// Token: 0x06003CC1 RID: 15553 RVA: 0x0011F744 File Offset: 0x0011D944
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		this._mcRoot.visible = this._bVisible;
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._root);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			this._mcRoot.gotoAndPlay("fadein");
			base.method_5();
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			this._mcRoot.gotoAndPlay("fadeout");
		}
	}

	// Token: 0x06003CC2 RID: 15554 RVA: 0x00028ED4 File Offset: 0x000270D4
	protected void method_11(CEvent cevent_0)
	{
		this.vmethod_7();
	}

	// Token: 0x06003CC3 RID: 15555 RVA: 0x00028EDC File Offset: 0x000270DC
	protected void method_12(CEvent cevent_0)
	{
		this.vmethod_1(false, false);
	}

	// Token: 0x06003CC4 RID: 15556 RVA: 0x0011F7E8 File Offset: 0x0011D9E8
	protected void method_13(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			SkillTreeView.SkillNodeContainer skillNodeContainer = gclass.object_0 as SkillTreeView.SkillNodeContainer;
			if (skillNodeContainer != null && skillNodeContainer.Skill_0 != null)
			{
				this.vmethod_8(skillNodeContainer.Skill_0.m_id);
			}
		}
	}

	// Token: 0x06003CC5 RID: 15557 RVA: 0x00028EE6 File Offset: 0x000270E6
	protected override void vmethod_6(int int_0, int int_1)
	{
		base.vmethod_6(int_0, int_1);
		if (this._skillTreeRoot != null)
		{
			this._skillTreeRoot.method_8(int_1);
		}
	}

	// Token: 0x06003CC6 RID: 15558 RVA: 0x00028F04 File Offset: 0x00027104
	protected override void vmethod_5(List<InvestedSkill> list_0)
	{
		base.vmethod_5(list_0);
		if (this._skillTreeRoot != null)
		{
			this._skillTreeRoot.method_7(this._skillTreeData);
		}
	}

	// Token: 0x04002AB3 RID: 10931
	protected static string EVT_ONCLICK_SKILLSLOT = "Evt_OnClick_SkillSlot";

	// Token: 0x04002AB4 RID: 10932
	protected static string EVT_ONCLICK_CLOSE = "Evt_OnClick_Close";

	// Token: 0x04002AB5 RID: 10933
	protected static string EVT_ONCLICK_RESET = "Evt_OnClick_Reset";

	// Token: 0x04002AB6 RID: 10934
	protected uniSkillTreeView.SkillTreePanel _skillTreeRoot;

	// Token: 0x04002AB7 RID: 10935
	protected MovieClip _mcRoot;

	// Token: 0x04002AB8 RID: 10936
	protected GClass51 _root;

	// Token: 0x04002AB9 RID: 10937
	protected Dictionary<string, MovieClip> _dicSkillIcon = new Dictionary<string, MovieClip>();

	// Token: 0x020008A5 RID: 2213
	public class SkillTreePanel : GClass51
	{
		// Token: 0x06003CC8 RID: 15560 RVA: 0x0011F830 File Offset: 0x0011DA30
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains("mcSkillProgress"))
			{
				flag = true;
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				uniSkillTreeView.TierBGProgress tierBGProgress = new uniSkillTreeView.TierBGProgress();
				tierBGProgress.method_0(movieClip);
				tierBGProgress.method_5(num);
				this._dicProgressBG.Add(num, tierBGProgress);
			}
			else if (movieClip.name.Contains("mcSkillPt"))
			{
				flag = true;
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				Dictionary<int, uniSkillTreeView.SkillIconSlot> dictionary = null;
				this._dicPositionSkillSlot.TryGetValue(num, out dictionary);
				if (dictionary == null)
				{
					dictionary = new Dictionary<int, uniSkillTreeView.SkillIconSlot>();
					this._dicPositionSkillSlot.Add(num, dictionary);
				}
				int num2 = Convert.ToInt32(array[2]);
				uniSkillTreeView.SkillIconSlot skillIconSlot = null;
				if (!dictionary.TryGetValue(num2, out skillIconSlot))
				{
					skillIconSlot = new uniSkillTreeView.SkillIconSlot();
					dictionary.Add(num2, skillIconSlot);
					skillIconSlot.addEventListener(uniSkillTreeView.EVT_ONCLICK_SKILLSLOT, new EventDispatcher.EventCallback(this.method_13));
				}
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				skillIconSlot.method_0(movieClip);
				if (num != 1 && num != 2)
				{
					movieClip.visible = false;
				}
			}
			else
			{
				string name = movieClip.name;
				switch (name)
				{
				case "mcClass":
					flag = true;
					this._mcClass = movieClip;
					break;
				case "btnReset":
					flag = true;
					this._btnReset.method_0(movieClip);
					this._btnReset.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
					break;
				case "mcCareerBG":
					this._mcCareerBG = movieClip;
					flag = true;
					break;
				case "mcBtnClose":
					this._btnClose.method_0(movieClip);
					this._btnClose.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
					flag = true;
					break;
				}
			}
			return flag;
		}

		// Token: 0x06003CC9 RID: 15561 RVA: 0x00028F65 File Offset: 0x00027165
		public void method_5()
		{
			this._dicProgressBG.Clear();
			this._dicPositionSkillSlot.Clear();
			this._dicSkillSlot.Clear();
		}

		// Token: 0x06003CCA RID: 15562 RVA: 0x0011FA80 File Offset: 0x0011DC80
		public void method_6(SkillTreeView.SkillTreeDataRoot skillTreeDataRoot_0, Dictionary<string, MovieClip> dictionary_0)
		{
			if (skillTreeDataRoot_0 != null && this._mcRoot != null && dictionary_0 != null)
			{
				string text = skillTreeDataRoot_0.AvatarType_0.ToString();
				if (this._mcCareerBG != null)
				{
					this._mcCareerBG.gotoAndStop(text);
				}
				if (this._mcClass != null)
				{
					UnityTextField unityTextField = (UnityTextField)this._mcClass.getChildByName<TextField>("textClassName");
					if (unityTextField != null)
					{
						unityTextField.text = LocalizedString.smethod_0(new LocalizedString("CLASS_" + text));
					}
				}
				for (int i = 1; i <= 3; i++)
				{
					uniSkillTreeView.TierBGProgress tierBGProgress = null;
					this._dicProgressBG.TryGetValue(i, out tierBGProgress);
					StringBuilder stringBuilder = new StringBuilder(text);
					stringBuilder.Append('_').Append(i);
					if (tierBGProgress != null)
					{
						tierBGProgress.method_7(stringBuilder.ToString());
					}
				}
				foreach (SkillTreeView.SkillNodeGroup skillNodeGroup in skillTreeDataRoot_0.method_2())
				{
					foreach (SkillTreeView.SkillTierSegment skillTierSegment in skillNodeGroup.method_2())
					{
						int int32_ = skillTierSegment.Int32_0;
						int count = skillTierSegment.method_1().Count;
						int num = 0;
						foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in skillTierSegment.method_1())
						{
							if (skillNodeContainer.Skill_0 != null)
							{
								int num2;
								if (skillNodeGroup.Int32_0 == 0)
								{
									num2 = 1;
								}
								else
								{
									int num3 = count % 2;
									num2 = (skillNodeGroup.Int32_0 - 1) * 3 + num3 + 2 * num + 1;
									num++;
								}
								uniSkillTreeView.SkillIconSlot skillIconSlot = null;
								Dictionary<int, uniSkillTreeView.SkillIconSlot> dictionary = null;
								if (this._dicPositionSkillSlot.TryGetValue(int32_, out dictionary))
								{
									dictionary.TryGetValue(num2, out skillIconSlot);
								}
								MovieClip movieClip = null;
								dictionary_0.TryGetValue(skillNodeContainer.Skill_0.m_icon, out movieClip);
								if (skillIconSlot != null)
								{
									skillIconSlot.method_10(skillNodeContainer.Skill_0, int32_, skillTreeDataRoot_0.AvatarType_0, movieClip);
									skillIconSlot.DisplayObjectContainer_0.visible = true;
									if (skillIconSlot.GInterface1_0 == null)
									{
										uniSkillTreeView.SkillNodeTips skillNodeTips = new uniSkillTreeView.SkillNodeTips(skillNodeContainer.Skill_0, skillNodeContainer.Int32_1);
										skillIconSlot.GInterface1_0 = skillNodeTips;
									}
									if (!this._dicSkillSlot.ContainsKey(skillNodeContainer.Int32_0))
									{
										this._dicSkillSlot.Add(skillNodeContainer.Int32_0, skillIconSlot);
									}
								}
							}
						}
					}
					if (skillNodeGroup.Int32_0 != 0)
					{
						StringBuilder stringBuilder2 = new StringBuilder("textTreeName_");
						stringBuilder2.Append(skillNodeGroup.Int32_0);
						UnityTextField childByName = this._mcRoot.getChildByName<UnityTextField>(stringBuilder2.ToString());
						childByName.text = LocalizedString.smethod_0(new LocalizedString(skillNodeGroup.String_0));
					}
				}
				this.method_7(skillTreeDataRoot_0);
				return;
			}
		}

		// Token: 0x06003CCB RID: 15563 RVA: 0x00028F88 File Offset: 0x00027188
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			if (this._mcRoot != null)
			{
				this._textUnspentSkillPt = this._mcRoot.getChildByName<UnityTextField>("textField_AvailablePt");
			}
		}

		// Token: 0x06003CCC RID: 15564 RVA: 0x00028FBF File Offset: 0x000271BF
		public void method_7(SkillTreeView.SkillTreeDataRoot skillTreeDataRoot_0)
		{
			if (skillTreeDataRoot_0 == null)
			{
				return;
			}
			this._skillDataContainer = skillTreeDataRoot_0;
			this.method_10();
			this.method_9();
		}

		// Token: 0x06003CCD RID: 15565 RVA: 0x00028FD8 File Offset: 0x000271D8
		public void method_8(int int_0)
		{
			if (this._textUnspentSkillPt != null)
			{
				this._textUnspentSkillPt.text = int_0.ToString();
			}
		}

		// Token: 0x06003CCE RID: 15566 RVA: 0x0011FDA8 File Offset: 0x0011DFA8
		protected void method_9()
		{
			foreach (SkillTreeView.SkillNodeGroup skillNodeGroup in this._skillDataContainer.method_2())
			{
				if (skillNodeGroup.Int32_0 != 0)
				{
					uniSkillTreeView.TierBGProgress tierBGProgress = null;
					if (this._dicProgressBG.TryGetValue(skillNodeGroup.Int32_0, out tierBGProgress))
					{
						tierBGProgress.method_6(skillNodeGroup.Int32_1, skillNodeGroup.Single_0);
					}
				}
			}
		}

		// Token: 0x06003CCF RID: 15567 RVA: 0x0011FE2C File Offset: 0x0011E02C
		protected void method_10()
		{
			foreach (SkillTreeView.SkillNodeGroup skillNodeGroup in this._skillDataContainer.method_2())
			{
				foreach (SkillTreeView.SkillTierSegment skillTierSegment in skillNodeGroup.method_2())
				{
					foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in skillTierSegment.method_1())
					{
						if (skillNodeContainer.Skill_0 != null)
						{
							uniSkillTreeView.SkillIconSlot skillIconSlot = null;
							if (this._dicSkillSlot.TryGetValue(skillNodeContainer.Int32_0, out skillIconSlot))
							{
								skillIconSlot.method_12(skillNodeContainer);
								if (skillIconSlot.GInterface1_0 != null)
								{
									uniSkillTreeView.SkillNodeTips skillNodeTips = (uniSkillTreeView.SkillNodeTips)skillIconSlot.GInterface1_0;
									if (skillNodeTips.Int32_0 != skillNodeContainer.Int32_1)
									{
										skillNodeTips.Int32_0 = skillNodeContainer.Int32_1;
										skillNodeTips.vmethod_0();
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06003CD0 RID: 15568 RVA: 0x00028FF4 File Offset: 0x000271F4
		protected void method_11(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniSkillTreeView.EVT_ONCLICK_RESET));
		}

		// Token: 0x06003CD1 RID: 15569 RVA: 0x00029007 File Offset: 0x00027207
		protected void method_12(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(uniSkillTreeView.EVT_ONCLICK_CLOSE));
		}

		// Token: 0x06003CD2 RID: 15570 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_13(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x04002ABA RID: 10938
		protected const int _iBranchNum = 3;

		// Token: 0x04002ABB RID: 10939
		protected const string CLASSNAME_LOCALIZATION_PREFIX = "CLASS_";

		// Token: 0x04002ABC RID: 10940
		protected const string TREE_NAME_PREFIX = "textTreeName_";

		// Token: 0x04002ABD RID: 10941
		protected MovieClip _mcRoot;

		// Token: 0x04002ABE RID: 10942
		protected MovieClip _mcClass;

		// Token: 0x04002ABF RID: 10943
		protected MovieClip _mcCareerBG;

		// Token: 0x04002AC0 RID: 10944
		protected GClass25 _btnReset = new GClass25();

		// Token: 0x04002AC1 RID: 10945
		protected GClass25 _btnClose = new GClass25();

		// Token: 0x04002AC2 RID: 10946
		protected UnityTextField _textUnspentSkillPt;

		// Token: 0x04002AC3 RID: 10947
		protected SkillTreeView.SkillTreeDataRoot _skillDataContainer;

		// Token: 0x04002AC4 RID: 10948
		protected Dictionary<int, uniSkillTreeView.TierBGProgress> _dicProgressBG = new Dictionary<int, uniSkillTreeView.TierBGProgress>();

		// Token: 0x04002AC5 RID: 10949
		protected Dictionary<int, Dictionary<int, uniSkillTreeView.SkillIconSlot>> _dicPositionSkillSlot = new Dictionary<int, Dictionary<int, uniSkillTreeView.SkillIconSlot>>();

		// Token: 0x04002AC6 RID: 10950
		protected Dictionary<int, uniSkillTreeView.SkillIconSlot> _dicSkillSlot = new Dictionary<int, uniSkillTreeView.SkillIconSlot>();
	}

	// Token: 0x020008A6 RID: 2214
	public class SkillIconSlot : GClass24
	{
		// Token: 0x06003CD4 RID: 15572 RVA: 0x0011FF68 File Offset: 0x0011E168
		public void method_10(Skill skill_0, int int_0, AvatarType avatarType_0, MovieClip movieClip_1)
		{
			this._iTierID = int_0;
			this._avatarType = avatarType_0;
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
			if (this._iTierID != 1)
			{
				if (this._iTierID != 2)
				{
					if (childByName != null && movieClip_1 != null && skill_0 != null)
					{
						MovieClip childByName2 = childByName.getChildByName<MovieClip>(skill_0.m_icon);
						if (childByName2 != null)
						{
							childByName.removeChild(childByName2);
						}
						MovieClip childByName3 = childByName.getChildByName<MovieClip>("mcIconImg");
						childByName3.visible = false;
						MovieClip movieClip = movieClip_1.newInstance();
						movieClip.x = 0f;
						movieClip.y = 0f;
						movieClip.name = movieClip_1.name;
						childByName.stopAll();
						childByName.addChildAt(movieClip, childByName.getChildIndex(childByName3));
						goto IL_00EF;
					}
					goto IL_00EF;
				}
			}
			MovieClip childByName4 = this._rootMC.getChildByName<MovieClip>("mcClassIcon");
			if (childByName4 != null && this._avatarType != AvatarType.TOTAL)
			{
				childByName4.gotoAndStop(this._avatarType.ToString());
			}
			IL_00EF:
			this.method_12(this._slotData);
		}

		// Token: 0x06003CD5 RID: 15573 RVA: 0x00120070 File Offset: 0x0011E270
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.removeAllEventListeners(MouseEvent.CLICK);
			this._rootMC.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this._rootMC.stopAll();
			if (this._btnMouseCover == null)
			{
				this._btnMouseCover = new GClass25();
			}
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcMouseCover");
			if (childByName != null)
			{
				this._btnMouseCover.method_0(childByName);
			}
		}

		// Token: 0x06003CD6 RID: 15574 RVA: 0x00029029 File Offset: 0x00027229
		protected void method_11(CEvent cevent_0)
		{
			if ((this._slotStatus == uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUnlock || this._slotStatus == uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUpgrade) && this._slotData != null)
			{
				base.dispatchEvent(new GClass55(uniSkillTreeView.EVT_ONCLICK_SKILLSLOT, this._slotData, true, false));
			}
		}

		// Token: 0x06003CD7 RID: 15575 RVA: 0x00120104 File Offset: 0x0011E304
		public void method_12(SkillTreeView.SkillNodeContainer skillNodeContainer_0)
		{
			if (skillNodeContainer_0 != null && skillNodeContainer_0.Skill_0 != null)
			{
				if (skillNodeContainer_0.bUnlocked)
				{
					if (skillNodeContainer_0.Int32_1 == 0)
					{
						this._rootMC.gotoAndStop("unlock");
						this._slotStatus = uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUnlock;
					}
					else if (skillNodeContainer_0.Int32_1 < skillNodeContainer_0.Skill_0.m_maxGrade)
					{
						this._rootMC.gotoAndStop("upgrade");
						this._slotStatus = uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUpgrade;
					}
					else if (skillNodeContainer_0.Int32_1 == skillNodeContainer_0.Skill_0.m_maxGrade)
					{
						this._rootMC.gotoAndStop("complete");
						MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcFlash");
						if (childByName != null)
						{
							childByName.stop();
							childByName.visible = false;
						}
						bool flag;
						if (this._iTierID != 1)
						{
							if (this._iTierID != 2)
							{
								flag = this._slotStatus == uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUpgrade;
								goto IL_00DF;
							}
						}
						flag = this._slotStatus == uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eUnlock;
						IL_00DF:
						if (flag && childByName != null)
						{
							childByName.gotoAndPlay(1);
							childByName.visible = true;
						}
						this._slotStatus = uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eComplete;
					}
					if (skillNodeContainer_0.Int32_1 >= 0)
					{
						TextField childByName2 = this._rootMC.getChildByName<TextField>("textSkillPt");
						if (childByName2 != null)
						{
							string text = skillNodeContainer_0.Int32_1 + "/" + skillNodeContainer_0.Skill_0.m_maxGrade;
							childByName2.text = text;
						}
					}
				}
				else
				{
					this._rootMC.gotoAndStop("lock");
					this._slotStatus = uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eLock;
				}
				this._btnMouseCover.Boolean_6 = this._slotStatus != uniSkillTreeView.SkillIconSlot.SkillSlotStatus.eLock;
				MovieClip childByName3 = this._rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
				if (childByName3 != null)
				{
					MovieClip childByName4 = childByName3.getChildByName<MovieClip>(skillNodeContainer_0.Skill_0.m_icon);
					if (childByName4 != null)
					{
						childByName4.alpha = childByName3.alpha;
					}
				}
				this._slotData = skillNodeContainer_0;
				return;
			}
		}

		// Token: 0x04002AC8 RID: 10952
		protected MovieClip _rootMC;

		// Token: 0x04002AC9 RID: 10953
		protected SkillTreeView.SkillNodeContainer _slotData;

		// Token: 0x04002ACA RID: 10954
		protected int _iTierID;

		// Token: 0x04002ACB RID: 10955
		protected uniSkillTreeView.SkillIconSlot.SkillSlotStatus _slotStatus;

		// Token: 0x04002ACC RID: 10956
		protected AvatarType _avatarType = AvatarType.TOTAL;

		// Token: 0x04002ACD RID: 10957
		protected GClass25 _btnMouseCover;

		// Token: 0x020008A7 RID: 2215
		public enum SkillSlotStatus
		{
			// Token: 0x04002ACF RID: 10959
			eNone,
			// Token: 0x04002AD0 RID: 10960
			eLock,
			// Token: 0x04002AD1 RID: 10961
			eUnlock,
			// Token: 0x04002AD2 RID: 10962
			eUpgrade,
			// Token: 0x04002AD3 RID: 10963
			eComplete
		}
	}

	// Token: 0x020008A8 RID: 2216
	public class TierBGProgress : GClass51
	{
		// Token: 0x06003CD9 RID: 15577 RVA: 0x001202D0 File Offset: 0x0011E4D0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains("mcArcher"))
			{
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				this._dicArcher.Add(num, movieClip);
				flag = true;
			}
			else if (movieClip.name == "mcMask")
			{
				movieClip.visible = false;
				this._maskMC = movieClip;
				flag = true;
			}
			else if (movieClip.name == "mcSlave")
			{
				this._slaveMC = movieClip;
				flag = true;
			}
			return flag;
		}

		// Token: 0x06003CDA RID: 15578 RVA: 0x00029071 File Offset: 0x00027271
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			this._rootMC.gotoAndStop(10);
		}

		// Token: 0x06003CDB RID: 15579 RVA: 0x0012036C File Offset: 0x0011E56C
		public void method_5(int int_0)
		{
			this._iOrder = int_0;
			if (this._iOrder == 1)
			{
				this._slaveMC.gotoAndStop("green");
			}
			else if (this._iOrder == 2)
			{
				this._slaveMC.gotoAndStop("blue");
			}
			else if (this._iOrder == 3)
			{
				this._slaveMC.gotoAndStop("red");
			}
		}

		// Token: 0x06003CDC RID: 15580 RVA: 0x001203D0 File Offset: 0x0011E5D0
		public void method_6(int int_0, float float_0)
		{
			if (int_0 <= 2)
			{
				this._maskMC.y = 0f;
			}
			else
			{
				if (float_0 < 0f)
				{
					float_0 = 0f;
				}
				if (float_0 > 1f)
				{
					float_0 = 1f;
				}
				MovieClip movieClip = this._dicArcher[int_0];
				MovieClip movieClip2 = this._dicArcher[int_0 + 1];
				float num = movieClip2.y - movieClip.y;
				float num2 = movieClip.y + num * float_0;
				this._maskMC.y = num2;
			}
			Rectangle bounds = this._maskMC.getBounds(this._slaveMC);
			this._slaveMC.clipRect = bounds.rect;
			this._maskMC.visible = false;
		}

		// Token: 0x06003CDD RID: 15581 RVA: 0x00120488 File Offset: 0x0011E688
		public void method_7(string string_1)
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcBranchBG");
			if (childByName != null)
			{
				childByName.gotoAndStop(string_1);
			}
		}

		// Token: 0x04002AD4 RID: 10964
		protected Dictionary<int, MovieClip> _dicArcher = new Dictionary<int, MovieClip>();

		// Token: 0x04002AD5 RID: 10965
		protected MovieClip _maskMC;

		// Token: 0x04002AD6 RID: 10966
		protected MovieClip _slaveMC;

		// Token: 0x04002AD7 RID: 10967
		protected MovieClip _rootMC;

		// Token: 0x04002AD8 RID: 10968
		protected int _iOrder;
	}

	// Token: 0x020008A9 RID: 2217
	public class SkillNodeTips : GClass62
	{
		// Token: 0x06003CDE RID: 15582 RVA: 0x0002909C File Offset: 0x0002729C
		public SkillNodeTips(Skill skill_0, int int_0)
		{
			this._skill = skill_0;
			this._iCurGrade = int_0;
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06003CE0 RID: 15584 RVA: 0x000290BB File Offset: 0x000272BB
		// (set) Token: 0x06003CDF RID: 15583 RVA: 0x000290B2 File Offset: 0x000272B2
		public int Int32_0
		{
			get
			{
				return this._iCurGrade;
			}
			set
			{
				this._iCurGrade = value;
			}
		}

		// Token: 0x06003CE1 RID: 15585 RVA: 0x000290C3 File Offset: 0x000272C3
		public override DisplayObject vmethod_0()
		{
			if (this._skill == null)
			{
				return null;
			}
			this.method_0();
			return uniSkillTreeView.SkillNodeTips._skillInfoPanel.DisplayObjectContainer_0;
		}

		// Token: 0x06003CE2 RID: 15586 RVA: 0x000290DF File Offset: 0x000272DF
		public static void smethod_0()
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Tips.swf", "Panel_Skill_Tips", new FuncLoad(uniSkillTreeView.SkillNodeTips.smethod_1));
		}

		// Token: 0x06003CE3 RID: 15587 RVA: 0x0002910B File Offset: 0x0002730B
		protected static void smethod_1(MovieClip movieClip_0)
		{
			uniSkillTreeView.SkillNodeTips._skillInfoPanel = new uniSkillTreeView.SkillInfoPanel();
			uniSkillTreeView.SkillNodeTips._skillInfoPanel.method_0(movieClip_0);
		}

		// Token: 0x06003CE4 RID: 15588 RVA: 0x001204B0 File Offset: 0x0011E6B0
		protected void method_0()
		{
			if (uniSkillTreeView.SkillNodeTips._skillInfoPanel != null)
			{
				bool flag = this._skill.m_id != 51 && this._skill.m_id != 52 && this._skill.m_id != 101 && this._skill.m_id != 102 && this._skill.m_id != 151 && this._skill.m_id != 152 && this._skill.m_id != 1 && this._skill.m_id != 2;
				uniSkillTreeView.SkillNodeTips._skillInfoPanel.Boolean_0 = flag;
				uniSkillTreeView.SkillNodeTips._skillInfoPanel.method_5(this._skill);
				uniSkillTreeView.SkillNodeTips._skillInfoPanel.method_6(this._iCurGrade);
			}
		}

		// Token: 0x04002AD9 RID: 10969
		protected Skill _skill;

		// Token: 0x04002ADA RID: 10970
		protected int _iCurGrade;

		// Token: 0x04002ADB RID: 10971
		protected static uniSkillTreeView.SkillInfoPanel _skillInfoPanel;
	}

	// Token: 0x020008AA RID: 2218
	public class SkillInfoPanel : GClass51
	{
		// Token: 0x1700033A RID: 826
		// (set) Token: 0x06003CE7 RID: 15591 RVA: 0x0002915D File Offset: 0x0002735D
		public bool Boolean_0
		{
			set
			{
				this._bShowAttributeDes = value;
			}
		}

		// Token: 0x06003CE8 RID: 15592 RVA: 0x001205DC File Offset: 0x0011E7DC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			this._rootMC.stopAll();
			this._rootMC.mouseEnabled = false;
			this.mcTop = this._rootMC.getChildByName<MovieClip>("mcTop");
			this.mcBottom = this._rootMC.getChildByName<MovieClip>("mcBottom");
			this._textSkillName = this.mcTop.getChildByName<TextField>("textSkillName");
			this._textSkillDes = this.mcTop.getChildByName<TextField>("textSkillDes");
			this._textNextGrade = this.mcBottom.getChildByName<TextField>("textNextGrade");
			this.mcBottom.visible = false;
			for (int i = 0; i < uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT; i++)
			{
				string text = "textCurParameter_" + i;
				this._curAttributeName[i] = this.mcTop.getChildByName<TextField>(text);
				if (this._curAttributeName[i] != null)
				{
					this._curAttributeName[i].visible = false;
				}
				text = "textCurValue_" + i;
				this._curAttributeValue[i] = this.mcTop.getChildByName<TextField>(text);
				if (this._curAttributeValue[i] != null)
				{
					this._curAttributeValue[i].visible = false;
					this._curAttributeValue[i].textFormat.color = new Color(1f, 0.5f, 0f);
				}
				text = "textNextParameter_" + i;
				this._nextAttributeName[i] = this.mcBottom.getChildByName<TextField>(text);
				if (this._nextAttributeName[i] != null)
				{
					this._nextAttributeName[i].visible = false;
					this._nextAttributeName[i].textFormat.color = new Color(1f, 0.5f, 0f);
				}
				text = "textNextValue_" + i;
				this._nextAttributeValue[i] = this.mcBottom.getChildByName<TextField>(text);
				if (this._nextAttributeValue[i] != null)
				{
					this._nextAttributeValue[i].visible = false;
					this._nextAttributeValue[i].textFormat.color = new Color(1f, 0.5f, 0f);
				}
			}
		}

		// Token: 0x06003CE9 RID: 15593 RVA: 0x00029166 File Offset: 0x00027366
		public void method_5(Skill skill_0)
		{
			if (this._skill != skill_0)
			{
				this._skill = skill_0;
				this.method_7();
			}
		}

		// Token: 0x06003CEA RID: 15594 RVA: 0x0002917E File Offset: 0x0002737E
		public void method_6(int int_0)
		{
			if (this._iCurGrade != int_0)
			{
				this._iCurGrade = int_0;
				this.method_7();
			}
		}

		// Token: 0x06003CEB RID: 15595 RVA: 0x00120810 File Offset: 0x0011EA10
		protected void method_7()
		{
			if (this._skill == null)
			{
				return;
			}
			if (this._textSkillName != null)
			{
				this._textSkillName.text = LocalizedString.smethod_0(new LocalizedString(this._skill.m_name));
			}
			if (this._textSkillDes != null)
			{
				this._textSkillDes.multiline = true;
				this._textSkillDes.text = LocalizedString.smethod_0(new LocalizedString(this._skill.m_description));
			}
			Effect[] effectList = this._skill.m_effectList;
			bool flag = this._iCurGrade != 0;
			bool flag2 = this._iCurGrade < this._skill.m_maxGrade;
			this.mcBottom.visible = flag2 && this._bShowAttributeDes;
			int i = 0;
			float num = uniSkillTreeView.SkillInfoPanel.HEADER_HEIGHT + uniSkillTreeView.SkillInfoPanel.DISCRIPTION_HEIGHT;
			float num2 = uniSkillTreeView.SkillInfoPanel.BOTTOM_HEADER;
			if (this._bShowAttributeDes)
			{
				while (i < effectList.Length && i < uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT)
				{
					Effect effect = effectList[i];
					if (this._curAttributeName[i] != null)
					{
						DisplayType displayType = SkillDisplayStore.SkillDisplayStore_0.m_skillDisplaySetup.method_1(effect.m_type);
						float num3 = effect.m_firstGrade + effect.m_perGrade * (float)(this._iCurGrade - 1);
						float num4 = effect.m_firstGrade + effect.m_perGrade * (float)this._iCurGrade;
						StringBuilder stringBuilder = new StringBuilder();
						StringBuilder stringBuilder2 = new StringBuilder();
						if (num3 >= 0f)
						{
							stringBuilder.Append(" + ");
						}
						else
						{
							num3 = -num3;
							stringBuilder.Append(" - ");
						}
						if (num4 >= 0f)
						{
							stringBuilder2.Append(" + ");
						}
						else
						{
							num4 = -num4;
							stringBuilder2.Append(" - ");
						}
						if (displayType == DisplayType.Percentage)
						{
							stringBuilder.Append(num3 * 100f).Append(" % ");
							stringBuilder2.Append(num4 * 100f).Append(" % ");
						}
						else
						{
							stringBuilder.Append(num3);
							stringBuilder2.Append(num4);
						}
						this._curAttributeValue[i].text = stringBuilder.ToString();
						this._curAttributeValue[i].visible = flag;
						this._curAttributeName[i].text = LocalizedString.smethod_0(new LocalizedString(effect.m_type.ToString()));
						this._curAttributeName[i].visible = flag;
						if (flag)
						{
							num += uniSkillTreeView.SkillInfoPanel.ROW_HEIGHT;
						}
						this._nextAttributeName[i].text = LocalizedString.smethod_0(new LocalizedString(effect.m_type.ToString()));
						this._nextAttributeName[i].visible = flag2;
						this._nextAttributeValue[i].text = stringBuilder2.ToString();
						this._nextAttributeValue[i].visible = flag2;
						if (flag2)
						{
							num2 += uniSkillTreeView.SkillInfoPanel.ROW_HEIGHT;
						}
					}
					i++;
				}
			}
			this.mcTop.getChildByName<BadAssMovieClip>("mcBackGround").Single_1 = num + uniSkillTreeView.SkillInfoPanel.FOOTER_HEIGHT;
			this.mcBottom.y = num;
			this.mcBottom.getChildByName<BadAssMovieClip>("mcBottomBg").Single_1 = num2 + uniSkillTreeView.SkillInfoPanel.FOOTER_HEIGHT;
			while (i < uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT)
			{
				this._curAttributeName[i].visible = false;
				this._curAttributeValue[i].visible = false;
				this._nextAttributeName[i].visible = false;
				this._nextAttributeValue[i].visible = false;
				i++;
			}
		}

		// Token: 0x04002ADC RID: 10972
		protected Skill _skill;

		// Token: 0x04002ADD RID: 10973
		protected MovieClip _rootMC;

		// Token: 0x04002ADE RID: 10974
		protected MovieClip mcTop;

		// Token: 0x04002ADF RID: 10975
		protected MovieClip mcBottom;

		// Token: 0x04002AE0 RID: 10976
		protected int _iCurGrade = -1;

		// Token: 0x04002AE1 RID: 10977
		protected bool _bShowAttributeDes = true;

		// Token: 0x04002AE2 RID: 10978
		protected static int MAX_ATTRIBUTE_COUNT = 3;

		// Token: 0x04002AE3 RID: 10979
		protected static float HEADER_HEIGHT = 50f;

		// Token: 0x04002AE4 RID: 10980
		protected static float FOOTER_HEIGHT = 50f;

		// Token: 0x04002AE5 RID: 10981
		protected static float BOTTOM_HEADER = 30f;

		// Token: 0x04002AE6 RID: 10982
		protected static float DISCRIPTION_HEIGHT = 112f;

		// Token: 0x04002AE7 RID: 10983
		protected static float ROW_HEIGHT = 28f;

		// Token: 0x04002AE8 RID: 10984
		protected TextField _textSkillName;

		// Token: 0x04002AE9 RID: 10985
		protected TextField _textSkillDes;

		// Token: 0x04002AEA RID: 10986
		protected TextField _textNextGrade;

		// Token: 0x04002AEB RID: 10987
		protected TextField[] _curAttributeName = new TextField[uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT];

		// Token: 0x04002AEC RID: 10988
		protected TextField[] _curAttributeValue = new TextField[uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT];

		// Token: 0x04002AED RID: 10989
		protected TextField[] _nextAttributeName = new TextField[uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT];

		// Token: 0x04002AEE RID: 10990
		protected TextField[] _nextAttributeValue = new TextField[uniSkillTreeView.SkillInfoPanel.MAX_ATTRIBUTE_COUNT];
	}
}
