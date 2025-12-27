using UnityEngine;

public class TeamProfile : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] singleMaterialRenderers;
    [SerializeField] private MeshRenderer[] characterMeshRenderers;

    public TeamData MyTeam { get; private set; }
   
    public void Initialize(TeamData data)
    {
        MyTeam = data;

        if (characterMeshRenderers == null || characterMeshRenderers.Length == 0)
            characterMeshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (var meshRenderer in characterMeshRenderers)
        { 
            if (!meshRenderer) continue;
            var materials = meshRenderer.materials;

            for (int i = 0; i < materials.Length; i++)
                materials[i] = MyTeam.MaterialTeam;

            meshRenderer.materials = materials;
        }
        
        if (singleMaterialRenderers == null || singleMaterialRenderers.Length == 0)
            singleMaterialRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (var meshRenderer in singleMaterialRenderers)
        {
            if (!meshRenderer) continue;
            meshRenderer.material = MyTeam.MaterialTeam;
        }
    }
}