using System;
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
		public static void AddShields()
		{
			//------------------------------------------------------
			//Rarity 0 (Grey)
			//------------------------------------------------------
			new Shield()
				.ShieldStatSlot(1)
				.StatSlot(new Stat[] { BLOCK })
				.Name("Rusten Battered Shield")
				.Description("Covered in rust and scarred from countless blows, this battered shield has seen better days. It creaks with every movement, offering only the most basic protection.")
				.Rarity(0);

			new Shield()
				.StatSlot(new Stat[] { BLOCK })
				.Name("Cracked Buckler")
				.Description("Cracked and barely holding together, this old buckler offers little more than false hope. Its surface is marred with dents and splits from battles long forgotten.")
			.Rarity(0);
			new Shield()
				.StatSlot(new Stat[] { BLOCK })
				.StatSlot(new Stat[] { STRENGTH, NONE })
				.Name("Shattered Guard")
				.Description("No warior would pick this up and call it a shield.")
				.Rarity(0);

			//------------------------------------------------------
			//Rarity 1 (White)
			//------------------------------------------------------

			new Shield()
				.ShieldStatSlot(2)
				.StatSlot(new Stat[] { BLOCK })
				.Name("Plain Iron Shield")
				.Description("Fuck you Hazard. ~Lama Mega~")
				.Rarity(1);

			new Shield()
				.ShieldStatSlot(1)
				.StatSlot(new Stat[] { BLOCK })
				.StatSlot(new Stat[] { THORNS, BASE_MELEE_DAMAGE })
				.Name("Wooden Buckler")
				.Description("This shield has a precariously sticking out nail.")
				.Rarity(1);

			new Shield()
				.ShieldStatSlot(1)
				.DefaultStatSlot(1)
				.StatSlot(new Stat[] { BLOCK })
				.Name("Footknights's Roundshield")
				.Description("")
				.Rarity(1);

			//------------------------------------------------------
			//Rarity 2 (Dark Blue)
			//------------------------------------------------------

			new Shield()
				.ShieldStatSlot(3)
				.StatSlot(new Stat[] { BLOCK })
				.Name("Runed Iron Bulwark")
				.Description("Fuck you Hazard. ~Lama Mega~")
				.Rarity(1);


			new Shield()
				.ShieldStatSlot(3)
				.StatSlot(new Stat[] { BLOCK })
				.StatSlot(new Stat[] { DODGE_CHANCE })
				.Name("Reinforced Buckler")
				.Description("Light and small shield that allows you to dodge attacks.")
				.Rarity(2);

			new Shield()
				.ShieldStatSlot(3)
				.StatSlot(new Stat[] { BLOCK })
				.StatSlot(new Stat[] { DODGE_CHANCE })
				.Name("Knight's Guard")
				.Description("")
				.Rarity(2);


			//------------------------------------------------------
			//Rarity 3 (Blue)
			//------------------------------------------------------

			//------------------------------------------------------
			//Rarity 4 (Yellow)
			//------------------------------------------------------

			//------------------------------------------------------
			//Rarity 5 (Orange)
			//------------------------------------------------------

			//------------------------------------------------------
			//Rarity 6 (Green)
			//------------------------------------------------------

			//------------------------------------------------------
			//Rarity 7 (Red)
			//------------------------------------------------------
		}

	}
}
