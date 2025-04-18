﻿using System;

using ChampionsOfForest.Localization;

using UnityEngine;

namespace ChampionsOfForest.Player.Crafting
{
	public partial class CustomCrafting
	{
		public class IndividualRerolling : ICraftingMode
		{
			public int selectedStat = -1;

			public bool validRecipe
			{
				get
				{
					if (CraftingHandler.changedItem.i == null)
						return false;
					if (selectedStat == -1)
						return false;
					var stat = CraftingHandler.changedItem.i.stats[selectedStat];
					if (stat.possibleStatsIndex == -1)
						return false;
					if (CraftingHandler.changedItem.i.statSlots[stat.possibleStatsIndex].Count < 2)
						return false;
					int itemCount = 0;
					int rarity = CraftingHandler.changedItem.i.rarity;
					for (int i = 0; i < CraftingHandler.ingredients.Length; i++)
					{
						if (CraftingHandler.ingredients[i].i != null)
						{
							if (CraftingHandler.ingredients[i].i.rarity >= rarity)
							{
								itemCount++;
							}
							else
							{
								return false;
							}
						}
					}
					return itemCount == IngredientCount;
				}
			}
			public void Craft()
			{
				if (CraftingHandler.changedItem.i != null)
				{
					if (validRecipe)
					{
						var stat = CraftingHandler.changedItem.i.stats[selectedStat];
						if (stat.id > 3000)
						{
							CraftingHandler.changedItem.i.stats[selectedStat] = new ItemStat(ItemDatabase.Stats[3000]); //set to empty socket
						}
						else
						{
							var options = CraftingHandler.changedItem.i.statSlots[stat.possibleStatsIndex];
							int random = UnityEngine.Random.Range(0, options.Count);
							{
								ItemStat newStat = new ItemStat(options[random], CraftingHandler.changedItem.i.level);
								newStat.amount *= CraftingHandler.changedItem.i.GetRarityMultiplier();
								newStat.possibleStatsIndex = stat.possibleStatsIndex;
								if (newStat.valueCap != 0)
								{
									newStat.amount = Mathf.Min(newStat.amount, newStat.valueCap);
								}
								CraftingHandler.changedItem.i.stats[selectedStat] = newStat;
							}
							selectedStat = -1;

						}
						Effects.Sound_Effects.GlobalSFX.Play(Effects.Sound_Effects.GlobalSFX.SFX.Purge);
						for (int i = 0; i < CraftingHandler.ingredients.Length; i++)
						{
							CraftingHandler.ingredients[i].RemoveItem();
						}
					}
				}
			}

			public int IngredientCount => 1;

			public CustomCrafting CraftingHandler => CustomCrafting.instance;

