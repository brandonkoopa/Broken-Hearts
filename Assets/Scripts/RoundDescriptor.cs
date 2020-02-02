﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "RoundDescriptor")]
public class RoundDescriptor : ScriptableObject
{
  public Robot leftRobotPrefab;
  public Robot rightRobotPrefab;

  public float roundDuration = 60.0f;

  public int maxPoints = 1000;
  public List<GameObject> partsList = new List<GameObject>();

}
