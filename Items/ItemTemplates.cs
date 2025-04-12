using System.Linq;
using System.Collections.Generic;
using ChampionsOfForest.Items;
using ChampionsOfForest.Items.Sets;
using ChampionsOfForest.Localization;
using ChampionsOfForest.Player;

using static ChampionsOfForest.ItemDataBase.Stat;
using static ChampionsOfForest.ItemDataBase;

namespace ChampionsOfForest.Items.ItemTemplates
{

	public abstract class ItemTemplateBuilder : BaseItem
	{

		private static List<ItemStat> defaultStats = null;
		private static List<ItemStat> magicStats = null;
		private static List<ItemStat> meleeStats = null;
		private static List<ItemStat> rangedStats = null;
		private static List<ItemStat> defenseStats = null;
		private static List<ItemStat> recoveryStats = null;
		public ItemTemplateBuilder()
		{
			if (defaultStats == null || defaultStats.Count() == 0)
			{
				defaultStats = ToItemStatList(defaultStatIds);
			}
			if (magicStats == null || magicStats.Count() == 0)
			{
				magicStats = ToItemStatList(magicStatIds);
			}
			if (meleeStats == null || meleeStats.Count() == 0)
			{
				meleeStats = ToItemStatList(meleeStatIds);
			}
			if (rangedStats == null || rangedStats.Count() == 0)
			{
				rangedStats = ToItemStatList(rangedStatIds);
			}
			if (defenseStats == null || defenseStats.Count() == 0)
			{
				defenseStats = ToItemStatList(defenseStatIds);
			}
			if (recoveryStats == null || recoveryStats.Count() == 0)
			{
				recoveryStats = ToItemStatList(recoveryStatIds);
			}

			ID = ItemDataBase._Item_Bases.Count;
			ItemDataBase._Item_Bases.Add(this);
		}

		protected List<ItemStat> ToItemStatList(Stat[] stats)
		{
			var list = new List<ItemStat>();
			foreach (var stat in defaultStatIds)
			{
				list.Add(new ItemStat(ItemDataBase.Stats[(int)stat]));
			}
			return list;
		}

		// pool of stats to appear on items by default
		private readonly Stat[] defaultStatIds = new Stat[]
		{
			STRENGTH,
			AGILITY,
			VITALITY,
			INTELLIGENCE,
			MAX_LIFE,
			MAX_ENERGY,
			LIFE_REGEN_BASE,
			STAMINA_REGEN_BASE,
			STAMINA_AND_ENERGY_REGEN_MULT,
			LIFE_REGEN_MULT,
			DAMAGE_REDUCTION,
			CRIT_CHANCE,
			CRIT_DAMAGE,
			LIFEONHIT,
			DODGECHANCE,
			ARMOR,
			RESISTANCETOMAGIC,
			ATTACKSPEED,
			EXPGAIN,
			MASSACREDURATION,
			SPELLDAMAGEINCREASE,
			MELEEDAMAGEINCREASE,
			RANGEDDAMAGEINCREASE,
			BASESPELLDAMAGE,
			BASEMELEEDAMAGE,
			BASERANGEDDAMAGE,
			ALLHEALINGPERCENT,
			MOVEMENTSPEED,
			ATTACKCOSTREDUCTION,
			SPELLCOSTREDUCTION,
			SPELLCOSTTOSTAMINA,
			LESSERSTRENGTH,
			LESSERAGILITY,
			LESSERVITALITY,
			LESSERINTELLIGENCE,
			LESSERARMOR,
			ENERGYPERSECOND,
			PERCENTMAXIMUMLIFE,
			PERCENTMAXIMUMENERGY,
			COOLDOWNREDUCTION,
			ENERGYONHIT,
			MAGICFIND,  // think about keeping this later
			ALL_ATTRIBUTES,
			JUMPPOWER,
			THORNS
		};

		// adds the defaultStatIds n times to the stat pool for the item
		public ItemTemplateBuilder DefaultStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(defaultStats);
			return this;
		}

		public ItemTemplateBuilder StatSlot(Stat[] statPool)
		{
			PossibleStats.Add(ToItemStatList(statPool));
			return this;
		}

		public ItemTemplateBuilder DropsFrom(EnemyProgression.Enemy enemyTypes)
		{
			lootTable = enemyTypes;
			return this;
		}

		public ItemTemplateBuilder Name(string s)
		{
			name = s;
			return this;
		}

		public ItemTemplateBuilder Description(string s)
		{
			description = s;
			return this;
		}

		public ItemTemplateBuilder Lore(string s)
		{
			lore = s;
			return this;
		}

