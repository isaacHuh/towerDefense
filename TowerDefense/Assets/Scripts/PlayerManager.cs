using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float purse = 0f;
    public Text purseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        purseText.text = "Bank: $" + purse.ToString();

        if ( Input.GetMouseButtonDown (0)){
            Debug.Log("pressed");
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin,ray.direction);

            if ( Physics.Raycast (ray,out hit,200.0f)) {
                GameObject box = hit.collider.gameObject;
                GameObject parent = box.transform.parent.gameObject;

                if (box.tag == "enemy") {
                    Debug.Log(parent.GetComponent<Enemy>().hp);
                    Debug.Log("hit");
                    parent.GetComponent<Enemy>().lowerHp();
                    //Destroy(box);
                }
            }
        }
    }
}
