using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ManageTargets : MonoBehaviour
{
    public int Health{ get; private set; }

    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotHit(){
        Health -= 50;
        if(Health <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
        GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(newExplosion, 1);
    }
}
