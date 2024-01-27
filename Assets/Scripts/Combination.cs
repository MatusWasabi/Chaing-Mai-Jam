using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Combination
{
    public string recipe1;
    public string recipe2;
    public List<string> wordPool;
    public string resultMenu;
    public Sprite resultSprite;

    public Combination(List<string> wordPool, string resultMenu, Sprite resultSprite, string recipe1 = "", string recipe2 = "" )
    {
        this.recipe1 = recipe1;
        this.recipe2 = recipe2;
        this.wordPool = wordPool;
        this.resultMenu = resultMenu;
        this.resultSprite = resultSprite;
    }

    public string GetWord(int index)
    {
        return wordPool[index];
    }

    public bool IsSameRecipe(string slot1, string slot2)
    {
        bool firstCheck = recipe1 == slot1 || recipe1 == slot2;
        bool secondCheck = recipe2 == slot1 || recipe2 == slot2;
        return firstCheck && secondCheck;
    }

}
