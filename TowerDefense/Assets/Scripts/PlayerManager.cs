using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float purse = 20f;
    public Text purseText;
    public GameObject defense;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        purseText.text = "Bank: $" + purse.ToString();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.tag == "block")
            {
                obj.GetComponent<Block>().selected = true;

                if (Input.GetMouseButtonDown(0))
                {
                    if (obj.GetComponent<Block>().assigned == false && purse >= 10f) {
                        purse -= 10f;
                        obj.GetComponent<Block>().assigned = true;
                        Instantiate(defense, obj.transform.position + new Vector3(0,1,0), Quaternion.identity);
                    }
                }
            }
        }

        if ( Input.GetMouseButtonDown (0)){
            if ( Physics.Raycast (ray,out hit,200.0f)) {
                GameObject box = hit.collider.gameObject;

                if (box.tag == "enemy") {
                    GameObject parent = box.transform.parent.gameObject;
                    parent.GetComponent<Enemy>().lowerHp();
                    //Destroy(box);
                }
            }
        }
    }
}
