using UnityEngine;

public abstract class CharacterBase : ScriptableObject
{
    public Color skinColor = Color.gray; //all children of CharacterBase will inherit skinColor, defaulted to gray

    public virtual void Walk() //every child will have the walking class, virtual allows it to be overriden in the child class
    {
        Debug.Log("walking"); //this is to just see that it works when instanced, will get replaced with code
    }
}
