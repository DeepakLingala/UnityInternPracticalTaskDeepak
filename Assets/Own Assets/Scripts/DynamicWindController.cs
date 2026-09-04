using System.Collections.Generic;
using UnityEngine;

public class DynamicWindController : MonoBehaviour
{
    [Header("Wind Settings")]
    [Range(0f, 3f)]
    [SerializeField] private float windStrength = 1f;

    [Header("Tree Renderers")]
    [SerializeField] private Renderer[] treeRenderers;

    private readonly List<Material> windMaterials = new List<Material>();

    private void Start()
    {
        FindWindMaterials();
        ApplyWindStrength();
    }

    private void Update()
    {
        ApplyWindStrength();
    }

    private void FindWindMaterials()
    {
        windMaterials.Clear();

        foreach (Renderer renderer in treeRenderers)
        {
            if (renderer == null)
                continue;

            Material[] materials = renderer.materials;

            foreach (Material material in materials)
            {
                if (material == null)
                    continue;

                if (HasWindStrengthProperty(material))
                {
                    if (!windMaterials.Contains(material))
                    {
                        windMaterials.Add(material);
                    }
                }
            }
        }

        Debug.Log("Wind materials found: " + windMaterials.Count);
    }

    private bool HasWindStrengthProperty(Material material)
    {
        Shader shader = material.shader;

        for (int i = 0; i < shader.GetPropertyCount(); i++)
        {
            string propertyName = shader.GetPropertyName(i);
            string propertyDescription = shader.GetPropertyDescription(i);

            string combinedText =
                (propertyName + " " + propertyDescription).ToLower();

            if (combinedText.Contains("wind") &&
                combinedText.Contains("strength"))
            {
                return true;
            }
        }

        return false;
    }

    private void ApplyWindStrength()
    {
        foreach (Material material in windMaterials)
        {
            Shader shader = material.shader;

            for (int i = 0; i < shader.GetPropertyCount(); i++)
            {
                string propertyName = shader.GetPropertyName(i);
                string propertyDescription = shader.GetPropertyDescription(i);

                string combinedText =
                    (propertyName + " " + propertyDescription).ToLower();

                if (combinedText.Contains("wind") &&
                    combinedText.Contains("strength"))
                {
                    material.SetFloat(propertyName, windStrength);
                }
            }
        }
    }
}