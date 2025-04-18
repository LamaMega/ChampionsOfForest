using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

using ChampionsOfForest.Items.ItemTemplates;

using static ChampionsOfForest.Items.ItemDatabase.Stat;

namespace ChampionsOfForest.Items
{
	public static partial class ItemDatabase
	{

		public static void AddChestArmors()
		{

			//------------------------------------------------------
			//Rarity 0 (White)
			//------------------------------------------------------

			new ChestArmor()
			.DefaultStatSlot(1)
			.StatSlot(new Stat[] { ARMOR }, probability: 0.5f)
			.Name("")
			.Description("")
			.Rarity(0);

			//------------------------------------------------------
			//Rarity 1 (Green)
			//------------------------------------------------------

			new ChestArmor()
			.DefaultStatSlot(2)
			.StatSlot(new Stat[] { ARMOR }, probability: 0.5f)
			.Name("")
			.Description("")
			.Rarity(1);

			//------------------------------------------------------
			//Rarity 2 (Blue)
			//------------------------------------------------------

			new ChestArmor()
			.DefaultStatSlot(3)
			.StatSlot(new Stat[] { ARMOR })
			.Name("")
			.Description("")
			.Rarity(2);

			//------------------------------------------------------
			//Rarity 3 (Yellow)
			//------------------------------------------------------

			new ChestArmor()
			.DefaultStatSlot(4)
			.StatSlot(new Stat[] { ARMOR })
			.Name("")
			.Description("")
			.Rarity(3);

			//------------------------------------------------------
			//Rarity 4 (Red)
			//------------------------------------------------------

			new ChestArmor()
			.DefaultStatSlot(5)
			.StatSlot(new Stat[] { ARMOR })
			.Name("")
			.Description("")
			.Rarity(4);

		}
	}
}