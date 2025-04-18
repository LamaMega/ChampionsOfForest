﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;

using ChampionsOfForest.Effects;
using ChampionsOfForest.Enemies;
using ChampionsOfForest.Enemies.EnemyAbilities;
using ChampionsOfForest.Player;

using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest.Network
{
	
	public class CommandReader
	{
		public delegate void CommandDelegate(BinaryReader r);
		public static Dictionary<int, CommandDelegate> callbacks = new Dictionary<int, CommandDelegate>();


		public static int curr_cmd_index;

		public static void OnCommand(byte[] bytes)
		{
			using (MemoryStream stream = new MemoryStream(bytes))
			{
				using (BinaryReader r = new BinaryReader(stream))
				{
					int cmdIndex = r.ReadInt32();
					try
					{
						if (callbacks.TryGetValue(cmdIndex, out var t))
						{
							t.Invoke(r);
						}
						else
							switch (cmdIndex)
							{
								case -1:    //Network stat has been updated by another player
									{
										var nID = r.ReadInt32();
										NetworkPlayerStats.syncedStats[nID].ReceivedOtherPlayerChange(r);
										break;
									}

								case 1:
									{
										if (ModSettings.DifficultyChosen)
										{
											ModSettings.BroadCastSettingsToClients();
										}

										break;
									}

								case 2:
									{
										if (!GameSetup.IsMpClient || ModSettings.IsDedicated)
											return;

										int index = r.ReadInt32();
										ModSettings.FriendlyFire = r.ReadBoolean();
										ModSettings.dropsOnDeath = (ModSettings.DropsOnDeathModes)r.ReadInt32();
										ModSettings.killOnDowned = r.ReadBoolean();
										ModSettings.difficulty = (ModSettings.GameDifficulty)index;
										if (!ModSettings.DifficultyChosen)
										{
											LocalPlayer.FpCharacter.UnLockView();
											LocalPlayer.FpCharacter.MovementLocked = false;
											Cheats.GodMode = false;
											MainMenu.Instance.ClearDiffSelectionObjects();
										}
										ModSettings.DifficultyChosen = true;
										break;
									}

								case 3:
									{
										int spellid = r.ReadInt32();
										if (spellid == 1)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											BlackHole.CreateBlackHole(pos, r.ReadBoolean(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadString());
										}
										else if (spellid == 2)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											HealingDome.CreateHealingDome(pos, 
												r.ReadSingle(),
												r.ReadSingle(),
												r.ReadBoolean(),
												r.ReadBoolean(),
												r.ReadSingle(),
												r.ReadSingle(),
												r.ReadSingle(),
												r.ReadSingle(),
												r.ReadSingle());
										}
										else if (spellid == 3)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											DarkBeam.Create(pos, r.ReadBoolean(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										}
										else if (spellid == 4)
										{
											bool isOn = r.ReadBoolean();
											string packed = r.ReadString();
											BlackFlame.ToggleOtherPlayer(packed, isOn);
										}
										else if (spellid == 5)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float radius = r.ReadSingle();
											float speed = r.ReadSingle();
											float dmg = r.ReadSingle();
											bool GiveDmg = r.ReadBoolean();
											bool GiveAr = r.ReadBoolean();
											int ar = r.ReadInt32();
											bool GiveDr = r.ReadBoolean();

											WarCry.Cast(pos, radius, speed, dmg, GiveDmg, GiveAr, ar, GiveDr);
										}
										else if (spellid == 6)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float duration = r.ReadSingle();
											int id = r.ReadInt32();

											Portal.CreatePortal(pos, duration, id, r.ReadBoolean(), r.ReadBoolean());
										}
										else if (spellid == 7)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											Vector3 dir = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());

											float dmg = r.ReadSingle();
											string caster = r.ReadString();
											float duration = r.ReadSingle();
											bool slow = r.ReadBoolean();
											bool dmgdebuff = r.ReadBoolean();
											if (GameSetup.IsMpServer)
											{
												MagicArrow.Create(pos, dir, dmg, caster, duration, slow, dmgdebuff);
											}
											else
											{
												MagicArrow.CreateEffect(pos, dir, dmgdebuff, duration);
											}
										}
										else if (spellid == 8)
										{
											Purge.Cast(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()), r.ReadSingle(), r.ReadBoolean(), r.ReadBoolean());
										}
										else if (spellid == 9)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float dist = r.ReadSingle();

											SnapFreeze.CreateEffect(pos, dist);
											if (!GameSetup.IsMpClient)
											{
												SnapFreeze.HostAction(pos, dist, r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											}
										}
										else if (spellid == 10)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											Vector3 speed = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float dmg = r.ReadSingle();
											uint id = r.ReadUInt32();

											if (BallLightning.lastID < id)
											{
												BallLightning.lastID = id;
											}

											BallLightning.Create(pos, speed, dmg, id);
										}
										else if (spellid == 11) //cataclysm
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float radius = r.ReadSingle();
											float dmg = r.ReadSingle();
											float duration = r.ReadSingle();
											bool isArcane = r.ReadBoolean();
											bool fromEnemy = r.ReadBoolean();
											Cataclysm.Create(pos, radius, dmg, duration, isArcane ? Cataclysm.TornadoType.Arcane : Cataclysm.TornadoType.Fire, fromEnemy);
										}
										else if (spellid == 12)
										{
											//a request from a client to a host to spawn a ball lightning. The host assigns the id of
											//a ball lightning to not create overlapping ids
											using (MemoryStream answerStream = new MemoryStream())
											{
												using (BinaryWriter w = new BinaryWriter(answerStream))
												{
													w.Write(3);
													w.Write(10);
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write(r.ReadSingle());
													w.Write((BallLightning.lastID + 1));
													w.Close();
													BallLightning.lastID++;
												}
												NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Everyone);
												answerStream.Close();
											}
										}
										else if (spellid == 13) //parry was casted by a client
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float radius = r.ReadSingle();
											bool ignite = r.ReadBoolean();
											float dmg = r.ReadSingle();

											var hits = Physics.SphereCastAll(pos, radius, Vector3.one);

											for (int i = 0; i < hits.Length; i++)
											{
												if (hits[i].transform.CompareTag("enemyCollide"))
												{
													var prog = hits[i].transform.root.GetComponent<EnemyProgression>();
													if (prog == null)
														hits[i].transform.root.SendMessageUpwards("Hit", (int)dmg, SendMessageOptions.DontRequireReceiver);
													else
														prog.HitPhysical(dmg);
													if (ignite)
														hits[i].transform.SendMessageUpwards("Burn", SendMessageOptions.DontRequireReceiver);

												}
											}
										}
										else if (spellid == 14) //Massive fart
										{
											bool grounded = r.ReadBoolean();
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											Vector3 dir = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											TheFartCreator.CreateEffect(pos, dir, !grounded);
											if (GameSetup.IsMpServer)
											{
												TheFartCreator.DealDamageAsHost(pos, dir, r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											}
										}
										else if (spellid == 15) //taunt
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											float radius = r.ReadSingle();
											if (GameSetup.IsMpServer)
											{
												float duration = r.ReadSingle();
												float slow = r.ReadSingle();
												bool pullIn = r.ReadBoolean();
												string playerID = r.ReadString();
												var player = ModReferences.AllPlayerEntities.First(x => x.GetState<IPlayerState>().name == playerID);
												if (player)
												{
													Taunt.Cast(pos, radius, player.gameObject, duration, slow, pullIn);
												}
											}
											Taunt.CastEffect(pos, radius);
										}
										break;
									}

								case 4:
									PickUpManager.RemovePickup(r.ReadUInt64());
									break;

								case 5:
									{
										var baseItem = ItemDatabase.itemLookup[r.ReadInt32()];
										Item item = new Item(baseItem, 1, 0, false);   //reading first value, id
										ulong id = r.ReadUInt64();
										int itemLvl = r.ReadInt32();
										item.level = itemLvl;
										int amount = r.ReadInt32();
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										int dropSource = r.ReadInt32();
										while (r.BaseStream.Position != r.BaseStream.Length)
										{
											ItemStat stat = new ItemStat(ItemDatabase.Stats[r.ReadInt32()], itemLvl, r.ReadInt32())
											{
												amount = r.ReadSingle()
											};
											item.stats.Add(stat);
										}
										PickUpManager.SpawnPickUp(item, pos, amount, id, (ItemPickUp.DropSource)dropSource);
										break;
									}

								case 6:
									{
										if (!GameSetup.IsMpClient)
										{
											ulong packed = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(packed))
											{
												EnemyProgression ep = EnemyManager.hostDictionary[packed];
												using (MemoryStream answerStream = new MemoryStream())
												{
													using (BinaryWriter w = new BinaryWriter(answerStream))
													{
														w.Write(7);
														w.Write(packed);
														w.Write(ep.enemyName);
														w.Write(ep.level);
														w.Write((float)ep.HP);
														w.Write(ep.DamageTotal);
														w.Write((float)ep.maxHealth);
														w.Write(ep.bounty);
														w.Write(ep.armor);
														w.Write(ep.armorReduction);
														w.Write(ep.Steadfast);
														w.Write(ep.abilities.Count);
														foreach (EnemyProgression.Abilities item in ep.abilities)
														{
															w.Write((int)item);
														}

														w.Close();
													}
													NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Clients);
													answerStream.Close();
												}
											}
											else
											{
												Utils.Log("no enemy in host's dictionary");
											}
										}

										break;
									}

								case 7:
									{
										if (ModSettings.IsDedicated)
										{
											return;
										}

										if (GameSetup.IsMpClient)
										{
											ulong packed = r.ReadUInt64();

											BoltEntity entity = BoltNetwork.FindEntity(new Bolt.NetworkId(packed));
											string name = r.ReadString();
											int level = r.ReadInt32();
											double health = r.ReadSingle();
											float damage = r.ReadSingle();
											double maxhealth = r.ReadSingle();
											long bounty = r.ReadInt64();
											int armor = r.ReadInt32();
											int armorReduction = r.ReadInt32();
											float steadfast = r.ReadSingle();
											int length = r.ReadInt32();
											int[] affixes = new int[length];
											for (int i = 0; i < length; i++)
											{
												affixes[i] = r.ReadInt32();
											}
											if (EnemyManager.clinetProgressions.ContainsKey(entity))
											{
												ClientEnemyProgression cp = EnemyManager.clinetProgressions[entity];
												cp.Update(entity, name, level, (float)health, damage, (float)maxhealth, bounty, armor, armorReduction, steadfast, affixes);
											}
											else
											{
												new ClientEnemyProgression(entity).Update(entity, name, level, (float)health, damage, (float)maxhealth, bounty, armor, armorReduction, steadfast, affixes);
											}

										}
										break;
									}

								case 8: //enemy spells
									{
										int id = r.ReadInt32();
										if (id == 1) //snow aura
										{
											ulong packed = r.ReadUInt64();
											SnowAura sa = new GameObject("Snow").AddComponent<SnowAura>();

											sa.followTarget = BoltNetwork.FindEntity(new Bolt.NetworkId(packed)).transform;
										}
										else if (id == 2) //fire aura
										{
											ulong packed = r.ReadUInt64();
											float dmg = r.ReadSingle();
											GameObject go = BoltNetwork.FindEntity(new Bolt.NetworkId(packed)).gameObject;
											FireAura.Cast(go, dmg);
										}

										break;
									}

								case 9: //add buff to a player by id
									{
										string playerID = r.ReadString();
										if (playerID == "@everyone" || ModReferences.ThisPlayerID == playerID)
										{
											int source = r.ReadInt32();
											float amount = r.ReadSingle();
											float duration = r.ReadSingle();

											BuffDB.AddBuff(3, source, amount, duration);
										}

										break;
									}

								case 10:
									ModdedPlayer.instance.AddKillExperience(r.ReadInt64());
									break;

								case 11:
									ModdedPlayer.instance.AddFinalExperience(r.ReadInt64());
									break;

								case 12:
									{
										if (ModdedPlayer.Stats.rootImmunity == 0 && ModdedPlayer.Stats.stunImmunity == 0)
										{
											Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
											if ((LocalPlayer.Transform.position - pos).sqrMagnitude < 1250)
											{
												float duration = r.ReadSingle();
												ModdedPlayer.instance.Root(duration);
												using (MemoryStream answerStream = new MemoryStream())
												{
													using (BinaryWriter w = new BinaryWriter(answerStream))
													{
														w.Write(14);
														w.Write(LocalPlayer.Transform.position.x);
														w.Write(LocalPlayer.Transform.position.y);
														w.Write(LocalPlayer.Transform.position.z);
														w.Write(duration);
														w.Close();
													}
													NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Everyone);
													answerStream.Close();
												}
											}
										}

										break;
									}

								case 13:
									{
										if (ModSettings.IsDedicated)
											return;
										if (ModdedPlayer.Stats.stunImmunity == 0)
										{
											string playerID = r.ReadString();
											if (ModReferences.ThisPlayerID == playerID)
											{
												float duration = r.ReadSingle();
												ModdedPlayer.instance.Stun(duration);
											}
										}

										break;
									}

								case 14:
									{
										if (ModSettings.IsDedicated)
											return;

										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										float duration = r.ReadSingle();
										RootSpell.Create(pos, duration);
										break;
									}

								case 15:
									{
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										float duration = r.ReadSingle();
										float radius = r.ReadSingle();
										TrapSphereSpell.Create(pos, radius, duration);
										break;
									}

								case 16:
									{
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										Vector3 dir = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());

										EnemyLaser.CreateLaser(pos, dir);
										break;
									}

								case 17:
									{
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										Meteor.CreateEnemy(pos, r.ReadInt32());
										break;
									}

								case 18:
									{
										using (MemoryStream answerStream = new MemoryStream())
										{
											using (BinaryWriter w = new BinaryWriter(answerStream))
											{
												w.Write(19);
												w.Write(ModReferences.ThisPlayerID);
												w.Write(ModdedPlayer.instance.level);
											}
											NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Others);
										}

										break;
									}

								case 19:
									{
										string packed = r.ReadString();
										int level = r.ReadInt32();
										if (ModReferences.PlayerLevels.ContainsKey(packed))
										{
											ModReferences.PlayerLevels[packed] = level;
											ModReferences.UpdatePlayerLevel(packed, level);
										}
										else
										{
											ModReferences.PlayerLevels.Add(packed, level);
											ModReferences.UpdatePlayerLevel(packed, level);

										}

										break;
									}

								case 20:
									{
										if (ModSettings.IsDedicated)
											return;

										float amount = r.ReadSingle();
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										Color c = new Color(r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										MainMenu.CreateHitMarker(amount, pos, c);
										break;
									}

								case 21:
									{
										if (ModSettings.IsDedicated)
											return;

										int amount = r.ReadInt32();
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										new MainMenu.HitMarker(amount, pos, true);
										break;
									}

								case 22:    //slow enemy by id
									{
										if (GameSetup.IsMpServer || GameSetup.IsSinglePlayer)
										{
											ulong id = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(id))
											{
												float amount = r.ReadSingle();
												float time = r.ReadSingle();
												int src = r.ReadInt32();
												EnemyManager.hostDictionary[id].Slow(src, amount, time);
											}
										}

										break;
									}

								//case 23 & 24 obsolete - were related to syncing magic find
								case 25:
									{
										if (GameSetup.IsMpServer)
										{
											ulong itemID = r.ReadUInt64();
											if (PickUpManager.PickUps.ContainsKey(itemID))
											{
												int itemAmount = r.ReadInt32();
												string playerID = r.ReadString();

												if (PickUpManager.PickUps[itemID].amount > 0)
												{
													int givenAmount = itemAmount;
													if (itemAmount > PickUpManager.PickUps[itemID].amount)
													{
														givenAmount = Mathf.Min(PickUpManager.PickUps[itemID].amount, itemAmount);
													}

													NetworkManager.SendItemToPlayer(PickUpManager.PickUps[itemID].item, playerID, givenAmount);

													PickUpManager.PickUps[itemID].amount -= givenAmount;

													if (PickUpManager.PickUps[itemID].amount > 0)
													{
														return;
													}
												}
											}
											using (MemoryStream answerStream = new MemoryStream())
											{
												using (BinaryWriter w = new BinaryWriter(answerStream))
												{
													w.Write(4);
													w.Write(itemID);
													w.Close();
												}
												NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Clients);
												answerStream.Close();
											}
										}

										break;
									}

								case 26:
									{
										string playerID = r.ReadString();
										if (ModReferences.ThisPlayerID == playerID)
										{
											//creating the item.
											Item item = new Item(ItemDatabase.itemLookup[r.ReadInt32()], r.ReadInt32(), 0, false)
											{
												level = r.ReadInt32()
											};

											//adding stats to the item
											while (r.BaseStream.Position != r.BaseStream.Length)
											{
												int statId = r.ReadInt32();
												int statPoolIdx = r.ReadInt32();
												ItemStat stat = new ItemStat(ItemDatabase.Stats[statId], 1, statPoolIdx)
												{
													amount = r.ReadSingle()
												};
												item.stats.Add(stat);
											}

											Inventory.Instance.AddItem(item, item.stackedAmount);
										}

										break;
									}

								case 27:
									{
										if (GameSetup.IsMpServer || GameSetup.IsSinglePlayer)
										{
											ulong id = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(id))
											{
												float amount = r.ReadSingle();
												float time = r.ReadSingle();
												int src = r.ReadInt32();
												EnemyManager.hostDictionary[id].FireDebuff(src, amount, time);
											}
										}

										break;
									}

								case 28:
									{
										string id = r.ReadString();
										int weaponID = r.ReadInt32();
										if (!ModReferences.PlayerHands.ContainsKey(id) || ModReferences.PlayerHands[id] == null)
										{
											ModReferences.FindHands();
										}

										if (ModReferences.PlayerHands.ContainsKey(id))
										{
											CoopCustomWeapons.SetWeaponOn(ModReferences.PlayerHands[id], weaponID);
											Console.WriteLine(ModReferences.PlayerHands[id].name);
										}
										else
										{
											Debug.LogWarning("NO HAND IN COMMAND READER");
										}

										break;
									}

								case 29: //request for sync enemy abilities, visuals, appearance
									{
										if (GameSetup.IsMpServer)
										{
											ulong id = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(id))
											{
												EnemyProgression p = EnemyManager.hostDictionary[id];
												p.SyncAppearance(id);
											}
										}

										break;
									}

								case 30: //sync enemy abilities, visuals, appearance
									{
										ulong id = r.ReadUInt64();
										float dmg = r.ReadSingle();
										float scale = r.ReadSingle();
										Color c = new Color(r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										List<EnemyProgression.Abilities> abilities = new List<EnemyProgression.Abilities>();
										while (r.BaseStream.Position != r.BaseStream.Length)
										{
											abilities.Add((EnemyProgression.Abilities)r.ReadInt32());
										}
										new ClientEnemy(id, dmg, scale, c, abilities);
										break;
									}

								case 31:
									{
										uint id = r.ReadUInt32();
										Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										if (BallLightning.list.ContainsKey(id))
										{
											BallLightning.list[id].CoopTrigger(pos);
										}

										break;
									}

								case 32:
									{
										ulong id = r.ReadUInt64();
										if (EnemyManager.hostDictionary.ContainsKey(id))
										{
											EnemyProgression p = EnemyManager.hostDictionary[id];
											p.DoDoT(r.ReadSingle(), r.ReadSingle());
										}

										break;
									}

								case 33:
									{
										ulong enemy = r.ReadUInt64();
										if (EnemyManager.hostDictionary.ContainsKey(enemy))
										{
											EnemyProgression p = EnemyManager.hostDictionary[enemy];
											float duration = r.ReadSingle();
											var source = r.ReadInt32();
											float slowAmount = r.ReadSingle();
											float dmgDebuff = r.ReadSingle();
											var bleedDmg = r.ReadInt32();
											float bleedChance = r.ReadSingle();
											p.Slow(source, slowAmount, duration);
											p.DmgTakenDebuff(source, dmgDebuff, duration);
											if (UnityEngine.Random.value < bleedChance)
											{
												p.DoDoT(bleedDmg, duration);
											}
										}

										break;
									}

								case 34:
									{
										if (GameSetup.IsMpServer)
										{
											ulong enemy = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(enemy))
											{
												EnemyProgression p = EnemyManager.hostDictionary[enemy];
												var source = r.ReadInt32();
												float amount = r.ReadSingle();
												float duration = r.ReadSingle();
												p.DmgTakenDebuff(source, amount, duration);
											}
										}

										break;
									}

								case 35:
									{
										string player = r.ReadString();
										if (MainMenu.Instance.otherPlayerPings.ContainsKey(player))
										{
											MainMenu.Instance.otherPlayerPings.Remove(player);
										}

										break;
									}

								case 36:
									{
										string PlayerID = r.ReadString();
										MarkObject.PingType ptype = (MarkObject.PingType)r.ReadInt32();
										switch (ptype)
										{
											case MarkObject.PingType.Enemy:
												ulong EnemyID = r.ReadUInt64();

												bool isElite = r.ReadBoolean();
												string name = r.ReadString();
												BoltEntity entity = BoltNetwork.FindEntity(new Bolt.NetworkId(EnemyID));
												Transform tr = entity.transform;
												if (PlayerID == ModReferences.ThisPlayerID)
												{
													MainMenu.Instance.localPlayerPing = new MarkEnemy(tr, name, isElite, entity);
												}
												else
												{
													if (MainMenu.Instance.otherPlayerPings.ContainsKey(PlayerID))
													{
														MainMenu.Instance.otherPlayerPings[PlayerID] = new MarkEnemy(tr, name, isElite, entity);
													}
													else
													{
														MainMenu.Instance.otherPlayerPings.Add(PlayerID, new MarkEnemy(tr, name, isElite, entity));
													}

												}
												break;

											case MarkObject.PingType.Location:
												float x = r.ReadSingle(), y = r.ReadSingle(), z = r.ReadSingle();
												if (PlayerID == ModReferences.ThisPlayerID)
												{
													MainMenu.Instance.localPlayerPing = new MarkPostion(new Vector3(x, y, z));
												}
												else
												{
													if (MainMenu.Instance.otherPlayerPings.ContainsKey(PlayerID))
													{
														MainMenu.Instance.otherPlayerPings[PlayerID] = new MarkPostion(new Vector3(x, y, z));
													}
													else
													{
														MainMenu.Instance.otherPlayerPings.Add(PlayerID, new MarkPostion(new Vector3(x, y, z)));
													}
												}

												break;

											case MarkObject.PingType.Item:
												ulong PickupID = r.ReadUInt64();
												if (PickUpManager.PickUps.ContainsKey(PickupID))
												{
													var pu = PickUpManager.PickUps[PickupID];
													if (PlayerID == ModReferences.ThisPlayerID)
													{
														MainMenu.Instance.localPlayerPing = new MarkPickup(pu.transform, pu.item.name, pu.item.rarity);
													}
													else
													{
														if (MainMenu.Instance.otherPlayerPings.ContainsKey(PlayerID))
														{
															MainMenu.Instance.otherPlayerPings[PlayerID] = new MarkPickup(pu.transform, pu.item.name, pu.item.rarity);
														}
														else
														{
															MainMenu.Instance.otherPlayerPings.Add(PlayerID, new MarkPickup(pu.transform, pu.item.name, pu.item.rarity));
														}
													}
												}
												break;
										}

										break;
									}

								case 37:
									{
										if (GameSetup.IsMpServer)
										{
											string PlayerID = r.ReadString();
											ulong EnemyID = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(EnemyID))
											{
												var enemy = EnemyManager.hostDictionary[EnemyID];
												using (MemoryStream answerStream = new MemoryStream())
												{
													using (BinaryWriter w = new BinaryWriter(answerStream))
													{
														w.Write(36);
														w.Write(PlayerID);
														w.Write(0);
														w.Write(EnemyID);
														w.Write(enemy._rarity != EnemyProgression.EnemyRarity.Normal);
														w.Write(enemy.enemyName);
														w.Close();
													}
													NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Everyone);
													answerStream.Close();
												}
											}
										}

										break;
									}

								case 38:
									{
										if (GameSetup.IsMpClient)
										{
											string PlayerID = r.ReadString();
											if (ModReferences.ThisPlayerID == PlayerID)
											{
												Vector3 pos = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
												SpellActions.CastBallLightning(pos, Vector3.down);
											}
										}

										break;
									}

								case 39:
									{
										var s = r.ReadString();
										if (ModReferences.ThisPlayerID == s)
										{
											BuffDB.AddBuff(25, 91, r.ReadSingle(), 10);
											BuffDB.AddBuff(9, 92, 1.35f, 30);
											LocalPlayer.Stats.Energy += ModdedPlayer.Stats.TotalMaxEnergy / 10f;
											ModdedPlayer.instance.damageAbsorbAmounts[2] = r.ReadSingle();
										}

										break;
									}

								case 40:
									{
										var s = r.ReadString();
										if (ModReferences.ThisPlayerID == s)
										{
											BuffDB.AddBuff(r.ReadInt32(), r.ReadInt32(), r.ReadSingle(), r.ReadSingle());
										}

										break;
									}

								case 41:
									{
										var vector = new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
										var dist = r.ReadSingle();
										if ((vector - LocalPlayer.Transform.position).sqrMagnitude <= dist * dist)
										{
											BuffDB.AddBuff(r.ReadInt32(), r.ReadInt32(), r.ReadSingle(), r.ReadSingle());
										}

										break;
									}

								case 42:
									BuffDB.AddBuff(r.ReadInt32(), r.ReadInt32(), r.ReadSingle(), r.ReadSingle());
									break;

								case 43:
									{
										if (GameSetup.IsMpServer)
										{
											ulong EnemyID = r.ReadUInt64();
											if (EnemyManager.hostDictionary.ContainsKey(EnemyID))
											{
												var enemy = EnemyManager.hostDictionary[EnemyID];
												enemy.AddKnockbackByDistance(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()), r.ReadSingle());
											}
										}

										break;
									}
								case 44:
									if (GameSetup.IsMpClient)
									{
										var entity = BoltNetwork.FindEntity(new Bolt.NetworkId(r.ReadUInt64()));
										if (EnemyManager.clinetProgressions.ContainsKey(entity))
										{
											ClientEnemyProgression cp = EnemyManager.clinetProgressions[entity];
											cp.UpdateDynamic(r.ReadSingle(), r.ReadInt32(), r.ReadInt32(), r.ReadSingle());
											UnityEngine.Debug.Log("Received update dynamic client enemy cmd");
										}
										else
										{
											UnityEngine.Debug.LogWarning("Not fonund CP entity");
										}
									}
									else
									{
										ulong packed = r.ReadUInt64();
										if (EnemyManager.hostDictionary.TryGetValue(packed, out var enemy))
										{
											using (MemoryStream answerStream = new MemoryStream())
											{
												using (BinaryWriter w = new BinaryWriter(answerStream))
												{
													w.Write(44);
													w.Write(packed);
													w.Write((float)enemy.HP);
													w.Write(enemy.armor);
													w.Write(enemy.armorReduction);
													w.Write(enemy.DamageAmp);
													w.Close();
												}
												NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Clients);
												answerStream.Close();
											}
											UnityEngine.Debug.Log("CP request sent"); 
										}
										else
										{
											UnityEngine.Debug.Log("Host doesnt have enemy with that packed");

										}
									}
									break;
							}
					}
					catch (Exception e)
					{

						ModAPI.Log.Write("Error: " + cmdIndex + "\n" + e.ToString());
					}
					r.Close();
				}
				stream.Close();
			}
		}
	}
}