using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000590 RID: 1424
public class CharacterFxMgr
{
	// Token: 0x06002469 RID: 9321 RVA: 0x00018D79 File Offset: 0x00016F79
	public CharacterFxMgr()
	{
		this.mFxParaArray = new CharacterFxMgr.FxPara[5];
		this.mCharacterList = new List<CharacterFxMgr.CharacterEntity>();
	}

	// Token: 0x0600246A RID: 9322 RVA: 0x000AE5A0 File Offset: 0x000AC7A0
	public void method_0()
	{
		CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
		if (component != null)
		{
			Color color = new Color(component.mFireBlendPara, component.mSpeedX, component.mSpeedY);
			this.mFxParaArray[0] = new CharacterFxMgr.FxPara(component.mFireColor, color, component.mFireSupportTransparentView);
			color = new Color(component.mElectricPara, component.mSpeedX, component.mSpeedY);
			this.mFxParaArray[1] = new CharacterFxMgr.FxPara(component.mElectricColor, color, component.mElectricSupportTransparentView);
			color = new Color(component.mPoisonPara, component.mSpeedX, component.mSpeedY);
			this.mFxParaArray[2] = new CharacterFxMgr.FxPara(component.mPoisonColor, color, component.mPoisonSupportTransparentView);
			color = new Color(component.mRevivePara, component.mSpeedX, component.mSpeedY);
			this.mFxParaArray[3] = new CharacterFxMgr.FxPara(component.mReviveColor, color, component.mReviveSupportTransparentView);
			color = new Color(component.mHunterMarkPara, component.mSpeedX, component.mSpeedY);
			this.mFxParaArray[4] = new CharacterFxMgr.FxPara(component.mHunterMarkColor, color, component.mHunterMarkSupportTransparentView);
			this.mUvAnimTex = component.mUvAnimTex;
		}
	}

	// Token: 0x0600246B RID: 9323 RVA: 0x00018D98 File Offset: 0x00016F98
	public CharacterFxMgr.FxPara[] method_1()
	{
		return this.mFxParaArray;
	}

	// Token: 0x0600246C RID: 9324 RVA: 0x00018DA0 File Offset: 0x00016FA0
	public Texture method_2()
	{
		return this.mUvAnimTex;
	}

	// Token: 0x0600246D RID: 9325 RVA: 0x000AE6DC File Offset: 0x000AC8DC
	public void method_3(Entity entity_0, float float_0, AttackInfo.ElementalType elementalType_0)
	{
		CharacterFxMgr.FX_TYPE fx_TYPE;
		switch (elementalType_0)
		{
		case AttackInfo.ElementalType.Fire:
			fx_TYPE = CharacterFxMgr.FX_TYPE.FX_FIRE;
			break;
		case AttackInfo.ElementalType.Shock:
			fx_TYPE = CharacterFxMgr.FX_TYPE.FX_ELECTRIC;
			break;
		case AttackInfo.ElementalType.Corrosive:
			fx_TYPE = CharacterFxMgr.FX_TYPE.FX_POISON;
			break;
		default:
			DebugUtils.LogError(LogCategory.Graphics, "Unsupport fx effect!");
			return;
		}
		this.method_4(entity_0, float_0, fx_TYPE);
	}

	// Token: 0x0600246E RID: 9326 RVA: 0x000AE720 File Offset: 0x000AC920
	public void method_4(Entity entity_0, float float_0, CharacterFxMgr.FX_TYPE fx_TYPE_0)
	{
		CharacterFxMgr.CharacterEntity characterEntity = new CharacterFxMgr.CharacterEntity(this, entity_0, float_0, fx_TYPE_0);
		this.mCharacterList.Add(characterEntity);
	}

	// Token: 0x0600246F RID: 9327 RVA: 0x000AE744 File Offset: 0x000AC944
	public void method_5(Entity entity_0)
	{
		for (int i = 0; i < this.mCharacterList.Count; i++)
		{
			CharacterFxMgr.CharacterEntity characterEntity = this.mCharacterList[i];
			if (characterEntity.method_1(entity_0))
			{
				characterEntity.method_6();
				this.mCharacterList.Remove(characterEntity);
			}
		}
	}

