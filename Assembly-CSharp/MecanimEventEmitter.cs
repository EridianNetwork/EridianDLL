using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000AD8 RID: 2776
public class MecanimEventEmitter : MonoBehaviour
{
	// Token: 0x06004B52 RID: 19282 RVA: 0x00138D2C File Offset: 0x00136F2C
	private void Start()
	{
		string text = base.gameObject.name;
		if (base.transform.parent != null)
		{
			text = base.transform.parent.name + "-->" + text;
		}
		if (this.animator == null)
		{
			DebugUtils.LogWarning(LogCategory.Animation, "Do not find animator component." + text);
			base.enabled = false;
			return;
		}
		if (this.animatorController == null)
		{
			DebugUtils.LogWarning(LogCategory.Animation, "Please assgin animator in editor. Add emitter at runtime is not currently supported." + text);
			base.enabled = false;
			return;
		}
		if (MecanimEventManager.Dictionary_0 != null)
		{
			string text2 = Utils.smethod_18(this.animator.runtimeAnimatorController.name);
			this.m_bEmitterLoaded = MecanimEventManager.Dictionary_0.ContainsKey(text2);
			if (this.m_bEmitterLoaded)
			{
				this.m_animatorControllerId = MecanimEventManager.Dictionary_0[text2];
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Animation, "Couldn't load MecanimEventEmitter data for: " + Utils.smethod_16(base.gameObject) + "\n\t animator.runtimeAnimatorController.name: " + this.animator.runtimeAnimatorController.name);
			}
		}
		if (this.m_animEventList != null)
		{
			this.m_animEventList.Clear();
		}
	}

	// Token: 0x06004B53 RID: 19283 RVA: 0x00138E50 File Offset: 0x00137050
	private void Update()
	{
		if (!this.m_bEmitterLoaded)
		{
			return;
		}
		MecanimEventManager.smethod_2(ref this.m_animEventList, this.m_animatorControllerId, this.animator);
		for (int i = 0; i < this.m_animEventList.Count; i++)
		{
			MecanimEvent mecanimEvent = this.m_animEventList[i];
			MecanimEvent.smethod_0(mecanimEvent);
			MecanimEventEmitTypes mecanimEventEmitTypes = this.emitType;
			if (mecanimEventEmitTypes != MecanimEventEmitTypes.Upwards)
			{
				if (mecanimEventEmitTypes != MecanimEventEmitTypes.Broadcast)
				{
					if (mecanimEvent.paramType != MecanimEventParamTypes.None)
					{
						base.SendMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
					}
					else
					{
						base.SendMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
					}
				}
				else if (mecanimEvent.paramType != MecanimEventParamTypes.None)
				{
					base.BroadcastMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					base.BroadcastMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (mecanimEvent.paramType != MecanimEventParamTypes.None)
			{
				base.SendMessageUpwards(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				base.SendMessageUpwards(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
			}
		}
		if (this.m_animEventList != null)
		{
			this.m_animEventList.Clear();
		}
	}

	// Token: 0x040036D7 RID: 14039
	public global::UnityEngine.Object animatorController;

	// Token: 0x040036D8 RID: 14040
	public Animator animator;

	// Token: 0x040036D9 RID: 14041
	public MecanimEventEmitTypes emitType = MecanimEventEmitTypes.Upwards;

	// Token: 0x040036DA RID: 14042
	protected int m_animatorControllerId = -1;

	// Token: 0x040036DB RID: 14043
	protected bool m_bEmitterLoaded;

	// Token: 0x040036DC RID: 14044
	protected List<MecanimEvent> m_animEventList = new List<MecanimEvent>();
}
