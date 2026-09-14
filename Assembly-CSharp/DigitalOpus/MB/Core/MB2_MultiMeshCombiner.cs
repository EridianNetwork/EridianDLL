using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	// Token: 0x02000AEF RID: 2799
	[Serializable]
	public class MB2_MultiMeshCombiner
	{
		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06004BF8 RID: 19448 RVA: 0x00031940 File Offset: 0x0002FB40
		// (set) Token: 0x06004BF9 RID: 19449 RVA: 0x00031948 File Offset: 0x0002FB48
		public int maxVertsInMesh
		{
			get
			{
				return this._maxVertsInMesh;
			}
			set
			{
				if (this.obj2MeshCombinerMap.Count > 0)
				{
					global::UnityEngine.Debug.LogError("Can't set the max verts in meshes once there are objects in the mesh.");
					return;
				}
				this._maxVertsInMesh = value;
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06004BFA RID: 19450 RVA: 0x0003196A File Offset: 0x0002FB6A
		// (set) Token: 0x06004BFB RID: 19451 RVA: 0x00031972 File Offset: 0x0002FB72
		public string name
		{
			get
			{
				return this.__name;
			}
			set
			{
				this.__name = value;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06004BFC RID: 19452 RVA: 0x0003197B File Offset: 0x0002FB7B
		// (set) Token: 0x06004BFD RID: 19453 RVA: 0x00031983 File Offset: 0x0002FB83
		public MB2_TextureBakeResults textureBakeResults
		{
			get
			{
				return this.__textureBakeResults;
			}
			set
			{
				this.__textureBakeResults = value;
			}
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06004BFE RID: 19454 RVA: 0x0003198C File Offset: 0x0002FB8C
		// (set) Token: 0x06004BFF RID: 19455 RVA: 0x00031994 File Offset: 0x0002FB94
		public GameObject resultSceneObject
		{
			get
			{
				return this.__resultSceneObject;
			}
			set
			{
				this.__resultSceneObject = value;
			}
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06004C00 RID: 19456 RVA: 0x0003199D File Offset: 0x0002FB9D
		// (set) Token: 0x06004C01 RID: 19457 RVA: 0x000319A5 File Offset: 0x0002FBA5
		public MB_RenderType renderType
		{
			get
			{
				return this.__renderType;
			}
			set
			{
				this.__renderType = value;
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06004C02 RID: 19458 RVA: 0x000319AE File Offset: 0x0002FBAE
		// (set) Token: 0x06004C03 RID: 19459 RVA: 0x000319B6 File Offset: 0x0002FBB6
		public MB2_OutputOptions outputOption
		{
			get
			{
				return this.__outputOption;
			}
			set
			{
				this.__outputOption = value;
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06004C04 RID: 19460 RVA: 0x000319BF File Offset: 0x0002FBBF
		// (set) Token: 0x06004C05 RID: 19461 RVA: 0x000319C7 File Offset: 0x0002FBC7
		public MB2_LightmapOptions lightmapOption
		{
			get
			{
				return this.__lightmapOption;
			}
			set
			{
				if (this.obj2MeshCombinerMap.Count > 0 && this.__lightmapOption != value)
				{
					global::UnityEngine.Debug.LogWarning("Can't change lightmap option once objects are in the combined mesh.");
				}
				this.__lightmapOption = value;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06004C06 RID: 19462 RVA: 0x000319F1 File Offset: 0x0002FBF1
		// (set) Token: 0x06004C07 RID: 19463 RVA: 0x000319F9 File Offset: 0x0002FBF9
		public bool doNorm
		{
			get
			{
				return this.__doNorm;
			}
			set
			{
				this.__doNorm = value;
			}
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06004C08 RID: 19464 RVA: 0x00031A02 File Offset: 0x0002FC02
		// (set) Token: 0x06004C09 RID: 19465 RVA: 0x00031A0A File Offset: 0x0002FC0A
		public bool doTan
		{
			get
			{
				return this.__doTan;
			}
			set
			{
				this.__doTan = value;
			}
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06004C0A RID: 19466 RVA: 0x00031A13 File Offset: 0x0002FC13
		// (set) Token: 0x06004C0B RID: 19467 RVA: 0x00031A1B File Offset: 0x0002FC1B
		public bool doCol
		{
			get
			{
				return this.__doCol;
			}
			set
			{
				this.__doCol = value;
			}
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06004C0C RID: 19468 RVA: 0x00031A24 File Offset: 0x0002FC24
		// (set) Token: 0x06004C0D RID: 19469 RVA: 0x00031A2C File Offset: 0x0002FC2C
		public bool doUV
		{
			get
			{
				return this.__doUV;
			}
			set
			{
				this.__doUV = value;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06004C0E RID: 19470 RVA: 0x00031A35 File Offset: 0x0002FC35
		// (set) Token: 0x06004C0F RID: 19471 RVA: 0x00031A3D File Offset: 0x0002FC3D
		public bool doUV1
		{
			get
			{
				return this.__doUV1;
			}
			set
			{
				this.__doUV1 = value;
			}
		}

		// Token: 0x06004C10 RID: 19472 RVA: 0x00031A46 File Offset: 0x0002FC46
		public int GetNumObjectsInCombined()
		{
			return this.obj2MeshCombinerMap.Count;
		}

		// Token: 0x06004C11 RID: 19473 RVA: 0x0013D300 File Offset: 0x0013B500
		public int GetNumVerticesFor(GameObject go)
		{
			MB2_MultiMeshCombiner.CombinedMesh combinedMesh = null;
			if (this.obj2MeshCombinerMap.TryGetValue(go, out combinedMesh))
			{
				return combinedMesh.combinedMesh.GetNumVerticesFor(go);
			}
			return -1;
		}

		// Token: 0x06004C12 RID: 19474 RVA: 0x0013D330 File Offset: 0x0013B530
		public List<GameObject> GetObjectsInCombined()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				list.AddRange(this.meshCombiners[i].combinedMesh.GetObjectsInCombined());
			}
			return list;
		}

		// Token: 0x06004C13 RID: 19475 RVA: 0x00031A53 File Offset: 0x0002FC53
		public int GetLightmapIndex()
		{
			if (this.meshCombiners.Count > 0)
			{
				return this.meshCombiners[0].combinedMesh.GetLightmapIndex();
			}
			return -1;
		}

		// Token: 0x06004C14 RID: 19476 RVA: 0x00031A7B File Offset: 0x0002FC7B
		public bool CombinedMeshContains(GameObject go)
		{
			return this.obj2MeshCombinerMap.ContainsKey(go);
		}

		// Token: 0x06004C15 RID: 19477 RVA: 0x0013D378 File Offset: 0x0013B578
		private bool _validateTextureBakeResults()
		{
			if (this.textureBakeResults == null)
			{
				global::UnityEngine.Debug.LogError("Material Bake Results is null. Can't combine meshes.");
				return false;
			}
			if (this.textureBakeResults.materials != null && this.textureBakeResults.materials.Length != 0)
			{
				if (this.textureBakeResults.doMultiMaterial)
				{
					if (this.textureBakeResults.resultMaterials == null || this.textureBakeResults.resultMaterials.Length == 0)
					{
						global::UnityEngine.Debug.LogError("Material Bake Results has no result materials. Try baking materials. Can't combine meshes.");
						return false;
					}
				}
				else if (this.textureBakeResults.resultMaterial == null)
				{
					global::UnityEngine.Debug.LogError("Material Bake Results has no result material. Try baking materials. Can't combine meshes.");
					return false;
				}
				return true;
			}
			global::UnityEngine.Debug.LogError("Material Bake Results has no materials in material to uvRect map. Try baking materials. Can't combine meshes.");
			return false;
		}

		// Token: 0x06004C16 RID: 19478 RVA: 0x0013D41C File Offset: 0x0013B61C
		public void Apply()
		{
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				if (this.meshCombiners[i].isDirty)
				{
					this.meshCombiners[i].combinedMesh.Apply();
					this.meshCombiners[i].isDirty = false;
				}
			}
		}

		// Token: 0x06004C17 RID: 19479 RVA: 0x0013D47C File Offset: 0x0013B67C
		public void Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool colors, bool uv1, bool uv2, bool bones = false)
		{
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				if (this.meshCombiners[i].isDirty)
				{
					this.meshCombiners[i].combinedMesh.Apply(triangles, vertices, normals, tangents, uvs, colors, uv1, uv2, bones);
					this.meshCombiners[i].isDirty = false;
				}
			}
		}

		// Token: 0x06004C18 RID: 19480 RVA: 0x0013D4EC File Offset: 0x0013B6EC
		public void UpdateGameObjects(GameObject[] gos, bool recalcBounds = true)
		{
			if (gos == null)
			{
				global::UnityEngine.Debug.LogError("list of game objects cannot be null");
				return;
			}
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				this.meshCombiners[i].gosToUpdate.Clear();
			}
			for (int j = 0; j < gos.Length; j++)
			{
				MB2_MultiMeshCombiner.CombinedMesh combinedMesh = null;
				this.obj2MeshCombinerMap.TryGetValue(gos[j], out combinedMesh);
				if (combinedMesh != null)
				{
					combinedMesh.gosToUpdate.Add(gos[j]);
				}
				else
				{
					global::UnityEngine.Debug.LogWarning("Object " + gos[j] + " is not in the combined mesh.");
				}
			}
			for (int k = 0; k < this.meshCombiners.Count; k++)
			{
				if (this.meshCombiners[k].gosToUpdate.Count > 0)
				{
					GameObject[] array = this.meshCombiners[k].gosToUpdate.ToArray();
					this.meshCombiners[k].combinedMesh.UpdateGameObjects(array, recalcBounds);
				}
			}
		}

		// Token: 0x06004C19 RID: 19481 RVA: 0x00031A89 File Offset: 0x0002FC89
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs)
		{
			return this.AddDeleteGameObjects(gos, deleteGOs, true, this.textureBakeResults.fixOutOfBoundsUVs);
		}

		// Token: 0x06004C1A RID: 19482 RVA: 0x00031A9F File Offset: 0x0002FC9F
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
		{
			return this.AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource, this.textureBakeResults.fixOutOfBoundsUVs);
		}

		// Token: 0x06004C1B RID: 19483 RVA: 0x0013D5E0 File Offset: 0x0013B7E0
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			if (!this._validate(gos, deleteGOs))
			{
				return null;
			}
			if (MB2_MultiMeshCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[] { "AddDeleteGameObjects adding:", gos.Length, " deleting:", deleteGOs.Length, " disableRendererInSource:", disableRendererInSource, " fixOutOfBoundUVs:", fixOutOfBoundUVs }));
			}
			this._distributeAmongBakers(gos, deleteGOs);
			return this._bakeStep1(gos, deleteGOs, disableRendererInSource, fixOutOfBoundUVs);
		}

		// Token: 0x06004C1C RID: 19484 RVA: 0x0013D66C File Offset: 0x0013B86C
		private bool _validate(GameObject[] gos, GameObject[] deleteGOs)
		{
			this._validateTextureBakeResults();
			if (gos != null)
			{
				for (int i = 0; i < gos.Length; i++)
				{
					if (gos[i] == null)
					{
						global::UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
						return false;
					}
					for (int j = i + 1; j < gos.Length; j++)
					{
						if (gos[i] == gos[j])
						{
							global::UnityEngine.Debug.LogError("GameObject " + gos[i] + "appears twice in list of game objects to add");
							return false;
						}
					}
					if (this.obj2MeshCombinerMap.ContainsKey(gos[i]))
					{
						bool flag = false;
						if (deleteGOs != null)
						{
							for (int k = 0; k < deleteGOs.Length; k++)
							{
								if (deleteGOs[k] == gos[i])
								{
									flag = true;
								}
							}
						}
						if (!flag)
						{
							global::UnityEngine.Debug.LogError("GameObject " + gos[i] + " is already in the combined mesh");
							return false;
						}
					}
				}
			}
			if (deleteGOs != null)
			{
				for (int l = 0; l < deleteGOs.Length; l++)
				{
					for (int m = l + 1; m < deleteGOs.Length; m++)
					{
						if (deleteGOs[l] == deleteGOs[m] && deleteGOs[l] != null)
						{
							global::UnityEngine.Debug.LogError("GameObject " + deleteGOs[l] + "appears twice in list of game objects to delete");
							return false;
						}
					}
					if (!this.obj2MeshCombinerMap.ContainsKey(deleteGOs[l]))
					{
						global::UnityEngine.Debug.LogWarning("GameObject " + deleteGOs[l] + " on the list of objects to delete is not in the combined mesh.");
					}
				}
			}
			return true;
		}

		// Token: 0x06004C1D RID: 19485 RVA: 0x0013D7D4 File Offset: 0x0013B9D4
	private void _distributeAmongBakers(GameObject[] gos, GameObject[] deleteGOs)
	{
		if (gos == null)
		{
			gos = empty;
		}
		if (deleteGOs == null)
		{
			deleteGOs = empty;
		}
		if (resultSceneObject == null)
		{
			resultSceneObject = new GameObject("CombinedMesh-" + name);
		}
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].extraSpace = _maxVertsInMesh - meshCombiners[i].combinedMesh.GetMesh().vertexCount;
		}
		for (int j = 0; j < deleteGOs.Length; j++)
		{
			CombinedMesh value = null;
			if (obj2MeshCombinerMap.TryGetValue(deleteGOs[j], out value))
			{
				if (VERBOSE)
				{
					UnityEngine.Debug.Log(string.Concat("Removing ", deleteGOs[j], " from meshCombiner ", meshCombiners.IndexOf(value)));
				}
				value.numVertsInListToDelete += value.combinedMesh.GetNumVerticesFor(deleteGOs[j]);
				value.gosToDelete.Add(deleteGOs[j]);
			}
			else
			{
				UnityEngine.Debug.LogWarning(string.Concat("Object ", deleteGOs[j], " in the list of objects to delete is not in the combined mesh."));
			}
		}
		for (int k = 0; k < gos.Length; k++)
		{
			GameObject gameObject = gos[k];
			int vertexCount = MB_Utility.GetMesh(gameObject).vertexCount;
			CombinedMesh combinedMesh = null;
			for (int l = 0; l < meshCombiners.Count; l++)
			{
				if (meshCombiners[l].extraSpace + meshCombiners[l].numVertsInListToDelete - meshCombiners[l].numVertsInListToAdd > vertexCount)
				{
					combinedMesh = meshCombiners[l];
					if (VERBOSE)
					{
						UnityEngine.Debug.Log(string.Concat("Added ", gos[k], " to combinedMesh ", l));
					}
					break;
				}
			}
			if (combinedMesh == null)
			{
				combinedMesh = new CombinedMesh(maxVertsInMesh);
				_setMBValues(combinedMesh.combinedMesh);
				meshCombiners.Add(combinedMesh);
				if (VERBOSE)
				{
					UnityEngine.Debug.Log("Created new combinedMesh");
				}
			}
			combinedMesh.gosToAdd.Add(gameObject);
			combinedMesh.numVertsInListToAdd += vertexCount;
		}
	}
		// Token: 0x06004C1E RID: 19486 RVA: 0x0013DA38 File Offset: 0x0013BC38
		private Mesh _bakeStep1(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				MB2_MultiMeshCombiner.CombinedMesh combinedMesh = this.meshCombiners[i];
				if (combinedMesh.combinedMesh.targetRenderer == null)
				{
					GameObject gameObject = combinedMesh.combinedMesh.buildSceneMeshObject(this.resultSceneObject, combinedMesh.combinedMesh.GetMesh(), true);
					combinedMesh.combinedMesh.targetRenderer = gameObject.GetComponent<Renderer>();
				}
				else if (combinedMesh.combinedMesh.targetRenderer.transform.parent != this.resultSceneObject.transform)
				{
					global::UnityEngine.Debug.LogError("targetRender objects must be children of resultSceneObject");
					return null;
				}
				if (combinedMesh.gosToAdd.Count > 0 || combinedMesh.gosToDelete.Count > 0)
				{
					combinedMesh.combinedMesh.AddDeleteGameObjects(combinedMesh.gosToAdd.ToArray(), combinedMesh.gosToDelete.ToArray(), disableRendererInSource, this.textureBakeResults.fixOutOfBoundsUVs);
				}
				Renderer targetRenderer = combinedMesh.combinedMesh.targetRenderer;
				if (targetRenderer is MeshRenderer)
				{
					MeshFilter component = targetRenderer.gameObject.GetComponent<MeshFilter>();
					component.sharedMesh = combinedMesh.combinedMesh.GetMesh();
				}
				else
				{
					SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
					skinnedMeshRenderer.sharedMesh = combinedMesh.combinedMesh.GetMesh();
				}
			}
			for (int j = 0; j < this.meshCombiners.Count; j++)
			{
				MB2_MultiMeshCombiner.CombinedMesh combinedMesh2 = this.meshCombiners[j];
				for (int k = 0; k < combinedMesh2.gosToDelete.Count; k++)
				{
					this.obj2MeshCombinerMap.Remove(combinedMesh2.gosToDelete[k]);
					if (!(combinedMesh2.gosToDelete[k] != null))
					{
					}
				}
			}
			for (int l = 0; l < this.meshCombiners.Count; l++)
			{
				MB2_MultiMeshCombiner.CombinedMesh combinedMesh3 = this.meshCombiners[l];
				for (int m = 0; m < combinedMesh3.gosToAdd.Count; m++)
				{
					this.obj2MeshCombinerMap.Add(combinedMesh3.gosToAdd[m], combinedMesh3);
				}
				if (combinedMesh3.gosToAdd.Count > 0 || combinedMesh3.gosToDelete.Count > 0)
				{
					combinedMesh3.gosToDelete.Clear();
					combinedMesh3.gosToAdd.Clear();
					combinedMesh3.numVertsInListToDelete = 0;
					combinedMesh3.numVertsInListToAdd = 0;
					combinedMesh3.isDirty = true;
				}
			}
			if (MB2_MultiMeshCombiner.VERBOSE)
			{
				string text = "Meshes in combined:";
				for (int n = 0; n < this.meshCombiners.Count; n++)
				{
					string text2 = text;
					text = string.Concat(new object[]
					{
						text2,
						" mesh",
						n,
						"(",
						this.meshCombiners[n].combinedMesh.GetObjectsInCombined().Count,
						")\n"
					});
				}
				text = text + "children in result: " + this.resultSceneObject.transform.childCount;
				global::UnityEngine.Debug.Log(text);
			}
			if (this.meshCombiners.Count > 0)
			{
				return this.meshCombiners[0].combinedMesh.GetMesh();
			}
			return null;
		}

		// Token: 0x06004C1F RID: 19487 RVA: 0x00031AB5 File Offset: 0x0002FCB5
		public void ClearMesh()
		{
			this.DestroyMesh();
		}

		// Token: 0x06004C20 RID: 19488 RVA: 0x0013DD80 File Offset: 0x0013BF80
		public void DestroyMesh()
		{
			for (int i = 0; i < this.meshCombiners.Count; i++)
			{
				if (this.meshCombiners[i].combinedMesh.targetRenderer != null)
				{
					global::UnityEngine.Object.Destroy(this.meshCombiners[i].combinedMesh.targetRenderer.gameObject);
				}
				this.meshCombiners[i].combinedMesh.ClearMesh();
			}
			this.obj2MeshCombinerMap.Clear();
			this.meshCombiners.Clear();
		}

		// Token: 0x06004C21 RID: 19489 RVA: 0x0013DE10 File Offset: 0x0013C010
		private void _setMBValues(MB2_MeshCombiner targ)
		{
			targ.renderType = this.renderType;
			targ.outputOption = MB2_OutputOptions.bakeIntoSceneObject;
			targ.lightmapOption = this.lightmapOption;
			targ.textureBakeResults = this.textureBakeResults;
			targ.doNorm = this.doNorm;
			targ.doTan = this.doTan;
			targ.doCol = this.doCol;
			targ.doUV = this.doUV;
			targ.doUV1 = this.doUV1;
		}

		// Token: 0x06004C22 RID: 19490 RVA: 0x0000311B File Offset: 0x0000131B
		public void SaveMeshsToAssetDatabase(string folderPath, string newFileNameBase)
		{
		}

		// Token: 0x06004C23 RID: 19491 RVA: 0x0000311B File Offset: 0x0000131B
		public void RebuildPrefab(GameObject prefabRoot)
		{
		}

		// Token: 0x04003760 RID: 14176
		private static bool VERBOSE = false;

		// Token: 0x04003761 RID: 14177
		private static GameObject[] empty = new GameObject[0];

		// Token: 0x04003762 RID: 14178
		private Dictionary<GameObject, MB2_MultiMeshCombiner.CombinedMesh> obj2MeshCombinerMap = new Dictionary<GameObject, MB2_MultiMeshCombiner.CombinedMesh>();

		// Token: 0x04003763 RID: 14179
		private List<MB2_MultiMeshCombiner.CombinedMesh> meshCombiners = new List<MB2_MultiMeshCombiner.CombinedMesh>();

		// Token: 0x04003764 RID: 14180
		[SerializeField]
		private int _maxVertsInMesh = 65535;

		// Token: 0x04003765 RID: 14181
		[SerializeField]
		private string __name;

		// Token: 0x04003766 RID: 14182
		[SerializeField]
		private MB2_TextureBakeResults __textureBakeResults;

		// Token: 0x04003767 RID: 14183
		[SerializeField]
		private GameObject __resultSceneObject;

		// Token: 0x04003768 RID: 14184
		[SerializeField]
		private MB_RenderType __renderType;

		// Token: 0x04003769 RID: 14185
		[SerializeField]
		private MB2_OutputOptions __outputOption;

		// Token: 0x0400376A RID: 14186
		[SerializeField]
		private MB2_LightmapOptions __lightmapOption;

		// Token: 0x0400376B RID: 14187
		[SerializeField]
		private bool __doNorm;

		// Token: 0x0400376C RID: 14188
		[SerializeField]
		private bool __doTan;

		// Token: 0x0400376D RID: 14189
		[SerializeField]
		private bool __doCol;

		// Token: 0x0400376E RID: 14190
		[SerializeField]
		private bool __doUV;

		// Token: 0x0400376F RID: 14191
		[SerializeField]
		private bool __doUV1;

		// Token: 0x02000AF0 RID: 2800
		[Serializable]
		public class CombinedMesh
		{
			// Token: 0x06004C24 RID: 19492 RVA: 0x0013DE84 File Offset: 0x0013C084
			public CombinedMesh(int maxNumVertsInMesh)
			{
				this.combinedMesh = new MB2_MeshCombiner();
				this.extraSpace = maxNumVertsInMesh;
				this.numVertsInListToDelete = 0;
				this.numVertsInListToAdd = 0;
				this.gosToAdd = new List<GameObject>();
				this.gosToDelete = new List<GameObject>();
				this.gosToUpdate = new List<GameObject>();
			}

			// Token: 0x06004C25 RID: 19493 RVA: 0x0013DEE0 File Offset: 0x0013C0E0
			public bool isEmpty()
			{
				List<GameObject> list = new List<GameObject>();
				list.AddRange(this.combinedMesh.GetObjectsInCombined());
				for (int i = 0; i < this.gosToDelete.Count; i++)
				{
					list.Remove(this.gosToDelete[i]);
				}
				return list.Count == 0;
			}

			// Token: 0x04003770 RID: 14192
			public MB2_MeshCombiner combinedMesh;

			// Token: 0x04003771 RID: 14193
			public int extraSpace = -1;

			// Token: 0x04003772 RID: 14194
			public int numVertsInListToDelete;

			// Token: 0x04003773 RID: 14195
			public int numVertsInListToAdd;

			// Token: 0x04003774 RID: 14196
			public List<GameObject> gosToAdd;

			// Token: 0x04003775 RID: 14197
			public List<GameObject> gosToDelete;

			// Token: 0x04003776 RID: 14198
			public List<GameObject> gosToUpdate;

			// Token: 0x04003777 RID: 14199
			public bool isDirty;
		}
	}
}
