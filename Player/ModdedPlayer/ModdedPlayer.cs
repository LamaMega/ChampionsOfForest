﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Bolt;
using ChampionsOfForest.Effects;
using ChampionsOfForest.Localization;
using ChampionsOfForest.Network;
using TheForest.Utils;
using UnityEngine;
using static ChampionsOfForest.Player.BuffDB;
using Random = UnityEngine.Random;

namespace ChampionsOfForest.Player
{
	public partial class ModdedPlayer : MonoBehaviour
	{
		public List<CPlayerStatBase> allStats = new List<CPlayerStatBase>();

		private ModdedPlayerStats stats;
		public static ModdedPlayerStats Stats => instance.stats;
		public static ModdedPlayer instance = null;


		public int level = 1;

		public float basejumpPower;
		public long ExpCurrent = 0;
		public long ExpGoal = 1;
		public int PermanentBonusPerkPoints;
		public int MutationPoints = 1;
		public long NewlyGainedExp;
		public int MassacreKills;
		public string MassacreText = "";
		public float MassacreMultiplier = 1;
		public float TimeUntillMassacreReset;

		public float DamageAbsorbAmount
		{
			get
			{
				float f = 0;
				for (int i = 0; i < damageAbsorbAmounts.Length; i++)
				{
					f += damageAbsorbAmounts[i];
				}
				return f;
			}
		}

		public float[] damageAbsorbAmounts = new float[3];//every unique source of shielding gets their own slot here, if its not unique it uses [0]
														  //[1] is channeled shield spell;

		
		public Dictionary<int, int> GeneratedResources = new Dictionary<int, int>();

		//Smokeys quiver
		//Hexed pants of mr Moritz
		
		public int LastDayOfGeneration = 0;
		public float RootDuration = 0;
		public float StunDuration = 0;


		//Death Pact shoulders


		public float lostArmor = 0;


		public float _greedCooldown;
		public float _lastCrossfireTime;
		public float _HexedPantsOfMrM_StandTime;
		public float _DeathPact_Amount = 1;


		public Dictionary<int, ExtraItemCapacity> ExtraCarryingCapactity = new Dictionary<int, ExtraItemCapacity>();

		public struct ExtraItemCapacity
		{
			public int ID;
			public int Amount;
			public bool applied;

			public ExtraItemCapacity(int id, int amount)
			{
				ID = id;
				Amount = amount;
				applied = false;
			}

			public void NewApply()
			{
				applied = true;
				LocalPlayer.Inventory.AddMaxAmountBonus(ID, Amount);
			}

			public void ExistingApply(int NewAmount)
			{
				if (applied)
				{
					Remove();
				}
				Amount += NewAmount;
				if (Amount > 0)
				{
					NewApply();
				}
				else
				{
					instance.ExtraCarryingCapactity.Remove(ID);
				}
			}

			public void Remove()
			{
				switch (ID)
				{
					case 53:    //rock and rock bag
						if (LocalPlayer.Inventory.AmountOf(214) > 0)
						{
							LocalPlayer.Inventory.SetMaxAmountBonus(ID, 5);
						}
						break;

					case 82:    //small rock and small rock bag
						if (LocalPlayer.Inventory.AmountOf(282) > 0)
						{
							LocalPlayer.Inventory.SetMaxAmountBonus(ID, 15);
						}
						break;

					case 57:    //stick and stick bag
						if (LocalPlayer.Inventory.AmountOf(215) > 0)
						{
							LocalPlayer.Inventory.SetMaxAmountBonus(ID, 10);
						}
						break;

					case 56:    //spears and spear bag
						if (LocalPlayer.Inventory.AmountOf(290) > 0)
						{
							LocalPlayer.Inventory.SetMaxAmountBonus(ID, 4);
						}
						break;

					default:

						LocalPlayer.Inventory.SetMaxAmountBonus(ID, 0);
						break;
				}
				applied = false;
			}
		}

		public void AddExtraItemCapacity(int ID, int Amount)
		{
			if (ExtraCarryingCapactity.ContainsKey(ID))
			{
				ExtraCarryingCapactity[ID].ExistingApply(Amount);
			}
			else if (Amount > 0)
			{
				ExtraItemCapacity EIC = new ExtraItemCapacity(ID, Amount);
				EIC.NewApply();
				ExtraCarryingCapactity.Add(ID, EIC);
			}
		}

		public void AddExtraItemCapacity(int[] ID, int Amount)
		{
			for (int i = 0; i < ID.Length; i++)
			{
				AddExtraItemCapacity(ID[i], Amount);
			}
		}
		void Awake()
		{
			instance = this;
		}
	public	void SetStats()
		{
			stats = new ModdedPlayerStats();
		}

		private void Start()
		{
			ExpGoal = GetGoalExp();

			if (!GameSetup.IsNewGame)
			{
				MoreCraftingReceipes.BlockUpdating = true;
				Serializer.Load();
			}
			InitializeHandHeld();
			Invoke("SendJoinMessage", 6);
			StartCoroutine(InitializeCamera());
		}
		public void AfterRespawn()
		{
			InitializeHandHeld();
			StartCoroutine(InitializeCamera());

		}

