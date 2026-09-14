using System;
using UnityEngine;

// Token: 0x02000ABD RID: 2749
public class TimePos
{
	// Token: 0x06004A89 RID: 19081 RVA: 0x00135C24 File Offset: 0x00133E24
	public TimePos(TimePos timePos_0)
	{
		this.m_networkTimeStamp = timePos_0.m_networkTimeStamp;
		this.m_time = timePos_0.m_time;
		this.m_position = timePos_0.m_position;
		this.m_rotation = timePos_0.m_rotation;
		this.m_frameNum = timePos_0.m_frameNum;
	}

	// Token: 0x06004A8A RID: 19082 RVA: 0x00030BD3 File Offset: 0x0002EDD3
	public TimePos(double double_0, Vector3 vector3_0, double double_1, int int_0)
	{
		this.m_networkTimeStamp = double_1;
		this.m_time = double_0;
		this.m_position = vector3_0;
		this.m_frameNum = int_0;
	}

	// Token: 0x06004A8B RID: 19083 RVA: 0x00030BF8 File Offset: 0x0002EDF8
	public TimePos(double double_0, Vector3 vector3_0, Quaternion quaternion_0, double double_1, int int_0)
	{
		this.m_networkTimeStamp = double_1;
		this.m_time = double_0;
		this.m_position = vector3_0;
		this.m_rotation = quaternion_0;
		this.m_frameNum = int_0;
	}

	// Token: 0x06004A8C RID: 19084 RVA: 0x00030C25 File Offset: 0x0002EE25
	public TimePos(double double_0, Vector3 vector3_0, int int_0)
	{
		this.m_time = double_0;
		this.m_position = vector3_0;
		this.m_frameNum = int_0;
	}

	// Token: 0x06004A8D RID: 19085 RVA: 0x00135C74 File Offset: 0x00133E74
	public override bool Equals(object obj)
	{
		TimePos timePos = obj as TimePos;
		return timePos != null && timePos.m_time == this.m_time && timePos.m_frameNum == this.m_frameNum;
	}

	// Token: 0x06004A8E RID: 19086 RVA: 0x00135CAC File Offset: 0x00133EAC
	public override int GetHashCode()
	{
		return this.m_time.GetHashCode() ^ this.m_position.GetHashCode();
	}

	// Token: 0x17000782 RID: 1922
	// (get) Token: 0x06004A8F RID: 19087 RVA: 0x00030C42 File Offset: 0x0002EE42
	// (set) Token: 0x06004A90 RID: 19088 RVA: 0x00030C4A File Offset: 0x0002EE4A
	public int m_frameNum { get; private set; }

	// Token: 0x17000783 RID: 1923
	// (get) Token: 0x06004A91 RID: 19089 RVA: 0x00030C53 File Offset: 0x0002EE53
	// (set) Token: 0x06004A92 RID: 19090 RVA: 0x00030C5B File Offset: 0x0002EE5B
	public double m_networkTimeStamp { get; private set; }

	// Token: 0x17000784 RID: 1924
	// (get) Token: 0x06004A93 RID: 19091 RVA: 0x00030C64 File Offset: 0x0002EE64
	// (set) Token: 0x06004A94 RID: 19092 RVA: 0x00030C6C File Offset: 0x0002EE6C
	public double m_time { get; private set; }

	// Token: 0x06004A95 RID: 19093 RVA: 0x00135CD4 File Offset: 0x00133ED4
	public override string ToString()
	{
		return string.Concat(new object[]
		{
			" localTime:",
			this.m_time,
			"remoteTime:",
			this.m_networkTimeStamp,
			"m_position:",
			this.m_position.x,
			",",
			this.m_position.y,
			",",
			this.m_position.z
		});
	}

	// Token: 0x04003641 RID: 13889
	public Vector3 m_position;

	// Token: 0x04003642 RID: 13890
	public Quaternion m_rotation;
}
