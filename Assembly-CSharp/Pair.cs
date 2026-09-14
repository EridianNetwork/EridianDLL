using System;
using UnityEngine;

// Token: 0x02000A9B RID: 2715
[Serializable]
public sealed class Pair<TLeft, TRight>
{
	// Token: 0x0600496A RID: 18794 RVA: 0x0002FFE5 File Offset: 0x0002E1E5
	public Pair(TLeft gparam_0, TRight gparam_1)
	{
		this._left = gparam_0;
		this._right = gparam_1;
	}

	// Token: 0x17000777 RID: 1911
	// (get) Token: 0x0600496B RID: 18795 RVA: 0x0002FFFB File Offset: 0x0002E1FB
	public TLeft Left
	{
		get
		{
			return this._left;
		}
	}

	// Token: 0x17000778 RID: 1912
	// (get) Token: 0x0600496C RID: 18796 RVA: 0x00030003 File Offset: 0x0002E203
	// (set) Token: 0x0600496D RID: 18797 RVA: 0x0003000B File Offset: 0x0002E20B
	public TRight Right
	{
		get
		{
			return this._right;
		}
		set
		{
			this._right = value;
		}
	}

	// Token: 0x0600496E RID: 18798 RVA: 0x00131588 File Offset: 0x0012F788
	public override int GetHashCode()
	{
		int num;
		if (this._left == null)
		{
			num = 0;
		}
		else
		{
			TLeft left = this._left;
			num = left.GetHashCode();
		}
		int num2 = num;
		int num3 = ((this._right != null) ? this._right.GetHashCode() : 0);
		return num2 ^ num3;
	}

	// Token: 0x0600496F RID: 18799 RVA: 0x001315E0 File Offset: 0x0012F7E0
	public override bool Equals(object obj)
	{
		Pair<TLeft, TRight> pair = obj as Pair<TLeft, TRight>;
		return pair != null && object.Equals(this._left, pair._left) && object.Equals(this._right, pair._right);
	}

	// Token: 0x040035D4 RID: 13780
	[SerializeField]
	private readonly TLeft _left;

	// Token: 0x040035D5 RID: 13781
	[SerializeField]
	private TRight _right;
}
