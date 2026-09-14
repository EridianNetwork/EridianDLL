using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x02000277 RID: 631
public class FrontEndStepManager : MonoBehaviour
{
	// Token: 0x17000085 RID: 133
	// (get) Token: 0x06000D72 RID: 3442 RVA: 0x0000C7BE File Offset: 0x0000A9BE
	// (set) Token: 0x06000D71 RID: 3441 RVA: 0x0000C7B5 File Offset: 0x0000A9B5
	public bool Boolean_0
	{
		get
		{
			return this._isExistingUser;
		}
		set
		{
			this._isExistingUser = value;
		}
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x06000D74 RID: 3444 RVA: 0x0000C7CF File Offset: 0x0000A9CF
	// (set) Token: 0x06000D73 RID: 3443 RVA: 0x0000C7C6 File Offset: 0x0000A9C6
	public string accountName
	{
		get
		{
			return this._accountName;
		}
		set
		{
			this._accountName = value;
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x06000D76 RID: 3446 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
	// (set) Token: 0x06000D75 RID: 3445 RVA: 0x0000C7D7 File Offset: 0x0000A9D7
	public string password
	{
		get
		{
			return this._password;
		}
		set
		{
			this._password = value;
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x06000D78 RID: 3448 RVA: 0x0000C7F1 File Offset: 0x0000A9F1
	// (set) Token: 0x06000D77 RID: 3447 RVA: 0x0000C7E8 File Offset: 0x0000A9E8
	public AvatarType AvatarType_0
	{
		get
		{
			return this._classType;
		}
		set
		{
			this._classType = value;
		}
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0000C7F9 File Offset: 0x0000A9F9
	public FrontEndStepManager.StepState StepState_0
	{
		get
		{
			return this.m_curStep;
		}
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x0006FDD8 File Offset: 0x0006DFD8
	private void Awake()
	{
		this.m_dicFrontEndSteps = new Dictionary<FrontEndStepManager.StepState, Type>
		{
			{
				FrontEndStepManager.StepState.Login,
				typeof(LoginBehaviour)
			},
			{
				FrontEndStepManager.StepState.CharacterSelect,
				typeof(CharacterSelectBehaviour)
			},
			{
				FrontEndStepManager.StepState.ClassSelect,
				typeof(ClassSelectBehaviour)
			},
			{
				FrontEndStepManager.StepState.CharacterCreate,
				typeof(DNACreateBehaviour)
			},
			{
				FrontEndStepManager.StepState.WorldMap,
				typeof(InstanceSelBehaviour)
			},
			{
				FrontEndStepManager.StepState.Gaming,
				typeof(GamingBehaviour)
			},
			{
				FrontEndStepManager.StepState.Town,
				typeof(TownBehaviour)
			},
			{
				FrontEndStepManager.StepState.PVP,
				typeof(PVPBehaviour)
			},
			{
				FrontEndStepManager.StepState.RV,
				typeof(RVBehaviour)
			}
		};
		this.m_curStepBehaviour = null;
		this.m_curStep = FrontEndStepManager.StepState.none;
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x0006FE9C File Offset: 0x0006E09C
	public void method_0()
	{
		if (this.m_scene == null)
		{
			this.m_scene = GameObject.Find("LA");
		}
		if (this.m_bg == null)
		{
			this.m_bg = GameObject.Find("BG");
		}
		if (this.m_scene != null)
		{
			this.m_scene.SetActive(true);
		}
		if (this.m_bg != null)
		{
			this.m_bg.SetActive(false);
		}
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x0006FF1C File Offset: 0x0006E11C
	public void method_1()
	{
		if (this.m_scene == null)
		{
			this.m_scene = GameObject.Find("LA");
		}
		if (this.m_bg == null)
		{
			this.m_bg = GameObject.Find("BG");
		}
		if (this.m_scene != null)
		{
			this.m_scene.SetActive(false);
		}
		if (this.m_bg != null)
		{
			this.m_bg.SetActive(true);
		}
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x0006FE9C File Offset: 0x0006E09C
	public void method_2()
	{
		if (this.m_scene == null)
		{
			this.m_scene = GameObject.Find("LA");
		}
		if (this.m_bg == null)
		{
			this.m_bg = GameObject.Find("BG");
		}
		if (this.m_scene != null)
		{
			this.m_scene.SetActive(true);
		}
		if (this.m_bg != null)
		{
			this.m_bg.SetActive(false);
		}
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0006FF9C File Offset: 0x0006E19C
	public void method_3(FrontEndStepManager.StepState stepState_0, object object_0 = null)
	{
		FrontEndStepManager.StepState curStep = this.m_curStep;
		if (this.m_curStepBehaviour != null)
		{
			this.m_curStepBehaviour.vmethod_0(stepState_0);
			global::UnityEngine.Object.Destroy(this.m_curStepBehaviour);
			this.m_curStepBehaviour = null;
			this.m_curStep = FrontEndStepManager.StepState.none;
		}
		if (stepState_0 == FrontEndStepManager.StepState.none)
		{
			this.m_curStepBehaviour = null;
			this.m_curStep = FrontEndStepManager.StepState.none;
			return;
		}
		Type type = this.m_dicFrontEndSteps[stepState_0];
		if (type == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "FrontEnd Step:" + stepState_0 + "'s behaviour does not exist!!!");
			return;
		}
		StepBehaviour stepBehaviour = base.gameObject.AddComponent(type) as StepBehaviour;
		if (stepBehaviour == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "FrontEnd Step: can not create instance of class: [" + type.ToString() + "]");
			return;
		}
		stepBehaviour.OnShow(curStep, object_0);
		this.m_curStepBehaviour = stepBehaviour;
		this.m_curStep = stepState_0;
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x0000C801 File Offset: 0x0000AA01
	public void OnCurStepLevelLoadingFinish()
	{
		if (this.m_curStep != FrontEndStepManager.StepState.none)
		{
			this.m_curStepBehaviour.OnLevelLoadingFinish();
		}
	}

	// Token: 0x04000C34 RID: 3124
	private Dictionary<FrontEndStepManager.StepState, Type> m_dicFrontEndSteps;

	// Token: 0x04000C35 RID: 3125
	private StepBehaviour m_curStepBehaviour;

	// Token: 0x04000C36 RID: 3126
	private FrontEndStepManager.StepState m_curStep;

	// Token: 0x04000C37 RID: 3127
	private GameObject m_scene;

	// Token: 0x04000C38 RID: 3128
	private GameObject m_bg;

	// Token: 0x04000C39 RID: 3129
	private string _accountName = string.Empty;

	// Token: 0x04000C3A RID: 3130
	private string _password = string.Empty;

	// Token: 0x04000C3B RID: 3131
	private bool _isExistingUser;

	// Token: 0x04000C3C RID: 3132
	private AvatarType _classType = AvatarType.BERSERKER;

	// Token: 0x02000278 RID: 632
	public enum StepState
	{
		// Token: 0x04000C3E RID: 3134
		Login,
		// Token: 0x04000C3F RID: 3135
		CharacterSelect,
		// Token: 0x04000C40 RID: 3136
		ClassSelect,
		// Token: 0x04000C41 RID: 3137
		CharacterCreate,
		// Token: 0x04000C42 RID: 3138
		Town,
		// Token: 0x04000C43 RID: 3139
		WorldMap,
		// Token: 0x04000C44 RID: 3140
		Gaming,
		// Token: 0x04000C45 RID: 3141
		PVP,
		// Token: 0x04000C46 RID: 3142
		RV,
		// Token: 0x04000C47 RID: 3143
		none
	}
}
