using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x020007EB RID: 2027
public class uniEchoMessageView : EchoMessageView
{
	// Token: 0x060036BE RID: 14014 RVA: 0x000242B5 File Offset: 0x000224B5
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._arrEchoMsgHandler.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Echo.swf", "RootEchoPanel", new FuncLoad(this.method_3));
	}

	// Token: 0x060036BF RID: 14015 RVA: 0x000FAA78 File Offset: 0x000F8C78
	private void method_3(MovieClip movieClip_0)
	{
		this._rootPanel = new GClass51();
		this._rootPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		movieClip_0.mouseEnabled = false;
		float num = MonoSingleton<GameSettingMgr>.Instance.method_10(SettingFunctionType.EchoDuration);
		num = ((num <= 0f) ? EchoMessageView.DEFAUL_DURATION : num);
		this.vmethod_8(num);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._rootPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_39();
	}

	// Token: 0x060036C0 RID: 14016 RVA: 0x000FAB04 File Offset: 0x000F8D04
	public override void vmethod_3()
	{
		base.vmethod_3();
		foreach (uniEchoMessageView.EchoMsgHandlerDashBorad echoMsgHandlerDashBorad in this._arrEchoMsgHandler)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_6(echoMsgHandlerDashBorad);
		}
		this._arrEchoMsgHandler.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		this._rootPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Echo.swf");
	}

	// Token: 0x060036C1 RID: 14017 RVA: 0x000242F2 File Offset: 0x000224F2
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._rootPanel != null)
		{
			this._rootPanel.DisplayObjectContainer_0.visible = this._bVisible;
		}
	}

	// Token: 0x060036C2 RID: 14018 RVA: 0x000FAB84 File Offset: 0x000F8D84
	public override void vmethod_8(float float_0)
	{
		base.vmethod_8(float_0);
		foreach (uniEchoMessageView.EchoMsgHandlerDashBorad echoMsgHandlerDashBorad in this._arrEchoMsgHandler)
		{
			echoMsgHandlerDashBorad.vmethod_2(float_0);
		}
	}

	// Token: 0x060036C3 RID: 14019 RVA: 0x000FABE0 File Offset: 0x000F8DE0
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcEventPanel":
		{
			uniEchoMessageView.EventEchoHandler eventEchoHandler = new uniEchoMessageView.EventEchoHandler();
			eventEchoHandler.method_0(movieClip);
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Event, eventEchoHandler);
			this._arrEchoMsgHandler.Add(eventEchoHandler);
			flag = true;
			break;
		}
		case "mcBroadcastPanel":
		{
			uniEchoMessageView.BroadcastHandler broadcastHandler = new uniEchoMessageView.BroadcastHandler();
			broadcastHandler.method_0(movieClip);
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Broadcast, broadcastHandler);
			this._arrEchoMsgHandler.Add(broadcastHandler);
			flag = true;
			break;
		}
		case "mcLevelNotifPanel":
		{
			uniEchoMessageView.LevelNotificationHandler levelNotificationHandler = new uniEchoMessageView.LevelNotificationHandler();
			levelNotificationHandler.method_0(movieClip);
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.LevelNotification, levelNotificationHandler);
			this._arrEchoMsgHandler.Add(levelNotificationHandler);
			flag = true;
			break;
		}
		case "mcDialogPanel":
		{
			uniEchoMessageView.LevelNotificationHandler levelNotificationHandler2 = new uniEchoMessageView.LevelNotificationHandler();
			levelNotificationHandler2.vmethod_2(3f);
			levelNotificationHandler2.method_0(movieClip);
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Dialog, levelNotificationHandler2);
			this._arrEchoMsgHandler.Add(levelNotificationHandler2);
			flag = true;
			break;
		}
		case "mcNPCPortrait":
		{
			uniEchoMessageView.NPCPortraitHandler npcportraitHandler = new uniEchoMessageView.NPCPortraitHandler();
			npcportraitHandler.method_0(movieClip);
			movieClip.stopAll();
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Dialog, npcportraitHandler);
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Broadcast, npcportraitHandler);
			movieClip.visible = false;
			this._arrEchoMsgHandler.Add(npcportraitHandler);
			flag = true;
			break;
		}
		case "mcCountdownPanel":
		{
			uniEchoMessageView.CountdownHandler countdownHandler = new uniEchoMessageView.CountdownHandler();
			countdownHandler.method_0(movieClip);
			movieClip.stopAll();
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_5(DisplayTarget.Countdown, countdownHandler);
			movieClip.visible = false;
			this._arrEchoMsgHandler.Add(countdownHandler);
			flag = true;
			break;
		}
		}
		return flag;
	}

	// Token: 0x040025D8 RID: 9688
	private GClass51 _rootPanel;

	// Token: 0x040025D9 RID: 9689
	private List<uniEchoMessageView.EchoMsgHandlerDashBorad> _arrEchoMsgHandler = new List<uniEchoMessageView.EchoMsgHandlerDashBorad>();

	// Token: 0x020007EC RID: 2028
	protected class EchoMsgHandlerDashBorad : GClass51, GInterface0
	{
		// Token: 0x060036C5 RID: 14021 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void imethod_0(EchoMessage echoMessage_0)
		{
		}

		// Token: 0x060036C6 RID: 14022 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void Update()
		{
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x0002432D File Offset: 0x0002252D
		public virtual void vmethod_2(float float_0)
		{
			if (float_0 > 0f)
			{
				this.DISPLAY_TIME = float_0;
			}
			else
			{
				this.DISPLAY_TIME = 5f;
			}
		}

		// Token: 0x040025DB RID: 9691
		protected float DISPLAY_TIME = 5f;
	}

	// Token: 0x020007ED RID: 2029
	protected class CountdownHandler : uniEchoMessageView.EchoMsgHandlerDashBorad
	{
		private static System.Collections.Generic.Dictionary<string, int> f__switch_map11;
		// Token: 0x060036C9 RID: 14025 RVA: 0x00024353 File Offset: 0x00022553
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			this.mcSelf.gotoAndStop("fadein");
		}

		// Token: 0x060036CA RID: 14026 RVA: 0x000FADEC File Offset: 0x000F8FEC
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (uniEchoMessageView.CountdownHandler.f__switch_map11 == null)
				{
					uniEchoMessageView.CountdownHandler.f__switch_map11 = new Dictionary<string, int>(1) { { "mcRoot", 0 } };
				}
				int num;
				if (uniEchoMessageView.CountdownHandler.f__switch_map11.TryGetValue(name, out num) && num == 0)
				{
					this.mcRoot = movieClip;
					this.textField = this.mcRoot.getChildByName<UnityTextField>("textField");
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x060036CB RID: 14027 RVA: 0x000FAE5C File Offset: 0x000F905C
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			try
			{
				this.m_totalTimer = double.Parse(echoMessage_0.m_localizedText);
			}
			catch (Exception ex)
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, ex.ToString());
			}
			this.mcSelf.gotoAndPlay("fadein");
			this.mcSelf.visible = true;
			this.method_5();
		}

		// Token: 0x060036CC RID: 14028 RVA: 0x000FAEC0 File Offset: 0x000F90C0
		private void method_5()
		{
			this.textField.text = Math.Ceiling(this.m_totalTimer).ToString();
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x0002437C File Offset: 0x0002257C
		private void method_6()
		{
			this.mcSelf.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_7));
			this.mcSelf.gotoAndPlay("fadeout");
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x000243AB File Offset: 0x000225AB
		protected void method_7(CEvent cevent_0)
		{
			this.mcSelf.removeFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_7));
			this.mcSelf.visible = false;
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x000FAEEC File Offset: 0x000F90EC
		public override void Update()
		{
			if (this.m_totalTimer > 0.0)
			{
				this.m_totalTimer -= (double)Time.deltaTime;
				if (this.m_totalTimer <= 0.0)
				{
					this.m_totalTimer = 0.0;
					this.method_6();
				}
				else
				{
					this.method_5();
				}
			}
		}

		// Token: 0x040025DC RID: 9692
		protected const string START_FRAME = "fadein";

		// Token: 0x040025DD RID: 9693
		protected const string END_FRAME = "fadeout";

		// Token: 0x040025DE RID: 9694
		protected const string LAST_FRAME = "AnimationEnd";

		// Token: 0x040025DF RID: 9695
		protected MovieClip mcSelf;

		// Token: 0x040025E0 RID: 9696
		protected MovieClip mcRoot;

		// Token: 0x040025E1 RID: 9697
		protected UnityTextField textField;

		// Token: 0x040025E2 RID: 9698
		protected double m_totalTimer;
	}

	// Token: 0x020007EE RID: 2030
	protected class EchoSingleTextPanel : uniEchoMessageView.EchoMsgHandlerDashBorad
	{
		private static System.Collections.Generic.Dictionary<string, int> f__switch_map12;
		// Token: 0x060036D1 RID: 14033 RVA: 0x000243D6 File Offset: 0x000225D6
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			this.mcSelf.gotoAndStop("AnimationEnd");
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x000FAF4C File Offset: 0x000F914C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (uniEchoMessageView.EchoSingleTextPanel.f__switch_map12 == null)
				{
					uniEchoMessageView.EchoSingleTextPanel.f__switch_map12 = new Dictionary<string, int>(1) { { "mcRoot", 0 } };
				}
				int num;
				if (uniEchoMessageView.EchoSingleTextPanel.f__switch_map12.TryGetValue(name, out num) && num == 0)
				{
					this.mcRoot = movieClip;
					this.textField = this.mcRoot.getChildByName<UnityTextField>("textField");
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x000243FF File Offset: 0x000225FF
		public void method_5(string string_1)
		{
			this.mcSelf.gotoAndPlay("fadein");
			this.textField.text = string_1;
		}

		// Token: 0x060036D4 RID: 14036 RVA: 0x0002441D File Offset: 0x0002261D
		public void method_6()
		{
			this.mcSelf.gotoAndPlay("fadeout");
		}

		// Token: 0x040025E4 RID: 9700
		protected const string START_FRAME = "fadein";

		// Token: 0x040025E5 RID: 9701
		protected const string END_FRAME = "fadeout";

		// Token: 0x040025E6 RID: 9702
		protected const string LAST_FRAME = "AnimationEnd";

		// Token: 0x040025E7 RID: 9703
		protected const string NORMAL_FRAME = "normal";

		// Token: 0x040025E8 RID: 9704
		protected MovieClip mcSelf;

		// Token: 0x040025E9 RID: 9705
		protected MovieClip mcRoot;

		// Token: 0x040025EA RID: 9706
		protected UnityTextField textField;
	}

	// Token: 0x020007EF RID: 2031
	protected class LoopingSingleLineTextPanel : uniEchoMessageView.EchoMsgHandlerDashBorad
	{
		private static System.Collections.Generic.Dictionary<string, int> f__switch_map13;
		// Token: 0x060036D6 RID: 14038 RVA: 0x000FAFBC File Offset: 0x000F91BC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			this.mcSelf.gotoAndStop("start");
			this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x060036D7 RID: 14039 RVA: 0x0002442F File Offset: 0x0002262F
		protected void method_5(CEvent cevent_0)
		{
			if (this.mcMask != null)
			{
				this.mcRoot.clipRect = this.mcMask.getBounds(this.mcRoot).rect;
			}
		}

		// Token: 0x060036D8 RID: 14040 RVA: 0x000FB010 File Offset: 0x000F9210
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (uniEchoMessageView.LoopingSingleLineTextPanel.f__switch_map13 == null)
				{
					uniEchoMessageView.LoopingSingleLineTextPanel.f__switch_map13 = new Dictionary<string, int>(2)
					{
						{ "mcRoot", 0 },
						{ "mcMask", 1 }
					};
				}
				int num;
				if (uniEchoMessageView.LoopingSingleLineTextPanel.f__switch_map13.TryGetValue(name, out num))
				{
					if (num != 0)
					{
						if (num == 1)
						{
							this.mcMask = movieClip;
							if (this.mcRoot != null)
							{
								this.mcRoot.clipRect = this.mcMask.getBounds(this.mcRoot).rect;
							}
							flag = false;
						}
					}
					else
					{
						this.mcRoot = movieClip;
						this.textField = this.mcRoot.getChildByName<UnityTextField>("textField");
						if (this.mcMask != null)
						{
							this.mcRoot.clipRect = this.mcMask.getBounds(this.mcRoot).rect;
						}
						flag = false;
					}
				}
			}
			return flag;
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x0002445A File Offset: 0x0002265A
		public void method_6(string string_1)
		{
			this.mcSelf.gotoAndPlay("start");
			this.textField.text = string_1;
		}

		// Token: 0x060036DA RID: 14042 RVA: 0x00024478 File Offset: 0x00022678
		public void method_7()
		{
			this.mcSelf.gotoAndStop("end");
		}

		// Token: 0x040025EC RID: 9708
		protected const string START_FRAME = "start";

		// Token: 0x040025ED RID: 9709
		protected const string END_FRAME = "end";

		// Token: 0x040025EE RID: 9710
		protected MovieClip mcSelf;

		// Token: 0x040025EF RID: 9711
		protected MovieClip mcRoot;

		// Token: 0x040025F0 RID: 9712
		protected MovieClip mcMask;

		// Token: 0x040025F1 RID: 9713
		protected UnityTextField textField;
	}

	// Token: 0x020007F0 RID: 2032
	protected class EventEchoHandler : uniEchoMessageView.LoopingSingleLineTextPanel
	{
		// Token: 0x060036DC RID: 14044 RVA: 0x000FB0F4 File Offset: 0x000F92F4
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			uniEchoMessageView.EventEchoHandler.EventMsg eventMsg = new uniEchoMessageView.EventEchoHandler.EventMsg
			{
				message = echoMessage_0,
				_loopingTime = 3
			};
			this._arrEventList.Add(eventMsg);
			if (this._currentIndex < 0)
			{
				this._currentIndex = 0;
				this.method_8();
			}
		}

		// Token: 0x060036DD RID: 14045 RVA: 0x000FB13C File Offset: 0x000F933C
		public void method_8()
		{
			if (this._arrEventList[this._currentIndex]._loopingTime <= 0)
			{
				this._arrEventList.RemoveAt(this._currentIndex--);
			}
			if (this._arrEventList.Count > 0)
			{
				this._currentIndex = (this._currentIndex + 1) % this._arrEventList.Count;
				this._arrEventList[this._currentIndex]._loopingTime--;
				base.method_6(this._arrEventList[this._currentIndex].message.m_localizedText);
			}
			else
			{
				base.method_7();
				this._currentIndex = -1;
			}
		}

		// Token: 0x060036DE RID: 14046 RVA: 0x000244A4 File Offset: 0x000226A4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf.addFrameScript("end", new EventDispatcher.EventCallback(this.method_9));
		}

		// Token: 0x060036DF RID: 14047 RVA: 0x000244C9 File Offset: 0x000226C9
		protected void method_9(CEvent cevent_0)
		{
			this.method_8();
		}

		// Token: 0x040025F3 RID: 9715
		protected const int DEFAULT_LOOP_TIMES = 3;

		// Token: 0x040025F4 RID: 9716
		protected List<uniEchoMessageView.EventEchoHandler.EventMsg> _arrEventList = new List<uniEchoMessageView.EventEchoHandler.EventMsg>();

		// Token: 0x040025F5 RID: 9717
		protected int _currentIndex = -1;

		// Token: 0x020007F1 RID: 2033
		protected class EventMsg
		{
			// Token: 0x040025F6 RID: 9718
			public EchoMessage message;

			// Token: 0x040025F7 RID: 9719
			public int _loopingTime;
		}
	}

	// Token: 0x020007F2 RID: 2034
	protected class BroadcastHandler : uniEchoMessageView.EchoMsgHandlerDashBorad
	{
		// Token: 0x060036E1 RID: 14049 RVA: 0x000FB1F4 File Offset: 0x000F93F4
		public BroadcastHandler()
		{
			this.DISPLAY_TIME = 5f;
			uniEchoMessageView.BroadcastHandler.BroadcastMsg broadcastMsg = new uniEchoMessageView.BroadcastHandler.BroadcastMsg
			{
				lifeTimeLeft = -1f
			};
			int num = 0;
			while (num++ < 3)
			{
				this._arrSingleTextPanel.Add(null);
				this._queEventList.Enqueue(broadcastMsg);
			}
		}

		// Token: 0x060036E2 RID: 14050 RVA: 0x000231B9 File Offset: 0x000213B9
		protected override void vmethod_0()
		{
			base.vmethod_0();
		}

		// Token: 0x060036E3 RID: 14051 RVA: 0x000FB264 File Offset: 0x000F9464
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcItem0":
			{
				uniEchoMessageView.EchoSingleTextPanel echoSingleTextPanel = new uniEchoMessageView.EchoSingleTextPanel();
				echoSingleTextPanel.method_0(movieClip);
				this._arrSingleTextPanel[0] = echoSingleTextPanel;
				flag = true;
				break;
			}
			case "mcItem1":
			{
				uniEchoMessageView.EchoSingleTextPanel echoSingleTextPanel2 = new uniEchoMessageView.EchoSingleTextPanel();
				echoSingleTextPanel2.method_0(movieClip);
				this._arrSingleTextPanel[1] = echoSingleTextPanel2;
				flag = true;
				break;
			}
			case "mcItem2":
			{
				uniEchoMessageView.EchoSingleTextPanel echoSingleTextPanel3 = new uniEchoMessageView.EchoSingleTextPanel();
				echoSingleTextPanel3.method_0(movieClip);
				this._arrSingleTextPanel[2] = echoSingleTextPanel3;
				flag = true;
				break;
			}
			case "mcItem3":
				movieClip.visible = false;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x060036E4 RID: 14052 RVA: 0x000FB364 File Offset: 0x000F9564
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			foreach (uniEchoMessageView.BroadcastHandler.BroadcastMsg broadcastMsg in this._queEventList)
			{
				broadcastMsg.bFirst = true;
			}
			this._queEventList.Dequeue();
			uniEchoMessageView.BroadcastHandler.BroadcastMsg broadcastMsg2 = new uniEchoMessageView.BroadcastHandler.BroadcastMsg
			{
				message = echoMessage_0,
				lifeTimeLeft = this.DISPLAY_TIME,
				bFirst = true
			};
			this._queEventList.Enqueue(broadcastMsg2);
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x000FB3F0 File Offset: 0x000F95F0
		public override void Update()
		{
			int num = 0;
			foreach (uniEchoMessageView.BroadcastHandler.BroadcastMsg broadcastMsg in this._queEventList)
			{
				if (broadcastMsg.lifeTimeLeft > 0f)
				{
					broadcastMsg.lifeTimeLeft -= Time.deltaTime;
					if (broadcastMsg.lifeTimeLeft < 0f)
					{
						this._arrSingleTextPanel[num].method_6();
					}
					else if (broadcastMsg.bFirst)
					{
						broadcastMsg.bFirst = false;
						this._arrSingleTextPanel[num].method_5(broadcastMsg.message.m_localizedText);
					}
				}
				num++;
			}
		}

		// Token: 0x040025F8 RID: 9720
		protected const int NUM_TOTAL_MSG = 3;

		// Token: 0x040025F9 RID: 9721
		protected Queue<uniEchoMessageView.BroadcastHandler.BroadcastMsg> _queEventList = new Queue<uniEchoMessageView.BroadcastHandler.BroadcastMsg>(3);

		// Token: 0x040025FA RID: 9722
		protected List<uniEchoMessageView.EchoSingleTextPanel> _arrSingleTextPanel = new List<uniEchoMessageView.EchoSingleTextPanel>(3);

		// Token: 0x020007F3 RID: 2035
		protected class BroadcastMsg
		{
			// Token: 0x040025FC RID: 9724
			public EchoMessage message;

			// Token: 0x040025FD RID: 9725
			public float lifeTimeLeft;

			// Token: 0x040025FE RID: 9726
			public bool bFirst;
		}
	}

	// Token: 0x020007F4 RID: 2036
	protected class DialogEchoHandler : uniEchoMessageView.EchoSingleTextPanel
	{
		// Token: 0x060036E7 RID: 14055 RVA: 0x000244D1 File Offset: 0x000226D1
		public DialogEchoHandler()
		{
			this.DISPLAY_TIME = 5f;
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x000244E4 File Offset: 0x000226E4
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			this._fTimter = this.DISPLAY_TIME;
			this._curMessage = echoMessage_0;
			base.method_5(this._curMessage.m_localizedText);
		}

		// Token: 0x060036E9 RID: 14057 RVA: 0x0002450A File Offset: 0x0002270A
		public override void Update()
		{
			if (this._fTimter > 0f)
			{
				this._fTimter -= Time.deltaTime;
				if (this._fTimter < 0f)
				{
					base.method_6();
				}
			}
		}

		// Token: 0x040025FF RID: 9727
		protected EchoMessage _curMessage;

		// Token: 0x04002600 RID: 9728
		protected float _fTimter;
	}

	// Token: 0x020007F5 RID: 2037
	protected class LevelNotificationHandler : uniEchoMessageView.EchoSingleTextPanel
	{
		// Token: 0x060036EA RID: 14058 RVA: 0x0002453E File Offset: 0x0002273E
		public LevelNotificationHandler()
		{
			this.DISPLAY_TIME = 5f;
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x000FB48C File Offset: 0x000F968C
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			bool flag = this._queEventList.Count == 0;
			this._queEventList.Enqueue(echoMessage_0);
			if (flag)
			{
				this.method_7();
			}
		}

		// Token: 0x060036EC RID: 14060 RVA: 0x000FB4C0 File Offset: 0x000F96C0
		public override void Update()
		{
			if (this._fDisplayTime > 0f)
			{
				this._fDisplayTime -= Time.deltaTime;
				if (this._fDisplayTime < 0f)
				{
					this._queEventList.Dequeue();
					if (this._queEventList.Count > 0)
					{
						this.method_7();
					}
					else
					{
						base.method_6();
					}
				}
			}
		}

		// Token: 0x060036ED RID: 14061 RVA: 0x000FB524 File Offset: 0x000F9724
		protected void method_7()
		{
			this._fDisplayTime = this.DISPLAY_TIME;
			EchoMessage echoMessage = this._queEventList.Peek();
			base.method_5(echoMessage.m_localizedText);
		}

		// Token: 0x04002601 RID: 9729
		protected float _fDisplayTime;

		// Token: 0x04002602 RID: 9730
		protected Queue<EchoMessage> _queEventList = new Queue<EchoMessage>();
	}

	// Token: 0x020007F6 RID: 2038
	protected class NPCPortraitHandler : uniEchoMessageView.EchoMsgHandlerDashBorad
	{
		// Token: 0x060036EE RID: 14062 RVA: 0x0002455C File Offset: 0x0002275C
		public NPCPortraitHandler()
		{
			this.DISPLAY_TIME = 5f;
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x00024585 File Offset: 0x00022785
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			this.mcSelf.gotoAndStop("in");
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x000FB558 File Offset: 0x000F9758
		public override void imethod_0(EchoMessage echoMessage_0)
		{
			bool flag = this._queEventList.Count == 0;
			this._queEventList.Enqueue(echoMessage_0);
			if (flag)
			{
				this.method_5();
			}
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x000FB58C File Offset: 0x000F978C
		protected void method_5()
		{
			this._fTimter = this.DISPLAY_TIME;
			EchoMessage echoMessage = this._queEventList.Peek();
			this._curMessage = echoMessage;
			this.method_7(this._curMessage.m_npcIcon);
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x000FB5CC File Offset: 0x000F97CC
		public override void Update()
		{
			if (this._fTimter > 0f)
			{
				this._fTimter -= Time.deltaTime;
				if (this._fTimter < 0f)
				{
					this._queEventList.Dequeue();
					if (this._queEventList.Count > 0)
					{
						this.method_5();
					}
					else
					{
						this.method_8();
					}
				}
			}
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x000FB630 File Offset: 0x000F9830
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcRoot":
				this.mcRoot = movieClip;
				break;
			case "mcNPC":
				this.mcNPCPortrait = movieClip;
				this.mcNPCPortrait.gotoAndStop("NPC_" + this._npcName);
				flag = true;
				break;
			case "mcMaskedBg":
			{
				this.mcMaskedBg = movieClip;
				MovieClip childByName = this.mcMaskedBg.getChildByName<MovieClip>("mcMask");
				this.mcMaskedBg.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
				this.mcMaskedBg.clipRect = childByName.getBounds(this.mcMaskedBg).rect;
				flag = true;
				break;
			}
			}
			return flag;
		}

		// Token: 0x060036F4 RID: 14068 RVA: 0x000FB738 File Offset: 0x000F9938
		protected void method_6(CEvent cevent_0)
		{
			MovieClip childByName = this.mcMaskedBg.getChildByName<MovieClip>("mcMask");
			if (childByName != null)
			{
				this.mcMaskedBg.clipRect = childByName.getBounds(this.mcMaskedBg).rect;
			}
		}

		// Token: 0x060036F5 RID: 14069 RVA: 0x000FB778 File Offset: 0x000F9978
		protected void method_7(string string_1)
		{
			if (string_1 != this._npcName)
			{
				this._npcName = string_1;
				this.mcSelf.visible = true;
				this.mcSelf.gotoAndPlay("in");
				if (this.mcNPCPortrait != null)
				{
					this.mcNPCPortrait.gotoAndStop("NPC_" + this._npcName);
				}
				if (this.mcMaskedBg != null)
				{
					this.mcMaskedBg.play();
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Echo_On_Rnd");
				}
			}
		}

		// Token: 0x060036F6 RID: 14070 RVA: 0x000245AE File Offset: 0x000227AE
		protected void method_8()
		{
			this._npcName = string.Empty;
			this.mcSelf.addFrameScript("end", new EventDispatcher.EventCallback(this.method_9));
			this.mcSelf.gotoAndPlay("out");
		}

		// Token: 0x060036F7 RID: 14071 RVA: 0x000245E8 File Offset: 0x000227E8
		protected void method_9(CEvent cevent_0)
		{
			this.mcSelf.removeFrameScript("end", new EventDispatcher.EventCallback(this.method_9));
			this.mcSelf.visible = false;
		}

		// Token: 0x04002603 RID: 9731
		protected const string START_FRAME = "in";

		// Token: 0x04002604 RID: 9732
		protected const string END_FRAME = "out";

		// Token: 0x04002605 RID: 9733
		protected const string LAST_FRAME = "end";

		// Token: 0x04002606 RID: 9734
		protected const string NPC_FRAME_NAME = "NPC_";

		// Token: 0x04002607 RID: 9735
		protected MovieClip mcSelf;

		// Token: 0x04002608 RID: 9736
		protected MovieClip mcRoot;

		// Token: 0x04002609 RID: 9737
		protected MovieClip mcNPCPortrait;

		// Token: 0x0400260A RID: 9738
		protected MovieClip mcMaskedBg;

		// Token: 0x0400260B RID: 9739
		protected EchoMessage _curMessage;

		// Token: 0x0400260C RID: 9740
		protected float _fTimter;

		// Token: 0x0400260D RID: 9741
		protected string _npcName = string.Empty;

		// Token: 0x0400260E RID: 9742
		protected Queue<EchoMessage> _queEventList = new Queue<EchoMessage>();
	}
}
