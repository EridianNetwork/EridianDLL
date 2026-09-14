using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200026B RID: 619
public class InstanceInput : MonoBehaviour
{
	// Token: 0x06000CF2 RID: 3314 RVA: 0x0000C396 File Offset: 0x0000A596
	private void Awake()
	{
		this.m_outgoing = new RingBuffer(10, true);
		this.m_incoming = new RingBuffer(10, true);
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
	private void Start()
	{
		this.m_player = base.GetComponent<EntityPlayer>();
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x0000C3C2 File Offset: 0x0000A5C2
	public int GetIncommingFrames()
	{
		return this.m_incoming.GetCount();
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x0006D6E0 File Offset: 0x0006B8E0
	public Vector3 GetMovementDirection()
	{
		float num = 0f;
		float num2 = 0f;
		if (this.currentInput.HasFlag(InputFrame.Flag.Left))
		{
			num -= 1f;
		}
		if (this.currentInput.HasFlag(InputFrame.Flag.Right))
		{
			num += 1f;
		}
		if (this.currentInput.HasFlag(InputFrame.Flag.Forward))
		{
			num2 += 1f;
		}
		if (this.currentInput.HasFlag(InputFrame.Flag.Backward))
		{
			num2 -= 1f;
		}
		Vector3 vector = new Vector3(num, 0f, num2);
		return vector.normalized;
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x0000C3CF File Offset: 0x0000A5CF
	public bool IsRunning()
	{
		return this.currentInput.HasFlag(InputFrame.Flag.Run);
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x0000C3DD File Offset: 0x0000A5DD
	public bool IsMoving()
	{
		return this.currentInput.HasFlag(InputFrame.Flag.Forward) || this.currentInput.HasFlag(InputFrame.Flag.Backward) || this.currentInput.HasFlag(InputFrame.Flag.Left) || this.currentInput.HasFlag(InputFrame.Flag.Right);
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x0000C41A File Offset: 0x0000A61A
	public bool IsJumping()
	{
		return this.currentInput.HasFlag(InputFrame.Flag.Jump);
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x0000C428 File Offset: 0x0000A628
	public bool IsAiming()
	{
		return this.currentInput.HasFlag(InputFrame.Flag.Aim);
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x0000C43A File Offset: 0x0000A63A
	public bool IsCrouching()
	{
		return this.currentInput.HasFlag(InputFrame.Flag.Crouch);
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x0000C449 File Offset: 0x0000A649
	public float GetYaw()
	{
		return this.currentInput.m_yaw;
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x0000C456 File Offset: 0x0000A656
	public float GetPitch()
	{
		return this.currentInput.m_pitch;
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x0006D768 File Offset: 0x0006B968
	public void EnqueueIncomingInputs(InputFrame[] inputFrame_0)
	{
		if (this.m_incoming.GetCount() > this.m_incomingLagcy)
		{
			this.m_exceedCount++;
		}
		else
		{
			this.m_exceedCount = 0;
		}
		if (this.m_exceedCount > this.m_drainWhenExceed)
		{
			this.m_exceedCount = 0;
			this.DiscardExcessEmptyFrames(this.m_drain);
		}
		for (int i = 0; i < inputFrame_0.Length; i++)
		{
			this.m_incoming.Enqueue(inputFrame_0[i]);
		}
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x0006D7EC File Offset: 0x0006B9EC
	public void FlushOutgoingInputs(out InputFrame[] inputFrame_0)
	{
		inputFrame_0 = new InputFrame[this.m_outgoing.GetCount()];
		for (int i = 0; i < inputFrame_0.Length; i++)
		{
			inputFrame_0[i] = (InputFrame)this.m_outgoing.Dequeue();
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x0006D838 File Offset: 0x0006BA38
	public void CaptureAndQueueInputFrame()
	{
		if (this.m_player && this.m_player.vmethod_25().IsMyActor())
		{
			this.currentInput = this.BuildInputFrame();
			this.m_outgoing.Enqueue(this.currentInput);
		}
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x0006D888 File Offset: 0x0006BA88
	private void FixedUpdate()
	{
		if (this.m_player == null)
		{
			return;
		}
		if (this.m_player.vmethod_25() == null)
		{
			return;
		}
		if (!MonoSingleton<AppManager>.Instance.m_offlineMode && this.m_outgoing.GetCount() == this.m_outgoing.GetCapacity())
		{
			DebugUtils.Log(LogCategory.Input, "outgoing buffer overflow");
		}
		if (this.m_incoming.GetCount() != 0)
		{
			this.m_InputMiss = 0;
			this.currentInput = (InputFrame)this.m_incoming.Dequeue();
		}
		else
		{
			this.m_InputMiss++;
		}
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x0006D924 File Offset: 0x0006BB24
	private void DiscardExcessEmptyFrames(int int_0)
	{
		int num = this.m_incoming.GetCount();
		while (num > int_0 && num > 1)
		{
			InputFrame inputFrame = (InputFrame)this.m_incoming.PeekAt(0);
			InputFrame inputFrame2 = (InputFrame)this.m_incoming.PeekAt(1);
			if (!inputFrame.IsEmpty() || !inputFrame2.IsEmpty())
			{
				break;
			}
			this.currentInput = (InputFrame)this.m_incoming.Dequeue();
			num = this.m_incoming.GetCount();
		}
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x0000C463 File Offset: 0x0000A663
	private PlayerBehavior GetPlayerBehavior()
	{
		if (this.m_playerBehavior == null)
		{
			this.m_playerBehavior = base.GetComponent<PlayerBehavior>();
		}
		return this.m_playerBehavior;
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x0006D9A0 File Offset: 0x0006BBA0
	private InputFrame BuildInputFrame()
	{
		InputFrame inputFrame = default(InputFrame);
		PlayerBehavior playerBehavior = this.GetPlayerBehavior();
		inputFrame.SetFlag(InputFrame.Flag.Forward, playerBehavior.IsMovingForward());
		inputFrame.SetFlag(InputFrame.Flag.Backward, playerBehavior.IsMovingBackwards());
		inputFrame.SetFlag(InputFrame.Flag.Left, playerBehavior.IsMovingLeft());
		inputFrame.SetFlag(InputFrame.Flag.Right, playerBehavior.IsMovingRight());
		inputFrame.SetFlag(InputFrame.Flag.Jump, playerBehavior.IsJumping());
		inputFrame.SetFlag(InputFrame.Flag.Run, playerBehavior.IsRunning());
		inputFrame.SetFlag(InputFrame.Flag.Aim, playerBehavior.IsAiming());
		inputFrame.SetFlag(InputFrame.Flag.Crouch, playerBehavior.IsCrouching());
		inputFrame.m_frameNum = this.m_instanceInputCount;
		this.m_instanceInputCount++;
		inputFrame.m_yaw = playerBehavior.GetYawAngle();
		inputFrame.m_pitch = playerBehavior.GetPitchAngle();
		return inputFrame;
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x0006DA6C File Offset: 0x0006BC6C
	private InputFrame method_15()
	{
		InputFrame inputFrame = default(InputFrame);
		PlayerBehavior playerBehavior = this.GetPlayerBehavior();
		inputFrame.SetFlag(InputFrame.Flag.Forward, playerBehavior.IsMovingForward());
		inputFrame.SetFlag(InputFrame.Flag.Backward, playerBehavior.IsMovingBackwards());
		inputFrame.SetFlag(InputFrame.Flag.Left, playerBehavior.IsMovingLeft());
		inputFrame.SetFlag(InputFrame.Flag.Right, playerBehavior.IsMovingRight());
		inputFrame.SetFlag(InputFrame.Flag.Jump, playerBehavior.IsJumping());
		inputFrame.SetFlag(InputFrame.Flag.Run, playerBehavior.IsRunning());
		inputFrame.SetFlag(InputFrame.Flag.Aim, playerBehavior.IsAiming());
		inputFrame.SetFlag(InputFrame.Flag.Crouch, playerBehavior.IsCrouching());
		inputFrame.m_frameNum = this.m_instanceInputCount;
		inputFrame.m_yaw = playerBehavior.GetYawAngle();
		inputFrame.m_pitch = playerBehavior.GetPitchAngle();
		return inputFrame;
	}

	// Token: 0x04000BB0 RID: 2992
	public int m_incomingLagcy = 2;

	// Token: 0x04000BB1 RID: 2993
	public int m_drainWhenExceed = 3;

	// Token: 0x04000BB2 RID: 2994
	public int m_drain;

	// Token: 0x04000BB3 RID: 2995
	private int m_exceedCount;

	// Token: 0x04000BB4 RID: 2996
	public InputFrame currentInput;

	// Token: 0x04000BB5 RID: 2997
	private PlayerBehavior m_playerBehavior;

	// Token: 0x04000BB6 RID: 2998
	private RingBuffer m_outgoing;

	// Token: 0x04000BB7 RID: 2999
	private RingBuffer m_incoming;

	// Token: 0x04000BB8 RID: 3000
	private EntityPlayer m_player;

	// Token: 0x04000BB9 RID: 3001
	private int m_InputMiss;

	// Token: 0x04000BBA RID: 3002
	private int m_instanceInputCount;
}
