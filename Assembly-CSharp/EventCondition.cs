using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AD2 RID: 2770
[Serializable]
public class EventCondition
{
	// Token: 0x06004B4C RID: 19276 RVA: 0x00138AFC File Offset: 0x00136CFC
	public bool method_0(Animator animator_0)
	{
		if (this.conditions.Count == 0)
		{
			return true;
		}
		foreach (EventConditionEntry eventConditionEntry in this.conditions)
		{
			if (!string.IsNullOrEmpty(eventConditionEntry.conditionParam))
			{
				switch (eventConditionEntry.conditionParamType)
				{
				case EventConditionParamTypes.Int:
				{
					int integer = animator_0.GetInteger(eventConditionEntry.conditionParam);
					switch (eventConditionEntry.conditionMode)
					{
					case EventConditionModes.Equal:
						if (integer != eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.NotEqual:
						if (integer == eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.GreaterThan:
						if (integer <= eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.LessThan:
						if (integer >= eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.GreaterEqualThan:
						if (integer < eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.LessEqualThan:
						if (integer > eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					}
					break;
				}
				case EventConditionParamTypes.Float:
				{
					float @float = animator_0.GetFloat(eventConditionEntry.conditionParam);
					EventConditionModes conditionMode = eventConditionEntry.conditionMode;
					if (conditionMode != EventConditionModes.GreaterThan)
					{
						if (conditionMode == EventConditionModes.LessThan)
						{
							if (@float >= eventConditionEntry.floatValue)
							{
								return false;
							}
						}
					}
					else if (@float <= eventConditionEntry.floatValue)
					{
						return false;
					}
					break;
				}
				case EventConditionParamTypes.Boolean:
					if (animator_0.GetBool(eventConditionEntry.conditionParam) != eventConditionEntry.boolValue)
					{
						return false;
					}
					break;
				}
			}
		}
		return true;
	}

	// Token: 0x040036C0 RID: 14016
	public List<EventConditionEntry> conditions = new List<EventConditionEntry>();
}
