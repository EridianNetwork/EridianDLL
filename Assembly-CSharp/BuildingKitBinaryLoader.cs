using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns0;
using UnityEngine;

// Token: 0x0200014B RID: 331
public class BuildingKitBinaryLoader : BuildingKitLoader
{
	// Token: 0x06000794 RID: 1940 RVA: 0x00007F62 File Offset: 0x00006162
	public BuildingKitBinaryLoader(string string_0)
	{
		this.str = string_0;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x00057924 File Offset: 0x00055B24
	protected override object vmethod_1()
	{
		string text = this.str;
		TextAsset textAsset = ResourcesLoader.smethod_0(text) as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		ComposableCharacter composableCharacter;
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			composableCharacter = new ComposableCharacter();
			composableCharacter.bkID = binaryReader.ReadUInt32();
			int num = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sTypeName = Encoding.Unicode.GetString(binaryReader.ReadBytes(num));
			num = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sCharacterName = Encoding.Unicode.GetString(binaryReader.ReadBytes(num));
			num = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sSkeletonName = Encoding.Unicode.GetString(binaryReader.ReadBytes(num));
			composableCharacter.m_aParts = new List<ComposablePart>(binaryReader.ReadInt32());
			for (int i = 0; i < composableCharacter.m_aParts.Capacity; i++)
			{
				this.method_5(binaryReader, composableCharacter.m_aParts);
			}
			if (MonoSingleton<AppManager>.Instance != null && MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
			{
				composableCharacter.m_aParts.Clear();
			}
			stream.Dispose();
			binaryReader.Close();
		}
		ResourcesLoader.smethod_6(textAsset);
		return composableCharacter;
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x00007F71 File Offset: 0x00006171
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.str);
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00057A68 File Offset: 0x00055C68
	private void method_5(BinaryReader binaryReader_0, List<ComposablePart> list_0)
	{
		int num = binaryReader_0.ReadInt32() * 2;
		ComposablePart composablePart = new ComposablePart(Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num)));
		composablePart.m_aFbxs = new List<ComposableFBX>(binaryReader_0.ReadInt32());
		for (int i = 0; i < composablePart.m_aFbxs.Capacity; i++)
		{
			this.method_6(binaryReader_0, composablePart.m_aFbxs);
		}
		list_0.Add(composablePart);
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x00057AD0 File Offset: 0x00055CD0
	private void method_6(BinaryReader binaryReader_0, List<ComposableFBX> list_0)
	{
		int num = binaryReader_0.ReadInt32() * 2;
		ComposableFBX composableFBX = new ComposableFBX();
		composableFBX.m_sFileName = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		composableFBX.m_aMaterials = new List<ComposableMaterial>(binaryReader_0.ReadInt32());
		for (int i = 0; i < composableFBX.m_aMaterials.Capacity; i++)
		{
			this.method_7(binaryReader_0, composableFBX.m_aMaterials);
		}
		list_0.Add(composableFBX);
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x00057B40 File Offset: 0x00055D40
	private void method_7(BinaryReader binaryReader_0, List<ComposableMaterial> list_0)
	{
		int num = binaryReader_0.ReadInt32() * 2;
		ComposableMaterial composableMaterial = new ComposableMaterial();
		composableMaterial.m_sMaterial = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		num = binaryReader_0.ReadInt32() * 2;
		composableMaterial.m_sShader = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		composableMaterial.m_sTexName = new List<string>(binaryReader_0.ReadInt32());
		for (int i = 0; i < composableMaterial.m_sTexName.Capacity; i++)
		{
			num = binaryReader_0.ReadInt32() * 2;
			composableMaterial.m_sTexName.Add(Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num)));
		}
		composableMaterial.m_sTexFileName = new List<string>(binaryReader_0.ReadInt32());
		for (int j = 0; j < composableMaterial.m_sTexFileName.Capacity; j++)
		{
			num = binaryReader_0.ReadInt32() * 2;
			composableMaterial.m_sTexFileName.Add(Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num)));
		}
		composableMaterial.m_sShaderProperties = new List<ShaderProperty>(binaryReader_0.ReadInt32());
		for (int k = 0; k < composableMaterial.m_sShaderProperties.Capacity; k++)
		{
			this.method_8(binaryReader_0, composableMaterial.m_sShaderProperties);
		}
		list_0.Add(composableMaterial);
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x00057C6C File Offset: 0x00055E6C
	private void method_8(BinaryReader binaryReader_0, List<ShaderProperty> list_0)
	{
		ShaderProperty shaderProperty = new ShaderProperty();
		shaderProperty.mType = (ShaderPropertyType)binaryReader_0.ReadByte();
		int num = binaryReader_0.ReadInt32() * 2;
		shaderProperty.mName = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		num = binaryReader_0.ReadInt32() * 2;
		shaderProperty.mDesc = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		num = binaryReader_0.ReadInt32() * 2;
		shaderProperty.mValue = Encoding.Unicode.GetString(binaryReader_0.ReadBytes(num));
		list_0.Add(shaderProperty);
	}

	// Token: 0x040006C2 RID: 1730
	private string str;
}
