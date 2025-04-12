﻿using System.Linq;

using ChampionsOfForest.Items;
using ChampionsOfForest.Localization;
using ChampionsOfForest.Player;

using TheForest.Utils;

using UnityEngine;

using static ChampionsOfForest.ItemDataBase.Stat;

namespace ChampionsOfForest
{
	public static partial class ItemDataBase
	{
		public enum Stat
		{
			ALL = -1,
			NONE = 0,
			STRENGTH = 1,
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
			PERMANENTPERKPOINTS,
			EXPERIENCE,
			MOVEMENTSPEED,
			MELEEWEAPONRANGE,
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
			RANGEDDMGFROMAGI,
			ENERGYONHIT,
			BLOCK,
			PROJECTILESPEED,
			PROJECTILESIZE,
			MELEEARMORPIERCING,
			RANGEDARMORPIERCING,
			ARMORPIERCING,
			MAGICFIND,
			ALL_ATTRIBUTES,
			REFUNDPOINTS,
			JUMPPOWER,
			HEADSHOTDAMAGE,
			FIREDAMAGE,
			CHANCEONHITTOSLOW,
			CHANCEONHITTOBLEED,
			CHANCEONHITTOWEAKEN,
			THORNS,
			PIERCECHANCE,
			EXPLOSIONDAMAGE,
			SPEARDAMAGE,

			EXTRACARRIEDSTICKS = 1000,
			EXTRACARRIEDROCKS,
			EXTRACARRIEDROPES,
			EXTRACARRIEDDRINKS,
			EXTRACARRIEDFOOD,

			BLACKHOLESIZE = 2000,
			BLACKHOLELIFETIME,
			BLACKHOLEGRAVITATIONALFORCE,
			BLACKHOLEDAMAGE,
			STUNONHIT,
			SNAPFREEZEDURATION,
			RAFTSPEED,

			EMPTYSOCKET = 3000,
		}

