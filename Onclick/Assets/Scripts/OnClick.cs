using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnClick : MonoBehaviour
{
    public float Visible;
    public Text number;
    public Sprite Close;
    private Image thisImage;
    private bool isClose;

    private void Awake()
    {
        thisImage = GetComponent<Image>();
        GetComponent<Animation>().Play("Creat");
    }
    public void Click()
    {
        if (isClose)
            return;
        SpawnInGame.Score += 1;
        EventManager.OnClickToPoint();
        Delete();
    }
    public void Delete()
    {
        Destroy(gameObject);
        Destroy(this);
    }
    private void OnDestroy()
    {
        SpawnInGame.PointsInstanste--;
    }
    private void FixedUpdate()
    {
        Visible -= Time.fixedDeltaTime;
        if (Visible <= 0)
        {
            if (isClose)
                Delete();
            isClose = true;
            thisImage.sprite = Close;
            Visible = 0.77f;
        }
    }
}