		public ItemTemplateBuilder UniqueStat(string s, OnItemEquip _onEquip, OnItemUnequip _onUnequip)
		{
			onEquip = _onEquip;
			onUnequip = _onUnequip;
			uniqueStat = s;
			return this;
		}

		public ItemTemplateBuilder LevelRequirement(int minimumLevel)
		{
			minLevel = minimumLevel;
			maxLevel = minimumLevel + 1;
			return this;
		}

		public ItemTemplateBuilder Consumable(string consumableDescriptiuon, OnItemConsume _onConsume, OnItemUnequip _onUnequip)
		{
			onConsume = _onConsume;
			uniqueStat = consumableDescriptiuon;
			StackSize = 100;
			CanConsume = true;
			return this;
		}

		public ItemTemplateBuilder Rarity(int r)
		{
			base.rarity = r;
			return this;
		}

        public ItemTemplateBuilder Icon(int iconid)
        {
			icon = Res.ResourceLoader.GetTexture(iconid); // Texture2D <- int
            return this;
        }

		private readonly Stat[] magicStatIds = new Stat[]
		{
			INTELLIGENCE,
			SPELLDAMAGEINCREASE,
			BASESPELLDAMAGE,
			SPELLCOSTREDUCTION,
			ENERGYPERSECOND,
			PERCENTMAXIMUMENERGY,
			COOLDOWNREDUCTION,
			SPELLDMGFROMINT
		};

