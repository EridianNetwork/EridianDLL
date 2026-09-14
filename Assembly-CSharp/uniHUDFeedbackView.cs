using System;
using ns0;
using pumpkin.display;
using UnityEngine;
using XsdSettings;

// Token: 0x02000814 RID: 2068
public class uniHUDFeedbackView : HUDFeedbackView
{
	// Token: 0x060037E9 RID: 14313 RVA: 0x00025236 File Offset: 0x00023436
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Skages_melee.swf", "Panel_Damage", new FuncLoad(this.method_3));
	}

	// Token: 0x060037EA RID: 14314 RVA: 0x001025EC File Offset: 0x001007EC
	private void method_3(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		float single_ = GClass20.GClass20_0.Single_0;
		this._feedBackPanel = new uniHUDFeedbackView.AttackFeedbackPanel();
		movieClip_0.x = num2;
		movieClip_0.y = num;
		this._feedBackPanel.method_0(movieClip_0);
		movieClip_0.scaleX = single_;
		movieClip_0.scaleY = single_;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._feedBackPanel);
		this._skageMeleePanel = new uniHUDFeedbackView.SkageMeleePanel();
		MovieClip movieClip = new MovieClip("Skages_melee.swf:Panel_Skage_Melee");
		movieClip.x = num2;
		movieClip.y = num;
		this._skageMeleePanel.method_0(movieClip);
		movieClip.scaleX = single_;
		movieClip.scaleY = single_;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._skageMeleePanel);
	}

	// Token: 0x060037EB RID: 14315 RVA: 0x001026CC File Offset: 0x001008CC
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._skageMeleePanel);
		this._skageMeleePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._feedBackPanel);
		this._feedBackPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Skages_melee.swf");
	}

	// Token: 0x060037EC RID: 14316 RVA: 0x0010273C File Offset: 0x0010093C
	public override void vmethod_6(DamageInfo damageInfo_0)
	{
		base.vmethod_6(damageInfo_0);
		switch (damageInfo_0.m_attackSubType)
		{
		case AttackSubType.MeleeBite:
			this._skageMeleePanel.method_5();
			break;
		case AttackSubType.MeleePaw:
			this._skageMeleePanel.method_6();
			break;
		case AttackSubType.MeleeAxe:
			this._skageMeleePanel.method_7();
			break;
		case AttackSubType.MeleeClaw:
			this._skageMeleePanel.method_8();
			break;
		}
	}

	// Token: 0x060037ED RID: 14317 RVA: 0x00025268 File Offset: 0x00023468
	protected override void vmethod_7(HUDFeedbackView.Direction direction_0)
	{
		if (this._feedBackPanel == null)
		{
			return;
		}
		this._feedBackPanel.method_5(direction_0);
		GClass61.GClass61_0.GInterface3_0.imethod_0(AudioEvents.smethod_0(AudioEventName.Chr_Shr_Shield_Impact_Rnd));
	}

	// Token: 0x060037EE RID: 14318 RVA: 0x00025294 File Offset: 0x00023494
	protected override void vmethod_8(HUDFeedbackView.Direction direction_0)
	{
		if (this._feedBackPanel == null)
		{
			return;
		}
		this._feedBackPanel.method_6(direction_0);
		if (MonoSingleton<AudioManager>.Boolean_0)
		{
			MonoSingleton<AudioManager>.Instance.method_0(AudioEvents.smethod_0(AudioEventName.Chr_Hurt_Rnd));
		}
	}

	// Token: 0x040026F6 RID: 9974
	private uniHUDFeedbackView.AttackFeedbackPanel _feedBackPanel;

	// Token: 0x040026F7 RID: 9975
	private uniHUDFeedbackView.SkageMeleePanel _skageMeleePanel;

	// Token: 0x02000815 RID: 2069
	private class SkageMeleePanel : GClass51
	{
		// Token: 0x060037F0 RID: 14320 RVA: 0x001027A8 File Offset: 0x001009A8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcPaw = this.displayObjectContainer_0.getChildByName<MovieClip>("mcAttack1");
			this.mcBite = this.displayObjectContainer_0.getChildByName<MovieClip>("mcAttack2");
			this.mcClaw = this.displayObjectContainer_0.getChildByName<MovieClip>("mcAttack3");
			this.mcAxe = this.displayObjectContainer_0.getChildByName<MovieClip>("mcAttack4");
			if (this.mcPaw != null)
			{
				this.mcPaw.stop();
				this._PawOriPos.x = this.mcPaw.x;
				this._PawOriPos.y = this.mcPaw.y;
			}
			if (this.mcBite != null)
			{
				this.mcBite.stop();
				this._BiteOriPos.x = this.mcBite.x;
				this._BiteOriPos.y = this.mcBite.y;
			}
			if (this.mcAxe != null)
			{
				this.mcAxe.stop();
				this._AxeOriPos.x = this.mcAxe.x;
				this._AxeOriPos.y = this.mcAxe.y;
			}
			if (this.mcClaw != null)
			{
				this.mcClaw.stop();
				this._ClawOriPos.x = this.mcClaw.x;
				this._ClawOriPos.y = this.mcClaw.y;
			}
		}

		// Token: 0x060037F1 RID: 14321 RVA: 0x00102910 File Offset: 0x00100B10
		public void method_5()
		{
			if (this.mcBite == null)
			{
				return;
			}
			if (this.mcBite.isPlaying)
			{
				return;
			}
			int num = global::UnityEngine.Random.Range(-300, 100);
			int num2 = global::UnityEngine.Random.Range(-400, 100);
			this.mcBite.x = this._BiteOriPos.x + (float)num2;
			this.mcBite.y = this._BiteOriPos.y + (float)num;
			this.mcBite.rotation = global::UnityEngine.Random.Range(-45f, 45f);
			this.mcBite.gotoAndPlay("start");
		}

		// Token: 0x060037F2 RID: 14322 RVA: 0x001029AC File Offset: 0x00100BAC
		public void method_6()
		{
			if (this.mcPaw == null)
			{
				return;
			}
			if (this.mcPaw.isPlaying)
			{
				return;
			}
			int num = global::UnityEngine.Random.Range(-50, 200);
			int num2 = global::UnityEngine.Random.Range(-80, 100);
			this.mcPaw.x = this._PawOriPos.x + (float)num2;
			this.mcPaw.y = this._PawOriPos.y + (float)num;
			this.mcPaw.rotation = global::UnityEngine.Random.Range(-10f, 10f);
			this.mcPaw.gotoAndPlay("start");
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x00102A44 File Offset: 0x00100C44
		public void method_7()
		{
			if (this.mcAxe == null)
			{
				return;
			}
			if (this.mcAxe.isPlaying)
			{
				return;
			}
			int num = global::UnityEngine.Random.Range(-50, 200);
			int num2 = global::UnityEngine.Random.Range(-80, 100);
			this.mcAxe.x = this._AxeOriPos.x + (float)num2;
			this.mcAxe.y = this._AxeOriPos.y + (float)num;
			this.mcAxe.rotation = global::UnityEngine.Random.Range(-10f, 10f);
			this.mcAxe.gotoAndPlay("start");
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x00102ADC File Offset: 0x00100CDC
		public void method_8()
		{
			if (this.mcClaw == null)
			{
				return;
			}
			if (this.mcClaw.isPlaying)
			{
				return;
			}
			int num = global::UnityEngine.Random.Range(-50, 200);
			int num2 = global::UnityEngine.Random.Range(-80, 100);
			this.mcClaw.x = this._ClawOriPos.x + (float)num2;
			this.mcClaw.y = this._ClawOriPos.y + (float)num;
			this.mcClaw.rotation = global::UnityEngine.Random.Range(-10f, 10f);
			this.mcClaw.gotoAndPlay("start");
		}

		// Token: 0x040026F8 RID: 9976
		protected MovieClip mcSelf;

		// Token: 0x040026F9 RID: 9977
		protected MovieClip mcPaw;

		// Token: 0x040026FA RID: 9978
		protected MovieClip mcBite;

		// Token: 0x040026FB RID: 9979
		protected MovieClip mcAxe;

		// Token: 0x040026FC RID: 9980
		protected MovieClip mcClaw;

		// Token: 0x040026FD RID: 9981
		protected Vector2 _PawOriPos;

		// Token: 0x040026FE RID: 9982
		protected Vector2 _BiteOriPos;

		// Token: 0x040026FF RID: 9983
		protected Vector2 _AxeOriPos;

		// Token: 0x04002700 RID: 9984
		protected Vector2 _ClawOriPos;
	}

	// Token: 0x02000816 RID: 2070
	private class AttackFeedbackPanel : GClass51
	{
		// Token: 0x060037F6 RID: 14326 RVA: 0x00102B74 File Offset: 0x00100D74
		protected override void vmethod_0()
		{
			base.vmethod_0();
			for (int i = 0; i < this._directMap.Length; i++)
			{
				MovieClip movieClip = base.DisplayObjectContainer_0.getChildByName<MovieClip>("shield_" + this._directMap[i]);
				if (movieClip != null)
				{
					movieClip.stop();
				}
				movieClip = base.DisplayObjectContainer_0.getChildByName<MovieClip>("dmg_" + this._directMap[i]);
				if (movieClip != null)
				{
					movieClip.stop();
				}
			}
		}

		// Token: 0x060037F7 RID: 14327 RVA: 0x00102BEC File Offset: 0x00100DEC
		public void method_5(HUDFeedbackView.Direction direction_0)
		{
			if (base.DisplayObjectContainer_0 == null)
			{
				return;
			}
			if (direction_0 > (HUDFeedbackView.Direction)this._directMap.Length)
			{
				return;
			}
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("shield_" + this._directMap[(int)direction_0]);
			if (childByName != null)
			{
				childByName.gotoAndPlay("fadein");
			}
		}

		// Token: 0x060037F8 RID: 14328 RVA: 0x00102C3C File Offset: 0x00100E3C
		public void method_6(HUDFeedbackView.Direction direction_0)
		{
			if (base.DisplayObjectContainer_0 == null)
			{
				return;
			}
			if (direction_0 > (HUDFeedbackView.Direction)this._directMap.Length)
			{
				return;
			}
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("dmg_" + this._directMap[(int)direction_0]);
			if (childByName != null)
			{
				childByName.gotoAndPlay("fadein");
			}
		}

		// Token: 0x04002701 RID: 9985
		private const string SHIELD_NAME = "shield_";

		// Token: 0x04002702 RID: 9986
		private const string HP_NAME = "dmg_";

		// Token: 0x04002703 RID: 9987
		private const string FRAME_START = "fadein";

		// Token: 0x04002704 RID: 9988
		private const string FRAME_END = "fadeout";

		// Token: 0x04002705 RID: 9989
		private string[] _directMap = new string[] { "u", "d", "l", "r" };
	}
}
