using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChampionsOfForest.Network.Commands
{
	public struct GetPlayerStateParams
	{
		public string playerID;
		public int level;
		public float health;
		public float maxHealth;
		public int xp;
		public ulong entityNetworkID;
	}

}