		/// <summary>
		/// Adds a post processing effect to the camera
		/// </summary>
		private IEnumerator InitializeCamera()
		{
			while (Camera.main == null || LocalPlayer.Inventory == null)
			{
				yield return null;
			}
			yield return null;
			yield return null;
			yield return null;
			if (RealisticBlackHoleEffect.instance == null)
			{
				Camera.main.gameObject.AddComponent<RealisticBlackHoleEffect>();
			}
			LocalPlayer.Inventory.Blocked.AddListener(SpellActions.OnBlockSetTimer);
		}

		public void SendLevelMessage()
		{
			if (ChatBoxMod.instance != null)
			{
				if (BoltNetwork.isRunning)
				{
					NetworkManager.SendText("II" + LocalPlayer.Entity.GetState<IPlayerState>().name + " has reached level " + instance.level + "!", NetworkManager.Target.Everyone);
				}
			}
			MainMenu.Instance.LevelUpAction();
		}

		public void SendJoinMessage()
		{
			if (ChatBoxMod.instance != null)
			{
				if (BoltNetwork.isRunning)
				{
					string s = "IIWelcome " + LocalPlayer.Entity.GetState<IPlayerState>().name + "!\nChampion level: " + level + "\nINSTALLED MODS: \n";
					foreach (var item in ModAPI.Mods.LoadedMods)
					{
						s += "- " + item.Value.Id + " [" + item.Value.Version + "]\n";
					}
					NetworkManager.SendText(s, NetworkManager.Target.Everyone);
				}
			}
		}

		public void SendLeaveMessage(string Player)
		{
			if (ChatBoxMod.instance != null)
			{
				if (BoltNetwork.isRunning)
				{
					string s = "II" + Player + " left the server";
					NetworkManager.SendText(s, NetworkManager.Target.Everyone);
				}
		
			}

		}

		public static int AttributeBonus(int x)
		{
			if (x == 1)
				return 1;
			int bonus = Mathf.RoundToInt(Mathf.Sqrt(x));
			return AttributeBonus(x - 1) + bonus;
		}

		public void AssignLevelAttributes()
		{
			int x = AttributeBonus(level);

			Stats.strength.Add(x);
			Stats.intelligence.Add(x);
			Stats.vitality.Add(x);
			Stats.agility.Add(x);
		}

		private static string ListComponents(Transform t, string prefix = "")
		{
			string result = prefix + t.name + ":\n";
			var components = t.gameObject.GetComponents<Component>();
			foreach (var comp in components)
			{
				result += prefix + "\t- " + comp.GetType().ToString() + "\n";
			}
			foreach (Transform child in t)
			{
				result += ListComponents(child, prefix + "\t");
			}
			return result;
		}

