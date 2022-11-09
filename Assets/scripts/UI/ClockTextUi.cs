using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTextUi : MonoBehaviour
{
  [SerializeField] private Text _text;
  [SerializeField] private TextUtility.TextColor _color = TextUtility.TextColor.NONE; 
  private void Awake()
  {
    _text = GetComponent<Text>();

    if (_color == TextUtility.TextColor.NONE)
    {
      _color = TextUtility.TextColor.default_color;
    }
  }


  private void Update()
  {
    DateTime now = DateTime.Now;
    string hour = LeadingZeros(now.Hour);
    string minute = LeadingZeros(now.Minute);
    string second = LeadingZeros(now.Second);
    _text.text = hour + ":" + minute + ":" + second;
    _text.text = TextUtility.add_color_modifier(_text.text,_color);
  }


  private string LeadingZeros(int n)
  {
    return n.ToString().PadLeft(2, '0');
  }
}
