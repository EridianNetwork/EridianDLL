using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.text;
using UnityEngine;

// Token: 0x02000848 RID: 2120
public class uniHUDWorldTipsView : HUDWorldTipsView
{
	// Token: 0x06003978 RID: 14712 RVA: 0x0002655A File Offset: 0x0002475A
	public uniHUDWorldTipsView()
	{
		this._showingDMGList = new List<uniHUDWorldTipsView.DamageValuePanel>();
		this._showingCriticalList = new List<uniHUDWorldTipsView.CriticalPanel>();
	}

	// Token: 0x06003979 RID: 14713 RVA: 0x0010B8D8 File Offset: 0x00109AD8
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this._valueTextURI == null)
		{
			this._valueTextURI = new SwfURI("SightBead.swf:Value");
		}
		if (this._valueResistURI == null)
		{
			this._valueResistURI = new SwfURI("SightBead.swf:Resist");
		}
		if (this._valueCriticalURI == null)
		{
			this._valueCriticalURI = new SwfURI("SightBead.swf:CRITICAL");
		}
		this._showingDMGList.Clear();
		this._showingCriticalList.Clear();
		this._rootPanel = new GClass51();
		this._MovieClipContainer = new MovieClip();
		DisplayObject movieClipContainer = this._MovieClipContainer;
		float num = 0f;
		this._MovieClipContainer.y = num;
		movieClipContainer.x = num;
		this._MovieClipContainer.width = 1280f;
		this._MovieClipContainer.height = 720f;
		this._rootPanel.method_0(this._MovieClipContainer);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._rootPanel);
	}

	// Token: 0x0600397A RID: 14714 RVA: 0x0010B9CC File Offset: 0x00109BCC
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		this._valueTextURI = null;
		this._valueResistURI = null;
		this._valueCriticalURI = null;
		this._rootPanel = null;
		this._MovieClipContainer.removeAllChildren();
		this._MovieClipContainer = null;
		this._showingDMGList.Clear();
		this._showingCriticalList.Clear();
	}

	// Token: 0x0600397B RID: 14715 RVA: 0x0010BA40 File Offset: 0x00109C40
	public override void vmethod_5(int int_0, WeakPoint.StrengthType strengthType_0, Vector3 vector3_0, AttackInfo.ElementalType elementalType_0 = AttackInfo.ElementalType.None, bool bool_0 = true, bool bool_1 = false)
	{
		base.vmethod_5(int_0, strengthType_0, vector3_0, elementalType_0, bool_0, false);
		if (MonoSingleton<AppManager>.Instance.method_0().Camera_0 == null)
		{
			return;
		}
		this.method_7(int_0, strengthType_0, vector3_0, elementalType_0, bool_1);
		if (bool_0)
		{
			bool flag = MonoSingleton<Session>.Instance.method_12() && strengthType_0 == WeakPoint.StrengthType.Weak;
			if ((!MonoSingleton<Session>.Instance.method_12() && strengthType_0 == WeakPoint.StrengthType.VeryWeak) || flag)
			{
				this.method_3(vector3_0);
			}
		}
	}

	// Token: 0x0600397C RID: 14716 RVA: 0x00026578 File Offset: 0x00024778
	public override void vmethod_6()
	{
		base.vmethod_6();
		this.method_9();
		this.method_4();
	}

	// Token: 0x0600397D RID: 14717 RVA: 0x0010BAB8 File Offset: 0x00109CB8
	private void method_3(Vector3 vector3_0)
	{
		MovieClip movieClip = new MovieClip(this._valueCriticalURI);
		Vector3 vector = MonoSingleton<AppManager>.Instance.method_0().Camera_0.WorldToScreenPoint(vector3_0);
		movieClip.x = (float)Mathf.CeilToInt(vector.x / GClass20.GClass20_0.Single_0);
		movieClip.y = (float)Mathf.CeilToInt(((float)Screen.height - vector.y) / GClass20.GClass20_0.Single_0);
		uniHUDWorldTipsView.CriticalPanel criticalPanel = new uniHUDWorldTipsView.CriticalPanel();
		criticalPanel.method_0(movieClip);
		criticalPanel.addEventListener(CEvent.COMPLETE, new EventDispatcher.EventCallback(this.method_5));
		criticalPanel.startPosition = vector3_0;
		criticalPanel.method_6();
		this._MovieClipContainer.addChild(movieClip);
		this._showingCriticalList.Add(criticalPanel);
	}

	// Token: 0x0600397E RID: 14718 RVA: 0x0010BB78 File Offset: 0x00109D78
	private void method_4()
	{
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		List<uniHUDWorldTipsView.CriticalPanel> list = new List<uniHUDWorldTipsView.CriticalPanel>();
		int num = this._showingCriticalList.Count;
		for (int i = 0; i < num; i++)
		{
			uniHUDWorldTipsView.CriticalPanel criticalPanel = this._showingCriticalList[i];
			if (criticalPanel.method_7())
			{
				list.Add(criticalPanel);
			}
			else
			{
				DisplayObject displayObjectContainer_ = criticalPanel.DisplayObjectContainer_0;
				Vector3 vector = camera_.WorldToScreenPoint(criticalPanel.startPosition);
				displayObjectContainer_.visible = vector.z >= 0f;
				if (displayObjectContainer_.visible)
				{
					displayObjectContainer_.x = (float)Mathf.CeilToInt(vector.x / GClass20.GClass20_0.Single_0);
					displayObjectContainer_.y = (float)Mathf.CeilToInt(((float)Screen.height - vector.y) / GClass20.GClass20_0.Single_0);
				}
			}
		}
		num = list.Count;
		for (int j = 0; j < num; j++)
		{
			this.method_6(list[j]);
		}
		list.Clear();
	}

	// Token: 0x0600397F RID: 14719 RVA: 0x0010BC8C File Offset: 0x00109E8C
	private void method_5(CEvent cevent_0)
	{
		uniHUDWorldTipsView.CriticalPanel criticalPanel = cevent_0.target as uniHUDWorldTipsView.CriticalPanel;
		if (criticalPanel != null)
		{
			this.method_6(criticalPanel);
		}
	}

	// Token: 0x06003980 RID: 14720 RVA: 0x0002658C File Offset: 0x0002478C
	private void method_6(uniHUDWorldTipsView.CriticalPanel criticalPanel_0)
	{
		this._MovieClipContainer.removeChild(criticalPanel_0.DisplayObjectContainer_0);
		this._showingCriticalList.Remove(criticalPanel_0);
		criticalPanel_0 = null;
	}

	// Token: 0x06003981 RID: 14721 RVA: 0x0010BCB0 File Offset: 0x00109EB0
	private void method_7(int int_0, WeakPoint.StrengthType strengthType_0, Vector3 vector3_0, AttackInfo.ElementalType elementalType_0, bool bool_0 = false)
	{
		float num = 1f;
		MovieClip movieClip;
		uniHUDWorldTipsView.DamageValuePanel damageValuePanel;
		if (bool_0)
		{
			movieClip = new MovieClip(this._valueResistURI);
			damageValuePanel = new uniHUDWorldTipsView.SpecialDamagePanel();
		}
		else
		{
			movieClip = new MovieClip(this._valueTextURI);
			damageValuePanel = new uniHUDWorldTipsView.DamageValuePanel();
		}
		damageValuePanel.method_0(movieClip);
		damageValuePanel.vmethod_2(int_0, (strengthType_0 != WeakPoint.StrengthType.VeryWeak) ? uniHUDWorldTipsView.VALUE_TYPE.V_NORMAL : uniHUDWorldTipsView.VALUE_TYPE.V_CRITICAL, elementalType_0);
		if (strengthType_0 == WeakPoint.StrengthType.VeryWeak)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("Damage_Critical_Rnd");
		}
		damageValuePanel.fLifeTime = 0f;
		damageValuePanel.fTotalLife = num;
		damageValuePanel.startPosition = vector3_0;
		float num2 = (float)((global::UnityEngine.Random.Range(1f, 3f) <= 2f) ? 1 : (-1));
		damageValuePanel.fSpeedX = global::UnityEngine.Random.Range(0.45f, 0.7f) * num2;
		num2 = (float)((global::UnityEngine.Random.Range(6f, 8f) <= 7f) ? 1 : (-1));
		damageValuePanel.fSpeedZ = global::UnityEngine.Random.Range(0.45f, 0.7f) * num2;
		damageValuePanel.Boolean_0 = false;
		this._MovieClipContainer.addChild(damageValuePanel.DisplayObjectContainer_0);
		this._showingDMGList.Add(damageValuePanel);
	}

	// Token: 0x06003982 RID: 14722 RVA: 0x000265B1 File Offset: 0x000247B1
	private void method_8(uniHUDWorldTipsView.DamageValuePanel damageValuePanel_0)
	{
		this._MovieClipContainer.removeChild(damageValuePanel_0.DisplayObjectContainer_0);
		this._showingDMGList.Remove(damageValuePanel_0);
		damageValuePanel_0 = null;
	}

	// Token: 0x06003983 RID: 14723 RVA: 0x0010BDC4 File Offset: 0x00109FC4
	private void method_9()
	{
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		List<uniHUDWorldTipsView.DamageValuePanel> list = new List<uniHUDWorldTipsView.DamageValuePanel>();
		int num = this._showingDMGList.Count;
		for (int i = 0; i < num; i++)
		{
			uniHUDWorldTipsView.DamageValuePanel damageValuePanel = this._showingDMGList[i];
			if (damageValuePanel.fLifeTime < damageValuePanel.fTotalLife)
			{
				damageValuePanel.Boolean_0 = true;
				Vector3 zero = Vector3.zero;
				zero.x = damageValuePanel.fSpeedX * damageValuePanel.fLifeTime;
				zero.z = damageValuePanel.fSpeedZ * damageValuePanel.fLifeTime;
				float num2 = damageValuePanel.fTotalLife * 0.45f;
				zero.y = 0.6f - (num2 - damageValuePanel.fLifeTime) * (num2 - damageValuePanel.fLifeTime) / (num2 * num2) * 0.6f;
				Vector3 vector = camera_.WorldToScreenPoint(damageValuePanel.startPosition + zero);
				if (vector.z >= 0f)
				{
					damageValuePanel.DisplayObjectContainer_0.visible = true;
					if (damageValuePanel.fOrinHeight > 0f)
					{
						float num3 = Mathf.Min(1.5f, (camera_.WorldToScreenPoint(damageValuePanel.startPosition + zero + Vector3.up * 0.2f).y - vector.y) / damageValuePanel.fOrinHeight);
						if (damageValuePanel.fLifeTime < 0.3f)
						{
							num3 *= 0.6f + 0.5f * damageValuePanel.fLifeTime / 0.3f;
						}
						else if (damageValuePanel.fLifeTime < 0.6f)
						{
							num3 *= 1.15f;
						}
						else
						{
							num3 *= 1.15f - 0.6f * (damageValuePanel.fLifeTime - 0.6f) / (damageValuePanel.fTotalLife - 0.6f);
						}
						float num4 = 1f;
						if (damageValuePanel.fLifeTime > damageValuePanel.fTotalLife * 0.7f)
						{
							num4 = 1f - 0.8f * (damageValuePanel.fLifeTime - 0.7f) / (damageValuePanel.fTotalLife - 0.7f);
						}
						DisplayObject displayObjectContainer_ = damageValuePanel.DisplayObjectContainer_0;
						float num5 = num3 * 2f;
						damageValuePanel.DisplayObjectContainer_0.scaleY = num5;
						displayObjectContainer_.scaleX = num5;
						damageValuePanel.DisplayObjectContainer_0.alpha = num4;
					}
					damageValuePanel.DisplayObjectContainer_0.x = (float)Mathf.CeilToInt(vector.x / GClass20.GClass20_0.Single_0);
					damageValuePanel.DisplayObjectContainer_0.y = (float)Mathf.CeilToInt(((float)Screen.height - vector.y) / GClass20.GClass20_0.Single_0);
				}
				else
				{
					damageValuePanel.DisplayObjectContainer_0.visible = false;
				}
			}
			else
			{
				list.Add(damageValuePanel);
			}
			damageValuePanel.fLifeTime += Time.deltaTime;
		}
		num = list.Count;
		for (int j = 0; j < num; j++)
		{
			this.method_8(list[j]);
		}
		list.Clear();
	}

	// Token: 0x06003984 RID: 14724 RVA: 0x000265D6 File Offset: 0x000247D6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._rootPanel != null)
		{
			this._rootPanel.DisplayObjectContainer_0.visible = this._bVisible;
		}
	}

	// Token: 0x04002828 RID: 10280
	private const float TIME_DAMAGE_TEXT_LIFE = 1f;

	// Token: 0x04002829 RID: 10281
	private const string PATH_VALUE_TEXT = "SightBead.swf:Value";

	// Token: 0x0400282A RID: 10282
	private const string PATH_CRITICAL_TEXT = "SightBead.swf:CRITICAL";

	// Token: 0x0400282B RID: 10283
	private const string PATH_RESIST_TEXT = "SightBead.swf:Resist";

	// Token: 0x0400282C RID: 10284
	private GClass51 _rootPanel;

	// Token: 0x0400282D RID: 10285
	private MovieClip _MovieClipContainer;

	// Token: 0x0400282E RID: 10286
	private List<uniHUDWorldTipsView.DamageValuePanel> _showingDMGList;

	// Token: 0x0400282F RID: 10287
	private List<uniHUDWorldTipsView.CriticalPanel> _showingCriticalList;

	// Token: 0x04002830 RID: 10288
	private SwfURI _valueTextURI;

	// Token: 0x04002831 RID: 10289
	private SwfURI _valueCriticalURI;

	// Token: 0x04002832 RID: 10290
	private SwfURI _valueResistURI;

	// Token: 0x02000849 RID: 2121
	protected enum VALUE_TYPE
	{
		// Token: 0x04002834 RID: 10292
		V_NORMAL,
		// Token: 0x04002835 RID: 10293
		V_CRITICAL,
		// Token: 0x04002836 RID: 10294
		V_EXP
	}

	// Token: 0x0200084A RID: 2122
	private class CriticalPanel : GClass51
	{
		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06003986 RID: 14726 RVA: 0x000265FE File Offset: 0x000247FE
		// (set) Token: 0x06003987 RID: 14727 RVA: 0x00026615 File Offset: 0x00024815
		public bool Boolean_0
		{
			get
			{
				return this.mcSelf != null && this.mcSelf.visible;
			}
			set
			{
				if (this.mcSelf != null)
				{
					this.mcSelf.visible = value;
				}
			}
		}

		// Token: 0x06003988 RID: 14728 RVA: 0x0010C0D4 File Offset: 0x0010A2D4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				return;
			}
			this.mcRoot = this.mcSelf.getChildByName<MovieClip>("mcRoot");
			this.mcRoot.stop();
		}

		// Token: 0x06003989 RID: 14729 RVA: 0x0010C124 File Offset: 0x0010A324
		private void method_5(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent(CEvent.COMPLETE)
			{
				target = this
			});
		}

		// Token: 0x0600398A RID: 14730 RVA: 0x0002662B File Offset: 0x0002482B
		public void method_6()
		{
			this.mcRoot.gotoAndPlay(1);
		}

		// Token: 0x0600398B RID: 14731 RVA: 0x0002663E File Offset: 0x0002483E
		public bool method_7()
		{
			return this.mcRoot == null || this.mcRoot.currentFrame == this.mcRoot.totalFrames;
		}

		// Token: 0x04002837 RID: 10295
		protected MovieClip mcSelf;

		// Token: 0x04002838 RID: 10296
		protected MovieClip mcRoot;

		// Token: 0x04002839 RID: 10297
		public Vector3 startPosition;
	}

	// Token: 0x0200084B RID: 2123
	private class SpecialDamagePanel : uniHUDWorldTipsView.DamageValuePanel
	{
		// Token: 0x0600398D RID: 14733 RVA: 0x0010C14C File Offset: 0x0010A34C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				return;
			}
			this.mcSelf.stop();
			this.mcSelf.visible = false;
			this.fOrinWidth = this.mcSelf.width;
			this.fOrinHeight = this.mcSelf.height;
		}

		// Token: 0x0600398E RID: 14734 RVA: 0x0002666A File Offset: 0x0002486A
		public override void vmethod_2(int int_0, uniHUDWorldTipsView.VALUE_TYPE value_TYPE_0, AttackInfo.ElementalType elementalType_0)
		{
			this._value = int_0;
			this._type = value_TYPE_0;
			if (this.mcSelf != null)
			{
				this.mcSelf.visible = true;
				this.mcSelf.colorTransform = UniUIManager.UniSWFToolClass.smethod_7(elementalType_0);
			}
		}
	}

	// Token: 0x0200084C RID: 2124
	private class DamageValuePanel : GClass51
	{
		// Token: 0x0600398F RID: 14735 RVA: 0x0010C1B4 File Offset: 0x0010A3B4
		public DamageValuePanel()
		{
			this._colorMap = new Dictionary<AttackInfo.ElementalType, string>
			{
				{
					AttackInfo.ElementalType.None,
					"white"
				},
				{
					AttackInfo.ElementalType.Explosive,
					"yellow"
				},
				{
					AttackInfo.ElementalType.Fire,
					"orange"
				},
				{
					AttackInfo.ElementalType.Shock,
					"blue"
				},
				{
					AttackInfo.ElementalType.Corrosive,
					"green"
				},
				{
					AttackInfo.ElementalType.Max,
					"white"
				}
			};
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06003990 RID: 14736 RVA: 0x0002669F File Offset: 0x0002489F
		// (set) Token: 0x06003991 RID: 14737 RVA: 0x000266B6 File Offset: 0x000248B6
		public virtual bool Boolean_0
		{
			get
			{
				return this.mcSelf != null && this.mcSelf.visible;
			}
			set
			{
				if (this.mcSelf != null)
				{
					this.mcSelf.visible = value;
				}
			}
		}

		// Token: 0x06003992 RID: 14738 RVA: 0x0010C21C File Offset: 0x0010A41C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				return;
			}
			this.mcSelf.stop();
			this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
			this.mcSelf.visible = false;
			this.fOrinWidth = this.mcSelf.width;
			this.fOrinHeight = this.mcSelf.height;
		}

		// Token: 0x06003993 RID: 14739 RVA: 0x0010C2A0 File Offset: 0x0010A4A0
		private void method_5(CEvent cevent_0)
		{
			TextField childByName = this.mcSelf.getChildByName<TextField>("textField");
			if (childByName != null)
			{
				childByName.text = Utility.smethod_8(this._value);
			}
		}

		// Token: 0x06003994 RID: 14740 RVA: 0x0010C2D4 File Offset: 0x0010A4D4
		public virtual void vmethod_2(int int_0, uniHUDWorldTipsView.VALUE_TYPE value_TYPE_0, AttackInfo.ElementalType elementalType_0)
		{
			this._value = int_0;
			this._type = value_TYPE_0;
			if (this.mcSelf != null)
			{
				this.mcSelf.visible = true;
				if (this.mcSelf.getCurrentFrame() == this.mcSelf.getFrameLabel(this._colorMap[elementalType_0]))
				{
					TextField childByName = this.mcSelf.getChildByName<TextField>("textField");
					if (childByName != null)
					{
						childByName.text = Utility.smethod_8(this._value);
					}
				}
				else
				{
					this.mcSelf.gotoAndStop(this._colorMap[elementalType_0]);
				}
			}
		}

		// Token: 0x0400283A RID: 10298
		public float fLifeTime;

		// Token: 0x0400283B RID: 10299
		public float fTotalLife;

		// Token: 0x0400283C RID: 10300
		public float fSpeedX;

		// Token: 0x0400283D RID: 10301
		public float fSpeedZ;

		// Token: 0x0400283E RID: 10302
		public Vector3 startPosition;

		// Token: 0x0400283F RID: 10303
		public float fOrinWidth;

		// Token: 0x04002840 RID: 10304
		public float fOrinHeight;

		// Token: 0x04002841 RID: 10305
		protected MovieClip mcSelf;

		// Token: 0x04002842 RID: 10306
		protected int _value;

		// Token: 0x04002843 RID: 10307
		protected uniHUDWorldTipsView.VALUE_TYPE _type;

		// Token: 0x04002844 RID: 10308
		protected Dictionary<AttackInfo.ElementalType, string> _colorMap;
	}
}
