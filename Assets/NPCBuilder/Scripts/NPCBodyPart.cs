using UnityEngine;

namespace TheGameMecha.NPCBuilder
{
    [CreateAssetMenu(fileName = "NPC Body Part", menuName = "NPC Builder/NPC Body Part")]
    public class NPCBodyPart : ScriptableObject
    {
        [Tooltip("A Prefab containing the mesh, bones, and material")]
        public GameObject bodyPartPrefab;
        public BodyPartType bodyPartType;
    }

    public enum BodyPartType
    {
        HEAD,
        BODY,
        LEGS,
        RIGHT_ARM,
        LEFT_ARM
    }
}