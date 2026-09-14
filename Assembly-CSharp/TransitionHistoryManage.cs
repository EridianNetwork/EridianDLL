using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class TransitionHistoryManage
{
	// Token: 0x060003BC RID: 956 RVA: 0x00048400 File Offset: 0x00046600
	public TransitionHistoryManage(PlayerAnimationManagerFSM playerAnimationManagerFSM_0)
	{
		this.m_owner = playerAnimationManagerFSM_0;
		this.m_previousFirstPersonTransition = null;
		this.m_previousThirdPersonTransition = null;
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00048468 File Offset: 0x00046668
	public void Update()
	{
		if (this.m_owner == null)
		{
			return;
		}
		if (this.m_owner.m_firstPersonAnimator != null && this.m_owner.m_firstPersonAnimator.IsInTransition(0))
		{
			string name = this.m_owner.m_firstPersonAnimator.GetCurrentAnimationClipState(0)[0].clip.name;
			string name2 = this.m_owner.m_firstPersonAnimator.GetNextAnimationClipState(0)[0].clip.name;
			TransitionHistoryManage.Transition transition = new TransitionHistoryManage.Transition(name, name2);
			if (this.m_firstPersonTransitionHistory.Count > this.m_size)
			{
				this.m_firstPersonTransitionHistory.Dequeue();
			}
			this.method_1(transition);
		}
		if (this.m_owner.Animator_0 != null)
		{
			if (this.m_owner.Animator_0.IsInTransition(0))
			{
				AnimationInfo[] array = this.m_owner.Animator_0.GetCurrentAnimationClipState(0);
				string text = "Empty";
				if (array != null && array.Length > 0)
				{
					text = array[0].clip.name;
				}
				string text2 = "Empty";
				array = this.m_owner.Animator_0.GetNextAnimationClipState(0);
				if (array != null && array.Length > 0)
				{
					text2 = array[0].clip.name;
				}
				TransitionHistoryManage.Transition transition2 = new TransitionHistoryManage.Transition(text, text2);
				if (this.m_thirdPersonTransitionHistory.Count > this.m_size)
				{
					this.m_thirdPersonTransitionHistory.Dequeue();
				}
				this.method_2(transition2);
			}
			if (this.m_owner.Animator_0.IsInTransition(1))
			{
				AnimationInfo[] array2 = this.m_owner.Animator_0.GetCurrentAnimationClipState(1);
				string text3 = "Empty";
				if (array2 != null && array2.Length > 0)
				{
					text3 = array2[0].clip.name;
				}
				string text4 = "Empty";
				array2 = this.m_owner.Animator_0.GetNextAnimationClipState(1);
				if (array2 != null && array2.Length > 0)
				{
					text4 = array2[0].clip.name;
				}
				TransitionHistoryManage.Transition transition3 = new TransitionHistoryManage.Transition(text3, text4);
				if (this.m_thirdPersonTransitionHistoryUpper.Count > this.m_size)
				{
					this.m_thirdPersonTransitionHistoryUpper.Dequeue();
				}
				this.method_3(transition3);
			}
		}
		this.method_0();
	}

	// Token: 0x060003BE RID: 958 RVA: 0x000486A8 File Offset: 0x000468A8
	private void method_0()
	{
		if (!(this.m_owner == null) && this.m_owner.m_animationStateMachine != null && this.m_owner.m_animationStateMachine.m_curState != null)
		{
			string text = this.m_owner.m_animationStateMachine.m_curState.StateName;
			if (this.m_thirdPersonStateHistory.Count > 0)
			{
				if (string.Compare(this.m_thirdPersonStateHistory[this.m_thirdPersonStateHistory.Count - 1], text) != 0)
				{
					this.m_thirdPersonStateHistory.Add(text);
				}
			}
			else
			{
				this.m_thirdPersonStateHistory.Add(text);
			}
			if (this.m_thirdPersonStateHistory.Count > this.m_size)
			{
				this.m_thirdPersonStateHistory.RemoveAt(0);
			}
			if (this.m_owner.m_upperBodyStateMachine != null && this.m_owner.m_upperBodyStateMachine.m_curState != null)
			{
				text = this.m_owner.m_upperBodyStateMachine.m_curState.StateName;
				if (this.m_thirdPersonUpperbodyStateHistory.Count > 0)
				{
					if (string.Compare(this.m_thirdPersonUpperbodyStateHistory[this.m_thirdPersonUpperbodyStateHistory.Count - 1], text) != 0)
					{
						this.m_thirdPersonUpperbodyStateHistory.Add(text);
					}
				}
				else
				{
					this.m_thirdPersonUpperbodyStateHistory.Add(text);
				}
				if (this.m_thirdPersonUpperbodyStateHistory.Count > this.m_size)
				{
					this.m_thirdPersonUpperbodyStateHistory.RemoveAt(0);
				}
			}
			return;
		}
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00048808 File Offset: 0x00046A08
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("first Person: ");
		foreach (TransitionHistoryManage.Transition transition in this.m_firstPersonTransitionHistory)
		{
			stringBuilder.AppendFormat("  {0} -> {1},", transition.m_from, transition.m_to);
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("\t3rdPerson: ");
		foreach (TransitionHistoryManage.Transition transition2 in this.m_thirdPersonTransitionHistory)
		{
			stringBuilder.AppendFormat("  {0} -> {1},", transition2.m_from, transition2.m_to);
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("\t3rdPersonUpper: ");
		foreach (TransitionHistoryManage.Transition transition3 in this.m_thirdPersonTransitionHistoryUpper)
		{
			stringBuilder.AppendFormat("  {0} -> {1},", transition3.m_from, transition3.m_to);
		}
		if (this.m_thirdPersonStateHistory.Count > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("--StateHistory:\n\t");
			foreach (string text in this.m_thirdPersonStateHistory)
			{
				stringBuilder.AppendFormat("{0} ->", text);
			}
		}
		if (this.m_thirdPersonUpperbodyStateHistory.Count > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("--UpperBodyStateHistory:\n\t");
			foreach (string text2 in this.m_thirdPersonUpperbodyStateHistory)
			{
				stringBuilder.AppendFormat("{0} ->", text2);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00005485 File Offset: 0x00003685
	private void method_1(TransitionHistoryManage.Transition transition_0)
	{
		if (this.m_previousFirstPersonTransition == null || !this.m_previousFirstPersonTransition.method_0(transition_0))
		{
			this.m_firstPersonTransitionHistory.Enqueue(transition_0);
			this.m_previousFirstPersonTransition = transition_0;
		}
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x000054B0 File Offset: 0x000036B0
	private void method_2(TransitionHistoryManage.Transition transition_0)
	{
		if (this.m_previousThirdPersonTransition == null || !this.m_previousThirdPersonTransition.method_0(transition_0))
		{
			this.m_thirdPersonTransitionHistory.Enqueue(transition_0);
			this.m_previousThirdPersonTransition = transition_0;
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x000054DB File Offset: 0x000036DB
	private void method_3(TransitionHistoryManage.Transition transition_0)
	{
		if (this.m_previousThirdPersonTransitionUpper == null || !this.m_previousThirdPersonTransitionUpper.method_0(transition_0))
		{
			this.m_thirdPersonTransitionHistoryUpper.Enqueue(transition_0);
			this.m_previousThirdPersonTransitionUpper = transition_0;
		}
	}

	// Token: 0x040003AD RID: 941
	private PlayerAnimationManagerFSM m_owner;

	// Token: 0x040003AE RID: 942
	private int m_size = 5;

	// Token: 0x040003AF RID: 943
	private Queue<TransitionHistoryManage.Transition> m_firstPersonTransitionHistory = new Queue<TransitionHistoryManage.Transition>();

	// Token: 0x040003B0 RID: 944
	private Queue<TransitionHistoryManage.Transition> m_thirdPersonTransitionHistory = new Queue<TransitionHistoryManage.Transition>();

	// Token: 0x040003B1 RID: 945
	private Queue<TransitionHistoryManage.Transition> m_thirdPersonTransitionHistoryUpper = new Queue<TransitionHistoryManage.Transition>();

	// Token: 0x040003B2 RID: 946
	private TransitionHistoryManage.Transition m_previousFirstPersonTransition;

	// Token: 0x040003B3 RID: 947
	private TransitionHistoryManage.Transition m_previousThirdPersonTransition;

	// Token: 0x040003B4 RID: 948
	private TransitionHistoryManage.Transition m_previousThirdPersonTransitionUpper;

	// Token: 0x040003B5 RID: 949
	private List<string> m_thirdPersonStateHistory = new List<string>();

	// Token: 0x040003B6 RID: 950
	private List<string> m_thirdPersonUpperbodyStateHistory = new List<string>();

	// Token: 0x040003B7 RID: 951
	public bool m_errorInJump;

	// Token: 0x0200009F RID: 159
	public class Transition
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x00005506 File Offset: 0x00003706
		public Transition(string string_0, string string_1)
		{
			this.m_from = string_0;
			this.m_to = string_1;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000551C File Offset: 0x0000371C
		public bool method_0(TransitionHistoryManage.Transition transition_0)
		{
			return this.m_from.Equals(transition_0.m_from) && this.m_to.Equals(transition_0.m_to);
		}

		// Token: 0x040003B8 RID: 952
		public string m_from;

		// Token: 0x040003B9 RID: 953
		public string m_to;
	}
}
