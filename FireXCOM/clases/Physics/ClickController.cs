using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;


public class ClickController
{
    PhysicsManager physicsManager;
    private static MouseState previousMouseState;
    private static MouseState currentMouseState;
    public ClickController(PhysicsManager _physicsManager){
        physicsManager = _physicsManager;
    }
    public int SendClick(int clickX, int clickY){
        int clicked = 0;
        clicked += CheckAndPerformClick(clickX, clickY,physicsManager.gameObjects);
        
        return clicked;
    }
    public int CheckAndPerformClick (int clickX, int clickY, List<GameObject2D> checks){
        int clicked = 0;
        foreach(GameObject2D gameObject in checks){
            if(gameObject.hitbox != null && gameObject.hitbox.CheckClicked(clickX,clickY)){
                clicked ++;
                gameObject.OnClick();
            }
            if(gameObject.Children.Count != 0){
                clicked += CheckAndPerformClick(clickX,clickY,gameObject.Children);
            }
        }
        return clicked;
    }
    public int SendKeep(int clickX, int clickY){
        int keeped = 0;
        
        return keeped;
    }
    public void UpdateClicks(MouseState mouseState){
        currentMouseState = mouseState;
        if(CheckJustClick()){
            SendClick(mouseState.Position.X, mouseState.Position.Y);
        } 
        

        previousMouseState = currentMouseState;
    }
    private bool CheckJustClick(){
        return previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed;
    }
}