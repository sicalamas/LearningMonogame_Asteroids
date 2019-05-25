using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Dados úteis para o funcionamento do jogo (acessíveis globalmente)
    /// </summary>
    class GameData
    {
        // Atributos
        public static Texture2D gameTexture; // Guarda uma referência ao Sprite Sheet (único para este jogo)
        public static SpriteFont gameFont;
        public static readonly int WIDTH = 640; // Largura da tela
        public static readonly int HEIGHT = 480; // Altura da tela
        public static int LIFES = 3; // Nº de vidas do player
        public static int SCORE = 0; // Nº de vidas do player
        public static float SCALE = 2.0f; // Escala global dos desenhos no jogo
        public static bool FULLSCREEN = true; // Define se tela cheia ou não

        /// <summary>
        /// Carrega o sprite sheet na memória (referência única na classe principal)
        /// </summary>
        /// <param name="cM">Referência a ContentManager (Classe utilitária para carregar arquivos de mídia externos)</param>
        public GameData(ContentManager cM)
        {
            gameTexture = cM.Load<Texture2D>("SpriteSheet");
            gameFont = cM.Load<SpriteFont>("Pixeltype");
        }

        /// <summary>
        /// Desenha o contador de vidas (corações no canto superior esquerdo)
        /// </summary>
        /// <param name="sB">Referência a SpriteBatch</param>
        public void drawData(SpriteBatch sB)
        {
            for (int i = 0; i < LIFES; i++)
            {
                sB.Draw(gameTexture, new Rectangle(8 * (int)SCALE * i, 16, 16 * (int)SCALE, 16 * (int)SCALE), new Rectangle(0, 32, 16, 16), Color.White);
            }
            // Draw ponint counting
            sB.DrawString
                (
                GameData.gameFont,
                GameData.SCORE.ToString(),
                new Vector2(4 * GameData.SCALE, 2 * GameData.SCALE),
                Color.White,
                0.0f,
                new Vector2(0, 0),
                GameData.SCALE,
                SpriteEffects.None,
                0
                );
            SCORE += 1;
        }
    }
}
