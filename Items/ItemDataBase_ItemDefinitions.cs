﻿using System.Linq;
using System.Collections.Generic;
using ChampionsOfForest.Items;
using ChampionsOfForest.Items.Sets;
using ChampionsOfForest.Localization;
using ChampionsOfForest.Player;

using static ChampionsOfForest.ItemDataBase.Stat;

namespace ChampionsOfForest
{
    public static partial class ItemDataBase
    {
        static Dictionary<BaseItem.ItemType, List<List<string>>> randomitemNamesPool;

        static void SetNamesPool()
        {
            randomitemNamesPool = new Dictionary<BaseItem.ItemType, List<List<string>>>();


			//Shield, Quiver, Helmet, Boot, Pants, ChestArmor, ShoulderArmor, Glove, Bracer, Amulet, Ring, SpellScroll



			//Weapon, Other, Material
			//}
		}

        static List<List<string>> GetQuiverNames()
		{
			List<string> brokenQualityNames = new List<string>()
			{
				"Potato Sack",
				"Cracked Buckler",
				"Fractured Aegis",
				"Rusted Battered Shield",
				"Shattered Guard",
				"Tattered Protector",
				"Warped Kite Shield",
				"Decayed Bulwark",
				"Dilapidated Defender",
				"Fragmented Ward",
			};

			List<string> commonQualityNames = new List<string>()
			{
				"Iron Shield",
				"Wooden Buckler",
				"Militia Guard",
				"Footman's Protection",
				"Simple Protector",
				"Recruit's Shield",
				"Basic Bulwark",
				"Ordinary Defender",
				"Standard Kite Shield",
				"Copper Guard",
			};

			List<string> uncommonQualityNames = new List<string>()
			{
				"Reinforced Buckler",
				"Knight's Guard",
				"Polished Defender",
				"Steel Bulwark",
				"Hardwood Shield",
				"Sentinel's Guard",
				"Reliable Protector",
				"Sturdy Aegis",
				"Shieldbearer's Wall",
				"Bronze-Rimmed Ward",
			};

			List<string> magicQualityNames = new List<string>()
			{
				"Frostbound Shield",
				"Ember Ward",
				"Arcane Defender",
				"Enchanted Bulwark",
				"Whispering Protector",
				"Shield of Runes",
				"Spellguard Barrier",
				"Gleaming Aegis",
				"Stormcaller's Shield",
				"Mystic Bulwark",
			};

			List<string> rareQualityNames = new List<string>()
			{
				"Dragonscale Shield",
				"Sunfire Aegis",
				"Warden's Resolve",
				"Shadowforged Bulwark",
				"Astral Defender",
				"Thunderous Guard",
				"Shield of Ancient Kings",
				"Celestial Protection",
				"Mithril-Bound Guardian",
				"Wyvern Wing Shield",
			};

			List<string> uniqueQualityNames = new List<string>()
			{
				"Bastion of the Fallen Hero",
				"Moonlight Reflection",
				"Stormheart Shield",
				"Guardian of Lost Souls",
				"The Unbroken Vow",
				"Earthshaker's Wall",
				"Twilight's Embrace",
				"Dawnbreaker Shield",
				"Defiance of the Phoenix",
				"The Immovable Object",
			};

			List<string> legendaryQualityNames = new List<string>()
			{
				"Aegis of the Immortal Emperor",
				"Bulwark of the Star Forger",
				"The Divine Protector",
				"Shield of Eternal Victory",
				"Godslayer's Defender",
				"Dragonlord's Guardian",
				"The Titanic Wall",
				"Salvation's Embrace",
				"Avatar of Protection",
				"The World's Edge",
			};

			List<string> mythicQualityNames = new List<string>()
			{
				"Cosmos Barrier",
				"The Void's Edge",
				"Shield of Infinite Worlds",
				"Reality's Guardian",
				"Divinity's Embrace",
				"The Primordial Aegis",
				"Eternity's Bulwark",
				"Celestial Embodiment",
				"The Universal Constant",
				"Transcendence",
			};


			// put all the names into a single list
			List<List<string>> rarityNames = new List<List<string>>()
			{
				brokenQualityNames,
				commonQualityNames,
				uncommonQualityNames,
				magicQualityNames,
				rareQualityNames,
				uniqueQualityNames,
				legendaryQualityNames,
				mythicQualityNames
			};
			return rarityNames;
		}

		static List<List<string>> GetShieldNames()
        {
            // define names for each of the rarities
            List<string> brokenQualityNames = new List<string>()
			{
				"Splintered Barrier",
				"Cracked Buckler",
				"Fractured Aegis",
				"Rusted Battered Shield",
				"Shattered Guard",
				"Tattered Protector",
				"Warped Kite Shield",
				"Decayed Bulwark",
				"Dilapidated Defender",
				"Fragmented Ward",
			};

            List<string> commonQualityNames = new List<string>()
			{
				"Iron Shield",
				"Wooden Buckler",
				"Militia Guard",
				"Footman's Protection",
				"Simple Protector",
				"Recruit's Shield",
				"Basic Bulwark",
				"Ordinary Defender",
				"Standard Kite Shield",
				"Copper Guard",
			};

            List<string> uncommonQualityNames = new List<string>()
			{
				"Reinforced Buckler",
				"Knight's Guard",
				"Polished Defender",
				"Steel Bulwark",
				"Hardwood Shield",
				"Sentinel's Guard",
				"Reliable Protector",
				"Sturdy Aegis",
				"Shieldbearer's Wall",
				"Bronze-Rimmed Ward",
			};

            List<string> magicQualityNames = new List<string>()
			{
				"Frostbound Shield",
				"Ember Ward",
				"Arcane Defender",
				"Enchanted Bulwark",
				"Whispering Protector",
				"Shield of Runes",
				"Spellguard Barrier",
				"Gleaming Aegis",
				"Stormcaller's Shield",
				"Mystic Bulwark",
			};

            List<string> rareQualityNames = new List<string>()
			{
				"Dragonscale Shield",
				"Sunfire Aegis",
				"Warden's Resolve",
				"Shadowforged Bulwark",
				"Astral Defender",
				"Thunderous Guard",
				"Shield of Ancient Kings",
				"Celestial Protection",
				"Mithril-Bound Guardian",
				"Wyvern Wing Shield",
			};

            List<string> uniqueQualityNames = new List<string>()
			{
				"Bastion of the Fallen Hero",
				"Moonlight Reflection",
				"Stormheart Shield",
				"Guardian of Lost Souls",
				"The Unbroken Vow",
				"Earthshaker's Wall",
				"Twilight's Embrace",
				"Dawnbreaker Shield",
				"Defiance of the Phoenix",
				"The Immovable Object",
			};

            List<string> legendaryQualityNames = new List<string>()
            {
                "Aegis of the Immortal Emperor",
                "Bulwark of the Star Forger",
                "The Divine Protector",
                "Shield of Eternal Victory",
                "Godslayer's Defender",
                "Dragonlord's Guardian",
                "The Titanic Wall",
                "Salvation's Embrace",
                "Avatar of Protection",
                "The World's Edge",
            };

            List<string> mythicQualityNames = new List<string>()
            {
                "Cosmos Barrier",
                "The Void's Edge",
                "Shield of Infinite Worlds",
                "Reality's Guardian",
                "Divinity's Embrace",
                "The Primordial Aegis",
                "Eternity's Bulwark",
                "Celestial Embodiment",
                "The Universal Constant",
                "Transcendence",
            };


            // put all the names into a single list
            List<List<string>> rarityNames = new List<List<string>>()
            {
                brokenQualityNames,
                commonQualityNames,
                uncommonQualityNames,
                magicQualityNames,
                rareQualityNames,
                uniqueQualityNames,
                legendaryQualityNames,
                mythicQualityNames
            };
            return rarityNames;
        }


