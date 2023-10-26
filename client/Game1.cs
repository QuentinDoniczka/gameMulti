using client.Entites;
using client.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace client
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IInputManager _inputManager;
        private Player _player;
        private Texture2D _playerTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _inputManager = new InputManager();
            _player = new Player(new Vector2(100, 100));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Generate a red circle texture with a radius of 15 pixels
            _playerTexture = CreateCircleTexture(50, Color.Red, Color.Yellow, 5);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector2 direction = _inputManager.GetMovementDirection();
            _player.Move(direction);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_playerTexture, _player.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private Texture2D CreateCircleTexture(int radius, Color fillColor, Color borderColor, int borderWidth)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(GraphicsDevice, diameter, diameter);

            Color[] data = new Color[diameter * diameter];

            int centerX = radius;
            int centerY = radius;

            for (int y = 0; y < diameter; y++)
            {
                for (int x = 0; x < diameter; x++)
                {
                    int dx = centerX - x;
                    int dy = centerY - y;
                    double distanceSquared = dx * dx + dy * dy;

                    // Si le pixel est à l'intérieur du cercle
                    if (distanceSquared <= radius * radius)
                    {
                        // Si le pixel est proche de la bordure externe du cercle, coloriez-le avec la couleur de la bordure
                        if (distanceSquared >= (radius - borderWidth) * (radius - borderWidth))
                        {
                            data[y * diameter + x] = borderColor;
                        }
                        else
                        {
                            data[y * diameter + x] = fillColor;
                        }
                    }
                    else
                    {
                        data[y * diameter + x] = Color.Transparent;
                    }
                }
            }
            texture.SetData(data);
            return texture;
        }
    }
}