using System.Collections.Generic;

using ChampionsOfForest.Effects.Sound_Effects;

using UnityEngine;

namespace ChampionsOfForest
{
	public class BaseItem
	{
		public class StatSlot
		{
			public float chance;
			public List<ItemStat> options;
			public StatSlot(List<ItemStat> options, float chance = 1)
			{
				this.chance = chance;
				this.options = options;
			}
		}

		public enum ItemType
		{
			Other, Shield, Quiver, Weapon, Material, Helmet, Boot, Pants, ChestArmor, ShoulderArmor, Glove, Bracer, Amulet, Ring, SpellScroll, SocketableGem
		}
		public enum Rarity
		{
			Common = 0, Uncommon, Rare, Magic, Legendary
		}
		public enum ItemSubtype 
		{ 
			None, GreatSword, LongSword, Hammer, Polearm, Axe, Greatbow,
			RangedSocketable, MeleeSocketable, MagicSocketable, SupportSocketable, DefenseSocketable, UtilitySocketable,
		};

		public delegate void OnItemUsed();
		public delegate bool OnItemConsume(Item other);


		public int id = 0;                      
		public Rarity rarity = 0;                  
		public ItemType type = ItemType.Other;          
		public ItemSubtype subtype = ItemSubtype.None;
		
		public bool canConsume = false;             
		public OnItemConsume onConsumeCallback;
		public OnItemUsed onEquipCallback, onUnequipCallback;
		public List<StatSlot> statSlots;
		public int maximumSocketSlots;

		// display properties of the item
		public string name;                 
		public string description;          
		public string lore;                 
		public string uniqueStat;              
		public Texture2D icon;
		public int minLevel = 1;
		public int maxLevel = 1;

		public int stackSize = 1;
		public bool PickUpAll = true;          

		//Drop settings
		public EnemyProgression.Enemy lootTable = EnemyProgression.Enemy.All;
		public int lootWeight = 1; //weight of the item in loot table, used to calculate drop chance
		
		public BaseItem()
		{
			statSlots = new List<StatSlot>();
		}



		private void SetDropFromEverything()
		{
			//Lootable from everything
			lootTable = (EnemyProgression.Enemy)0b1111111111111111111111;
		}

		//Sets the item to drop from only a specyfic group of enemies
		public void SetDropOnlyArmsy()
		{
			lootTable = EnemyProgression.Enemy.RegularArmsy | EnemyProgression.Enemy.PaleArmsy;
		}

		public void SetDropOnlyVags()
		{
			lootTable = EnemyProgression.Enemy.PaleVags | EnemyProgression.Enemy.RegularVags;
		}

		public void SetDropOnlyCow()
		{
			lootTable = EnemyProgression.Enemy.Cowman;
		}

		public void SetDropOnlyBaby()
		{
			lootTable = EnemyProgression.Enemy.Baby;
		}

		public void SetDropOnlyMegan()
		{
			lootTable = EnemyProgression.Enemy.Megan;
		}

		public void SetDropOnlyCreepy()
		{
			lootTable = EnemyProgression.Enemy.RegularArmsy | EnemyProgression.Enemy.PaleArmsy | EnemyProgression.Enemy.RegularVags | EnemyProgression.Enemy.PaleVags | EnemyProgression.Enemy.Cowman | EnemyProgression.Enemy.Baby | EnemyProgression.Enemy.Girl | EnemyProgression.Enemy.Worm | EnemyProgression.Enemy.Megan;
		}

		public void SetDropOnlyCannibals()
		{
			lootTable =
				EnemyProgression.Enemy.NormalMale | EnemyProgression.Enemy.NormalLeaderMale | EnemyProgression.Enemy.NormalFemale | EnemyProgression.Enemy.NormalSkinnyMale | EnemyProgression.Enemy.NormalSkinnyFemale | EnemyProgression.Enemy.PaleMale | EnemyProgression.Enemy.PaleSkinnyMale | EnemyProgression.Enemy.PaleSkinnedMale | EnemyProgression.Enemy.PaleSkinnedSkinnyMale | EnemyProgression.Enemy.PaintedMale | EnemyProgression.Enemy.PaintedLeaderMale | EnemyProgression.Enemy.PaintedFemale | EnemyProgression.Enemy.Fireman;
		}

		public GlobalSFX.SFX GetInvSound()
		{
			switch (type)
			{
				case ItemType.Shield:
					return GlobalSFX.SFX.Invshiel;
				case ItemType.Quiver:
					return GlobalSFX.SFX.Invlarm;
				case ItemType.Weapon:
					switch (subtype)
					{							
						case ItemSubtype.GreatSword:
							return GlobalSFX.SFX.Invharm;
						case ItemSubtype.LongSword:
							return GlobalSFX.SFX.Invsword;
						case ItemSubtype.Hammer:
							return GlobalSFX.SFX.Invanvl;
						case ItemSubtype.Polearm:
							return GlobalSFX.SFX.Invstaf;
						case ItemSubtype.Axe:
							return GlobalSFX.SFX.Invaxe;
						case ItemSubtype.Greatbow:
							return GlobalSFX.SFX.Invbow;
						default:
							return GlobalSFX.SFX.Invharm;
					}
				case ItemType.Other:
					return GlobalSFX.SFX.Invbody;
				case ItemType.Material:
					return GlobalSFX.SFX.Invrock;
				case ItemType.Helmet:
					return GlobalSFX.SFX.Invcap;
				case ItemType.Boot:
					return GlobalSFX.SFX.Invgrab;	//change
				case ItemType.Pants:
					return GlobalSFX.SFX.Invblst;	//change
				case ItemType.ChestArmor:
					return GlobalSFX.SFX.Invsign;	
				case ItemType.ShoulderArmor:
					return GlobalSFX.SFX.Invharm;	//change
				case ItemType.Glove:
					return GlobalSFX.SFX.Invlarm;	//change
				case ItemType.Bracer:
					return GlobalSFX.SFX.Invbook;	//change
				case ItemType.Amulet:
					return GlobalSFX.SFX.Invring;
				case ItemType.Ring:
					return GlobalSFX.SFX.Invring;
				case ItemType.SpellScroll:
					return GlobalSFX.SFX.Invscrol;
				default:
					return GlobalSFX.SFX.ClickDown;
			}
		}

		public int GetDropSoundID()
		{
			int ID = ((int)GetInvSound()) + 1052;
			return ID < 1070 ? ID : Random.Range(1050, 1052);
		}


		public float GetInvSoundPitch()
		{
			return 1.00f - (float)rarity / 12f;
		}
	}
}