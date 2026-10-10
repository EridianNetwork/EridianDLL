using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x0200086D RID: 2157
public class uniNPCInteractiveView : NPCInteractiveView
{
	// Token: 0x06003AE2 RID: 15074 RVA: 0x00114870 File Offset: 0x00112A70
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Quest.swf", "NPCFunctionList", new FuncLoad(this.method_7));
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_6), false);
	}

	// Token: 0x06003AE3 RID: 15075 RVA: 0x000277D9 File Offset: 0x000259D9
	protected void method_6()
	{
		if (!this._bVisible)
		{
			return;
		}
		if (this._root != null && MonoSingleton<InputManager>.Instance.method_9("Jump") && this._root.Int32_0 <= 2)
		{
			this._root.method_5();
		}
	}

	// Token: 0x06003AE4 RID: 15076 RVA: 0x00027816 File Offset: 0x00025A16
	public override void vmethod_7(NPCInteractiveView.FunctionListItemData functionListItemData_0)
	{
		if (this._animaContainerMC != null && this._animaContainerMC.isPlaying)
		{
			return;
		}
		base.vmethod_7(functionListItemData_0);
	}

	// Token: 0x06003AE5 RID: 15077 RVA: 0x001148D0 File Offset: 0x00112AD0
	private void method_7(MovieClip movieClip_0)
	{
		movieClip_0.visible = false;
		this._animaContainer = new GClass51();
		this._animaContainer.method_0(movieClip_0);
		this._animaContainerMC = movieClip_0;
		this._animaContainerMC.visible = false;
		this._animaContainerMC.addFrameScript("fadein", new EventDispatcher.EventCallback(this.method_9));
		this._animaContainerMC.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_9));
		this._animaContainerMC.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_9));
		this._animaContainerMC.addFrameScript("KeyFrame_1", new EventDispatcher.EventCallback(this.method_9));
		this._animaContainerMC.addFrameScript("AniEnd", new EventDispatcher.EventCallback(this.method_8));
		this._root = new uniNPCInteractiveView.NPCFunctionList();
		this._root.DeleOnClickButton_0 = new uniNPCInteractiveView.deleOnClickButton(this.vmethod_7);
		MovieClip childByName = this._animaContainerMC.getChildByName<MovieClip>("mcFunctionList");
		if (childByName != null)
		{
			this._root.method_0(movieClip_0);
		}
		this._bActive = true;
	}

	// Token: 0x06003AE6 RID: 15078 RVA: 0x00027835 File Offset: 0x00025A35
	protected void method_8(CEvent cevent_0)
	{
		this._animaContainerMC.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._animaContainer);
	}

	// Token: 0x06003AE7 RID: 15079 RVA: 0x0002785D File Offset: 0x00025A5D
	protected void method_9(CEvent cevent_0)
	{
		this.method_10();
	}

	// Token: 0x06003AE8 RID: 15080 RVA: 0x001149EC File Offset: 0x00112BEC
	protected void method_10()
	{
		MovieClip childByName = this._animaContainerMC.getChildByName<MovieClip>("mcFunctionList");
		if (childByName != null)
		{
			this._root.method_0(childByName);
		}
		if (this._totalList != null)
		{
			this._root.method_8(this._totalList);
			if (this._NPCInfo != null)
			{
				this._root.method_7(this._NPCInfo.m_nameId, this._NPCInfo.m_greetingsId);
			}
		}
	}

	// Token: 0x06003AE9 RID: 15081 RVA: 0x00114A5C File Offset: 0x00112C5C
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._animaContainer != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._animaContainer);
		}
		this._animaContainer = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Quest.swf");
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_6));
		this._root = null;
	}

	// Token: 0x06003AEA RID: 15082 RVA: 0x00114AD4 File Offset: 0x00112CD4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._animaContainer);
			this._animaContainerMC.visible = true;
			this._animaContainerMC.gotoAndPlay("fadein");
			this.method_10();
			this.vmethod_6();
		}
		else
		{
			this._animaContainerMC.gotoAndPlay("fadeout");
		}
	}

	// Token: 0x06003AEB RID: 15083 RVA: 0x00027865 File Offset: 0x00025A65
	public override void vmethod_5(global::XsdSettings.TownNpc townNpc_0)
	{
		base.vmethod_5(townNpc_0);
		if (this._root != null)
		{
			this._root.method_7(this._NPCInfo.m_nameId, this._NPCInfo.m_greetingsId);
		}
	}

	// Token: 0x06003AEC RID: 15084 RVA: 0x00027897 File Offset: 0x00025A97
	protected override void vmethod_6()
	{
		base.vmethod_6();
		if (!this._bActive)
		{
			return;
		}
		if (this._root != null)
		{
			this._root.method_8(this._totalList);
		}
	}

	// Token: 0x0400294A RID: 10570
	protected uniNPCInteractiveView.NPCFunctionList _root;

	// Token: 0x0400294B RID: 10571
	protected GClass51 _animaContainer;

	// Token: 0x0400294C RID: 10572
	protected MovieClip _animaContainerMC;

	// Token: 0x0200086E RID: 2158
	public class NPCFunctionList : GClass51
	{
		// Token: 0x17000322 RID: 802
		// (set) Token: 0x06003AEE RID: 15086 RVA: 0x000278FA File Offset: 0x00025AFA
		public uniNPCInteractiveView.deleOnClickButton DeleOnClickButton_0
		{
			set
			{
				this._deleOnClickButton = value;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06003AEF RID: 15087 RVA: 0x00027903 File Offset: 0x00025B03
		public int Int32_0
		{
			get
			{
				return this._allItemInfoList.Count;
			}
		}

		// Token: 0x06003AF0 RID: 15088 RVA: 0x00114B48 File Offset: 0x00112D48
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains(this._strListNamePrefix))
			{
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				if (this._functionItemList[num - 1] == null)
				{
					this._functionItemList[num - 1] = new uniNPCInteractiveView.NPCFunctionListButton();
					this._functionItemList[num - 1].DeleOnClickButton_0 = this._deleOnClickButton;
				}
				this._functionItemList[num - 1].method_0(movieClip);
				flag = true;
			}
			else if (movieClip.name == "mcScrollingBar")
			{
				this._scBar.method_0(movieClip);
				this._scBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_6));
				GClass45 scBar = this._scBar;
				this._scBar.int_1 = 0;
				scBar.int_0 = 0;
			}
			return flag;
		}

		// Token: 0x06003AF1 RID: 15089 RVA: 0x00027910 File Offset: 0x00025B10
		public void method_5()
		{
			if (this.Int32_0 > 0)
			{
				this._deleOnClickButton(this._allItemInfoList[0]);
			}
		}

		// Token: 0x06003AF2 RID: 15090 RVA: 0x00114C2C File Offset: 0x00112E2C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			this._textNpcName = (UnityTextField)this._rootMC.getChildByName<TextField>("textNpcName");
			this._textGreeting = (UnityTextField)this._rootMC.getChildByName<TextField>("textGreeting");
		}

		// Token: 0x06003AF3 RID: 15091 RVA: 0x00027932 File Offset: 0x00025B32
		protected void method_6(CEvent cevent_0)
		{
			this.method_9();
		}

		// Token: 0x06003AF4 RID: 15092 RVA: 0x0002793A File Offset: 0x00025B3A
		public void method_7(string string_1, string string_2)
		{
			if (this._textNpcName != null)
			{
				this._textNpcName.text = LocalizedString.smethod_0(new LocalizedString(string_1));
			}
			if (this._textGreeting != null)
			{
				this._textGreeting.text = LocalizedString.smethod_0(new LocalizedString(string_2));
			}
		}

		// Token: 0x06003AF5 RID: 15093 RVA: 0x00114C88 File Offset: 0x00112E88
		public void method_8(List<NPCInteractiveView.FunctionListItemData> list_1)
		{
			this._allItemInfoList = list_1;
			if (this._scBar != null)
			{
				this._scBar.Boolean_1 = this._allItemInfoList.Count > 6;
				this._scBar.method_10(this._functionItemList.Length, 0, list_1.Count - this._functionItemList.Length, 1);
				this._scBar.Int32_1 = 0;
			}
			this._iOnShowItemCnt = ((this._functionItemList.Length <= list_1.Count) ? this._functionItemList.Length : list_1.Count);
			int num = 0;
			foreach (NPCInteractiveView.FunctionListItemData functionListItemData in this._allItemInfoList)
			{
				if (functionListItemData.bAlwaysInBoard)
				{
					num++;
				}
			}
			this._iMaxScrollableItemCnt = this._functionItemList.Length - num;
			this.method_9();
		}

		// Token: 0x06003AF6 RID: 15094 RVA: 0x00114D78 File Offset: 0x00112F78
		protected void method_9()
		{
			List<NPCInteractiveView.FunctionListItemData> list = new List<NPCInteractiveView.FunctionListItemData>();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this._allItemInfoList.Count; i++)
			{
				NPCInteractiveView.FunctionListItemData functionListItemData = this._allItemInfoList[i];
				if (functionListItemData != null)
				{
					if (functionListItemData.bAlwaysInBoard)
					{
						list.Add(functionListItemData);
					}
					else if (num < this._scBar.Int32_1)
					{
						num++;
					}
					else if (num2 < this._iMaxScrollableItemCnt)
					{
						list.Add(functionListItemData);
						num2++;
					}
				}
			}
			int j;
			for (j = 0; j < list.Count; j++)
			{
				NPCInteractiveView.FunctionListItemData functionListItemData2 = list[j];
				uniNPCInteractiveView.NPCFunctionListButton npcfunctionListButton = this._functionItemList[j];
				if (functionListItemData2 != null && npcfunctionListButton != null)
				{
					npcfunctionListButton.method_7(functionListItemData2);
					npcfunctionListButton.method_5(true);
				}
			}
			while (j < this._functionItemList.Length)
			{
				uniNPCInteractiveView.NPCFunctionListButton npcfunctionListButton2 = this._functionItemList[j];
				if (npcfunctionListButton2 != null)
				{
					npcfunctionListButton2.method_5(false);
				}
				j++;
			}
		}

		// Token: 0x0400294D RID: 10573
		protected MovieClip _rootMC;

		// Token: 0x0400294E RID: 10574
		protected GClass46 _scBar = new GClass46();

		// Token: 0x0400294F RID: 10575
		protected UnityTextField _textNpcName;

		// Token: 0x04002950 RID: 10576
		protected UnityTextField _textGreeting;

		// Token: 0x04002951 RID: 10577
		protected string _strListNamePrefix = "mcNPCItem_";

		// Token: 0x04002952 RID: 10578
		protected List<NPCInteractiveView.FunctionListItemData> _allItemInfoList = new List<NPCInteractiveView.FunctionListItemData>();

		// Token: 0x04002953 RID: 10579
		protected uniNPCInteractiveView.NPCFunctionListButton[] _functionItemList = new uniNPCInteractiveView.NPCFunctionListButton[NPCInteractiveView.MAX_FUNCTION_ITEM_COUNT];

		// Token: 0x04002954 RID: 10580
		protected uniNPCInteractiveView.deleOnClickButton _deleOnClickButton;

		// Token: 0x04002955 RID: 10581
		protected int _iOnShowItemCnt;

		// Token: 0x04002956 RID: 10582
		protected int _iMaxScrollableItemCnt;
	}

	// Token: 0x0200086F RID: 2159
	public class NPCFunctionListButton : GClass51
	{
		// Token: 0x17000324 RID: 804
		// (set) Token: 0x06003AF8 RID: 15096 RVA: 0x00027978 File Offset: 0x00025B78
		public uniNPCInteractiveView.deleOnClickButton DeleOnClickButton_0
		{
			set
			{
				this._deleOnClickButton = value;
			}
		}

		// Token: 0x06003AF9 RID: 15097 RVA: 0x00114E64 File Offset: 0x00113064
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._relateItem = new uniNPCInteractiveView.NPCFunctionListSlot();
			this._relateItem.method_0(this._rootMC.getChildByName<MovieClip>("mcListItem"));
			this._rootBtn = new GClass25();
			this._rootBtn.method_0(this._rootMC);
			this._rootBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			this.method_8();
		}

		// Token: 0x06003AFA RID: 15098 RVA: 0x000276A2 File Offset: 0x000258A2
		public void method_5(bool bool_0)
		{
			if (base.DisplayObjectContainer_0 != null)
			{
				base.DisplayObjectContainer_0.visible = bool_0;
			}
		}

		// Token: 0x06003AFB RID: 15099 RVA: 0x00027981 File Offset: 0x00025B81
		protected void method_6(CEvent cevent_0)
		{
			if (this._deleOnClickButton != null)
			{
				this._deleOnClickButton(this._relateFunctionInfo);
			}
		}

		// Token: 0x06003AFC RID: 15100 RVA: 0x0002799C File Offset: 0x00025B9C
		public void method_7(NPCInteractiveView.FunctionListItemData functionListItemData_0)
		{
			this._relateFunctionInfo = functionListItemData_0;
			this.method_8();
		}

		// Token: 0x06003AFD RID: 15101 RVA: 0x000279AB File Offset: 0x00025BAB
		protected void method_8()
		{
			if (this._relateFunctionInfo == null)
			{
				this._rootMC.visible = false;
				return;
			}
			this._relateItem.method_5(this._relateFunctionInfo);
		}

		// Token: 0x04002957 RID: 10583
		protected MovieClip _rootMC;

		// Token: 0x04002958 RID: 10584
		protected GClass25 _rootBtn;

		// Token: 0x04002959 RID: 10585
		protected uniNPCInteractiveView.NPCFunctionListSlot _relateItem;

		// Token: 0x0400295A RID: 10586
		protected NPCInteractiveView.FunctionListItemData _relateFunctionInfo;

		// Token: 0x0400295B RID: 10587
		protected uniNPCInteractiveView.deleOnClickButton _deleOnClickButton;
	}

	// Token: 0x02000870 RID: 2160
	public class NPCFunctionListSlot : GClass51
	{
		// Token: 0x06003AFF RID: 15103 RVA: 0x00114EF0 File Offset: 0x001130F0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			this._rootMC.visible = false;
			this._Item = new uniNPCInteractiveView.NPCFunctionListItem();
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
		}

		// Token: 0x06003B00 RID: 15104 RVA: 0x00114F48 File Offset: 0x00113148
		public void method_5(NPCInteractiveView.FunctionListItemData functionListItemData_0)
		{
			this._data = functionListItemData_0;
			if (functionListItemData_0 == null)
			{
				this._rootMC.visible = false;
				return;
			}
			this._strListItemName = "mcListItem_";
			string text = "Common";
			switch (functionListItemData_0.functionType)
			{
			case NPC_UIFlowController.NPC_UIFlowState.None:
				text = "Close";
				break;
			case NPC_UIFlowController.NPC_UIFlowState.Quest:
				text = "Quest";
				break;
			}
			this._strListItemName += text;
			this._rootMC.gotoAndStop(text);
		}

		// Token: 0x06003B01 RID: 15105 RVA: 0x00114FC8 File Offset: 0x001131C8
		protected void method_6(CEvent cevent_0)
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>(this._strListItemName);
			if (childByName != null)
			{
				this._Item.method_0(childByName);
				if (this._data != null)
				{
					this._Item.method_5(this._data);
				}
			}
		}

		// Token: 0x0400295C RID: 10588
		protected MovieClip _rootMC;

		// Token: 0x0400295D RID: 10589
		protected uniNPCInteractiveView.NPCFunctionListItem _Item;

		// Token: 0x0400295E RID: 10590
		protected NPCInteractiveView.FunctionListItemData _data;

		// Token: 0x0400295F RID: 10591
		protected string _strListItemName = string.Empty;
	}

	// Token: 0x02000871 RID: 2161
	public class NPCFunctionListItem : GClass51
	{
		// Token: 0x06003B03 RID: 15107 RVA: 0x00115010 File Offset: 0x00113210
		public void method_5(NPCInteractiveView.FunctionListItemData functionListItemData_0)
		{
			MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
			if (functionListItemData_0 != null && movieClip != null)
			{
				if (functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Quest)
				{
					if (functionListItemData_0.quest == null || functionListItemData_0.questProgress == null)
					{
						return;
					}
					UnityTextField childByName = movieClip.getChildByName<UnityTextField>("ItemText");
					if (childByName != null)
					{
						Color color = Color.white;
						switch (functionListItemData_0.questProgress.mStatus)
						{
						case QuestState.Available:
							if (functionListItemData_0.quest.mCategory == QuestCategory.Daily)
							{
								color = new Color(0f, 0.514f, 1f);
							}
							else if (functionListItemData_0.quest.mCategory == QuestCategory.Special)
							{
								color = new Color(0.227f, 0.694f, 1f);
							}
							else
							{
								color = Color.yellow;
							}
							break;
						case QuestState.InProgress:
							color = Color.white;
							break;
						case QuestState.Completed:
							color = Color.green;
							break;
						}
						childByName.text = LocalizedString.smethod_0(new LocalizedString(functionListItemData_0.quest.mTitle));
						childByName.Color_0 = color;
					}
					MovieClip childByName2 = movieClip.getChildByName<MovieClip>("mcQuestTypeIcon");
					if (childByName2 != null)
					{
						childByName2.gotoAndStop(functionListItemData_0.quest.mCategory.ToString());
						string text = Utility.smethod_5("mcIconColor_", functionListItemData_0.quest.mCategory.ToString());
						MovieClip childByName3 = childByName2.getChildByName<MovieClip>(text);
						if (childByName3 != null)
						{
							childByName3.gotoAndStop(functionListItemData_0.questProgress.mStatus.ToString());
						}
					}
				}
				else if (functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Melting || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.WeaponShop || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.ClassModeShop || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.CoinShieldShop || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Crafting || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.CreateGuild || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.DismissGuild || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Mail || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Warehouse || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.WeaponUpgrade || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.QuitGuild || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.PvP || functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.MaterialShop)
				{
					UnityTextField childByName4 = movieClip.getChildByName<MovieClip>("mcTitleContainer").getChildByName<UnityTextField>("textTitle");
					if (childByName4 != null)
					{
						childByName4.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("NPC_", functionListItemData_0.functionType.ToString())));
					}
				}
				return;
			}
		}

		// Token: 0x04002960 RID: 10592
		protected const string KEY_PREFIX = "NPC_";
	}

	// Token: 0x02000872 RID: 2162
	// (Invoke) Token: 0x06003B05 RID: 15109
	public delegate void deleOnClickButton(NPCInteractiveView.FunctionListItemData itemData);
}
