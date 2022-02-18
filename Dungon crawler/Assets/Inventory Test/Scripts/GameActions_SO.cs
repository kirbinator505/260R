using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameActions_SO : ScriptableObject
{
    public UnityAction raiseNoArgs;
    public UnityAction<object> raiseObj;
    public UnityAction<Transform> raiseTran;
    public UnityAction<bool> raiseBool;

    public void RaiseAction()
    {
        raiseNoArgs?.Invoke();
    }

    public void RaiseActionWithObject(object obj)
    {
        raiseObj?.Invoke(obj);
    }

    public void RaiseActionWithTransform(Transform obj)
    {
        raiseTran?.Invoke(obj);
    }

    public void RaiseActionWithBool(bool obj)
    {
        raiseBool?.Invoke(obj);
    }
}
