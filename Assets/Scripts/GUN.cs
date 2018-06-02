using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour {
    public Rigidbody2D rocket;
    public float speed = 20f;

    private PlayerControl playerCtrl;
    private Animator anim;

    void Awake()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerControl>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")){
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();

            if (playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
	}
}