	// Token: 0x06002470 RID: 9328 RVA: 0x000AE790 File Offset: 0x000AC990
	public void Update()
	{
		for (int i = 0; i < this.mCharacterList.Count; i++)
		{
			CharacterFxMgr.CharacterEntity characterEntity = this.mCharacterList[i];
			if (characterEntity.method_2())
			{
				characterEntity.method_6();
				this.mCharacterList.Remove(characterEntity);
			}
			else
			{
				characterEntity.method_10();
			}
		}
	}

	// Token: 0x0400194E RID: 6478
	private CharacterFxMgr.FxPara[] mFxParaArray;

	// Token: 0x0400194F RID: 6479
	private List<CharacterFxMgr.CharacterEntity> mCharacterList;

	// Token: 0x04001950 RID: 6480
	private Texture mUvAnimTex;

	// Token: 0x02000591 RID: 1425
	public enum FX_TYPE
	{
		// Token: 0x04001952 RID: 6482
		FX_FIRE,
		// Token: 0x04001953 RID: 6483
		FX_ELECTRIC,
		// Token: 0x04001954 RID: 6484
		FX_POISON,
		// Token: 0x04001955 RID: 6485
		FX_REVIVE,
		// Token: 0x04001956 RID: 6486
		FX_HUNTER_MARK,
		// Token: 0x04001957 RID: 6487
		FX_NUM
	}

