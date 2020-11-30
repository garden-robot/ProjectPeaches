using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListButton : MonoBehaviour
{
    [SerializeField] private Animator _crossOutAnim = null;
    [SerializeField] private Animator _listAnim = null;

    public void OnClick()
    {
        if(_listAnim.GetBool("Clicked") == false)
        {
            _listAnim.SetBool("Clicked", true);
        }else {
            _listAnim.SetBool("Clicked", false);
        }
    }
    
    public void OnTaskComplete()
    {
        _crossOutAnim.SetBool("Finished", true);
    }
}