			public void DrawUI(in float x, in float w, in float screenScale, in GUIStyle[] styles)
			{


				GUI.Label(new Rect(x, (CustomCrafting.CRAFTINGBAR_HEIGHT + 5) * screenScale, w, 26 * screenScale), Translations.IndividualRerolling_1/*Stat to change*/, styles[3]); //tr
				MainMenu.Instance.CraftingIngredientBox(new Rect(x + w / 2 - 75 * screenScale, (CustomCrafting.CRAFTINGBAR_HEIGHT + 40) * screenScale, 150 * screenScale, 150 * screenScale), CustomCrafting.instance.changedItem);
				float ypos = (CustomCrafting.CRAFTINGBAR_HEIGHT + 190) * screenScale;
				if (CustomCrafting.instance.changedItem.i != null)
				{
					try
					{
						float mult = CustomCrafting.instance.changedItem.i.GetRarityMultiplier();

						int ind = 0;
						foreach (ItemStat stat in CustomCrafting.instance.changedItem.i.stats)
						{
							Rect statRect = new Rect(x + 10 * screenScale, ypos, w - 20 * screenScale, 26 * screenScale);
							Rect valueMinMaxRect = new Rect(statRect.xMax + 15 * screenScale, ypos, statRect.width, statRect.height);
							ypos += 26 * screenScale;
							string maxAmount = stat.GetMaxValue(CraftingHandler.changedItem.i.level, mult);
							string minAmount = stat.GetMinValue(CraftingHandler.changedItem.i.level, mult);
							string amount = stat.amount.ToString((stat.displayAsPercent ? "P" : "N") + stat.roundingCount);

							GUI.color = MainMenu.RarityColors[stat.rarity];
							if (selectedStat == ind)
							{
								GUI.Label(statRect, "• " + stat.name + " •", new GUIStyle(styles[0]) { fontStyle = FontStyle.Bold, fontSize = Mathf.RoundToInt(19 * screenScale) });
							}
							else
							{
								if (GUI.Button(statRect, stat.name, styles[0]))
								{
									selectedStat = ind;
								}
							}
							GUI.color = Color.white;



							ind++;

							GUI.Label(statRect, amount, styles[1]);
							GUI.Label(valueMinMaxRect, "[ " + minAmount + " - " + maxAmount + " ]", styles[4]);

						}
					}
					catch (Exception e)
					{
						Debug.LogException(e);
					}
					try
					{
						if (validRecipe)
						{
							if (GUI.Button(new Rect(x, ypos, w, 40 * screenScale), CraftingHandler.changedItem.i.stats[selectedStat].id > 3000 ? Translations.IndividualRerolling_3/*Empty socket*/ : Translations.IndividualRerolling_2/*Reroll stat*/, styles[2])) //tr
							{
								Craft();
							}
							ypos += 50 * screenScale;
						}
						else
						{
							GUI.color = Color.gray;
							GUI.Label(new Rect(x, ypos, w, 40 * screenScale), Translations.IndividualRerolling_4/*Select a Stat*/, styles[2]); //tr
							GUI.color = Color.white;
							ypos += 50 * screenScale;
						}
					}
					catch (Exception e)
					{
						Debug.LogWarning("reroll stats button ex " + e);
					}
				}
				float baseX = x + ((w - 250 * screenScale) / 2);
				float baseY = ypos + 30 * screenScale;
				if (CustomCrafting.instance.changedItem.i != null)
				{

					for (int j = 0; j < 1; j++)
					{
						for (int k = 0; k < 1; k++)
						{
							int index = 3 * k + j;
							MainMenu.Instance.CraftingIngredientBox(new Rect(baseX + j * 80 * screenScale, baseY + k * 80 * screenScale, 80 * screenScale, 80 * screenScale), CustomCrafting.instance.ingredients[index]);
						}
					}
					if (selectedStat != -1)
					{
						var stat = CraftingHandler.changedItem.i.stats[selectedStat];
						if (stat.possibleStatsIndex != -1)
						{
							var options = CraftingHandler.changedItem.i.statSlots[stat.possibleStatsIndex];
							if (options.Count == 1)
							{
								GUI.Label(new Rect(x, ypos, w, Screen.height - x), Translations.IndividualRerolling_5/*This stat cannot be changed*/, new GUIStyle(styles[0]) { alignment = TextAnchor.UpperLeft, fontSize = (int)(12 * screenScale), wordWrap = true }); //tr

							}
							else
							{
								string optionsStr = Translations.IndividualRerolling_6/*Possible stats:\n*/; //tr
								foreach (var stat1 in options)
								{
									optionsStr += stat1.name + '\t';
								}
								GUI.Label(new Rect(x, ypos, w, Screen.height - x), optionsStr, new GUIStyle(styles[0]) { alignment = TextAnchor.UpperLeft, fontSize = (int)(12 * screenScale), wordWrap = true });
							}
						}
						else
						{
							GUI.Label(new Rect(x, ypos, w, Screen.height - x), Translations.IndividualRerolling_5/*This stat cannot be changed*/, new GUIStyle(styles[0]) { alignment = TextAnchor.UpperLeft, fontSize = (int)(12 * screenScale), wordWrap = true }); //tr
						}

					}
				}
			}
		}
	}
}