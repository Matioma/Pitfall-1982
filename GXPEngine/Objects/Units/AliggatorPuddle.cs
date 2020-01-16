using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
using GXPEngine.Objects.Units;

public class AliggatorPuddle:GameObject
{
    Sprite visuals;
    Alligator[] triggers= new Alligator[3];

    public AliggatorPuddle(float puddleWidth, float x,float y) {
        visuals = new Sprite("circle.png", false);
        visuals.SetXY(x, y);
        AddChild(visuals);

        int alligatorIndex = 0;
        for (int xPos = (int)x + (int)puddleWidth / 4; xPos < x + puddleWidth; xPos += (int)puddleWidth / 3)
        {
            triggers[alligatorIndex] = new Alligator(xPos, y);
            triggers[alligatorIndex].SetScaleXY(0.5f, 0.5f);
            Console.WriteLine(alligatorIndex);
            AddChild(triggers[alligatorIndex]);
            alligatorIndex++;
        }
    }
}

