using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Enter Collider!~" + gameObject.name);
        if (gameObject.name.StartsWith("AmmoPowerUp"))
        {
            Debug.Log("Entered");
            GameObject.Destroy(gameObject);
        }
        if (gameObject.name.StartsWith("HealthPack"))
        {
            Debug.Log("Healing");
            GameObject.Destroy(gameObject);
        }
    }
}
