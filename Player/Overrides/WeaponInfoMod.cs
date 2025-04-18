﻿using Bolt;
using ChampionsOfForest.Effects;
using ChampionsOfForest.Network;
using TheForest.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ChampionsOfForest.Player
{
	public class WeaponInfoMod : weaponInfo
	{
		public static bool AlwaysIgnite = false;
		protected override void Start()
		{
			base.Start();
			var rb = animator.gameObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			}
		}
		protected override void Update()
		{
			if (mainTriggerScript != null)
			{
				if (PlayerInventoryMod.EquippedModel != ItemDefinition.ItemSubtype.None && PlayerInventoryMod.EquippedModel != ItemDefinition.ItemSubtype.Greatbow)
				{
					CustomWeapon cw = PlayerInventoryMod.customWeapons[PlayerInventoryMod.EquippedModel];
					setup.pmStamina.FsmVariables.GetFsmFloat("notTiredSpeed").Value = animSpeed * cw.swingspeed;
					setup.pmStamina.FsmVariables.GetFsmFloat("staminaDrain").Value = staminaDrain * -1f * ModdedPlayer.Stats.attackStaminaCost;
					setup.pmStamina.FsmVariables.GetFsmFloat("tiredSpeed").Value = animTiredSpeed * cw.tiredswingspeed;
					setup.pmStamina.FsmVariables.GetFsmFloat("staminaDrain").Value = staminaDrain * -1f * (ModdedPlayer.Stats.attackStaminaCost);
					LocalPlayer.Stats.blockDamagePercent = /*ModdedPlayer.Stats.block **/ blockDamagePercent;
				}
				else
				{
					setup.pmStamina.FsmVariables.GetFsmFloat("staminaDrain").Value = staminaDrain * -1f * (ModdedPlayer.Stats.attackStaminaCost);
					setup.pmStamina.FsmVariables.GetFsmFloat("staminaDrain").Value = staminaDrain * -1f * (ModdedPlayer.Stats.attackStaminaCost);
					LocalPlayer.Stats.blockDamagePercent = /*ModdedPlayer.Stats.block **/ blockDamagePercent;
				}
				//float ats = ModdedPlayer.instance.AttackSpeed;
				//if (GreatBow.isEnabled) ats /= 10f;
				//if (LocalPlayer.Stats.Stamina > 4)
				//{
				//    animator.speed = ats;
				//}
				//else
				//{
				//    animator.speed =Mathf.Min( 0.5f, ats/2);

				//}
			}

			base.Update();
		}

		protected override void setupMainTrigger()
		{
			if ((bool)mainTriggerScript)
			{
				mainTriggerScript.stick = stick;
				mainTriggerScript.axe = axe;
				mainTriggerScript.rock = rock;
				mainTriggerScript.fireStick = fireStick;
				mainTriggerScript.spear = spear;
				mainTriggerScript.chainSaw = chainSaw;
				mainTriggerScript.machete = machete;
				mainTriggerScript.repairTool = repairTool;
				mainTriggerScript.weaponDamage = WeaponDamage;
				mainTriggerScript.smashDamage = smashDamage;
				mainTriggerScript.smallAxe = smallAxe;
				if (shell)
				{
					mainTriggerScript.spear = true;
				}
				else
				{
					mainTriggerScript.shell = false;
				}
				if (weaponRange == 0f)
				{
					mainTriggerScript.hitTriggerRange.transform.localScale = new Vector3(1f, 1f, 1f * ModdedPlayer.Stats.weaponRange);
				}
				else if (BoltNetwork.isClient)
				{
					mainTriggerScript.hitTriggerRange.transform.localScale = new Vector3(1f, 1f, Mathf.Clamp(weaponRange * ModdedPlayer.Stats.weaponRange, 1f, weaponRange * ModdedPlayer.Stats.weaponRange));
				}
				else
				{
					mainTriggerScript.hitTriggerRange.transform.localScale = new Vector3(1f, 1f, weaponRange * ModdedPlayer.Stats.weaponRange);
				}
			}
		}


		private void AfterHit()
		{
			if (smashSoundEnabled)
			{
				smashSoundEnabled = false;
				base.Invoke("EnableSmashSound", 0.3f);
				PlayEvent(smashHitEvent, null);
				if (BoltNetwork.isRunning)
				{
					FmodOneShot fmodOneShot3 = FmodOneShot.Create(GlobalTargets.Others, ReliabilityModes.Unreliable);
					fmodOneShot3.EventPath = CoopAudioEventDb.FindId(smashHitEvent);
					fmodOneShot3.Position = base.transform.position;
					fmodOneShot3.Send();
				}
			}
			FMODCommon.PlayOneshotNetworked(currentWeaponScript.fleshHitEvent, weaponAudio.transform, FMODCommon.NetworkRole.Any);

		}
		private bool COTFHit(Collider other)
		{
			//----------------HIT DAMAGE
			float outputdmg = 0;
			if (animControl.smashBool)
				outputdmg = smashDamage;
			else
				outputdmg = weaponDamage;
			outputdmg += ModdedPlayer.Stats.baseMeleeDamage + SpellActions.GetParryCounterStrikeDmg();
			float critDmg = ModdedPlayer.Stats.RandomCritDamage;
			outputdmg *= critDmg * ModdedPlayer.Stats.MeleeDamageMult;

			if (hitReactions.kingHitBool || fsmHeavyAttackBool.Value)
				outputdmg *= ModdedPlayer.Stats.heavyAttackDmg * 3;
			if (animControl.smashBool)
				outputdmg *= ModdedPlayer.Stats.smashDamage;

			if (ModdedPlayer.Stats.perk_danceOfFiregod && BlackFlame.IsOn)
				outputdmg *= 1 + LocalPlayer.Rigidbody.velocity.magnitude*1.1f;
			if (outputdmg < 0)
				outputdmg = -outputdmg;
			//----------------HIT DAMAGE

			if (other.CompareTag("enemyCollide") || other.CompareTag("enemyRoot"))
			{
				
				ModdedPlayer.instance.OnHit();
				ModdedPlayer.instance.OnHit_Melee(other.transform);
				if (GameSetup.IsMpClient)
				{
					BoltEntity entity = other.GetComponentInParent<BoltEntity>();
					if (entity != null)
					{
						{
							var eventContext = new COTFEvents.HitOtherParams(outputdmg, critDmg != 1, entity, this);
							COTFEvents.Instance.OnHitEnemy.Invoke(eventContext);
							COTFEvents.Instance.OnHitMelee.Invoke(eventContext);
						}
						var phe = PlayerHitEnemy.Create(GlobalTargets.OnlyServer);
						phe.Target = entity;
						phe.getAttackerType = 4 + DamageUtils.CONVERTEDFLOATattackerType;
						phe.Hit = DamageUtils.GetSendableDamage(outputdmg);
						phe.HitAxe = axe;
						phe.hitFallDown = fsmHeavyAttackBool.Value && axe;
						phe.getAttackDirection = animator.GetInteger("hitDirection");
						phe.takeDamage = 1;
						phe.getCombo = 3;
						phe.Burn = (fireStick && Random.value > 0.8f) || AlwaysIgnite || BlackFlame.IsOn;
						if (phe.Burn)
							COTFEvents.Instance.OnIgniteMelee.Invoke();
						phe.explosion = fsmJumpAttackBool.Value && LocalPlayer.FpCharacter.jumpingTimer > 1.2f && !chainSaw;
						phe.Send();
						ModdedPlayer.instance.OnHitEffectsClient(entity, outputdmg);

						ulong packed = entity.networkId.PackedValue;
						if (ModdedPlayer.Stats.TotalMeleeArmorPiercing > 0)
							EnemyProgression.ReduceArmor(entity, ModdedPlayer.Stats.TotalMeleeArmorPiercing);
						if ((hitReactions.kingHitBool || fsmHeavyAttackBool.Value) && ModdedPlayer.Stats.perk_chargedAtkKnockback)
						{	using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
							{
								using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(stream))
								{
									Vector3 dir = other.transform.position - LocalPlayer.Transform.position;
									dir.y = 0;
									w.Write(43);
									w.Write(packed);
									w.Write(dir.x);
									w.Write(dir.y);
									w.Write(dir.z);
									w.Write(6f);
									w.Close();
								}
								NetworkManager.SendLine(stream.ToArray(), NetworkManager.Target.OnlyServer);

								stream.Close();
							}
						}
						if (BlackFlame.IsOn)
						{
							using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
							{
								using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(stream))
								{
									w.Write(27);
									w.Write(packed);
									w.Write(BlackFlame.FireDamageBonus);
									w.Write(20f);
									w.Write(1);
									w.Close();
								}
								NetworkManager.SendLine(stream.ToArray(), NetworkManager.Target.OnlyServer);

								stream.Close();
							}
							if (BlackFlame.GiveAfterburn && Random.value <= BlackFlame.afterburn_chance)
							{
								int id = 121 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
								using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
								{
									using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
									{
										w.Write(34);
										w.Write(packed);
										w.Write(id);
										w.Write(BlackFlame.afterburn_debuff_amount);
										w.Write(BlackFlame.afterburn_duration);
										w.Close();
									}
									AsyncHit.SendCommandDelayed(1, answerStream.ToArray(), NetworkManager.Target.OnlyServer);
									answerStream.Close();
								}
							}
						}
						if (ModdedPlayer.Stats.perk_fireDmgIncreaseOnHit)
						{
							int myID = 2000 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
							float fireDmg = 1 + ModdedPlayer.Stats.baseSpellDamage / 3;
							fireDmg *= ModdedPlayer.Stats.TotalMagicDamageMultiplier;
							fireDmg *= ModdedPlayer.Stats.fireDamage + 1;
							fireDmg *= 0.35f;
							using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
							{
								using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
								{
									w.Write(27);
									w.Write(packed);
									w.Write(fireDmg);
									w.Write(15);
									w.Write(myID);
									w.Close();
								}
								AsyncHit.SendCommandDelayed(2, answerStream.ToArray(), NetworkManager.Target.OnlyServer);
								answerStream.Close();
							}
						}
						if (ModdedPlayer.Stats.i_HammerStun && PlayerInventoryMod.EquippedModel == ItemDefinition.ItemSubtype.Hammer)
						{
							using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
							{
								using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
								{
									w.Write(22);
									w.Write(packed);
									w.Write(ModdedPlayer.Stats.i_HammerStunAmount);
									w.Write(ModdedPlayer.Stats.i_HammerStunDuration);
									w.Write(40);
									w.Close();
								}
								AsyncHit.SendCommandDelayed(2, answerStream.ToArray(), NetworkManager.Target.OnlyServer);
								answerStream.Close();
							}
						}
						SpellActions.Bash(packed, outputdmg);

						AfterHit();
						return true;
					}

				}
				else        //is singleplayer or host
				{
					if (EnemyManager.enemyByTransform.ContainsKey(other.transform.root) )
					{
						var progression = EnemyManager.enemyByTransform[other.transform.root];
						{
							var eventContext = new COTFEvents.HitOtherParams(outputdmg, critDmg != 1, progression, this);
							COTFEvents.Instance.OnHitEnemy.Invoke(eventContext);
							COTFEvents.Instance.OnHitMelee.Invoke(eventContext);
						}



						progression.HitPhysical(outputdmg);
						ModdedPlayer.instance.OnHitEffectsHost(progression, outputdmg);

						progression.HealthScript.getCombo(3);
						var hitDirection = animator.GetInteger("hitDirection");
						progression.HealthScript.getAttackDirection(hitDirection);
						progression.setup.hitReceiver.getAttackDirection(hitDirection);
						progression.setup.hitReceiver.getCombo(3);
						if (fsmJumpAttackBool.Value && LocalPlayer.FpCharacter.jumpingTimer > 1.2f && !chainSaw)
						{
							progression.HealthScript.Explosion(-1f);
						}


						if (ModdedPlayer.Stats.TotalMeleeArmorPiercing > 0)
							progression.ReduceArmor(ModdedPlayer.Stats.TotalMeleeArmorPiercing);

						if ((hitReactions.kingHitBool || fsmHeavyAttackBool.Value) && ModdedPlayer.Stats.perk_chargedAtkKnockback)
						{
							Vector3 dir = other.transform.position - LocalPlayer.Transform.position;
							progression.AddKnockbackByDistance(dir, 6);
						}

						if (BlackFlame.IsOn)
						{
							progression.FireDebuff(40, BlackFlame.FireDamageBonus, 20);
							if (BlackFlame.GiveAfterburn && Random.value <=BlackFlame.afterburn_chance)
								progression.DmgTakenDebuff(120, BlackFlame.afterburn_debuff_amount, BlackFlame.afterburn_duration);

						}
						if (ModdedPlayer.Stats.perk_fireDmgIncreaseOnHit)
						{
							int myID = 2000 + ModReferences.Players.IndexOf(LocalPlayer.GameObject);
							float fireDmg = 1 + ModdedPlayer.Stats.baseSpellDamage / 3;
							fireDmg *= ModdedPlayer.Stats.TotalMagicDamageMultiplier;
							fireDmg *= ModdedPlayer.Stats.fireDamage + 1;
							fireDmg *= 0.35f;
							progression.FireDebuff(2000, fireDmg, 14);

						}
						if (ModdedPlayer.Stats.i_HammerStun && PlayerInventoryMod.EquippedModel == ItemDefinition.ItemSubtype.Hammer)
							progression.Slow(40, ModdedPlayer.Stats.i_HammerStunAmount, ModdedPlayer.Stats.i_HammerStunDuration);

						SpellActions.Bash(progression, outputdmg);


						if ((fireStick && Random.value > 0.8f) || AlwaysIgnite || BlackFlame.IsOn)
						{
							COTFEvents.Instance.OnIgniteMelee.Invoke();
							progression.HealthScript.Burn();
						}

						AfterHit();
						return true;
					}
				}
			}
			else if (other.gameObject.CompareTag("PlayerNet") && (mainTrigger || (!mainTrigger && (animControl.smashBool || chainSaw))))
			{
				if (ModSettings.FriendlyFire)
				{
					BoltEntity component3 = other.GetComponent<BoltEntity>();
					BoltEntity component4 = base.GetComponent<BoltEntity>();
					if (!ReferenceEquals(component3, component4) && lastPlayerHit + 0.2f < Time.time)
					{
						other.transform.root.SendMessage("getClientHitDirection", animator.GetInteger("hitDirection"), SendMessageOptions.DontRequireReceiver);
						other.transform.root.SendMessage("StartPrediction", SendMessageOptions.DontRequireReceiver);
						lastPlayerHit = Time.time;
						if (BoltNetwork.isRunning)
						{
							ModdedPlayer.instance.OnHit();
							ModdedPlayer.instance.OnHit_Melee(other.transform);

							DamageUtils.ReduceDamageToSendOverNet(2f * (WeaponDamage + ModdedPlayer.Stats.baseMeleeDamage + SpellActions.GetParryCounterStrikeDmg()) * ModdedPlayer.Stats.MeleeDamageMult * ModdedPlayer.Stats.RandomCritDamage, out int dmg, out int repetitions);

							HitPlayer hitPlayer = HitPlayer.Create(component3, EntityTargets.Everyone);
							hitPlayer.damage = dmg;
							for (int i = 0; i < repetitions; i++)
								hitPlayer.Send();
						}
					}

					AfterHit();
				}
				return true;
			}
			return false;
		}
		protected override void OnTriggerEnter(Collider other)
		{
			if (COTFHit(other))
				return;
			base.OnTriggerEnter(other);
		}
	}
}