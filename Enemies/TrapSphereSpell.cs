﻿using System.Collections.Generic;
using TheForest.Utils;
using UnityEngine;

namespace ChampionsOfForest.Enemies
{
    public class TrapSphereSpell : MonoBehaviour
    {
        public float Duration;
        public float Radius;
        private float Lifetime;
        private readonly float rotSpeed = 50f;
        private List<Transform> coughtPlayers = new List<Transform>();
        public static GameObject Prefab;

        public static void Create(Vector3 pos, float radius, float duration)
        {
            if (Prefab == null)
            {
                try
                {


                    Prefab = new GameObject("TrapSphere");
                    Prefab.AddComponent<MeshFilter>().mesh = Res.ResourceLoader.instance.LoadedMeshes[68];
                    Prefab.transform.localScale = Vector3.one * radius;
                    MeshRenderer r = Prefab.AddComponent<MeshRenderer>();

                    r.material = BuilderCore.Core.CreateMaterial(new BuilderCore.BuildingData() { MainColor = new Color(1, 0.83f, 0, 0.2f), Metalic = 0f, Smoothness = 0f, renderMode = BuilderCore.BuildingData.RenderMode.Fade });


                }
                catch (System.Exception ex)
                {

                    ModAPI.Log.Write(ex.ToString());
                }
            }
            else
            {
            }
            Prefab.SetActive(true);

            GameObject go = GameObject.Instantiate(Prefab, pos, Quaternion.identity);
            TrapSphereSpell s = go.AddComponent<TrapSphereSpell>();
            s.Radius = radius;
            s.Duration = duration;
            s.Lifetime = 0;
            go.transform.localScale = Vector3.one * radius;


            Prefab.SetActive(false);





        }

        private void Update()
        {
            transform.Rotate((transform.forward + transform.up + Vector3.right) * rotSpeed * Time.deltaTime);
            Lifetime += Time.deltaTime;
            if (Lifetime < Duration)
            {
                if (BoltNetwork.isRunning)
                {

                    foreach (CoopPlayerRemoteSetup item in ModReferences.PlayerRemoteSetups)
                    {
                        if (!coughtPlayers.Contains(item.transform.root))
                        {
                            if ((item.transform.root.position - transform.position).sqrMagnitude < Radius * Radius)
                            {
                                coughtPlayers.Add(item.transform.root);
                            }
                        }
                    }
                }
                else
                {
                    if (coughtPlayers.Count < 1)
                    {
                        if ((LocalPlayer.Transform.root.position - transform.position).sqrMagnitude < Radius * Radius -2)
                        {
                            coughtPlayers.Add(LocalPlayer.Transform.root);
                        }
                    }
                }
                foreach (Transform tr in coughtPlayers)
                {
                    if ((tr.position - transform.position).sqrMagnitude > Radius * Radius)
                    {
                        tr.position = Vector3.MoveTowards(tr.position, transform.position, 40 * Time.deltaTime);
                    }
                }
            }
            else
            {
                transform.localScale -= Vector3.one * Time.deltaTime;
                if (transform.localScale.x < 0.02f)
                {
                    Destroy(gameObject);
                }
            }

        }



    }
}
