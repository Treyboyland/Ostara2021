using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnvironmentColorControl : MonoBehaviour
{
    [SerializeField]
    Gradient cameraColor;

    [SerializeField]
    Gradient particleColor;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    ParticleSystem clouds;

    float maxGrowth = 0;

    float currentGrowth = 0;

    List<Ground> grounds;

    ParticleSystem.Particle[] cloudParticles;

    // Start is called before the first frame update
    void Start()
    {
        cloudParticles = new ParticleSystem.Particle[clouds.main.maxParticles];
        CalculateMaxGrowth();
    }

    private void Update()
    {
        SetColors();
    }

    void CalculateMaxGrowth()
    {
        grounds = FindObjectsOfType<Ground>().ToList();
        maxGrowth = grounds.Count;
    }

    void SetColors()
    {
        float normalizedGrowth = 0;
        foreach (var ground in grounds)
        {
            normalizedGrowth += ground.GrowthNormalized;
        }
        normalizedGrowth /= grounds.Count;
        normalizedGrowth = 1 - normalizedGrowth; //Because I was a dingus and made the 0 values the max growth values
        //Debug.LogWarning(normalizedGrowth);
        mainCamera.backgroundColor = cameraColor.Evaluate(normalizedGrowth);
        var main = clouds.main;
        var color = particleColor.Evaluate(normalizedGrowth);
        main.startColor = particleColor.Evaluate(normalizedGrowth);

        int numParticlesAlive = clouds.GetParticles(cloudParticles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            cloudParticles[i].startColor = color;
        }

        clouds.SetParticles(cloudParticles, numParticlesAlive);
    }
}
