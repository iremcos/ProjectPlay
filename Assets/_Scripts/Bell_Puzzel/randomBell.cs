using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBell : MonoBehaviour
{


    public GameObject[] bells; 
    public Transform[] slots; 


    public class RandomBell : MonoBehaviour
    {
        public GameObject bellPrefab;  
        public Transform slotContainer; 
        public float spawnRadius = 10f; 
        public randomBell bellPuzzleData; 

        void Start()
        {
            int slotCount = slotContainer.childCount;

            
            bellPuzzleData.bells = new GameObject[slotCount];
            bellPuzzleData.slots = new Transform[slotCount];

           
            for (int i = 0; i < slotCount; i++)
            {
                bellPuzzleData.slots[i] = slotContainer.GetChild(i);
            }

            
            for (int i = 0; i < slotCount; i++)
            {
                Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
                randomPosition.y = Mathf.Abs(randomPosition.y) + 1; 

                GameObject bell = Instantiate(bellPrefab, randomPosition, Quaternion.identity);
                bell.name = $"Bell_{i + 1}"; 
                bellPuzzleData.bells[i] = bell;
            }
        }
    }
}
