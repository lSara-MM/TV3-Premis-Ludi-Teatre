using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

//https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/
//https://gamedevbeginner.com/addressable-assets-in-unity/

public class PropData
{
    public string name { get; set; }
    public string internalTag { get; set; }
    public string imagePath { get; set; }

    public Prop CreateProp(string name, string internalTag, string imgPath)
    {
        if (true)   // validation?
        {
            Prop prop = new Prop(this.name, this.internalTag, this.imagePath);
            return prop;
        }

        return null;
    }
}

public class Prop
{
    public string name;
    public string internalTag;
    public string imagePath;

    public Prop()
    {

    }
    public Prop(string name, string internalTag, string imgPath)
    {

    }
}
