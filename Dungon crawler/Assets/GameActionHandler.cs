using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameActions_SO action;
    public UnityEvent startEvent, respondEvent;
    public float holdTime = 0.1f;
    private WaitForSeconds waitObj;

    void Start()
    {
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        waitObj = new WaitForSeconds(holdTime);
        action.raiseNoArgs += Respond;
       /* action.raiseObj += RespondWithObj;
        action.raiseTran += RespondWithTran;
        action.raiseBool += RespondWithBool;*/
    }

    private void Respond()
    {
        respondEvent.Invoke();
    }

   /* private void RespondWithObj(object obj)
    {
        
    }

    private void RespondWithTran(Transform obj)
    {
        
    }

    private void RespondWithBool(bool obj)
    {
        
    }*/
}
