using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void healthSet(int health){
        slider.maxValue = health;
        slider.value = health;

    }

    public void changeHealth(int health){
        slider.value = health;
    }
    // Start is called before the first frame update

}
