using Microsoft.Xna.Framework.Graphics;

public class CharacterObject : GameObject2D
{
    public CharacterInfo characterInfo;
    public int actionsLeft=0;
    public int maxActions=2;
    public int team;
    public CharacterObject(int posX, int posY, int _width, int _height,CharacterInfo info, Texture2D _texture,int _team):base(posX,posY,_width,_height,_texture){
        characterInfo=info;
        team = _team;
        actionsLeft=maxActions;
    }
    public void LinkToTile(Tile tile){
        position.X= tile.position.X +tile.width/4;
        position.Y= tile.position.Y +tile.height/4;
        characterInfo.LinkToTile(tile);
    }

}