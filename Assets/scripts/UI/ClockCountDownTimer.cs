using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ClockCountDownTimer : MonoBehaviour
{
  [SerializeField] private Text _text;
  private float elpased_time = 0.0f;
  [Tooltip("how many second until the count down finishes")]
  public int seconds_for_countdown = 5;
  private int seconds_remaining = 0;
  // second remaining 
    void Start()
    {
      _text = GetComponent<Text>();
      elpased_time = 0.0f;
      seconds_remaining = seconds_for_countdown;
      format_time_text();
    }

    void Update()
    {
      elpased_time += Time.deltaTime;
      if ( seconds_remaining >= 0 && elpased_time > 0.99f)
      {
        format_time_text();
        elpased_time = 0.0f;
        seconds_remaining = seconds_remaining - 1;
      }
      else if (seconds_remaining < 0)
      {
        _text.text = "time is up";
        _text.text = TextUtility.add_color_modifier(_text.text, TextUtility.TextColor.white);
      }

    }

    void format_time_text()
    {
      StringBuilder sb = new StringBuilder();
      sb.Insert(0,"remaining time : ");
      sb.Insert(sb.Length, seconds_remaining.ToString().PadLeft(2, '0'));
      _text.text = TextUtility.add_color_modifier(sb.ToString(), TextUtility.TextColor.white) ;
    }
}
