﻿using System.Collections.Generic;

using ChampionsOfForest.Effects;

using TheForest.Items.Inventory;
using TheForest.Utils;

using UnityEngine;

namespace ChampionsOfForest.Player
{
	internal class PlayerInventoryMod : PlayerInventory
	{
		//public static Vector3 Rot;
		//public static Vector3 Pos;
		//public static float Sca;
		public static PlayerInventoryMod instance;

		public static InventoryItemView originalPlaneAxe;
		public static Quaternion originalRotation;
		public static Vector3 OriginalOffset;
		public static bool SetupComplete;
		public static GameObject originalPlaneAxeModel = null;
		public static Transform originalParent;
		public static float OriginalTreeDmg;
		public static Mesh noMesh;
		public static Mesh originalMesh;
		//public static TheForest.Items.Item.AnimatorVariables[] originalAnimVars;
		public static Dictionary<ItemDefinition.ItemSubtype, CustomWeapon> customWeapons = new Dictionary<ItemDefinition.ItemSubtype, CustomWeapon>();
		public static ItemDefinition.ItemSubtype ToEquipWeaponType = ItemDefinition.ItemSubtype.None;
		public static ItemDefinition.ItemSubtype EquippedModel = ItemDefinition.ItemSubtype.None;
		public void GetRightHand()
		{
			ModReferences.rightHandTransform = this._itemViews[64]._heldWeaponInfo.transform.parent.gameObject.transform.parent.transform;
		}
		public void SetupCOTF()
		{
			instance = this;

				customWeapons.Clear();
				originalPlaneAxe = this._itemViews[64];
				originalPlaneAxeModel = this._itemViews[64]._heldWeaponInfo.transform.parent.GetChild(2).gameObject;
				originalRotation = originalPlaneAxeModel.transform.localRotation;
				OriginalOffset = originalPlaneAxeModel.transform.localPosition;
				originalParent = originalPlaneAxeModel.transform.parent;
				OriginalTreeDmg = this._itemViews[64]._heldWeaponInfo.treeDamage;
				originalMesh = originalPlaneAxeModel.GetComponent<MeshFilter>().mesh;
				noMesh = new Mesh();
			
				CreateCustomWeapons();
				SetupComplete = true;
		}

