using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour1 : MonoBehaviour
{
    // Start is called before the first frame update
    /* IEnumerator OnEnable()
     {
         yield return new WaitForSeconds(2.0f);

     }*/
    //public Animator anim;

    void OnEnable()
    {
        Invoke("OnDisable", 3.0f);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
        this.transform.gameObject.SetActive(false);
        
        
    }
}
