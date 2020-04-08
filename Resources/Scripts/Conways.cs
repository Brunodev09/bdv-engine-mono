using bdv;
using System;
using System.Collections.Generic;

namespace Scripts
{
    public class Conways : IScript
    {

        public List<Entity> Entities { get; set; }
        public List<Entity> BufferedEntities { get; set; }

        public int[,] Matrix;
        public int[,] BufferedMatrix;
        public RGBA BackgroundColor { get; set; }
        public Dimension Resolution { get; set; }
        public int rows = 100;
        public int cols = 100;
        public RGBA AliveColor;
        public RGBA DeadColor;
        public int EvolutionTick;
        private Random rand = new Random();

        public Conways()
        {
            Resolution = new Dimension(800, 600);
            BackgroundColor = new RGBA(255, 255, 255, 255);
            Entities = new List<Entity>();
            BufferedEntities = new List<Entity>();

            Matrix = new int[rows, cols];
            BufferedMatrix = new int[rows, cols];

            var tileSize = new Dimension(Resolution.Width / rows, Resolution.Height / cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rand.Next(1, 10) == 1)
                    {
                        Matrix[i, j] = 1;
                        BufferedMatrix[i, j] = 1;

                        Entities.Add(new Entity(
                        Point<float>.Factory(tileSize.Width * i + i, tileSize.Height * j + j),
                        tileSize,
                        new RGBA(255, 255, 0, 255)));
                    }
                    else
                    {
                        Matrix[i, j] = 0;
                        BufferedMatrix[i, j] = 0;

                        Entities.Add(new Entity(
                        Point<float>.Factory(tileSize.Width * i + i, tileSize.Height * j + j),
                        tileSize,
                        new RGBA(0, 0, 0, 255)));
                    }
                }
            }
        }

        public bool ShouldDie(Point<int> p)
        {
            int Neighbours = 0;
            bool CellStatus = Matrix[p.x, p.y] == 0 ? false : true;

            if (p.x < rows - 1 && Matrix[p.x + 1, p.y] == 1)
            {
                Neighbours++;
            }
            if (p.x > 0 && Matrix[p.x - 1, p.y] == 1)
            {
                Neighbours++;
            }
            if (p.y < cols - 1 && Matrix[p.x, p.y + 1] == 1)
            {
                Neighbours++;
            }
            if (p.y > 0 && Matrix[p.x, p.y - 1] == 1)
            {
                Neighbours++;
            }
            if (p.x < rows - 1 && p.y < cols - 1 && Matrix[p.x + 1, p.y + 1] == 1)
            {
                Neighbours++;
            }
            if (p.x > 0 && p.y < cols - 1 && Matrix[p.x - 1, p.y + 1] == 1)
            {
                Neighbours++;
            }
            if (p.x < rows - 1 && p.y > 0 && Matrix[p.x + 1, p.y - 1] == 1)
            {
                Neighbours++;
            }
            if (p.x > 0 && p.y > 0 && Matrix[p.x - 1, p.y - 1] == 1)
            {
                Neighbours++;
            }

            if (CellStatus)
            {
                if (Neighbours < 2 || Neighbours > 3) return true;
                if (Neighbours == 2 || Neighbours == 3) return false;
                return true;
            }
            else if (!CellStatus && Neighbours == 3) return false;
            else return true;
        }
        public void Update()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bool Status = ShouldDie(Point<int>.Factory(i, j));
                    if (!Status)
                    {
                        BufferedMatrix[i, j] = 1;
                    }
                    else
                    {
                        BufferedMatrix[i, j] = 0;
                    }

                }
            }

            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        Entities[counter].color = new RGBA(255, 255, 0, 255);
                    }
                    else
                    {
                        Entities[counter].color = new RGBA(0, 0, 0, 255);
                    }
                    counter++;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Matrix[i, j] = BufferedMatrix[i, j];
                }
            }

        }

    }
}