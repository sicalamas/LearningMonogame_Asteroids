using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Asteroids
{
    /// <summary>
    /// Classe principal do jogo
    /// </summary>
    public class Game1 : Game
    {
        // Atributos
        GraphicsDeviceManager graphics; // Administrador de gráficos
        SpriteBatch spriteBatch; // Classe "desenhadora" da framework
        GameObjects gameObjects; // Listão de objetos (padrão observer)
        GameData gameData; // Dados globais para o jogo

        /// <summary>
        /// Construtor
        /// </summary>
        public Game1()
        {
            // Instanciações da framework
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Configurações para os objetos do jogo
            gameObjects = new GameObjects(); // Instancia o listão de objetos
            gameObjects.createPlayer(GameData.WIDTH/2,GameData.HEIGHT/2); // Instancia N players
            gameObjects.createAsteroids(30); // Instancia N asteróides (20 nesse caso)

            // Configurações da tela do jogos
            graphics.PreferredBackBufferWidth = GameData.WIDTH;
            graphics.PreferredBackBufferHeight = GameData.HEIGHT;
            graphics.IsFullScreen = GameData.FULLSCREEN;
        }

        /// <summary>
        /// Permite que o jogo execute qualquer inicialização que precise antes de começar a correr.
        /// Aqui é onde ele pode consultar qualquer serviço necessário e carregar qualquer elemento não gráfico.
        /// Conteúdo Relacionado. Chamando base.Initialize irá enumerar através de quaisquer componentes
        /// e inicialize-os também.
        /// </summary>
        protected override void Initialize()
        {
            gameObjects.init();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent será chamado uma vez por jogo e é o lugar para carregar
        /// todo o seu conteúdo (arquivos externos de mídia, imagens, audio etc).
        /// </summary>
        protected override void LoadContent()
        {
            // Cria um novo SpriteBatch, que pode ser usado para desenhar texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameObjects.load(Content);
            gameData = new GameData(Content);
        }

        /// <summary>
        /// UnloadContent será chamado uma vez por jogo e é o lugar para descarregar
        /// conteúdo específico do jogo.
        /// </summary>
        protected override void UnloadContent()
        {
            gameObjects.unload();
        }

        /// <summary>
        /// Permite que o jogo execute uma lógica como atualizar o mundo,
        /// checando colisões, reunindo entradas e reproduzindo áudio.
        /// </summary>
        /// <param name="gameTime">Dados e controle de tempo.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            gameObjects.update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Isso é chamado quando o jogo deve se desenhar.
        /// </summary>
        /// <param name="gameTime">Dados e controle de tempo.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // Pinta o fundo de preto

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            gameObjects.draw(spriteBatch); // Chamadas aos desenhos de todos os objetos do listão
            spriteBatch.DrawRectangle(new RectangleF(0, 0, GameData.WIDTH, GameData.HEIGHT), Color.White, 2.0f); // Desenho do retângulo branco (bordas da tela)
            gameData.drawLifes(spriteBatch); // Chamada ao desenho dos corações (contadores de vida)
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
