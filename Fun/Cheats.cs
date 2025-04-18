﻿using System.Linq;

using ChampionsOfForest.Player;

using TheForest;
using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest.Fun
{
	public static class CotfCheats
	{
		public static void SetLevel(int lvl)
		{
			ModdedPlayer.instance.level = lvl;
			ModdedPlayer.Respec();
		}

		public static void AddLevel(int lvl)
		{
			for (int i = 0; i < lvl; i++)
			{
				ModdedPlayer.instance.LevelUp();
			}
		}

		public static void AddPoints(int points)
		{
			ModdedPlayer.instance.MutationPoints += points;
		}

		public static void Respec()
		{
			ModdedPlayer.Respec();
		}

		public static void CotfItem(int id, int level)
		{
			Item item = new Item(ItemDatabase.itemLookup[id], 1, 0, false)
			{
				level = level
			};
			item.RollStats();
			Inventory.Instance.AddItem(item);
		}

		public static bool Cheat_noCooldowns;

		public static void NoCooldowns(string state)
		{
			if (state == "on")
			{
				Cheat_noCooldowns = true;
			}
			else if (state == "off")
			{
				Cheat_noCooldowns = false;
			}
			else
			{
				Cheat_noCooldowns = !Cheat_noCooldowns;
			}
		}
	}

	public class DebugConsoleMod : DebugConsole
	{
		private void _cotfhelp(string param)
		{
			Debug.LogWarning("Avaible champions of the forest commands:");
			Debug.LogWarning("cotfnocooldowns [on, off, no parameter to toggle]");
			Debug.LogWarning("cotfspawnitem [item id] [level]");
			Debug.LogWarning("cotfspawnitembyname [item name]");
			Debug.LogWarning("cotfaddlevel [amount]");
			Debug.LogWarning("cotfsetlevel [amount]");
			Debug.LogWarning("cotfaddpoints [amount]");
			Debug.LogWarning("cotfresetpoints");
			Debug.LogWarning("cotfsetdifficulty [0-8]");
			Debug.LogWarning("cotflistitems");
			Debug.LogWarning("cotfliststats");
			Debug.LogWarning("cotflogitemdatabase");
			Debug.LogWarning("cotflistperks");

		}

		private void _cotfaddlevel(string param)
		{
			CotfCheats.AddLevel(int.Parse(param));
		}

		private void _cotfnocooldowns(string param)
		{
			CotfCheats.NoCooldowns(param);
		}

		private void _cotfsetlevel(string param)
		{
			CotfCheats.SetLevel(int.Parse(param));
		}

		private void _cotfaddpoints(string param)
		{
			CotfCheats.AddPoints(int.Parse(param));
		}

		private void _cotfprintlang(string param)
		{
			Debug.Log(PlayerPreferences.Language);
		}
		private void _cotflang(string param)
		{
			Localization.Translations.Load(param);
		}
		private void _cotflangf(string param)
		{
			Localization.Translations.LoadNoDl("Mods/Champions of the Forest/Localization/"+ param + ".txt");
		}
		private void _cotfresetpoints(string param)
		{
			CotfCheats.Respec();
		}

		private void _cotflistitems(string param)
		{
			string s = "";
			foreach (var item in ItemDatabase.itemLookup)
			{
				s += string.Concat(new object[]
				{
					"[",
					item.Key,
					"]  ",
					item.Value.name,
					"\n"
				});
			}
			Debug.Log(s);
			ModAPI.Log.Write(s);
		}
		private void _cotflistperks(string param)
		{
			string s = "";
			foreach (var item in PerkDatabase.perks)
			{
				s += string.Concat(new object[]
				{
					"[",
					item.id,
					"]  ",
					item.name,
					": ",
					item.Description,
					"\n"
				});
			}
			Debug.Log(s);
			ModAPI.Log.Write(s);
		}


		private void _cotfliststats(string param)
		{
			string s = "";
			foreach (var item in ItemDatabase.Stats)
			{
				s += string.Concat(new object[]
				{
					"[",
					item.Key,
					"]  ",
					item.Value.name,
					"\n"
				});
			}
			Debug.Log(s);
			ModAPI.Log.Write(s);
		}

		private void _cotfsetdifficulty(string param)
		{
			int i = int.Parse(param);
			ModSettings.difficulty = (ModSettings.GameDifficulty)i;
			Debug.LogWarning("Difficulty changed to: " + (ModSettings.GameDifficulty)i);
		}

		private void _cotfspawnitem(string param)
		{
			var splited = param.Split(new char[] { ' ' });
			if (splited.Length != 2)
			{
				Debug.LogWarning("Wrong command usage \t cotfspawnitem [item id] [level]");
				return;
			}
			CotfCheats.CotfItem(int.Parse(splited[0]), int.Parse(splited[1]));
		}

		private void _cotfspawnitembyname(string param)
		{
			var matches = ItemDatabase.itemLookup.Where(x => x.Value.name.ToLower().StartsWith(param)).Select(x => x.Value.id).ToArray();
			if (matches.Length > 0)
			{
				CotfCheats.CotfItem(matches[0], ModdedPlayer.instance.level);
				return;
			}
			Debug.LogWarning("Wrong command usage \t cotfspawnitembyname [itemname]");
		}
        private void _cotflogitemdatabase(string param)
        {
            ItemDatabase.LogInfo();
        }
		private void _sleep(string param)
		{
			LocalPlayer.Stats.GoToSleep();
		}
		private void _cotfrandomcavespawns(string param)
		{
			bool on = param == "on";
			ModSettings.AllowRandomCaveSpawn = on;
		}
		private void _cotfhordemodepause(string param)
		{
			bool on = param == "on";
			TheForest.Utils.Scene.MutantControler.hordeModePaused = on;
		}
		private void _cotfhordemode(string param )
		{
			bool on = param == "on";
			TheForest.Utils.Scene.MutantControler.hordeModeActive = on;
			TheForest.Utils.Scene.MutantControler.hordeModeAuto = on;
			TheForest.Utils.Scene.MutantControler.hordeConstantSpawning = on;
			TheForest.Utils.Scene.MutantControler.Invoke("doStart", 1f);
		}
	}
}