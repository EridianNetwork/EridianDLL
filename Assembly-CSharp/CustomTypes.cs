using System;
using System.IO;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000B03 RID: 2819
internal static class CustomTypes
{
	// Token: 0x06004C7B RID: 19579 RVA: 0x001415B8 File Offset: 0x0013F7B8
	internal static void smethod_0()
	{
		PhotonPeer.RegisterType(typeof(Vector2), 87, new SerializeMethod(CustomTypes.smethod_5), new DeserializeMethod(CustomTypes.smethod_6));
		PhotonPeer.RegisterType(typeof(Vector3), 86, new SerializeMethod(CustomTypes.smethod_3), new DeserializeMethod(CustomTypes.smethod_4));
		PhotonPeer.RegisterType(typeof(Transform), 84, new SerializeMethod(CustomTypes.smethod_1), new DeserializeMethod(CustomTypes.smethod_2));
		PhotonPeer.RegisterType(typeof(Quaternion), 81, new SerializeMethod(CustomTypes.smethod_7), new DeserializeMethod(CustomTypes.smethod_8));
		PhotonPeer.RegisterType(typeof(PhotonPlayer), 80, new SerializeMethod(CustomTypes.smethod_9), new DeserializeMethod(CustomTypes.smethod_10));
	}

	// Token: 0x06004C7C RID: 19580 RVA: 0x00141698 File Offset: 0x0013F898
	private static byte[] smethod_1(object object_0)
	{
		Transform transform = (Transform)object_0;
		return Protocol.Serialize(new Vector3[] { transform.position, transform.eulerAngles });
	}

	// Token: 0x06004C7D RID: 19581 RVA: 0x001416E0 File Offset: 0x0013F8E0
	private static object smethod_2(byte[] byte_0)
	{
		return Protocol.Deserialize(byte_0);
	}

	// Token: 0x06004C7E RID: 19582 RVA: 0x001416F8 File Offset: 0x0013F8F8
	private static byte[] smethod_3(object object_0)
	{
		Vector3 vector = (Vector3)object_0;
		int num = 0;
		byte[] array = new byte[12];
		Protocol.Serialize(vector.x, array, ref num);
		Protocol.Serialize(vector.y, array, ref num);
		Protocol.Serialize(vector.z, array, ref num);
		return array;
	}

	// Token: 0x06004C7F RID: 19583 RVA: 0x00141744 File Offset: 0x0013F944
	private static object smethod_4(byte[] byte_0)
	{
		Vector3 vector = default(Vector3);
		int num = 0;
		Protocol.Deserialize(out vector.x, byte_0, ref num);
		Protocol.Deserialize(out vector.y, byte_0, ref num);
		Protocol.Deserialize(out vector.z, byte_0, ref num);
		return vector;
	}

	// Token: 0x06004C80 RID: 19584 RVA: 0x00141790 File Offset: 0x0013F990
	private static byte[] smethod_5(object object_0)
	{
		Vector2 vector = (Vector2)object_0;
		MemoryStream memoryStream = new MemoryStream(8);
		memoryStream.Write(BitConverter.GetBytes(vector.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.y), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x06004C81 RID: 19585 RVA: 0x001417DC File Offset: 0x0013F9DC
	private static object smethod_6(byte[] byte_0)
	{
		return new Vector2
		{
			x = BitConverter.ToSingle(byte_0, 0),
			y = BitConverter.ToSingle(byte_0, 4)
		};
	}

	// Token: 0x06004C82 RID: 19586 RVA: 0x00141814 File Offset: 0x0013FA14
	private static byte[] smethod_7(object object_0)
	{
		Quaternion quaternion = (Quaternion)object_0;
		MemoryStream memoryStream = new MemoryStream(16);
		memoryStream.Write(BitConverter.GetBytes(quaternion.w), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.y), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.z), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x06004C83 RID: 19587 RVA: 0x00141888 File Offset: 0x0013FA88
	private static object smethod_8(byte[] byte_0)
	{
		return new Quaternion
		{
			w = BitConverter.ToSingle(byte_0, 0),
			x = BitConverter.ToSingle(byte_0, 4),
			y = BitConverter.ToSingle(byte_0, 8),
			z = BitConverter.ToSingle(byte_0, 12)
		};
	}

	// Token: 0x06004C84 RID: 19588 RVA: 0x001418DC File Offset: 0x0013FADC
	private static byte[] smethod_9(object object_0)
	{
		int int32_ = ((PhotonPlayer)object_0).ActorId;
		return BitConverter.GetBytes(int32_);
	}

	// Token: 0x06004C85 RID: 19589 RVA: 0x001418FC File Offset: 0x0013FAFC
	private static object smethod_10(byte[] byte_0)
	{
		int num = BitConverter.ToInt32(byte_0, 0);
		if (PhotonNetwork.networkingPeer.mActors.ContainsKey(num))
		{
			return PhotonNetwork.networkingPeer.mActors[num];
		}
		return null;
	}
}
