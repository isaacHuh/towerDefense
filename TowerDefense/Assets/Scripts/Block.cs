using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Material nonSelectedMat;
    public Material selectedMat;
    public bool selected = false;
    public bool assigned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            gameObject.GetComponent<MeshRenderer>().material = selectedMat;
            selected = false;
        }
        else {
            gameObject.GetComponent<MeshRenderer>().material = nonSelectedMat;
        }
    }
}
