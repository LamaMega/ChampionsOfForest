﻿using System.Collections.Generic;

using BuilderCore;

using UnityEngine;

namespace ChampionsOfForest
{
	public static class PickUpManager
	{
		public static Dictionary<ulong, ItemPickUp> PickUps = new Dictionary<ulong, ItemPickUp>();

		private static Material pickupMaterial;
		private static Material Heart_pickupMaterial;
		private static GameObject chestPrefab;

		/// <summary>
		/// spawns a pickup for the client.
		/// </summary>
		public static void SpawnPickUp(Item item, Vector3 pos, int amount, ulong id, ItemPickUp.DropSource dropSource)
		{
			try
			{
				GameObject spawn = GameObject.CreatePrimitive(PrimitiveType.Cube);

				if (!ModSettings.IsDedicated)
				{
					spawn.AddComponent<Rigidbody>().mass = 5;
					spawn.transform.position = pos;
					MeshRenderer renderer = spawn.GetComponent<MeshRenderer>();
					MeshFilter filter = spawn.GetComponent<MeshFilter>();

					if (pickupMaterial == null)
					{
						pickupMaterial = Core.CreateMaterial(new BuildingData() { MainColor = Color.gray, Metalic = 0.65f, Smoothness = 0.8f });
						Heart_pickupMaterial = Core.CreateMaterial(new BuildingData() { MainColor = Color.white, Metalic = 0.1f, Smoothness = 0.4f, MainTexture = Res.ResourceLoader.GetTexture(103), BumpMap = Res.ResourceLoader.GetTexture(104) });
					}

					var col = spawn.GetComponent<BoxCollider>();

					renderer.material = pickupMaterial;

					switch (item.type)
					{
						case ItemDefinition.ItemType.Shield:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[49];

							break;

						case ItemDefinition.ItemType.Quiver:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[116];

							break;

						case ItemDefinition.ItemType.SpellScroll:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[124];

							break;

						case ItemDefinition.ItemType.Weapon:

							if (item.subtype == ItemDefinition.ItemSubtype.GreatSword)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[52];
							}
							else if (item.subtype == ItemDefinition.ItemSubtype.LongSword)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[51];
							}
							else if (item.subtype == ItemDefinition.ItemSubtype.Hammer)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[108];
								spawn.transform.localScale *= 1.2f;
							}
							else if (item.subtype == ItemDefinition.ItemSubtype.Axe)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[2001];
								renderer.materials = new Material[] { pickupMaterial, pickupMaterial };
								spawn.transform.localScale *= 1.12f;
							}
							else if (item.subtype == ItemDefinition.ItemSubtype.Greatbow)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[167];
								spawn.transform.localScale *= 1.1f;
							}
							else if (item.subtype == ItemDefinition.ItemSubtype.Polearm)
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[175];
								spawn.transform.localScale *= 0.60f;
							}

							break;

						case ItemDefinition.ItemType.Other:
							if (item.name == "Greater Mutated Heart")
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[102];
								renderer.material = Heart_pickupMaterial;
								spawn.transform.localScale *= 3.5f;
							}
							else if (item.name == "Lesser Mutated Heart")
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[102];
								renderer.material = Heart_pickupMaterial;
								spawn.transform.localScale *= 2f;
							}
							else if (item.name == "Heart of Purity")
							{
								filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[102];
								renderer.material = Heart_pickupMaterial;
								spawn.transform.localScale *= 2f;
							}

							break;

						case ItemDefinition.ItemType.Material:
							Object.Destroy(filter);
							Object.Destroy(renderer);
							if (!chestPrefab)
							{
								var objs = Res.ResourceLoader.GetAssetBundle(2005).LoadAssetWithSubAssets("Assets/chest.prefab");
								foreach (var i in objs)
								{
									if (i.name == "chest")
									{
										ModAPI.Console.Write("Found Chest");
										chestPrefab = (GameObject)i;
									}
								}
								if (!chestPrefab)
									ModAPI.Log.Write("Big yike, no chest in the assetbundle");
							}

							var spawnedChest = GameObject.Instantiate(chestPrefab, spawn.transform.position, Quaternion.identity, spawn.transform);
							var meshRenderes = spawnedChest.transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();   //get the outer metal frame, its split into 2 objects, because the mesh is too big.

							foreach (var rend in meshRenderes)
							{
								rend.material.color = MainMenu.RarityColors[item.rarity];
							}
							if (item.rarity > 2)
							{
								Light l = spawn.AddComponent<Light>();
								l.type = LightType.Point;
								l.shadowStrength = 1;
								l.color = MainMenu.RarityColors[item.rarity];
								l.intensity = 1f;
								l.range = 4f;
								if (item.rarity > 5)
								{
									l.range = 7f;
									l.intensity = 1.7f;
									l.cookieSize = 5f;
									if (item.rarity == 7)
									{
										l.range = 12f;
										l.intensity = 4f;
									}
								}
							}
							goto aftercolorsetup;

						case ItemDefinition.ItemType.Helmet:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[48];
							spawn.transform.localScale *= 0.95f;
							break;

						case ItemDefinition.ItemType.Boot:

							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[44];
							spawn.transform.localScale *= 1.1f;
							break;

						case ItemDefinition.ItemType.Pants:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[50];
							spawn.transform.localScale *= 1.75f;
							break;

						case ItemDefinition.ItemType.ChestArmor:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[42];
							spawn.transform.localScale *= 1.5f;
							break;

						case ItemDefinition.ItemType.ShoulderArmor:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[53];
							spawn.transform.localScale *= 1.65f;
							break;

						case ItemDefinition.ItemType.Glove:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[41];
							spawn.transform.localScale *= 2.22f;
							break;

						case ItemDefinition.ItemType.Bracer:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[45];
							break;

						case ItemDefinition.ItemType.Amulet:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[40];
							spawn.transform.localScale *= 0.85f;
							break;

						case ItemDefinition.ItemType.Ring:
							filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[43];
							spawn.transform.localScale *= 0.85f;
							break;

						default:
							break;
					}

					if (item.rarity > 2)
					{
						Light l = spawn.AddComponent<Light>();
						l.type = LightType.Point;
						l.shadowStrength = 1;
						l.color = MainMenu.RarityColors[item.rarity];
						l.intensity = 1f;
						l.range = 4f;
						renderer.material.color = MainMenu.RarityColors[item.rarity];
						if (item.rarity > 5)
						{
							l.range = 7f;
							l.intensity = 1.7f;
							l.cookieSize = 5f;
							if (item.rarity == 7)
							{
								l.range = 12f;
								l.intensity = 4f;
							}
						}
					}

					aftercolorsetup:
					var bounds = filter.mesh.bounds;
					col.size = bounds.size;
					col.center = bounds.center;
				}

				ItemPickUp pickup = spawn.AddComponent<ItemPickUp>();
				pickup.lifetime = (int)dropSource + item.rarity * item.rarity * 2;
				pickup.item = item;
				pickup.amount = amount;
				pickup.ID = id;
				if (Network.NetworkManager.lastDropID < id)
				{
					Network.NetworkManager.lastDropID = id;
				}

				PickUps.Add(id, pickup);
			}
			catch (System.Exception ex)
			{
				ModAPI.Log.Write("Problem with creating a item pickup " + ex.ToString());
			}
		}

		/// <summary>
		/// removes a pickup with given id for the clinet
		/// </summary>
		public static void RemovePickup(ulong id)
		{
			if (PickUps.ContainsKey(id))
			{
				PickUps[id].Remove();
				PickUps.Remove(id);
			}
		}
	}
}