		private void Update()
		{
			if (ModAPI.Input.GetButtonDown("EquipWeapon"))
			{
				if (Inventory.Instance.ItemSlots[-12] != null && Inventory.Instance.ItemSlots[-12].isEquipped)
				{
					PlayerInventoryMod.ToEquipWeaponType = Inventory.Instance.ItemSlots[-12].subtype;
					switch (Inventory.Instance.ItemSlots[-12].subtype)
					{
						case ItemDefinition.ItemSubtype.Polearm:
							if (LocalPlayer.Inventory.AmountOf(56) <= 0)
							{
								LocalPlayer.Inventory.AddItem(56);
							}
							LocalPlayer.Inventory.StashEquipedWeapon(false);
							LocalPlayer.Inventory.Equip(56, false);
							break;

						case ItemDefinition.ItemSubtype.Greatbow:
							if (LocalPlayer.Inventory.AmountOf(79) <= 0)
							{
								LocalPlayer.Inventory.AddItem(79);
							}
							LocalPlayer.Inventory.StashEquipedWeapon(false);
							if (CustomBowBase.baseBow == null)
							{
								PlayerInventoryMod.ToEquipWeaponType = ItemDefinition.ItemSubtype.None;
								LocalPlayer.Inventory.Equip(79, false);
							}
							else if (LocalPlayer.Inventory.Equip(79, false))
							{
								CustomBowBase.baseBow.SetActive(false);
								if (GreatBow.instance != null)
								{
									GreatBow.instance.SetActive(true);
								}
#if Debugging_Enabled
								else
								{
									ModAPI.Console.Write("No Greatbow instance");
								}
#endif
							}
#if Debugging_Enabled
							else
							{
								ModAPI.Log.Write("Trying to equip a greatbow but no crafted bow in inventory");
							}
#endif
							break;

						default:
							if (LocalPlayer.Inventory.AmountOf(80) <= 0)
							{
								LocalPlayer.Inventory.AddItem(80);
							}
							LocalPlayer.Inventory.StashEquipedWeapon(false);
							LocalPlayer.Inventory.Equip(80, false);
							break;
					}

					PlayerInventoryMod.ToEquipWeaponType = ItemDefinition.ItemSubtype.None;
				}
			}
			try
			{
				float dmgPerSecond = 0;
				int poisonCount = 0;
				lostArmor = 0;
				int[] keys = new List<int>(activeBuffs.Keys).ToArray();
				for (int i = 0; i < keys.Length; i++)
				{
					Buff buff = activeBuffs[keys[i]];
					if (stats.debuffImmunity > 0 && buff.isNegative && buff.DispellAmount <= 2)
					{
						activeBuffs[keys[i]].ForceEndBuff(keys[i]);
						continue;
					}
					else if (stats.debuffResistance > 0 && buff.isNegative && buff.DispellAmount <= 1)
					{
						activeBuffs[keys[i]].ForceEndBuff(keys[i]);
						continue;
					}
					else
					{
						activeBuffs[keys[i]].UpdateBuff(keys[i]);
						if (buff._ID == 3)
						{
							poisonCount++;
							dmgPerSecond += buff.amount;
						}
						else if (buff._ID == 21)
						{
							lostArmor -= buff.amount;
						}
					}
				}
				if (dmgPerSecond != 0)
				{
					dmgPerSecond *= stats.damageFromElites;
					dmgPerSecond *= Stats.allDamageTaken;
					LocalPlayer.Stats.Health -= dmgPerSecond * Time.deltaTime;
					LocalPlayer.Stats.HealthTarget -= dmgPerSecond * Time.deltaTime * 2;

					if (poisonCount > 1)
					{
						AddBuff(1, 33, 0.7f, 1);
					}
				}
				if (LocalPlayer.Stats.Health <= 0 && !LocalPlayer.Stats.Dead)
				{
					LocalPlayer.Stats.Hit(10, true, PlayerStats.DamageType.Drowning);
				}
			}
			catch (Exception)
			{
				//ModAPI.Log.Write("Poisoning player error" + e.ToString());
			}

			if (LocalPlayer.Stats != null)
			{
				if (Stats.perk_danceOfFiregodAtkCap&& BlackFlame.IsOn)
				{
					LocalPlayer.Animator.speed = 2.0f;
					return;
				}
				float ats = stats.attackSpeed;
				if (GreatBow.isEnabled)
					ats /= 2f;

				if (LocalPlayer.Stats.Stamina > 4)
				{
					LocalPlayer.Animator.speed = ats;
				}
				else
				{
					LocalPlayer.Animator.speed = Mathf.Min(0.5f, ats / 2);
				}

				if (LocalPlayer.Stats.Health < stats.TotalMaxHealth)
				{
					if (LocalPlayer.Stats.Health < LocalPlayer.Stats.HealthTarget)
					{
						LocalPlayer.Stats.Health += stats.lifeRegenBase* (stats.lifeRegenMult) * stats.allRecoveryMult;
					}
					else
					{
						LocalPlayer.Stats.Health += stats.lifeRegenBase * (stats.lifeRegenMult) * stats.allRecoveryMult / 10;
					}
				}

				if (Clock.Day > LastDayOfGeneration)
				{
					for (int i = 0; i < Clock.Day - LastDayOfGeneration; i++)
					{
						foreach (KeyValuePair<int, int> pair in GeneratedResources)
						{
							LocalPlayer.Inventory.AddItem(pair.Key, pair.Value);
						}
					}
					LastDayOfGeneration = Clock.Day;
				}
			}

			if (TimeUntillMassacreReset > 0)
			{
				TimeUntillMassacreReset -= Time.unscaledDeltaTime;
				if (TimeUntillMassacreReset <= 0)
				{
					AddFinalExperience(Convert.ToInt64((double)NewlyGainedExp * MassacreMultiplier));
					NewlyGainedExp = 0;
					TimeUntillMassacreReset = 0;
					MassacreKills = 0;
					CountMassacre();
				}
			}

			if (Multishot.IsOn)
			{
				if (!SpellCaster.RemoveStamina(3 * Time.deltaTime) || LocalPlayer.Stats.Stamina < 7)
				{
					Multishot.IsOn = false;
					Multishot.localPlayerInstance.SetActive(false);
				}
			}
			Berserker.Effect();

			if (stats.rooted)
			{
				if (stats.stunImmunity> 0 || stats.rootImmunity > 0)
				{
					stats.rooted.Reset();
					if (!stats.stunned)
					{
						LocalPlayer.FpCharacter.MovementLocked = false;
						LocalPlayer.FpCharacter.CanJump = true;
						LocalPlayer.Rigidbody.isKinematic = false;
						LocalPlayer.Rigidbody.useGravity = true;
						LocalPlayer.Rigidbody.WakeUp();
					}
				}

				RootDuration -= Time.deltaTime;
				if (RootDuration < 0)
				{
					Stats.rooted.Reset();
					if (!Stats.stunned)
					{
						LocalPlayer.Rigidbody.isKinematic = false;
						LocalPlayer.Rigidbody.useGravity = true;
						LocalPlayer.Rigidbody.WakeUp();
						LocalPlayer.FpCharacter.MovementLocked = false;
						LocalPlayer.FpCharacter.CanJump = true;
					}
				}
			}
			if (Stats.stunned)
			{
				if (stats.stunImmunity > 0)
				{
					Stats.stunned.Reset();
					LocalPlayer.FpCharacter.Locked = false;
					if (!Stats.rooted)
					{
						LocalPlayer.FpCharacter.MovementLocked = false;
						LocalPlayer.FpCharacter.CanJump = true;
						LocalPlayer.Rigidbody.isKinematic = false;
						LocalPlayer.Rigidbody.useGravity = true;
						LocalPlayer.Rigidbody.WakeUp();
					}
				}
				StunDuration -= Time.deltaTime;
				if (StunDuration < 0)
				{
					Stats.stunned.Reset();
					LocalPlayer.FpCharacter.Locked = false;
					if (!Stats.rooted)
					{
						LocalPlayer.FpCharacter.MovementLocked = false;
						LocalPlayer.FpCharacter.CanJump = true;
						LocalPlayer.Rigidbody.isKinematic = false;
						LocalPlayer.Rigidbody.useGravity = true;
						LocalPlayer.Rigidbody.WakeUp();
					}
				}
			}
			if (stats.i_HexedPantsOfMrM_Enabled)
			{
				if (LocalPlayer.FpCharacter.velocity.sqrMagnitude < 0.1)//if standing still
				{
					_HexedPantsOfMrM_StandTime = Mathf.Clamp(_HexedPantsOfMrM_StandTime - Time.deltaTime, -1.1f, 1.1f);
					if (_HexedPantsOfMrM_StandTime <= 1)
					{
						if (LocalPlayer.Stats.Health > 5)
						{
							LocalPlayer.Stats.Health -= Time.deltaTime * stats.TotalMaxHealth * 0.01f;
						}
					}
				}
				else //if moving
				{
					_HexedPantsOfMrM_StandTime = Mathf.Clamp(_HexedPantsOfMrM_StandTime + Time.deltaTime, -1.1f, 1.1f);
					if (_HexedPantsOfMrM_StandTime >= 1)
					{
						AddBuff(9, 41, 1.6f, 1f);
						AddBuff(11, 42, 1.6f, 1f);
					}
				}
			}
			if (stats.i_DeathPact_Enabled)
			{
				Stats.allDamage.Divide(_DeathPact_Amount);

				_DeathPact_Amount = 1 + Mathf.RoundToInt((1 - (LocalPlayer.Stats.Health / Stats.TotalMaxHealth)) * 100) * 0.05f;
				AddBuff(12, 43, _DeathPact_Amount, 1f);

				Stats.allDamage.Multiply(_DeathPact_Amount);
			}
			else if(_DeathPact_Amount != 1)
			{
				
				Stats.allDamage.Divide(_DeathPact_Amount);
				_DeathPact_Amount = 1;
			}
			if (stats.i_isGreed)
			{
				_greedCooldown -= Time.deltaTime;
				if (_greedCooldown < 0)
				{
					AutoPickupItems.DoPickup();
					_greedCooldown = 1f;
				}
			}
			if (stats.perk_isShieldAutocast)
			{
				float mx = stats.TotalMaxEnergy* 0.90f;
				if (LocalPlayer.Stats.Energy >= mx)
				{
					if (LocalPlayer.Stats.Stamina >= mx)
					{
						var spell = SpellDataBase.spellDictionary[5];
						if (spell.IsEquipped)
						{
							if (SpellCaster.RemoveStamina(10 * Time.deltaTime))
								spell.active();
						}
					}
				}
			}
		}

