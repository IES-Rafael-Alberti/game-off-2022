using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredHealthBar : MonoBehaviour {

    public Slider slider;

    public void SetHealth(int health) { 
        slider.value = health;
    }

}
