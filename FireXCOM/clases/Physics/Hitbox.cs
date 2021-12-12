public class Hitbox
{
    public GameObject2D parent;
    int x,y,width,height;
    public bool Enabled;

    public Hitbox(int posX, int posY, int _width, int _height,GameObject2D _parent, bool enable=true){
        x = posX;
        y = posY;
        width = _width;
        height = _height;
        parent = _parent;
        Enabled = enable;
    }
    public Hitbox(GameObject2D _parent, bool enable = true){
        parent = _parent;
        x = (int)parent.position.X;
        y = (int)parent.position.Y;
        width = parent.width;
        height = parent.height;
        Enabled = enable;
    }
    public bool CheckClicked(int clickX, int clickY){
        if(clickX<x || clickY<y) return false;
        if(clickX>(x+width) || clickY>(y+height)) return false;
        return true;
    }
}