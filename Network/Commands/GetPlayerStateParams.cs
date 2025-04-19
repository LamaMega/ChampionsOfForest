using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChampionsOfForest.Network.Commands
{
	public struct GetPlayerStateParams
	{
		public ulong entityNetworkID;
		public string playerID;
		public int level;
		public float health;
		public float maxHealth;
		public int xp;
	}

	public struct BroadcastModSettings
	{
		public ModSettings.DropsOnDeathModes dropsOnDeath;
		public ModSettings.GameDifficulty difficulty;
		public bool dieOnDowned;
		public bool friendlyFire;

	}

}
