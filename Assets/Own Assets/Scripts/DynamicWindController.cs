using System.Collections.Generic;
using UnityEngine;

public class DynamicWindController : MonoBehaviour
{
    [Header("WIND SETTINGS")]

    [Range(0f, 10f)]
    [SerializeField] private float windMovement = 10f;

    [Range(0f, 5f)]
    [SerializeField] private float windDensity = 0.01f;

    [Range(0f, 1f)]
    [SerializeField] private float windStrength = 1f;


    [Header("VEGETATION MATERIALS")]

    [SerializeField]
    private List<Material> windMaterials = new List<Material>();


    [Header("SMOOTHING")]

    [SerializeField]
    private float smoothSpeed = 5f;


    private float targetWindMovement;
    private float targetWindDensity;
    private float targetWindStrength;


    private static readonly int WindMovementID =
        Shader.PropertyToID("_WindMovement");

    private static readonly int WindDensityID =
        Shader.PropertyToID("_WindDensity");

    private static readonly int WindStrengthID =
        Shader.PropertyToID("_WindStrength");


    private void Start()
    {
        targetWindMovement = windMovement;
        targetWindDensity = windDensity;
        targetWindStrength = windStrength;

        ApplyWind();
    }

    private void Update()
    {
        windMovement = Mathf.Lerp(
            windMovement,
            targetWindMovement,
            smoothSpeed * Time.deltaTime
        );

        windDensity = Mathf.Lerp(
            windDensity,
            targetWindDensity,
            smoothSpeed * Time.deltaTime
        );

        windStrength = Mathf.Lerp(
            windStrength,
            targetWindStrength,
            smoothSpeed * Time.deltaTime
        );

        ApplyWind();
    }


    public void SetWindMovement(float value)
    {
        targetWindMovement = value;

        Debug.Log("Wind Movement: " + value);
    }


    public void SetWindDensity(float value)
    {
        targetWindDensity = value;

        Debug.Log("Wind Density: " + value);
    }

    public void SetWindStrength(float value)
    {
        targetWindStrength = value;

        Debug.Log("Wind Strength: " + value);
    }


    public float GetWindStrength()
    {
        return windStrength;
    }


    private void ApplyWind()
    {
        foreach (Material material in windMaterials)
        {
            if (material == null)
                continue;

            material.EnableKeyword("_CUSTOMWIND_ON");

            material.SetFloat(
                WindMovementID,
                windMovement
            );

            material.SetFloat(
                WindDensityID,
                windDensity
            );

            material.SetFloat(
                WindStrengthID,
                windStrength
            );
        }
    }
}