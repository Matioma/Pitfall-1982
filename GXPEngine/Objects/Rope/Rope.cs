using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
public class Rope: GameObject
{

    float time = 0;
    float startAngleDegrees = 0;
    float rotationAplitudeDegrees = 45;
    float onePeriodTimeSecs = 10;

    float ropeLength = 250;

    EasyDraw _easyDraw;
    public Rope(float x, float y)
    {

        this.x = x;
        this.y = y;
 
        this.AddChild(new OnRopeTigger (0, ropeLength));

        _easyDraw = new EasyDraw(10, (int)ropeLength, false);

        _easyDraw.StrokeWeight(3);
        _easyDraw.Stroke(255);
        this.AddChild(_easyDraw);
        //ropeObject.SetXY(120,120);

    }
    public Rope()
    {
        this.AddChild(new OnRopeTigger(0, ropeLength));

        _easyDraw = new EasyDraw(10, (int)ropeLength, false);

        _easyDraw.StrokeWeight(3);
        _easyDraw.Stroke(255);
        this.AddChild(_easyDraw);
        //ropeObject.SetXY(120,120);

    }
    public void Update()
    {
        ropeRotation();
        _easyDraw.Line(0,0,0, ropeLength);
    }

    void ropeRotation() {
        time += Time.deltaTime;
        
        //Console.WriteLine();
        rotation = startAngleDegrees + rotationAplitudeDegrees * Mathf.Sin((time* Mathf.PI/180)/ onePeriodTimeSecs);
    }

}
