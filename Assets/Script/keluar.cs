using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keluar : MonoBehaviour
{
    public void TombolKeluar()
    {
        Application.Quit();
        Debug.Log("tombol sudah ditekan");
    }
}