		public float DealDamageToShield(float f)
		{
			for (int i = 0; i < damageAbsorbAmounts.Length; i++)
			{
				if (damageAbsorbAmounts[i] > 0)
				{
					if (f - damageAbsorbAmounts[i] <= 0)
					{
						damageAbsorbAmounts[i] -= f;
						return 0;
					}
					else
					{
						f -= damageAbsorbAmounts[i];
						damageAbsorbAmounts[i] = 0;
					}
				}
			}
			return f;
		}

		public void Root(float duration)
		{
			if (stats.rootImmunity > 0 || stats.stunImmunity > 0)
			{
				return;
			}
			LocalPlayer.HitReactions.enableFootShake(1, 0.2f);

			Stats.rooted.value= true;
			if (RootDuration < duration)
			{
				RootDuration = duration;
			}
			COTFEvents.Instance.OnStun.Invoke();

		}

		public void Stun(float duration)
		{
			if (stats.stunImmunity > 0)
			{
				return;
			}
			LocalPlayer.HitReactions.enableFootShake(1, 0.6f);
			Stats.stunned.value = true;
			if (StunDuration < duration)
			{
				StunDuration = duration;
			}
			COTFEvents.Instance.OnStun.Invoke();
		}

		public void AddKillExperience(long Amount)
		{
			COTFEvents.Instance.OnKill.Invoke();

			MassacreKills++;
			CountMassacre();
			if (TimeUntillMassacreReset == 0)
			{
				TimeUntillMassacreReset = stats.maxMassacreTime;
			}
			else
			{
				TimeUntillMassacreReset = Mathf.Clamp(TimeUntillMassacreReset + stats.timeBonusPerKill, 1, stats.maxMassacreTime);
			}
			NewlyGainedExp += Amount;
		}

