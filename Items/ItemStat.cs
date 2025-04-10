using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using static ChampionsOfForest.ItemStatBuilder;

namespace ChampionsOfForest
{

	public class ItemStatBuilder : ItemStat
	{
		private float CompareAdd(List<float> x) => x.Sum();
		private float CompareMult(List<float> x)
		{
			float f = 1;
			for (int j = 0; j < x.Count; j++)
				f *= x[j];
			return f - 1;
		}
		private float CompareMultPlus1(List<float> x)
		{
			float f = 1;
			for (int j = 0; j < x.Count; j++)
				f *= 1 + x[j];
			return f;
		}
		private float Compare1MinusMult(List<float> x)
		{
			float f = 1;
			for (int k = 0; k < x.Count; k++)
				f *= 1 - x[k];
			return 1 - f;
		}




		public ItemStatBuilder(int id, string name, float min, float max)
		{
			this.id = id;
			this.name = name;
			this.rangeMin = min;
			this.rangeMax = max;
			ItemDataBase.AddStat(this);

		}

		public ItemStatBuilder Rarity(int rarity)
		{
			if (rarity < 0 || rarity > 7)
				UnityEngine.Debug.LogError($"ItemStat {name} has incorrect rarity {rarity}");
			this.rarity = rarity;
			return this;
		}

		public ItemStatBuilder AdditiveComparing()
		{
			this.comparing = 
		}
	}
	public class ItemStat
	{
		public class StatCompare
		{
			public readonly Func<List<float>, float> CalculateValues;

			public StatCompare(Func<List<float>, float> calculateValues)
			{
				CalculateValues = calculateValues;
			}
		}

		public float levelExponent = 1;
		public float valueCap = 0;
		public int id = 0;
		public string name = "";
		public int rarity = 1;
		public float rangeMin = 0;
		public float rangeMax = 0;
		public float amount = 1;
		public float multipier = 1;
		public float rarityCoefficient = 1;

		// display
		public bool displayAsPercent = false;
		public int roundingCount;
		public int possibleStatsIndex = -1;


		private Func<List<float>, float> comparingFunc;
		public Func<string> GetTotalStat; 

		public delegate void StatActionDelegate(float f);

		public StatActionDelegate OnEquip;
		public StatActionDelegate OnUnequip;


		public float EvaluateTotalIncrease(List<float> amounts)
		{
			return comparing.CalculateValues(amounts);
		}

		public ItemStat()
		{
			
		}

		// Returns a copy of an item stat
		public ItemStat(ItemStat original, int level, int possibleStatsIdx, float rarityMult)
		{
			name = original.name;
			levelExponent = original.levelExponent;
			id = original.id;
			rarity = original.rarity;
			rangeMin = original.rangeMin;
			rangeMax = original.rangeMax;
			OnEquip = original.OnEquip;
			OnUnequip = original.OnUnequip;
			roundingCount = original.roundingCount;
			displayAsPercent = original.displayAsPercent;
			GetTotalStat = original.GetTotalStat;
			valueCap = original.valueCap;
			multipier = original.multipier;
			rarityCoefficient = original.rarityCoefficient;
			comparingFunc = original.comparingFunc;
			amount = RollValue(level, rarityMult);
			possibleStatsIndex = possibleStatsIdx;
		}


		private float GetMultiplier(int level, float rarityMult)
		{
			float levelMult = 1;
			if (levelExponent != 0)
			{
				levelMult = Mathf.Pow(level, levelExponent);
			}
			rarityMult *= rarityCoefficient;
			return multipier * levelMult * rarityMult;
		}

		public float RollValue(int level, float rarityMult)
		{
			float randomValue = UnityEngine.Random.Range(rangeMin, rangeMax);
			float mult = GetMultiplier(level, rarityMult);
			float val = randomValue * mult;
			if (valueCap != 0 && val > valueCap)
				val = valueCap;
			return val;
		}

		public string GetMaxValue(int level,float rarityMult)
		{
			string formatting = (displayAsPercent ? "P" : "N" )+ roundingCount;

			float mult = GetMultiplier(level, rarityMult);
			float val = rangeMax * mult;
			if (valueCap != 0 && val > valueCap)
				return (valueCap).ToString(formatting) + " (capped)";
			else 
				return (val).ToString(formatting);
		}

		public string GetMinValue(int level, float rarityMult)
		{
			string formatting = (displayAsPercent ? "P" : "N") + roundingCount;

			float mult = GetMultiplier(level, rarityMult);
			float val = rangeMin * mult;
			if (valueCap != 0 && val > valueCap)
				return (valueCap).ToString(formatting) + " (capped)";
			else
				return (val).ToString(formatting);
		}
	}
}