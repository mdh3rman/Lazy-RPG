using UnityEngine;
using System.Collections;

public class PopupTextController : MonoBehaviour {

    private static PopupText popupText;
    private static GameObject canvas;
    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<PopupText>("Prefabs/Enemy_Damage");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        PopupText instance = Instantiate(popupText);
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f,.5f), location.position.y + Random.Range(-.5f, .5f)));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        Debug.Log("X = " + screenPosition.x + ", Y = " + screenPosition.y);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);

    }
}
