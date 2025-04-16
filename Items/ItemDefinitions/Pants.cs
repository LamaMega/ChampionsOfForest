﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

using ChampionsOfForest.Items.ItemTemplates;

using static ChampionsOfForest.ItemDataBase.Stat;

namespace ChampionsOfForest
{
	public static partial class ItemDataBase
	{

		public static void AddPants()
		{


			//------------------------------------------------------
			//Rarity 0 (White)
			//------------------------------------------------------

			new Pants()
				.DefaultStatSlot(1)
				.Name("")
				.Description("")
				.Rarity(0);


			//------------------------------------------------------
			//Rarity 1 (Green)
			//------------------------------------------------------

			new Pants()
				.DefaultStatSlot(2)
				.Name("")
				.Description("")
				.Rarity(1);

			//------------------------------------------------------
			//Rarity 2 (Blue)
			//------------------------------------------------------

			new Pants()
				.DefaultStatSlot(3)
				.Name("")
				.Description("")
				.Rarity(2);

			//------------------------------------------------------
			//Rarity 3 (Yellow)
			//------------------------------------------------------

			new Pants()
				.DefaultStatSlot(4)
				.Name("")
				.Description("")
				.Rarity(3);

			//------------------------------------------------------
			//Rarity 4 (Red)
			//------------------------------------------------------

			new Pants()
				.DefaultStatSlot(5)
				.Name("")
				.Description("")
				.Rarity(4);

		}
	}
}