﻿using BuilderCore;
using System.Collections.Generic;
using UnityEngine;
namespace ChampionsOfForest
{
    public static class PickUpManager
    {

        public static Dictionary<int, ItemPickUp> PickUps = new Dictionary<int, ItemPickUp>();



        private static Material pickupMaterial;


        /// <summary>
        /// spawns a pickup for the clinet.
        /// </summary>
        public static void SpawnPickUp(Item item, Vector3 pos, int amount = 1, int id = -1)
        {
            try
            {
                GameObject spawn = GameObject.CreatePrimitive(PrimitiveType.Cube);
                spawn.AddComponent<Rigidbody>().mass = 25;
                spawn.transform.position = pos;
                Renderer renderer = spawn.GetComponent<Renderer>();
                MeshFilter filter = spawn.GetComponent<MeshFilter>();
              
                    switch (item._itemType)
                    {
                        case BaseItem.ItemType.Shield:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[49];

                            break;
                        case BaseItem.ItemType.Offhand:


                            break;
                        case BaseItem.ItemType.Weapon:

                            if (item.weaponModel == BaseItem.WeaponModelType.GreatSword)
                            {
                                filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[52];
                            }
                            else if (item.weaponModel == BaseItem.WeaponModelType.LongSword)
                            {
                                filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[51];
                            }

                            break;
                        case BaseItem.ItemType.Other:


                            break;
                        case BaseItem.ItemType.Material:


                            break;
                        case BaseItem.ItemType.Helmet:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[48];
                        spawn.transform.localScale *= 1.1f;
                            break;
                        case BaseItem.ItemType.Boot:

                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[44];
                        spawn.transform.localScale *= 1.1f;

                        break;
                        case BaseItem.ItemType.Pants:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[50];
                        spawn.transform.localScale *= 1.7f;

                        break;
                        case BaseItem.ItemType.ChestArmor:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[42];
                        spawn.transform.localScale *= 1.5f;

                        break;
                        case BaseItem.ItemType.ShoulderArmor:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[53];
                        spawn.transform.localScale *= 1.6f;


                        break;
                        case BaseItem.ItemType.Glove:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[41];
                        spawn.transform.localScale *= 2.2f;

                        break;
                        case BaseItem.ItemType.Bracer:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[45];

                            break;
                        case BaseItem.ItemType.Amulet:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[40];
                        spawn.transform.localScale *= 0.9f;

                        break;
                        case BaseItem.ItemType.Ring:
                            filter.mesh = Res.ResourceLoader.instance.LoadedMeshes[43];

                            break;
                        default:
                            break;
                    }

                
            

                //spawn.AddComponent<BoxCollider>();

                if (pickupMaterial == null)
                {
                    pickupMaterial = Core.CreateMaterial(new BuildingData() { MainColor = Color.yellow, Metalic = 0.8f, Smoothness = 0.9f, EmissionColor = new Color(0.2f, 0.2f, 0.2f) });

                }
                renderer.material = pickupMaterial;


                if (item.Rarity > 2)
                {
                    Light l = spawn.AddComponent<Light>();
                    l.type = LightType.Point;
                    l.shadowStrength = 1;
                    l.color = MainMenu.RarityColors[item.Rarity];
                    l.intensity = 1f;
                    l.range = 6f;
                    if (item.Rarity > 4)
                    {

                    }
                }
                spawn.AddComponent<MeshCollider>().convex = true;

                ItemPickUp pickup = spawn.AddComponent<ItemPickUp>();
                if (id == -1)
                {
                    id = 0;
                    while (PickUps.ContainsKey(id))
                    {
                        id++;
                    }
                }
                pickup.item = item;
                pickup.amount = amount;
                pickup.ID = id;
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
        public static void RemovePickup(int id)
        {
            if (PickUps.ContainsKey(id))
            {
                PickUps[id].Remove();
                PickUps.Remove(id);
            }
            else
            {
                ModAPI.Log.Write("Item desync happened, no item with given id present in the dictionary");
            }
        }
    }
}
