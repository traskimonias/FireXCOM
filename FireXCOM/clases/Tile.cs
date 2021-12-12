using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


public class Tile: GameObject2D
{
    public int Column;
    public int Row;
    TileManager tileManager;
    public CharacterObject character;
    public bool InMovementReach = false;
    public bool InAttackReach = false;
    public bool IsBlocked = false;
    private int BasicMovementCost;
    Color[] colorMove = new Color[] { Color.Blue };
    Color[] colorAttack = new Color[] { Color.Red };
    Color[] colorStand = new Color[] { Color.Green };
    Color[] colorBlock = new Color[] { Color.Black };

    public Tile(int posX, int posY, int width, int height, Texture2D _texture, int column, int row,TileManager _tileManager) :base(posX, posY,width,height,_texture){
        Column =column;
        Row = row;
        tileManager =_tileManager;
        hitbox = new Hitbox(posX,posY,width,height,this,true);
        BasicMovementCost=1;
    }
    public override void OnClick()
    {
        base.OnClick();
        tileManager.OnTileClicked(this);
        // if(character!=null){
        //     tileManager.ShowCharacterReach(character);
        // }
        // else{
        //     tileManager.ClearTileMarks();
        //     MarkBlocked();
        // }
        
    }
    public override void Render(SpriteBatch spriteBatch){
        base.Render(spriteBatch);
        foreach(CharacterObject character in tileManager.Characters){
            if(character.characterInfo.tile == this){
                //character.Render(spriteBatch);
            }
        }
        // if(character!= null){
        //     character.Render(spriteBatch);
        // }
    }
    public void MarkCanMove(){
        InMovementReach=true;
        texture.SetData(colorMove);
    }
    public void MarkCanAttack(){
        InAttackReach = true;
        if(!InMovementReach){
            texture.SetData(colorAttack);
        }
    }
    public void MarkBlocked(){
        IsBlocked=true;
        BasicMovementCost=99;
        texture.SetData(colorBlock);
    }
    public void UnmarkTile(){
        InMovementReach=false;
        InAttackReach=false;
        if(IsBlocked){
            texture.SetData(colorBlock);
        }else{
            texture.SetData(colorStand);
        }
    }
    public int GetMovementCost(){
        return BasicMovementCost;
    }
}