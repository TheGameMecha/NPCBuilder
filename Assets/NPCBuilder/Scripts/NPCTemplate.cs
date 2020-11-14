using System.Collections.Generic;
using UnityEngine;

namespace TheGameMecha.NPCBuilder
{
    [CreateAssetMenu(fileName = "NPC Template", menuName = "NPC Builder/NPC Template")]
    public class NPCTemplate : ScriptableObject
    {
        public List<NPCBodyPart> bodyParts;
    }
}