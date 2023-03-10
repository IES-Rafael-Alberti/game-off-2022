using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public Vector3 respawn = Vector3.zero;

    private List<DontDestroyOnLoad> objs = new List<DontDestroyOnLoad>();
    private float age = 0;
    private void Update()
    {
        age += Time.deltaTime * 0.01f;
        if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(gameObject);
    }


    private void Awake()
    {
        

        foreach (DontDestroyOnLoad go in FindObjectsOfType(typeof(DontDestroyOnLoad)))
             if (go.name == name) objs.Add(go);
        if (objs.Count > 1)
        {
            foreach (DontDestroyOnLoad go in objs)
            {
                if (go.GetInstanceID() != GetInstanceID())
                {
                    if (go.age > age) {
                        Destroy(gameObject);
                    }
                }
                else transform.position = respawn;
            }
        }
        DontDestroyOnLoad(gameObject);

        
    }
}
