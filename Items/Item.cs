﻿using System;
using System.Collections.Generic;
using System.Linq;

using ChampionsOfForest.Items;
using ChampionsOfForest.Localization;
using ChampionsOfForest.Player;

using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest
{
	public class Item : BaseItem
	{
		public int level;
		public int stackedAmount;
		public bool isEquipped;
		public List<ItemStat> stats = new List<ItemStat>();
		public int currentEmptySockets;
		public int currentMaxEmptySockets;

		#region Grouping stats of the same id
		private Dictionary<int, float> groupedStats;
		private void GroupStats()
		{
			var grouped = new Dictionary<int, List<float>>();
			foreach (var stat in stats)
			{
				if (grouped.ContainsKey(stat.id))
					grouped[stat.id].Add(stat.amount);
				else
					grouped.Add(stat.id, new List<float>() { stat.amount });
			}
			groupedStats = new Dictionary<int, float>(grouped.Count);
			foreach (var group in grouped)
			{
				groupedStats.Add(group.Key, ItemDataBase.StatByID(group.Key).EvaluateTotalIncrease(group.Value));
			}
		}
		public Dictionary<int, float> GetGroupedStats()
		{
			if (stats.Count == 0)
				return null;
			if (groupedStats == null)
				GroupStats();
			return groupedStats;
		}
		#endregion

		public bool HasEmptySocket => currentEmptySockets > 0;

		public bool PlaceItemInSocket(Item other)
		{
			if (other == null)
				return false;
			if (other.type == ItemType.SocketableGem
				&& HasEmptySocket)
			{
				if (other.onConsumeCallback.Invoke(this))
				{
					//item was successfully socketed
					currentEmptySockets--;
					return true;
				}
			}
			return false;
		}

		// called when another item is dragged and dropped on top of this item
		public bool CombineItems(Item other)
		{
			// if other is a material
			// materials can be used to upgrade items, reroll their values, etc
			if (other.type == ItemType.Material)
			{
				if (other.onConsumeCallback != null)
				{
					if (isEquipped)
						OnUnequip();

					bool returnval = other.onConsumeCallback.Invoke(this);
					OnEquip();

					return returnval;
				}
			}
			else if (other.type == ItemType.SocketableGem)
			{
				bool wasEquipped = isEquipped;
				if (isEquipped)
					OnUnequip();
				PlaceItemInSocket(other);
				if (wasEquipped)
					OnEquip();

				return true;
			}

			return false;
		}

		public bool CanPlaceInSlot(in int slotIndex)
		{
			switch (slotIndex)
			{
				case -2:
					if (this.type == ItemType.Helmet)
						return true;
					break;

				case -3:
					if (this.type == ItemType.ChestArmor)
						return true;
					break;

				case -4:
					if (this.type == ItemType.Pants)
						return true;
					break;

				case -5:
					if (this.type == ItemType.Boot)
						return true;
					break;

				case -6:
					if (this.type == ItemType.ShoulderArmor)
						return true;
					break;

				case -7:
					if (this.type == ItemType.Glove)
						return true;
					break;

				case -8:
					if (this.type == ItemType.Amulet)
						return true;
					break;

				case -9:
					if (this.type == ItemType.Bracer)
						return true;
					break;

				case -10:
					if (this.type == ItemType.Ring)
						return true;
					break;

				case -11:
					if (this.type == ItemType.Ring)
						return true;
					break;

				case -12:
					if (this.type == ItemType.Weapon)
						return true;
					break;

				case -13:
					if (this.type == ItemType.Quiver || this.type == ItemType.SpellScroll || this.type == ItemType.Shield)
						return true;
					break;
			}
			return false;
		}

		public int destinationSlotID
		{
			get
			{
				switch (this.type)
				{
					case ItemType.Shield:
						return -13;

					case ItemType.Quiver:
						return -13;

					case ItemType.Weapon:
						return -12;

					case ItemType.Other:
						return -1;

					case ItemType.Material:
						return -1;

					case ItemType.Helmet:
						return -2;

					case ItemType.Boot:
						return -5;

					case ItemType.Pants:
						return -4;

					case ItemType.ChestArmor:
						return -3;

					case ItemType.ShoulderArmor:
						return -6;

					case ItemType.Glove:
						return -7;

					case ItemType.Bracer:
						return -9;

					case ItemType.Amulet:
						return -8;

					case ItemType.Ring:
						return -11;

					case ItemType.SpellScroll:
						return -13;

					default:
						return -1;
				}
			}
		}
		public string TypeName()
		{
			switch (this.type)
			{
				case BaseItem.ItemType.Shield:
					return Translations.Item_1/*Shield*/;    //tr
				case BaseItem.ItemType.Quiver:
					return Translations.Item_2/*Quiver*/;    //tr
				case BaseItem.ItemType.Weapon:
					return Translations.Item_3/*Weapon*/;    //tr
				case BaseItem.ItemType.Other:
					return Translations.Item_4/*Other*/; //tr
				case BaseItem.ItemType.Material:
					return Translations.Item_5/*Material*/;      //tr
				case BaseItem.ItemType.Helmet:
					return Translations.Item_6/*Helmet*/;    //tr
				case BaseItem.ItemType.Boot:
					return Translations.Item_7/*Boots*/; //tr
				case BaseItem.ItemType.Pants:
					return Translations.Item_8/*Pants*/; //tr
				case BaseItem.ItemType.ChestArmor:
					return Translations.Item_9/*Chest armor*/;   //tr
				case BaseItem.ItemType.ShoulderArmor:
					return Translations.Item_10/*Shoulder armor*/;    //tr
				case BaseItem.ItemType.Glove:
					return Translations.Item_11/*Gloves*/;    //tr
				case BaseItem.ItemType.Bracer:
					return Translations.Item_12/*Bracers*/;   //tr
				case BaseItem.ItemType.Amulet:
					return Translations.Item_13/*Amulet*/;    //tr
				case BaseItem.ItemType.Ring:
					return Translations.Item_14/*Ring*/;  //tr
				case BaseItem.ItemType.SpellScroll:
					return Translations.Item_15/*Scroll*/;    //tr		
				default:
					return type.ToString();
			}
		}


		public Item()
		{
		}

		/// <summary>
		/// creates a item based on a BaseItem object, rolls values
		/// </summary>
		//public Item(BaseItem b, int amount = 1, int increasedLevel = 0, bool roll = true)
		//{
		//	base.description = b.description;
		//	base.minLevel = b.minLevel;
		//	base.maxLevel = b.maxLevel;
		//	if (increasedLevel != -1)
		//	{
		//		this.level = Random.Range(minLevel, maxLevel + 1) + increasedLevel;
		//	}
		//	else
		//	{
		//		int averageLevel;
		//		if (GameSetup.IsMultiplayer)
		//		{
		//			int sum = ModReferences.PlayerLevels.Values.Sum();
		//			int count = ModReferences.PlayerLevels.Values.Count;

		//			if (!ModSettings.IsDedicated)
		//			{
		//				sum += ModdedPlayer.instance.level;
		//				count++;
		//			}
		//			else
		//			{
		//				//ModAPI.Log.Write("Is dedicated server bool set to true.");
		//			}
		//			sum = Mathf.Max(1, sum);
		//			count = Mathf.Max(1, count);
		//			sum /= count;
		//			averageLevel = sum;
		//		}
		//		else
		//		{
		//			averageLevel = ModdedPlayer.instance.level;
		//		}
		//		averageLevel = Mathf.Max(1, averageLevel);
		//		base.level = averageLevel;
		//	}
		//	base.lore = b.lore;
		//	base.name = b.name;
		//	base.onEquipCallback = b.onEquipCallback;
		//	base.onUnequipCallback = b.onUnequipCallback;
		//	base.statSlots = b.statSlots;
		//	base.rarity = b.rarity;
		//	base.uniqueStat = b.uniqueStat;
		//	base.id = b.id;
		//	base.type = b.type;
		//	base.stackSize = b.stackSize;
		//	base.icon = b.icon;
		//	base.onConsumeCallback = b.onConsumeCallback;
		//	base.canConsume = b.canConsume;
		//	base.subtype = b.subtype;
		//	base.lootTable = b.lootTable;
		//	this.stackedAmount = amount;
		//	isEquipped = false;
		//	stats = new List<ItemStat>();
		//	if (roll)
		//	{
		//		RollStats();
		//	}
		//}
		// TODO MAKE A CONSTRUCTOR FOR ITEMS FROM BASE ITEMS



		public float GetRarityMultiplier()
		{
			return Mathf.Pow(1.3f, (int)rarity);
		}

		public bool isEquippable => destinationSlotID < -1;
		//rolls 'amount' on every item stat on this object
		public void RollStats()
		{
			groupedStats = null;
			stats.Clear();
			float rarityMult = GetRarityMultiplier();

			for (int i = 0; i < statSlots.Count; i++)
			{
				StatSlot statSlot = statSlots[i];

				if (UnityEngine.Random.value <= statSlot.chance)
				{
					// roll a random stat from pool
					int selected = Random.Range(0, statSlot.options.Count);

					ItemStat newstat = new ItemStat(statSlot.options[selected], level, i, rarityMult);
					//if (stats.Any(stat => stat.id == newstat.id)) // if stats should be grouped
					//{
					//	stats.First(stat => stat.id == newstat.id).amount += newstat.amount;
					//}
					//else
					{
						stats.Add(newstat);
					}
				}
			}
		}
		public void RollSockets()
		{
			if (isEquippable && level >= ModSettings.MinimumLevelForSocketsToAppear && Random.value <= ModSettings.ChanceForFirstSocketToAppear)
			{
				int socketAmount = 1;

				while (Random.value <= ModSettings.ChanceForSubsequentSocketsToAppear && socketAmount < maximumSocketSlots)
				{
					socketAmount++;
				}

				currentMaxEmptySockets = socketAmount;
				currentEmptySockets = socketAmount;

			}
		}

		public void OnEquip()
		{
			isEquipped = true;
			foreach (ItemStat item in stats)
			{
				if (item.amount != 0)
				{
					item.OnEquip?.Invoke(item.amount);
				}
			}
			onEquipCallback?.Invoke();
		}

		public void OnUnequip()
		{
			isEquipped = false;
			foreach (ItemStat item in stats)
			{
				if (item.amount != 0)
				{
					item.OnUnequip(item.amount);
				}
			}
			onUnequipCallback?.Invoke();
		}

		public bool OnConsume()
		{
			if (canConsume)
			{
				return onConsumeCallback.Invoke(this);
			}
			return false;
		}
	}
}