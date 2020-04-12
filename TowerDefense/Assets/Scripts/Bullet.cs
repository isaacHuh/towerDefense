using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
  public float speed = 5;
  public float lifeTime = 5;
  public float damage = 0.2f;
  private Rigidbody rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rb.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
  }
  void FixedUpdate()
  {
    lifeTime -= Time.deltaTime;
    Debug.Log(lifeTime);
    if (lifeTime < 0) Destroy(gameObject);
  }
}
