using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    //Score text
    //puse button? (pause state!)
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    //как устроить скор систему?
    //1 скор засчитывается в gameplay системе.
    
    //скор - сохраняемая модель!
    //=> где хранить эту модель??
    //пока что в data-provider`е
    //при изменении состояния, модель кидает событие об изменении, на которое уже подписан gameplay UI?
    //или модель знает об gameplay UI?
}