		[ModAPI.Attributes.Priority(1000)]
		protected override bool Equip(InventoryItemView itemView, bool pickedUpFromWorld)
		{
			COTFEvents.Instance.OnWeaponEquip.Invoke();
			Spells.ActiveSpellManager.Instance.OnWeaponEquipped();
			if (!ModSettings.IsDedicated)
			{
				if (GreatBow.instance != null)
					GreatBow.instance.SetActive(false);
				if (ToEquipWeaponType == ItemDefinition.ItemSubtype.None)
				{
					foreach (CustomWeapon item in customWeapons.Values)
					{
						item.obj.SetActive(false);
						item.objectToHide?.SetActive(true);
					}
				}
				if (itemView != null)
				{
					if (EquippedModel != ItemDefinition.ItemSubtype.None)
					{
						customWeapons[EquippedModel].objectToHide?.SetActive(true);
					}
					
					EquippedModel = ItemDefinition.ItemSubtype.None;

					//Send network event to display a custom weapon for other players
					if (BoltNetwork.isRunning && ToEquipWeaponType != ItemDefinition.ItemSubtype.None)
					{
						using (System.IO.MemoryStream answerStream = new System.IO.MemoryStream())
						{
							using (System.IO.BinaryWriter w = new System.IO.BinaryWriter(answerStream))
							{
								w.Write(28);
								w.Write(ModReferences.ThisPlayerID);
								w.Write((int)ToEquipWeaponType);
								w.Close();
							}
							Network.NetworkManager.SendLine(answerStream.ToArray(), Network.NetworkManager.Target.Others);
							answerStream.Close();
						}
					}


					if (itemView.gameObject.name == "axePlane_Inv")
					{

						if (ToEquipWeaponType != ItemDefinition.ItemSubtype.None)
						{
							try
							{
								foreach (CustomWeapon item in customWeapons.Values)
								{
									item.obj.SetActive(false);
								}
								CustomWeapon cw = customWeapons[ToEquipWeaponType];
								cw.obj.SetActive(true);
								itemView._heldWeaponInfo.weaponSpeed = itemView._heldWeaponInfo.baseWeaponSpeed * cw.swingspeed;
								itemView._heldWeaponInfo.tiredSpeed = itemView._heldWeaponInfo.baseTiredSpeed * cw.tiredswingspeed;
								itemView._heldWeaponInfo.smashDamage = cw.smashDamage;
								itemView._heldWeaponInfo.weaponDamage = cw.damage;
								itemView._heldWeaponInfo.treeDamage = cw.treeDamage;
								itemView._heldWeaponInfo.weaponRange = cw.ColliderScale * 3;
								itemView._heldWeaponInfo.staminaDrain = cw.staminaDrain;
								itemView._heldWeaponInfo.noTreeCut = cw.blockTreeCut;
								itemView._heldWeaponInfo.spear = cw.spearType;
								itemView._heldWeaponInfo.transform.localScale = Vector3.one * cw.ColliderScale;
								cw.objectToHide?.SetActive(false);
								originalPlaneAxeModel.GetComponent<MeshFilter>().mesh = noMesh;
							}
							catch (System.Exception exc)
							{
								ModAPI.Log.Write("Error with EQUIPPING custom weaponry " + exc.ToString());
							}
							EquippedModel = ToEquipWeaponType;
						}
						else
							//equip the base plane axe
						{
							itemView._heldWeaponInfo.transform.parent.GetChild(2).gameObject.SetActive(true);
							foreach (CustomWeapon item in customWeapons.Values)
							{
								item.obj.SetActive(false);
							}
							itemView._heldWeaponInfo.weaponSpeed = itemView._heldWeaponInfo.baseWeaponSpeed;
							itemView._heldWeaponInfo.tiredSpeed = itemView._heldWeaponInfo.baseTiredSpeed;
							itemView._heldWeaponInfo.smashDamage = itemView._heldWeaponInfo.baseSmashDamage;
							itemView._heldWeaponInfo.weaponDamage = itemView._heldWeaponInfo.baseWeaponDamage;
							itemView._heldWeaponInfo.treeDamage = 1;
							itemView._heldWeaponInfo.weaponRange = itemView._heldWeaponInfo.baseWeaponRange;
							itemView._heldWeaponInfo.staminaDrain = itemView._heldWeaponInfo.baseStaminaDrain;
							itemView._heldWeaponInfo.noTreeCut = false;
							itemView._heldWeaponInfo.transform.localScale = Vector3.one * 0.6f;
							originalPlaneAxeModel.GetComponent<MeshFilter>().mesh = originalMesh;
						}
					}
					else if (itemView == _itemViews[158])	//spear
					{
						if (ToEquipWeaponType == ItemDefinition.ItemSubtype.Polearm)
						{
							EquippedModel = ToEquipWeaponType;
							try
							{
								foreach (CustomWeapon item in customWeapons.Values)
								{
									item.obj.SetActive(false);
								}
								CustomWeapon cw = customWeapons[ToEquipWeaponType];
								cw.obj.SetActive(true);
								itemView._heldWeaponInfo.weaponSpeed = itemView._heldWeaponInfo.baseWeaponSpeed * cw.swingspeed;
								itemView._heldWeaponInfo.tiredSpeed = itemView._heldWeaponInfo.baseTiredSpeed * cw.tiredswingspeed;
								itemView._heldWeaponInfo.smashDamage = cw.smashDamage;
								itemView._heldWeaponInfo.weaponDamage = cw.damage;
								itemView._heldWeaponInfo.treeDamage = cw.treeDamage;
								itemView._heldWeaponInfo.weaponRange = cw.ColliderScale * 3;
								itemView._heldWeaponInfo.staminaDrain = cw.staminaDrain;
								itemView._heldWeaponInfo.noTreeCut = cw.blockTreeCut;
								itemView._heldWeaponInfo.spear = cw.spearType;
								cw.objectToHide.GetComponent<Renderer>().enabled = false;
							}
							catch (System.Exception exc)
							{
								ModAPI.Log.Write("Error with EQUIPPING custom weaponry " + exc.ToString());
							}
						}
						else
						{
							foreach (CustomWeapon item in customWeapons.Values)
							{
								item.obj.SetActive(false);
							}
							itemView._heldWeaponInfo.weaponSpeed = itemView._heldWeaponInfo.baseWeaponSpeed;
							itemView._heldWeaponInfo.tiredSpeed = itemView._heldWeaponInfo.baseTiredSpeed;
							itemView._heldWeaponInfo.smashDamage = itemView._heldWeaponInfo.baseSmashDamage;
							itemView._heldWeaponInfo.weaponDamage = itemView._heldWeaponInfo.baseWeaponDamage;
							itemView._heldWeaponInfo.weaponRange = itemView._heldWeaponInfo.baseWeaponRange;
							itemView._heldWeaponInfo.staminaDrain = itemView._heldWeaponInfo.baseStaminaDrain;
							itemView._heldWeaponInfo.noTreeCut = false;
							itemView._heldWeaponInfo.spear = true;
							customWeapons[ItemDefinition.ItemSubtype.Polearm].objectToHide.GetComponent<Renderer>().enabled = true;
						}
					}
				}
			}
			return base.Equip(itemView, pickedUpFromWorld);
		}

