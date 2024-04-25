using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ManageWeapons : MonoBehaviour
{
    public int AmmoInGun{get; private set;}

    [SerializeField] GameObject sparksAtImpact;
    [SerializeField] GameObject ammoCratePartcles;
    Camera playersCamera;
    Ray rayFromPlayer;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        playersCamera = Camera.main;
        AmmoInGun = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && AmmoInGun > 0)
        {
            rayFromPlayer = playersCamera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            if(Physics.Raycast(rayFromPlayer, out hit, 100)){
                Vector3 positionHit = hit.point;
                GameObject impact = Instantiate(sparksAtImpact, positionHit, quaternion.identity);
                Destroy(impact, 1);
                if(hit.collider.GetComponent<ManageTargets>())
                {
                    hit.collider.GetComponent<ManageTargets>().GotHit();
                }
            }
            AmmoInGun--;
            Debug.Log($"You have {AmmoInGun} shots left!");
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "AmmoBox")
        {
            Destroy(other.gameObject);
            GameObject particles = Instantiate(ammoCratePartcles, other.transform.position, Quaternion.identity);
            Destroy(particles, 1);
            AmmoInGun += 10;
        }
    }
}
