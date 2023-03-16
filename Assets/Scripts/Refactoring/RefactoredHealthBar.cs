using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredHealthBar : MonoBehaviour {

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private IHealth healthInterface;

    private void Start() {
        healthInterface = gameObject.GetComponentInParent<IHealth>();
    }

    public void Update() {
        slider.value = healthInterface.GetActualHealth();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