		protected override void ThrowProjectile()
		{
			if (EquippedModel == ItemDefinition.ItemSubtype.Polearm)
				return;
			this._isThrowing = false;
			InventoryItemView inventoryItemView = this._equipmentSlots[0];
			if (inventoryItemView != null)
			{
				TheForest.Items.Item itemCache = inventoryItemView.ItemCache;
				bool flag = itemCache._maxAmount < 0;
				GameObject gameObject = Instantiate((!this.UseAltWorldPrefab) ? inventoryItemView._worldPrefab : inventoryItemView._altWorldPrefab, inventoryItemView._held.transform.position, inventoryItemView._held.transform.rotation);
				gameObject.transform.localScale *= ModdedPlayer.Stats.projectileSize;
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				Collider component2 = gameObject.GetComponent<Collider>();
				if (BoltNetwork.isRunning)
				{
					BoltEntity component3 = gameObject.GetComponent<BoltEntity>();
					if (component3 != null)
					{
						BoltNetwork.Attach(gameObject);
					}
				}
				Vector3 force = ((float)itemCache._projectileThrowForceRange) * ModdedPlayer.Stats.projectileSpeed* (0.016666f / Time.fixedDeltaTime) * LocalPlayer.MainCamTr.forward;
				if (ModdedPlayer.Stats.spell_bia_AccumulatedDamage > 0)
				{
					gameObject.transform.localScale *= 1.5f;
					force *= 2f;
					component.useGravity = false;
					
					//gameObject.GetComponent<Renderer>().material = bloodInfusedMaterial;
					var trail = gameObject.AddComponent<TrailRenderer>();
					trail.widthCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 1f, 0f, 0f), new Keyframe(0.5f, 1f, 0f, 0f), new Keyframe(1f, 0.006248474f, 0f, 0f), });
					trail.material = ModReferences.BloodMaterial;
					trail.widthMultiplier = 0.85f;
					trail.time = 2f;
					trail.autodestruct = false;
				}
				if (inventoryItemView.ActiveBonus == TheForest.Items.Craft.WeaponStatUpgrade.Types.StickyProjectile)
				{
					if (component2 != null)
					{
						gameObject.AddComponent<StickyBomb>();
						SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
						sphereCollider.isTrigger = true;
						sphereCollider.radius = 0.8f;
					}
					else
					{
						Collider componentInChildren = gameObject.GetComponentInChildren<Collider>();
						if (componentInChildren != null)
						{
							componentInChildren.gameObject.AddComponent<StickyBomb>();
						}
					}
				}

