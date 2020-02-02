﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
  private Part currentPart_ = null;

  public Action PartChanged;
  public HeartArea heartArea;

  public void AttachPart(Part partToAttach) {
    currentPart_ = partToAttach;
    if(partToAttach != null) {
      partToAttach.transform.position = transform.position;
      partToAttach.transform.rotation = transform.rotation;
    }

    if (PartChanged != null) {
      // trigger the part change event
      PartChanged();
    }
  }

  private void OnTriggerEnter(Collider other) {
    var part = other.gameObject.GetComponent<Part>();
    if(part != null) {
      part.gameObject.GetComponent<Draggable>().collidingSlot = gameObject.GetComponent<Slot>();
      highlight();
      heartArea.highlight();
      AttachPart(part); 
    }
  }

  private void OnTriggerExit(Collider other) {
    var part = other.gameObject.GetComponent<Part>();
    if(part != null) {
      unHighlight();
      heartArea.unHighlight();
      part.gameObject.GetComponent<Draggable>().collidingSlot = null;
    }
  }

  public void highlight() {
        gameObject.GetComponent<Renderer>().materials[0].color = Color.green;
    }

    public void unHighlight() {
        gameObject.GetComponent<Renderer>().materials[0].color = Color.white;
    }

}
