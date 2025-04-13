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
			LIFE_ON_HIT,
			DODGE_CHANCE,
			ARMOR,
			ELITE_DAMAGE_REDUCTION,
			ATTACKSPEED,
			EXP_GAIN_MULT,
			MASSACRE_DURATION,
			SPELL_DAMAGE_MULTIPLIER,
			MELEE_DAMAGE_INCREASE,
			RANGED_DAMAGE_INCREASE,
			BASE_SPELL_DAMAGE,
			BASE_MELEE_DAMAGE,
			BASE_RANGED_DAMAGE,
			ALL_RECOVERY,
			MOVEMENT_SPEED,
			ATTACK_COST_REDUCTION,
			SPELL_COST_REDUCTION,
			SPELL_COST_TO_STAMINA,
			LESSERSTRENGTH,
			LESSERAGILITY,
			LESSERVITALITY,
			LESSERINTELLIGENCE,
			LESSERARMOR,
			ENERGY_REGEN_BASE,
			MAX_LIFE_MULT,
			MAX_ENERGY_MULT,
			COOLDOWN_REDUCTION,
			ENERGY_ON_HIT,
			LOOT_QUANTITY,  // think about keeping this later
			ALL_ATTRIBUTES,
			JUMP_POWER,
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
			SPELL_DAMAGE_MULTIPLIER,
			BASE_SPELL_DAMAGE,
			SPELL_COST_REDUCTION,
			ENERGY_REGEN_BASE,
			MAX_ENERGY_MULT,
			COOLDOWN_REDUCTION,
			SPELL_DMG_FROM_INT
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
			MELEE_DAMAGE_INCREASE,
			BASE_MELEE_DAMAGE,
			MELEE_DMG_FROM_STR,
			MELEE_WEAPON_RANGE,
			MELEE_ARMOR_PIERCING,
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
			RANGED_DAMAGE_INCREASE,
			BASE_RANGED_DAMAGE,
			RANGED_DMG_FROM_AGI,
			PROJECTILE_SPEED,
			PROJECTILE_SIZE,
			RANGED_ARMOR_PIERCING,
			HEADSHOT_DAMAGE_MULT,
			PROJECTILE_PIERCE_CHANCE,
			THROWN_SPEAR_DAMAGE,
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
			DODGE_CHANCE,
			ARMOR,
			ELITE_DAMAGE_REDUCTION,
			MAX_HEALTH_FROM_VITALITY,
			MAX_LIFE_MULT,
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
			LIFE_ON_HIT,
			ALL_RECOVERY,
			ENERGY_REGEN_BASE,
			ENERGY_ON_HIT,
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
			LIFE_ON_HIT,
			DODGE_CHANCE,
			ARMOR,
			ELITE_DAMAGE_REDUCTION,
			ATTACKSPEED,
			MASSACRE_DURATION,
			MELEE_DAMAGE_INCREASE,
			BASE_MELEE_DAMAGE,
			ALL_RECOVERY,
			MELEE_WEAPON_RANGE,
			ATTACK_COST_REDUCTION,
			SPELL_COST_REDUCTION,
			SPELL_COST_TO_STAMINA,
			ENERGY_REGEN_BASE,
			MAX_LIFE_MULT,
			MAX_ENERGY_MULT,
			COOLDOWN_REDUCTION,
			ENERGY_ON_HIT,
			BLOCK,
			MELEE_ARMOR_PIERCING,
			THORNS,
			THROWN_SPEAR_DAMAGE,
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
			LIFE_ON_HIT,
			DODGE_CHANCE,
			ARMOR,
			ELITE_DAMAGE_REDUCTION,
			ATTACKSPEED,
			EXP_GAIN_MULT,
			MASSACRE_DURATION,
			SPELL_DAMAGE_MULTIPLIER,
			MELEE_DAMAGE_INCREASE,
			RANGED_DAMAGE_INCREASE,
			BASE_SPELL_DAMAGE,
			BASE_MELEE_DAMAGE,
			BASE_RANGED_DAMAGE,
			MAX_ENERGY_FROM_AGILITY,
			MAX_HEALTH_FROM_VITALITY,
			SPELL_DMG_FROM_INT,
			MELEE_DMG_FROM_STR,
			ALL_RECOVERY,
			MOVEMENT_SPEED,
			MELEE_WEAPON_RANGE,
			ATTACK_COST_REDUCTION,
			SPELL_COST_REDUCTION,
			SPELL_COST_TO_STAMINA,
			ENERGY_REGEN_BASE,
			MAX_LIFE_MULT,
			MAX_ENERGY_MULT,
			COOLDOWN_REDUCTION,
			RANGED_DMG_FROM_AGI,
			ENERGY_ON_HIT,
			BLOCK,
			PROJECTILE_SPEED,
			PROJECTILE_SIZE,
			MELEE_ARMOR_PIERCING,
			RANGED_ARMOR_PIERCING,
			ARMOR_PIERCING,
			ALL_ATTRIBUTES,
			HEADSHOT_DAMAGE_MULT,
			FIRE_DAMAGE,
			CHANCE_ON_HIT_TO_SLOW,
			CHANCE_ON_HIT_TO_BLEED,
			CHANCE_ON_HIT_TO_WEAKEN,
			THORNS,
			PROJECTILE_PIERCE_CHANCE,
			EXPLOSION_DAMAGE,
			THROWN_SPEAR_DAMAGE,


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
				LIFE_ON_HIT,
				ATTACKSPEED,
				EXP_GAIN_MULT,
				ALL_RECOVERY,
				EXPERIENCE,
				ATTACK_COST_REDUCTION,
				SPELL_COST_REDUCTION,
				SPELL_COST_TO_STAMINA,
				LESSERSTRENGTH,
				LESSERAGILITY,
				LESSERVITALITY,
				LESSERINTELLIGENCE,
				ENERGY_REGEN_BASE,
				MAX_LIFE_MULT,
				MAX_ENERGY_MULT,
				COOLDOWN_REDUCTION,
				ENERGY_ON_HIT,
				PROJECTILE_SPEED,
				PROJECTILE_SIZE,
				LOOT_QUANTITY,
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