				component.AddForce(force);

				inventoryItemView._held.SendMessage("OnProjectileThrown", gameObject, SendMessageOptions.DontRequireReceiver);
				inventoryItemView.ActiveBonus = (TheForest.Items.Craft.WeaponStatUpgrade.Types)(-1);
				if (!ForestVR.Enabled)
				{
					if (itemCache._rangedStyle == TheForest.Items.Item.RangedStyle.Bell)
					{
						component.AddTorque((float)itemCache._projectileThrowTorqueRange * base.transform.forward);
					}
					else if (itemCache._rangedStyle == TheForest.Items.Item.RangedStyle.Forward)
					{
						component.AddTorque((float)itemCache._projectileThrowTorqueRange * LocalPlayer.MainCamTr.forward);
					}
				}
				if (base.transform.GetComponent<Collider>().enabled && component2 && component2.enabled)
				{
					Physics.IgnoreCollision(base.transform.GetComponent<Collider>(), component2);
				}
				if (!flag)
				{
					this.MemorizeOverrideItem(TheForest.Items.Item.EquipmentSlot.RightHand);
				}
				bool equipPrevious = true;
				if (LocalPlayer.FpCharacter.Sitting || LocalPlayer.AnimControl.onRope || LocalPlayer.FpCharacter.SailingRaft)
				{
					equipPrevious = false;
				}
				if (ModdedPlayer.Stats.perk_projectileNoConsumeChance < Random.value)
					this.UnequipItemAtSlot(itemCache._equipmentSlot, false, false, equipPrevious);
				LocalPlayer.Sfx.PlayThrow();
			}
		}

		public override void Attack()
		{
			if (ModSettings.IsDedicated)
			{
				return;
			}

			if (!IsRightHandEmpty() && !_isThrowing && !IsReloading && !blockRangedAttack && !IsSlotLocked(TheForest.Items.Item.EquipmentSlot.RightHand) && !LocalPlayer.Inventory.HasInSlot(TheForest.Items.Item.EquipmentSlot.RightHand, LocalPlayer.AnimControl._slingShotId))
			{
				if (EquippedModel != ItemDefinition.ItemSubtype.None && customWeapons.ContainsKey(EquippedModel))
				{
					customWeapons[EquippedModel].EnableTrail();
				}
				if (ModdedPlayer.Stats.i_DeathPact_Enabled.value)
				{
					LocalPlayer.Stats.Health -= ModdedPlayer.Stats.TotalMaxHealth * 0.06f;
					LocalPlayer.Stats.Health = Mathf.Max(1, LocalPlayer.Stats.Health);
				}
			}
			base.Attack();
		}

		public override void AddMaxAmountBonus(int itemId, int amount)
		{
			if (ModSettings.IsDedicated)
			{
				return;
			}

			base.AddMaxAmountBonus(itemId, amount);
		}

		public override void SetMaxAmountBonus(int itemId, int amount)
		{
			base.SetMaxAmountBonus(itemId, amount);
			if (ModdedPlayer.instance.ExtraCarryingCapactity.ContainsKey(itemId))
			{
				ModdedPlayer.instance.ExtraCarryingCapactity[itemId].NewApply();
			}
		}

		public override void StashEquipedWeapon(bool equipPrevious)
		{
			if (GreatBow.instance != null)
				GreatBow.instance.SetActive(false);
			base.StashEquipedWeapon(equipPrevious);
		}

		public override void HideRightHand(bool hideOnly)
		{
			if (GreatBow.instance != null)
				GreatBow.instance.SetActive(false);
			base.HideRightHand(hideOnly);
		}

		public override void Start()
		{
			SetupCOTF();
			InitializeGreatBow();
			base.Start();

		}

		protected override void FireRangedWeapon()
		{
			var cache = _equipmentSlots[0].ItemCache;
			if (EquippedModel == ItemDefinition.ItemSubtype.Polearm)
				return;
			bool noconsume = ModdedPlayer.Stats.perk_projectileNoConsumeChance >= 0 && Random.value < ModdedPlayer.Stats.perk_projectileNoConsumeChance;
			noconsume = noconsume || cache._maxAmount < 0 || RemoveItem(cache._ammoItemId, 1, false, true);
			if (noconsume && cache._ammoItemId == 231)
			{
				AddItem(231);
			}
			Multishot.Fired();
			COTFEvents.Instance.OnAttackRanged.Invoke();
			this.StartCoroutine(RCoroutines.i.AsyncRangedFire(this, _weaponChargeStartTime, _equipmentSlots[0], _inventoryItemViewsCache[cache._ammoItemId][0], noconsume));

			_weaponChargeStartTime = 0f;
			float duration = (!noconsume) ? cache._reloadDuration : cache._dryFireReloadDuration;
			if (GreatBow.isEnabled)
				duration *= 10;
			SetReloadDelay(duration);
			_isThrowing = false;
		}

		public void InitializeGreatBow()
		{
			var go = _itemViews[48]._held;
			go.AddComponent<CustomBowBase>();
		}

		public void CreateCustomWeapons()
		{
			//long sword
			new CustomWeapon(ItemDefinition.ItemSubtype.LongSword,
					51,
					BuilderCore.Core.CreateMaterial(
						new BuilderCore.BuildingData()
						{
							MainTexture = Res.ResourceLoader.instance.LoadedTextures[60],
							Metalic = 0.86f,
							Smoothness = 0.66f
						}
						),
					new Vector3(0.2f - 0.04347827f, -1.5f + 0.173913f, 0.3f - 0.05797101f),
					new Vector3(0, -90, 0),
					new Vector3(-0.2f, -2.3f, 0),
					1.1f, 0.9f, 20, 25, 0.4f, 0.2f, 30, false, 3);

			//great sword
			new CustomWeapon(ItemDefinition.ItemSubtype.GreatSword,
				52,
				BuilderCore.Core.CreateMaterial(
					new BuilderCore.BuildingData()
					{
						OcclusionStrenght = 0.75f,
						Smoothness = 0.5f,
						Metalic = 0.5f,
						MainTexture = Res.ResourceLoader.instance.LoadedTextures[61],
						EmissionMap = Res.ResourceLoader.instance.LoadedTextures[62],
						BumpMap = Res.ResourceLoader.instance.LoadedTextures[64],
						HeightMap = Res.ResourceLoader.instance.LoadedTextures[65],
						Occlusion = Res.ResourceLoader.instance.LoadedTextures[66]
					}
					),
				new Vector3(0.15f - 0.03623189f, -2.13f - 0.0572464f, 0.19f - 0.1014493f),
				new Vector3(180, 180, 90),
				new Vector3(0, 0, -3.5f),
				1.6f, 1f, 20, 30, 0.00f, 0.00f, 60, false, 10);

			//hammer
			new CustomWeapon(ItemDefinition.ItemSubtype.Hammer,
				   108,
				   BuilderCore.Core.CreateMaterial(
					   new BuilderCore.BuildingData()
					   {
						   Metalic = 0.86f,
						   Smoothness = 0.66f,
						   MainColor = new Color(0.7f, 0.7f, 0.76f),
					   }
					   ),
				   new Vector3(0, 0, 0),
				   new Vector3(0, 0, 90),
				   new Vector3(0, 0, -2f),
				   1.2f, 1f, 75, 250, 0.1f, 0f, 300, false, 600);

			var Axe_PlaneAxe = Instantiate(originalPlaneAxeModel, originalParent);
			var Axe_Renderer = Axe_PlaneAxe.GetComponent<Renderer>();
			if (Axe_Renderer != null)
				Destroy(Axe_Renderer);
			var Axe_Filter = Axe_PlaneAxe.GetComponent<MeshFilter>();
			if (Axe_Filter != null)
				Destroy(Axe_Filter);

			Vector3 AxeOffset = new Vector3(0.15f - 0.03623189f, -2.13f - 0.0572464f, 0.19f - 0.1014493f);// new Vector3(0.179f,-0.31f,0.026f);
			Axe_PlaneAxe.transform.localScale = Vector3.one;
			Vector3 AxeRotation = new Vector3(180, 180, 90);
			Axe_PlaneAxe.transform.position += AxeOffset;
			GameObject axeObject = Instantiate(Res.ResourceLoader.GetAssetBundle(2001).LoadAsset<GameObject>("AxePrefab.prefab"), Axe_PlaneAxe.transform);
			Axe_PlaneAxe.transform.localPosition = OriginalOffset;
			Axe_PlaneAxe.transform.localRotation = originalRotation;
			Axe_PlaneAxe.transform.Rotate(AxeRotation, Space.Self);
			axeObject.transform.localScale = Vector3.one;
			var AxeTrail = axeObject.transform.GetChild(0).GetComponent<TrailRenderer>();
			AxeTrail.transform.localPosition = new Vector3(0, -0.3f, 0);
			new CustomWeapon(ItemDefinition.ItemSubtype.Axe, Axe_PlaneAxe, AxeTrail, AxeOffset, AxeRotation, 1)
			{
				blockTreeCut = false,
				damage = 10,
				smashDamage = 25,
				staminaDrain = 4,
				swingspeed = 50,
				treeDamage = 10,
				tiredswingspeed = 50,
				ColliderScale = 0.5f
			};
			AxeTrail.gameObject.SetActive(false);
			CreateCustomWeapons_Spears();
		}

		public void CreateCustomWeapons_Spears()
		{
			if (customWeapons.ContainsKey(ItemDefinition.ItemSubtype.Polearm) && customWeapons[ItemDefinition.ItemSubtype.Polearm].obj != null)
			{
				customWeapons.Remove(ItemDefinition.ItemSubtype.Polearm);
			}
			var original = _itemViews[158]._held;
			//original.gameObject.SetActive(true);
			var assets = Res.ResourceLoader.GetAssetBundle(2005).LoadAssetWithSubAssets("assets/PolearmPrefab.prefab");
			foreach (var asset in assets)
			{
				ModAPI.Console.Write(asset.name);
				if (asset.name == "PolearmPrefab")
				{
					var clone = new GameObject();
					clone.transform.SetParent(original.transform);
					clone.transform.localPosition = Vector3.zero;
					clone.transform.localRotation = Quaternion.identity;

					var secondChild = original.transform.GetChild(1);   //second child contains the og model of the spear
					GameObject modelClone =Instantiate( (GameObject)asset, LocalPlayer.Transform.position, Quaternion.identity, clone.transform);
					modelClone.transform.localPosition = secondChild.localPosition;
					modelClone.transform.localRotation = secondChild.localRotation;
					modelClone.transform.Rotate(new Vector3(90, 0, 0));
					modelClone.transform.localScale *= 0.7f / 3;
					var polearm = new CustomWeapon(ItemDefinition.ItemSubtype.Polearm,
						clone,
						Vector3.zero,
						new Vector3(0, 0, 0),
						2)
					{
						spearType = true,
						tiredswingspeed = 20,
						damage = 20f,
						staminaDrain = 14,
						blockTreeCut = false,
						smashDamage = 60f,
						swingspeed = 50,
						ColliderScale = 1f,
						treeDamage = 1,
						objectToHide = secondChild.gameObject
					};
					clone.SetActive(false);
					return;
				}
			}
		}



	}
}