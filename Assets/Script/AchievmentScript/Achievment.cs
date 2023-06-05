using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievment
{
    private string name;
    private string description;
    private bool unlocked;
    private int spriteIndex;
    private GameObject achievmentRef;
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    
    public Achievment(string name, string description, int spriteIndex){
        this.name=name;
        this.description=description;
        this.unlocked=false;
        this.spriteIndex=spriteIndex;
    }


    public bool EarnAchievment(){
        if(!Unlocked){
            Unlocked=true;
            return true;
        }
        return false;
    }

}
