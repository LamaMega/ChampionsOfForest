﻿using System;

using UnityEngine;

namespace ChampionsOfForest.Player.Crafting
{
	public partial class CustomCrafting
	{
		public class Empowering : ICraftingMode
		{
			public bool validRecipe
			{
				get
				{
					if (CraftingHandler.changedItem.i == null || CraftingHandler.changedItem.i.destinationSlotID > -2)
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
						CraftingHandler.changedItem.i.level = ModdedPlayer.instance.level;
						foreach (var stat in CraftingHandler.changedItem.i.stats)
						{
							if (stat.id >= 3000)
								continue;
							stat.amount = stat.RollValue(CraftingHandler.changedItem.i.level) * CustomCrafting.instance.changedItem.i.GetRarityMultiplier();
							if (stat.valueCap != 0)
								stat.amount = Mathf.Min(stat.amount, stat.valueCap);
							stat.amount *= stat.multipier;
						}
						Effects.Sound_Effects.GlobalSFX.Play(Effects.Sound_Effects.GlobalSFX.SFX.Purge);

						for (int i = 0; i < CraftingHandler.ingredients.Length; i++)
						{
							CraftingHandler.ingredients[i].RemoveItem();
						}
					}
				}
			}

			public int IngredientCount => 9;

			public CustomCrafting CraftingHandler => CustomCrafting.instance;

			public void DrawUI(in float x, in float w, in float screenScale, in GUIStyle[] styles)
			{
				GUI.Label(new Rect(x, (CustomCrafting.CRAFTINGBAR_HEIGHT + 5) * screenScale, w, 26 * screenScale), "Item to change level", styles[3]);
				MainMenu.Instance.CraftingIngredientBox(new Rect(x + w / 2 - 75 * screenScale, (CustomCrafting.CRAFTINGBAR_HEIGHT + 40) * screenScale, 150 * screenScale, 150 * screenScale), CustomCrafting.instance.changedItem);
				float ypos = (CustomCrafting.CRAFTINGBAR_HEIGHT + 190) * screenScale;
				if (CustomCrafting.instance.changedItem.i != null)
				{
					int ind = 1;
					try
					{
						float mult = CustomCrafting.instance.changedItem.i.GetRarityMultiplier();
						foreach (ItemStat stat in CustomCrafting.instance.changedItem.i.stats)
						{
							Rect statRect = new Rect(x + 10 * screenScale, ypos, w - 20 * screenScale, 26 * screenScale);
							Rect valueMinMaxRect = new Rect(statRect.xMax + 15 * screenScale, ypos, statRect.width, statRect.height);
							ypos += 26 * screenScale;
							string maxAmount = stat.GetMaxValue(CraftingHandler.changedItem.i.level,mult) ;
							string minAmount = stat.GetMinValue(CraftingHandler.changedItem.i.level, mult)  ;
							string amount = stat.amount.ToString((stat.displayAsPercent ? "P" : "N") + stat.roundingCount);
							GUI.color = MainMenu.RarityColors[stat.rarity];
							GUI.Label(statRect, ind + ".  " + stat.name, styles[0]);
							GUI.color = Color.white;
							ind++;
						
								GUI.Label(statRect, amount, styles[1]);
								GUI.Label(valueMinMaxRect, "[ " + minAmount+ " - " + maxAmount+" ]", styles[4]);
						
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
							if (GUI.Button(new Rect(x, ypos, w, 40 * screenScale), "Bring item to level " + ModdedPlayer.instance.level, styles[2]))
							{
								Craft();
							}
							ypos += 50 * screenScale;
						}
					}
					catch (Exception e)
					{
						Debug.LogWarning("reroll stats button ex " + e);
					}
				}
				float baseX = x + ((w - 240 * screenScale) / 2);
				float baseY = ypos + 30 * screenScale;
				if (CustomCrafting.instance.changedItem.i != null)
					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 3; k++)
						{
							int index = 3 * k + j;
							MainMenu.Instance.CraftingIngredientBox(new Rect(baseX + j * 80 * screenScale, baseY + k * 80 * screenScale, 80 * screenScale, 80 * screenScale), CustomCrafting.instance.ingredients[index]);
						}
					}
			}
		}
	}
}