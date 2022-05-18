using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject[] prifb;

    private GameObject install;
    private void Awake()
    {
        install = Instantiate(prifb[0], transform, false);
    }

    public void Click(int index)
    {
        Destroy(install);
        install = Instantiate(prifb[index], transform, false);
    }

}