        public static void PopulateItems()
        {
            new BaseItem(new int[][]
            {
                new int[] { 34 },
                new int[] {43,0,39,59,67 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_1/*Broken Flip-Flops*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_2/*A pair of damaged shoes. Judging by their condition, i can imagine what happened to their owner.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_3/*Worn by one of the passengers of the plane that Eric also flew in.*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
            {
                new int[] {34 },
                new int[] {34,0,40,41 },
                new int[] {43 },
                new int[] {43,0 ,67 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_4/*Old Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_5/*A pair of old boots. They must have been lying here for ages.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_6/*Found on the Peninsula, but judging by their condition, they belong neither to a plane passenger nor a cannibal.*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
          {
                new int[] {34 },
                new int[] {34,40,41 },
                new int[] {43,3,2 },
                new int[] {43,65,67 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_7/*Damaged Leather Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_8/*A pair of leather boots. They look good and have only some scratches.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_9/*They arrived to the Peninsula the same way Eric did. Since they were in a baggage, they avoided a lot of damage.*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
          {
                new int[] {34 },
                new int[] {3,2 },
                new int[] {43,3,2,1,4 },
                new int[] {43,65,67 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_10/*Sturdy Leather Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_11/*A pair of leather boots. They are in a very good condition.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_12/*They arrived to the Peninsula the same way Eric did. Eric found them undamaged in their original box. They still had a pricetag - $419,99.*/, //tr
                Rarity = 2,
                minLevel = 7,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
          {
              new int[] {34 },
                new int[] {34,39,41,11,57 },
                new int[] {-1},
                new int[] {16,7,8 },
                new int[] {43,65,67 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_13/*Damaged Army Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_14/*Sturdy, hard, resistant but damaged boots.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_15/*They look modern, almost too modern for everything here.*/, //tr
                Rarity = 3,
                minLevel = 4,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
          {
                new int[] {34 },
                new int[] {34,3,2,11 },
                new int[] {-1},
                new int[] {16,7,8 },
                new int[] {43,65,67 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_16/*Army Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_17/*Sturdy, hard, resistant boots.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_15/*They look modern, almost too modern for everything here.*/, //tr
                Rarity = 4,
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
          {
              new int[] {25,22 },
              new int[] {11,1,3,17 },
              new int[] {22,1,3,17 },
              new int[] {28,1,65 },
              new int[] {-1 },
              new int[] {5,6,16,31,7,8,9,10 },
              new int[] {5,6,16,31,7,8,9,10 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_18/*Armsy Skin Footwear*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_19/*Severed armsy legs, with all of their insides removed. All thats left is dried mutated skin.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_20/*Armsy, the second heaviest of the mutants needs very resistant skin. It often drags its legs on the ground when it moves. The skin on their legs grew very thick, and has bone tissue mixed with skin tissue.*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            }.DropSettings_OnlyArmsy();
            new BaseItem(new int[][]
     {
                new int[] {42,0 },
                new int[] {40,41,26,25,67 },
                new int[] {43,65,0 },
     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_21/*Finger Warmer*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_22/*A little glove to keep your fingers warm and cozy.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_23/*Made of wool.*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
            {
                new int[] {39,40,41,42,43,24,25,26 },
                new int[] {39,40,41,42,43,24,25,26,44 },
                new int[] {43,0,7,0,5,6,8,0,21,22,23,16,67 },
                new int[] {43,0,7,0,5,6,8,0,0,0,0,21,22,23,65,66,67 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_24/*Thick Rubber Glove*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_25/*A glove that helps get a better grip.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_23/*Made of wool.*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
            {
                new int[] {39,40,41,42},
                new int[] {39,40,41,42},
                new int[] {1,2,3,4,5,6,7},
                new int[] {0,18,14},
                new int[] {-1 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_26/*Tribal Glove*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_27/*Offers medicore protection.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_28/*Glove made out of thin bones, some may possibly be from a human.*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
         {
                new int[] {1,2,4,6,8,9},
                new int[] {1,11,65},
                new int[] {21,22,23},
                new int[] {12,13,15},
                new int[] {12,13,24,25,26},
                new int[] {24,25,26,44,35},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_29/*Tribe Leader Glove*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_30/*A glove that offers little protection but a lot of offensive stats.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_31/*A glove made of bones, some have engravings of crosses.*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
      {
                new int[] {43,0 },
                new int[] {43,39,40,41,42 },
      })
            {
                name = Translations.ItemDataBase_ItemDefinitions_32/*Worn Shorts*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_33/*Some protection for legs.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_34/*Short, made out of cheap thin fabric, and on top of that they are damaged. But its better than nothing.*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new int[][]
          {
                new int[] {1000,1001,1002},
                new int[] {1000,1001,1002,1003,1004,0,0,0,0},
                new int[] {8,9,0,0,0,0 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_35/*Cargo Shorts*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_36/*No protection at all but they allow to carry more items.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_37/*They are ugly as hell tho*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new int[][]
                    {
                new int[] {5 },
                new int[] {43,16,0,41 },
                new int[] {39,40,41,42,43,44,0,0,0,0,0,0,1003,1004},
                    })
            {
                name = Translations.ItemDataBase_ItemDefinitions_38/*Passenger's Jacket*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_39/*It's a little torn. */, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_40/*This jacket was worn by Preston A. the 34th passenger on the plane. Eric talked to him at the airport. Guy was odd, and now he's dead.*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {1,2,3,4,5,6,65},
                new int[] {43,16,0,41,3,2,1 },
                new int[] {6,7,8,9,10,16,17,31, },
                new int[] {39,40,41,42,43,44,0,0,0,0,0,0,1003,1004},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_41/*Leather Jacket*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_42/*Offers little protection*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_43/*This jacket was in a baggage of one of the plane passengers*/, //tr
                Rarity = 1,
                minLevel = 4,
                maxLevel = 7,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {5,3,1 },
                new int[] {5 },
                new int[] {16},
                new int[] {7,11 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_44/*Boar Skin Armor*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_45/*It's made from a skin of a huge individual. It's heavy and thick, and surely can protect from attacks of weaker enemies.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_46/*Boar, one of the animals on the peninsula, is rather rare and it's skin is very durable.*/, //tr
                Rarity = 1,
                minLevel = 4,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {5,3,4,2,1 },
                new int[] {14,0,0,0 },
                new int[] {6,8,9},
                new int[] {6,8,9},
                new int[] {12,13,0,65,66 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_47/*Crocodile Skin Armor*/, //tr
                Rarity = 2,
                minLevel = 7,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            BaseItem baseItem1 = new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {16 },
                new int[] {18,17,16},
                new int[] {11},
                new int[] {65,0},
                new int[] {12,13,1,2,3,4},
                new int[] {25,22,0},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_48/*Plate armour*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            baseItem1.PossibleStats[1][0].Multipier = 2.5f;
            new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {65 },
                new int[] {16},
                new int[] {16,43},
                new int[] {16,0,43},
                new int[] {6,8,9},
                new int[] {45,43,39,42},
                new int[] {7,10,11,17,18,31,66},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_49/*Bear Skin Armor*/, //tr
                Rarity = 3,
                minLevel = 7,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {12,13},
                new int[] {13,23,26},
                new int[] {23,26},
                new int[] {34,2,2},
                new int[] {15,14},
                new int[] {16,23,4,5,6,66},
                new int[] {16,23,4,5,6,0,0,0,0},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_50/*Archer's Gear*/, //tr
                Rarity = 5,
                minLevel = 7,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {5 },
                new int[] {23,26,2 },
                new int[] {23,26 },
                new int[] {12,13},
                new int[] {13,23,26},
                new int[] {23,26},
                new int[] {34,2,2},
                new int[] {15,14},
                new int[] {16,23,4,5,6},
                new int[] {45,46,66},
                new int[] {27,48},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_51/*Hazard's Gear*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
          {
                new int[] {47 },
                new int[] {4,29 },
                new int[] {4,29 },
                new int[] {4,29 },
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_52/*Mysterious robe*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_53/*Magic flows through the entirety of this object. It's made out of unknown material*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_54/*Robe looks like it was created yesterday, but its older than the oldest of mankinds' civilizations. Simply looking at it sends chills down the spine.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_55/*Empowers cataclysm. The vortex turns blue, damage is increased, freezes enemies */, //tr
                Rarity = 7,
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
                onEquip = () => ModdedPlayer.Stats.spell_cataclysmArcane.value = true,
                onUnequip = () => ModdedPlayer.Stats.spell_cataclysmArcane.value = false
            };
            new BaseItem(new int[][]
                    {
                new int[] {39,40,41,42,44,8,14,49 },
                new int[] {39,40,41,42,44,8,14,49 },
                new int[] {0,62,63,64},
                new int[] {1,0,65},
                    })
            {
                name = Translations.ItemDataBase_ItemDefinitions_56/*Rusty Longsword*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_57/*A long, very heavy sword. Edge got dull over time. Still, it's in a condition that allows me to slice some enemies in half.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_58/*The sword appears to be from medieval ages, through it's not. It was made a lot later. It never was used as a weapon in battles, because it was merely a decoration.*/, //tr
                Rarity = 3,
                minLevel = 13,
                maxLevel = 15,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
            };
            new BaseItem(new int[][]
         {
                new int[] {25 },
                new int[] {25 ,62,63,64},
                new int[] {6,49},
                new int[] {22,0,25,1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {39,40,41,42,44,8,18,65 },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_59/*Longsword*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_60/*Sharp and long*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_61/*The sword is in perfect contidion.*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 27,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
            };
            new BaseItem(new int[][]
         {
                new int[] {25 },
                new int[] {6,49},
                new int[] {22,0,25,1,2,3,4},
                new int[] {1,2,3,4,8},
                new int[] {1,2,3,4,8},
                new int[] {5,6,45,46,16,8},
                new int[] {39,40,41,42,44,8 },
                new int[] {39,40,41,42,44,8,62,63,64 },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_62/*Full Metal Sword*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_63/*It's sooo big...*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_64/*A normal human cannot lift this.*/, //tr
                Rarity = 6,
                minLevel = 50,
                maxLevel = 52,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
            };
            new BaseItem(new int[][]
         {
                new int[] {25,1,3 },
                new int[] {25,22,1,3 },
                new int[] {25,22,0,0,0,0 },
                new int[] {49 },
                new int[] {14 },
                new int[] {14,1 },
                new int[] {14,31,49 },
                new int[] {14,18,49 },
                new int[] {38,36,1,3,4,5,6,16 ,62,63,64},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_65/*The Leech*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_66/*Hey where did my health g- oh it's back...*/, //tr
                Rarity = 6,
                minLevel = 60,
                maxLevel = 61,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
            };
            new BaseItem(new int[][]
            {
                new int[] {1,2,3,4 },
                new int[] {1,2,3,15,4,0,0,0 },
                new int[] {12,13,1,2,3,4,5, },
                new int[] {18,16,23,26,19 },
                new int[] {18,16,23,26 },
                new int[] {34,44,45,46 },
                new int[] {2,23,26},
                new int[] {2,23,26,51},
                new int[] {2,23,26,20,16,15,60},
                new int[] {52,66,60,0,0},
                new int[] {66},
                 })
            {
                name = Translations.ItemDataBase_ItemDefinitions_67/*Smokey's Sacred Quiver*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_68/*SmokeyTheBear died because he never used this item.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_69/*Smokey was the friend of allmighty Hazard, who can materialize any kind of weapon at the snap of his fingers. Hazard remebered Smokey's favourite playstyle and he gave him this as a gift to purge the sh** out of mutants.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_70("250%", "500%")/*Crossbows operate at <color=gold>250%</color> speed and deal 400% increased damage*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => { ModdedPlayer.Stats.i_SmokeyCrossbowQuiver.value = true; ModdedPlayer.Stats.perk_crossbowDamageMult.Multiply(5); },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.i_SmokeyCrossbowQuiver.value = false;
                    ModdedPlayer.Stats.perk_crossbowDamageMult.Divide(5);
                },
            };
            new BaseItem(new int[][]
         {
                new int[] {0,42 },
                new int[] {50 },
                new int[] {43,16 },
                new int[] {1,0 },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_71/*Broken shield*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new int[][]
    {
                new int[] {1,2,3,4,0,42 },
                new int[] {0,42 },
                new int[] {50 },
                new int[] {1,0 },
                new int[] {43,16 },
                new int[] {43,16,0,0 },
    })
            {
                name = Translations.Item_1/*Shield*/, //tr
                Rarity = 1,
                minLevel = 3,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new int[][]
     {
                new int[] {16},
                new int[] {16},
                new int[] {16},
                new int[] {16,0},
                new int[] {16,0,45,46},
                new int[] {0,42,11 },
                new int[] {50 },
     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_72/*Tower Shield*/, //tr
                Rarity = 3,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new int[][]
                  {
                new int[] {5,6,7,8,0,0,0},
                new int[] {43},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_73/*Broken Leather Shoulder Armor*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new int[][]
         {
                new int[] {5,6,7,8},
                new int[] {43},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_74/*Leather Shoulder Armor*/, //tr
                Rarity = 1,
                minLevel = 2,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new int[][]
         {
                new int[] {16},
                new int[] {1,2,3,4},
                new int[] {17},
                new int[] {17},
                new int[] {8,9,49,47},
                new int[] {8,9,49,47},
                new int[] {16,18,11,34},
                new int[] {37,34},
                new int[] {-1},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_75/*Phase Pauldrons*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_76/*The distance of blink is increased by <color=gold>40</color> meters, and blink now hits everything that you teleported through*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
                onEquip = () => { ModdedPlayer.Stats.spell_blinkRange.Add(40); ModdedPlayer.Stats.spell_blinkDamage.Add(60); },
                onUnequip = () => { ModdedPlayer.Stats.spell_blinkRange.Substract(40); ModdedPlayer.Stats.spell_blinkDamage.Substract(60); },
            };
            new BaseItem(new int[][]
                     {
                new int[] {39,49,5,6,7,8,0,0,0},
                new int[] {43,0},
                new int[] {43},
                     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_77/*MAGA Cap*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_78/*Wearing this item channels the power of D.Trump to you*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_79/*... or does it?*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new int[][]
            {
                new int[] {2000},
                new int[] {2001},
                new int[] {2002},
                new int[] {2003},
                new int[] {16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {1,2,3,4},
                new int[] {21,6},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_80/*Hubble's Vision*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_81/*Wearing this item empowers your black hole spell*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_82/*Man, fuck gravity.*/, //tr
                Rarity = 6,
                minLevel = 10,
                maxLevel = 11,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new int[][]
                  {
                new int[] {39,40,41,42,43,12,13},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_83/*Broken Loop*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };
            new BaseItem(new int[][]
            {
                new int[] {-1},
                new int[] {39,40,41,42,43,12,13},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_84/*Loop*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };
            new BaseItem(new int[][]
            {
                new int[] {63},
                new int[] {-1},
                new int[] {39,40,41,42,43,12,13,5,6,7,8,9,12,13,15,16,17,18,10,11},
                new int[] {1,2,3,4,21,22,23,24,25,26,43,12,13},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_85/*Toxic Ring*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_87/*What the fuck did you just fucking say about me, you little bitch? I'll have you know I graduated top of my class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You're fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little /'clever\' comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn't, you didn't, and now you're paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You're fucking dead, kiddo."*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };
            new BaseItem(new int[][]
                     {
                new int[] {39,40,41,42,43},
                new int[] {-1},
                new int[] {-1},
                     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_88/*Scarf*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
            };
            new BaseItem(new int[][]
                    {
                new int[] {39,40,41,42,43},
                new int[] {43},
                    })
            {
                name = Translations.ItemDataBase_ItemDefinitions_89/*Damaged Bracer*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
          {
                new int[] {39,40,41,42,43},
                new int[] {43},
                new int[] {16},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_90/*Worn Bracer*/, //tr
                Rarity = 1,
                minLevel = 3,
                maxLevel = 10,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
          {
                new int[] {39,40,41,42,43},
                new int[] {16},
                new int[] {-1},
                new int[] {5,6,7,8,9,10},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_91/*Leather Bracer*/, //tr
                Rarity = 2,
                minLevel = 4,
                maxLevel = 10,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(94),
            };
            new BaseItem(new int[][]
                     {
                new int[] {32},
                     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_92/*Greater Mutated Heart*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_93/*Can be consumed by right clicking it*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = true,
                StackSize = 100,
                type = BaseItem.ItemType.Other,
                icon = Res.ResourceLoader.GetTexture(105),
            };
            new BaseItem(new int[][]
            {
                new int[] {33},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_94/*Lesser Mutated Heart*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_93/*Can be consumed by right clicking it*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 6,
                CanConsume = true,
                StackSize = 1,
                type = BaseItem.ItemType.Other,
                icon = Res.ResourceLoader.GetTexture(105),
            };
            new BaseItem(new int[][]
        {
                new int[] {1,2},
                new int[] {1,2,3,5,6},
                new int[] {65},
                new int[] {-1},
                new int[] {-1},
                new int[] {53,54},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_95/*Spiked ring*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_96/*Armor piercing for either melee or ranged weapons*/, //tr
                Rarity = 4,
                minLevel = 10,
                maxLevel = 16,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };

            new BaseItem(new int[][]
            {
                new int[] {1,2,3,4,5,6},
                new int[] {1,2,3,4,5,6,65},
                new int[] {-1},
                new int[] {-1 },
                new int[] {1,2,3,4,21,22,23,24,25,26,18,16},
                new int[] {55},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_97/*Piercer*/, //tr
                Rarity = 4,
                minLevel = 11,
                maxLevel = 15,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101),
            };
            new BaseItem(new int[][]
            {
                new int[] {59 },
                new int[] {21 },
                new int[] {34,0,40,41 },
                new int[] {16,34},
                new int[] {12 },
                new int[] {-1 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_98/*Moon Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_99/*A pair of boots from the moon.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_100/*It is said that the wearer will not take fall damage while wearing these boots and will jump like on the moon, I wouldn't trust it tough.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85), //icon ids, don't worry about that
            };
            new BaseItem(new int[][]
            {
                new int[] {1},
                new int[] {1,57,18,36},
                new int[] {12,13,1},
                new int[] {22,25,1},
                new int[] {22,25,1},
                new int[] {50,53,35},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_101/*Golden Ring of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_103/*A Golden Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new int[][]
            {
                new int[] {3},
                new int[] {3,31,6,7,8,9},
                new int[] {5,3,41,45},
                new int[] {7,10,31,14},
                new int[] {14,16,11,17},
                new int[] {65,57,45,46},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_104/*Golden Ring of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_103/*A Golden Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
                new int[] {2},
                new int[] {12,13,8,9, },
                new int[] {15,18,34,36},
                new int[] {23,48,54,26,59,55,16},
                new int[] {6,57,2,34,},
                new int[] {52,66,51,2,23}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_105/*Golden Ring of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_103/*A Golden Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new int[][]
            {
                new int[] {4},
                new int[] {12,13,21,24,6},
                new int[] {12,13,21,24},
                new int[] {19,47,49},
                new int[] { 37,38,4,24,61,44},
                new int[] { 57,44,6,24,21,47}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_106/*Golden Ring of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_103/*A Golden Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            //Silver Rings---------------------------------------------------------------------------
            new BaseItem(new int[][]
             {
                new int[] {1},
                new int[] {22,25,12,13},
                new int[] {35,50,53},
                new int[] {20,0,0,0}
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_107/*Silver Ring of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_108/*A Silver Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {3},
                new int[] {7,10,31,5, },
                new int[] {11,17,0},
                new int[] {14,16,45},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_109/*Silver Ring of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_108/*A Silver Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {2},
                new int[] {12,13,51,8,9, },
                new int[] {15,18,34,36,0},
                new int[] {23,48,54,26,6,57,0,0,0 }
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_110/*Silver Ring of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_108/*A Silver Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {4},
                new int[] { 12, 13, 21, 24,12, 13,21,24,0},
                new int[] {19,47,49,6},
                new int[] { 57,37,38,0},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_111/*Silver Ring of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_108/*A Silver Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            //Steel Rings-------------------------------------------------------------------
            new BaseItem(new int[][]
             {
                 new int[] {1},
                 new int[] {12,13,65},
                 new int[] {22,25, 57,35,50,53,20},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_112/*Steel Ring of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_113/*A Steel Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {3},
                new int[] {7,10,31,5,65},
                new int[] {14,16, 45,11,17,0},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_114/*Steel Ring of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_113/*A Steel Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {2},
                new int[] {8,9, 12,13,51,57},
                new int[] {23,54,26,59,18,34},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_115/*Steel Ring of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_113/*A Steel Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 10,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
             {
                new int[] {4},
                new int[] {12,13,21,24,6},
                new int[] {19,47,49,57,37,38,21,24},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_116/*Steel Ring of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_113/*A Steel Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            //One Ring to rule them all----------------------------------------------------------

            new BaseItem(new int[][]
             {
                new int[] {1,3,2,4},
                new int[] {12,13},
                new int[] {22,25,30,},
                new int[] {35,50,53,20},
                new int[] {5,28},
                new int[] {7,10,31},
                new int[] {11,17,14,16 },
                new int[] {8,9,27,45},
                new int[] {51,52,66},
                new int[] {15,18,34,36,57},
                new int[] {23,48,54,26},
                new int[] {21,24},
                new int[] {19,47,49,57,6},
                new int[] {29,37,38,57},
                new int[] {65},
                new int[] {-1},
                new int[] {-1},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_117/*The One Ring To Rule Them All*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_118/*An Ancient magical Ring of great power.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_119/*It looks like and ordinay ring, but a strange energy is surrounding it. The Ring is said to have been found inside a volcanic rock by an archeologist, who went mad and isolated himself on the peninsula many years ago. But that's just a fairy tale, ring?*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_120/*Attracts unwanted attention of an unknown entity.*/, //tr
                Rarity = 7,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 20,
                maxLevel = 30,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            //Golden Lockets---------------------------------------------------------------------

            new BaseItem(new int[][]
            {
            new int[] {1},
            new int[] {12,13},
            new int[] {22,25,57,},
            new int[] {35,50,53},
            new int[] {65,1,57,47,34,36,18}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_121/*Golden Locket of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_123/*A Golden Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 3,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {3},
            new int[] {5,6,7},
            new int[] {7,10,31},
            new int[] {11,17},
            new int[] {14,16,45},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_124/*Golden Locket of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_123/*A Golden Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 3,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {2},
            new int[] {12,13,51,52,66,8,9,},
            new int[] {12,13,51,52,66},
            new int[] {23,48,54,26},
            new int[] {57,18,47}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_125/*Golden Locket of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_123/*A Golden Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 3,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {4},
            new int[] {12,13,21,24},
            new int[] {12,13,21,24,19,47,49,},
            new int[] {57,37,38,6},
            new int[] {4,37,38,}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_126/*Golden Locket of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_123/*A Golden Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 3,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            //Silver Lockets---------------------------------------------------------------------------

            new BaseItem(new int[][]
            {
            new int[] {1},
            new int[] {12,13},
            new int[] {22,25,57,},
            new int[] {35,50,53,0},
            new int[] {20,0,0,0}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_127/*Silver Locket of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_128/*A Silver Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {3},
            new int[] {7,10,31,5,},
            new int[] {11,17,0},
            new int[] {14,16,0},
            new int[] {45,0,0,0}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_129/*Silver Locket of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_128/*A Silver Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {2},
            new int[] {12,13,51,52,66,8,9,6,},
            new int[] {12,13,51,52,66,0},
            new int[] {15,18,34,36,0},
            new int[] {23,48,54,26},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_130/*Silver Locket of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_128/*A Silver Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {4},
            new int[] {12,13,21,24},
            new int[] {12,13,21,24,6},
            new int[] {19,47,49,0},
            new int[] {57,37,38,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_131/*Silver Locket of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_128/*A Silver Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 2,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            // Emerald Pendant-----------------------------------------------------------

            new BaseItem(new int[][]
            {
            new int[] {1},
            new int[] {12,13},
            new int[] {22,25,57,1},
            new int[] {35,50,53},
            new int[] {36,65,22,25},
            new int[] {11,18,37,6,8},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_132/*Emerald Pendant of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_134/*An Emerald Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {3},
            new int[] {7,10,31,5},
            new int[] {11,17},
            new int[] {14,16,57,55},
            new int[] {5,7,10,3,31},
            new int[] {57,65},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_135/*Emerald Pendant of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_134/*An Emerald Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {2},
            new int[] {8,9,12,13,51,52,66},
            new int[] {12,13,51,52,66},
            new int[] {15,18,34,36},
            new int[] {23,48,54,26},
            new int[] {52,66,23,26,2},
            new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_136/*Emerald Pendant of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_134/*An Emerald Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {4},
            new int[] {29,37,21,24,46,56,19},
            new int[] {12,13,21,24,6},
            new int[] {21,4,47,49},
            new int[] {4,57,47,24},
            new int[] {-1},
            new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_137/*Emerald Pendant of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_134/*An Emerald Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 5,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            // Diamond Pendant-----------------------------------------------------------

            new BaseItem(new int[][]
            {
            new int[] {1},
            new int[] {12,13},
            new int[] {22,25,1,},
            new int[] {35,50,53, },
            new int[] {65,30},
            new int[] {-1},
            new int[] {-1},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_138/*Diamond Pendant of Strength*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_139/*A Diamond Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 12,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {3},
            new int[] {5,6,7,8,9,10},
            new int[] {7,10,31},
            new int[] {11,17},
            new int[] {14,16},
            new int[] {28,11},
            new int[] {-1},
            new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_140/*Diamond Pendant of Vitality*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_139/*A Diamond Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 12,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {2},
            new int[] {8,9,12,13,51,52,66},
            new int[] {12,13,51,52,66,15,18,34,36 },
            new int[] {23,48,54,26},
            new int[] {54,52,66,2},
            new int[] {2,18,38},
            new int[] {57,2,6},
            new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_141/*Diamond Pendant of Agility*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_139/*A Diamond Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 12,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            new BaseItem(new int[][]
            {
            new int[] {4},
            new int[] {12,13,21,24},
            new int[] {12,13,21,24,6,65},
            new int[] {19,47,49,11,5,6,7,8,46,34},
            new int[] {29,4},
            new int[] {21,4,47,49},
            new int[] {4,57,47,24},
            new int[] {-1},
            new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_142/*Diamond Pendant of Intelligence*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_133/*A Pendant of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_139/*A Diamond Pendant that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 12,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };

            //Rare Amulets -----------------------------------------------------------------------------------------

            var armsyFingerNecklace = new BaseItem(new int[][]
            {
            new int[] {1},
            new int[] {65},
            new int[] {18,11},
            new int[] {-1},
            new int[] {12,13},
            new int[] {22,25,30,},
            new int[] {35,50,53,57},
            new int[] {20,57}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_143/*Armsy Finger Necklace*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_144/*A Necklace decorated with armsy fingertips.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_145/*A Necklace made from the fingertips of an armsy, yeilding it's raw power and strentgh.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that

            };
            armsyFingerNecklace.DropSettings_OnlyArmsy();
            armsyFingerNecklace.PossibleStats[0][0].Multipier = 2;
            armsyFingerNecklace.PossibleStats[1][0].Multipier = 2;
            var virginiaHeartPedant = new BaseItem(new int[][]
            {
            new int[] {2},
            new int[] {23},
            new int[] {48},
            new int[] {-1},
            new int[] {5,28},
            new int[] {7,10,31},
            new int[] {11,17,57},
            new int[] {14,16,57},
            new int[] {45,57}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_146/*Virginia Heart Pendant*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_147/*A Pendant of a petrified Virginia heart.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_148/*A Pendant made from a petrified Virginia heart, yeilding it's love and Vitality.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };
            virginiaHeartPedant.DropSettings_OnlyVags();
            virginiaHeartPedant.PossibleStats[0][0].Multipier = 2;
            virginiaHeartPedant.PossibleStats[1][0].Multipier = 2.25f;

            var cowmanToeNecklace = new BaseItem(new int[][]
            {
            new int[] {3},
            new int[] {31,6},
            new int[] {28},
            new int[] {8,9,27},
            new int[] {12,13,51,52,66},
            new int[] {12,13,51,52,66,57},
            new int[] {15,18,34,36,57},
            new int[] {23,48,54,26},
            new int[] {65,57}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_149/*Cowman Toe Necklace*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_150/*A Necklace decorated with cowman toes.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_151/*A Necklace made from the fingertips of an armsy, yeilding it's speed and agility.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 20,
                maxLevel = 40,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };
            cowmanToeNecklace.DropSettings_OnlyCow();
            cowmanToeNecklace.PossibleStats[0][0].Multipier = 3;
            cowmanToeNecklace.PossibleStats[1][0].Multipier = 2;
            new BaseItem(new int[][]
            {
            new int[] {47},
            new int[] {4,0},
            new int[] {21,0},
            new int[] {38,31,49,14},
            new int[] {-1},
            new int[] {-1},
            new int[] {-1},
            new int[] {-1},
            new int[] {12,13,21,24,6},
            new int[] {19,47,49,6},
            new int[] {29,37,38},
            new int[] {29,37,38,},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_152/*Pendant of Perpetual Rebirth*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_153/*A Pendant of a shrunken babyhead.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_154/*A pedant of great power. Obtainable only from babies or crafting*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_155(1)/*decrease a random cooldown by 1 second whenever you hit something with melee or ranged attack.*/, //tr
                Rarity = 7,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 30,
                maxLevel = 40,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
                onEquip = () => ModdedPlayer.Stats.i_infinityLoop.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_infinityLoop.value = false,
            }.DropSettings_OnlyBaby();

            //Boss drop Amulet----------------------------------------------------------------------------------------

            new BaseItem(new int[][]
            {
            new int[] {1,2,4},
            new int[] {12,13},
            new int[] {22,25,30,18,5,28},
            new int[] {35,50,53,57,56,20,57,19,18},
            new int[] {7,10,31},
            new int[] {45,16,10,11,9,8, 14, 16, 57,11, 17,57},
            new int[] { 51, 52,66,8, 9,27},
            new int[] {15,18,34,36,57},
            new int[] {23,48,54,26},
            new int[] {6,55,46,54,53},
            new int[] {19,47,49,57, 21,24,29,37,38,57},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_156/*Megan's Locket*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_157/*The Locket Megan wore.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_158/*Megan wore this Locket, it has a picture of her mom in it.*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            }.DropSettings_OnlyMegan();

            BaseItem RelicHammer = new BaseItem(new int[][]
            {
                new int[] {25 },
                new int[] {18 },
                new int[] {2004 },
                new int[] {1,62,63,64 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_159/*Relic Hammer*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_160/*It's slow and weak.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_161/*Slows on hit*/, //tr
                Rarity = 2,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
            };
            RelicHammer.PossibleStats[1][0].Multipier = -4;

            BaseItem GreaterHammer = new BaseItem(new int[][]
        {
                new int[] {25 },
                new int[] {18 },
                new int[] {2004 },
                new int[] {1,3,62,63,64},
                new int[] {53,16},
                new int[] {39,31,43,0,0},
                new int[] {25 ,22,1,12,13,5,6},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_162/*Black Hammer*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_163/*It's slow but with enough strength i can make it a very deadly tool*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_161/*Slows on hit*/, //tr
                Rarity = 4,
                minLevel = 30,
                maxLevel = 35,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
            };
            GreaterHammer.PossibleStats[1][0].Multipier = -3;
            //Item 0/6
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {2,6,4},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_164/*Potato Sack*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_165/*Can be used as a quiver*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
            };

            //Item 1/6
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {40,41,42},
                    new int[] {40,16,60},
                    new int[] {2},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_166/*Rabbit Skin Quiver*/, //tr
                Rarity = 1,
                minLevel = 2,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
            };

            //Item 2/6
            new BaseItem(new int[][]
            {
                    new int[] {26},
                    new int[] {23,2,54},
                    new int[] {18,60,61},
                    new int[] {40,41,16,5,6,40},
                    new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_167/*Hollow Log*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_168/*It allows for faster drawing of arrow than a cloth quiver*/, //tr
                Rarity = 2,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
            };

            //Item 3/6
            new BaseItem(new int[][]
            {
                    new int[] {26,23},
                    new int[] {24,21},
                    new int[] {17,16,18,54,51,52,66},
                    new int[] {2,3,4,15,14,13,12,11,10},
                    new int[] {5,6,47,60,61},
                    new int[] {2,3,4,5,6,7,8,11,12,16,18,37},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_169/*Spellbound Quiver*/, //tr
                Rarity = 3,
                minLevel = 6,
                maxLevel = 11,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
            };

            //Item 4/6
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {23},
                    new int[] {2,3,4},
                    new int[] {34,18,17,16,15,14,60,61,55,},
                    new int[] {16,19,23,31,54,51,52,66,57},
                    new int[] {2,0},
                    new int[] {2,3,4,5,6,7,8,9,10},
                    new int[] {2,1,5,6},
                    new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_170/*Long Lost Quiver*/, //tr
                Rarity = 5,
                minLevel = 12,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
            };

            //Item 5/6
            new BaseItem(new int[][]
            {
                    new int[] {37, 24,47},
                    new int[] {42,6,17,61},
                    new int[] {-1},
                    new int[] {4,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_171/*Spell Scroll*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_172/*Contains a lot of information on how to properly cast spells to achieve better results*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
            };

            new BaseItem(new int[][]
            {
                new int[] {16,43},
                new int[] {43,39,40,41,42},
                new int[] {43,39,40,41,42},
                new int[] {43,0,0,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_173/*Cloth Pants*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_174/*Offer little protction*/, //tr
                Rarity = 1,
                minLevel = 2,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            //Item 1/7
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {1,2,3,4},
                new int[] {5,6},
                new int[] {16,43,39,40,41,42},
                new int[] {1000,1001,1002,1003,1004,43,0,0,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_175/*Rough Hide Leggins*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            //Item 2/7
            new BaseItem(new int[][]
            {
                new int[] {16,},
                new int[] {1,2,3,4},
                new int[] {5,44,7,8},
                new int[] {6,16,3},
                new int[] {1,2,3,4,11},
                new int[] {17,16,10,9},
                new int[] {16,43},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_176/*Plate Leggins*/, //tr
                Rarity = 4,
                minLevel = 4,
                maxLevel = 10,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            //Item 3/7
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {19},
                new int[] {1,2,3,4,5,6,7,8},
                new int[] {39,40,41,42,43},
                new int[] {4},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_177/*Sage's Robes*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            //Item 4/7
            new BaseItem(new int[][]
            {
                new int[] {1,2,3,4},
                new int[] {1,5},
                new int[] {16},
                new int[] {22,25},
                new int[] {11,12,13,14,5,6,1,2,3,4},
                new int[] {7,8,9,10,44,45,46,49},
                new int[] {31,1,3,},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_178/*Hammer Jammers*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_179("450%")/*Damage of your smash attack is increased by <color=gold>450%</color>, hammer stun duration is doubled*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 28,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
                onEquip = () => { ModdedPlayer.Stats.smashDamage.Multiply(4.5f); ModdedPlayer.Stats.i_HammerStunAmount.Multiply(2); },
                onUnequip = () => { ModdedPlayer.Stats.smashDamage.Divide(4.5f); ModdedPlayer.Stats.i_HammerStunAmount.Divide(2); },
            };

            //Item 5/7
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {34},
                new int[] {1,2,4,6,7,8},
                new int[] {-1},
                new int[] {26,23,24,21},
                new int[] {1000, 1001,1002, 1003, 1004, 0,0,0,1,2,4},
                new int[] {51,1,2,3,4,55},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_180/*Pirate Pants*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_181/*Those pants are ligh and comfortable. They offer plenty of mobility but lack in protection.*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            //Item 6/7
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {1,2,3,4,16,17},
                new int[] {18,34},
                new int[] {1,2,3,4},
                new int[] {5,6,15,16,13,12,11},
                new int[] {8,4,2,9},
                new int[] {22,21,23},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_182/*Hexed Pants of Mr M.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_183/*They look like yoga pants but for a man the size of a wardrobe*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_184/*Once upon a time there was a man who was in a basement and fed himself with nothing but nuggets. He got so obese that friends and family started worrying. Hazard noticed this man and cursed his pants to force him to excercise.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_185("60%", "1%")/*While moving, energy regeneration and damage is increased by <color=gold>40%</color>. While standing still for longer than a second, you loose 1% of max health per second.*/, //tr
                Rarity = 7,
                minLevel = 14,
                maxLevel = 15,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
                onEquip = () => ModdedPlayer.Stats.i_HexedPantsOfMrM_Enabled.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_HexedPantsOfMrM_Enabled.value = false,
            };
            new BaseItem(new int[][]
            {
new int[] {39,40,41,42,43},
new int[] {39,40,41,42,43},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_186/*Leather Mantle*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_187/*A piece of cloth to give protection from */, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            //Item 1/6
            new BaseItem(new int[][]
            {
new int[] {16},
new int[] {16},
new int[] {1,2,3,4,5,6},
new int[] {39,40,41,42,43},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_188/*Shoulder Guards*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_189/*Medium armor piece.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_190/*Heavy armor*/, //tr
                Rarity = 2,
                minLevel = 4,
                maxLevel = 7,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            //Item 2/6
            BaseItem Heavy_Shoulder_Plates = new BaseItem(new int[][]
            {
                new int[] {34},
                new int[] {18},
                new int[] {16},
                new int[] {16,65},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4,5,8,9,7,10},
                new int[] {17,10,5,8,9,7,10},
                new int[] {5,45,3},
                new int[] {11},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_191/*Heavy Shoulder Plates*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_192/*Heavy armor piece. They offer great protection at the cost of attack speed and movement speed decrease*/, //tr
                Rarity = 4,
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            Heavy_Shoulder_Plates.PossibleStats[0][0].Multipier = -1;
            Heavy_Shoulder_Plates.PossibleStats[1][0].Multipier = -1;
            Heavy_Shoulder_Plates.PossibleStats[2][0].Multipier = 3;

            //Item 3/6
            new BaseItem(new int[][]
            {
                new int[] {21,22,23,24,25,26},
                new int[] {16},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4,16,39,40,41,42,43},
                new int[] {1,2,3,4,16,39,40,41,42,43},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_193/*Etched Mantle*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_194/*Those pauldrons empower wearer's combat skill*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            //Item 4/6
            new BaseItem(new int[][]
            {
                new int[] {22,25},
                new int[] {1,2,3,4},
                new int[] {16},
                new int[] {12,11,13,14},
                new int[] {5,6},
                new int[] {10,15,16,17,18,19,31,35,36,44,45,46,47,49,50,53,55},
                new int[] {10,15,16,17,18,19,31,35,36,44,45,46,47,49,50,53,55},
                new int[] {53,55},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_195/*Assassins Pauldrons*/, //tr
                Rarity = 5,
                minLevel = 4,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            //Item 5/6
            new BaseItem(new int[][]
            {
                new int[] {11},
                new int[] {1,2,3,4},
                new int[] {16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {21,22,23,24,25,26},
                new int[] {5,14,7,10,45},
                new int[] {1,2,3,4},
                new int[] {12,13,15,16,18},
                new int[] {17,19,21,22,23},
                new int[] {37,35,36,38,44,45,47},
                new int[] {1,2,4},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_196/*Death Pact*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_197/*Find the greatest strength on the border of life and death.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_198("6%", "5%")/*Every attack you make decreases your health by <color=gold>7%</color> of max health. For every percent of missing health you gain 5% damage amplification. This damage cannot kill you.*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
                onEquip = () => ModdedPlayer.Stats.i_DeathPact_Enabled.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_DeathPact_Enabled.value = false,
            };
            new BaseItem(new int[][]
            {
                new int[] {56},
                new int[] {-1},
                new int[] {-1},
                new int[] {1,2,3,4},
                new int[] {11,12,13,14,15,16,17,18},
                new int[] {11,12,13,14,15,16,17,18},
                new int[] {5,6,7,8,9,10,31},
                new int[] {55,54,53,50},
                new int[] {1,2,3,4,21,22,23,24,25,26},
                new int[] {16,0,0,0,1,2,3,4,0,0,0,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_199/*Maximale Qualitöt*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_200/*A platinum ring with the most expensive jewels engraved on it. It's quality is uncomparable.*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };
            new BaseItem(new int[][]
                         {
                         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_201/*Heart of Purity*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_202/*A object filled with both destructive and creative energy. Allows to re-assign all spent mutation points*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_203/*This powerful relic contains so much power, that it can kill anything and force it to come back to life, resulting in it's rebirth.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_204/*Can be consumed by right clicking it. */, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = true,
                StackSize = 100,
                type = BaseItem.ItemType.Other,
                icon = Res.ResourceLoader.GetTexture(105),
                onEquip = ModdedPlayer.Respec
            };

            new BaseItem(new int[][]
            {
new int[] {1,2,3,4,57},
new int[] {16,17,14},
new int[] {50,11},
new int[] {49,39,40,41,42,45,44},
new int[] {5,6,9,8,10,12,13,14,},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_205/*Round Shield*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_206/*A sturdy shield made of wood and reinforced with iron.*/, //tr
                Rarity = 2,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };

            //Item 1/5
            new BaseItem(new int[][]
            {
new int[] {1,11,5,7},
new int[] {57,2,3,4,5,6,7,8,10,11},
new int[] {39,40,41,42,43,44,45,46},
new int[] {50},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_207/*Old Buckler*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_208/*An old shield.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_209/*This item has a lot of scratches that look like they were made by something with sharp claws.*/, //tr
                Rarity = 1,
                minLevel = 4,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };

            //Item 2/5
            new BaseItem(new int[][]
            {
new int[] {16},
new int[] {16,50},
new int[] {-1},
new int[] {-1},
new int[] {-1},
new int[] {11},
new int[] {39,40,41,42,43,50,57},
new int[] {39,40,41,42,43,50,57},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_210/*Dark Oak Shield*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };

            //Item 3/5
            new BaseItem(new int[][]
            {
new int[] {15,14},
new int[] {2,3,4,1,41,42,57},
new int[] {-1},
new int[] {-1},
new int[] {-1},
new int[] {65,1,16,25},
new int[] {2,4,5,6},
new int[] {16,7,8,22,23,25,26},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_211/*Bone Shield*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_212/*A shield made of bones, held together by thick steel wire.*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };

            new BaseItem(new int[][]
            {
new int[] {18},
new int[] {0,0,0,0,62,63,64},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_213/*Dull Longsword*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_214/*It's round on the edges*/, //tr
                Rarity = 0,
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
            }.PossibleStats[0][0].Multipier = -3;

            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {65},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_215/*Iron Horn*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_216("10%")/*When using Warcry, you and all allies recieve armor bonus equal to <color=gold>10%</color> of your armor*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101),
                onEquip = () => ModdedPlayer.Stats.spell_warCryGiveArmor.value = true,
                onUnequip = () => ModdedPlayer.Stats.spell_warCryGiveArmor.value = false,
            }.PossibleStats[0][0].Multipier = 2;

            //Item 1/5
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {31,7,8,9,10},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_217/*The Great Iron Horn*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_216("10%") + Translations.ItemDataBase_ItemDefinitions_608/*When using Warcry, you and all allies recieve armor bonus equal to <color=gold>10%</color> of your armor*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.spell_warCryGiveArmor.value = true;
                    ModdedPlayer.Stats.spell_warCryGiveDamageResistance.value = true;
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.spell_warCryGiveArmor.value = false;
                    ModdedPlayer.Stats.spell_warCryGiveDamageResistance.value = true;
                },
            }.PossibleStats[0][0].Multipier = 5;

            //Item 2/5
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {1},
                new int[] {65,0},
                new int[] {5,16,18},
                new int[] {21,22,23,0,0,0},
                new int[] {24,25,26,0,0,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_218/*Horned Helmet*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_219/*A viking helmet*/, //tr
                Rarity = 2,
                minLevel = 2,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            //Item 3/5
            new BaseItem(new int[][]
            {
                new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_220/*Mask*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            //Item 4/5
            BaseItem mask = new BaseItem(new int[][]
             {
                new int[] {18},
                new int[] {22,23,21},
                new int[] {11},
                new int[] {1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {24,25,26,0,0,0},
                new int[] {29,30,48},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_221/*Mask of Madness*/, //tr
                Rarity = 5,
                minLevel = 2,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            mask.PossibleStats[2][0].Multipier = -4;
            mask.PossibleStats[0][0].Multipier = 1.5f;
            mask.PossibleStats[1][0].Multipier = 2.5f;
            mask.PossibleStats[1][1].Multipier = 2.5f;
            mask.PossibleStats[1][2].Multipier = 2.5f;

            new BaseItem(new int[][]
             {
                new int[] {47,49,37,38},
                new int[] {42,4},
                new int[] {44},
                new int[] {21},
                new int[] {-1},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_222/*Old Scroll*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_172/*Contains a lot of information on how to properly cast spells to achieve better results*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
            };
            new BaseItem(new int[][]
            {
                new int[] {57},
                new int[] {1,2,3,4},
                new int[] {5,46},
                new int[] {6,45},
                new int[] {21,24,11,12,13,14,15,16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {4,18,7,8,19},
                new int[] {27,28,29,30,48,47},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_223/*Wormhole Stabilizators*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_224/*High-tech gear*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_225/*Hazard remember to put some fucking lore in here, don't leave it like this!*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_226("570")/*Increases the duration of a portal by <color=gold>570</color> seconds*/, //tr
                Rarity = 7,
                minLevel = 4,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(94),
                onEquip = () => ModdedPlayer.Stats.spell_portalDuration.Add(570),
                onUnequip = () => ModdedPlayer.Stats.spell_portalDuration.Substract(570),
            };
            new BaseItem(new int[][]
            {
                new int[] {57},
                new int[] {1,2,3,4},
                new int[] {5,46},
                new int[] {6,45},
                new int[] {21,24,11,12,13,14,15,16},
                new int[] {16},
                new int[] {17},
                new int[] {4,18,7,8,19},
                new int[] {27,28,29,30,48,47},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_227/*Cripplers*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_228(15)/*Increases the duration of a magic arrow's negative effect by <color=gold>10</color> seconds*/, //tr
                Rarity = 7,
                minLevel = 3,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
                onEquip = () => ModdedPlayer.Stats.spell_magicArrowDuration.Add(15),
                onUnequip = () => ModdedPlayer.Stats.spell_magicArrowDuration.Substract(15),
            };

            new BaseItem(new int[][]
            {
                new int[] {24,4},
                new int[] {26,4},
                new int[] {21,2},
                new int[] {23,2,0,0,0,0},
                new int[] {2,4,57,16},
                new int[] {6,8,9,44,46},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {12,13,14,15,16,18},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_229/*Crossfire*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_230/*Infused with powerful magic. This item is a dangerous tool of destruction.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_231/*When hitting an enemy with a projectile, create a magic arrow pointed at the enemy and shoot it without using in energy. This effect may occur once every <color=gold2</color> seconds, but can be interval can be shortened with cooldown reduction.*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.i_CrossfireQuiver.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_CrossfireQuiver.value = false,
            };

            new BaseItem(new int[][]
            {
                new int[] {44},
                new int[] {44,8},
                new int[] {44,4,6,9,4},
                new int[] {49,7,0},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_232/*Scroll of Recovery*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_233/*Recovers health and stamina*/, //tr
                Rarity = 1,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
            };

            new BaseItem(new int[][]
            {
                new int[] {11},
                new int[] {-1},
                new int[] {16,15},
                new int[] {37,38},
                new int[] {42,24},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_234/*Tiara*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_235/*A beautiful tiara */, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_236/*This tiara may not provide much protection, but it sure is pretty*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_237/*Shiny*/, //tr
                Rarity = 2,
                minLevel = 5,
                maxLevel = 10,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            //Item 1/2
            new BaseItem(new int[][]
            {
                new int[] {-1},
                new int[] {15},
                new int[] {15},
                new int[] {17,16},
                new int[] {17,16},
                new int[] {0,65},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_238/*Chastity belt*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_239/*Dodge those fukbois*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_240/*This belt will stop those cheeky cannibals and armsies from getting into your pants*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_241("99%")/* <color=gold>100%</color> damage reduction while sleeping*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new int[][]
          {
                    new int[] {2005},
                    new int[] {-1},
                    new int[] {-1},
                    new int[] {42,43},
                    new int[] {44,0,49,},
                    new int[] {21,24,0,0,0,0},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_242/*Ice Scroll*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_243/*A spell surrounded by flying shards of ice, contains tramendous power of cold.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_244/*Created at the top of the mountain.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_581("250", 2)/*Snap freeze damage is increased and the slow duration is increased by 1 second*/, //tr
                Rarity = 4,
                minLevel = 30,
                maxLevel = 40,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
                onEquip = () => { ModdedPlayer.Stats.spell_snapDamageScaling.Add(250f); ModdedPlayer.Stats.spell_snapFreezeDuration.Add(2); },
                onUnequip = () => { ModdedPlayer.Stats.spell_snapDamageScaling.Substract(250f); ModdedPlayer.Stats.spell_snapFreezeDuration.Add(2); }
            };
            new BaseItem(new int[][]
          {
                    new int[] {2006},
                    new int[] {57,1,2,3,4},
                    new int[] {34,45,46,15,1,2,3,4,57,11,14,7,10,59},
                    new int[] {8,1,2,3,4,9,5,6},
                    new int[] {1000,1001,1002},
                    new int[] {1000,1001,1002, 1003, 1004, 0,0,0,0,0,0,0},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_245/*Motorboat Modification Blueprints*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_246/*Sheet of paper that allows to turn any raft into a high speed. Increases carry amount and increases speed of rafts.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_247/*Who did this lmao.*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
            };
            new BaseItem(new int[][]
             {
                new int[]{1,2,3,4},
                new int[]{18},
                new int[]{18,0,0,62,63,64},
                new int[] {1,2,3,4,6,55},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_248/*Axe of Swiftness*/, //tr
                Rarity = 3,
                minLevel = 15,
                maxLevel = 17,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
            }.PossibleStats[1][0].Multipier = 1.6f;
            new BaseItem(new int[][]
             {
                new int[]{1,26,22},
                new int[]{18},
                new int[]{18,62,63,64},
                new int[] {1,2,3,4,6,55,59,57,34,35,36,14,44,49},
                new int[] {53,22,25,12,13},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_249/*Severer*/, //tr
                Rarity = 4,
                minLevel = 25,
                maxLevel = 25,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
            }.PossibleStats[1][0].Multipier = 2.5f;

            new BaseItem(new int[][]
             {
                new int[]{1,26,22},
                new int[]{18},
                new int[]{1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,20,34,35,36,37,38,44,45,46,47,49,53,54,55,},
                new int[]{62,63,64,0,0,0},
                new int[]{19,56},
                new int[] {1,2,3,4,6,55,59,57,34,35,36,14,44,49},
                new int[] {53,22,25,12,13,1,2,3,4,39,40,41,42,43},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_250/*Golden Axe of Fortune*/, //tr
                Rarity = 5,
                minLevel = 35,
                maxLevel = 36,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
            }.PossibleStats[1][0].Multipier = 2.5f;
            new BaseItem(new int[][]
                      {
                new int[]{26,22},
                new int[]{63},
                new int[]{1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,20,34,35,36,37,38,44,45,46,47,49,53,54,55,},
                new int[]{62,63,64,65},
                new int[]{19,56},
                new int[] {26},
                new int[] {53,22,25,12,13,1,2,3,4,39,40,41,42,43},
                      })
            {
                name = Translations.ItemDataBase_ItemDefinitions_251/*Axe of Misfortune*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_252/*Misfortunate are the ones on the recieving end. They will bleed a lot*/, //tr
                Rarity = 5,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
            }.PossibleStats[1][0].Multipier = 3;

            new BaseItem(new int[][]
         {
                new int[] {1,2,3,4},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_253/*Golden Ring*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_102/*A Ring of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_103/*A Golden Ring that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 4,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new int[][]
          {
                new int[] {1,2,3,4},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_254/*Golden Locket*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_122/*A Locket of ancient times.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_123/*A Golden Locket that looks simple and elegant, yet it feels powerfull to the touch.*/, //tr
                Rarity = 3,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101), //icon ids, don't worry about that
            };
            new BaseItem(new int[][]
          {
              new int[]{0,39}
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_255/*Dull Axe*/, //tr
                Rarity = 0,
                minLevel = 15,
                maxLevel = 24,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
            };
            new BaseItem(new int[][]
            {
                new int[] {1,2,3,4 },
                new int[] {1,2,3,15,4,0,0,0 },
                new int[] {12,13,1,2,3,4,5, },
                new int[] {18,16,23,26,19 },
                new int[] {18,16,23,26 },
                new int[] {34,44,45,46 },
                new int[] {2,23,26},
                new int[] {2,23,26,51},
                new int[] {2,23,26,20,16,15,60},
                new int[] {52,66,60,0,0},
                new int[] {-1},
                 })
            {
                name = Translations.ItemDataBase_ItemDefinitions_256/*Precise Adjustments*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_257(15)/*Focus attack speed buff duration is increased by <color=gold>16</color> seconds*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.spell_focusOnAtkSpeedDuration.Add(16),
                onUnequip = () => ModdedPlayer.Stats.spell_focusOnAtkSpeedDuration.Substract(16),
            };
            new BaseItem(new int[][]
          {
                new int[] {25 },
                new int[] {22,1,18,},
                new int[] {1,2,3,4,57,},
                new int[] {27,28,30},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {15,14,45,7,35,10},
                new int[] {62,63,64, },
                new int[] {53,61 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_258/*Rage*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_259(15)/*Increases maximum stacks of frenzy by <color=gold>10</color>*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_260/*Swords go brrrrrrttt*/, //tr
                Rarity = 7,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Add(15),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Substract(15),
            }.PossibleStats[0][0].Multipier = 5;

            BaseItem jaggedRipper = new BaseItem(new int[][]
            {
                new int[] {1,2,3,4,57,},
                new int[]{18},
                new int[] {25 },
                new int[] {62,63,64, },
                new int[] {53, },
                new int[] {49,14, },
                new int[] {35,36,15,12, },
                new int[] {27,28,30},
                new int[]{18,62,63,64},
                new int[] {65},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_261/*Jagged Edge*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_262("30%", "30%")/*Bash has <color=gold>30%</color> a chance to make enemies to bleed for <color=gold>30%</color> of damage dealt per second for duration of slow*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
                onEquip = () => ModdedPlayer.Stats.spell_bashBleedChance.Add(0.3f),
                onUnequip = () => ModdedPlayer.Stats.spell_bashBleedChance.Substract(0.3f),
            };
            jaggedRipper.PossibleStats[1][0].Multipier = 2;

            new BaseItem(new int[][]
                     {
                        new int[] {25 },
                        new int[] {22,},
                        new int[] {1,2,3,4,57,},
                        new int[] {27,28,30},
                        new int[] {-1},
                        new int[] {-1},
                        new int[] {-1},
                        new int[] {-1},
                        new int[] {-1},
                        new int[] {15,14,45,7,35,10},
                        new int[] {62,63,64, },
                        new int[] {53,61 },
                     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_263/*Bloodthirster*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_264/*Drenched in blood of many unfortunate foes.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_265("2%")/*Bash lifesteals <color=gold>2%</color> of damage dealt into energy and health*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 5,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
                onEquip = () => ModdedPlayer.Stats.spell_bashLifesteal.Add(0.02f),
                onUnequip = () => ModdedPlayer.Stats.spell_bashLifesteal.Substract(0.02f),
            }.PossibleStats[0][0].Multipier = 3;
            new BaseItem(new int[][]
         {
                new int[] {25 },
                new int[] {22 },
                new int[] {2004 },
                new int[] {62,63,64 },
                new int[] {27,28,30,29,48},
                new int[] {1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_266/*Frost Giant*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_267/*Melee hits freeze enemies*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.i_HammerStunDuration.Multiply(2);
                    ModdedPlayer.Stats.i_HammerStunAmount.Multiply(0);
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.i_HammerStunDuration.Divide(2);
                    ModdedPlayer.Stats.i_HammerStunAmount.Reset();
                },
            }.PossibleStats[0][0].Multipier = 3.25f;

            new BaseItem(new int[][]
            {
             new int[] {11},
                new int[] {65},
                new int[] {16,17},
                new int[] {1,11,45},
                new int[] {15},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_268/*Alexander's Shield*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_269/*Parry has a chance to be casted when getting it. Requires parry to be equipped*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
                onEquip = () => ModdedPlayer.Stats.spell_chanceToParryOnHit.value = true,
                onUnequip = () => ModdedPlayer.Stats.spell_chanceToParryOnHit.value = false,
            };

            new BaseItem(new int[][]
     {
             new int[] {1},
                new int[] {12,3,16,45,46},
                new int[] {13,4,62,64},
                new int[] {22},
                new int[] {25,22},
                new int[] {25},
                new int[] {11,1},
                new int[] {30,1,57},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_270/*King Qruies*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_271/*A mighty sword seeking for it's owner*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_272/*Gain additional melee damage equal to the last instance of physical damage taken.*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
                onEquip = () => ModdedPlayer.Stats.i_KingQruiesSword.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_KingQruiesSword.value = false,
            };

            new BaseItem(new int[][]
            {
             new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
             new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
                new int[] {13,4,62,64},
                new int[] {26,2,34,57,55},
                new int[] {26,23},
                new int[] {18,16},
                new int[] {48,2,55},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_273/*Grip of Sora*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_274/*Look, a porcupine! -Sora*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_275("20%", "+4")/*Multishot drains <color=gold>20%</color> less energy and shoots <color=gold>+4</color> projectiles. Additional projectiles do not increase the cost of multishot*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
                onEquip = () => ModdedPlayer.Stats.i_SoraBracers.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_SoraBracers.value = false,
            };
            new BaseItem(new int[][]
          {
             new int[] {18},
                new int[] {60,0},
                new int[] {2,40},
                new int[] {12,13,2,40,16,66},
                new int[] {39,40,41,42,43,0,0},
                new int[] {23,26},
                new int[] {-1,0},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_276/*Ancient Greatbow*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_277/*A massive and slow bow, deals extra damage*/, //tr
                Rarity = 4,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
            }.PossibleStats[0][0].Multipier = -1.55f;

            new BaseItem(new int[][]
        {
             new int[] {18},
                new int[] {61},
                new int[] {2,0,0,0},
                new int[] {12,13,2,40,16},
                new int[] {39,40,41,42,43,0,0},
                new int[] {23,26,2,66},
                new int[] {23,26},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_278/*Phoenix's Death*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_279/*Ignites enemies on hit*/, //tr
                Rarity = 6,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
                onEquip = () => ModdedPlayer.Stats.i_greatBowIgnites.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_greatBowIgnites.value = false,
            }.PossibleStats[0][0].Multipier = -1.7f;

            new BaseItem(new int[][]
        {
             new int[] {18},
                new int[] {61,48},
                new int[] {2,3,5},
                new int[] {12,13,2,40,16},
                new int[] {39,40,41,42,43,66},
                new int[] {23,26},
                new int[] {23,26},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_280/*Soulstring*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_281/*A massive and slow bow*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_282(100)/*Blood infused arrow now deals additional <color=gold>20</color> points of damage per health consumed*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
                onEquip = () => ModdedPlayer.Stats.spell_bia_HealthDmMult.Add(100),
                onUnequip = () => ModdedPlayer.Stats.spell_bia_HealthDmMult.Substract(100),
            }.PossibleStats[0][0].Multipier = -1.7f;

            new BaseItem(new int[][]
            {
             new int[] {18},

                new int[] {2,40,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_283/*Greatbow*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_277/*A massive and slow bow, deals extra damage*/, //tr
                Rarity = 2,
                minLevel = 25,
                maxLevel = 28,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
            }.PossibleStats[0][0].Multipier = -2.7f;

            new BaseItem(new int[][]
        {
             new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
             new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
                new int[] {13,4,62,64},
                new int[] {26,2,34,57,55},
                new int[] {26,23},
                new int[] {26,0,0},
                new int[] {18,16},
                new int[] {30,1,57},
                new int[] {5},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_284/*Withered Crown*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_285/*Worn by Hazard.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_286("4")/*A single cast of blood infused arrow affects <color=gold>4</color> more projectiles*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
                onEquip = () => ModdedPlayer.Stats.i_HazardCrown.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_HazardCrown.value = false,
            };
            new BaseItem(new int[][]
                  {
                new int[] {39,40,41,42,43,4},
                new int[] {4,6,24,21,16,3,42,43,49},
                new int[] {0,6,24,21,16,3,47,49,38,17,10,11,9,8,7,6},
                new int[] {37,4},
                new int[] {43,16,17,37,47 },
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_287/*Novice Magic Caster's Bracers*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
                  {
                new int[] {2,12,13,23,26,40,43,54},
                new int[] {2,12,13,23,26,40,43,60,62,63,51,52,66},
                new int[] {5,6,7,8,9,10,16,17,26},
                new int[] {37,0,0,0},
                new int[] {43,16,2 },
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_288/*Ranger's Bracers*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
                  {
                new int[] {1,16,5,6,18,39,14,22,25,53,62,63,57,45},
                new int[] {2,12,13,22,25,40,43,54},
                new int[] {5,6,7,8,9,10,16,17,26},
                new int[] {37,1,17,18,16},
                new int[] {43,1,65 },
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_289/*Swordsman's Bracers*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
                  {
                new int[] {3,5,6,7,8,9,10,11,14,15,16},
                new int[] {7,16,18,0,0},
                new int[] {39,40,41,42,43,31,16},
                new int[] {1,2,3,4,5,57,39,40,41,42,43,31,16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_290/*Healer's Bracers*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new int[][]
                 {
                new int[] {39,40,41,42,43,4},
                new int[] {4,6,24,21,16,3,42,43,49},
                new int[] {0,6,24,21,16,3,47,49,38,17,10,11,9,8,7,6},
                new int[] {37,0,0,0},
                new int[] {43,4 },
                 })
            {
                name = Translations.ItemDataBase_ItemDefinitions_291/*Novice Magic Caster's Gloves*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
                  {
                new int[] {2,12,13,23,26,40,43,54},
                new int[] {2,12,13,23,26,40,43,60,62,63,51,52,66},
                new int[] {5,6,7,8,9,10,16,17,26},
                new int[] {37,68},
                new int[] {43,2 },
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_292/*Ranger's Gloves*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
                  {
                new int[] {1,16,5,6,18,39,14,22,25,53,62,63,57,45},
                new int[] {2,12,13,23,26,40,43,54},
                new int[] {5,6,7,8,9,10,16,17,26},
                new int[] {37,18,7,0},
                new int[] {43,1,65 },
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_293/*Swordsman's Gloves*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
                  {
                new int[] {3,5,6,7,8,9,10,11,14,15,16},
                new int[] {7,16,18,0,0},
                new int[] {39,40,41,42,43,31,16},
                new int[] {1,2,3,4,5,57,39,40,41,42,43,31,16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_294/*Healer's Gloves*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
                  {
                new int[] {62,63,64,55,54,53,48,30,29,28,27},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_295/*Fate Gloves*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
                  {
                new int[] {62,63,64,55,54,53,48,30,29,28,27},
                new int[] {34},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_296/*Fate Boots*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
                  {
                new int[] {62,63,64,55,54,53,48,30,29,28,27},
                new int[] {34},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                  })
            {
                name = Translations.ItemDataBase_ItemDefinitions_297/*Greed*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_298/*Automatically casts wide reach every second*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
                onEquip = () => ModdedPlayer.Stats.i_isGreed.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_isGreed.value = false,
            };
            BaseItem titaniumleggins = new BaseItem(new int[][]
             {
                new int[] { 16},
                new int[] {31},
                new int[] {1,2,3,4},
                new int[] {5,},
                new int[] {-1,65},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_299/*Titanium Leggins*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_300/*Heavily armored leg protection. Suffers from the same weaknesses as spartan armor.*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            titaniumleggins.PossibleStats[0][0].Multipier = 3;
            titaniumleggins.PossibleStats[1][0].Multipier = 1.5f;
            new BaseItem(new int[][]
     {
                new int[] {42,39,40,41,43,0,0 },
                new int[] {16,24,25,26,5,6,7,8,9,10,11,12,13,14,15,17,18,55,60,61,62,63,64,0,0,0 },
                new int[] {16,24,25,26,5,6,7,8,9,10,11,12,13,14,15,17,18,55,60,61,62,63,64 },
                new int[] {43,0,0,0,16 },
                new int[] {65,0},
     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_301/*Iron Gauntlet*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };

            new BaseItem(new int[][]
         {
                new int[] {4,3,6},
                new int[] {21,24,16 },
                new int[] {29,4 },
                new int[] {16,15,17 },
                new int[] {47,49,44,45,46 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_302/*Magefist*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_303/*Gloves that amplify magic*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_304/*Spells deal <color=gold>double</color> damage but have double the energy cost*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
                onEquip = () => { ModdedPlayer.Stats.spellIncreasedDmg.valueMultiplicative *= 2f; ModdedPlayer.Stats.spellCost.valueMultiplicative *= 2f; },
                onUnequip = () => { ModdedPlayer.Stats.spellIncreasedDmg.valueMultiplicative /= 2f; ModdedPlayer.Stats.spellCost.valueMultiplicative /= 2f; }
            };
            new BaseItem(new int[][]
              {
                new int[] {34 },
                new int[] {34,5,1,2,4,3,2,11 },
                new int[] {16,3,2,1,4 },
                new int[] {16,7,8 },
                new int[] {16, },
                new int[] {-1 },
                new int[] {43 },
              })
            {
                name = Translations.ItemDataBase_ItemDefinitions_305/*Armored Boots*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_306/*Heavily armored, resistant to damage boots.*/, //tr
                Rarity = 5,
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new int[][]
            {
                new int[] {16},
                new int[] {16,18,57,53},
                new int[] {16,1,2,3,4,21,22,23,24,25,26,31,15,5,6,7,8,9},
                new int[] {1,2,3,4,57},
                new int[] {16,45,46,0,0,0},
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_307/*Broken Protector*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_308/*This shield failed to protect those behind it.*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            }.PossibleStats[0][0].Multipier = 2;

            new BaseItem(new int[][]
          {
                    new int[] {4},
                    new int[] {6,4,3,44},
                    new int[] {21,24},
                    new int[] {21,24},
                    new int[] {-1,},
                    new int[] {-1},
                    new int[] {-1},
                    new int[] {47,4,5,6,7,61,17,0,0,0,0,2,56,57,49,64},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_309/*Forbidden Scroll*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_310/*Too powerful to be kept.*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
            };

            new BaseItem(new int[][]
         {
                new int[] {16},
                new int[] {1,2,3,4},
                new int[] {17},
                new int[] {8,9,49,47},
                new int[] {16,18,11,34},
                new int[] {37,34},
                new int[] {-1},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_311/*Doom Pauldrons*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_312/*Despite the cool name, they are completely normal pair of shoulder armor.*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new int[][]
         {
                new int[] {16},
                new int[] {1,2,3,4,57,53,54,55},
                new int[] {17,18,11,15},
                new int[] {15},
                new int[] {34},
                new int[] {16,5,6,7,8,9,10,11,12,13,14,15,17,18,59,47,45,46,60},
                new int[] {23,22,30,27,34,44,48,59},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_313/*Wind armor*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_314/*Run fast like the wind*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_315("20%", "35%", "2000", "5%")/*Upon dodging an attack, gain 20% movement speed, 35% damage, 2000 armor, and heal for 5% of your maximum health*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
                onEquip = () => ModdedPlayer.Stats.i_isWindArmor.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_isWindArmor.value = false,
            };
            new BaseItem(new int[][]
            {
                new int[] {11},
                new int[] {22,23,21},
                new int[] {16},
                new int[] {1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,31,36,37,38,43,44,45,46,47,49,50,53,54,55,57},
                new int[] {-1},
                new int[] {-1},
                new int[] {24,25,26,0,0,0},
				//new int[] {29,30,48},
			})
            {
                name = Translations.ItemDataBase_ItemDefinitions_316/*Crusader Helmet*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_317/*You're talking mad shit for someone within crusading distance*/, //tr
                Rarity = 5,
                minLevel = 2,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            new BaseItem(new int[][]
        {
                new int[] {1,2,3,4,5,6,57},
                new int[] {-1},
                new int[] {-1},
                new int[] {24,25,26,10,47,0,0,0},
			//new int[] {29,30,48},
		})
            {
                name = Translations.ItemDataBase_ItemDefinitions_318/*Hood*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_319/*Hats provide usefull stat bonuses*/, //tr
                Rarity = 3,
                minLevel = 2,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new int[][]
            {
                new int[] {47 },
                new int[] {4,29 },
                new int[] {4,29 },
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {4,17,6,44,38,21,24,8,9},
                new int[] {2000,2002,49},
                new int[] {2001,4,29,24,21},
                new int[] {2002,4},
                new int[] {2003,-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_320/*The Spark of Light in The Darkness*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_321/*Magic Scroll of great quality*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_322/*Written in a language i canno't understand. Decyphering this text is impossible, so is the full utilization of the scroll.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_323("5")/*If a black hole hits 5 or more enemies during it's lifetime, a ball lightning is summoned after it ends.*/, //tr
                Rarity = 7,
                minLevel = 15,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
                onEquip = () => ModdedPlayer.Stats.i_sparkOfLightAfterDark.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_sparkOfLightAfterDark.value = false
            };
            new BaseItem(new int[][]
          {
                new int[] {21,22,23,24,25,26,1,2,4},
                new int[] {12,13,11,47},
                new int[] {62,63,64,1000,1001,1002,1003,1004},
                new int[] {61},
                new int[] {5,57},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_324/*Purgatory*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_325/*Golden ring with a bone chilling feel about it. This thing will only bring harm, but not to the wearer*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_326/*Ring made of Netherrite*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_327("300%")/*Purge increases all of your damage based on missing health. Up to 300%*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 26,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.spell_purgeDamageBonus.value = true,
                onUnequip = () => ModdedPlayer.Stats.spell_purgeDamageBonus.value = false,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            }.DropSettings_OnlyCannibals();

            new BaseItem(new int[][]
        {
             new int[] {18},
                new int[] {61,48},
                new int[] {2,3,5},
                new int[] {12,13,2,40,16},
                new int[] {39,40,41,42,43,0,0},
                new int[] {23,26},
                new int[] {23,26},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_328/*Eruption*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_329/*Incarnation of devastation*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_330/*Headshots cause explosions*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
                onEquip = () => ModdedPlayer.Stats.i_EruptionBow.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_EruptionBow.value = false,
            }.PossibleStats[0][0].Multipier = -1.6f;

            new BaseItem(new int[][]
        {
             new int[] {18},
                new int[] {61,48},
                new int[] {2,3,5},
                new int[] {12,13,2,40,16},
                new int[] {39,40,41,42,43,0,0},
                new int[] {23,26},
                new int[] {23,26},
                new int[] {31},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
                new int[] {2,3,4,5,6,11,12,13,15,23,26,51,60,44,49,48},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_331/*Archangel*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_332/*Spread the goodness*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_333("30")/*Shooting another player causes them to be greatly empowered for 30 seconds*/, //tr
                Rarity = 7,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),
                onEquip = () => ModdedPlayer.Stats.i_ArchangelBow.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_ArchangelBow.value = false,
            }.PossibleStats[0][0].Multipier = -2f;
            new BaseItem(new int[][]
            {
                new int[] {1,4 },
                new int[] {1,3,5,6,49 },
                new int[] {22},
                new int[] {25},
                new int[] {12},
                new int[] {13},
                new int[] {1,12,13,22,25,30,53,57,65 },
                new int[] {-1 },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_334/*The Executioner*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_335/*A sword for decapitating*/, //tr
                Rarity = 4,
                minLevel = 25,
                maxLevel = 27,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(89),
            };
            new BaseItem(new int[][]
             {
                new int[] {48 },
                new int[] {23,26,2 },
                new int[] {23,26 },
                new int[] {12,13},
                new int[] {60},
                new int[] {13,23,26},
                new int[] {23,26},
                new int[] {34,2,2,54},
                new int[] {15,14},
                new int[] {16,23,2,4,5,6},
                new int[] {45,46},
                new int[] {27,49},
                new int[] {-1},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_336/*Moon Cuirass*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_337/*A piece of armor designed for an archer. */, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_338("120")/*Landing a headshot with an arrow without the homing effect of seeking arrow at a distance greater than 120 feet deals five-fold damage, and hits the enemy two extra times*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.perk_trueAimUpgrade.value = true,
                onUnequip = () => ModdedPlayer.Stats.perk_trueAimUpgrade.value = false,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new int[][]
             {
                new int[] {65 },
                new int[] {1 },
                new int[] {3},
                new int[] {5,65},
                new int[] {5,6,11,10,7,45},
                new int[] {53},
                new int[] {22},
                new int[] {1,3,4,5,31},
                new int[] {28},
                new int[] {63},
                new int[] {16},
                new int[] {-1},
                new int[] {-1},
                new int[] {-1},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_339/*Thornmail*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_340/*Spiked death on the outside, really comfy on the inside*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_341/*Thorns deal double damage*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.thornsDmgMult.valueMultiplicative *= 2,
                onUnequip = () => ModdedPlayer.Stats.thornsDmgMult.valueMultiplicative /= 2,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };

            new BaseItem(new int[][]
                         {
                new int[] {1 },
                         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_342/*Rusty Polearm*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_343/*Used by the Ubersreik Five*/, //tr
                Rarity = 1,
                minLevel = 10,
                maxLevel = 16,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            };
            new BaseItem(new int[][]
                      {
                new int[] {1 },
                new int[] {25,0 },
                new int[] {25 ,62,63,64},
                new int[] {6,49},
                new int[] {39,40,41,42,44,8,18,65 },
                      })
            {
                name = Translations.ItemDataBase_ItemDefinitions_344/*Giant Polearm*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_345/*Used by the Sir Kruber*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 24,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            };

            //Feathers
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_346/*Crude Feather*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_582/*If equipped on a weapon, increases ranged damage by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Weapon, 1).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_583/*If equipped on boots, increases movement speed by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Boot, 1).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_584/*If equipped on a helmet, increases critical hit chance by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Helmet, 1).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_585/*If equipped on accessories, increases ranged armor piercing by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Amulet, 1).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_586/*If equipped in other slots, increases agility by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.ChestArmor, 1).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 3,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 1,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(185),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_348/*Soft Feather*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_582/*If equipped on a weapon, increases ranged damage by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Weapon, 1).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_583/*If equipped on boots, increases movement speed by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Boot, 1).ToString("P") + "\n" +              //tr
                Translations.ItemDataBase_ItemDefinitions_584/*If equipped on a helmet, increases critical hit chance by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Helmet, 1).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_585/*If equipped on accessories, increases ranged armor piercing by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Amulet, 1).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_586/*If equipped in other slots, increases agility by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.ChestArmor, 1).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 1,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(185),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_349/*Ornate Feather*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_582/*If equipped on a weapon, increases ranged damage by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Weapon, 1).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_583/*If equipped on boots, increases movement speed by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Boot, 1).ToString("P") + "\n" +              //tr
                Translations.ItemDataBase_ItemDefinitions_584/*If equipped on a helmet, increases critical hit chance by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Helmet, 1).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_585/*If equipped on accessories, increases ranged armor piercing by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Amulet, 1).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_586/*If equipped in other slots, increases agility by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.ChestArmor, 1).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 5,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 1,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(185),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_350/*Wonderful Feather*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_582/*If equipped on a weapon, increases ranged damage by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Weapon, 1).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_583/*If equipped on boots, increases movement speed by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Boot, 1).ToString("P") + "\n" +              //tr
                Translations.ItemDataBase_ItemDefinitions_584/*If equipped on a helmet, increases critical hit chance by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Helmet, 1).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_585/*If equipped on accessories, increases ranged armor piercing by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Amulet, 1).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_586/*If equipped in other slots, increases agility by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.ChestArmor, 1).ToString("N"),                        //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 6,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 1,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(185),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_351/*White Crow's Feather*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_582/*If equipped on a weapon, increases ranged damage by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Weapon, 1).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_583/*If equipped on boots, increases movement speed by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Boot, 1).ToString("P") + "\n" +              //tr
                Translations.ItemDataBase_ItemDefinitions_584/*If equipped on a helmet, increases critical hit chance by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Helmet, 1).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_585/*If equipped on accessories, increases ranged armor piercing by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Amulet, 1).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_586/*If equipped in other slots, increases agility by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.ChestArmor, 1).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 1,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(185),
            };

            //-------------- Shark teeth

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_352/*Reef Shark*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_587/*If equipped on a weapon, increases melee damage by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Weapon, 2).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_588/*If equipped on boots, decreases damage taken by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Boot, 2).ToString("P") + "\n" +                   //tr
                Translations.ItemDataBase_ItemDefinitions_589/*If equipped on a helmet, increases cattack speed by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Helmet, 2).ToString("P") + "\n" +         //tr
                Translations.ItemDataBase_ItemDefinitions_590/*If equipped on accessories, increases melee armor piercing by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Amulet, 2).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_591/*If equipped in other slots, increases strength by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.ChestArmor, 2).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 3,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 2,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(186),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_353/*Tiger Shark Tooth*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_587/*If equipped on a weapon, increases melee damage by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Weapon, 2).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_588/*If equipped on boots, decreases damage taken by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Boot, 2).ToString("P") + "\n" +                   //tr
                Translations.ItemDataBase_ItemDefinitions_589/*If equipped on a helmet, increases cattack speed by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Helmet, 2).ToString("P") + "\n" +         //tr
                Translations.ItemDataBase_ItemDefinitions_590/*If equipped on accessories, increases melee armor piercing by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Amulet, 2).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_591/*If equipped in other slots, increases strength by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.ChestArmor, 2).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 2,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(186),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_354/*Whale Shark Tooth*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_587/*If equipped on a weapon, increases melee damage by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Weapon, 2).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_588/*If equipped on boots, decreases damage taken by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Boot, 2).ToString("P") + "\n" +                   //tr
                Translations.ItemDataBase_ItemDefinitions_589/*If equipped on a helmet, increases cattack speed by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Helmet, 2).ToString("P") + "\n" +         //tr
                Translations.ItemDataBase_ItemDefinitions_590/*If equipped on accessories, increases melee armor piercing by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Amulet, 2).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_591/*If equipped in other slots, increases strength by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.ChestArmor, 2).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 5,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 2,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(186),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_355/*Great White Shark Tooth*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_587/*If equipped on a weapon, increases melee damage by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Weapon, 2).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_588/*If equipped on boots, decreases damage taken by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Boot, 2).ToString("P") + "\n" +                   //tr
                Translations.ItemDataBase_ItemDefinitions_589/*If equipped on a helmet, increases cattack speed by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Helmet, 2).ToString("P") + "\n" +         //tr
                Translations.ItemDataBase_ItemDefinitions_590/*If equipped on accessories, increases melee armor piercing by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Amulet, 2).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_591/*If equipped in other slots, increases strength by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.ChestArmor, 2).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 6,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 2,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(186),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_356/*Megalodon's Tooth*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_587/*If equipped on a weapon, increases melee damage by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Weapon, 2).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_588/*If equipped on boots, decreases damage taken by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Boot, 2).ToString("P") + "\n" +                   //tr
                Translations.ItemDataBase_ItemDefinitions_589/*If equipped on a helmet, increases cattack speed by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Helmet, 2).ToString("P") + "\n" +         //tr
                Translations.ItemDataBase_ItemDefinitions_590/*If equipped on accessories, increases melee armor piercing by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Amulet, 2).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_591/*If equipped in other slots, increases strength by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.ChestArmor, 2).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 2,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(186),
            };

            //------------- Sapphires

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_357/*Uncut Sapphire*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_592/*If equipped on a weapon, increases magic damage by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Weapon, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_593/*If equipped on boots, decreases spell cost by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Boot, 3).ToString("P") + "\n" +          //tr
                Translations.ItemDataBase_ItemDefinitions_594/*If equipped on a helmet, decreases spell cooldown by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Helmet, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_595/*If equipped on accessories, increases energy on hit by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Amulet, 3).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_596/*If equipped in other slots, increases intelligence by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.ChestArmor, 3).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 3,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 3,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(187),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_358/*Clear Sapphire*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_592/*If equipped on a weapon, increases magic damage by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Weapon, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_593/*If equipped on boots, decreases spell cost by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Boot, 3).ToString("P") + "\n" +          //tr
                Translations.ItemDataBase_ItemDefinitions_594/*If equipped on a helmet, decreases spell cooldown by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Helmet, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_595/*If equipped on accessories, increases energy on hit by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Amulet, 3).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_596/*If equipped in other slots, increases intelligence by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.ChestArmor, 3).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 3,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(187),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_359/*Shiny Sapphire*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_592/*If equipped on a weapon, increases magic damage by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Weapon, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_593/*If equipped on boots, decreases spell cost by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Boot, 3).ToString("P") + "\n" +          //tr
                Translations.ItemDataBase_ItemDefinitions_594/*If equipped on a helmet, decreases spell cooldown by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Helmet, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_595/*If equipped on accessories, increases energy on hit by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Amulet, 3).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_596/*If equipped in other slots, increases intelligence by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.ChestArmor, 3).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 5,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 3,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(187),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_360/*Enchanted Sapphire*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_592/*If equipped on a weapon, increases magic damage by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Weapon, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_593/*If equipped on boots, decreases spell cost by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Boot, 3).ToString("P") + "\n" +          //tr
                Translations.ItemDataBase_ItemDefinitions_594/*If equipped on a helmet, decreases spell cooldown by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Helmet, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_595/*If equipped on accessories, increases energy on hit by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Amulet, 3).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_596/*If equipped in other slots, increases intelligence by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.ChestArmor, 3).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 6,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 3,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(187),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_361/*Celestial Sapphire*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_592/*If equipped on a weapon, increases magic damage by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Weapon, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_593/*If equipped on boots, decreases spell cost by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Boot, 3).ToString("P") + "\n" +          //tr
                Translations.ItemDataBase_ItemDefinitions_594/*If equipped on a helmet, decreases spell cooldown by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Helmet, 3).ToString("P") + "\n" +     //tr
                Translations.ItemDataBase_ItemDefinitions_595/*If equipped on accessories, increases energy on hit by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Amulet, 3).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_596/*If equipped in other slots, increases intelligence by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.ChestArmor, 3).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 3,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(187),
            };

            // -------- Moonstones
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_362/*Uncut Moonstone*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_597/*If equipped on a weapon, increases all healing by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Weapon, 4).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_598/*If equipped on boots, increases magic find by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Boot, 4).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_599/*If equipped on a helmet, increases experience gained by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Helmet, 4).ToString("P") + "\n" +  //tr
                Translations.ItemDataBase_ItemDefinitions_600/*If equipped on accessories, increases life per second by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Amulet, 4).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_601/*If equipped in other slots, increases vitality by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.ChestArmor, 4).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 3,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 4,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(188),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_363/*Clear Moonstone*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_597/*If equipped on a weapon, increases all healing by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Weapon, 4).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_598/*If equipped on boots, increases magic find by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Boot, 4).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_599/*If equipped on a helmet, increases experience gained by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Helmet, 4).ToString("P") + "\n" +  //tr
                Translations.ItemDataBase_ItemDefinitions_600/*If equipped on accessories, increases life per second by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Amulet, 4).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_601/*If equipped in other slots, increases vitality by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.ChestArmor, 4).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 4,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(188),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_364/*Shiny Moonstone*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_597/*If equipped on a weapon, increases all healing by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Weapon, 4).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_598/*If equipped on boots, increases magic find by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Boot, 4).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_599/*If equipped on a helmet, increases experience gained by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Helmet, 4).ToString("P") + "\n" +  //tr
                Translations.ItemDataBase_ItemDefinitions_600/*If equipped on accessories, increases life per second by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Amulet, 4).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_601/*If equipped in other slots, increases vitality by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.ChestArmor, 4).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 5,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 4,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(188),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_365/*Enchanted Moonstone*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_597/*If equipped on a weapon, increases all healing by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Weapon, 4).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_598/*If equipped on boots, increases magic find by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Boot, 4).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_599/*If equipped on a helmet, increases experience gained by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Helmet, 4).ToString("P") + "\n" +  //tr
                Translations.ItemDataBase_ItemDefinitions_600/*If equipped on accessories, increases life per second by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Amulet, 4).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_601/*If equipped in other slots, increases vitality by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.ChestArmor, 4).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 6,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 4,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(188),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_366/*Celestial Moonstone*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_597/*If equipped on a weapon, increases all healing by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Weapon, 4).ToString("P") + "\n" +        //tr
                Translations.ItemDataBase_ItemDefinitions_598/*If equipped on boots, increases magic find by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Boot, 4).ToString("P") + "\n" +            //tr
                Translations.ItemDataBase_ItemDefinitions_599/*If equipped on a helmet, increases experience gained by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Helmet, 4).ToString("P") + "\n" +  //tr
                Translations.ItemDataBase_ItemDefinitions_600/*If equipped on accessories, increases life per second by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Amulet, 4).ToString("N") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_601/*If equipped in other slots, increases vitality by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.ChestArmor, 4).ToString("N"), //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 4,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(188),
            };

            // ----------------- Ores

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_367/*Lead Ore*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_602/*If equipped on a weapon, increases crit damage by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Weapon, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_603/*If equipped on boots, increases resistance to magic by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Boot, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_604/*If equipped on a helmet, increases health by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Helmet, 5).ToString("P") + "\n" +           //tr
                Translations.ItemDataBase_ItemDefinitions_605/*If equipped on accessories, increases thorns by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.Amulet, 5).ToString("N") + "\n" +    //tr
                Translations.ItemDataBase_ItemDefinitions_606/*If equipped in other slots, increases armor by */ + StatActions.GetSocketedStatAmount(3, BaseItem.ItemType.ChestArmor, 5).ToString("N"),           //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 3,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 5,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(184),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_368/*Vanadium Ore*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_602/*If equipped on a weapon, increases crit damage by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Weapon, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_603/*If equipped on boots, increases resistance to magic by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Boot, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_604/*If equipped on a helmet, increases health by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Helmet, 5).ToString("P") + "\n" +           //tr
                Translations.ItemDataBase_ItemDefinitions_605/*If equipped on accessories, increases thorns by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.Amulet, 5).ToString("N") + "\n" +    //tr
                Translations.ItemDataBase_ItemDefinitions_606/*If equipped in other slots, increases armor by */ + StatActions.GetSocketedStatAmount(4, BaseItem.ItemType.ChestArmor, 5).ToString("N"),           //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 5,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(184),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_369/*Titanium Ore*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_602/*If equipped on a weapon, increases crit damage by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Weapon, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_603/*If equipped on boots, increases resistance to magic by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Boot, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_604/*If equipped on a helmet, increases health by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Helmet, 5).ToString("P") + "\n" +           //tr
                Translations.ItemDataBase_ItemDefinitions_605/*If equipped on accessories, increases thorns by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.Amulet, 5).ToString("N") + "\n" +    //tr
                Translations.ItemDataBase_ItemDefinitions_606/*If equipped in other slots, increases armor by */ + StatActions.GetSocketedStatAmount(5, BaseItem.ItemType.ChestArmor, 5).ToString("N"),           //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 5,

                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 5,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(184),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_370/*Chromium Ore*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_602/*If equipped on a weapon, increases crit damage by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Weapon, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_603/*If equipped on boots, increases resistance to magic by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Boot, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_604/*If equipped on a helmet, increases health by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Helmet, 5).ToString("P") + "\n" +           //tr
                Translations.ItemDataBase_ItemDefinitions_605/*If equipped on accessories, increases thorns by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.Amulet, 5).ToString("N") + "\n" +    //tr
                Translations.ItemDataBase_ItemDefinitions_606/*If equipped in other slots, increases armor by */ + StatActions.GetSocketedStatAmount(6, BaseItem.ItemType.ChestArmor, 5).ToString("N"),           //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 6,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 5,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(184),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_371/*Tungsten Ore*/, //tr
                description =
                Translations.ItemDataBase_ItemDefinitions_602/*If equipped on a weapon, increases crit damage by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Weapon, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_603/*If equipped on boots, increases resistance to magic by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Boot, 5).ToString("P") + "\n" + //tr
                Translations.ItemDataBase_ItemDefinitions_604/*If equipped on a helmet, increases health by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Helmet, 5).ToString("P") + "\n" +           //tr
                Translations.ItemDataBase_ItemDefinitions_605/*If equipped on accessories, increases thorns by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.Amulet, 5).ToString("N") + "\n" +    //tr
                Translations.ItemDataBase_ItemDefinitions_606/*If equipped in other slots, increases armor by */ + StatActions.GetSocketedStatAmount(7, BaseItem.ItemType.ChestArmor, 5).ToString("N"),           //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_347/*Materials can be put inside empty sockets to add stats to items*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 21,
                CanConsume = false,
                StackSize = 100,
                subtype = 5,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(184),
            };

            //This is the new better way of defining items, no longer uses item ids, now uses enum like in C++, the enum is Stats, you can find it in ItemDataBase_StatDefinitons.cs
            new BaseItem(new Stat[][]
            {
                new [] {MELEEDMGFROMSTR},
                new [] {STRENGTH},
                new [] {BASEMELEEDAMAGE,MELEEDAMAGEINCREASE},
                new [] {MELEEARMORPIERCING,ARMORPIERCING,ALLATTRIBUTES},
                new [] {ATTACKCOSTREDUCTION,ATTACKSPEED},
                new [] {ATTACKSPEED},
                new [] {ALLATTRIBUTES,MELEEWEAPONRANGE,VITALITY,MAXIMUMLIFE},
                new [] {ENERGYONHIT,VITALITY,LIFEONHIT }
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_372/*Knife on a stick*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_373/*Kasper named this item, his fault*/, //tr
                Rarity = 5,
                minLevel = 30,
                maxLevel = 34,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            };
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH},
                new [] {STRENGTH,ALLATTRIBUTES,MELEEARMORPIERCING,MELEEDAMAGEINCREASE,COOLDOWNREDUCTION,SPELLDAMAGEINCREASE},
                new [] {MAXIMUMLIFE,VITALITY,PERCENTMAXIMUMLIFE,ALLATTRIBUTES},
                new [] {MELEEDAMAGEINCREASE,DAMAGEREDUCTION},
                new [] {THORNS},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION,THORNS},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ENERGYPERSECOND,MAXIMUMENERGY,DODGECHANCE,ARMOR,},
                new [] {STRENGTH,INTELLIGENCE,ARMOR,ARMORPIERCING,THORNS,}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_374/*Fists of Nails*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_375/*Swiss sheese makers*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_376("900%")/*Gain 5 thorns per vitality*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.thornsPerVit.Add(9),
                onUnequip = () => ModdedPlayer.Stats.thornsPerVit.Substract(9),
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new int[][]
          {
                new int[] {1000},
                new int[] {1001},
                new int[] {1002},
                new int[] {1003},
                new int[] {1004},
                new int[] {1,2,3,4,5,6 },
                new int[] {-1 },
                new int[] {-1 },
                new int[] {-1 },
          })
            {
                name = Translations.ItemDataBase_ItemDefinitions_377/*Cargo Shorts MK2*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_378/*Deepest pockets out there*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_379/*Improved cargo pants. Twice as many pockets, and since they didnt fit on the outside, they are inside. They are still ugly as hell tho*/, //tr
                Rarity = 4,
                minLevel = 30,
                maxLevel = 33,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new Stat[][]
            {
                new [] {INTELLIGENCE,AGILITY},
                new [] {MAGICFIND,SPELLDAMAGEINCREASE,BASESPELLDAMAGE},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE},
                new [] {MAXENERGYFROMAGI,SPELLDMGFROMINT,RANGEDDMGFROMAGI},
                new [] {ARMOR},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION,INTELLIGENCE,AGILITY,STRENGTH,ALLATTRIBUTES},
                new [] {COOLDOWNREDUCTION,SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,MOVEMENTSPEED,DAMAGEREDUCTION},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {DODGECHANCE,ARMOR,BASESPELLDAMAGE,BASERANGEDDAMAGE},
                new [] {BASERANGEDDAMAGE,RANGEDARMORPIERCING,RANGEDDAMAGEINCREASE}
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_380/*Aezyn*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_381/*Enchanted with magic as strong as power swing. It's purpose? Hit harder.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_382("1666%")/*Magic arrow damage scaling is increased by 666%*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.spell_magicArrowDamageScaling.Add(16.66f),
                onUnequip = () => ModdedPlayer.Stats.spell_magicArrowDamageScaling.Substract(16.66f),
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new Stat[][]
        {
                new [] {INTELLIGENCE,AGILITY},
                new [] {CRITICALHITCHANCE},
                new [] {CRITICALHITDAMAGE},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION,INTELLIGENCE,AGILITY,STRENGTH,ALLATTRIBUTES},
                new [] {COOLDOWNREDUCTION,SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,MOVEMENTSPEED,DAMAGEREDUCTION},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {DODGECHANCE,ARMOR,BASESPELLDAMAGE,BASERANGEDDAMAGE},
                new [] {BASERANGEDDAMAGE,RANGEDARMORPIERCING,RANGEDDAMAGEINCREASE}
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_383/*Punny's Reflective Ring*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_381/*Enchanted with magic as strong as power swing. It's purpose? Hit harder.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_384/*Magic arrow is shot in volleys. This effect can stack.*/, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Add(3),
                onUnequip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Substract(3),
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
            };
            new BaseItem(new int[][]
                     {
                new int[] {39,0},
                new int[] {43,0},
                new int[] {67},
                     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_385/*Eyepatch*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_386/*A wise man once said:*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_387/*Everyone thinks I'm just a one-eyed bloody monster, god damnit... (sobbing)*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_388/*Explosion damage is also applied when performing jump attacks*/, //tr
                Rarity = 0,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new [] {RANGEDARMORPIERCING},
                new [] {AGILITY},
                new [] {BASERANGEDDAMAGE,RANGEDDAMAGEINCREASE},
                new [] {SPEARDAMAGE},
                new [] {PROJECTILESPEED},
                new [] {ALLATTRIBUTES,PROJECTILESIZE,LESSERAGILITY},
                new [] {ENERGYONHIT,VITALITY,LIFEONHIT }
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_389/*Javelin*/, //tr
                Rarity = 5,
                minLevel = 30,
                maxLevel = 34,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            };
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH},
                new [] {MAXIMUMLIFE, VITALITY,PERCENTMAXIMUMLIFE},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE,BASEMELEEDAMAGE},
                new [] {MELEEDAMAGEINCREASE,BASEMELEEDAMAGE},
                new [] {ATTACKSPEED, CRITICALHITDAMAGE,CRITICALHITCHANCE},
                new [] {MAXENERGYFROMAGI,PERCENTMAXIMUMENERGY,ENERGYONHIT,LIFEONHIT,LIFEPERSECOND,LIFEREGENERATION,STAMINAPERSECOND,STAMINAREGENERATION},
                new [] {ARMOR,THORNS,DAMAGEREDUCTION,PERCENTMAXIMUMLIFE},
                new [] {ALL},
                new [] {ALL},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_390/*Warplate*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_391/*Enchanted with the power of the GOD's armor. It's purpose? Hit harder, daddy.*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_392/*Strength comes from the power of will, the stronger the will the stronger you are*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            {
                var SomeItem = new BaseItem(new Stat[][]
                    {
                new [] {STRENGTH},
                new [] {MAXIMUMLIFE, VITALITY,MAXHEALTHFROMVIT,PERCENTMAXIMUMLIFE},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE,BASEMELEEDAMAGE,ATTACKSPEED},
                new [] {SPELLCOSTREDUCTION, CRITICALHITDAMAGE,CRITICALHITCHANCE},
                new [] {ALL},
                new [] {STRENGTH, THORNS},
                })
                {
                    name = Translations.ItemDataBase_ItemDefinitions_393/*Torso of Strength*/, //tr

                    Rarity = 4,
                    minLevel = 1,
                    maxLevel = 3,
                    CanConsume = false,
                    StackSize = 1,
                    type = BaseItem.ItemType.ChestArmor,
                    icon = Res.ResourceLoader.GetTexture(96),
                };
                SomeItem.PossibleStats[0][0].Multipier = 2;
            }
            {
                var demoVestItem = new BaseItem(new Stat[][]
                    {
                new [] {EXPLOSIONDAMAGE},
                new [] {AGILITY,INTELLIGENCE, ALLATTRIBUTES},
                new [] {MAXIMUMLIFE, VITALITY, LIFEONHIT},
                new [] {ALLHEALINGPERCENT},
                new [] {ALL},
                new [] {MELEEWEAPONRANGE,ENERGYONHIT,ARMORPIERCING, DODGECHANCE},
                new [] {MOVEMENTSPEED,BLOCK,MAGICFIND},

                    })
                {
                    name = Translations.ItemDataBase_ItemDefinitions_394/*Demoman's Vest*/, //tr
                    description = Translations.ItemDataBase_ItemDefinitions_395/*What makes me a good demoman? If I were a bad demoman, I wouldn't be sittin' here discussin' it with you, now would I?! LET'S DO IT! Not one of you's gonna survive this! One crossed wire, one wayward pinch of potassium chlorate, one errant twitch, and KA-BLOOIE! I got a manky eye. I'm a black Scottish cyclops. They got more fecking sea monsters in the great Lochett Ness than they got the likes of me. So! T'all you fine dandies, so proud, so cocksure, prancin' about with your heads full of eyeballs... come and get me, I say! I'll be waitin' on you with a whiff of the old brimstone! I'm a Grimm bloody fable with an unhappy bloody end! Oh, they're going to have to glue you back together...IN HELL!*/, //tr
                    lore = Translations.ItemDataBase_ItemDefinitions_392/*Strength comes from the power of will, the stronger the will the stronger you are*/, //tr
                    Rarity = 5,
                    minLevel = 1,
                    maxLevel = 3,
                    CanConsume = false,
                    StackSize = 1,
                    type = BaseItem.ItemType.ChestArmor,
                    icon = Res.ResourceLoader.GetTexture(96),
                };
                demoVestItem.PossibleStats[0][0].Multipier = 7;

            }
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH,ALLATTRIBUTES,BASEMELEEDAMAGE},
                new [] {MAXIMUMLIFE, VITALITY,DAMAGEREDUCTION,MELEEWEAPONRANGE},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE},
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR},
                new [] {SPELLCOSTREDUCTION, CRITICALHITDAMAGE},
                new [] {ALL},
                new [] {STRENGTH,THORNS,BASEMELEEDAMAGE,CRITICALHITCHANCE,ATTACKSPEED,MELEEWEAPONRANGE},
                new [] {ARMOR},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_396/*Brawler's Gloves*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALLATTRIBUTES,STRENGTH,AGILITY,INTELLIGENCE},
                new [] {MAXIMUMLIFE, VITALITY,STRENGTH,INTELLIGENCE},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE,RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,RANGEDARMORPIERCING},
                new [] {SPELLCOSTREDUCTION, CRITICALHITDAMAGE,CRITICALHITCHANCE,SPELLDAMAGEINCREASE,COOLDOWNREDUCTION},
                new [] {ARMORPIERCING},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,RESISTANCETOMAGIC,VITALITY,LESSERVITALITY},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_397/*Nail Gloves*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_398/*Enchanted with the power of penetration. It's purpose? Hit harder.*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ATTACKSPEED},
                new [] {RANGEDDAMAGEINCREASE,RANGEDDMGFROMAGI},
                new [] {BASERANGEDDAMAGE},
                new [] {BASERANGEDDAMAGE,NONE},
                new [] {PROJECTILESIZE,LESSERAGILITY,AGILITY},
                new [] {PROJECTILESPEED,CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new [] {AGILITY,NONE},
                new [] {RANGEDARMORPIERCING, ARMORPIERCING,ENERGYONHIT},
                new [] {ALL},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_399/*Hand-held Ballista*/, //tr
                Rarity = 5,
                minLevel = 10,
                maxLevel = 12,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Greatbow,
                icon = Res.ResourceLoader.GetTexture(170),

            }.PossibleStats[0][0].Multipier = -2f;

            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH,LESSERSTRENGTH},
                new [] {MAXIMUMLIFE, VITALITY,MELEEDMGFROMSTR,ARMOR},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_400/*Kuldars's Scarf*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_401/*Strength comes from the power of will*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
            };
            new BaseItem(new Stat[][]
            {
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR},
                new [] {MAXIMUMLIFE, VITALITY,MELEEDAMAGEINCREASE,BASEMELEEDAMAGE},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,ARMOR},
                new [] {SPELLCOSTREDUCTION, CRITICALHITDAMAGE,CRITICALHITCHANCE},
                new [] {ALL},
                new [] {STRENGTH,LESSERSTRENGTH},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_402/*Sword Devil's Scarf*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
            };
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH},
                new [] {MAXIMUMLIFE, VITALITY},
                new [] {MELEEARMORPIERCING, MELEEDAMAGEINCREASE},
                new [] {SPELLCOSTREDUCTION, CRITICALHITDAMAGE},
                new [] {STRENGTH},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_403/*Peasant's Scarf*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
            };
            new BaseItem(new Stat[][]
            {
                new [] {EXPLOSIONDAMAGE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_404/*Bombastinc Choker*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
            }.PossibleStats[0][0].Multipier = 7f;
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH,VITALITY,AGILITY,ALLATTRIBUTES,INTELLIGENCE},
                new [] {MAXENERGYFROMAGI,MELEEDMGFROMSTR,SPELLDMGFROMINT,RANGEDDMGFROMAGI,MAXHEALTHFROMVIT},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] { CRITICALHITCHANCE, CRITICALHITDAMAGE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE,NONE},
                new [] {EXPLOSIONDAMAGE,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_405/*Explosive Touch*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_406/*Enchanted with the power of the explosions armor. It's purpose? Become the true explosion master*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_407/*Strength comes from the power of will, the stronger the will the stronger the explosion*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ARMOR},
                new [] {MAXIMUMLIFE, VITALITY},
                new [] {CRITICALHITCHANCE, CRITICALHITDAMAGE,ATTACKSPEED,BASESPELLDAMAGE,STAMINAPERSECOND},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALLATTRIBUTES},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_408/*Volatile Bracers*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_406/*Enchanted with the power of the explosions armor. It's purpose? Become the true explosion master*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_407/*Strength comes from the power of will, the stronger the will the stronger the explosion*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ARMOR},
                new [] {MAXIMUMLIFE, VITALITY},
                new [] {CRITICALHITCHANCE, CRITICALHITDAMAGE,ATTACKSPEED,BASESPELLDAMAGE,STAMINAPERSECOND},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {EMPTYSOCKET},
                new [] {EMPTYSOCKET},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_409/*Volatile Helmet*/, //tr

                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {MAXIMUMLIFE, VITALITY,ARMOR,PERCENTMAXIMUMLIFE,PERCENTMAXIMUMENERGY,MAXHEALTHFROMVIT,THORNS,RESISTANCETOMAGIC},
                new [] {JUMPPOWER},
                new [] {MOVEMENTSPEED},
                new [] {EMPTYSOCKET},
                new [] {EMPTYSOCKET},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_410/*Gunpowder filled socks*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {MAXIMUMLIFE, VITALITY,ARMOR,PERCENTMAXIMUMLIFE,PERCENTMAXIMUMENERGY,MAXHEALTHFROMVIT,THORNS,RESISTANCETOMAGIC},
                new [] {EMPTYSOCKET},
                new [] {EMPTYSOCKET},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_411/*Red Skirt*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {MAXIMUMLIFE, VITALITY,ARMOR},
                new [] {MELEEARMORPIERCING, RANGEDARMORPIERCING},
                new [] {ARMOR, ALLATTRIBUTES,VITALITY,LESSERVITALITY},
                new [] {EXTRACARRIEDSTICKS,EXTRACARRIEDROCKS,EXTRACARRIEDROPES},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_412/*Gunpowder Boxers*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            new BaseItem(new Stat[][]
            {
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE},
                new [] {EXPLOSIONDAMAGE,NONE},
                new [] {EXPLOSIONDAMAGE,NONE},
                new [] {ARMOR},
                new [] {PERCENTMAXIMUMLIFE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_413/*Jihad Vest*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 4,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };

            new BaseItem(new Stat[][]
            {
                new [] {CRITICALHITCHANCE},
                new [] {MAGICFIND,NONE,EXPGAIN},
                new [] {RANGEDDAMAGEINCREASE,MELEEDAMAGEINCREASE},
                new [] {STRENGTH,AGILITY},
                new [] {ALL},
                new [] {CHANCEONHITTOBLEED},
                new [] {CHANCEONHITTOSLOW},
                new [] {CHANCEONHITTOWEAKEN},
                new [] {MAXENERGYFROMAGI,FIREDAMAGE,CRITICALHITDAMAGE,RANGEDDMGFROMAGI,MELEEDMGFROMSTR},


            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_414/*Ring of Fortune*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new Stat[][]
            {
                new [] {SPELLDAMAGEINCREASE},
                new [] {INTELLIGENCE},
                new [] {COOLDOWNREDUCTION},
                new [] {ALLATTRIBUTES, INTELLIGENCE,SPELLDAMAGEINCREASE},
                new [] {SPELLDMGFROMINT,MAXENERGYFROMAGI},
                new [] {BASESPELLDAMAGE},
                new [] {PERCENTMAXIMUMENERGY,ENERGYONHIT,ENERGYPERSECOND},
                new [] {FIREDAMAGE,SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA},


            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_415/*Mana Ring*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new Stat[][]
            {
                new [] {MELEEDMGFROMSTR,ALLATTRIBUTES,STAMINAPERSECOND,STAMINAREGENERATION,DODGECHANCE},
                new [] {STRENGTH,LESSERSTRENGTH,VITALITY,ARMOR},
                new [] {MELEEWEAPONRANGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE},
                new [] {VITALITY},
                new [] {MAXHEALTHFROMVIT,MAXENERGYFROMAGI},
                new [] {LIFEPERSECOND},
                new [] {LIFEONHIT},
                new [] {ENERGYONHIT,ENERGYPERSECOND,INTELLIGENCE,AGILITY},
                new [] {MAXIMUMLIFE},
                new [] {PERCENTMAXIMUMLIFE,CRITICALHITCHANCE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_416/*Life Ring*/, //tr
                Rarity = 6,     //range 0-7, 0 is most common, 7 is ultra rare
                minLevel = 10,
                maxLevel = 14,
                CanConsume = false,
                StackSize = 1,   //stacking in inventory like in mc, one means single item
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };
            new BaseItem(new Stat[][]
            {
            new [] {STRENGTH},
            new [] {MOVEMENTSPEED,DODGECHANCE,DAMAGEREDUCTION},
            new [] {VITALITY,MAXHEALTHFROMVIT,MAXIMUMLIFE,PERCENTMAXIMUMLIFE,ARMOR},
            new [] {INTELLIGENCE,MAXENERGYFROMAGI,PERCENTMAXIMUMENERGY,MAXIMUMENERGY,BASEMELEEDAMAGE,MELEEDAMAGEINCREASE,ARMOR,DAMAGEREDUCTION},
            new [] {MELEEARMORPIERCING,MELEEDAMAGEINCREASE},
            new [] {ARMOR,ATTACKSPEED,STRENGTH},
            new [] {BASEMELEEDAMAGE},
            new [] {BASEMELEEDAMAGE,MELEEDAMAGEINCREASE},
            new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR},
            new [] {CRITICALHITCHANCE,MELEEWEAPONRANGE,ATTACKSPEED},
            new [] {CRITICALHITDAMAGE, MELEEDAMAGEINCREASE, STRENGTH},
            new [] {ENERGYONHIT,ENERGYPERSECOND,MAXIMUMLIFE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_417/*Moritz's Gear*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH,BASEMELEEDAMAGE,MELEEDAMAGEINCREASE,ATTACKSPEED},
                new [] {MOVEMENTSPEED,DODGECHANCE,DAMAGEREDUCTION},
                new [] {VITALITY,MAXHEALTHFROMVIT,MAXIMUMLIFE,PERCENTMAXIMUMLIFE,MELEEARMORPIERCING},
                new [] {INTELLIGENCE,STRENGTH,CRITICALHITDAMAGE,PERCENTMAXIMUMENERGY,MAXIMUMENERGY},
                new [] {BASEMELEEDAMAGE},
                new [] {BASEMELEEDAMAGE,MELEEDAMAGEINCREASE},
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR},
                new [] {CRITICALHITCHANCE,MELEEWEAPONRANGE},
                new [] {CRITICALHITDAMAGE, MELEEDAMAGEINCREASE, STRENGTH},
                new [] {ENERGYONHIT,ENERGYPERSECOND,MAXIMUMLIFE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_418/*Band of Hurting*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_419/*A ring for a warrior*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90), //icon ids, don't worry about that
            };

            new BaseItem(new Stat[][]
            {
                new [] {AGILITY,RANGEDDAMAGEINCREASE},
                new [] {ALLATTRIBUTES, ARMOR,PERCENTMAXIMUMLIFE},
                new [] {CRITICALHITCHANCE},
                new [] {CRITICALHITDAMAGE,NONE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_420/*Straw Hat*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new [] {INTELLIGENCE},
                new [] {ALLATTRIBUTES, ARMOR,ENERGYONHIT},
                new [] {BASESPELLDAMAGE},
                new [] {FIREDAMAGE,SPELLDAMAGEINCREASE,SPELLCOSTREDUCTION},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_318/*Hood*/, //tr
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
        {
                new [] {SPEARDAMAGE},
                new [] {AGILITY},
                new [] {STAMINAPERSECOND},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_421/*Rusty Javelin*/, //tr
                Rarity = 3,
                minLevel = 10,
                maxLevel = 16,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            };
            new BaseItem(new Stat[][]
            {
            new [] {INTELLIGENCE},
            new [] {DODGECHANCE,DAMAGEREDUCTION},
            new [] {VITALITY,MAXHEALTHFROMVIT,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
            new [] {SPELLDMGFROMINT},
            new [] {SPELLCOSTREDUCTION,COOLDOWNREDUCTION},
            new [] {SPELLCOSTREDUCTION,COOLDOWNREDUCTION},
            new [] {ENERGYPERSECOND,PERCENTMAXIMUMENERGY,MAXENERGYFROMAGI},
            new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE},
            new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE},
            new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE},
            new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE},
            new [] {ENERGYONHIT,ENERGYPERSECOND,MAXIMUMLIFE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_422/*Star Robe*/, //tr
                Rarity = 6,
                minLevel = 5,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ATTACKSPEED},
                new [] {BASESPELLDAMAGE},
                new [] {DODGECHANCE,DAMAGEREDUCTION,MELEEWEAPONRANGE,ARMORPIERCING,FIREDAMAGE,CRITICALHITCHANCE},
                new [] {VITALITY,MAXHEALTHFROMVIT,MAXIMUMLIFE,PERCENTMAXIMUMLIFE,LIFEPERSECOND,LIFEONHIT},
                new [] {SPELLDMGFROMINT},
                new [] {SPELLCOSTREDUCTION,COOLDOWNREDUCTION,CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new [] {SPELLCOSTREDUCTION,COOLDOWNREDUCTION,SPELLCOSTTOSTAMINA,PERCENTMAXIMUMENERGY,LIFEREGENERATION},
                new [] {ENERGYPERSECOND,PERCENTMAXIMUMENERGY,MAXENERGYFROMAGI},
                new [] {INTELLIGENCE,STAMINAPERSECOND,STAMINAREGENERATION},
                new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE,BASEMELEEDAMAGE,ALLATTRIBUTES},
                new [] {BASESPELLDAMAGE,SPELLDAMAGEINCREASE,INTELLIGENCE,DAMAGEREDUCTION},
                new [] {ENERGYONHIT,ENERGYPERSECOND,MAXIMUMLIFE,MASSACREDURATION,MAGICFIND,EXPLOSIONDAMAGE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_423/*Anger*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_424/*Downscaled version of Greatsword Rage, made to be wielded by flimsy wizards*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_425(15)/*Increases maximum stacks of frenzy by 10*/, //tr
                Rarity = 7,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.LongSword,
                icon = Res.ResourceLoader.GetTexture(88),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Add(15),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Substract(15),
            }.PossibleStats[0][0].Multipier = 1.5f;


            new BaseItem(new Stat[][]
            {
                new[] { ARMOR },
                new[] { MOVEMENTSPEED},
                new[] { SPELLDMGFROMINT },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { BASESPELLDAMAGE, SPELLDAMAGEINCREASE, INTELLIGENCE, ALLATTRIBUTES },
                new[] { BASESPELLDAMAGE, SPELLDAMAGEINCREASE, INTELLIGENCE, DAMAGEREDUCTION },
                new[] { VITALITY, MAXHEALTHFROMVIT, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR,MAXHEALTHFROMVIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, SPELLCOSTTOSTAMINA, PERCENTMAXIMUMENERGY, LIFEREGENERATION },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
                new[] { ENERGYONHIT, ENERGYPERSECOND, MAXIMUMLIFE, MASSACREDURATION, MAGICFIND, EXPLOSIONDAMAGE },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_426/*Yuki-Onna Strides*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_433("50%", "300%")/*Set Piece:\n2 Pieces- Snow Storm pulls enemies towards you\n3 Pieces - Snow Storm radius, maximum damage, spell cost is doubled, but charge rate is slower\n4 Pieces - Snow storm hit frequency is increased by 50%*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_428/*Boots looted off a snow demon*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_429("50%")/*Increses snowstorm damage by 50%*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
                onEquip = () => AkagiSet.Equip(),
                onUnequip = () => AkagiSet.Unequip(),
            };

            new BaseItem(new Stat[][]
            {
                new[] { INTELLIGENCE,NONE },
                new[] { ARMOR },
                new[] { ALLHEALINGPERCENT,DODGECHANCE,SPELLDAMAGEINCREASE,BASESPELLDAMAGE},
                new[] { SPELLDMGFROMINT,DAMAGEREDUCTION },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { ARMOR,DAMAGEREDUCTION ,RESISTANCETOMAGIC},
                new[] { INTELLIGENCE, MAXIMUMLIFE,LIFEPERSECOND,SPELLDAMAGEINCREASE,BASESPELLDAMAGE },
                new[] { VITALITY, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, SPELLCOSTTOSTAMINA, PERCENTMAXIMUMENERGY, LIFEREGENERATION,RESISTANCETOMAGIC },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI,MAXHEALTHFROMVIT },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_430/*Yuki-Onna Greaves*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_433("50%", "300%")/*Set Piece:\n2 Pieces- Snow Storm pulls enemies towards you\n3 Pieces - Snow Storm radius, maximum damage, spell cost is doubled, but charge rate is slower\n4 Pieces - Snow storm hit frequency is increased by 50%*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_429("50%")/*Increses snowstorm damage by 50%*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
                onEquip = () => AkagiSet.Equip(),
                onUnequip = () => AkagiSet.Unequip(),
            };

            new BaseItem(new Stat[][]
            {
                new[] { INTELLIGENCE,NONE },
                new[] { ARMOR },
                new[] { ALLHEALINGPERCENT,DODGECHANCE},
                new[] { SPELLDMGFROMINT,DAMAGEREDUCTION },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { ARMOR,DAMAGEREDUCTION ,RESISTANCETOMAGIC,SPELLDAMAGEINCREASE,BASESPELLDAMAGE},
                new[] { INTELLIGENCE, MAXIMUMLIFE,LIFEPERSECOND,SPELLDAMAGEINCREASE,BASESPELLDAMAGE },
                new[] { VITALITY, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, SPELLCOSTTOSTAMINA, PERCENTMAXIMUMENERGY, LIFEREGENERATION,RESISTANCETOMAGIC },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI,MAXHEALTHFROMVIT },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_431/*Yuki-Onna Kimono*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_433("50%", "300%")/*Set Piece:\n2 Pieces- Snow Storm pulls enemies towards you\n3 Pieces - Snow Storm radius, maximum damage, spell cost is doubled, but charge rate is slower\n4 Pieces - Snow storm hit frequency is increased by 50%*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_429("50%")/*Increses snowstorm damage by 50%*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
                onEquip = () => AkagiSet.Equip(),
                onUnequip = () => AkagiSet.Unequip(),
            };

            new BaseItem(new Stat[][]
            {
                new[] { INTELLIGENCE,NONE },
                new[] { ARMOR },
                new[] { CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new[] { SPELLDMGFROMINT },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { ARMOR, SPELLDAMAGEINCREASE, BASESPELLDAMAGE, RESISTANCETOMAGIC},
                new[] { INTELLIGENCE, MAXIMUMLIFE,LIFEPERSECOND },
                new[] { SPELLDAMAGEINCREASE,BASESPELLDAMAGE, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, SPELLCOSTTOSTAMINA, PERCENTMAXIMUMENERGY, LIFEREGENERATION,RESISTANCETOMAGIC },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI,MAXHEALTHFROMVIT },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_432/*Yuki-Onna's Headdress*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_433("50%", "300%")/*Set Piece:\n2 Pieces- Snow Storm pulls enemies towards you\n3 Pieces - Snow Storm radius, maximum damage, spell cost is doubled, but charge rate is slower\n4 Pieces - Snow storm hit frequency is increased by 50% and damage is increased by 300%*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_429("50%")/*Increses snowstorm damage by 50%*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
                onEquip = () => AkagiSet.Equip(),
                onUnequip = () => AkagiSet.Unequip(),
            };

            new BaseItem(new Stat[][]
        {
                new[] { INTELLIGENCE,NONE },
                new[] { ARMOR },
                new[] { CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new[] { SPELLDMGFROMINT },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { ARMOR, SPELLDAMAGEINCREASE, BASESPELLDAMAGE, RESISTANCETOMAGIC},
                new[] { INTELLIGENCE, MAXIMUMLIFE,LIFEPERSECOND },
                new[] { SPELLDAMAGEINCREASE,BASESPELLDAMAGE, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, SPELLCOSTTOSTAMINA, PERCENTMAXIMUMENERGY, LIFEREGENERATION,RESISTANCETOMAGIC },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI,MAXHEALTHFROMVIT },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_434/*Lama Mega's Blood Bag*/, //tr
                description = "", //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_435("15 000%", 15)/*Melee hits cause enemies to bleed for 100% of your health as damage for 15 seconds*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () => COTFEvents.Instance.OnHitMelee.AddListener(UniqueItemFunctions.EnemyBleedForPlayerHP),
                onUnequip = () => COTFEvents.Instance.OnHitMelee.RemoveListener(UniqueItemFunctions.EnemyBleedForPlayerHP),
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_436/*Socket Drill*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_437/*A convienient one use tool*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_438/*What's a drill doing here in a place full of primitive tribes?*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_439/*Adds one socket to an item, unless the item can't have any more sockets.*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(190),
                onConsume = x =>
                {
                    int socketMax = StatActions.GetMaxSocketAmountOnItem(in x.type);
                    int socketCurrent = x.Stats.Count(y => y.StatID >= 3000);
                    if (socketCurrent < socketMax)
                    {
                        x.Stats.Add(new ItemStat(ItemDataBase.StatByID(3000)));
                        return true;
                    }
                    return false;
                }
            };
            new BaseItem(new Stat[][]
            {
                new[] { MOVEMENTSPEED},
                new[] { INTELLIGENCE,STRENGTH,AGILITY },
                new[] { ALLATTRIBUTES,VITALITY },
                new[] { ARMOR },
                new[] { NONE,JUMPPOWER},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_440/*Moonwalkers*/, //tr
                description = "", //tr
                lore = Translations.ItemDataBase_ItemDefinitions_441/*Cha cha real smooth.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_442/*Inverts movement*/, //tr
                Rarity = 3,
                minLevel = 16,
                maxLevel = 18,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
                onEquip = () => ModdedPlayer.Stats.movementSpeed.Multiply(-1.2f),
                onUnequip = () => ModdedPlayer.Stats.movementSpeed.Divide(-1.2f)
            }.PossibleStats[0][0].Multipier = 3;

            new BaseItem(new Stat[][]
            {
                new[] { JUMPPOWER},
                new[] { LESSERAGILITY},
                new[] { LESSERARMOR},
                new[] { PROJECTILESIZE,PROJECTILESIZE,ALLATTRIBUTES,LIFEREGENERATION,LIFEPERSECOND,LESSERVITALITY,AGILITY},
                new[] { RANGEDARMORPIERCING,RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,ATTACKSPEED},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_443/*Rabbit Ears Hairband*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_444/*Cute*/, //tr
                lore = "", //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new[] { JUMPPOWER},
                new[] { AGILITY},
                new[] { ARMOR},
                new[] { PROJECTILESIZE,PROJECTILESIZE,ALLATTRIBUTES,LIFEREGENERATION,LIFEPERSECOND,VITALITY,INTELLIGENCE,AGILITY},
                new[] { RANGEDARMORPIERCING,RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,ATTACKSPEED},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_445/*Bunny Ears Hairband*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_444/*Cute*/, //tr
                lore = "", //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new int[][]
            {
                new int[] {11},
                new int[] {16},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000},
                new int[] {3000,0},
                new int[] {3000,0},
                new int[] {3000,0},
                new int[] {3000,0},
                new int[] {3000,0},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_446/*Iron plate full of holes*/, //tr
                description = "", //tr
                lore = Translations.ItemDataBase_ItemDefinitions_447/*The integrity of this item is questionable*/, //tr
                Rarity = 3,
                minLevel = 50,
                maxLevel = 60,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,DAMAGEREDUCTION},
                new [] {ALLATTRIBUTES,AGILITY,STRENGTH,INTELLIGENCE,VITALITY},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_448/*Small Tribal Necklace*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_449(2)/*Increases maximum stacks of frenzy by 2*/, //tr
                Rarity = 4,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Add(2),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Substract(2),
            };
            new BaseItem(new Stat[][]
        {
                new [] {ALL},
                new [] {ALL},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,DAMAGEREDUCTION},
                new [] {ALLATTRIBUTES,AGILITY,STRENGTH,INTELLIGENCE,VITALITY},

        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_450/*Tribal Necklace*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_451(3)/*Increases maximum stacks of frenzy by 3*/, //tr
                Rarity = 4,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Add(3),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Substract(3),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,DAMAGEREDUCTION},
                new [] {ALLATTRIBUTES,AGILITY,STRENGTH,INTELLIGENCE,VITALITY},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_452/*Warlord Necklace*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_453(4)/*Increases maximum stacks of frenzy by 4*/, //tr
                Rarity = 5,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Add(4),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyMaxStacks.Substract(4),
            };
            new BaseItem(new Stat[][]
         {
                new [] {ALL},
                new [] {ALL},
                new [] {MOVEMENTSPEED,COOLDOWNREDUCTION},
                new [] {JUMPPOWER,ATTACKSPEED,MOVEMENTSPEED,ENERGYPERSECOND},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE,CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new [] {ALLATTRIBUTES,AGILITY,STRENGTH,INTELLIGENCE,VITALITY},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_454/*Travel Band*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_455(25)/*The distance of blink is increased by <color=gold>20</color> feet*/, //tr
                Rarity = 5,
                minLevel = 5,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
                onEquip = () => { ModdedPlayer.Stats.spell_blinkRange.Add(25); },
                onUnequip = () => { ModdedPlayer.Stats.spell_blinkRange.Substract(25); },
            };

            new BaseItem(new Stat[][]
     {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {COOLDOWNREDUCTION,NONE},
     })
            {
                name = Translations.ItemDataBase_ItemDefinitions_456/*Destroyed Void Shard*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_457/*Only a fraction of its previous might remains*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_154/*A pedant of great power. Obtainable only from babies or crafting*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_458(1)/*Decrease the cooldown of one ability by 1 second whenever you hit something with melee or ranged attack.*/, //tr
                Rarity = 6,
                minLevel = 80,
                maxLevel = 90,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(101),
                onEquip = () => ModdedPlayer.Stats.i_infinityLoop.value = true,
                onUnequip = () => ModdedPlayer.Stats.i_infinityLoop.value = false,
            };
            new BaseItem(new int[][]
            {
                new int[] {25 },
                new int[] {18 },
                new int[] {2004 },
                new int[] {1,3,62,63,64},
                new int[] {53,16},
                new int[] {25 ,22,1,12,13,5,6},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_459/*Famine Hammer*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_163/*It's slow but with enough strength i can make it a very deadly tool*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_460("30%")/*Chance to weaken enemies, causing them to take more damage from all attacks, is increased by 30%*/, //tr
                Rarity = 4,
                minLevel = 30,
                maxLevel = 35,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
                onEquip = () => ModdedPlayer.Stats.chanceToWeaken.Add(0.3f),
                onUnequip = () => ModdedPlayer.Stats.chanceToWeaken.Substract(0.3f),
            };

            new BaseItem(new int[][]
            {
                new int[] {25 },
                new int[] {18 },
                new int[] {-1 },
                new int[] {2004 },
                new int[] {1,3,62,63,64},
                new int[] {53,16},
                new int[] {25 ,22,1,12,13,5,6},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_461/*Curse Hammer*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_462/*Omnious Weapon*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_463("45%")/*Chance to weaken enemies, causing them to take more damage from all attacks, is increased by 40%*/, //tr
                Rarity = 5,
                minLevel = 30,
                maxLevel = 35,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
                onEquip = () => ModdedPlayer.Stats.chanceToWeaken.Add(0.45f),
                onUnequip = () => ModdedPlayer.Stats.chanceToWeaken.Substract(0.45f),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR},
                new [] {STRENGTH},
                new [] {BASEMELEEDAMAGE},
                new [] {ATTACKCOSTREDUCTION,ATTACKSPEED,LIFEONHIT,ENERGYONHIT,NONE,NONE,NONE},
                new [] {ALLATTRIBUTES,VITALITY,MELEEDAMAGEINCREASE,MELEEARMORPIERCING},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_464/*Smasher*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_163/*It's slow but with enough strength i can make it a very deadly tool*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_465/*Smash damage is increased tripled*/, //tr
                Rarity = 5,
                minLevel = 30,
                maxLevel = 35,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Hammer,
                icon = Res.ResourceLoader.GetTexture(109),
                onEquip = () => { ModdedPlayer.Stats.smashDamage.Multiply(3f); },
                onUnequip = () => { ModdedPlayer.Stats.smashDamage.Divide(3f); },
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {LIFEONHIT},
                new [] {ENERGYONHIT},
                new [] {STAMINAREGENERATION,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_466/*Vampiric Band*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_467(1)/*Gain 1 stamina on ranged and melee hit or double that amount on critical hits*/, //tr
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
                onEquip = () => COTFEvents.Instance.OnHitEnemy.AddListener(UniqueItemFunctions.Gain1EnergyOnHit),
                onUnequip = () => COTFEvents.Instance.OnHitEnemy.RemoveListener(UniqueItemFunctions.Gain1EnergyOnHit),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {LIFEONHIT},
                new [] {CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new [] {MELEEDAMAGEINCREASE,RANGEDDAMAGEINCREASE,SPELLDAMAGEINCREASE},
                new [] {ENERGYONHIT},
                new [] {STAMINAREGENERATION,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_468/*Vampire Ring*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_469(10)/*Gain 10 stamina on ranged and melee hit or double that amount on critical hits*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Ring,
                icon = Res.ResourceLoader.GetTexture(90),
                onEquip = () => COTFEvents.Instance.OnHitEnemy.AddListener(UniqueItemFunctions.Gain10EnergyOnHit),
                onUnequip = () => COTFEvents.Instance.OnHitEnemy.RemoveListener(UniqueItemFunctions.Gain10EnergyOnHit),
            };
            new BaseItem(new Stat[][]
        {
                new [] {SPELLDAMAGEINCREASE,INTELLIGENCE,BASESPELLDAMAGE},
                new [] {SPELLDAMAGEINCREASE,INTELLIGENCE,BASESPELLDAMAGE},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION,INTELLIGENCE,AGILITY,STRENGTH,ALLATTRIBUTES},
                new [] {COOLDOWNREDUCTION,SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,INTELLIGENCE,DAMAGEREDUCTION},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_470/*Tricksters Scarf*/, //tr
                description = "", //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_471(1)/*Magic arrow shoots 1 additional arrow.*/, //tr
                Rarity = 4,
                minLevel = 20,
                maxLevel = 22,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Add(1),
                onUnequip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Substract(1),
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100)
            };
            new BaseItem(new Stat[][]
        {
                new [] {SPELLDAMAGEINCREASE,INTELLIGENCE,BASESPELLDAMAGE},
                new [] {SPELLDAMAGEINCREASE,INTELLIGENCE,BASESPELLDAMAGE},
                new [] {VITALITY,LIFEPERSECOND,LIFEREGENERATION,INTELLIGENCE,AGILITY,STRENGTH,ALLATTRIBUTES},
                new [] {COOLDOWNREDUCTION,SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,INTELLIGENCE,DAMAGEREDUCTION},
                new [] {INTELLIGENCE},
                new [] {ALL},

        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_472/*Magus' Necktie*/, //tr
                description = "", //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_473(2)/*Magic arrow shoots 2 additional arrows.*/, //tr
                Rarity = 5,
                minLevel = 50,
                maxLevel = 52,
                CanConsume = false,
                StackSize = 1,
                onEquip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Add(2),
                onUnequip = () => ModdedPlayer.Stats.spell_magicArrowVolleyCount.Substract(2),
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100)
            };
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {34,18,17,16,15,14,60,61,55,},
                    new int[] {16,19,23,31,54,51,52,66,57},
                    new int[] {2,3,4,5,6,7,8,9,10},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_474/*Discounted Knockoff Magic Quiver*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_475("15%")/*There's a 15% increased chance to not consume ammo when firing a projectile.*/, //tr
                Rarity = 3,
                minLevel = 2,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Add(0.15f),
                onUnequip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Substract(0.15f),
            };
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {34,18,17,16,15,14,60,61,55,},
                    new int[] {16,19,23,31,54,51,52,66,57},
                    new int[] {2,48,0,0},
                    new int[] {2,3,4,5,6,7,8,9,10},
                    new int[] {2,1,5,6,0},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_476/*Magic Quiver*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_477("20%")/*There's a 20% increased chance to not consume ammo when firing a projectile.*/, //tr
                Rarity = 4,
                minLevel = 2,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Add(0.2f),
                onUnequip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Substract(0.2f),
            };
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {23},
                    new int[] {34,18,17,16,15,14,60,61,55,},
                    new int[] {16,19,23,31,54,51,52,66,57},
                    new int[] {2,48},
                    new int[] {2,3,4,5,6,7,8,9,10},
                    new int[] {2,1,5,6},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_478/*Improved Magic Quiver*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_479("25%")/*There's a 25% increased chance to not consume ammo when firing a projectile.*/, //tr
                Rarity = 5,
                minLevel = 2,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Add(0.25f),
                onUnequip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Substract(0.25f),
            };
            new BaseItem(new int[][]
            {
                    new int[] {23,26},
                    new int[] {23},
                    new int[] {34,18,17,16,15,14,60,61,55,},
                    new int[] {16,19,23,31,54,51,52,66,57},
                    new int[] {2,16,14},
                    new int[] {2,3,4,5,6,7,8,9,10},
                    new int[] {48},
                    new int[] {-1},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_480/*Factory Quiver*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_481("40%")/*There's a 40% increased chance to not consume ammo when firing a projectile.*/, //tr
                Rarity = 6,
                minLevel = 12,
                maxLevel = 20,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Quiver,
                icon = Res.ResourceLoader.GetTexture(98),
                onEquip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Add(0.4f),
                onUnequip = () => ModdedPlayer.Stats.perk_projectileNoConsumeChance.Substract(0.4f),
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_482/*Enzyme STR/34*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_484/*Changes Vitality, Agility or Intelligence stat on an item to <color=red>Strength</color> or changes Ranged or Spell damage stat to <color=red>Melee Damage</color>*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(193),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.Where(y => y.StatID == (int)VITALITY || y.StatID == (int)INTELLIGENCE || y.StatID == (int)AGILITY
                                                     || y.StatID == (int)LESSERVITALITY || y.StatID == (int)LESSERINTELLIGENCE || y.StatID == (int)LESSERAGILITY
                                                     || y.StatID == (int)BASERANGEDDAMAGE || y.StatID == (int)BASESPELLDAMAGE
                                                     || y.StatID == (int)RANGEDDAMAGEINCREASE || y.StatID == (int)SPELLDAMAGEINCREASE).ToArray();

                    int c = stats.Count();


                    if (c == 0)
                        return false;
                    int i = UnityEngine.Random.Range(0, c);
                    ItemStat stat = stats[i];
                    int index = x.Stats.IndexOf(stat);

                    ItemStat newStat;
                    Stat statID = (Stat)stat.StatID;
                    switch (statID)
                    {
                        case VITALITY:
                        case INTELLIGENCE:
                        case AGILITY:
                            newStat = new ItemStat(StatByID((int)STRENGTH));
                            break;
                        case LESSERVITALITY:
                        case LESSERINTELLIGENCE:
                        case LESSERAGILITY:
                            newStat = new ItemStat(StatByID((int)LESSERSTRENGTH));
                            break;
                        case BASERANGEDDAMAGE:
                        case BASESPELLDAMAGE:
                            newStat = new ItemStat(StatByID((int)BASEMELEEDAMAGE));
                            break;
                        case RANGEDDAMAGEINCREASE:
                        case SPELLDAMAGEINCREASE:
                            newStat = new ItemStat(StatByID((int)MELEEDAMAGEINCREASE));
                            break;
                        default:
                            return false;
                    }
                    newStat.Amount = stat.Amount;
                    newStat.possibleStatsIndex = stat.possibleStatsIndex;
                    x.Stats[index] = newStat;
                    return true;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_485/*Enzyme INT/33*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_486/*Changes Vitality, Agility or Strength stat on an item to <color=red>Intelligence</color> or changes Ranged or Melee damage stat to <color=red>Spell Damage</color>*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(191),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.Where(y => y.StatID == (int)VITALITY || y.StatID == (int)STRENGTH || y.StatID == (int)AGILITY
                                                     || y.StatID == (int)LESSERVITALITY || y.StatID == (int)LESSERSTRENGTH || y.StatID == (int)LESSERAGILITY
                                                     || y.StatID == (int)BASERANGEDDAMAGE || y.StatID == (int)BASEMELEEDAMAGE
                                                     || y.StatID == (int)RANGEDDAMAGEINCREASE || y.StatID == (int)MELEEDAMAGEINCREASE).ToArray();

                    int c = stats.Count();


                    if (c == 0)
                        return false;
                    int i = UnityEngine.Random.Range(0, c);
                    ItemStat stat = stats[i];
                    int index = x.Stats.IndexOf(stat);

                    ItemStat newStat;
                    Stat statID = (Stat)stat.StatID;
                    switch (statID)
                    {
                        case VITALITY:
                        case STRENGTH:
                        case AGILITY:
                            newStat = new ItemStat(StatByID((int)INTELLIGENCE));
                            break;
                        case LESSERVITALITY:
                        case LESSERSTRENGTH:
                        case LESSERAGILITY:
                            newStat = new ItemStat(StatByID((int)LESSERINTELLIGENCE));
                            break;
                        case BASERANGEDDAMAGE:
                        case BASEMELEEDAMAGE:
                            newStat = new ItemStat(StatByID((int)BASESPELLDAMAGE));
                            break;
                        case RANGEDDAMAGEINCREASE:
                        case MELEEDAMAGEINCREASE:
                            newStat = new ItemStat(StatByID((int)SPELLDAMAGEINCREASE));
                            break;
                        default:
                            return false;
                    }
                    newStat.Amount = stat.Amount;
                    newStat.possibleStatsIndex = stat.possibleStatsIndex;
                    x.Stats[index] = newStat;
                    return true;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_487/*Enzyme AGI/39*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_488/*Changes Vitality, Intelligence or Strength stat on an item to <color=red>Agility</color> or changes Melee or Spell damage stat to <color=red>Ranged Damage</color>*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(192),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.Where(y => y.StatID == (int)VITALITY || y.StatID == (int)STRENGTH || y.StatID == (int)INTELLIGENCE
                                                     || y.StatID == (int)LESSERVITALITY || y.StatID == (int)LESSERSTRENGTH || y.StatID == (int)LESSERINTELLIGENCE
                                                     || y.StatID == (int)BASESPELLDAMAGE || y.StatID == (int)BASEMELEEDAMAGE
                                                     || y.StatID == (int)SPELLDAMAGEINCREASE || y.StatID == (int)MELEEDAMAGEINCREASE).ToArray();

                    int c = stats.Count();


                    if (c == 0)
                        return false;
                    int i = UnityEngine.Random.Range(0, c);
                    ItemStat stat = stats[i];
                    int index = x.Stats.IndexOf(stat);

                    ItemStat newStat;
                    Stat statID = (Stat)stat.StatID;
                    switch (statID)
                    {
                        case VITALITY:
                        case INTELLIGENCE:
                        case STRENGTH:
                            newStat = new ItemStat(StatByID((int)AGILITY));
                            break;
                        case LESSERVITALITY:
                        case LESSERINTELLIGENCE:
                        case LESSERSTRENGTH:
                            newStat = new ItemStat(StatByID((int)LESSERAGILITY));
                            break;
                        case BASEMELEEDAMAGE:
                        case BASESPELLDAMAGE:
                            newStat = new ItemStat(StatByID((int)BASERANGEDDAMAGE));
                            break;
                        case MELEEDAMAGEINCREASE:
                        case SPELLDAMAGEINCREASE:
                            newStat = new ItemStat(StatByID((int)RANGEDDAMAGEINCREASE));
                            break;
                        default:
                            return false;
                    }
                    newStat.Amount = stat.Amount;
                    newStat.possibleStatsIndex = stat.possibleStatsIndex;
                    x.Stats[index] = newStat;
                    return true;
                }
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_489/*Enzyme VIT/449*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_490/*Changes Agility, Intelligence or Strength stat on an item to <color=red>Vitality</color>*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(199),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.Where(y => y.StatID == (int)VITALITY || y.StatID == (int)STRENGTH || y.StatID == (int)INTELLIGENCE
                                                     || y.StatID == (int)LESSERAGILITY || y.StatID == (int)LESSERSTRENGTH || y.StatID == (int)LESSERINTELLIGENCE).ToArray();

                    int c = stats.Count();


                    if (c == 0)
                        return false;
                    int i = UnityEngine.Random.Range(0, c);
                    ItemStat stat = stats[i];
                    int index = x.Stats.IndexOf(stat);

                    ItemStat newStat;
                    Stat statID = (Stat)stat.StatID;
                    switch (statID)
                    {
                        case AGILITY:
                        case INTELLIGENCE:
                        case STRENGTH:
                            newStat = new ItemStat(StatByID((int)VITALITY));
                            break;
                        case LESSERAGILITY:
                        case LESSERINTELLIGENCE:
                        case LESSERSTRENGTH:
                            newStat = new ItemStat(StatByID((int)LESSERVITALITY));
                            break;
                        default:
                            return false;
                    }
                    newStat.Amount = stat.Amount;
                    newStat.possibleStatsIndex = stat.possibleStatsIndex;
                    x.Stats[index] = newStat;
                    return true;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_491/*Stomach Acid*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_492/*Removes all stats with negative values from an item*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(198),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.RemoveAll(y => y.Amount < 0);
                    if (stats > 0)
                        return true;
                    return false;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_493/*Elite Stomach Acid*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_494/*Changes negative stat values into positive values on an item*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(198),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;

                    var stats = x.Stats.Where(y => y.Amount < 0).ToList();
                    if (stats.Count > 0)
                    {
                        for (int i = 0; i < stats.Count; i++)
                        {
                            stats[i].Amount *= -1;
                        }
                        return true;
                    }
                    return false;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_495/*Crimson Solution*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_496/*Upgrades item of any rarity to one of the same type but of <color=red>Legendary</color> rarity*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(196),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;
                    var itemType = x.type;
                    if (itemType == BaseItem.ItemType.Other || itemType == BaseItem.ItemType.Material || x.Amount > 1)
                        return false;
                    if (Player.Inventory.Instance.ItemSlots.ContainsValue(x))
                    {
                        for (int slotIndex = 0; slotIndex < Inventory.SlotCount; slotIndex++)
                        {
                            if (Player.Inventory.Instance.ItemSlots[slotIndex] == x)
                            {
                                var options = ItemDataBase.ItemBases.Where(y => y.Value.Rarity == 7 && y.Value.type == itemType && (itemType != BaseItem.ItemType.Weapon || y.Value.weaponModel == x.weaponModel)).Select(y => y.Key).ToList();
                                if (options.Count == 0)
                                {
                                    ModAPI.Log.Write("No tier 7 items for type: " + itemType);
                                    return false;
                                }
                                var random = options[UnityEngine.Random.Range(0, options.Count)];
                                Item item = new Item(ItemDataBase.ItemBases[random], 1, 0, false)
                                {
                                    level = x.level
                                };
                                item.RollStats();
                                Inventory.Instance.ItemSlots[slotIndex] = item;
                                return true;
                            }
                        }
                    }
                    return false;
                }
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_497/*Weak Armor Hardening Mixture*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_498/*Adds Armor Stat to a piece of equipment if the item does not already have it*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(197),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;
                    var itemType = x.type;
                    if (itemType == BaseItem.ItemType.Other || itemType == BaseItem.ItemType.Material || x.Amount > 1)
                        return false;
                    if (!x.Stats.Any(y => y.StatID == (int)ARMOR || y.StatID == (int)LESSERARMOR))
                    {
                        ItemStat stat = new ItemStat(StatByID((int)ARMOR), x.level);
                        x.Stats.Add(stat);
                        return true;
                    }
                    return false;
                }
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_499/*Upgraded Armor Hardening Mixture*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_500/*Adds Damage Reduction Stat to a piece of equipment if the item does not already have it*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(197),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;
                    var itemType = x.type;
                    if (itemType == BaseItem.ItemType.Other || itemType == BaseItem.ItemType.Material || x.Amount > 1)
                        return false;
                    if (!x.Stats.Any(y => y.StatID == (int)DAMAGEREDUCTION))
                    {
                        ItemStat stat = new ItemStat(StatByID((int)DAMAGEREDUCTION), x.level);
                        x.Stats.Add(stat);
                        return true;
                    }
                    return false;
                }
            };

            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_501/*Chaos Water*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_502/*Rerolls all stats on an item of rarity no higher than orange*/, //tr
                Rarity = 4,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(195),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;
                    var itemType = x.type;
                    if (itemType == BaseItem.ItemType.Other || itemType == BaseItem.ItemType.Material || x.Amount > 1 || x.Rarity > 5)
                        return false;
                    if (x.Stats.Count > 1)
                    {
                        x.RollStats();
                        return true;
                    }
                    return false;
                }
            };
            new BaseItem(new int[][] { })
            {
                name = Translations.ItemDataBase_ItemDefinitions_503/*Upgraded Chaos Water*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_483/*A substance which results in surprising changes to gear*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_504/*Rerolls all stats on an item of any rarity*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 100,
                type = BaseItem.ItemType.Material,
                icon = Res.ResourceLoader.GetTexture(194),
                onConsume = x =>
                {
                    if (x.Equipped)
                        return false;
                    var itemType = x.type;
                    if (itemType == BaseItem.ItemType.Other || itemType == BaseItem.ItemType.Material || x.Amount > 1)
                        return false;
                    if (x.Stats.Count > 1)
                    {
                        x.RollStats();
                        return true;
                    }
                    return false;
                }
            };
            new BaseItem(new Stat[][]
             {
                new [] {SPELLCOSTREDUCTION,MELEEDAMAGEINCREASE,SPELLDAMAGEINCREASE,COOLDOWNREDUCTION,DAMAGEREDUCTION, RANGEDDMGFROMAGI, ATTACKSPEED},
                new [] {AGILITY,LESSERAGILITY},
                new [] {MELEEARMORPIERCING,RANGEDARMORPIERCING,ARMORPIERCING,ARMOR},
                new [] {RANGEDDAMAGEINCREASE,RANGEDDMGFROMAGI,BASERANGEDDAMAGE,CRITICALHITCHANCE,CRITICALHITDAMAGE,ALLATTRIBUTES},
                new [] {INTELLIGENCE,STRENGTH,AGILITY,VITALITY,ALLATTRIBUTES,MAXIMUMLIFE,MAXIMUMENERGY},
                new [] {INTELLIGENCE,STRENGTH,AGILITY,VITALITY,ALLATTRIBUTES,LIFEONHIT,ENERGYONHIT,ENERGYPERSECOND,ALLHEALINGPERCENT},
                new [] {RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,AGILITY},
                new [] {ALL},
                new [] {ALL},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_505/*Gun Blade*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_506("150%")/*Increases pistol damage by <color=gold>150%</color>*/, //tr
                Rarity = 6,
                minLevel = 35,
                maxLevel = 36,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
                onEquip = () => ModdedPlayer.Stats.perk_bulletDamageMult.Multiply(2.5f),
                onUnequip = () => ModdedPlayer.Stats.perk_bulletDamageMult.Divide(2.5f),
            }.PossibleStats[0][0].Multipier = -1f;

            new BaseItem(new Stat[][]
             {
                new [] {SPELLCOSTREDUCTION,BASESPELLDAMAGE,SPELLDAMAGEINCREASE,COOLDOWNREDUCTION,DAMAGEREDUCTION},
                new [] {ATTACKSPEED,PROJECTILESIZE,PROJECTILESPEED},
                new [] {AGILITY,LESSERAGILITY},
                new [] {HEADSHOTDAMAGE},
                new [] {MELEEARMORPIERCING,RANGEDARMORPIERCING,ARMORPIERCING,ARMOR,RESISTANCETOMAGIC,MAGICFIND},
                new [] {RANGEDDAMAGEINCREASE,RANGEDDMGFROMAGI,BASERANGEDDAMAGE,CRITICALHITCHANCE,CRITICALHITDAMAGE,ALLATTRIBUTES,MAXENERGYFROMAGI},
                new [] {RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,AGILITY,VITALITY,INTELLIGENCE,CRITICALHITCHANCE,CRITICALHITDAMAGE},
                new [] {RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,AGILITY,VITALITY,INTELLIGENCE,HEADSHOTDAMAGE},
                new [] {INTELLIGENCE,STRENGTH,AGILITY,VITALITY,ALLATTRIBUTES,MAXIMUMLIFE,MAXIMUMENERGY},
                new [] {INTELLIGENCE,STRENGTH,AGILITY,VITALITY,ALLATTRIBUTES,LIFEONHIT,ENERGYONHIT,ENERGYPERSECOND,ALLHEALINGPERCENT},
                new [] {ALL},
                new [] {ALL},
             })
            {
                name = Translations.ItemDataBase_ItemDefinitions_507/*Sharpshooter's Axe*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_508("50%", "600%")/*Increases pistol headshot chance by <color=red>50%</color> and pistol damage by <color=red>600%</color>*/, //tr
                Rarity = 7,
                minLevel = 35,
                maxLevel = 36,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Axe,
                icon = Res.ResourceLoader.GetTexture(138),
                onEquip = () => { ModdedPlayer.Stats.perk_bulletDamageMult.Multiply(6f); ModdedPlayer.Stats.perk_bulletCritChance.Add(0.5f); },
                onUnequip = () => { ModdedPlayer.Stats.perk_bulletDamageMult.Divide(6f); ModdedPlayer.Stats.perk_bulletCritChance.Substract(0.5f); },
            };
            new BaseItem(new Stat[][]
         {
                new [] {ARMORPIERCING,MELEEARMORPIERCING,NONE},
                new [] {BLOCK,NONE},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,RESISTANCETOMAGIC,DODGECHANCE},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,VITALITY,STRENGTH,ALLATTRIBUTES},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,VITALITY,STRENGTH,ALLATTRIBUTES,THORNS},
                new [] {THORNS,MELEEDAMAGEINCREASE,VITALITY,STRENGTH},
                new [] {STRENGTH,ARMOR,MELEEARMORPIERCING},
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR,BASEMELEEDAMAGE},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,MELEEWEAPONRANGE},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_509/*Shield Blade*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_510/*So large can be used as a shield*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_511/*A normal human cannot lift this weapon.*/, //tr
                Rarity = 6,
                minLevel = 50,
                maxLevel = 52,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
            };
            new BaseItem(new Stat[][]
         {
                new [] {ARMORPIERCING,MELEEARMORPIERCING},
                new [] {BLOCK,NONE},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,RESISTANCETOMAGIC,DODGECHANCE},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,VITALITY,STRENGTH,ALLATTRIBUTES},
                new [] {ARMOR,MAXIMUMLIFE,MAXHEALTHFROMVIT,DAMAGEREDUCTION,VITALITY,STRENGTH,ALLATTRIBUTES,THORNS},
                new [] {THORNS,MELEEDAMAGEINCREASE,VITALITY,STRENGTH},
                new [] {STRENGTH,ARMOR,MELEEARMORPIERCING},
                new [] {MELEEDAMAGEINCREASE,MELEEDMGFROMSTR,BASEMELEEDAMAGE},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,MELEEWEAPONRANGE},
                new [] {ALL},
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_512/*Blunt Blade for Bashing Skulls*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_510/*So large can be used as a shield*/, //tr
                lore = Translations.ItemDataBase_ItemDefinitions_511/*A normal human cannot lift this weapon.*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_513("200%")/*Bash damage debuff on enemies is increased by 200%*/, //tr
                Rarity = 7,
                minLevel = 50,
                maxLevel = 52,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
                onEquip = () => ModdedPlayer.Stats.spell_bashDamageDebuffAmount.Add(2.00f),
                onUnequip = () => ModdedPlayer.Stats.spell_bashDamageDebuffAmount.Substract(2.00f),
            };

            new BaseItem(new Stat[][]
         {
                new[] { ARMORPIERCING, MELEEARMORPIERCING },
                new[] { BLOCK,STRENGTH},
                new[] { ARMOR, MAXIMUMLIFE, MAXHEALTHFROMVIT, DAMAGEREDUCTION, RESISTANCETOMAGIC, DODGECHANCE },
                new[] { ARMOR, MAXIMUMLIFE , DAMAGEREDUCTION, VITALITY, STRENGTH, ALLATTRIBUTES },
                new[] { ARMOR, MAXIMUMLIFE, DAMAGEREDUCTION, VITALITY, STRENGTH, ALLATTRIBUTES, THORNS },
                new[] { THORNS, MELEEDAMAGEINCREASE, VITALITY, STRENGTH },
                new[] { STRENGTH, ARMOR, MELEEARMORPIERCING },
                new[] { MELEEDAMAGEINCREASE, MELEEDMGFROMSTR, BASEMELEEDAMAGE },
                new[] { MELEEDAMAGEINCREASE, ATTACKSPEED, BASEMELEEDAMAGE, MELEEWEAPONRANGE },
                new[] { ALL },
                new[] { ALL },
                new[] { ALL },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_514/*Madman's Legacy*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_515("69%")/*Frenzy damage per stack is increased by 50%*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
                onEquip = () => ModdedPlayer.Stats.spell_frenzyDmg.Add(0.69f),
                onUnequip = () => ModdedPlayer.Stats.spell_frenzyDmg.Add(0.69f),
            };
            new BaseItem(new Stat[][]
         {
                new[] { ARMOR,BASEMELEEDAMAGE },
                new[] { BLOCK},
                new[] { ARMOR, MAXIMUMLIFE,MAXIMUMENERGY,STAMINAREGENERATION, DAMAGEREDUCTION, RESISTANCETOMAGIC, DODGECHANCE },
                new[] { ARMOR, MAXIMUMLIFE, MAXIMUMENERGY, DAMAGEREDUCTION, VITALITY, STRENGTH, ALLATTRIBUTES,CHANCEONHITTOBLEED,CHANCEONHITTOSLOW,CHANCEONHITTOWEAKEN },
                new[] { ARMOR, MAXIMUMLIFE, MAXHEALTHFROMVIT, DAMAGEREDUCTION, VITALITY, STRENGTH, ALLATTRIBUTES, THORNS },
                new[] { THORNS, MELEEDAMAGEINCREASE, VITALITY, STRENGTH },
                new[] { MELEEDAMAGEINCREASE, ATTACKSPEED, BASEMELEEDAMAGE, MELEEWEAPONRANGE,PERCENTMAXIMUMLIFE,PERCENTMAXIMUMENERGY,ALLHEALINGPERCENT },
         })
            {
                name = Translations.ItemDataBase_ItemDefinitions_516/*Buckler*/, //tr
                Rarity = 5,
                minLevel = 1,
                maxLevel = 2,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new Stat[][]
            {
                new [] {FIREDAMAGE},
                new [] {MAXIMUMENERGY,MAXIMUMLIFE,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,INTELLIGENCE,AGILITY,SPELLCOSTREDUCTION},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] {RESISTANCETOMAGIC,MAGICFIND,MOVEMENTSPEED,ARMOR},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_517/*Pyromancy Mask*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_518("200%")/*Ignited enemies burn for 200% extended perioid of time.*/, //tr
                Rarity = 5,
                minLevel = 2,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
                onEquip = () => ModdedPlayer.Stats.fireDuration.Add(2f),
                onUnequip = () => ModdedPlayer.Stats.fireDuration.Substract(2f),
            }.PossibleStats[0][0].Multipier = 2;

            new BaseItem(new Stat[][]
            {
                new [] {FIREDAMAGE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI},
                new [] {MAXENERGYFROMAGI,MAXHEALTHFROMVIT},
                new [] {MAXIMUMENERGY,MAXIMUMLIFE,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,INTELLIGENCE,AGILITY,SPELLCOSTREDUCTION},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] {RESISTANCETOMAGIC,MAGICFIND,MOVEMENTSPEED,ARMOR},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_519/*Ember Mask*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_520("700%")/*Ignited enemies burn for 300% extended perioid of time and fire ticks thrice as fast.*/, //tr
                Rarity = 7,
                minLevel = 2,
                maxLevel = 6,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
                onEquip = () => { ModdedPlayer.Stats.fireDuration.Add(7f); ModdedPlayer.Stats.fireTickRate.Add(3f); },
                onUnequip = () => { ModdedPlayer.Stats.fireDuration.Substract(7f); ModdedPlayer.Stats.fireTickRate.Substract(3f); },
            }.PossibleStats[0][0].Multipier = 5;


            new BaseItem(new Stat[][]
            {
                new [] {FIREDAMAGE},
                new [] {ARMOR,DODGECHANCE},
                new [] {MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI},
                new [] {MAXIMUMENERGY,MAXIMUMLIFE,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,INTELLIGENCE,AGILITY,SPELLCOSTREDUCTION,PROJECTILESPEED,PROJECTILESIZE},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] {RESISTANCETOMAGIC,MAGICFIND,MOVEMENTSPEED,ARMOR},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_521/*Flame Pauldrons*/, //tr
                description = "", //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_522(10, "750%")/*Firebolt costs 30 additional energy to cast and its damage scaling is increased by 250%*/, //tr
                Rarity = 7,
                minLevel = 5,
                maxLevel = 8,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.spell_fireboltEnergyCost.Add(5);
                    ModdedPlayer.Stats.spell_fireboltDamageScaling.Add(7.5f);
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.spell_fireboltEnergyCost.Substract(5);
                    ModdedPlayer.Stats.spell_fireboltDamageScaling.Substract(7.5f);
                },
            };
            new BaseItem(new Stat[][]
            {
                new [] {SPELLDMGFROMINT},
                new [] {MAXENERGYFROMAGI,MAXHEALTHFROMVIT},
                new [] {MAXIMUMENERGY,MAXIMUMLIFE,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,INTELLIGENCE,AGILITY,SPELLCOSTREDUCTION,COOLDOWNREDUCTION,SPELLCOSTTOSTAMINA},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {ALL},
                new [] {ALL},
                new [] {RESISTANCETOMAGIC,ENERGYONHIT,ENERGYPERSECOND,STAMINAREGENERATION,STAMINAPERSECOND},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_523/*Ancient Scroll*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_607/*Firebolt deals increased damage*/, //tr
                Rarity = 6,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
                onEquip = () => ModdedPlayer.Stats.spell_fireboltDamageScaling.Add(8),
                onUnequip = () => ModdedPlayer.Stats.spell_fireboltDamageScaling.Substract(8),
            };
            new BaseItem(new Stat[][]
            {
                new [] {SPELLDMGFROMINT},
                new [] {MAXENERGYFROMAGI,MAXHEALTHFROMVIT},
                new [] {MAXIMUMENERGY,MAXIMUMLIFE,PERCENTMAXIMUMENERGY,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,INTELLIGENCE,AGILITY,SPELLCOSTREDUCTION,COOLDOWNREDUCTION,SPELLCOSTTOSTAMINA},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE, INTELLIGENCE ,ALLATTRIBUTES},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {RESISTANCETOMAGIC,ENERGYONHIT,ENERGYPERSECOND,STAMINAREGENERATION,STAMINAPERSECOND},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_524/*Guide on Tearing Spacetime*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_525/*Blink creates an explosion at the exit point, and the damage of the explosion is increased by velocity and the radius is increased by the distance of blink*/, //tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 1,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.SpellScroll,
                icon = Res.ResourceLoader.GetTexture(110),
                onEquip = () => ModdedPlayer.Stats.spell_blinkDoExplosion.value = true,
                onUnequip = () => ModdedPlayer.Stats.spell_blinkDoExplosion.value = false,
            };
            new BaseItem(new Stat[][]
        {
                new [] {STRENGTH},
                new [] {MELEEDAMAGEINCREASE},
                new [] {ATTACKSPEED},
                new [] {MELEEDMGFROMSTR},
                new [] {BLOCK,ARMOR,DAMAGEREDUCTION},
                new [] {BASEMELEEDAMAGE,NONE},
                new [] {BASEMELEEDAMAGE,MELEEDAMAGEINCREASE,STRENGTH},
                new [] {MELEEARMORPIERCING,ARMORPIERCING,ALLATTRIBUTES},
                new [] {ATTACKCOSTREDUCTION,ATTACKSPEED},
                new [] {ALLATTRIBUTES,MELEEWEAPONRANGE,VITALITY,MAXIMUMLIFE},
                new [] {ENERGYONHIT,VITALITY,LIFEONHIT }
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_526/*300th Spear*/, //tr
                Rarity = 6,
                minLevel = 30,
                maxLevel = 34,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.Polearm,
                icon = Res.ResourceLoader.GetTexture(181),
            }.PossibleStats[0][0].Multipier = 6;



            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED,ATTACKSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_527/*Stone Pauldrons*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_529/*Iron Shoulder Pads*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_531/*Steel Shoulder Pads*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_533/*Battle scarred Shoulder Pads*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_535/*Mystery Shoulder Pads*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };

            new BaseItem(new Stat[][]
        {
                new [] {MOVEMENTSPEED,ATTACKSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {BLOCK},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_537/*Stone Shield*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {BLOCK},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_538/*Iron Shield*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL,ARMOR},
                new [] {BLOCK},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_539/*Steel Tower Shield*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };
            new BaseItem(new Stat[][]
            {

                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {BLOCK},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_540/*Guardian*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            };

            new BaseItem(new Stat[][]
            {
                new [] {BLOCK},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_541/*Mystery Shield*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Shield,
                icon = Res.ResourceLoader.GetTexture(99),
            }.PossibleStats[0][0].Multipier = 2f;


            new BaseItem(new Stat[][]
        {
                new [] {MOVEMENTSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_542/*Light Boot*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            }.PossibleStats[0][0].Multipier = 1.3f;
            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_543/*Iron Boots*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL,ARMOR},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_544/*Steel Boots*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_545/*Threads*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };

            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED},
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_546/*Mystery Boots*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };




            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_547/*Wraps*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_301/*Iron Gauntlet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_548/*Steel Gauntlet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_549/*Titanium Gauntlet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_550/*Mystery Gauntlet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };



            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_551/*Leather Tasset*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_552/*Iron Tasset*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_553/*Steel Tasset*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_554/*Black Steel Leggins*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_555/*Mystery Leggins*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };

            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_556/*Leather Vest*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_557/*Iron Breastplate*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_558/*Steel Breastplate*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_559/*Silver Armor*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_560/*Mystery Breastplate*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };

            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_561/*Cloth Band*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_562/*Iron Wristguard*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_563/*Steel Wristguard*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_564/*Baron Wristguards*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_565/*Mystery Wristguards*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };


            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
        })
            {
                name = Translations.ItemDataBase_ItemDefinitions_218/*Horned Helmet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_528("3%")/*All damage increased by 3%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.03f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.03f),
                Rarity = 2,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            }.PossibleStats[0][0].Multipier = -0.3f;
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_566/*Iron Helmet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_530("4%")/*All damage increased by 4%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.04f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.04f),
                Rarity = 3,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_567/*Steel Helmet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_532("5%")/*All damage increased by 5%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.05f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.05f),
                Rarity = 4,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {ALL,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_568/*Armored Hood*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_534("6%")/*All damage increased by 6%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.06f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.06f),
                Rarity = 5,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,RANGEDDMGFROMAGI,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_569/*Mystery Helmet*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_536("10%")/*All damage increased by 10%*/, //tr
                onEquip = () => ModdedPlayer.Stats.allDamage.Add(0.1f),
                onUnequip = () => ModdedPlayer.Stats.allDamage.Substract(0.1f),
                Rarity = 6,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {CRITICALHITCHANCE,CRITICALHITDAMAGE,},
                new [] {MELEEDAMAGEINCREASE,NONE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},
                })
            {
                name = Translations.ItemDataBase_ItemDefinitions_570/*Yorium's Gaze*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Helmet,
                icon = Res.ResourceLoader.GetTexture(91),
            };
            new BaseItem(new Stat[][]
        {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {MAXIMUMLIFE},
                new [] {MELEEDAMAGEINCREASE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_573/*Yorium's Ruthlessness*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ChestArmor,
                icon = Res.ResourceLoader.GetTexture(96),
            };

            new BaseItem(new Stat[][]
            {
                new [] {ALL,},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {MAXIMUMLIFE},
                new [] {MELEEDAMAGEINCREASE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_574/*Yorium's Burden*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.ShoulderArmor,
                icon = Res.ResourceLoader.GetTexture(95),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {MAXIMUMLIFE},
                new [] {MELEEDAMAGEINCREASE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_575/*Yorium's Resolve*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
            };
            new BaseItem(new Stat[][]
            {
                new [] {MOVEMENTSPEED},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {MAXIMUMLIFE},
                new [] {MELEEDAMAGEINCREASE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_576/*Atomic Augmentation*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Boot,
                icon = Res.ResourceLoader.GetTexture(85),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,MELEEWEAPONRANGE,BASEMELEEDAMAGE,STRENGTH},
                new [] {MELEEDAMAGEINCREASE,ATTACKSPEED,BASEMELEEDAMAGE,STRENGTH},
                new [] {MAXIMUMLIFE},
                new [] {MELEEDAMAGEINCREASE,MAXIMUMLIFE,PERCENTMAXIMUMLIFE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,ATTACKSPEED,ATTACKCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},
                new [] {EMPTYSOCKET,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_577/*Yorium's Assault*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_571("30%")/*SET PIECE. Melee weapon range is increased by 30%, attack cost in stamina is halved.*/, //tr
                description = Translations.ItemDataBase_ItemDefinitions_572(15, "35%", 15, "5%")/*Set Piece:\n2 Pieces- Berserk does not apply exhaustion when it ends\n3 Pieces - Berserk duration is increased by 15 seconds\n4 Pieces - Each second of berserk being in effect increases damage by 35%.\n5 Pieces - For the first 15 seconds of Berserk attack speed increases by 30% per second, and lasts till the end of the spell's duration.*/, //tr
                onEquip = () => BerserkSet.Equip(),
                onUnequip = () => BerserkSet.Unequip(),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Glove,
                icon = Res.ResourceLoader.GetTexture(86),
            };
            new BaseItem(new Stat[][]
            {
                new [] {ALL,EXPGAIN,MAGICFIND},
                new [] {MELEEDMGFROMSTR,MAXENERGYFROMAGI,RANGEDDMGFROMAGI,MAXHEALTHFROMVIT,SPELLDMGFROMINT},
                new [] {MELEEDAMAGEINCREASE,BASEMELEEDAMAGE,STRENGTH},
                new [] {RANGEDDAMAGEINCREASE,BASERANGEDDAMAGE,AGILITY},
                new [] {SPELLDAMAGEINCREASE,BASESPELLDAMAGE,INTELLIGENCE},
                new [] {ALL},
                new [] {MAXIMUMLIFE},
                new [] {MAXIMUMLIFE,PERCENTMAXIMUMLIFE,MAXIMUMENERGY,PERCENTMAXIMUMENERGY},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,AGILITY,ALLATTRIBUTES,ATTACKSPEED,ATTACKCOSTREDUCTION,SPELLCOSTREDUCTION,COOLDOWNREDUCTION},
                new [] {ALL},
                new [] {ALL,NONE},
                new [] {ALL,NONE},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION,ALLATTRIBUTES,NONE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_578/*Undying Promise*/, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_579(1)/*Resist lethal damage on a 1 minute cooldown*/, //tr
                onEquip = () => COTFEvents.Instance.OnTakeLethalDamage.AddListener(UniqueItemFunctions.ResistDeath),
                onUnequip = () => COTFEvents.Instance.OnTakeLethalDamage.RemoveListener(UniqueItemFunctions.ResistDeath),
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
            };
            new BaseItem(new Stat[][]
            {
                new [] {CRITICALHITDAMAGE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,AGILITY },
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ARMOR,DAMAGEREDUCTION },
                new [] {MAXIMUMLIFE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_609, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_610, //tr
                Rarity = 7,
                minLevel = 20,
                maxLevel = 28,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Pants,
                icon = Res.ResourceLoader.GetTexture(87),
                onEquip = () => { ModdedPlayer.Stats.spell_frenzy_active_critChance.Add(0.05f); ModdedPlayer.Stats.spell_frenzyAtkSpeed.Add(0.03f); },
                onUnequip = () => { ModdedPlayer.Stats.spell_frenzy_active_critChance.Substract(0.05f); ModdedPlayer.Stats.spell_frenzyAtkSpeed.Add(0.03f); },
            };



            new BaseItem(new Stat[][]
            {
                new [] {BASEMELEEDAMAGE,BASESPELLDAMAGE},
                new [] {BASEMELEEDAMAGE,BASESPELLDAMAGE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,AGILITY },
                new [] {MELEEDAMAGEINCREASE, SPELLDAMAGEINCREASE },
                new [] {ATTACKSPEED},
                new [] {CRITICALHITCHANCE},
                new [] {CRITICALHITDAMAGE},
                new [] {MELEEDMGFROMSTR},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {BLOCK, NONE},
                new [] {MAXIMUMLIFE},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_611, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_612("300%"), //tr
                Rarity = 7,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
                onEquip = () => ModdedPlayer.Stats.spell_berserkDamage.Add(3f),
                onUnequip = () => ModdedPlayer.Stats.spell_berserkDamage.Substract(3f),
            }.PossibleStats[0][0].Multipier = 5;
            new BaseItem(new Stat[][]
            {
                new [] {BASEMELEEDAMAGE,BASESPELLDAMAGE},
                new [] {BASEMELEEDAMAGE, NONE},
                new [] {STRENGTH,VITALITY,INTELLIGENCE,AGILITY },
                new [] {MELEEDAMAGEINCREASE, SPELLDAMAGEINCREASE },
                new [] {ATTACKSPEED},
                new [] {CRITICALHITCHANCE},
                new [] {CRITICALHITDAMAGE},
                new [] {MELEEDMGFROMSTR},
                new [] {STRENGTH},
                new [] {ALL},
                new [] {ALL},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_613, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_612("100%"), //tr
                Rarity = 6,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Weapon,
                weaponModel = BaseItem.WeaponModelType.GreatSword,
                icon = Res.ResourceLoader.GetTexture(88),
                onEquip = () => ModdedPlayer.Stats.spell_berserkDamage.Add(1f),
                onUnequip = () => ModdedPlayer.Stats.spell_berserkDamage.Substract(1f),
            }.PossibleStats[0][0].Multipier = 2;

            new BaseItem(new Stat[][]
            {
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE, NONE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,DAMAGEREDUCTION},
                new [] {ALLATTRIBUTES,AGILITY,STRENGTH,INTELLIGENCE,VITALITY},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_614, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_615("10%"), //tr
                Rarity = 5,
                minLevel = 6,
                maxLevel = 9,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.spell_berserkAttackSpeed.Add(0.1f);
                    ModdedPlayer.Stats.spell_berserkMovementSpeed.Add(0.1f);
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.spell_berserkAttackSpeed.Substract(0.1f);
                    ModdedPlayer.Stats.spell_berserkMovementSpeed.Substract(0.1f);
                },
            };
            new BaseItem(new Stat[][]
            {
                new [] {STRENGTH,VITALITY,AGILITY,ALLATTRIBUTES,INTELLIGENCE},
                new [] {MAXENERGYFROMAGI,MELEEDMGFROMSTR,SPELLDMGFROMINT,RANGEDDMGFROMAGI,MAXHEALTHFROMVIT},
                new [] {ARMOR,DAMAGEREDUCTION},
                new [] { CRITICALHITCHANCE, CRITICALHITDAMAGE},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {ALL},
                new [] {BASESPELLDAMAGE,BASERANGEDDAMAGE,BASEMELEEDAMAGE, NONE},
                new [] {SPELLDMGFROMINT,MELEEDMGFROMSTR,RANGEDDMGFROMAGI,DAMAGEREDUCTION},

            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_616, //tr
                uniqueStat = $"Berserk increases melee and ranged damage by 100%, increases movement speed by 30% and attack speed by 15%", //tr
                Rarity = 7,
                minLevel = 60,
                maxLevel = 62,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Amulet,
                icon = Res.ResourceLoader.GetTexture(100),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.meleeIncreasedDmg.Multiply(2f);
                    ModdedPlayer.Stats.rangedIncreasedDmg.Multiply(2f);
                    ModdedPlayer.Stats.spell_berserkAttackSpeed.Add(0.15f);
                    ModdedPlayer.Stats.spell_berserkMovementSpeed.Add(0.3f);
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.meleeIncreasedDmg.Divide(2f);
                    ModdedPlayer.Stats.rangedIncreasedDmg.Divide(2f);
                    ModdedPlayer.Stats.spell_berserkAttackSpeed.Substract(0.15f);
                    ModdedPlayer.Stats.spell_berserkMovementSpeed.Substract(0.3f);
                },
            };
            new BaseItem(new Stat[][]
            {
                new[] { LIFEPERSECOND },
                new[] { ARMOR, NONE, ALLHEALINGPERCENT },
                new[] { ALL},
                new[] { SPELLDMGFROMINT },
                new[] { SPELLCOSTREDUCTION,SPELLCOSTTOSTAMINA,ARMOR,ALLATTRIBUTES},
                new[] { BASESPELLDAMAGE, SPELLDAMAGEINCREASE, INTELLIGENCE, ALLATTRIBUTES },
                new[] { BASESPELLDAMAGE, SPELLDAMAGEINCREASE, INTELLIGENCE, DAMAGEREDUCTION },
                new[] { VITALITY, MAXHEALTHFROMVIT, MAXIMUMLIFE, PERCENTMAXIMUMLIFE, LIFEPERSECOND, LIFEONHIT },
                new[] { SPELLCOSTREDUCTION, COOLDOWNREDUCTION, CRITICALHITCHANCE, CRITICALHITDAMAGE, ARMOR,MAXHEALTHFROMVIT },
                new[] { DAMAGEREDUCTION, PERCENTMAXIMUMENERGY, LIFEREGENERATION },
                new[] { ENERGYPERSECOND, PERCENTMAXIMUMENERGY, MAXENERGYFROMAGI },
                new[] { INTELLIGENCE, STAMINAPERSECOND, STAMINAREGENERATION, ALLATTRIBUTES, ALLHEALINGPERCENT },
                new[] { ENERGYONHIT, ENERGYPERSECOND, MAXIMUMLIFE, MASSACREDURATION, MAGICFIND, EXPLOSIONDAMAGE },
            })
            {
                name = Translations.ItemDataBase_ItemDefinitions_617, //tr
                uniqueStat = Translations.ItemDataBase_ItemDefinitions_618("100%", "40%"),//tr
                Rarity = 7,
                minLevel = 1,
                maxLevel = 3,
                CanConsume = false,
                StackSize = 1,
                type = BaseItem.ItemType.Bracer,
                icon = Res.ResourceLoader.GetTexture(93),
                onEquip = () =>
                {
                    ModdedPlayer.Stats.spell_healingDomeCooldownRate.Add(1.0f);
                    ModdedPlayer.Stats.spell_healingDomeSpellCostReduction.Substract(0.4f);
                },
                onUnequip = () =>
                {
                    ModdedPlayer.Stats.spell_healingDomeCooldownRate.Substract(1.0f);
                    ModdedPlayer.Stats.spell_healingDomeSpellCostReduction.Add(0.4f);
                },
            };
        }
    }
}