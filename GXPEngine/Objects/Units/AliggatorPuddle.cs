using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
using GXPEngine.Objects.Units;

public class AliggatorPuddle:Sprite
{
    Sprite visuals;
    Alligator[] triggers= new Alligator[3];
    float alligatorsOffset = 120;


    public AliggatorPuddle(float puddleWidth, float x,float y): base ("puddle.png", false,false)
    {
        SetXY(x, y);
        width = (int)puddleWidth;

        visuals = new DeathTrigger(10, 10 ,(int)puddleWidth-20);

        AddChild(visuals);

        int alligatorIndex = 0;
        for (int xPos = 0 + (int)puddleWidth / 6; xPos < puddleWidth; xPos += (int)puddleWidth / 3)
        {
            triggers[alligatorIndex] = new Alligator(xPos, -10);
            triggers[alligatorIndex].SetScaleXY(0.5f, 0.5f);
            triggers[alligatorIndex].SetOrigin(triggers[alligatorIndex].width / 2, 0);
            AddChild(triggers[alligatorIndex]);
            Console.WriteLine(triggers[alligatorIndex]);
            alligatorIndex++;
        }
    }

    void Update() {
        

    }

    void OnCollision(GameObject collider)
    {
        if (collider is Player) {
            var player = collider as Player;
            player.Kill();
        }
    }
}

