using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MasterPrompt.ModelStitching;

namespace TheGameMecha.NPCBuilder
{
    public class NPCBuilder : MonoBehaviour
    {
        public NPCTemplate npcData;
        public GameObject model;

        public bool useOneMaterial = false;
        public Material material;

        private Stitcher stitcher;
        private GameObject spawnedObject;

        private bool _isReady;
        public bool IsReady
        {
            get { return _isReady; }
            private set { _isReady = false; }
        }

        void Awake()
        {
            stitcher = new Stitcher();
        }

        private void Start()
        {
            StartCoroutine(SetupSpawnedBody());
        }

        // Due to limitations within Unity, the Sticher can only be called once per frame
        // Need to use a Coroutine to spawn them at end of each frame
        IEnumerator SetupSpawnedBody()
        {
            foreach (NPCBodyPart item in npcData.bodyParts)
            {
                SpawnBodyPart(item.bodyPartPrefab);
                yield return new WaitForEndOfFrame();
            }

            if (useOneMaterial)
            {
                SkinnedMeshCombiner.CombineMeshes(gameObject, material);
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).name.Contains("SpawnedBodyPart"))
                    {
                        Destroy(transform.GetChild(i).gameObject);
                    }
                }
            }
            _isReady = true;
        }

        private void SpawnBodyPart(GameObject part)
        {
            if (part == null)
                return;
            part = Instantiate(part);
            part.name += "SpawnedBodyPart"; // This is for deleting it later
            spawnedObject = stitcher.Stitch(part, model);
        }
    }
}