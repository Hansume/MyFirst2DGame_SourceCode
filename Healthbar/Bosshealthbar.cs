using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshealthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Angel_Controller angelHealth;
    public Image health;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = angelHealth.currentHealth;
    }
}
