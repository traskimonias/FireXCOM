using System.Collections.Generic;
using Microsoft.Xna.Framework;
public class PhysicsManager
{
    public List<GameObject2D> gameObjects;
    public ClickController clickController;
    public PhysicsManager(){
        gameObjects = new List<GameObject2D>();
        clickController = new ClickController(this);
    }
    public void AddGameObject(GameObject2D gameObject){
        if(gameObject==null){

        }
        gameObjects.Add(gameObject);
    }
    public void UpdateAll(GameTime gameTime){
        foreach(GameObject2D objeto2D in gameObjects){
            try
            {
                objeto2D.Update(gameTime); 
            }
            catch (System.Exception)
            {
                Debug.ShowText("Error en la actualización");
            }
        }
    }
}