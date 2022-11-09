using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTextUi : MonoBehaviour
{
  [SerializeField] private Text _text;
  
  private void Awake()
  {
    _text = GetComponent<Text>();
  }


  private void Update()
  {
    DateTime now = DateTime.Now;
    string hour = LeadingZeros(now.Hour);
    string minute = LeadingZeros(now.Minute);
    string second = LeadingZeros(now.Second);
    _text.text = hour + ":" + minute + ":" + second;

  }


  private string LeadingZeros(int n)
  {
    return n.ToString().PadLeft(2, '0');
  }
}
