using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOStringUIUpdate : MonoBehaviour
{
    public SOString soString;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        uiTextValue.text = soString.value.ToString();
    }

    private void Update()
    {
        uiTextValue.text = soString.value.ToString();
    }
}
