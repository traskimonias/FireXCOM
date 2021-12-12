using Microsoft.Xna.Framework.Graphics;

public class CharacterInfo
{
    int vida= 5;
    public int movement = 5;
    public Tile tile;
    public Texture2D texture;
    public CharacterInfo(Texture2D _texture){
        texture = _texture;
    }
    public void LinkToTile(Tile _tile){
        tile = _tile;
    }

}