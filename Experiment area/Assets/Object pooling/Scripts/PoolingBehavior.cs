using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBehavior : MonoBehaviour
{
    public List<GameObject> objectList;
    private int i;

    public KeyCode keyCodeOption;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(keyCodeOption)) return;
        objectList[i].SetActive(true);
        i++;
        if (i >= objectList.Count)
        {
            i = 0;
        }
    }
}
