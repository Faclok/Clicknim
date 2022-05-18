using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public void _LoadingScene()
    => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1);

    public void _LoadingSceneStart() => GetComponent<Animation>().Play("LoadingStart");

}
