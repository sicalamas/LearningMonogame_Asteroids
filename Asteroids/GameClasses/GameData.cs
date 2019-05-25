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
        public static readonly int WIDTH = 640; // Largura da tela
        public static readonly int HEIGHT = 480; // Altura da tela
        public static int LIFES = 3; // Nº de vidas do player
        public static float SCALE = 2.0f; // Escala global dos desenhos no jogo
        public static bool FULLSCREEN = true; // Define se tela cheia ou não

        /// <summary>
        /// Carrega o sprite sheet na memória (referência única na classe principal)
        /// </summary>
        /// <param name="cM">Referência a ContentManager (Classe utilitária para carregar arquivos de mídia externos)</param>
        public GameData(ContentManager cM)
        {
            gameTexture = cM.Load<Texture2D>("SpriteSheet");
        }

        /// <summary>
        /// Desenha o contador de vidas (corações no canto superior esquerdo)
        /// </summary>
        /// <param name="sB">Referência a SpriteBatch</param>
        public void drawLifes(SpriteBatch sB)
        {
            for (int i = 0; i < LIFES; i++)
            {
                sB.Draw(gameTexture, new Rectangle(8 * (int)SCALE * i, 0, 16 * (int)SCALE, 16 * (int)SCALE), new Rectangle(0, 32, 16, 16), Color.White);
            }
        }
    }
}
