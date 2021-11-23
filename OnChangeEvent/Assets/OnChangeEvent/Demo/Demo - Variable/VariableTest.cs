using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Act.Scripts.OnChanged;
using UnityEngine.UI;

public class VariableTest : MonoBehaviour
{
    ObservableVariable<int> cubeHealth;
    ObservableLogger logger;

    void Start()
    {
        cubeHealth = new ObservableVariable<int>(100);
        cubeHealth.OnChanged += CubeHealth_OnChanged;
        logger = new ObservableLogger(cubeHealth);
    }

    private void CubeHealth_OnChanged(object obj)
    {
        if ((int)obj <= 0)
        {
            print("cube is dead");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            cubeHealth.Value -= 10;
    }

   
}

