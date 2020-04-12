using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float purse = 20f;
    public Text purseText;
    public GameObject defense;

    public float hp = 1.0f;
    public float damage = 0.25f;
    public GameObject hpBar;

    // Update is called once per frame
    void Update()
    {
        hpBar.GetComponent<Image>().fillAmount = hp;

        purseText.text = "Bank: $" + purse.ToString();

        if (hp == 0f) {
            SceneManager.LoadScene(2);
        }

        if (GameObject.FindGameObjectWithTag("enemy") == null) {
            SceneManager.LoadScene(2);
        }


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
                    parent.GetComponent<Enemy>().lowerHp(0.5f);
                    //Destroy(box);
                }
            }
        }
    }

    public void lowerHp(float damage)
    {
        hp -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide: " + other.gameObject.tag);
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("enter");
            lowerHp(0.25f);
            Destroy(other.gameObject);
        }
    }
}
