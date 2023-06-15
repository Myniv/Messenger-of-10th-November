using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMateri : MonoBehaviour
{
    public void OpenURL(string link){
        Application.OpenURL(link);
    }
}