		public ItemTemplateBuilder MagicStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(magicStats);
			return this;
		}

		private readonly Stat[] meleeStatIds = new Stat[]
		{
			STRENGTH,
			MELEEDAMAGEINCREASE,
			BASEMELEEDAMAGE,
			MELEEDMGFROMSTR,
			MELEEWEAPONRANGE,
			MELEEARMORPIERCING,
		};

		public ItemTemplateBuilder MeleeStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(meleeStats);
			return this;
		}

		private readonly Stat[] rangedStatIds = new Stat[]
		{
			AGILITY,
			RANGEDDAMAGEINCREASE,
			BASERANGEDDAMAGE,
			RANGEDDMGFROMAGI,
			PROJECTILESPEED,
			PROJECTILESIZE,
			RANGEDARMORPIERCING,
			HEADSHOTDAMAGE,
			PIERCECHANCE,
			SPEARDAMAGE,
		};

		public ItemTemplateBuilder RangedStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(rangedStats);
			return this;
		}

		private readonly Stat[] defenseStatIds = new Stat[]
		{
			VITALITY,
			MAX_LIFE,
			DAMAGE_REDUCTION,
			DODGECHANCE,
			ARMOR,
			RESISTANCETOMAGIC,
			MAXHEALTHFROMVIT,
			PERCENTMAXIMUMLIFE,
			BLOCK,
			THORNS,
		};

		public ItemTemplateBuilder DefenseStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(defenseStats);
			return this;
		}

		private readonly Stat[] recoveryStatIds = new Stat[]
		{
			LIFE_REGEN_BASE,
			LIFE_REGEN_MULT,
			LIFEONHIT,
			ALLHEALINGPERCENT,
			ENERGYPERSECOND,
			ENERGYONHIT,
			STAMINA_REGEN_BASE,
			STAMINA_AND_ENERGY_REGEN_MULT,
		};

		public ItemTemplateBuilder RecoveryStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(recoveryStats);
			return this;
		}
	}

	public class Greatsword : ItemTemplateBuilder
	{
		public Greatsword()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.GreatSword;
			Icon(88);

        }
	}

	public class Longsword : ItemTemplateBuilder
	{
		public Longsword()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.LongSword;
			Icon(89);
		}
	}

	public class Hammer : ItemTemplateBuilder
	{
		public Hammer()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.Hammer;
			Icon(109);

        }
	}

	public class Polearm : ItemTemplateBuilder
	{
		public Polearm()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.Polearm;
            Icon(181);
        }
	}

	public class Axe : ItemTemplateBuilder
	{
		public Axe()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.Axe;
            Icon(138);
        }
	}

	public class Greatbow : ItemTemplateBuilder
	{
		public Greatbow()
		{
			type = ItemType.Weapon;
			weaponModel = WeaponModelType.Greatbow;
            Icon(170);
        }
	}


	public class Material : ItemTemplateBuilder
	{
		public Material()
		{
			type = ItemType.Material;
			LevelRequirement(20);
			// Materials dont have a default icon
		}
	}

	public class Shield : ItemTemplateBuilder
	{

		private static readonly Stat[] shieldStatIds =
		{
			STRENGTH,
			VITALITY,
			MAX_LIFE,
			MAX_ENERGY,
			LIFE_REGEN_BASE,
			STAMINA_REGEN_BASE,
			STAMINA_AND_ENERGY_REGEN_MULT,
			LIFE_REGEN_MULT,
			DAMAGE_REDUCTION,
			CRIT_CHANCE,
			CRIT_DAMAGE,
			LIFEONHIT,
			DODGECHANCE,
			ARMOR,
			RESISTANCETOMAGIC,
			ATTACKSPEED,
			MASSACREDURATION,
			MELEEDAMAGEINCREASE,
			BASEMELEEDAMAGE,
			ALLHEALINGPERCENT,
			MELEEWEAPONRANGE,
			ATTACKCOSTREDUCTION,
			SPELLCOSTREDUCTION,
			SPELLCOSTTOSTAMINA,
			ENERGYPERSECOND,
			PERCENTMAXIMUMLIFE,
			PERCENTMAXIMUMENERGY,
			COOLDOWNREDUCTION,
			ENERGYONHIT,
			BLOCK,
			MELEEARMORPIERCING,
			THORNS,
			SPEARDAMAGE,
			};
		private static List<ItemStat> shieldStats = null;

		public Shield ShieldStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(shieldStats);
			return this;
		}

		public Shield()
		{
			type = ItemType.Shield;
			if (shieldStats == null)
				shieldStats = ToItemStatList(shieldStatIds);
			LevelRequirement(10);
            Icon(99);
        }
	}

	public class Quiver : ItemTemplateBuilder
	{
		public Quiver()
		{
			type = ItemType.Quiver;
			LevelRequirement(10);
            Icon(98);
        }
	}

	public class Other : ItemTemplateBuilder
	{
		public Other()
		{
			type = ItemType.Other;
            Icon(105);
        }
	}

	public class Helmet : ItemTemplateBuilder
	{
		public Helmet()
		{
			type = ItemType.Helmet;
			LevelRequirement(6);
            Icon(91);
        }
	}

	public class Boot : ItemTemplateBuilder
	{
		public Boot()
		{
			type = ItemType.Boot;
			LevelRequirement(5);
            Icon(85);
        }
	}

	public class Pants : ItemTemplateBuilder
	{
		public Pants()
		{
			type = ItemType.Pants;
            Icon(87);
        }
	}

	public class ChestArmor : ItemTemplateBuilder
	{
		public ChestArmor()
		{
			type = ItemType.ChestArmor;
			LevelRequirement(1);
            Icon(96);
        }
	}

	public class ShoulderArmor : ItemTemplateBuilder
	{
		public ShoulderArmor()
		{
			type = ItemType.ShoulderArmor;
			LevelRequirement(8);
            Icon(95);
        }
	}

	public class Glove : ItemTemplateBuilder
	{
		public Glove()
		{
			type = ItemType.Glove;
			LevelRequirement(7);
            Icon(86);
        }
	}

	public class Bracer : ItemTemplateBuilder
	{
		public Bracer()
		{
			type = ItemType.Bracer;
			LevelRequirement(9);
            Icon(93);
        }
	}

	public class Amulet : ItemTemplateBuilder
	{


		private static readonly Stat[] amuletStatIds =
		{
			STRENGTH,
			AGILITY,
			VITALITY,
			INTELLIGENCE,
			MAX_LIFE,
			MAX_ENERGY,
			LIFE_REGEN_BASE,
			STAMINA_REGEN_BASE,
			STAMINA_AND_ENERGY_REGEN_MULT,
			LIFE_REGEN_MULT,
			DAMAGE_REDUCTION,
			CRIT_CHANCE,
			CRIT_DAMAGE,
			LIFEONHIT,
			DODGECHANCE,
			ARMOR,
			RESISTANCETOMAGIC,
			ATTACKSPEED,
			EXPGAIN,
			MASSACREDURATION,
			SPELLDAMAGEINCREASE,
			MELEEDAMAGEINCREASE,
			RANGEDDAMAGEINCREASE,
			BASESPELLDAMAGE,
			BASEMELEEDAMAGE,
			BASERANGEDDAMAGE,
			MAXENERGYFROMAGI,
			MAXHEALTHFROMVIT,
			SPELLDMGFROMINT,
			MELEEDMGFROMSTR,
			ALLHEALINGPERCENT,
			MOVEMENTSPEED,
			MELEEWEAPONRANGE,
			ATTACKCOSTREDUCTION,
			SPELLCOSTREDUCTION,
			SPELLCOSTTOSTAMINA,
			ENERGYPERSECOND,
			PERCENTMAXIMUMLIFE,
			PERCENTMAXIMUMENERGY,
			COOLDOWNREDUCTION,
			RANGEDDMGFROMAGI,
			ENERGYONHIT,
			BLOCK,
			PROJECTILESPEED,
			PROJECTILESIZE,
			MELEEARMORPIERCING,
			RANGEDARMORPIERCING,
			ARMORPIERCING,
			ALL_ATTRIBUTES,
			HEADSHOTDAMAGE,
			FIREDAMAGE,
			CHANCEONHITTOSLOW,
			CHANCEONHITTOBLEED,
			CHANCEONHITTOWEAKEN,
			THORNS,
			PIERCECHANCE,
			EXPLOSIONDAMAGE,
			SPEARDAMAGE,


			};
		private static List<ItemStat> amuletStats = null;


		public Amulet()
		{
			type = ItemType.Amulet;
			if (amuletStats == null)
				amuletStats = ToItemStatList(amuletStatIds);
			LevelRequirement(20);
			Icon(101);
		}

		public Amulet RingStatSlot(int n = 1)
		{
			for (int i = 0; i < n; i++)
				PossibleStats.Add(amuletStats);
			return this;
		}

		public Amulet Scarf()
		{
			Icon(100); // this is the id of scarf icon
			return this;
		}
	}

	public class Ring : ItemTemplateBuilder
	{
		private static readonly Stat[] ringStatIds =
		{
				STRENGTH,
				AGILITY,
				VITALITY,
				INTELLIGENCE,
				MAX_LIFE,
				MAX_ENERGY,
				LIFE_REGEN_BASE,
				STAMINA_REGEN_BASE,
				STAMINA_AND_ENERGY_REGEN_MULT,
				LIFE_REGEN_MULT,
				CRIT_CHANCE,
				CRIT_DAMAGE,
				LIFEONHIT,
				ATTACKSPEED,
				EXPGAIN,
				ALLHEALINGPERCENT,
				EXPERIENCE,
				ATTACKCOSTREDUCTION,
				SPELLCOSTREDUCTION,
				SPELLCOSTTOSTAMINA,
				LESSERSTRENGTH,
				LESSERAGILITY,
				LESSERVITALITY,
				LESSERINTELLIGENCE,
				ENERGYPERSECOND,
				PERCENTMAXIMUMLIFE,
				PERCENTMAXIMUMENERGY,
				COOLDOWNREDUCTION,
				ENERGYONHIT,
				PROJECTILESPEED,
				PROJECTILESIZE,
				MAGICFIND,
				ALL_ATTRIBUTES

			};
		private static List<ItemStat> ringStats = null;

		public Ring()
		{
			type = ItemType.Ring;
			if (ringStats == null)
				ringStats = ToItemStatList(ringStatIds);
			Icon(90);
			LevelRequirement(15);
		}

		public Ring RingStatSlot(int n = 1)
		{
			for(int i = 0; i<n; i++)
				PossibleStats.Add(ringStats);
			return this;
		}
	}

	public class SpellScroll : ItemTemplateBuilder
	{
		public SpellScroll()
		{
			type = ItemType.SpellScroll;
			LevelRequirement(10);
			Icon(110);
		}
	}

	public class Consumables : ItemTemplateBuilder
	{
		public Consumables()
		{
			type = ItemType.Other;
			LevelRequirement(10);
			Icon(105);
		}
	}

    /*
	 * OLD
		new BaseItem(new int[][]
					 {
					 })
		{
			name = Translations.ItemDataBase_ItemDefinitions_201, //tr
			description = Translations.ItemDataBase_ItemDefinitions_202, //tr
			lore = Translations.ItemDataBase_ItemDefinitions_203, //tr
			uniqueStat = Translations.ItemDataBase_ItemDefinitions_204, //tr
			Rarity = 4,
			minLevel = 1,
			maxLevel = 2,
			CanConsume = true,
			StackSize = 100,
			type = BaseItem.ItemType.Other,
			icon = Res.ResourceLoader.GetTexture(105),
			onEquip = ModdedPlayer.Respec
		};


	* NEW
		new Consumable()
			.Name("heart of purity")
			.Description("respecs spent points")
			.Something()
			.DefaultStatSlot(3)
			.StatSlot({ BASESPELLDAMAGE, BASEMELEEDAMAGE, BASERANGEDDAMAGE })
			.StatSlot({ THORNS })
	 
	 # Example 2:
		new Ring()
            .RingStatSlot(3)
            .DefaultStatSlot(1)
            .StatSlot(new Stat[] {THORNS} )
            .Name("Hazards test loop")
            .Description("Description goes here")
            .Rarity(4); 
	 
	 */

}
