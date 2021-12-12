using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class GameObject2D
{
    public int width,height;
    public Vector2 position;
    public Texture2D texture;
    public bool Enabled = true;
    public Hitbox hitbox;
    public List<GameObject2D> Children;
    public GameObject2D(int x, int y, int _width, int _height, Texture2D _texture){
        position.X= x;
        position.Y=y;
        width = _width;
        height = _height;
        texture = _texture;
        Children = new List<GameObject2D>();
        
    }
    public virtual void Update(GameTime gameTime){
        //do something
        
    }
    public virtual void OnClick(){

    }
    public virtual void Render(SpriteBatch spriteBatch){
        //render itself
        if(texture==null) return;
        spriteBatch.Draw(texture,position, new Rectangle((int)position.X,(int)position.Y, width, height),
            Color.Chocolate);

    }
}