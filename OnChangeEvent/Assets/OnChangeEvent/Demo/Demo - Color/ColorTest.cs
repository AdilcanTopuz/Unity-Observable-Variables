using Act.Scripts.OnChanged;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    Renderer sphereMat;
    ObservableVariable<Color> color;
    ObservableLogger logger;
    Color[] colors = { Color.red, Color.green, Color.blue, Color.black, Color.cyan, Color.gray, Color.magenta, Color.yellow };
    void Start()
    {
        sphereMat = gameObject.GetComponent<Renderer>();
        color = new ObservableVariable<Color>(sphereMat.material.GetColor("_Color"));
        color.OnChanged += Color_OnChanged;
        logger = new ObservableLogger(color);
    }

    private void Color_OnChanged(object obj)
    {
        if ((Color)obj == Color.red)
        {
            print("Sphere is red and dead");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            color.Value = colors[Random.Range(0, colors.Length)];
            sphereMat.material.color = color.Value;
        }
    }

}
