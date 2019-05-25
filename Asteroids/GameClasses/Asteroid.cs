using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Asteroids
{
    enum AsteroidTypes
    {
        Big,
        Medium,
        Small
    }
    class Asteroid : Entity
    {
        // Atributos
        AsteroidTypes type;
        //float radius; // TODO: implementar raio como determinante para área colisão
        int spriteSize;
        Rectangle spriteRectangle;


        public Asteroid(float x, float y, AsteroidTypes t)
        {
            position.X = x;
            position.Y = y;
            setVelocity();
            type = t;
        }

        private void setAsteroid()
        {
            switch (type)
            {
                case AsteroidTypes.Big:
                    spriteSize = 32;
                    spriteRectangle = new Rectangle(32, 0, spriteSize, spriteSize);
                    // TODO: Configurar tamanho do colisor
                    break;
                case AsteroidTypes.Medium:
                    spriteSize = 16;
                    spriteRectangle = new Rectangle(48, 48, spriteSize, spriteSize);
                    // TODO: Configurar tamanho do colisor
                    break;
                case AsteroidTypes.Small:
                    spriteSize = 8;
                    spriteRectangle = new Rectangle(32, 48, spriteSize, spriteSize);
                    // TODO: Configurar tamanho do colisor
                    break;
            }
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

        private void setVelocity()
        {
            Random rand = new Random(this.GetHashCode());
            velocity.X = (float)rand.Next(-10, 10) / 10;
            velocity.Y = (float)rand.Next(-10, 10) / 10;
        }

        public override void init()
        {
            //Random rand = new Random((int)GameData.gameTime.ElapsedGameTime.TotalMilliseconds);
            Random rand = new Random(this.GetHashCode());
            angle = rand.Next(0, 7);
            scale = GameData.SCALE;

            setAsteroid();

            base.init();
        }

        public override void update(GameTime gT)
        {
            angle += 0.03f;
            updatePosition();
            base.update(gT);
        }

        public override void draw(SpriteBatch sB)
        {
            sB.Draw(GameData.gameTexture,
        position,
        spriteRectangle,
        Color.White,
        angle + MathHelper.ToRadians(90),
        new Vector2(spriteSize / 2, spriteSize / 2),
        scale,
        SpriteEffects.None,
        0);
            base.draw(sB);
        }
    }
}