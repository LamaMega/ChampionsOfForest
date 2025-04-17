using System;
using System.Collections.Generic;
using System.Linq;

using ChampionsOfForest.Player;

using TheForest.Utils;

using UnityEngine;

using Random = UnityEngine.Random;

namespace ChampionsOfForest.Items
{
	public static partial class ItemDatabase
	{
		private static int GetLevel(Vector3 pos)
		{
			int level;
			{
				if (GameSetup.IsMultiplayer)
				{
					var states = ModReferences.PlayerStates.All;
					switch (ModSettings.lootLevelPolicy)
					{
						case ModSettings.LootLevelPolicy.HighestPlayerLevel:
							level = states.Max(x => x.level);
							break;
						case ModSettings.LootLevelPolicy.AverageLevel:
							level = (int)states.Average(x => (double)x.level);
							break;
						case ModSettings.LootLevelPolicy.LowestLevel:
							level = states.Min(x => x.level);
							break;
						case ModSettings.LootLevelPolicy.ClosestPlayer:
							{
								level = ModdedPlayer.instance.level;
								float dist = (LocalPlayer.Transform.position - pos).sqrMagnitude;
								foreach (var state in states)
								{
									float d = (state.gameObject.transform.position - pos).sqrMagnitude;
									if (d < dist)
									{
										dist = d;
										level = state.level;
									}
								}
							}
							break;
						default:
							level = ModdedPlayer.instance.level;
							break;
					}
				}
				else
				{
					level = ModdedPlayer.instance.level;
				}
			}
			return level;
		}
		public static Item GetRandomItem(float Worth, Vector3 pos)
		{
			int level = GetLevel(pos);
			float w = Worth;
			w *= ModdedPlayer.Stats.magicFind_quantity.Value;

			int rarity = GetRarity(w, ModSettings.difficulty);

			int[] itemIdPool = null;
			while (itemIdPool == null)
			{
				itemIdPool = ItemRarityGroups[rarity].Where(i => (AllowItemDrop(i, level, EnemyProgression.Enemy.All))).ToArray();
				if (itemIdPool.Length == 0)
				{
					rarity--;
					itemIdPool = null;
				}
				if (rarity == -1)
					return null;
			}

			int randomID = Random.Range(0, itemIdPool.Length);
			Item item = new Item(itemLookup[itemIdPool[randomID]]);

			item.level = level;
			if (item.id == 42 || item.id == 103 || item.type == ItemDefinition.ItemType.Material)
				item.level = 1;
			item.RollStats();
			return item;
		}

		public static bool AllowItemDrop(int i, in int level, EnemyProgression.Enemy e)
		{
			if (!itemLookup.ContainsKey(i))
			{
				return true;
			}
			if ((int)itemLookup[i].lootTable != 0)
				return (itemLookup[i].lootTable & e) != 0 && itemLookup[i].minLevel <= level;
			return itemLookup[i].minLevel <= level;
		}


		struct RandomItemPoolEntry
		{
			public int totalWeight;
			public List<ItemDefinition> items;

			public RandomItemPoolEntry(int level, int rarity)
			{
				totalWeight = 0;
				items = new List<ItemDefinition>();
				foreach (var item in ItemRarityGroups[rarity])
				{
					if (itemLookup[item].minLevel <= level && itemLookup[item].lootTable != 0)
					{
						totalWeight += itemLookup[item].lootWeight;
						items.Add(itemLookup[item]);
					}
				}
			}
			public ItemDefinition Get(int randomWeight)
			{
				randomWeight = Mathf.Max(randomWeight, totalWeight);
				int i = 0;
				while (randomWeight > totalWeight && i < items.Count-1)
				{
					if (randomWeight < items[i].lootWeight)
						return items[i];
					else
					{
						randomWeight -= items[i].lootWeight;
						i++;
					}
				}
				return items[i];
			}
		};

		static int randomItemPoolLevel = -1; // at which level was the random item pool created
		static RandomItemPoolEntry[] randomItemPoolEntries = new RandomItemPoolEntry[(int)ItemDefinition.Rarity.Max];

		static RandomItemPoolEntry GetPool(int level, int rarity)
		{
			if(randomItemPoolLevel != level)
			{
				randomItemPoolLevel = level;
				for (int i = 0; i < randomItemPoolEntries.Length; i++)
					randomItemPoolEntries[i] = new RandomItemPoolEntry();
			}
			if ()
		}


		public static Item GetRandomItem(float Worth, EnemyProgression.Enemy killedEnemyType, ModSettings.Difficulty difficulty, Vector3 pos)
		{
			int level = GetLevel(pos);
			ItemDefinition.Rarity rarity = GetRandomRarity(level, ModdedPlayer.Stats.magicFind_quality.Value, difficulty);

			
			int[] itemIdPool = null;
			while (itemIdPool == null)
			{
				itemIdPool = ItemRarityGroups[rarity].Where(i => (AllowItemDrop(i, level, EnemyProgression.Enemy.All))).ToArray();
				if (itemIdPool.Length == 0)
				{
					rarity--;
					itemIdPool = null;
				}
				if (rarity == -1)
					return null;
			}

			int randomID = Random.Range(0, itemIdPool.Length);
			Item item = new Item(itemLookup[itemIdPool[randomID]]);

			item.level = level;
			if (item.id == 42 || item.id == 103 || item.type == ItemDefinition.ItemType.Material)
				item.level = 1;
			item.RollStats();
			return item;
		}

		static int[] odds = new int[]
		{
			// odds of upgrading from one rarity to another
			// the odds are 1 in x
			3, // Common
			10, // Magic
			25, // Rare
			100, // Legendary
		};

		static System.Random rng = new System.Random();
		public static ItemDefinition.Rarity GetRandomRarity(int level, float qualitymult, ModSettings.Difficulty difficulty)
		{
			qualitymult += (int)difficulty * ModSettings.MagicFindPerDifficultyLevel;

			int rarityNum = 0;			
			while (rarityNum < (int) ItemDefinition.Rarity.Max-1)
			{
				double chance = (odds[rarityNum] / qualitymult);
				double rand = rng.NextDouble() * chance;
				if (rand < 1.0)
					rarityNum++;
				else
					break;
			}
			return (ItemDefinition.Rarity) rarityNum;
		}
	}
}