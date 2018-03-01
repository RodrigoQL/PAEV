using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : Crashable {
    
    public bool isBoss;
    public int Scrap = 5;
    IEnumerator Win() {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector3(0, 50, 0);
        yield return new WaitForSeconds(2);
        GlobalValues val = GameObject.Find("GlobalValues").GetComponent<GlobalValues>();
        val.Scrap += Scrap;
        val.UpdateStats();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    protected override void DestroySelf() {
        Vector3 pos = this.transform.position;
        pos.z -= 1;
        GameObject exp = Instantiate( Explosion, pos, Quaternion.identity );
        Destroy( exp, 1 );

        if (isBoss) {
            pos += new Vector3( 1, 1, 0 );
            GameObject exp2 = Instantiate( Explosion, pos, Quaternion.identity );
            Destroy( exp2, 1 );
            pos += new Vector3( -1, 0, 0 );
            GameObject exp3 = Instantiate( Explosion, pos, Quaternion.identity );
            Destroy( exp3, 1 );
            pos += new Vector3( -1, -1, 0 );
            GameObject exp4 = Instantiate( Explosion, pos, Quaternion.identity );
            Destroy( exp4, 1 );
            StartCoroutine( Win() );
        }
        else {
            GlobalValues val = GameObject.Find("GlobalValues").GetComponent<GlobalValues>();
            val.Scrap += Scrap;
            val.UpdateStats();
            Destroy( gameObject, 0.1f );
        }
    }
}
