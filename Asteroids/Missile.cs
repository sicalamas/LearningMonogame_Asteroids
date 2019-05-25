using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Asteroids
{
    /// <summary>
    /// Míssil (é criado através de entrada do usuário (player pressiona 'space').
    /// </summary>
    class Missile : Entity
    {
        // Atributos
        GameObjects ownerRef; // Mantém uma referência à lista de objetos (onde os mísseis são adicionados)

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="p">Posição</param>
        /// <param name="v">Velocidade</param>
        /// <param name="a">Ângulo</param>
        /// <param name="gO">Lista de objetos</param>
        public Missile(Vector2 p, Vector2 v, float a, GameObjects gO)
        {
            // Inicializa os atributos
            position = p;
            angle = a;
            velocity.X = (float)Math.Cos(angle); // Define uma direção em função do ângulo em razão
            velocity.Y = (float)Math.Sin(angle); // do ângulo original da espaçonave que dispacha o míssil
            ownerRef = gO;
            scale = GameData.SCALE;
        }

        /// <summary>
        /// Lógica de controle do objeto
        /// </summary>
        /// <param name="gT">Referência a GameTime (Controle do tempo)</param>
        public override void update(GameTime gT)
        {
            updatePosition();
            base.update(gT);
        }

        /// <summary>
        /// Desenho dos gráficos do objeto
        /// </summary>
        /// <param name="sB">Referência a SpriteBatch (Classe "desenhadora" da framework)</param>
        public override void draw(SpriteBatch sB)
        {
                sB.Draw(GameData.gameTexture,
            position,
            new Rectangle(16,48,16,16),
            Color.White,
            angle + MathHelper.ToRadians(90),
            new Vector2(8, 8),
            scale,
            SpriteEffects.None,
            0);
            base.draw(sB);
        }

        /// <summary>
        /// Lógica de movimento para o objeto
        /// </summary>
        private void updatePosition()
        {
            position.X += velocity.X * 10.0f;
            position.Y += velocity.Y * 10.0f;
            // Screen Warp
            if (position.X >= GameData.WIDTH || position.X <= 0 || position.Y >= GameData.HEIGHT || position.Y <= 0)
            {
                destroy();
            }
        }

        /// <summary>
        /// Chamada à lista de objetos para remover este e destruí-lo
        /// </summary>
        public override void destroy()
        {
            ownerRef.destroy(this);
        }
    }
}