	// Token: 0x02000592 RID: 1426
	public class FxPara
	{
		// Token: 0x06002471 RID: 9329 RVA: 0x00018DA8 File Offset: 0x00016FA8
		public FxPara(Color color_0, Color color_1, bool bool_0)
		{
			this.mEffectColor = color_0;
			this.mBlendPara = color_1;
			this.mSupportTransparentView = bool_0;
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x00018DC5 File Offset: 0x00016FC5
		public Color method_0()
		{
			return this.mEffectColor;
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x00018DCD File Offset: 0x00016FCD
		public Color method_1()
		{
			return this.mBlendPara;
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x00018DD5 File Offset: 0x00016FD5
		public bool method_2()
		{
			return this.mSupportTransparentView;
		}

		// Token: 0x04001958 RID: 6488
		private Color mEffectColor;

		// Token: 0x04001959 RID: 6489
		private Color mBlendPara;

		// Token: 0x0400195A RID: 6490
		private bool mSupportTransparentView;
	}

	// Token: 0x02000593 RID: 1427
	private class CharacterEntity
	{
		// Token: 0x06002475 RID: 9333 RVA: 0x000AE7E4 File Offset: 0x000AC9E4
		public CharacterEntity(CharacterFxMgr characterFxMgr_0, Entity entity_0, float float_0, CharacterFxMgr.FX_TYPE fx_TYPE_0)
		{
			this.mFxMgr = characterFxMgr_0;
			this.mCharacter = entity_0;
			this.mTimer = new Utils.Timer();
			this.mTimer.Start(float_0);
			this.m_type = fx_TYPE_0;
			if (this.m_type == CharacterFxMgr.FX_TYPE.FX_REVIVE)
			{
				this.method_0(true);
			}
			else if (this.mFxMgr.method_1()[(int)this.m_type].method_2())
			{
				this.mWrapper = entity_0.gameObject.GetComponent<HurtEffectWrapper>();
				if (this.mWrapper == null)
				{
					this.mWrapper = entity_0.gameObject.AddComponent<HurtEffectWrapper>();
				}
				this.mWrapper.enabled = true;
				this.method_9();
			}
			else
			{
				this.method_3(CharacterFxMgr.CharacterEntity.m_name_defaultShader);
				this.method_5();
			}
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x000AE8B0 File Offset: 0x000ACAB0
		private void method_0(bool bool_0)
		{
			if (this.mCharacter == null)
			{
				return;
			}
			CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
			foreach (Renderer renderer in this.mCharacter.GetComponentsInChildren<Renderer>())
			{
				if (renderer)
				{
					for (int j = 0; j < renderer.materials.Length; j++)
					{
						Material material = renderer.materials[j];
						if (bool_0)
						{
							material.EnableKeyword("RESPAWN_ON");
							material.SetTexture("_RespawnTexture", component.mThirdPersonRespawnTexture);
							material.SetFloat("_RespawnStrength", component.mThirdPersonRespawnStrength);
							material.SetFloat("_RespawnSpeedU", component.mThirdPersonRespawnSpeedU);
							material.SetFloat("_RespawnSpeedV", component.mThirdPersonRespawnSpeedV);
						}
						else
						{
							material.DisableKeyword("RESPAWN_ON");
							material.SetTexture("_RespawnTexture", null);
							material.SetFloat("_RespawnStrength", 0f);
							material.SetFloat("_RespawnSpeedU", 0f);
							material.SetFloat("_RespawnSpeedV", 0f);
						}
					}
				}
			}
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x00018DF3 File Offset: 0x00016FF3
		public bool method_1(Entity entity_0)
		{
			return entity_0 == this.mCharacter;
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x00018E06 File Offset: 0x00017006
		public bool method_2()
		{
			return this.mTimer.method_7();
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x000AE9E0 File Offset: 0x000ACBE0
		private void method_3(string string_0)
		{
			this.m_matList.Clear();
			if (this.mCharacter == null)
			{
				return;
			}
			foreach (Renderer renderer in this.mCharacter.GetComponentsInChildren<Renderer>())
			{
				if (renderer)
				{
					for (int j = 0; j < renderer.materials.Length; j++)
					{
						Material material = renderer.materials[j];
						if (material.shader.name == string_0)
						{
							this.m_matList.Add(material);
						}
					}
				}
			}
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x000AEA6C File Offset: 0x000ACC6C
		private void method_4(string string_0, bool bool_0)
		{
			if (this.mCharacter == null)
			{
				return;
			}
			foreach (Material material in this.m_matList)
			{
				material.shader = Shader.Find(string_0);
				if (bool_0)
				{
					this.method_8(material);
				}
			}
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x00018E13 File Offset: 0x00017013
		private void method_5()
		{
			this.method_4(CharacterFxMgr.CharacterEntity.m_name_effectShader, true);
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x000AEADC File Offset: 0x000ACCDC
		public void method_6()
		{
			if (this.m_type == CharacterFxMgr.FX_TYPE.FX_REVIVE)
			{
				this.method_0(false);
			}
			else if (this.mFxMgr.method_1()[(int)this.m_type].method_2())
			{
				if (this.mWrapper != null)
				{
					this.mWrapper.enabled = false;
				}
			}
			else
			{
				this.method_7();
			}
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x00018E21 File Offset: 0x00017021
		private void method_7()
		{
			this.method_4(CharacterFxMgr.CharacterEntity.m_name_defaultShader, false);
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x000AEB38 File Offset: 0x000ACD38
		private void method_8(Material material_0)
		{
			material_0.SetColor("_Attack_Color", this.mFxMgr.method_1()[(int)this.m_type].method_0());
			material_0.SetTexture("_EmissUvAnimTex", this.mFxMgr.method_2());
			Color color = this.mFxMgr.method_1()[(int)this.m_type].method_1();
			if (this.m_type == CharacterFxMgr.FX_TYPE.FX_REVIVE)
			{
				color.r = 0f;
			}
			material_0.SetColor("_Attack_Para", color);
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x000AEBB8 File Offset: 0x000ACDB8
		private void method_9()
		{
			this.mWrapper.method_0(HurtEffectWrapper.EParamType.EPT_Color, "_Attack_Color", this.mFxMgr.method_1()[(int)this.m_type].method_0());
			this.mWrapper.method_0(HurtEffectWrapper.EParamType.EPT_Texture, "_EmissUvAnimTex", this.mFxMgr.method_2());
			Color color = this.mFxMgr.method_1()[(int)this.m_type].method_1();
			this.mWrapper.method_0(HurtEffectWrapper.EParamType.EPT_Color, "_Attack_Para", color);
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_10()
		{
		}

		// Token: 0x0400195B RID: 6491
		private Entity mCharacter;

		// Token: 0x0400195C RID: 6492
		private Utils.Timer mTimer;

		// Token: 0x0400195D RID: 6493
		private CharacterFxMgr mFxMgr;

		// Token: 0x0400195E RID: 6494
		private HurtEffectWrapper mWrapper;

		// Token: 0x0400195F RID: 6495
		private CharacterFxMgr.FX_TYPE m_type;

		// Token: 0x04001960 RID: 6496
		private List<Material> m_matList = new List<Material>();

		// Token: 0x04001961 RID: 6497
		private static string m_name_defaultShader = "Custom/BOL_Charactor_BRDF";

		// Token: 0x04001962 RID: 6498
		private static string m_name_effectShader = "Custom/BOL_Character_BRDF_WithHurtEffect";
	}
}
