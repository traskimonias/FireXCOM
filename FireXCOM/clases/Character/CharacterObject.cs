using Microsoft.Xna.Framework.Graphics;

public class CharacterObject : GameObject2D
{
    public CharacterInfo characterInfo;
    public CharacterObject(int posX, int posY, int _width, int _height,CharacterInfo info, Texture2D _texture):base(posX,posY,_width,_height,_texture){
        characterInfo=info;
    }
    public void LinkToTile(Tile tile){
        position.X= tile.position.X +tile.width/4;
        position.Y= tile.position.Y +tile.height/4;
        characterInfo.LinkToTile(tile);
    }
}