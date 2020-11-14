using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace TheGameMecha.NPCBuilder
{
    public class NPCGenerator : EditorWindow
    {
        int numberOfNpcs;

        int numHeads;
        Object[] headBodyParts;
        int numBodies;
        Object[] bodyBodyParts;
        int numRightArms;
        Object[] rightArmBodyParts;
        int numLeftArms;
        Object[] leftArmBodyParts;
        int numLegs;
        Object[] legsBodyParts;

        [MenuItem("NPC Builder/NPC Generator")]
        static void Init()
        {
            NPCGenerator window = (NPCGenerator)EditorWindow.GetWindow(typeof(NPCGenerator), false, "NPC Generator");
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Settings", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Number of NPCs to Generate: ");
            numberOfNpcs = EditorGUILayout.IntField(numberOfNpcs);

            GUILayout.Label("Body Parts", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Number of Head Variations: ");
            numHeads = EditorGUILayout.IntField(numHeads);
            if (headBodyParts == null || numHeads != headBodyParts.Length)
                 headBodyParts = new Object[numHeads];

            for (int i = 0; i < headBodyParts.Length; i++)
            {
                headBodyParts[i] = EditorGUILayout.ObjectField(headBodyParts[i], typeof(NPCBodyPart), true);
            }

            EditorGUILayout.LabelField("Number of Body Variations: ");
            numBodies = EditorGUILayout.IntField(numBodies);
            if (bodyBodyParts == null || numBodies != bodyBodyParts.Length)
                bodyBodyParts = new Object[numBodies];

            for (int i = 0; i < bodyBodyParts.Length; i++)
            {
                bodyBodyParts[i] = EditorGUILayout.ObjectField(bodyBodyParts[i], typeof(NPCBodyPart), true);
            }

            EditorGUILayout.LabelField("Number of Right Arm Variations: ");
            numRightArms = EditorGUILayout.IntField(numRightArms);
            if (rightArmBodyParts == null || numRightArms != rightArmBodyParts.Length)
                rightArmBodyParts = new Object[numRightArms];

            for (int i = 0; i < rightArmBodyParts.Length; i++)
            {
                rightArmBodyParts[i] = EditorGUILayout.ObjectField(rightArmBodyParts[i], typeof(NPCBodyPart), true);
            }

            EditorGUILayout.LabelField("Number of Left Arm Variations: ");
            numLeftArms = EditorGUILayout.IntField(numLeftArms);
            if (leftArmBodyParts == null || numLeftArms != leftArmBodyParts.Length)
                leftArmBodyParts = new Object[numLeftArms];

            for (int i = 0; i < leftArmBodyParts.Length; i++)
            {
                leftArmBodyParts[i] = EditorGUILayout.ObjectField(leftArmBodyParts[i], typeof(NPCBodyPart), true);
            }

            EditorGUILayout.LabelField("Number of Legs Variations: ");
            numLegs = EditorGUILayout.IntField(numLegs);
            if (legsBodyParts == null || numLegs != legsBodyParts.Length)
                legsBodyParts = new Object[numLegs];

            for (int i = 0; i < legsBodyParts.Length; i++)
            {
                legsBodyParts[i] = EditorGUILayout.ObjectField(legsBodyParts[i], typeof(NPCBodyPart), true);
            }

            if (GUILayout.Button("Generate NPCs"))
            {
                AssetDatabase.Refresh();
                for (int i = 0; i < numberOfNpcs; i++)
                {
                    NPCTemplate newNPC = CreateInstance<NPCTemplate>();

                    int chosenHead = Random.Range(0, headBodyParts.Length);
                    int chosenBody = Random.Range(0, bodyBodyParts.Length);
                    int chosenRightArm = Random.Range(0, rightArmBodyParts.Length);
                    int chosenLeftArm = Random.Range(0, leftArmBodyParts.Length);
                    int chosenLegs = Random.Range(0, legsBodyParts.Length);

                    newNPC.bodyParts = new List<NPCBodyPart>();

                    newNPC.bodyParts.Add((NPCBodyPart)headBodyParts[chosenHead]);
                    newNPC.bodyParts.Add((NPCBodyPart)bodyBodyParts[chosenBody]);
                    newNPC.bodyParts.Add((NPCBodyPart)rightArmBodyParts[chosenRightArm]);
                    newNPC.bodyParts.Add((NPCBodyPart)leftArmBodyParts[chosenLeftArm]);
                    newNPC.bodyParts.Add((NPCBodyPart)legsBodyParts[chosenLegs]);

                    string assetPath = "Assets/NPCBuilder/Data/GeneratedNPC.asset";

                    int count = 1;
                    string fileNameOnly = Path.GetFileNameWithoutExtension(assetPath);
                    string path = Path.GetDirectoryName(assetPath);
                    string extension = ".asset";
                    string newFullPath = assetPath;

                    while (File.Exists(newFullPath))
                    {
                        string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                        newFullPath = Path.Combine(path, tempFileName + extension);
                    }

                    AssetDatabase.CreateAsset(newNPC, newFullPath);
                    AssetDatabase.SaveAssets();
                }

                Debug.Log(numberOfNpcs + " NPCs Generated");
            }

            Repaint();
        }
    }
}