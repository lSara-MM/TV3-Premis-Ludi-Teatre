using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionManager : MonoBehaviour
{
    [SerializeField] private string solutionTag = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision?.tag == "Prop")
        {
            Debug.Log($"Enter {collision.name}");

            if (collision.GetComponent<PropBehaviour>()?.prop.internalTag == solutionTag)
            {
                collision.GetComponent<PropBehaviour>().prop.correctPlace = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision?.tag == "Prop")
        {
            Debug.Log($"Exit {collision.name}");

            if (collision.GetComponent<PropBehaviour>()?.prop.internalTag == solutionTag)
            {
                collision.GetComponent<PropBehaviour>().prop.correctPlace = false;
            }
        }
    }
}
