using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Asteroids
{
    // Nave espacial controlada pelo jogador
    class Spaceship : Entity
    {
        // Atributos
        ///CircleF collider; // Area para teste de colisão
        bool isAccelerating; // Teste: Está acelerando?
        float accelIndex; // Índice de aceleração
        float dragIndex; // Índice de desaceleração
        Color myColor; //TODO: implementar cor

        GameObjects entityRef;

        private double secondsPassed = 0.0;
        private bool _allowFire = true;

        public Spaceship(float x, float y, GameObjects e)
        {
            position = new Vector2(x, y);
            entityRef = e;
            myColor = new Color(1.0f, 1.0f, 1.0f); // Color = branca
        }
        public Spaceship(float x, float y, GameObjects e, Color c)
        {
            position = new Vector2(x, y);
            entityRef = e;
            myColor = c; // Recebo cor como parâmetro
        }


        // Métodos
        public override void init()
        {
            // Inicializa os atributos da superclasse
            //position = new Vector2(200, 200);
            velocity = new Vector2(0, 0);
            angle = MathHelper.ToRadians(0); // inicializa a nave em uma direção (traduz graus para radianos)
            scale = GameData.SCALE;
            // Inicializa atributos próprios
            isAccelerating = false;
            accelIndex = 0.1f;
            dragIndex = 0.992f;
            base.init();
        }

        public override void load(ContentManager cM)
        {
            base.load(cM);
        }

        public override void unload()
        {
            base.unload();
        }

        public override void update(GameTime gT)
        {
            getInput(); // Recebe e process entrada do usuário
            updatePosition(); // Altera posição
            updateDrag(); // Desacelera nave

            secondsPassed += gT.ElapsedGameTime.TotalSeconds;
            if (secondsPassed > 0.333)
            {
                secondsPassed -= 0.333;
                allowFire();
            }

            base.update(gT);
        }

        private void allowFire()
        {
            _allowFire = true;
        }

        public override void draw(SpriteBatch sB)
        {
            if (!isAccelerating)
            {
                sB.Draw(GameData.gameTexture,
                position,
                new Rectangle(0, 0, 16, 16),
                myColor,
                angle + MathHelper.ToRadians(90),
                new Vector2(8, 8),
                scale,
                SpriteEffects.None,
                0);
            }
            else
            {
                sB.Draw(GameData.gameTexture,
                position,
                new Rectangle(0, 16, 16, 16),
                myColor,
                angle + MathHelper.ToRadians(90),
                new Vector2(8, 8),
                scale,
                SpriteEffects.None,
                0);
            }
            base.draw(sB);
        }

        // Métodos próprios

        // getInput() -> Receber entrada do usuário
        private void getInput()
        {
            isAccelerating = false;


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _allowFire)
            {
                fire();
                Console.WriteLine("Fire!");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                isAccelerating = true;
                accelerate();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                angle -= 0.033f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                angle += 0.033f;
            }

        }

        // accelerate() -> Acelera a nave (Bidimensional projectile motion)
        private void accelerate()
        {
            float x, y;
            x = accelIndex * (float)Math.Cos(angle);
            y = accelIndex * (float)Math.Sin(angle);

            updateVelocity(x, y);
        }

        private void updateVelocity(float x, float y)
        {
            velocity.X += x;
            velocity.Y += y;
        }

        private void updatePosition()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;
            // Screen Warp
            if (position.X >= GameData.WIDTH)
                position.X = 0;
            else if (position.X <= 0)
                position.X = GameData.WIDTH;
            else if (position.Y >= GameData.HEIGHT)
                position.Y = 0;
            else if (position.Y <= 0)
                position.Y = GameData.HEIGHT;
        }

        private void updateDrag()
        {
            velocity.X *= dragIndex;
            velocity.Y *= dragIndex;
        }

        private void fire()
        {
            entityRef.createMissile(this);
            _allowFire = false;
        }
    }
}
