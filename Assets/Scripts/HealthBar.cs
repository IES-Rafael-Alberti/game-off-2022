using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour, ITextInfo
{
    public PlayerHealth playerHealth;

    private List<GameObject> gameObjects = new List<GameObject>();
    private int counter;

    public string Show()
    {
        return $"{playerHealth.health} Lives Left";
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            gameObjects.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter = 0;
        foreach(GameObject child in gameObjects)
        {
            child.SetActive(false);
        }
        foreach (GameObject child in gameObjects)
        {
            counter++;
            if (counter >= playerHealth.health+1) break;
            child.SetActive(true);
        }
    }
}
