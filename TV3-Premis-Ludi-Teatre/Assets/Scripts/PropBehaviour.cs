using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

//https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/
//https://gamedevbeginner.com/addressable-assets-in-unity/

public class PropBehaviour : MonoBehaviour
{
    public Prop prop = null;

    private void Awake()
    {
        string n = this.name.Replace("(Clone)", "");

        prop = Globals.propsList.Find((x) => x.name == n);

        /* equivalent to
         bool IsPropMatch(GameObject x)
        {
           return x.name == propName;
        }
         */
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}

