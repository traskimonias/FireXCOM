using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

public class TileManager : GameObject2D
{
    Vector2 Anchor;
    int RowNumber= 0;
    int ColNumber = 0;
    int Margin =0;
    int TileHeight=0;
    int TileWidth = 0;
    Dictionary<string,Tile> HashTileMap;
    Dictionary<string,int> HashPathFinding;
    public List<CharacterObject> Characters;
    private CharacterObject SelectedCharacter=null;
    

    
    public TileManager(int x, int y, int rows, int columns, int margin, int tileWidth, int tileHeight, GraphicsDevice graphicsDevice)
        :base(x,y,0,0,null)
    {
        HashTileMap = new Dictionary<string, Tile>();
        HashPathFinding = new Dictionary<string, int>();
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        RowNumber = rows;
        ColNumber = columns;
        Margin = margin;
        Characters = new List<CharacterObject>();
        //For testing
        Random random = new Random();
        Anchor = new Vector2(x,y);
        
        for(int i = 0; i< rows; i++){
            for(int j= 0; j<columns; j++){
                int tileX = TileWidth*j + Margin*j +x;
                int tileY = TileHeight*i + Margin*i+y;
                Texture2D texture2D = new Texture2D(graphicsDevice,1,1);
                // texture2D.SetData(new Color[] { new Color(random.Next(0,255),random.Next(0,255),random.Next(0,255)) });
                texture2D.SetData(new Color[] { Color.Green});
                Tile tile = new Tile(tileX,tileY,tileWidth,tileHeight,texture2D,j,i,this);
                HashTileMap[$"{j}-{i}"] = tile;
                HashPathFinding[$"{j}-{i}"] = -1;
                Children.Add(tile);
            }
        }
    }

    public override void Render(SpriteBatch spriteBatch){
        foreach(Tile tile in Children){
            tile.Render(spriteBatch);
        }
        foreach(CharacterObject character in Characters){
            character.Render(spriteBatch);
        }
    }
    public void AddCharacter(CharacterInfo characterInfo, int column, int row){
        foreach(Tile tile in Children){
            if(tile.Column == column && tile.Row == row){
                int charX = Convert.ToInt32(tile.position.X + tile.width/4);
                int charY = Convert.ToInt32(tile.position.Y + tile.height/4);
                int charWidth = Convert.ToInt32(tile.width/2);
                int charHeight = Convert.ToInt32(tile.height/2);
                CharacterObject  character = new CharacterObject(charX,charY,charWidth,charHeight,characterInfo, characterInfo.texture);
                Characters.Add(character);
                tile.character = character;
                characterInfo.LinkToTile(tile);
            }
        }
    }
    
    public void ShowCharacterReach(CharacterObject character){
        MarkCanMove(character.characterInfo.movement,character.characterInfo.tile);
    }
    public void ShowPathFinding(){
        string thisLine="";
        for(int i = 0; i< RowNumber;i++){
            thisLine+=$"{i}\t";
            for(int j=0; j<ColNumber;j++){
                thisLine+=HashPathFinding[$"{j}-{i}"].ToString()+"|";
            }
            thisLine+="\n";
        }
    }
    void MarkCanMove(int movementLeft, Tile tileFrom){
        movementLeft-= tileFrom.GetMovementCost();
        if(movementLeft>=0){
            if(HashPathFinding[$"{tileFrom.Column}-{tileFrom.Row}"]>=movementLeft){
                return;
            }
            HashPathFinding[$"{tileFrom.Column}-{tileFrom.Row}"] = movementLeft;
            tileFrom.MarkCanMove();
            //Check the movement in for directions
            if(RowNumber>tileFrom.Row+1){
                //Check down
                MarkCanMove(movementLeft,HashTileMap[$"{tileFrom.Column}-{tileFrom.Row+1}"]);
            }
            if(tileFrom.Row>0){
                //Check top
                MarkCanMove(movementLeft,HashTileMap[$"{tileFrom.Column}-{tileFrom.Row-1}"]);
            }
            if(ColNumber>tileFrom.Column+1){
                //Check right
                MarkCanMove(movementLeft,HashTileMap[$"{tileFrom.Column+1}-{tileFrom.Row}"]);
            }
            if(tileFrom.Column>0){
                //Check left
                MarkCanMove(movementLeft,HashTileMap[$"{tileFrom.Column-1}-{tileFrom.Row}"]);
            }
        }
        else{
            MarkCanAttack(1,tileFrom);
        }
    }
    void MarkCanAttack(int attackRange,Tile tileFrom){
        if(attackRange>=0) tileFrom.MarkCanAttack();
        attackRange -=1;
        if(attackRange<=0) return;
        
        if(RowNumber>tileFrom.Row+1){
            //Check down
            MarkCanAttack(attackRange,HashTileMap[$"{tileFrom.Column}-{tileFrom.Row+1}"]);
        }
        if(tileFrom.Row>0){
            //Check top
            MarkCanAttack(attackRange,HashTileMap[$"{tileFrom.Column}-{tileFrom.Row-1}"]);
        }
        if(ColNumber>tileFrom.Column+1){
            //Check right
            MarkCanAttack(attackRange,HashTileMap[$"{tileFrom.Column+1}-{tileFrom.Row}"]);
        }
        if(tileFrom.Column>0){
            //Check left
            MarkCanAttack(attackRange,HashTileMap[$"{tileFrom.Column-1}-{tileFrom.Row}"]);
        }
    }
    public void ClearTileMarks(){
        //Reset tiles color back to normal
        foreach(Tile tile in Children){
            tile.UnmarkTile();
        }
        string[] keys = new string[HashPathFinding.Count];
        HashPathFinding.Keys.CopyTo(keys,0);
        foreach(string key in keys){
            HashPathFinding[key]=-1;
        }
    }
    public void OnTileClicked(Tile tile){
        CharacterObject tileCharacter = null;
        foreach(CharacterObject character in Characters){
            if(character.characterInfo.tile == tile){
                tileCharacter = character;
            }
        }
        if(tileCharacter!=null){
            SelectedCharacter= tileCharacter;
            ShowCharacterReach(tileCharacter);   
        }else{
            if(tile.InMovementReach && SelectedCharacter!= null){
                MoveCharacter(SelectedCharacter,tile);
                ClearTileMarks();
            }else{
                ClearTileMarks();
                tile.MarkBlocked();
            }
        }
    }
    void MoveCharacter(CharacterObject characterToMove, Tile goalTile){
        characterToMove.LinkToTile(goalTile);
    }
    
}