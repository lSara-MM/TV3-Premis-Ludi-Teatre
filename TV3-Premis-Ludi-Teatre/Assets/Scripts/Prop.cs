using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropData
{
    public string Name { get; set; }
    public string InternalTag { get; set; }

    public Prop CreateProp(string name, string internalTag)
    {
        if (true)   // validation?
        {
            Prop prop = new Prop(name, internalTag);
            Globals.propsList.Add(prop);

            //Globals.propsDictionary.Add(name, prop);
        }

        return null;
    }
}

[System.Serializable]
public class Prop
{
    public string name;
    public string internalTag;
    public bool correctPlace;
    public int instances;

    public Prop()
    {

    }

    public Prop(string name, string internalTag)
    {
        this.name = name;
        this.internalTag = internalTag;

        instances = 0;
        correctPlace = false;
    }
}
