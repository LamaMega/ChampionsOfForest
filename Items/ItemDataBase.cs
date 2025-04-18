﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static ChampionsOfForest.ItemDefinition;
using static TheForest.Items.World.PickUp;

namespace ChampionsOfForest.Items
{
	public static partial class ItemDatabase
	{
		internal static Dictionary<ItemDefinition.ItemType, List<ItemDefinition>> ItemTemplateStorage;
		public static Dictionary<int, ItemDefinition> itemLookup;
		public static Dictionary<int, ItemStat> Stats;

		private static Dictionary<int, List<int>> ItemRarityGroups;


		//Called from Initializer

		public static void Initialize()
		{
			ItemTemplateStorage = Enum.GetValues(typeof(ItemDefinition.ItemType))
				.Cast<ItemDefinition.ItemType>()
				.ToDictionary(k => k, v => new List<ItemDefinition>());

			itemLookup = new Dictionary<int, ItemDefinition>();
			Stats = new Dictionary<int, ItemStat>();
			ItemRarityGroups = new Dictionary<int, List<int>>();

			PopulateStats();
			
			try
			{
				AddAmulets();
				AddBoots();
				AddBracers();
				AddChestArmor();
				AddConsumables();
				AddGloves();
				AddHelmets();
				AddMaterials();
				AddPants();
				AddQuivers();
				AddRings();
				AddShields();
				AddShoulderArmor();
				AddSpellScrolls
			}
			catch (System.Exception ex)
			{
				CotfUtils.Log("Error with item " + ex.ToString());
			}
			itemLookup.Clear();
			for (int i = 0; i < ItemTemplateStorage.Count; i++)
			{
				try
				{
					itemLookup.Add(ItemTemplateStorage[i].id, ItemTemplateStorage[i]);
					if (ItemRarityGroups.ContainsKey(ItemTemplateStorage[i].rarity))
					{
						ItemRarityGroups[ItemTemplateStorage[i].rarity].Add(ItemTemplateStorage[i].id);
					}
					else
					{
						ItemRarityGroups.Add(ItemTemplateStorage[i].rarity, new List<int>() { ItemTemplateStorage[i].id });
					}
				}
				catch (System.Exception ex)
				{
					ModAPI.Log.Write("Error with adding an item " + ex.ToString());
				}
			}

		}
		
		public static ItemStat StatByID(int id)
		{
			return ItemDatabase.Stats[id];
		}

		public static ItemDefinition ItemBaseByName(string name)
		{
			return itemLookup.Values.First(x => x.name == name);
		}

		private static void SanitizeItems()
		{
			foreach (var keyValuePair in itemLookup)
			{
				var itemDef = keyValuePair.Value;
				if (itemDef.lootTable == EnemyProgression.Enemy.All)
				{
					itemDef.lootTable = (EnemyProgression.Enemy)0b11111111111111111111111;
				}
				if (itemDef.lootWeight <= 0)
				{
					itemDef.lootWeight = 1;
				}
			}
		}
	}
}