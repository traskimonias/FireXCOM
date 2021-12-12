using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
public class Jugador : GameObject2D
{
    public Jugador(int x, int y, int _width, int _height, Texture2D _texture):base(x,y,_width,_height,_texture)
    {    
    }
    public override void Update(GameTime gameTime){
        position.X+=1;
    }
}