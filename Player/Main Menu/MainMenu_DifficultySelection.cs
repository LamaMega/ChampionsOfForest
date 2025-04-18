﻿using System;
using System.IO;

using ChampionsOfForest.Localization;

using TheForest.Utils;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChampionsOfForest
{
	public partial class MainMenu : MonoBehaviour
	{
		internal class MainMenuDifficultySelectionClient
		{
			private Texture blackSquareTex;
			private Font mainFont;
			private float screenScale;

			private float requestResendTime;
			private float timeStamp;
			private const float timeToQuit = 15f;

			private GUIStyle labelStyle;

			internal MainMenuDifficultySelectionClient(MainMenu mm)
			{
				timeStamp = Time.time;
				blackSquareTex = mm.blackSquareTex;
				mainFont = mm.mainFont;
				screenScale = mm.screenScale;
			}

			private bool initialziedStyles;

			private void InitStyles()
			{
				initialziedStyles = true;
				labelStyle = new GUIStyle(GUI.skin.label)
				{
					alignment = TextAnchor.MiddleCenter,
					font = mainFont,
					fontSize = Mathf.RoundToInt(50 * screenScale)
				};
			}

			internal void Draw()
			{
				if (!initialziedStyles)
					InitStyles();
				if (LocalPlayer.FpCharacter != null)
				{
					LocalPlayer.FpCharacter.LockView(true);
					LocalPlayer.FpCharacter.MovementLocked = true;
				}
				Rect r = new Rect(0, 0, Screen.width, Screen.height);

				if (timeStamp + timeToQuit < Time.time)
				{
					float deltaT = Time.time - timeStamp - timeToQuit;
					float c = deltaT / 2;
					if (c > 1)
						c = 1;
					GUI.color = new Color(1, 1, 1, 1 - c / 3);

					GUI.DrawTexture(r, blackSquareTex);
					if (deltaT < 2)
						r.y -= deltaT * 150 * screenScale;
					else
						r.y -= 300 * screenScale;

					GUI.color = Color.white;
					GUI.Label(r, Translations.MainMenu_DifficultySelection_1/*Please wait for the host to choose a COTF difficulty*/, labelStyle);   //tr

					GUI.color = new Color(c, c, c, c);
					GUI.Label(new Rect(0, Screen.height / 2f, Screen.width, screenScale * 150),
						Translations.MainMenu_DifficultySelection_2/*The server may not have Champions of The Forest Mod installed or the host is taking a long time. Playing on vanilla servers is impossible.\nDo you want to leave?*/, labelStyle);   //tr
					if (GUI.Button(new Rect(Screen.width / 2 - 120 * screenScale, Screen.height / 2f + screenScale * 240, 400 * screenScale, screenScale * 60), Translations.MainMenu_DifficultySelection_25/*Leave lobby*/)) //tr
					{
						SceneManager.LoadScene("TitleScene");
					}
				}
				else
				{
					GUI.color = Color.white;
					GUI.DrawTexture(r, blackSquareTex);
					GUI.Label(r, Translations.MainMenu_DifficultySelection_1/*Please wait for the host to choose a COTF difficulty*/, labelStyle);   //tr
				}

				ResendRequest();
			}

			private void ResendRequest()
			{
				if (requestResendTime <= 0)
				{
					using (MemoryStream answerStream = new MemoryStream())
					{
						using (BinaryWriter w = new BinaryWriter(answerStream))
						{
							w.Write(1);
							w.Close();
						}
						Network.NetworkManager.SendLine(answerStream.ToArray(), Network.NetworkManager.Target.OnlyServer);
						answerStream.Close();
					}
					requestResendTime = 2;
				}
				else
				{
					requestResendTime -= Time.deltaTime;
				}
			}
		}

		internal class MainMenuDifficultySelectionHost
		{
			private Texture blackSquareTex;
			private Font mainFont;
			private float screenScale;
			private int page = 0;

			private GUIStyle ButtonStyle;
			private GUIStyle DiffNameStyle;
			private GUIStyle DescriptionStyle;
			private GUIStyle CheatLabel;
			private GUIStyle CheatSlider;
			private GUIStyle OptionsButton;

			//Constructor
			internal MainMenuDifficultySelectionHost(MainMenu mm)
			{
				blackSquareTex = mm.blackSquareTex;
				mainFont = mm.mainFont;
				screenScale = mm.screenScale;
			}

			private bool initializedStyles;

			private void InitStyles()
			{
				initializedStyles = true;
				ButtonStyle = new GUIStyle(GUI.skin.button);
				DiffNameStyle = new GUIStyle(GUI.skin.label)
				{
					alignment = TextAnchor.MiddleCenter,
					fontSize = Mathf.FloorToInt(30 * screenScale),
					font = mainFont,
				};
				DescriptionStyle = new GUIStyle(GUI.skin.label)
				{
					alignment = TextAnchor.MiddleCenter,
					fontSize = Mathf.FloorToInt(16 * screenScale),
					font = mainFont,
				};
				OptionsButton = new GUIStyle(GUI.skin.button)
				{
					font = mainFont,
					fontSize = Mathf.FloorToInt(20 * screenScale)
				};
				CheatLabel = new GUIStyle(GUI.skin.label)
				{
					font = mainFont,
					fontSize = Mathf.FloorToInt(30 * screenScale)
				};
				CheatSlider = new GUIStyle(GUI.skin.horizontalSlider)
				{
					fontSize = Mathf.FloorToInt(30 * screenScale),
					stretchHeight = true
				};
			}

			private readonly int[] highestObtainableLootTierPerLevel = { 2, 3, 4, 5, 6, 7, 7, 7, 7, 7, 7 };

			private void DrawDifficultyTabs()
			{
				GUI.color = Color.white;
				for (int i = 0; i < 4; i++)
				{
					int ii = i + page * 4;
					if (DiffSel_Names.Length > ii)
					{
						Rect r = new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 8, Screen.height / 2);
						r.x += i * r.width;
						if (GUI.Button(r, "", ButtonStyle))
						{
							ModSettings.DifficultyChosen = true;
							Array values = Enum.GetValues(typeof(ModSettings.GameDifficulty));
							ModSettings.difficulty = (ModSettings.GameDifficulty)values.GetValue(ii);
							LocalPlayer.FpCharacter.UnLockView();
							LocalPlayer.FpCharacter.MovementLocked = false;
							Cheats.GodMode = false;
							Instance.ClearDiffSelectionObjects();
							ModSettings.BroadCastSettingsToClients();
							ModSettings.SaveSettings();
							return;
						}
						Rect name = new Rect(r);
						name.height /= 6;
						//original image is 500 x 154, so im taking half here
						Rect icon = new Rect(name.x, name.yMax, 250 * screenScale, 77 * screenScale);
						Rect desc = new Rect(r);
						desc.height = 400 * screenScale;
						desc.y = icon.yMax;

						GUI.color = RarityColors[highestObtainableLootTierPerLevel[ii]];
						GUI.Label(name, DiffSel_Names[ii](), DiffNameStyle);
						GUI.color = Color.white;
						if (ii < 4)
							GUI.DrawTexture(icon, Res.ResourceLoader.GetTexture(172));
						else
							GUI.DrawTexture(icon, Res.ResourceLoader.GetTexture(171));

						GUI.Label(desc, DiffSel_Descriptions[ii](), DescriptionStyle);
					}
				}

				GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 4), Translations.MainMenu_DifficultySelection_3/*Select Difficulty*/, DiffNameStyle); //tr
				if (GUI.Button(new Rect(0, Screen.height / 2 - 100 * screenScale, 200 * screenScale, 200 * screenScale), "<", ButtonStyle))
				{
					page = Mathf.Clamp(page - 1, 0, 2);
				}
				if (GUI.Button(new Rect(Screen.width - 200 * screenScale, Screen.height / 2 - 100 * screenScale, 200 * screenScale, 200 * screenScale), ">", ButtonStyle))
				{
					page = Mathf.Clamp(page + 1, 0, 2);
				}
			}

			private void DrawSettings()
			{
				//Friendly fire
				if (ModSettings.FriendlyFire)
				{
					GUI.color = Color.red;
					Rect r = new Rect(Screen.width / 2 - 300 * screenScale, 120 * screenScale, 600 * screenScale, 50 * screenScale);
					if (GUI.Button(r, Translations.MainMenu_DifficultySelection_4/*Friendly Fire enabled*/, OptionsButton))  //tr
					{
						ModSettings.FriendlyFire = !ModSettings.FriendlyFire;
					}
					else if (r.Contains(Instance.mousePos))
					{
						GUI.Label(new Rect(r.xMax, r.y, 600 * screenScale, 100f), Translations.MainMenu_DifficultySelection_5/*You will be able to hit other players with melee attacks and projectiles for full damage values.*/);  //tr
					}
				}
				else
				{
					Rect r = new Rect(Screen.width / 2 - 300 * screenScale, 120 * screenScale, 600 * screenScale, 50 * screenScale);

					GUI.color = Color.gray;
					if (GUI.Button(r, Translations.MainMenu_DifficultySelection_6/*Friendly Fire disabled*/, new GUIStyle(GUI.skin.button)   //tr
					{
						font = mainFont,
						fontSize = Mathf.FloorToInt(20 * screenScale)
					}))
					{
						ModSettings.FriendlyFire = !ModSettings.FriendlyFire;
					}
					else if (r.Contains(Instance.mousePos))
					{
						GUI.Label(new Rect(r.xMax, r.y, 600 * screenScale, 100f), Translations.MainMenu_DifficultySelection_7/*Your melee and ranged attacks will not damage other players.*/);  //tr
					}
				}

				//Bleeding out
				if (ModSettings.killOnDowned)
				{
					GUI.color = Color.red;
					var r = new Rect(Screen.width / 2 - 300 * screenScale, 170 * screenScale, 600 * screenScale, 50 * screenScale);
					if (GUI.Button(r, Translations.MainMenu_DifficultySelection_8/*Instant death*/, new GUIStyle(GUI.skin.button)    //tr
					{
						font = mainFont,
						fontSize = Mathf.FloorToInt(20 * screenScale)
					}))
					{
						ModSettings.killOnDowned = !ModSettings.killOnDowned;
					}
					else if (r.Contains(Instance.mousePos))
					{
						GUI.Label(new Rect(r.xMax, r.y, 600 * screenScale, 100f), Translations.MainMenu_DifficultySelection_9/*Instead of being downed, players instantly die*/);    //tr
					}
				}
				else
				{
					GUI.color = Color.gray;
					var r = new Rect(Screen.width / 2 - 300 * screenScale, 170 * screenScale, 600 * screenScale, 50 * screenScale);
					if (GUI.Button(r, Translations.MainMenu_DifficultySelection_10/*Players bleed out normally*/, new GUIStyle(GUI.skin.button)  //tr
					{
						font = mainFont,
						fontSize = Mathf.FloorToInt(20 * screenScale)
					}))
					{
						ModSettings.killOnDowned = !ModSettings.killOnDowned;
					}
					else if (r.Contains(Instance.mousePos))
					{
						GUI.Label(new Rect(r.xMax, r.y, 600 * screenScale, 100f), Translations.MainMenu_DifficultySelection_11/*Players slowly bleed out after being downed*/);  //tr
					}
				}

				//Drops on death
				switch (ModSettings.dropsOnDeath)
				{
					case ModSettings.DropsOnDeathModes.All:
						GUI.color = Color.red;
						break;

					case ModSettings.DropsOnDeathModes.Equipped:
						GUI.color = Color.yellow;
						break;

					case ModSettings.DropsOnDeathModes.NonEquipped:
						GUI.color = Color.cyan;
						break;

					case ModSettings.DropsOnDeathModes.Disabled:
						GUI.color = Color.gray;
						break;

					default:
						break;
				}
				if (GUI.Button(new Rect(Screen.width / 2 - 300 * screenScale, 70 * screenScale, 600 * screenScale, 50 * screenScale), Translations.MainMenu_DifficultySelection_12/*Item drops on death: */ + ModSettings.dropsOnDeath, new GUIStyle(GUI.skin.button)    //tr
				{
					font = mainFont,
					fontSize = Mathf.FloorToInt(20 * screenScale)
				}))
				{
					int i = (int)ModSettings.dropsOnDeath + 1;
					i %= 4;
					ModSettings.dropsOnDeath = (ModSettings.DropsOnDeathModes)i;
				}



				GUI.color = Color.white;

				if (GUI.Button(new Rect(Screen.width / 2 - 300 * screenScale, 220 * screenScale, 600 * screenScale, 50 * screenScale), Translations.MainMenu_DifficultySelection_26 +  ModSettings.m_lootLevelRule, new GUIStyle(GUI.skin.button)    //tr
				{
					font = mainFont,
					fontSize = Mathf.FloorToInt(20 * screenScale)
				}))
				{
					int i = (int)ModSettings.m_lootLevelRule + 1;
					i %= 5;
					ModSettings.m_lootLevelRule = (ModSettings.LootLevelRules)i;
				}

				float y = 350;
				DrawCheatOption(ref ModSettings.DropQuantityMultiplier, Translations.MainMenu_DifficultySelection_13/*Item Drop Quantity*/, ref y);  //tr
				DrawCheatOption(ref ModSettings.DropChanceMultiplier, Translations.MainMenu_DifficultySelection_14/*Item Drop Chance*/, ref y);     //tr
				DrawCheatOption(ref ModSettings.ExpMultiplier, Translations.MainMenu_DifficultySelection_15/*Enemy Bounty*/, ref y);                //tr
				DrawCheatOption(ref ModSettings.EnemyLevelIncrease, Translations.MainMenu_DifficultySelection_16/*Enemy Level Increase*/, ref y);       //tr
				DrawCheatOption(ref ModSettings.EnemyDamageMultiplier, Translations.MainMenu_DifficultySelection_17/*Enemy Damage*/, ref y);        //tr
				DrawCheatOption(ref ModSettings.EnemyHealthMultiplier, Translations.MainMenu_DifficultySelection_18/*Enemy Health*/, ref y);        //tr
				DrawCheatOption(ref ModSettings.EnemyArmorMultiplier, Translations.MainMenu_DifficultySelection_19/*Enemy Armor*/, ref y);          //tr
				DrawCheatOption(ref ModSettings.EnemySpeedMultiplier, Translations.MainMenu_DifficultySelection_20/*Enemy Speed*/, ref y);          //tr
				DrawCheatOption(ref ModSettings.AllowElites, Translations.MainMenu_DifficultySelection_21/*Allow elite enemies*/, ref y);               //tr
				DrawCheatOption(ref ModSettings.AllowCaveRespawn, Translations.MainMenu_DifficultySelection_27, ref y);               //tr
				if (ModSettings.AllowCaveRespawn)
					DrawCheatOption(ref ModSettings.AllowRandomCaveSpawn, Translations.MainMenu_DifficultySelection_28, ref y);               //tr
				if (ModSettings.AllowRandomCaveSpawn && ModSettings.AllowCaveRespawn)
					DrawCheatOption(ref ModSettings.CaveMaxAdditionalEnemies, Translations.MainMenu_DifficultySelection_29, ref y,0,20);               //tr
				if (ModSettings.AllowCaveRespawn)
					DrawCheatOption(ref ModSettings.CaveRespawnDelay, Translations.MainMenu_DifficultySelection_30, ref y);               //tr

				DrawCheatOptionLootFilter(ref ModSettings.LootFilterMinRarity, "Remove loot below rarirty (except materials)", ref y);               //tr

				if (GUI.Button(new Rect(Screen.width*0.5f - 250 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), Translations.MainMenu_DifficultySelection_31)) //tr
				{
					ModSettings.Reset();
				}
			}

			private void DrawCheatOption(ref float value, in string text, ref float y, float min = 0.01f, float max = 50.0f)
			{
				GUI.Label(new Rect(50 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), text, CheatLabel);
				value = GUI.HorizontalSlider(new Rect(500 * screenScale, y * screenScale, 950 * screenScale, 40 * screenScale), value, min, max);
				GUI.Label(new Rect(1500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), value.ToString("P1"), CheatLabel);
				y += 40;
			}
			private void DrawCheatOption(ref bool value, in string text, ref float y, float min = 0.1f, float max = 10.0f)
			{
				GUI.Label(new Rect(50 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), text, CheatLabel);
				value = GUI.Toggle(new Rect(500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), value, value ? Translations.MainMenu_DifficultySelection_23/*Yes*/: Translations.MainMenu_DifficultySelection_22/*No*/);    //tr
				y += 40;
			}
			private void DrawCheatOptionLootFilter(ref int value, in string text, ref float y)
			{
				GUI.Label(new Rect(50 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), text, CheatLabel);
				value = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), value, 0, RarityColors.Length));
				GUI.color = RarityColors[value];
				GUI.Label(new Rect(1500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), value.ToString("N0"), CheatLabel);
				GUI.color = Color.white;
				y += 40;
			}

			private void DrawCheatOption(ref int value, in string text, ref float y, int min = 0, int max = 300)
			{
				GUI.Label(new Rect(50 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), text, CheatLabel);
				value = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), value, min, max));
				GUI.Label(new Rect(1500 * screenScale, y * screenScale, 500 * screenScale, 40 * screenScale), "+" + value.ToString("N0"), CheatLabel);
				y += 40;
			}

			private bool showSettings = false;

			internal void Draw()
			{
				if (!initializedStyles)
					InitStyles();
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackSquareTex);
				if (GUI.Button(new Rect(Screen.width - 300 * screenScale, Screen.height - 50 * screenScale, 300 * screenScale, 50 * screenScale), Translations.MainMenu_DifficultySelection_24/*More options*/)) //tr
				{
					showSettings = !showSettings;
				}
				if (showSettings)
					DrawSettings();
				else
					DrawDifficultyTabs();
			}
		}

		#region DifficultySelectionMethods

		private MainMenuDifficultySelectionHost hostDiffSel;
		private MainMenuDifficultySelectionClient clientDiffSel;

		public void ClearDiffSelectionObjects()
		{
			hostDiffSel = null;
			clientDiffSel = null;
		}

		private void DifficultySelectionScreen()
		{
			if (LocalPlayer.Stats != null)
			{
				//lock movement and keep invincible
				Cheats.GodMode = true;
				if ((bool)LocalPlayer.FpCharacter)
				{
					LocalPlayer.FpCharacter.LockView(true);
					LocalPlayer.FpCharacter.MovementLocked = true;
				}
				LocalPlayer.Inventory.UnequipItemAtSlot(TheForest.Items.Item.EquipmentSlot.RightHand, false, true, false);

				if (GameSetup.IsMpClient)
				{
					if (clientDiffSel == null)
						clientDiffSel = new MainMenuDifficultySelectionClient(this);
					clientDiffSel.Draw();
				}
				else
				{
					if (hostDiffSel == null)
						hostDiffSel = new MainMenuDifficultySelectionHost(this);
					hostDiffSel.Draw();
				}
			}
		}

		#endregion DifficultySelectionMethods
	}
}