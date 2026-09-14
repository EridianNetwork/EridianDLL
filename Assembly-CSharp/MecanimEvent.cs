using System;
using System.Collections.Generic;

// Token: 0x02000AD1 RID: 2769
[Serializable]
public class MecanimEvent
{
	// Token: 0x06004B42 RID: 19266 RVA: 0x001388E4 File Offset: 0x00136AE4
	public MecanimEvent()
	{
		this.condition = new EventCondition();
		this.eventEnumList = new BaseEventEnumList();
		List<string> list = new List<string>();
		foreach (KeyValuePair<int, string> keyValuePair in this.eventEnumList.DicData)
		{
			list.Add(keyValuePair.Value);
		}
		MecanimEvent.enumParamList = list.ToArray();
	}

	// Token: 0x06004B43 RID: 19267 RVA: 0x00138978 File Offset: 0x00136B78
	public MecanimEvent(MecanimEvent mecanimEvent_0)
	{
		this.normalizedTime = mecanimEvent_0.normalizedTime;
		this.functionName = mecanimEvent_0.functionName;
		this.paramType = mecanimEvent_0.paramType;
		switch (this.paramType)
		{
		case MecanimEventParamTypes.Int32:
			this.intParam = mecanimEvent_0.intParam;
			break;
		case MecanimEventParamTypes.Float:
			this.floatParam = mecanimEvent_0.floatParam;
			break;
		case MecanimEventParamTypes.String:
			this.stringParam = mecanimEvent_0.stringParam;
			break;
		case MecanimEventParamTypes.Boolean:
			this.boolParam = mecanimEvent_0.boolParam;
			break;
		case MecanimEventParamTypes.EnumList:
			this.enumParam = mecanimEvent_0.enumParam;
			break;
		}
		this.condition = new EventCondition();
		this.condition.conditions = new List<EventConditionEntry>(mecanimEvent_0.condition.conditions);
		this.critical = mecanimEvent_0.critical;
		this.isEnable = mecanimEvent_0.isEnable;
	}

	// Token: 0x17000792 RID: 1938
	// (get) Token: 0x06004B45 RID: 19269 RVA: 0x000311E8 File Offset: 0x0002F3E8
	// (set) Token: 0x06004B44 RID: 19268 RVA: 0x000311E0 File Offset: 0x0002F3E0
	public static EventContext Context { get; protected set; }

	// Token: 0x17000793 RID: 1939
	// (get) Token: 0x06004B46 RID: 19270 RVA: 0x00138A60 File Offset: 0x00136C60
	public object parameter
	{
		get
		{
			switch (this.paramType)
			{
			case MecanimEventParamTypes.Int32:
				return this.intParam;
			case MecanimEventParamTypes.Float:
				return this.floatParam;
			case MecanimEventParamTypes.String:
				return this.stringParam;
			case MecanimEventParamTypes.Boolean:
				return this.boolParam;
			case MecanimEventParamTypes.EnumList:
				return this.enumParam;
			default:
				return null;
			}
		}
	}

	// Token: 0x06004B47 RID: 19271 RVA: 0x00138AC4 File Offset: 0x00136CC4
	public int method_0()
	{
		for (int i = 0; i < MecanimEvent.enumParamList.Length; i++)
		{
			if (MecanimEvent.enumParamList[i] == this.enumParam)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x06004B48 RID: 19272 RVA: 0x000311EF File Offset: 0x0002F3EF
	public void method_1(int int_0)
	{
		this.enumParam = MecanimEvent.enumParamList[int_0];
	}

	// Token: 0x06004B49 RID: 19273 RVA: 0x000311FE File Offset: 0x0002F3FE
	public void method_2(EventContext eventContext_0)
	{
		this.context = eventContext_0;
		this.context.current = this;
	}

	// Token: 0x06004B4A RID: 19274 RVA: 0x00031213 File Offset: 0x0002F413
	public static void smethod_0(MecanimEvent mecanimEvent_0)
	{
		MecanimEvent.Context = mecanimEvent_0.context;
	}

	// Token: 0x040036B1 RID: 14001
	public string functionName;

	// Token: 0x040036B2 RID: 14002
	public float normalizedTime;

	// Token: 0x040036B3 RID: 14003
	public MecanimEventParamTypes paramType;

	// Token: 0x040036B4 RID: 14004
	private BaseEventEnumList eventEnumList;

	// Token: 0x040036B5 RID: 14005
	public int intParam;

	// Token: 0x040036B6 RID: 14006
	public float floatParam;

	// Token: 0x040036B7 RID: 14007
	public string stringParam;

	// Token: 0x040036B8 RID: 14008
	public bool boolParam;

	// Token: 0x040036B9 RID: 14009
	public string enumParam;

	// Token: 0x040036BA RID: 14010
	public static string[] enumParamList;

	// Token: 0x040036BB RID: 14011
	public EventCondition condition;

	// Token: 0x040036BC RID: 14012
	public bool critical;

	// Token: 0x040036BD RID: 14013
	public bool isEnable = true;

	// Token: 0x040036BE RID: 14014
	private EventContext context;
}
