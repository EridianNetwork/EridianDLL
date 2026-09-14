using System;
using UnityEngine;

// Token: 0x02000B53 RID: 2899
[Serializable]
public class EffectTriggerItem
{
	// Token: 0x06004EAF RID: 20143 RVA: 0x0014E704 File Offset: 0x0014C904
	public void method_0(EffectTrigger effectTrigger_0)
	{
		if (this.method_1(effectTrigger_0))
		{
			this.m_triggerData.m_trigger = effectTrigger_0;
			this.m_triggerData.m_effectName = this.m_effectNameToPlay;
			GameObject gameObject = null;
			if (this.m_effect != null)
			{
				gameObject = this.m_effect.gameObject;
			}
			else
			{
				Transform parent = this.m_triggerData.m_trigger.transform.parent;
				if (parent != null)
				{
					gameObject = parent.gameObject;
				}
			}
			if (gameObject != null)
			{
				gameObject.BroadcastMessage("PlayEffect", this.m_triggerData, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x06004EB0 RID: 20144 RVA: 0x0014E79C File Offset: 0x0014C99C
	private bool method_1(EffectTrigger effectTrigger_0)
	{
		bool flag = true;
		bool flag2 = true;
		if (this.m_conditionSource != null)
		{
			for (int i = 0; i < this.m_conditionSource.Length; i++)
			{
				GameObject gameObject = effectTrigger_0.m_gameObject;
				if (effectTrigger_0.m_location == EffectLocationType.Raycast)
				{
					gameObject = effectTrigger_0.m_raycastHit.collider.gameObject;
				}
				else if (gameObject == null)
				{
					gameObject = effectTrigger_0.gameObject;
				}
				string text = string.Empty;
				if (this.m_conditionSource[i] == EffectConditionSourceType.MaterialName)
				{
					if (gameObject.renderer != null && gameObject.renderer.sharedMaterial != null)
					{
						text = gameObject.renderer.sharedMaterial.name;
					}
				}
				else if (this.m_conditionSource[i] == EffectConditionSourceType.TagName)
				{
					text = gameObject.tag;
				}
				else if (this.m_conditionSource[i] == EffectConditionSourceType.GameObjectName)
				{
					text = gameObject.name;
				}
				if (this.m_conditionAction[i] == EffectConditionActionType.Contains)
				{
					flag2 = text.Contains(this.m_conditionDestination[i]);
				}
				else if (this.m_conditionAction[i] == EffectConditionActionType.NotContain)
				{
					flag2 = !text.Contains(this.m_conditionDestination[i]);
				}
				else if (this.m_conditionAction[i] == EffectConditionActionType.Equals)
				{
					flag2 = text == this.m_conditionDestination[i];
				}
				else if (this.m_conditionAction[i] == EffectConditionActionType.NotEqual)
				{
					flag2 = text != this.m_conditionDestination[i];
				}
				if (!(flag = flag && flag2))
				{
					break;
				}
			}
		}
		return flag;
	}

	// Token: 0x04003B11 RID: 15121
	public EffectConditionSourceType[] m_conditionSource;

	// Token: 0x04003B12 RID: 15122
	public EffectConditionActionType[] m_conditionAction;

	// Token: 0x04003B13 RID: 15123
	public string[] m_conditionDestination;

	// Token: 0x04003B14 RID: 15124
	public EffectBase m_effect;

	// Token: 0x04003B15 RID: 15125
	public string m_effectNameToPlay = string.Empty;

	// Token: 0x04003B16 RID: 15126
	private EffectTriggerData m_triggerData = new EffectTriggerData();
}
