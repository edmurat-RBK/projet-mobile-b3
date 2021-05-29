using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class anim : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    IEnumerator Animate()
    {
        foreach (Sprite item in sprites)
        {
            image.sprite = item;
            yield return new WaitForSecondsRealtime(.2f);
        }
        StartCoroutine(Animate());
    }
}
