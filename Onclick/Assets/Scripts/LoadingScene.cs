using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public void _LoadingScene()
    => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0);

    public void _LoadingSceneStart() => GetComponent<Animation>().Play("LoadingStart");

}
