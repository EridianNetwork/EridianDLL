using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x020002B0 RID: 688
	public class AnimationStateMachine
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x0000CFDA File Offset: 0x0000B1DA
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x0000CFE2 File Offset: 0x0000B1E2
		public AnimationStateBase m_curState { get; private set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x0000CFEB File Offset: 0x0000B1EB
		// (set) Token: 0x06000ECA RID: 3786 RVA: 0x0000CFF3 File Offset: 0x0000B1F3
		public AnimationStateBase m_preState { get; private set; }

		// Token: 0x170000BD RID: 189
		public AnimationStateBase this[string string_0]
		{
			get
			{
				if (!this.States.ContainsKey(string_0))
				{
					return null;
				}
				return this.States[string_0];
			}
			set
			{
				this.States[string_0] = value;
			}
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x0000D029 File Offset: 0x0000B229
		public void method_0(string string_0)
		{
			this.States.Add(string_0, new AnimationStateBase(this, string_0));
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x000740C0 File Offset: 0x000722C0
		public void method_1(string string_0)
		{
			AnimationStateBase animationStateBase = null;
			if (!this.States.TryGetValue(string_0, out animationStateBase))
			{
				return;
			}
			if (animationStateBase == null)
			{
				return;
			}
			animationStateBase.StateMachine = this;
			if (this.m_curState != null)
			{
				this.m_curState.vmethod_2();
			}
			this.m_preState = this.m_curState;
			this.m_curState = animationStateBase;
			this.m_curState.vmethod_0();
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0000D03E File Offset: 0x0000B23E
		public void method_2(AnimationStateBase gclass11_2)
		{
			if (gclass11_2 == null)
			{
				return;
			}
			gclass11_2.StateMachine = this;
			if (this.m_curState != null)
			{
				this.m_curState.vmethod_2();
			}
			this.m_preState = this.m_curState;
			this.m_curState = gclass11_2;
			this.m_curState.vmethod_0();
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x0007411C File Offset: 0x0007231C
		public bool method_3(string string_0)
		{
			AnimationStateBase animationStateBase = null;
			return this.States.TryGetValue(string_0, out animationStateBase) && this.m_curState == animationStateBase;
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x0000D07C File Offset: 0x0000B27C
		public bool method_4(AnimationStateBase gclass11_2)
		{
			return this.m_curState == gclass11_2;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x0000D087 File Offset: 0x0000B287
		public virtual void Update()
		{
			if (this.m_curState == null)
			{
				return;
			}
			this.m_curState.vmethod_1();
		}

		// Token: 0x04000D3E RID: 3390
		public Dictionary<string, AnimationStateBase> States = new Dictionary<string, AnimationStateBase>();

		// Token: 0x04000D3F RID: 3391
		[CompilerGenerated]
		private AnimationStateBase gclass11_0;

		// Token: 0x04000D40 RID: 3392
		[CompilerGenerated]
		private AnimationStateBase gclass11_1;
	}
}
