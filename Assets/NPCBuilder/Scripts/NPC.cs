using System.Collections.Generic;
using UnityEngine;

namespace TheGameMecha.NPCBuilder
{
    [CreateAssetMenu(fileName = "NPC Data", menuName = "NPC Builder/NPC Data")]
    public class NPC : ScriptableObject
    {
        public List<NPCBodyPart> bodyParts;
    }
}