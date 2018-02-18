using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject Explosion;
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject exp = Instantiate(Explosion, collision.gameObject.transform);
        exp.transform.position = this.transform.position;
        exp.GetComponent<Animator>().speed = 3;
        Destroy(exp, 0.5f);
        Destroy(gameObject);
    }
}
