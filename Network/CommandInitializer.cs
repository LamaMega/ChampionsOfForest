using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ChampionsOfForest.Network.Commands;

using TheForest.Utils;

namespace ChampionsOfForest.Network
{
	public static class CommandInitializer
	{

		public static void Init()
		{
			CommandReader.curr_cmd_index = 100;

			COTFCommand<GetPlayerStateParams>.Initialize(
				param =>ModReferences.PlayerStates.UpdateOrAddPlayerState(param));

			COTFCommand<BroadcastModSettings>.Initialize(
				param => ModSettings.ReceivedSettingsFromServer(param));

		}
	}
}
