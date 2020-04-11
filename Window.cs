using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ModelBdv = bdv.Model;

using Scripts;

namespace bdv
{
    public class Window : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Core engine = new Core();

        Loader RunScripts = new Loader();

        public Window()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = RunScripts.ScriptToLoad.Resolution.Width;
            graphics.PreferredBackBufferHeight = RunScripts.ScriptToLoad.Resolution.Height;
        }

        protected override void Initialize()
        {
            var objects = RunScripts.ScriptToLoad.Entities;
            foreach (var obj in objects)
            {
                engine.render.RequestQueue().Enqueue(obj);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            RunScripts.ScriptToLoad.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            RGBA BackgroundColor = RunScripts.ScriptToLoad.BackgroundColor;
            GraphicsDevice.Clear(new Color(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B));
            var objects = engine.render.RequestQueue().GetQueue();

            spriteBatch.Begin();

            foreach (var obj in objects)
            {
                switch (obj.mdl)
                {
                    case ModelBdv.PIXEL:
                        {
                            Color[] data = new Color[obj.dimension.Width * obj.dimension.Height];
                            Texture2D rectTexture = new Texture2D(GraphicsDevice, obj.dimension.Width,
                             obj.dimension.Height);

                            for (int i = 0; i < data.Length; ++i)
                                data[i] = new Color(obj.color.R, obj.color.G, obj.color.B);

                            rectTexture.SetData(data);
                            var position = new Vector2(obj.position.x, obj.position.y);

                            spriteBatch.Draw(rectTexture, position, new Color(obj.color.R, obj.color.G, obj.color.B));
                            break;
                        }
                    case ModelBdv.TEXTURE:
                        {
                            Texture2D tex = Content.Load<Texture2D>(obj.texture.filepath);
                            spriteBatch.Draw(tex, new Rectangle((int)obj.position.x, (int)obj.position.y,
                                obj.dimension.Width, obj.dimension.Height), Color.White);

                            break;
                        }
                    case ModelBdv.SPRITESHEET:
                        {
                            Texture2D tex = Content.Load<Texture2D>(obj.sprite.filepath);
                            spriteBatch.Draw(tex,
                                new Rectangle((int)obj.position.x, (int)obj.position.y, obj.dimension.Width, obj.dimension.Height),
                                new Rectangle(obj.sprite.spriteWidth.x,
                                    obj.sprite.spriteHeight.y, obj.sprite.spriteWidth.y, obj.sprite.spriteHeight.y),
                                    Color.White);
                            break;
                        }
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
