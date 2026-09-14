using System;
using System.IO;

using System.Runtime.CompilerServices;
// Token: 0x02000269 RID: 617
[Serializable]
public struct InputFrame
{
	// Token: 0x06000CE6 RID: 3302 RVA: 0x0000C2C1 File Offset: 0x0000A4C1
	public InputFrame(InputFrame inputFrame_0)
	{
		this.m_flags = inputFrame_0.m_flags;
		this.m_yaw = inputFrame_0.m_yaw;
		this.m_pitch = inputFrame_0.m_pitch;
		this.m_frameNum = inputFrame_0.m_frameNum;
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x0000C2F7 File Offset: 0x0000A4F7
	// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x0000C306 File Offset: 0x0000A506
	public float m_yaw
	{
		get
		{
			return (float)this.m_yaw16 / 100f;
		}
		set
		{
			this.m_yaw16 = (ushort)(value * 100f);
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0000C316 File Offset: 0x0000A516
	// (set) Token: 0x06000CEA RID: 3306 RVA: 0x0000C325 File Offset: 0x0000A525
	public float m_pitch
	{
		get
		{
			return (float)this.m_pitch16 / 100f;
		}
		set
		{
			this.m_pitch16 = (ushort)(value * 100f);
		}
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x0000C335 File Offset: 0x0000A535
	public bool HasFlag(InputFrame.Flag flag_0)
	{
		return (this.m_flags & (byte)flag_0) != 0;
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x0000C346 File Offset: 0x0000A546
	public void SetFlag(Flag flag, bool enabled)
	{
		if (enabled)
		{
			m_flags |= (byte)flag;
		}
		else
		{
			m_flags &= (byte)(~(byte)flag);
		}
	}
	// Token: 0x06000CED RID: 3309 RVA: 0x0000C36F File Offset: 0x0000A56F
	public bool IsEmpty()
	{
		return (int)this.m_flags << 1 == 0;
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x0000C37C File Offset: 0x0000A57C
	public static int FrameLength()
	{
		return 9;
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x0006D5D8 File Offset: 0x0006B7D8
	public static byte[] Serialize(InputFrame inputFrame_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes((short)inputFrame_0.m_flags), 0, 1);
		memoryStream.Write(BitConverter.GetBytes(inputFrame_0.m_yaw16), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(inputFrame_0.m_pitch16), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(inputFrame_0.m_frameNum), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x0006D644 File Offset: 0x0006B844
	public static InputFrame Deserialize(byte[] byte_0)
	{
		InputFrame inputFrame = default(InputFrame);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_0, 0, byte_0.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[4];
		memoryStream.Read(array, 0, 1);
		inputFrame.m_flags = array[0];
		memoryStream.Read(array, 0, 2);
		inputFrame.m_yaw16 = BitConverter.ToUInt16(array, 0);
		memoryStream.Read(array, 0, 2);
		inputFrame.m_pitch16 = BitConverter.ToUInt16(array, 0);
		memoryStream.Read(array, 0, 4);
		inputFrame.m_frameNum = BitConverter.ToInt32(array, 0);
		return inputFrame;
	}

	// Token: 0x04000BA3 RID: 2979
	public byte m_flags;

	// Token: 0x04000BA4 RID: 2980
	private ushort m_yaw16;

	// Token: 0x04000BA5 RID: 2981
	public ushort m_pitch16;

	// Token: 0x04000BA6 RID: 2982
	public int m_frameNum;

	// Token: 0x0200026A RID: 618
	public enum Flag
	{
		// Token: 0x04000BA8 RID: 2984
		Run = 1,
		// Token: 0x04000BA9 RID: 2985
		Jump,
		// Token: 0x04000BAA RID: 2986
		Forward = 4,
		// Token: 0x04000BAB RID: 2987
		Backward = 8,
		// Token: 0x04000BAC RID: 2988
		Left = 16,
		// Token: 0x04000BAD RID: 2989
		Right = 32,
		// Token: 0x04000BAE RID: 2990
		Crouch = 64,
		// Token: 0x04000BAF RID: 2991
		Aim = 128
	}
}
