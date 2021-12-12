using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

public class RenderingManager
{
    public List<GameObject2D> gameObjects;
    public RenderingManager(){
        gameObjects = new List<GameObject2D>();
    }
    public void AddGameObject(GameObject2D gameObject){
        if(gameObject==null){

        }
        gameObjects.Add(gameObject);
    }
    public void RenderAll(SpriteBatch spriteBatch){
        foreach(GameObject2D objeto2D in gameObjects){
            try
            {
                objeto2D.Render(spriteBatch); 
            }
            catch (System.Exception)
            {
                Debug.ShowText("Error renderizando");
            }
        }
    }
}