		public void AddFinalExperience(long Amount)
		{
			COTFEvents.Instance.OnGainExp.Invoke();

			ExpCurrent += Convert.ToInt64(Amount * stats.expGain);
			int i = 0;
			while (ExpCurrent >= ExpGoal || (level > 100 && ExpCurrent < 0))
			{
				instance.ExpCurrent -= instance.ExpGoal;
				instance.LevelUp();
				MainMenu.Instance.LevelsToGain++;
				i++;
			}

			if (i > 0)
			{
				COTFEvents.Instance.OnGainLevel.Invoke();

				SendLevelMessage();

				if (GameSetup.IsMultiplayer)
				{
					using (MemoryStream answerStream = new MemoryStream())
					{
						using (BinaryWriter w = new BinaryWriter(answerStream))
						{
							w.Write(19);
							w.Write(ModReferences.ThisPlayerID);
							w.Write(instance.level);
							w.Close();
						}
						NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.Others);
						answerStream.Close();
					}
				}
			}
		}

		public void OnGetHit()
		{
			if (stats.spell_chanceToParryOnHit.value&& Random.value < 0.15f)
			{
				SpellActions.DoParry(LocalPlayer.Transform.forward + LocalPlayer.Transform.position);
			}
		}

		public void OnHit()
		{
			
			LocalPlayer.Stats.HealthTarget +=stats.lifeOnHit *stats.allRecoveryMult;
			LocalPlayer.Stats.Health += stats.lifeOnHit * stats.allRecoveryMult;
			LocalPlayer.Stats.Energy += stats.energyOnHit * stats.TotalEnergyRecoveryMultiplier;
			LocalPlayer.Stats.Stamina += stats.staminaOnHit * Stats.TotalEnergyRecoveryMultiplier;
			SpellActions.OnFrenzyAttack();
		}

