using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public static class TextUtility 
{
  /// <summary>
  /// Based on the unity color documentation : https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html#supported-color
  /// </summary>
  public enum TextColor : uint
  {
    NONE = 0,
    default_color = green,
    cyan = 0x00ffffff,
    aqua = cyan,
    black = 0x000000ff,
    blue = 0x0000ffff,
    brown = 0xa52a2aff,
    darkblue = 0x0000a0ff,
    magenta = 0xff00ffff,
    fuchsia = magenta,
    green =  0x008000ff,
    grey = 0x808080ff,
    lightblue = 0xadd8e6ff,
    lime = 0x00ff00ff,
    maroon = 0x800000ff,
    navy = 0x000080ff,
    olive = 0x808000ff,
    orange = 0xffa500ff,
    purple = 0x800080ff,
    red = 0xff0000ff,
    silver = 0xc0c0c0ff,
    teal = 0x008080ff,
    white = 0xffffffff,
    yellow = 0xffff00ff,
    
  }

  
  /// <summary>
  /// add the xml color modifiers to the input
  /// </summary>
  public static string add_color_modifier(string input, TextColor color )
  {
    uint tmp = (uint)color;
    string hex_color = tmp.ToString("X8");
    return _add_color_modifier(input, '#' + hex_color);
  }
  
  
  /// <summary>
  /// add the xml color modifiers to the input
  /// </summary>
  /// <param name="input"> the string to be modified</param>
  /// <param name="hex_color"> represent the color to be added</param>
  /// <returns>the string with the color tag </returns>
  private static string _add_color_modifier(string input, string hex_color)
  {
    StringBuilder builder = new StringBuilder(input) ;
    builder.Insert(0, "<color=" + hex_color + "> ");
    builder.Insert(builder.Length, "</color>");
    return builder.ToString() ;
  }
  
}
