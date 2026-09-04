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


    // Shader property IDs
    private static readonly int WindMovementID = Shader.PropertyToID("_WindMovement");
    private static readonly int WindDensityID = Shader.PropertyToID("_WindDensity");
    private static readonly int WindStrengthID = Shader.PropertyToID("_WindStrength");


    private void Start()
    {
        ApplyWind();
    }


    private void Update()
    {
        ApplyWind();
    }


    private void ApplyWind()
    {
        foreach (Material material in windMaterials)
        {
            if (material == null)
                continue;

            // Make sure the custom wind shader feature is enabled
            material.EnableKeyword("_CUSTOMWIND_ON");

            // Send values to the shader
            material.SetFloat(WindMovementID, windMovement);
            material.SetFloat(WindDensityID, windDensity);
            material.SetFloat(WindStrengthID, windStrength);
        }
    }
}