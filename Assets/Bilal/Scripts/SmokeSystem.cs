using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSystem : MonoBehaviour
{
    public static bool active;

    public GameObject smokePrefab;
    [Range(0, 0.5f)] public float slipLimit;

    public Transform[] wheelTransforms;
    public WheelCollider[] wheelColliders;
    public GameObject[] smokes;
    public ParticleSystem[] smokeParticles;

    void Start()
    {
        FindValues();
        SpawnSmokes();
    }

    private void Update()
    {
        RunSmokes();
    }

    void SpawnSmokes()
    {
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            smokes[i] = Instantiate(smokePrefab);
            smokeParticles[i] = smokes[i].GetComponent<ParticleSystem>();
            smokes[i].transform.parent = wheelTransforms[i].transform;
            smokes[i].transform.position = wheelTransforms[i].transform.position;
            smokes[i].transform.rotation = Quaternion.identity;
            smokes[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void RunSmokes()
    {
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            if (active)
            {
                if (!smokeParticles[i].isPlaying)
                    smokeParticles[i].Play();
            }
            else
            {
                if (!smokeParticles[i].isStopped)
                    smokeParticles[i].Stop();
            }
        }
    }

    void FindValues()
    {
        smokes = new GameObject[wheelTransforms.Length];
        smokeParticles = new ParticleSystem[wheelTransforms.Length];
    }
}
