using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ObjectCombiner : MonoBehaviour {
    
    public class ObjectCombination {
        public GameObject firstObject;
        public GameObject secondObject;
        public GameObject resultObject;
    }
    
    public List<ObjectCombination> objectCombinations;
    
    // Start is called before the first frame update
    void Start() {
        // Define object combinations
        ObjectCombination combination2 = new ObjectCombination();
        combination2.firstObject = GameObject.Find("PT_Medieval_Club_01_a");
        combination2.secondObject = GameObject.Find("PT_Medieval_Dagger_01_a");
        combination2.resultObject = GameObject.Find("PT_Medieval_Waraxe_01_a");

        ObjectCombination combination1 = new ObjectCombination();
        combination1.firstObject = GameObject.Find("Cube");
        combination1.secondObject = GameObject.Find("PT_Medieval_Waraxe_01_a");
        combination1.resultObject = GameObject.Find("Hammer2");

        // Add combinations to the list
        objectCombinations = new List<ObjectCombination>();
        objectCombinations.Add(combination1);
        objectCombinations.Add(combination2);
    }

    // Update is called once per frame
    void Update() {
        int validPairsCount = 0;

        // Loop through object combinations and check for a match
        foreach (ObjectCombination combination in objectCombinations)
        {
            Collider[] firstColliders = Physics.OverlapBox(combination.firstObject.transform.position, combination.firstObject.transform.localScale / 2);
            Collider[] secondColliders = Physics.OverlapBox(combination.secondObject.transform.position, combination.secondObject.transform.localScale / 2);
            foreach (Collider firstCollider in firstColliders)
            {
                foreach (Collider secondCollider in secondColliders)
                {
                    if (firstCollider.gameObject == secondCollider.gameObject)
                    {
                        validPairsCount++;
                    }
                }
            }
        }

        // if (validPairsCount = 2 && GameObject.FindObjectOfType<Ball>().score > 15)
        // {
        //     // Make the game visible
        //     gameObject.SetActive(true);
        // }
        // else
        // {
        //     // Make the game invisible
        //     gameObject.SetActive(false);
        // }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the game is visible
        if (gameObject.activeSelf)
        {
            // Check if the collision is with an object in the collider
            if (collision.collider.bounds.Intersects(GetComponent<Collider>().bounds))
            {
                // Loop through object combinations and check for a match
                foreach (ObjectCombination combination in objectCombinations)
                {
                    if (collision.gameObject == combination.firstObject)
                    {
                        Collider[] colliders = Physics.OverlapBox(collision.gameObject.transform.position, collision.gameObject.transform.localScale / 2);
                        foreach (Collider otherCollision in colliders)
                        {
                            if (otherCollision.gameObject == combination.secondObject)
                            {
                                if (GameObject.FindObjectOfType<Ball>().score >= 5)
                                {
                                    // Instantiate the combined object at position
                                Instantiate(combination.resultObject, new Vector3(0, 3, -7), transform.rotation);

                                // Destroy the two objects that were combined
                                Destroy(collision.gameObject);
                                Destroy(otherCollision.gameObject);
                                GameObject.FindObjectOfType<Ball>().score = 0;
                                return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}