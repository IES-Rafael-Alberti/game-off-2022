using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredHealthBar : MonoBehaviour {

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public float scale = 1.0f;

    private IHealth healthInterface;

    public void Awake() {
        transform.localScale =  transform.localScale * scale;
    }

    private void Start() {
        healthInterface = gameObject.GetComponentInParent<IHealth>();
    }

    public void Update() {
        slider.value = healthInterface.GetActualHealth();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
