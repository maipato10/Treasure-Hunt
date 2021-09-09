using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaunchGrenate : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject grenate;
    float range = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Launch();
    }
    //method that launches
    private void Launch()
    {
        GameObject grenateInstance = Instantiate(grenate, spawnPoint.position, spawnPoint.rotation);
        grenateInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Force);
    }
}