		public static void PopulateStats()
		{
			// Attributes
			new ItemStatBuilder(Stat.STRENGTH, "Strength", 2f, 3f)
				.AffectsStat(ModdedPlayer.Stats.strength)
				.Additive(ModdedPlayer.Stats.strength)
				.LevelScaling(0.4f);

			new ItemStatBuilder(Stat.AGILITY, "Agility", 2f, 3f)
				.AffectsStat(ModdedPlayer.Stats.agility)
				.Additive(ModdedPlayer.Stats.agility)
				.LevelScaling(0.4f);

			new ItemStatBuilder(Stat.VITALITY, "Vitality", 2f, 3f)
				.AffectsStat(ModdedPlayer.Stats.vitality)
				.Additive(ModdedPlayer.Stats.vitality)
				.LevelScaling(0.4f);

			new ItemStatBuilder(Stat.INTELLIGENCE, "Intelligence", 2f, 3f)
				.AffectsStat(ModdedPlayer.Stats.vitality)
				.Additive(ModdedPlayer.Stats.vitality)
				.LevelScaling(0.4f);

			new ItemStatBuilder(Stat.ALL_ATTRIBUTES, "All Attributes", 1f, 1.5f) 
			{ 
				OnEquip = f => {
					ModdedPlayer.Stats.strength.Add((int)f);
					ModdedPlayer.Stats.intelligence.Add((int)f);
					ModdedPlayer.Stats.agility.Add((int)f);
					ModdedPlayer.Stats.vitality.Add((int)f);
				},
				OnUnequip = f => {
					ModdedPlayer.Stats.strength.Sub((int)f);
					ModdedPlayer.Stats.intelligence.Sub((int)f);
					ModdedPlayer.Stats.agility.Sub((int)f);
					ModdedPlayer.Stats.vitality.Sub((int)f);
				},
				GetTotalStat = () => $"{ModdedPlayer.Stats.strength} Str, {ModdedPlayer.Stats.agility} Agi, {ModdedPlayer.Stats.intelligence} Int, {ModdedPlayer.Stats.vitality} Vit"
			}.LevelScaling(0.4f);


			// Life
			new ItemStatBuilder(Stat.MAX_LIFE, "Max Life", 3.75f, 5.65f)
				.AffectsStat(ModdedPlayer.Stats.maxLife)
				.Additive(ModdedPlayer.Stats.maxLife)
				.LevelScaling(1.21f);

			new ItemStatBuilder(Stat.MAX_ENERGY, "Max Energy", 0.7f, 1.5f)
				.AffectsStat(ModdedPlayer.Stats.maxEnergy)
				.Additive(ModdedPlayer.Stats.maxEnergy)
				.LevelScaling(0.5f);

			new ItemStatBuilder(Stat.LIFE_REGEN_BASE, "Life Regeneration", 0.013f, 0.023f)
				.AffectsStat(ModdedPlayer.Stats.lifeRegenBase)
				.Additive(ModdedPlayer.Stats.lifeRegenBase)
				.LinearLevelScaling()
				.RoundTo(2);

			new ItemStatBuilder(Stat.STAMINA_REGEN_BASE, "Stamina Regeneration", 0.035f, 0.11f)
				.AffectsStat(ModdedPlayer.Stats.staminaRegenBase)
				.Additive(ModdedPlayer.Stats.staminaRegenBase)
				.LevelScaling(0.5f)
				.RoundTo(2);

			new ItemStatBuilder(Stat.STAMINA_AND_ENERGY_REGEN_MULT, "Stamina and Energy Regeneration", 0.04f, 0.08f)
				.AffectsStat(ModdedPlayer.Stats.energyRegenMult)
				.Additive(ModdedPlayer.Stats.energyRegenMult)
				.LevelScaling(0.1f)
				.RarityScaling(0.2f)
				.PercentFormatting()
				.RoundTo(2);

			new ItemStatBuilder(Stat.LIFE_REGEN_MULT, "Life Regeneration", 0.04f, 0.08f)
				.AffectsStat(ModdedPlayer.Stats.lifeRegenMult)
				.Additive(ModdedPlayer.Stats.lifeRegenMult)
				.LevelScaling(0.1f)
				.RarityScaling(0.2f)
				.PercentFormatting();

			new ItemStatBuilder(Stat.DAMAGE_REDUCTION, "Reduced Damage Taken", 0.03f, 0.07f) // needs tweaking
				.AffectsStat(ModdedPlayer.Stats.allDamageTaken)
				.OneMinusMultiplier(ModdedPlayer.Stats.allDamageTaken)
				.LevelScaling(0.1f)
				.RarityScaling(0.33f)
				.PercentFormatting();

			new ItemStatBuilder(Stat.CRIT_CHANCE, "Critical Hit Chance", 0.035f, 0.06f)
				.AffectsStat(ModdedPlayer.Stats.critChance)
				.Additive(ModdedPlayer.Stats.critChance)    // change to OneMinusMultiplier if you dont want players reaching 100% crit chance
				.LevelScaling(0.1f)
				.RarityScaling(0.1f)
				.PercentFormatting()
				.RoundTo(2);

			new ItemStatBuilder(Stat.CRIT_DAMAGE, "Critical Hit Damage", 0.30f, 0.50f)
				.AffectsStat(ModdedPlayer.Stats.critDamage)
				.Additive(ModdedPlayer.Stats.critDamage)
				.LevelScaling(0.1f)
				.RarityScaling(0.1f)
				.PercentFormatting();


			new ItemStat(i, 0.03f, 0.06f, 0.4f, Translations.MainMenu_Guide_46, scAdd, 6, () => ModdedPlayer.Stats.critDamage.GetFormattedAmount(), StatActions.AddCritDamage, StatActions.RemoveCritDamage, StatActions.AddCritDamage) { displayAsPercent = true, roundingCount = 1, valueCap = 10f };//tr
			i++;
			new ItemStat(i, 0.07f, 0.13f, 1f, Translations.ItemDataBase_StatDefinitions_8/*Life on hit*/, scAdd, 4, () => ModdedPlayer.Stats.healthOnHit.GetFormattedAmount(), StatActions.AddLifeOnHit, StatActions.RemoveLifeOnHit, StatActions.AddLifeOnHit)
			{
				displayAsPercent = false,
				roundingCount = 1
			}; //tr
			i++;
			new ItemStat(i, 0.003f, 0.008f, 0.38f, Translations.ItemDataBase_StatDefinitions_9/*Dodge chance*/, scOneMinusMult, 4, () => (1-ModdedPlayer.Stats.getHitChance).ToString("P"), StatActions.AddDodgeChance, StatActions.RemoveDodgeChance, StatActions.AddDodgeChance) { valueCap = 0.35f, displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 5f, 9f, 1.4f, Translations.MainMenu_Guide_17/*Armor*/, scAdd, 3, () => ModdedPlayer.Stats.armor.GetFormattedAmount(), StatActions.AddArmor, StatActions.RemoveArmor, StatActions.AddArmor); //tr
			i++;
			new ItemStat(i, 0.004f, 0.018f, 0.5f, Translations.ItemDataBase_StatDefinitions_10/*Resistance to magic*/, scOneMinusMult, 5, () => ModdedPlayer.Stats.damageFromElite.Value.ToString("P"), StatActions.AddEliteDamageReduction, StatActions.RemoveEliteDamageReduction, StatActions.AddEliteDamageReduction) { valueCap = 0.5f, displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.004f, 0.005f, 0.2f, Translations.MainMenu_Guide_49/*Attack speed*/, scAdd, 6, () => ModdedPlayer.Stats.attackSpeed.GetFormattedAmount(), StatActions.AddAttackSpeed, StatActions.RemoveAttackSpeed, StatActions.AddAttackSpeed) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.015f, 0.025f, 0.25f, Translations.ItemDataBase_StatDefinitions_11/*Experience gain*/, scMult, 7, () => ModdedPlayer.Stats.expGain.GetFormattedAmount(), StatActions.AddExpFactor, StatActions.RemoveExpFactor, StatActions.AddExpFactor) { displayAsPercent = true, roundingCount = 1, valueCap = 1f }; //tr
			i++;
			new ItemStat(i, 1.5f, 2f, 0f, Translations.MainMenu_Guide_120/*Massacre Duration*/, scAdd, 7, () => ModdedPlayer.Stats.maxMassacreTime.GetFormattedAmount(), StatActions.AddMaxMassacreTime, StatActions.RemoveMaxMassacreTime, StatActions.AddMaxMassacreTime) //tr
			{
				roundingCount = 1
			};
			i++;
			new ItemStat(i, 0.014f, 0.018f, 0.3f, Translations.ItemDataBase_StatDefinitions_12/*Spell Damage Increase*/, scAdd, 5, () => ModdedPlayer.Stats.spellIncreasedDmg.GetFormattedAmount(), StatActions.AddSpellDamageAmplifier, StatActions.RemoveSpellDamageAmplifier, StatActions.AddSpellDamageAmplifier)  //tr
			{ 
				displayAsPercent = true,
				roundingCount = 1
			};
			i++;
			new ItemStat(i, 0.014f, 0.018f, 0.3f, Translations.ItemDataBase_StatDefinitions_13/*Melee Damage Increase*/, scAdd, 5, () => ModdedPlayer.Stats.meleeIncreasedDmg.GetFormattedAmount(), StatActions.AddMeleeDamageAmplifier, StatActions.RemoveMeleeDamageAmplifier, StatActions.AddMeleeDamageAmplifier) { displayAsPercent = true, roundingCount = 1, valueCap =2f }; //tr
			i++;
			new ItemStat(i, 0.014f, 0.018f, 0.3f, Translations.ItemDataBase_StatDefinitions_14/*Ranged Damage Increase*/, scAdd, 5, () => ModdedPlayer.Stats.rangedIncreasedDmg.GetFormattedAmount(), StatActions.AddRangedDamageAmplifier, StatActions.RemoveRangedDamageAmplifier, StatActions.AddRangedDamageAmplifier) { displayAsPercent = true, roundingCount = 1, valueCap = 2f }; //tr
			i++;
			new ItemStat(i, 0.5f, 1.1f, 0.8f, Translations.ItemDataBase_StatDefinitions_15/*Base Spell Damage*/, scAdd, 4, () => ModdedPlayer.Stats.spellFlatDmg.GetFormattedAmount(), StatActions.AddspellFlatDmg, StatActions.RemovespellFlatDmg, StatActions.AddspellFlatDmg); //tr
			i++;
			new ItemStat(i, 0.5f, 1.1f, 0.8f, Translations.ItemDataBase_StatDefinitions_16/*Base Melee Damage*/, scAdd, 4, () => ModdedPlayer.Stats.meleeFlatDmg.GetFormattedAmount(), StatActions.AddMeleeDamageBonus, StatActions.RemoveMeleeDamageBonus, StatActions.AddMeleeDamageBonus); //tr
			i++;
			new ItemStat(i, 0.5f, 1.1f, 0.8f, Translations.ItemDataBase_StatDefinitions_17/*Base Ranged Damage*/, scAdd, 4,() => ModdedPlayer.Stats.rangedFlatDmg.GetFormattedAmount(), StatActions.AddRangedDamageBonus, StatActions.RemoveRangedDamageBonus, StatActions.AddRangedDamageBonus); //tr
			i++;
			new ItemStat(i, 0.011f, 0.025f, 0f, Translations.ItemDataBase_StatDefinitions_18/*Energy Per Agility*/, scAdd, 7, () => ModdedPlayer.Stats.maxEnergyFromAgi.GetFormattedAmount(), StatActions.AddmaxEnergyFromAgi, StatActions.RemovemaxEnergyFromAgi, StatActions.AddmaxEnergyFromAgi) { displayAsPercent = false, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.07f, 0.25f, 0f, Translations.ItemDataBase_StatDefinitions_19/*Health Per Vitality*/, scAdd, 7, () => ModdedPlayer.Stats.maxHealthFromVit.GetFormattedAmount(), StatActions.AddmaxHealthFromVit, StatActions.RemovemaxHealthFromVit, StatActions.AddmaxHealthFromVit) { displayAsPercent = false, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.001f, 0.0018f, 0f, Translations.ItemDataBase_StatDefinitions_20/*Spell Damage Per Int*/, scAdd, 7, () => ModdedPlayer.Stats.spellDmgFromInt.GetFormattedAmount(), StatActions.AddspellDmgFromInt, StatActions.RemovespellDmgFromInt, StatActions.AddspellDmgFromInt) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.001f, 0.0018f, 0f, Translations.ItemDataBase_StatDefinitions_21/*Melee Damage Per Strength*/, scAdd,7, () => ModdedPlayer.Stats.meleeDmgFromStr.GetFormattedAmount(), StatActions.AddmeleeDmgFromStr, StatActions.RemovemeleeDmgFromStr, StatActions.AddmeleeDmgFromStr) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.0015f, 0.007f, 0.6f, Translations.ItemDataBase_StatDefinitions_22/*All Recovery*/, scMultPlusOne, 6, () => ModdedPlayer.Stats.allRecoveryMult.GetFormattedAmount(), StatActions.AddHealingMultipier, StatActions.RemoveHealingMultipier, StatActions.AddHealingMultipier) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 1f / 4f, 1f / 4f, 0f, Translations.ItemDataBase_StatDefinitions_23/*PERMANENT PERK POINTS*/, scAdd, 6,()=> ModdedPlayer.instance.MutationPoints.ToString(), null, null, StatActions.PERMANENT_perkPointIncrease); //tr
			i++;
			new ItemStat(i, 10f, 20f, 2f, Translations.ItemDataBase_StatDefinitions_25/*EXPERIENCE*/, scAdd, 5,()=> ModdedPlayer.instance.ExpCurrent.ToString("N")+ Translations.ItemDataBase_StatDefinitions_24/* / */ + ModdedPlayer.instance.ExpGoal.ToString("N"), null, null, StatActions.PERMANENT_expIncrease); //tr
			i++;
			new ItemStat(i, 0.01f, 0.020f, 0.2f, Translations.MainMenu_Guide_109/*Movement Speed*/, scAdd, 6, () => ModdedPlayer.Stats.movementSpeed.GetFormattedAmount(), StatActions.AddMoveSpeed, StatActions.RemoveMoveSpeed, StatActions.AddMoveSpeed) { displayAsPercent = true, roundingCount = 2, valueCap = 0.5f }; //tr
			i++;
			new ItemStat(i, 0.01f, 0.03f, 0.35f, Translations.ItemDataBase_StatDefinitions_26/*Weapon Size*/, scMultPlusOne, 4, () => ModdedPlayer.Stats.weaponRange.GetFormattedAmount(), f => ModdedPlayer.Stats.weaponRange.Multiply(1 + f), f => ModdedPlayer.Stats.weaponRange.Divide(1 + f), null) { displayAsPercent = true, roundingCount = 2, valueCap = 0.4f }; //tr
			i++;
			new ItemStat(i, 0.02f, 0.038f, 0.4f, Translations.ItemDataBase_StatDefinitions_27/*Attack Cost Reduction*/, scOneMinusMult, 3, () => (ModdedPlayer.Stats.attackStaminaCost-1).ToString("P"), f => ModdedPlayer.Stats.attackStaminaCost.Multiply(1 - f), f => ModdedPlayer.Stats.attackStaminaCost.Divide(1 - f)) { displayAsPercent = true, roundingCount = 2, valueCap = 0.75f }; //tr
			i++;
			new ItemStat(i, 0.005f, 0.01f, 0.3f, Translations.MainMenu_Guide_96/*Spell Cost Reduction*/, scOneMinusMult, 6, () => (1 - ModdedPlayer.Stats.spellCost).ToString("P"), f => ModdedPlayer.Stats.spellCost.valueMultiplicative *= 1 - f, f => ModdedPlayer.Stats.spellCost.valueMultiplicative /= 1 - f, f => ModdedPlayer.Stats.spellCost.valueMultiplicative*= 1 - f) { displayAsPercent = true, roundingCount = 2, valueCap = 0.5f }; //tr
			i++;
			new ItemStat(i, 0.0075f, 0.01f, 0.34f, Translations.ItemDataBase_StatDefinitions_28/*Spell Cost to Stamina*/, scOneMinusMult, 2, () => (ModdedPlayer.Stats.SpellCostToStamina).ToString("P"), f => ModdedPlayer.Stats.spellCostEnergyCost.Multiply(1-f), f => ModdedPlayer.Stats.spellCostEnergyCost.Divide(1 - f)) { valueCap = 0.55f, displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.6f, 1f, 0.8f, Translations.MainMenu_Guide_4/*Strength*/, scAdd, 2, () => ModdedPlayer.Stats.strength.GetFormattedAmount(), StatActions.AddStrength, StatActions.RemoveStrength, StatActions.AddStrength); //tr
			i++;
			new ItemStat(i, 0.6f, 1f, 0.8f, Translations.MainMenu_Guide_6/*Agility*/, scAdd, 2, () => ModdedPlayer.Stats.agility.GetFormattedAmount(), StatActions.AddAgility, StatActions.RemoveAgility, StatActions.AddAgility); //tr
			i++;
			new ItemStat(i, 0.6f, 1f, 0.8f, Translations.MainMenu_Guide_8/*Vitality*/, scAdd, 2, () => ModdedPlayer.Stats.vitality.GetFormattedAmount(), StatActions.AddVitality, StatActions.RemoveVitality, StatActions.AddVitality); //tr
			i++;
			new ItemStat(i, 0.6f, 1f, 0.8f, Translations.MainMenu_Guide_10/*Intelligence*/, scAdd, 2, () => ModdedPlayer.Stats.intelligence.GetFormattedAmount(), StatActions.AddIntelligence, StatActions.RemoveIntelligence, StatActions.AddIntelligence); //tr
			i++;
			new ItemStat(i, 1f, 1.75f, 1.35f, Translations.MainMenu_Guide_17/*Armor*/, scAdd, 2, () => ModdedPlayer.Stats.armor.GetFormattedAmount(), StatActions.AddArmor, StatActions.RemoveArmor, StatActions.AddArmor); //tr
			i++;
		new ItemStat(i, 0.0075f, 0.01f, 0.833f, Translations.ItemDataBase_StatDefinitions_29/*Energy Per Second*/, scAdd, 5, () => ModdedPlayer.Stats.energyRecoveryperSecond.GetFormattedAmount(), StatActions.AddEnergyRegen, StatActions.RemoveEnergyRegen, StatActions.AddEnergyRegen) { roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.006f, 0.009f, 0.35f, Translations.ItemDataBase_StatDefinitions_1/*Maximum Life*/, scAdd, 6, () => ModdedPlayer.Stats.maxHealthMult.GetFormattedAmount(), f => ModdedPlayer.Stats.maxHealthMult.valueAdditive += f, f => ModdedPlayer.Stats.maxHealthMult.valueAdditive -= f) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.006f, 0.009f, 0.35f, Translations.ItemDataBase_StatDefinitions_2/*Maximum Energy*/, scAdd, 6, () => ModdedPlayer.Stats.maxEnergyMult.GetFormattedAmount(), f => ModdedPlayer.Stats.maxEnergyMult.valueAdditive+= f, f => ModdedPlayer.Stats.maxEnergyMult.valueAdditive -= f, f => ModdedPlayer.Stats.maxEnergyMult.valueAdditive += f) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.004f, 0.00675f, 0.35f, Translations.MainMenu_Guide_99/*Cooldown Reduction*/, scOneMinusMult, 6, () => (1-ModdedPlayer.Stats.cooldown).ToString("P"), f => ModdedPlayer.Stats.cooldown.valueMultiplicative *= (1 - f), f => ModdedPlayer.Stats.cooldown.valueMultiplicative /= (1 - f), f => ModdedPlayer.Stats.cooldown.valueMultiplicative *= (1 - f)) { displayAsPercent = true, roundingCount = 2, valueCap = 0.5f }; //tr
			i++;
			new ItemStat(i, 0.001f, 0.0018f, 0f, Translations.ItemDataBase_StatDefinitions_30/*Ranged Damage Per Agi*/, scAdd, 7, () => ModdedPlayer.Stats.rangedDmgFromAgi.GetFormattedAmount(), f => ModdedPlayer.Stats.rangedDmgFromAgi.valueAdditive += f, f => ModdedPlayer.Stats.rangedDmgFromAgi.valueAdditive += -f, f => ModdedPlayer.Stats.rangedDmgFromAgi.valueAdditive += f) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.02f, 0.04f, 0.67f, Translations.MainMenu_Guide_39/*Energy on hit*/, scAdd, 4, () => ModdedPlayer.Stats.energyOnHit.GetFormattedAmount(), f => ModdedPlayer.Stats.energyOnHit.valueAdditive += f, f => ModdedPlayer.Stats.energyOnHit.valueAdditive += -f, f => ModdedPlayer.Stats.energyOnHit.valueAdditive += f) { roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.95f, 1.65f, 1f, Translations.PerkDatabase_387/*Block*/, scAdd, 1, () => ModdedPlayer.Stats.block.GetFormattedAmount(), f => ModdedPlayer.Stats.block.valueAdditive += f, f => ModdedPlayer.Stats.block.valueAdditive += -f, f => ModdedPlayer.Stats.block.valueAdditive += f); //tr
			i++;
			new ItemStat(i, 0.01f, 0.02f, 0.3f, Translations.MainMenu_Guide_71/*Projectile speed*/, scAdd, 4, () => ModdedPlayer.Stats.projectileSpeed.GetFormattedAmount(), f => ModdedPlayer.Stats.projectileSpeed.valueAdditive += f, f => ModdedPlayer.Stats.projectileSpeed.valueAdditive += -f, f => ModdedPlayer.Stats.projectileSpeed.valueAdditive += f) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.02f, 0.03f, 0.34f, Translations.MainMenu_Guide_73/*Projectile size*/, scAdd, 4, () => ModdedPlayer.Stats.projectileSize.GetFormattedAmount(), f => ModdedPlayer.Stats.projectileSize.valueAdditive += f, f => ModdedPlayer.Stats.projectileSize.valueAdditive += -f, f => ModdedPlayer.Stats.projectileSize.valueAdditive += f) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 1.5f, 2.25f, 1.21f, Translations.ItemDataBase_StatDefinitions_31/*Melee armor piercing*/, scAdd, 5, () => ModdedPlayer.Stats.TotalMeleeArmorPiercing.ToString(), f => ModdedPlayer.Stats.meleeArmorPiercing.valueAdditive += Mathf.RoundToInt(f), f => ModdedPlayer.Stats.meleeArmorPiercing.valueAdditive += -Mathf.RoundToInt(f), f => ModdedPlayer.Stats.meleeArmorPiercing.valueAdditive += Mathf.RoundToInt(f)); //tr
			i++;
			new ItemStat(i, 0.95f, 1.25f, 1.2f, Translations.ItemDataBase_StatDefinitions_32/*Ranged armor piercing*/, scAdd, 5, () => ModdedPlayer.Stats.TotalRangedArmorPiercing.ToString(), f => ModdedPlayer.Stats.rangedArmorPiercing.valueAdditive += Mathf.RoundToInt(f), f => ModdedPlayer.Stats.rangedArmorPiercing.valueAdditive += -Mathf.RoundToInt(f), f => ModdedPlayer.Stats.rangedArmorPiercing.valueAdditive += Mathf.RoundToInt(f)); //tr
			i++;
			new ItemStat(i, 0.75f, 1f, 1.2f, Translations.ItemDataBase_StatDefinitions_33/*Armor piercing*/, //tr
				scAdd, 5, () => $"M{ModdedPlayer.Stats.TotalMeleeArmorPiercing} R{ModdedPlayer.Stats.TotalRangedArmorPiercing}", f => ModdedPlayer.Stats.allArmorPiercing.valueAdditive += Mathf.RoundToInt(f), f => ModdedPlayer.Stats.allArmorPiercing.valueAdditive += -Mathf.RoundToInt(f), f => ModdedPlayer.Stats.allArmorPiercing.valueAdditive += Mathf.RoundToInt(f));
			i++;
			new ItemStat(i, 0.01f, 0.02f, 0.15f, Translations.MainMenu_Guide_126/*Magic Find*/, scMultPlusOne, 7, () => ModdedPlayer.Stats.magicFind.Value.ToString("P"), StatActions.AddMagicFind, StatActions.RemoveMagicFind, StatActions.AddMagicFind) { displayAsPercent = true, roundingCount = 1, valueCap = 0.25f }; //tr
			i++;
			new ItemStat(i, 0.5f, 0.8f, 0.8f, Translations.PerkDatabase_44/*All attributes*/, scAdd, 4, () =>  //tr
			$"S{ModdedPlayer.Stats.strength} A{ModdedPlayer.Stats.agility} I{ModdedPlayer.Stats.intelligence} V{ModdedPlayer.Stats.vitality}", StatActions.AddAllStats, StatActions.RemoveAllStats, StatActions.AddAllStats);
			i++;
			new ItemStat(i, 0, 0, 0, Translations.ItemDataBase_StatDefinitions_34/*Refund points*/, scAdd, 7,()=>"", f => ModdedPlayer.Respec(), f => ModdedPlayer.Respec(), f => ModdedPlayer.Respec()); //tr
			i++;
			new ItemStat(i, 0.02f, 0.033f, 0.24f, Translations.MainMenu_Guide_111/*Jump Power*/, scAdd, 4,()=> ModdedPlayer.Stats.jumpPower.GetFormattedAmount() ,StatActions.AddJump, StatActions.RemoveJump, StatActions.AddJump) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.052f, 0.13f, 0.35f, Translations.ItemDataBase_StatDefinitions_35/*Headshot Damage*/, scMultPlusOne, 4, () => ModdedPlayer.Stats.headShotDamage.GetFormattedAmount(), f => ModdedPlayer.Stats.headShotDamage.Add(f), f => ModdedPlayer.Stats.headShotDamage.Substract(f), null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.015f, 0.042f, 0.34f, Translations.ItemDataBase_StatDefinitions_36/*Fire Damage*/, scAdd, 4, () => ModdedPlayer.Stats.fireDamage.GetFormattedAmount(), f => ModdedPlayer.Stats.fireDamage.valueAdditive += f, f => ModdedPlayer.Stats.fireDamage.valueAdditive -= f, null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.008f, 0.015f, 0.25f, Translations.ItemDataBase_StatDefinitions_37/*Chance on hit to slow*/, scAdd, 3, () => ModdedPlayer.Stats.chanceToSlow.GetFormattedAmount(), f => ModdedPlayer.Stats.chanceToSlow.valueAdditive += f, f => ModdedPlayer.Stats.chanceToSlow.valueAdditive -= f, null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.006f, 0.01f, 0.25f, Translations.ItemDataBase_StatDefinitions_38/*Chance on hit to bleed*/, scAdd, 3, () => ModdedPlayer.Stats.chanceToBleed.GetFormattedAmount(), f => ModdedPlayer.Stats.chanceToBleed.valueAdditive += f, f => ModdedPlayer.Stats.chanceToBleed.valueAdditive -= f, null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 0.008f, 0.015f, 0.25f, Translations.ItemDataBase_StatDefinitions_39/*Chance on hit to weaken*/, scAdd, 3, () => ModdedPlayer.Stats.chanceToWeaken.GetFormattedAmount(), f => ModdedPlayer.Stats.chanceToWeaken.valueAdditive += f, f => ModdedPlayer.Stats.chanceToWeaken.valueAdditive -= f, null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;
			new ItemStat(i, 1.1f, 1.8f, 1.2f, Translations.MainMenu_Guide_104/*Thorns*/, scAdd, 4, () => ModdedPlayer.Stats.thorns.GetFormattedAmount(), f => ModdedPlayer.Stats.thorns.valueAdditive += f, f => ModdedPlayer.Stats.thorns.valueAdditive -= f, f => ModdedPlayer.Stats.thorns.valueAdditive += f); //tr
			i++;
			new ItemStat(i, 0.035f, 0.145f, 0.1f, Translations.MainMenu_Guide_77/*Projectile pierce chance*/, scAdd, 6, () => ModdedPlayer.Stats.projectilePierceChance.GetFormattedAmount(), f => ModdedPlayer.Stats.projectilePierceChance.valueAdditive += f, f => ModdedPlayer.Stats.projectilePierceChance.valueAdditive += -f, f => ModdedPlayer.Stats.projectilePierceChance.valueAdditive += f) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.04f, 0.11f, 1f, Translations.ItemDataBase_StatDefinitions_40/*Explosive damage*/, scAdd, 6, () => ModdedPlayer.Stats.explosionDamage.GetFormattedAmount(), f => ModdedPlayer.Stats.explosionDamage.Add( f), f => ModdedPlayer.Stats.projectilePierceChance.Substract(f)) { roundingCount = 1, displayAsPercent = true }; //tr
			i++;
			new ItemStat(i, 0.17f, 0.55f, 0.3f, Translations.ItemDataBase_StatDefinitions_41/*Thrown spear damage*/, scAdd, 6, () => ModdedPlayer.Stats.perk_thrownSpearDamageMult.GetFormattedAmount(), f => ModdedPlayer.Stats.perk_thrownSpearDamageMult.Multiply(1+ f), f => ModdedPlayer.Stats.perk_thrownSpearDamageMult.Divide(1+f)) { displayAsPercent = true, roundingCount = 1 }; //tr
			i++;

			//Extra carry items
			i = 1000;
			new ItemStat(i, 9f, 18f, 0f, Translations.ItemDataBase_StatDefinitions_42/*Extra Carried Sticks*/, scAdd, 4, () =>LocalPlayer.Inventory.GetMaxAmountOf(57).ToString(), f => ModdedPlayer.instance.AddExtraItemCapacity(57, Mathf.RoundToInt(f)), f => ModdedPlayer.instance.AddExtraItemCapacity(57, -Mathf.RoundToInt(f)), null); //tr
			i++;
			new ItemStat(i, 7f, 18f, 0f, Translations.ItemDataBase_StatDefinitions_43/*Extra Carried Rocks*/, scAdd, 4, () => LocalPlayer.Inventory.GetMaxAmountOf(53).ToString(), f => ModdedPlayer.instance.AddExtraItemCapacity(53, Mathf.RoundToInt(f)), f => ModdedPlayer.instance.AddExtraItemCapacity(53, -Mathf.RoundToInt(f)), null); //tr
			i++;
			new ItemStat(i, 6f, 18f, 0f, Translations.ItemDataBase_StatDefinitions_44/*Extra Carried Ropes*/, scAdd, 4, () => LocalPlayer.Inventory.GetMaxAmountOf(43).ToString(), f => ModdedPlayer.instance.AddExtraItemCapacity(54, Mathf.RoundToInt(f)), f => ModdedPlayer.instance.AddExtraItemCapacity(43, -Mathf.RoundToInt(f)), null); //tr
			i++;
			new ItemStat(i, 15f, 25f, 0f, Translations.ItemDataBase_StatDefinitions_47/*Extra Carried Drinks*/, scAdd, 4, () => Translations.ItemDataBase_StatDefinitions_46/*Booze: */ + LocalPlayer.Inventory.GetMaxAmountOf((int)MoreCraftingReceipes.VanillaItemIDs.BOOZE).ToString() + Translations.ItemDataBase_StatDefinitions_45/* Soda: */ + LocalPlayer.Inventory.GetMaxAmountOf((int)MoreCraftingReceipes.VanillaItemIDs.SODA), f =>  //tr
			{
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BOOZE, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.SODA, Mathf.RoundToInt(f));
			}, 
			f =>
			{
					ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BOOZE, -Mathf.RoundToInt(f));
					ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.SODA, -Mathf.RoundToInt(f));
			},
				null);
			i++;
			new ItemStat(i, 7f, 20f, 0f, Translations.ItemDataBase_StatDefinitions_48/*Extra Carried Food*/, scAdd, 4,  //tr
				() => "...", f =>
			{
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.GENERICMEAT, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.SMALLGENERICMEAT, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BLACKBERRY, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BLUEBERRY, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.CHOCOLATEBAR, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.LIZARD, Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.RABBITDEAD, Mathf.RoundToInt(f));
			},
			f =>
			{
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.GENERICMEAT, -Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.SMALLGENERICMEAT, -Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BLACKBERRY,- Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.BLUEBERRY, -Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.CHOCOLATEBAR, -Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.LIZARD, -Mathf.RoundToInt(f));
				ModdedPlayer.instance.AddExtraItemCapacity((int)MoreCraftingReceipes.VanillaItemIDs.RABBITDEAD, -Mathf.RoundToInt(f));
			},
			null);
			i++;


			i = 2000;
			new ItemStat(i, 3f, 6f, 0f, Translations.ItemDataBase_StatDefinitions_49/*Black Hole Size*/, scAdd, 6, () => ModdedPlayer.Stats.spell_blackhole_radius.GetFormattedAmount(), f => ModdedPlayer.Stats.spell_blackhole_radius.valueAdditive += f, f => ModdedPlayer.Stats.spell_blackhole_radius.valueAdditive += -f, f => ModdedPlayer.Stats.spell_blackhole_radius.valueAdditive += f) { roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 2f, 3f, 0f, Translations.ItemDataBase_StatDefinitions_50/*Black Hole Lifetime*/, scAdd, 6, () => ModdedPlayer.Stats.spell_blackhole_duration.GetFormattedAmount(), f => ModdedPlayer.Stats.spell_blackhole_duration.valueAdditive += f, f => ModdedPlayer.Stats.spell_blackhole_duration.valueAdditive += -f, f => ModdedPlayer.Stats.spell_blackhole_duration.valueAdditive += f) { roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 5f, 7f, 0f, Translations.ItemDataBase_StatDefinitions_51/*Black Hole Gravitational Force*/, scAdd, 6, () => ModdedPlayer.Stats.spell_blackhole_pullforce.GetFormattedAmount(), f => ModdedPlayer.Stats.spell_blackhole_pullforce.valueAdditive += f, f => ModdedPlayer.Stats.spell_blackhole_pullforce.valueAdditive += -f, f => ModdedPlayer.Stats.spell_blackhole_pullforce.valueAdditive += f) { roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 0.2f, 0.3f, 0.9f, Translations.ItemDataBase_StatDefinitions_52/*Black Hole damage*/, scAdd, 6, () => ModdedPlayer.Stats.spell_blackhole_damage.GetFormattedAmount(), f => ModdedPlayer.Stats.spell_blackhole_damage.valueAdditive += f, f => ModdedPlayer.Stats.spell_blackhole_damage.valueAdditive += -f, f => ModdedPlayer.Stats.spell_blackhole_damage.valueAdditive += f) { roundingCount = 1 }; //tr
			i++;
			new ItemStat(i, 1, 1, 0, Translations.ItemDataBase_StatDefinitions_53/*Stun on hit*/, scAdd, 1, () =>"", f => ModdedPlayer.Stats.i_HammerStun.value = true, f => ModdedPlayer.Stats.i_HammerStun.value = false, null); //tr
			i++;
			new ItemStat(i, 3, 5f, 0, Translations.ItemDataBase_StatDefinitions_54/*Snap Freeze Duration*/, scAdd, 3, () => ModdedPlayer.Stats.spell_snapFreezeDuration.GetFormattedAmount(), f => ModdedPlayer.Stats.spell_snapFreezeDuration.valueAdditive += f, f => ModdedPlayer.Stats.spell_snapFreezeDuration.valueAdditive -= f, null); //tr
			i++;
			new ItemStat(i, 1f, 1.15f, 0, Translations.ItemDataBase_StatDefinitions_55/*Raft Speed*/, scAdd, 4, () => ModdedPlayer.Stats.perk_RaftSpeedMultipier.GetFormattedAmount(), f => ModdedPlayer.Stats.perk_RaftSpeedMultipier.Add(f), f => ModdedPlayer.Stats.perk_RaftSpeedMultipier.Substract(f), null) { displayAsPercent = true, roundingCount = 2 }; //tr
			i++;

			//Sockets
			i = 3000;
			new ItemStat(i++, 1, 3.5f, 0, Translations.ItemDataBase_StatDefinitions_56/*Empty Socket*/, scAdd, 0, null, null, null) { multipier = 0 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_57/*Socket: Crit Chance*/, scAdd, 0,null, f=> ModdedPlayer.Stats.critChance.Add(f), f => ModdedPlayer.Stats.critChance.Substract(f))  //tr
			{ displayAsPercent = true, roundingCount = 1};
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_58/*Socket: Agility*/, scAdd, 0,null, StatActions.AddAgility, StatActions.RemoveAgility, null)  //tr
			{ roundingCount = 0 };
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_59/*Socket: Movement Speed*/, scAdd, 0,null, StatActions.AddMoveSpeed, StatActions.RemoveMoveSpeed, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_60/*Socket: Ranged Damage*/, scAdd, 0,null, StatActions.AddRangedDamageAmplifier, StatActions.RemoveRangedDamageAmplifier, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_61/*Socket: Ranged Armor Piercing*/, scAdd, 0,null, f => ModdedPlayer.Stats.rangedArmorPiercing.valueAdditive += Mathf.RoundToInt(f), f => ModdedPlayer.Stats.rangedArmorPiercing.valueAdditive += -Mathf.RoundToInt(f), null) { roundingCount = 0 }; //tr

			//3006
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_62/*Socketed Shark Tooth: Attack Speed*/, scAdd, 0,null, StatActions.AddAttackSpeed, StatActions.RemoveAttackSpeed, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_63/*Socketed Shark Tooth: Strength*/, scAdd, 0,null, StatActions.AddStrength, StatActions.RemoveStrength, null) { roundingCount = 0 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_64/*Socketed Shark Tooth: Damage Reduction*/, scOneMinusMult, 0,null, StatActions.AddDamageReduction, StatActions.RemoveDamageReduction, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_65/*Socketed Shark Tooth: Melee Damage*/, scAdd, 0,null, StatActions.AddMeleeDamageAmplifier, StatActions.RemoveMeleeDamageAmplifier, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_66/*Socketed Shark Tooth: Melee Armor Piercing*/, scAdd, 0,null, f => ModdedPlayer.Stats.meleeArmorPiercing.valueAdditive += Mathf.RoundToInt(f), f => ModdedPlayer.Stats.meleeArmorPiercing.valueAdditive += -Mathf.RoundToInt(f), null) { roundingCount = 0 }; //tr

			//30011
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_67/*Socket: Cooldown Reduction*/, scOneMinusMult, 0,null, f => ModdedPlayer.Stats.cooldown.valueMultiplicative *= (1 - f), f => ModdedPlayer.Stats.cooldown.valueMultiplicative /= (1 - f), null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_68/*Socket: Intelligence*/, scAdd, 0,null, StatActions.AddIntelligence, StatActions.RemoveIntelligence, null) { roundingCount = 0 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_69/*Socket: Spell Cost Reduction*/, scOneMinusMult, 0,null, f => ModdedPlayer.Stats.spellCost.valueMultiplicative *= 1 - f, f => ModdedPlayer.Stats.spellCost.valueMultiplicative /= 1 - f, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_70/*Socket: Spell Damage*/, scAdd, 0,null, StatActions.AddSpellDamageAmplifier, StatActions.RemoveSpellDamageAmplifier, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_71/*Socket: Energy On Hit*/, scAdd, 0,null, f => ModdedPlayer.Stats.energyOnHit.valueAdditive += f, f => ModdedPlayer.Stats.energyOnHit.valueAdditive += -f, null) { roundingCount = 2, multipier = 0.02f }; //tr

			//3016
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_72/*Socket: Experience Gain*/, scMultPlusOne, 0,null, StatActions.AddExpFactor, StatActions.RemoveExpFactor, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_73/*Socket: Vitality */, scAdd, 0,null, StatActions.AddVitality, StatActions.RemoveVitality, null) { roundingCount = 0 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_74/*Socket: Magic Find*/, scAdd, 0,null, f => StatActions.AddMagicFind(f), f => StatActions.AddMagicFind(-f), null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_75/*Socket: All Healing*/, scMultPlusOne, 0,null, StatActions.AddHealingMultipier, StatActions.RemoveHealingMultipier, null) { displayAsPercent = true, roundingCount = 1, multipier = 1.25f }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_76/*Socket: Life Per Second*/, scAdd, 0,null, StatActions.AddHPRegen, StatActions.RemoveHPRegen, null) { roundingCount = 1, multipier = 0.04f }; //tr

			//3021
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_77/*Socket: Maximum Health */, scMultPlusOne, 0,null, f => ModdedPlayer.Stats.maxHealthMult.valueMultiplicative *= 1 + f, f => ModdedPlayer.Stats.maxHealthMult.valueMultiplicative /= 1 + f, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_78/*Socket: Armor */, scAdd, 0,null, StatActions.AddArmor, StatActions.RemoveArmor, null) { roundingCount = 0, multipier = 10f }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_79/*Socket: Resistance To Magic*/, scOneMinusMult, 0,null, StatActions.AddEliteDamageReduction, StatActions.RemoveEliteDamageReduction, null) { displayAsPercent = true, roundingCount = 1 }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_80/*Socket: Crit Damage*/, scMultPlusOne, 0,null, f => ModdedPlayer.Stats.critDamage.Add(f), f => ModdedPlayer.Stats.critDamage.Substract(f), null) { displayAsPercent = true, roundingCount = 1, multipier = 5f }; //tr
			new ItemStat(i++, 0,0,1, Translations.ItemDataBase_StatDefinitions_81/*Socket: Thorns*/, scAdd, 0,null, f => ModdedPlayer.Stats.thorns.valueAdditive += f, f => ModdedPlayer.Stats.thorns.valueAdditive -= f, null) { roundingCount = 0, multipier = 5f }; //tr
		}
	}
}