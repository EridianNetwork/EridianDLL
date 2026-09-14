using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ns0
{
	// Token: 0x020002AF RID: 687
	public class AnimationStateBase
	{
		// Token: 0x06000EBA RID: 3770 RVA: 0x0000CEB5 File Offset: 0x0000B0B5
		public AnimationStateBase()
		{
			this.AutoTransistion = false;
			this.Duration = 0f;
			this.ElapsedTime = 0f;
			this.NextState = null;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00074008 File Offset: 0x00072208
		public AnimationStateBase(AnimationStateMachine gclass12_1, string string_1)
		{
			this.StateMachine = gclass12_1;
			this.StateName = string_1;
			this.AutoTransistion = false;
			this.Duration = 0f;
			this.ElapsedTime = 0f;
			this.NextState = null;
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000EBC RID: 3772 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		// (remove) Token: 0x06000EBD RID: 3773 RVA: 0x0000CF05 File Offset: 0x0000B105
		public event OnEnterAnim onEnter
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnEnter = (OnEnterAnim)Delegate.Combine(this.OnEnter, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnEnter = (OnEnterAnim)Delegate.Remove(this.OnEnter, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000EBE RID: 3774 RVA: 0x0000CF1E File Offset: 0x0000B11E
		// (remove) Token: 0x06000EBF RID: 3775 RVA: 0x0000CF37 File Offset: 0x0000B137
		public event OnUpdateAnim onUpdate
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnUpdate = (OnUpdateAnim)Delegate.Combine(this.OnUpdate, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnUpdate = (OnUpdateAnim)Delegate.Remove(this.OnUpdate, value);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000EC0 RID: 3776 RVA: 0x0000CF50 File Offset: 0x0000B150
		// (remove) Token: 0x06000EC1 RID: 3777 RVA: 0x0000CF69 File Offset: 0x0000B169
		public event OnExitAnim onExit
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnExit = (OnExitAnim)Delegate.Combine(this.OnExit, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnExit = (OnExitAnim)Delegate.Remove(this.OnExit, value);
			}
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0000CF82 File Offset: 0x0000B182
		public void method_0(AnimationStateMachine gclass12_1, string string_1)
		{
			this.StateMachine = gclass12_1;
			this.StateName = string_1;
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0000CF92 File Offset: 0x0000B192
		public virtual void vmethod_0()
		{
			this.ElapsedTime = 0f;
			if (this.OnEnter != null)
			{
				this.OnEnter();
			}
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00074058 File Offset: 0x00072258
		public virtual void vmethod_1()
		{
			this.ElapsedTime += Time.deltaTime;
			if (this.AutoTransistion && this.ElapsedTime >= this.Duration)
			{
				if (this.NextState != null)
				{
					this.StateMachine.method_1(this.NextState.StateName);
				}
				return;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0000CFB2 File Offset: 0x0000B1B2
		public virtual void vmethod_2()
		{
			if (this.OnExit != null)
			{
				this.OnExit();
			}
		}

		// Token: 0x04000D35 RID: 3381
		public string StateName = "DefaultStateName";

		// Token: 0x04000D36 RID: 3382
		public AnimationStateMachine StateMachine;

		// Token: 0x04000D37 RID: 3383
		public bool AutoTransistion;

		// Token: 0x04000D38 RID: 3384
		public AnimationStateBase NextState;

		// Token: 0x04000D39 RID: 3385
		protected float Duration;

		// Token: 0x04000D3A RID: 3386
		protected float ElapsedTime;

		// Token: 0x04000D3B RID: 3387
		private OnEnterAnim OnEnter;

		// Token: 0x04000D3C RID: 3388
		private OnUpdateAnim OnUpdate;

		// Token: 0x04000D3D RID: 3389
		private OnExitAnim OnExit;
	}
}
