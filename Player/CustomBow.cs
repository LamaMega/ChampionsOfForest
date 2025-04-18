﻿using BuilderCore;

using ChampionsOfForest.Player;

using TheForest.Items.World;

using UnityEngine;

namespace ChampionsOfForest
{
	public class CustomBowBase : MonoBehaviour
	{
		public static GameObject baseBow;
		public static BowController baseBowC;

		private void Initialize()
		{
			if (baseBow == null)
			{
				baseBow = gameObject;
				baseBowC = gameObject.GetComponent<BowController>();
				var greatbow = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
				greatbow.AddComponent<GreatBow>();
			}
		}

		private void OnEnable()
		{
			Initialize();
		}
	}

	public class GreatBow : MonoBehaviour
	{
		public static bool isEnabled;
		public static GameObject instance;
		private BowController bc;
		private GameObject model = null;

		private void OnEnable()
		{
			isEnabled = true;
			if (BoltNetwork.isRunning)
			{
				using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
				{
					using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
					{
						w.Write(28);
						w.Write(ModReferences.ThisPlayerID);
						w.Write((int)ItemDefinition.ItemSubtype.Greatbow);
						w.Close();
					}
					Network.NetworkManager.SendLine(answerStream.ToArray(), Network.NetworkManager.Target.Others);
					answerStream.Close();
				}
			}
			PlayerInventoryMod.ToEquipWeaponType = ItemDefinition.ItemSubtype.None;
		}

		private void OnDisable()
		{
			isEnabled = false;
			if (BoltNetwork.isRunning)
			{
				using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
				{
					using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
					{
						w.Write(28);
						w.Write(ModReferences.ThisPlayerID);
						w.Write((int)ItemDefinition.ItemSubtype.None);
						w.Close();
					}
					Network.NetworkManager.SendLine(answerStream.ToArray(), Network.NetworkManager.Target.Others);
					answerStream.Close();
				}
			}
		}

		private void Start()
		{
			bc = GetComponent<BowController>();
			instance = gameObject;
			try
			{
				var bow = transform.Find("Bow");
				if (bow == null)
					ModAPI.Log.Write("Bow is null");
				Destroy(transform.Find("TapedLight").gameObject);
				//if (modelPrefab == null) modelPrefab = Res.ResourceLoader.GetAssetBundle(2004).LoadAsset<GameObject>("firebow.prefab");
				//model = Instantiate(modelPrefab);
				model = new GameObject();
				model.transform.parent = bow.parent;
				model.transform.localScale = Vector3.one * 1.4f;
				model.transform.localPosition = new Vector3(0, 0, 0.3f);
				model.transform.localRotation = Quaternion.Euler(0, 180, 0);

				model.AddComponent<MeshFilter>().mesh = Res.ResourceLoader.instance.LoadedMeshes[167];
				model.AddComponent<MeshRenderer>().material =
				Core.CreateMaterial(new BuildingData()
				{
					BumpMap = Res.ResourceLoader.GetTexture(168),
					BumpScale = 1.2f,
					Metalic = 0.84f,
					Smoothness = 0.7f,
					MainTexture = Res.ResourceLoader.GetTexture(169),
				});

				Destroy(bow.gameObject);
				//model.transform.localScale *= 1.1f;
			}
			catch (System.Exception e)
			{
				ModAPI.Log.Write(e.Message);
			}
		}
	}
}