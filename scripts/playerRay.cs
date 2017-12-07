using Godot;
using System;

public class playerRay : RayCast2D
{
    globals g;
    player p;
    UI ui;
    Camera2D cam;
    npcScript collidingWith;
    bool drawingFadeOut;

    public override void _Ready()
    {
        g = GetNode("/root/globals") as globals;
        ui = GetNode("../../UI") as UI;
        cam = GetNode("../Camera2D") as Camera2D;
        p = GetParent() as player;

    }
    
    private void CheckCombat(Node col)
    {
        collidingWith = col.GetParent() as npcScript;
        ui.collidingWith = collidingWith;
        if(ui.collidingWith.myType == npcType.enemy){
            
            g.inCombat = true;

            ui.StartFadeOut();
        }
    }

    public override void _Process(float delta)
    {
        if (GetName() == "playerRayDown")
        {
            if (IsColliding())
            {
                if(!g.inCombat)
                    CheckCombat(GetCollider() as Node);
                g.playerBlockedDown = true;
            }
            else
                g.playerBlockedDown = false;
        }
        else if (GetName() == "playerRayUp")
        {
            if (IsColliding()){
                if(!g.inCombat)
                    CheckCombat(GetCollider() as Node);
                g.playerBlockedUp = true;
            }
            else
                g.playerBlockedUp = false;
        }
        else if (GetName() == "playerRayLeft")
        {
            if (IsColliding()){
                if(!g.inCombat)
                    CheckCombat(GetCollider() as Node);
                g.playerBlockedLeft = true;
            }
            else
                g.playerBlockedLeft = false;

        }
        else if(GetName() == "playerRayRight")
        {
            if (IsColliding()){
                if(!g.inCombat)
                    CheckCombat(GetCollider() as Node);
                g.playerBlockedRight = true;
            }
            else 
                g.playerBlockedRight = false;
        }
    }
}
