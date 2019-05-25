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
    /// Classe base para todos os objetos do jogo
    /// </summary>
    class Entity
    {
        // Atributos
        protected Vector2 position; // Posição 2D
        protected Vector2 velocity; // Velocidade & Direção 2D
        protected float angle; // Angulo do desenho
        protected float scale; // Escala do desenho

        // Métodos

        // init() -> Inicializa variáveis
        public virtual void init() { }

        // load(cM) -> Carrega imagens e sons
        // cM -> Gerenciador de arquivos (Biblioteca)
        public virtual void load(ContentManager cM) { }

        // unload() -> Descarrega o objeto da memória
        public virtual void unload() { }

        // update(gT) -> Lógica do objeto (teclado, mouse, algoritmos)
        // gT -> Controle do tempo (biblioteca)
        public virtual void update(GameTime gT) { }

        // draw(sB) -> Funções de desenho do jogo
        // sB -> Objeto desenhador da biblioteca ("css" do jogo)
        public virtual void draw(SpriteBatch sB) { }

        // Destruir o objeto (remover todas as suas referências)
        public virtual void destroy() { }

        // Alguns getters úteis
        public Vector2 getVelocity()
        {
            return this.velocity;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public float getAngle()
        {
            return angle;
        }
    }
}
