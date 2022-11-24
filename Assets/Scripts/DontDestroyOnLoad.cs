using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private List<GameObject> objs = new List<GameObject>();
    public Vector3 respawn = Vector3.zero;
    private void Awake()
    {
        {
            foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
            if (go.name == name) objs.Add(go);
            if (objs.Count > 1)
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    if (i == 0) objs[i].transform.position = respawn;
                    else Destroy(objs[i]);
                }
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
