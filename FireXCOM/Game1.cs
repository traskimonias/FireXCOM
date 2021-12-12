using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FireXCOM
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PhysicsManager physicsManager = new PhysicsManager();
        private RenderingManager renderingManager = new RenderingManager();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            int posX = 2;
            int posY = 2;
            int columnas = 7; //19
            int filas = 7; //11
            int margen = 2;
            int altura = 40;
            int anchura = 40;
            TileManager tileManager = new TileManager(posX,posY,filas,columnas,margen,altura,anchura,GraphicsDevice);
            Texture2D texture2D = new Texture2D(GraphicsDevice,1,1);
            texture2D.SetData(new Color[] { Color.Yellow });
            CharacterInfo character = new CharacterInfo(texture2D);
            physicsManager.AddGameObject(tileManager);
            renderingManager.AddGameObject(tileManager);
            tileManager.AddCharacter(character,5,5);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            physicsManager.UpdateAll(gameTime);
            physicsManager.clickController.UpdateClicks(Mouse.GetState(Window));
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            renderingManager.RenderAll(_spriteBatch);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