		public void OnHitEffectsClient(BoltEntity ent, float damage)
		{
			if (ent != null)
			{
				if (stats.chanceToBleed > 0 && Random.value < stats.chanceToBleed)
				{
					using (MemoryStream answerStream = new MemoryStream())
					{
						using (BinaryWriter w = new BinaryWriter(answerStream))
						{
							w.Write(32);
							w.Write(ent.networkId.PackedValue);
							w.Write(damage / 20);
							w.Write(10);
							w.Close();
						}
						NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.OnlyServer);
						answerStream.Close();
					}
				}
				if (stats.chanceToSlow > 0 && Random.value < stats.chanceToSlow)
				{
					int id = 62 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
					using (MemoryStream answerStream = new MemoryStream())
					{
						using (BinaryWriter w = new BinaryWriter(answerStream))
						{
							w.Write(22);
							w.Write(ent.networkId.PackedValue);
							w.Write(0.5f);
							w.Write(8f);
							w.Write(id);
							w.Close();
						}
						NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.OnlyServer);
						answerStream.Close();
					}
				}
				if (stats.chanceToWeaken > 0 && Random.value < stats.chanceToWeaken)
				{
					int id = 62 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
					using (MemoryStream answerStream = new MemoryStream())
					{
						using (BinaryWriter w = new BinaryWriter(answerStream))
						{
							w.Write(34);
							w.Write(ent.networkId.PackedValue);
							w.Write(id);
							w.Write(1.2f);
							w.Write(8f);
							w.Close();
						}
						NetworkManager.SendLine(answerStream.ToArray(), NetworkManager.Target.OnlyServer);
						answerStream.Close();
					}
				}
			}
		}

		public void OnHitEffectsHost(EnemyProgression p, float damage)
		{
			if (p != null)
			{
				if (stats.chanceToBleed > 0 && Random.value < stats.chanceToBleed)
				{
					p.DoDoT(damage / 20, 10);
				}
				if (stats.chanceToSlow > 0 && Random.value < stats.chanceToSlow)
				{
					int id = 62 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
					p.Slow(id, 0.5f, 8);
				}
				if (stats.chanceToWeaken > 0 && Random.value < stats.chanceToWeaken)
				{
					int id = 62 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
					p.DmgTakenDebuff(id, 1.2f, 8);
				}
			}
		}

		public void OnHit_Ranged(Transform hit)
		{
			SpellCaster.InfinityLoopEffect();
			if (stats.spell_furySwipes)
			{
				if (hit == FurySwipesLastHit)
				{
					FurySwipesDmg += 10;
					Stats.baseRangedDamage.valueAdditive += 10;
					Stats.baseSpellDamage.valueAdditive += 10;
					Stats.baseMeleeDamage.valueAdditive += 10;
					AddBuff(27, 98, 10, 60);

				}
				else
				{
					FurySwipesLastHit = hit;
					Stats.baseRangedDamage.valueAdditive -= FurySwipesDmg;
					Stats.baseSpellDamage.valueAdditive -= FurySwipesDmg;
					Stats.baseMeleeDamage.valueAdditive -= FurySwipesDmg;
					FurySwipesDmg = 0;
					if (activeBuffs.ContainsKey(98))
						activeBuffs[98].amount = 0;
				}
			}
			
		}

		public int FurySwipesDmg;
		public Transform FurySwipesLastHit;

		public void OnHit_Melee(Transform hit)
		{

			SpellCaster.InfinityLoopEffect();
			if (stats.spell_furySwipes)
			{
				if (hit == FurySwipesLastHit)
				{
					FurySwipesDmg += 100;
					Stats.baseRangedDamage.valueAdditive += 100;
					Stats.baseSpellDamage.valueAdditive +=100;
					Stats.baseMeleeDamage.valueAdditive += 100;
					AddBuff(27, 98, 100, 60);

				}
				else
				{
					FurySwipesLastHit = hit;
					Stats.baseRangedDamage.valueAdditive -= FurySwipesDmg;
					Stats.baseSpellDamage.valueAdditive -= FurySwipesDmg;
					Stats.baseMeleeDamage.valueAdditive -= FurySwipesDmg;
					FurySwipesDmg = 0;
					if (activeBuffs.ContainsKey(98))
						activeBuffs[98].amount = 0;

				}
			}
		}

		public bool DoAreaDamage(Transform rootTR, float damage)
		{
			try
			{
				if (Random.value < stats.areaDamageChance && stats.areaDamage > 0)
				{
					DoGuaranteedAreaDamage(rootTR, damage);
					return true;
				}
			}
			catch (Exception ex)
			{
				ModAPI.Log.Write("Area dmg exception " + ex);
			}
			return false;
		}

		public void DoGuaranteedAreaDamage(Transform rootTR, float damage)
		{
			RaycastHit[] hits = Physics.SphereCastAll(rootTR.position, stats.areaDamageRadius, Vector3.one, stats.areaDamageRadius,-9);
			var d =damage * stats.areaDamage;
			if (d > 0)
			{
				for (int i = 0; i < hits.Length; i++)
				{
					if (hits[i].transform.root != rootTR.root)
					{
						if (hits[i].transform.tag == "enemyCollide")
						{
							if (GameSetup.IsMpClient)
							{
								BoltEntity entity = hits[i].transform.GetComponent<BoltEntity>();
								if (entity == null)
								{
									entity = hits[i].transform.GetComponentInParent<BoltEntity>();
								}
								if (entity != null)
								{
									PlayerHitEnemy playerHitEnemy = PlayerHitEnemy.Create(GlobalTargets.OnlyServer);
									playerHitEnemy.Hit =  DamageUtils.GetSendableDamage( d);
									playerHitEnemy.getAttackerType = DamageUtils.SILENTattackerType;		//silent hit
									playerHitEnemy.Target = entity;
									playerHitEnemy.Send();
								}
							}
							else
							{
								hits[i].transform.root.SendMessage("Hit", d, SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (hits[i].transform.tag == "BreakableWood" || hits[i].transform.tag == "animalCollide")
						{
							hits[i].transform.root.SendMessage("Hit", d, SendMessageOptions.DontRequireReceiver);
						}
					}
				}
			}
		}

		public void LevelUp()
		{
			MutationPoints++;
			level++;
			ExpGoal = GetGoalExp();
			GiveSpecialItems();
			int ap = Mathf.RoundToInt(Mathf.Sqrt(level));
			stats.agility.valueAdditive+=ap;
			stats.strength.valueAdditive  += ap;
			stats.vitality.valueAdditive += ap;
			stats.intelligence.valueAdditive += ap;
		}

		public void GiveSpecialItems()
		{
			if ((level % 10) == 0 && level > 1)
			{
				var item = new Item(ItemDatabase.ItemBaseByName("Heart of Purity"));
				item.level = 1;
				if (!Inventory.Instance.AddItem(item))
				{
					NetworkManager.SendItemDrop(item, LocalPlayer.Transform.position + Vector3.up * 2, ItemPickUp.DropSource.PlayerDeath);
				}
			}
			else if (level >= 10 && level % 20 == 5 )
			{
				var item = new Item(ItemDatabase.ItemBaseByName("Greater Mutated Heart"));
				item.level = 1;
				if (!Inventory.Instance.AddItem(item))
				{
					NetworkManager.SendItemDrop(item, LocalPlayer.Transform.position + Vector3.up * 2, ItemPickUp.DropSource.PlayerDeath);
				}
			}
		}

		public long GetGoalExp()
		{
			return GetGoalExp(level);
		}

		public long GetGoalExp(int lvl)
		{
			double x = lvl;
			if (x >= 138)	//once you hit this level, its time to stop leveling. thanks.
				return 5000000000000000000;
			double y = ((0.8 * x * x * x * x) +
				(x * x * x) +
				(2 * x * x)) + 
				(20 * x) +
				System.Math.Pow(System.Math.E,x/3.3) * 4 + 
				System.Math.Pow(1.36, x-5);
			//var y = 120 * System.Math.Pow(1.345f, x - 10) + 20 + 5 * x * x * x;
			//y = y / 3.3;
			return Convert.ToInt64(y);
		}

		public void CountMassacre()
		{
			if (KCInRange(0, 3))
			{
				MassacreMultiplier = 1;
				MassacreText = "";
			}
			else if (KCInRange(3, 4))
			{
				MassacreMultiplier = 1.1f;
				MassacreText = Translations.ModdedPlayer_1;//tr
			}
			else if (KCInRange(4, 5))
			{
				MassacreMultiplier = 1.25f;
				MassacreText = Translations.ModdedPlayer_2;//tr
			}
			else if (KCInRange(5, 6))
			{
				MassacreMultiplier = 1.5f;
				MassacreText = Translations.ModdedPlayer_3;//tr
			}
			else if (KCInRange(6, 10))
			{
				MassacreMultiplier = 1.75f;
				MassacreText = Translations.ModdedPlayer_4;//tr
			}
			else if (KCInRange(10, 12))
			{
				MassacreMultiplier = 2.3f;
				MassacreText = Translations.ModdedPlayer_5;//tr
			}
			else if (KCInRange(12, 16))
			{
				MassacreMultiplier = 3f;
				MassacreText = Translations.ModdedPlayer_6;//tr
			}
			else if (KCInRange(16, 20))
			{
				MassacreMultiplier = 5f;
				MassacreText = Translations.ModdedPlayer_7;//tr
			}
			else if (KCInRange(20, 25))
			{
				MassacreMultiplier = 8.5F;
				MassacreText = Translations.ModdedPlayer_8;//tr
			}
			else if (KCInRange(25, 30))
			{
				MassacreMultiplier = 16F;
				MassacreText = Translations.ModdedPlayer_9;//tr
			}
			else if (KCInRange(30, 40))
			{
				MassacreMultiplier = 22.5f;
				MassacreText = Translations.ModdedPlayer_10;//tr
			}
			else if (KCInRange(40, 50))
			{
				MassacreMultiplier = 35;
				MassacreText = Translations.ModdedPlayer_11;//tr
			}
			else if (KCInRange(50, 65))
			{
				MassacreMultiplier = 50;
				MassacreText = Translations.ModdedPlayer_12;//tr
			}
			else if (KCInRange(65, 75))
			{
				MassacreMultiplier = 100;
				MassacreText = Translations.ModdedPlayer_13;//tr
			}
			else if (KCInRange(75, 100))
			{
				MassacreMultiplier = 250;
				MassacreText = Translations.ModdedPlayer_14;//tr
			}
			else if (MassacreKills >= 100)
			{
				MassacreMultiplier = 1000;
				MassacreText = Translations.ModdedPlayer_15;//tr
			}
		}

		private bool KCInRange(int min, int max)
		{
			if (MassacreKills >= min && MassacreKills < max)
			{
				return true;
			}
			return false;
		}

		private void FinishMassacre()
		{
			TimeUntillMassacreReset = 0;
			long Amount = Convert.ToInt64((double)NewlyGainedExp * MassacreMultiplier);
			NewlyGainedExp = 0;
			MassacreMultiplier = 1;
			AddFinalExperience(Amount);
		}

		public void InitializeHandHeld()
		{
			StartCoroutine(InitHandCoroutine());
		}

		private IEnumerator InitHandCoroutine()
		{
			while (ModReferences.rightHandTransform == null)
			{
				yield return null;
				LocalPlayer.Inventory?.SendMessage("GetRightHand");
			}
			yield return null;
			MoreCraftingReceipes.Initialize();

			//Multishot
			Multishot.localPlayerInstance = Multishot.Create(LocalPlayer.Transform, ModReferences.rightHandTransform);
			Multishot.localPlayerInstance.SetActive(false);

			//yield return null;
			//do
			//{
			//    if (LocalPlayer.Inventory.Owns(79))
			//        LocalPlayer.Inventory.Equip(79, false);

			//}
			//while (PlayerInventoryMod.originalBowModel == null);
		}

		public void AddGeneratedResource(int id, int amount)
		{
			if (amount > 0)
			{
				if (GeneratedResources.ContainsKey(id))
				{
					GeneratedResources[id] += amount;
				}
				else
				{
					GeneratedResources.Add(id, amount);
				}
			}
			else
			{
				if (GeneratedResources.ContainsKey(id))
				{
					GeneratedResources[id] += amount;
					if (GeneratedResources[id] <= 0)
					{
						GeneratedResources.Remove(id);
					}
				}
			}
		}

		public static void UnAssignAllStats()
		{
			foreach (var item in instance.ExtraCarryingCapactity)
			{
				item.Value.Remove();
			}
			instance.ExtraCarryingCapactity.Clear();

			foreach (KeyValuePair<int, Item> item in Inventory.Instance.ItemSlots)
			{
				if (item.Value == null)
					continue;
				if (item.Value.isEquipped)
				{
					item.Value.onUnequipCallback?.Invoke();
					item.Value.isEquipped = false;
					foreach (var stat in item.Value.stats)
					{
						try
						{
							stat.OnUnequip?.Invoke(stat.amount);
						}
						catch (Exception e)
						{
							Debug.Log("err: " + e.Message);
						}
					}
				}
			}
			for (int i = 0; i < PerkDatabase.perks.Count; i++)
			{
				if (PerkDatabase.perks[i].isBought)
				{
					PerkDatabase.perks[i].isBought = false;
				}
			}
		}

		public static void ResetAllStats()
		{
			COTFEvents.ClearEvents();
			foreach (var item in instance.ExtraCarryingCapactity)
			{
				item.Value.Remove();
			}

			activeBuffs.Clear();
			SpellDataBase.Reset();

			foreach (var stat in instance.allStats)
			{
				stat.Reset();
			}
			Multishot.IsOn = false;
			SpellActions.ShieldCastTime = 0;
			SpellActions.SeekingArrow_ChangeTargetOnHit = false;
			SpellActions.SeekingArrow_TimeStamp = 0;
			BlackFlame.DmgAmp = 1;
			BlackFlame.GiveAfterburn = false;
			BlackFlame.GiveDamageBuff = false;
			WeaponInfoMod.AlwaysIgnite = false;
			AutoPickupItems.radius = 7.5f;
			Berserker.active = false;
			instance.damageAbsorbAmounts = new float[2];
			
			instance.GeneratedResources.Clear();

			MoreCraftingReceipes.LockAll();
			MoreCraftingReceipes.BlockUpdating = true;
			instance.AssignLevelAttributes();
			ReapplyAllItems();
			ReapplyAllPerks();
			ReapplyAllSpell();
			foreach (var extraItem in instance.ExtraCarryingCapactity)
			{
				extraItem.Value.NewApply();
			}
			MoreCraftingReceipes.BlockUpdating = false;
			MoreCraftingReceipes.AddReceipes();
		}

		public static void ReapplyAllSpell()
		{
			for (int i = 0; i < SpellCaster.SpellCount; i++)
			{
				SpellCaster.instance.infos[i].spell?.passive?.Invoke(true);
			}
		}

		public static void ReapplyAllItems()
		{
			//items
			foreach (int key in Inventory.Instance.ItemSlots.Keys)
			{
				if (Inventory.Instance.ItemSlots[key] != null)
				{
					Inventory.Instance.ItemSlots[key].isEquipped = false;
					
				}
			}
		}

		public static void ReapplyAllPerks()
		{
			//perks
			for (int i = 0; i < PerkDatabase.perks.Count; i++)
			{
				PerkDatabase.perks[i].ResetDescription();

				if (PerkDatabase.perks[i].isBought)
				{
					if (PerkDatabase.perks[i].stackable)
					{
						for (int j = 0; j < PerkDatabase.perks[i].boughtTimes; j++)
						{
							PerkDatabase.perks[i].onApply();

						}
					}
					else
						PerkDatabase.perks[i].onApply();
					PerkDatabase.perks[i].OnBuy();
				}
			}
		}

		public static void Respec()
		{
			MainMenu.Instance.StartCoroutine(MainMenu.Instance.FadeMenuSwitch(MainMenu.OpenedMenuMode.Hud));
			LocalPlayer.Stats.Health = 1;
			LocalPlayer.Stats.HealthTarget = 1;
			LocalPlayer.Stats.Energy = 1;
			UnAssignAllStats();
			Effects.Sound_Effects.GlobalSFX.Play(Effects.Sound_Effects.GlobalSFX.SFX.Purge);

			instance.MutationPoints = instance.level + instance.PermanentBonusPerkPoints;
			foreach (int i in SpellDataBase.spellDictionary.Keys)
			{
				SpellDataBase.spellDictionary[i].Bought = false;
			}
			for (int i = 0; i < SpellCaster.SpellCount; i++)
			{
				SpellCaster.instance.SetSpell(i);
			}

			for (int i = 0; i < PerkDatabase.perks.Count; i++)
			{
				PerkDatabase.perks[i].isBought = false;
				PerkDatabase.perks[i].isApplied = false;
				PerkDatabase.perks[i].boughtTimes = 0;
			}
			ResetAllStats();
		}

		public static int RangedRepetitions()
		{
			int repeats = 1;
			if (Multishot.IsOn)
			{
				bool b = Stats.i_SoraBracers ? SpellCaster.RemoveStamina(7*Mathf.Pow(Stats.perk_multishotProjectileCount, 1.75f)) : SpellCaster.RemoveStamina(10 * Mathf.Pow(Stats.perk_multishotProjectileCount, 1.75f));
				if (b)
				{
					repeats += Stats.perk_multishotProjectileCount;
					if (Stats.i_SoraBracers)
						repeats += 4;
				}
				else
				{
					Multishot.IsOn = false;
					Multishot.localPlayerInstance.SetActive(false);
				}
			}
			return repeats;
		}
	}
}