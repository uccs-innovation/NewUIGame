
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.Events;



public class ReturnEvent : UnityEvent

{



}





public class InstructionsScreen : MonoBehaviour

{

    ReturnEvent returnEvent = new ReturnEvent();



    public void HandleReturn()

    {

        returnEvent.Invoke();

    }



    public void AddHandler(UnityAction handler)

    {

        returnEvent.AddListener(handler);

    }

}