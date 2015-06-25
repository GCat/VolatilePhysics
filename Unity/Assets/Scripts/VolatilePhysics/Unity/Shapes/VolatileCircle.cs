﻿using System;
using System.Collections.Generic;

using UnityEngine;

using Volatile;

public class VolatileCircle : VolatileShape
{
  [SerializeField]
  private float radius;

  public override Shape Shape { get { return this.shape; } }
  private Circle shape;

  public override void PrepareShape()
  {
    this.shape = Circle.FromWorldPosition(
      transform.position,
      radius, 
      this.density);
  }

  public override void DrawShapeInEditor()
  {
    Color current = Gizmos.color;
    Gizmos.color = Color.white;

    Gizmos.DrawWireSphere(transform.position, this.radius);

    Gizmos.color = current;
  }

  protected Vector2 GetBodyLocalPoint(Vector2 point, VolatileBody body)
  {
    return
      body.transform.InverseTransformPoint(
        this.transform.TransformPoint(point));
  }

  public override Vector2 ComputeTrueCenterOfMass()
  {
    return transform.position;
  }
}