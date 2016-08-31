using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoMmoRL
{
    class Map
    {
        StreamReader sr;
        List<string[]> lines = new List<string[]>();
        public int[,] map;

        public int width,length;

        public Map(string filePath)
        {
            sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string[] tokens = sr.ReadLine().Split(',');
                lines.Add(tokens);
                length++;
            }

            width = lines[0].Length;
            map = new int[width,length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int temp;
                    int.TryParse(lines[i][j], out temp);
                    map[j,i] = temp;
                }
            }

            
        }
    }
}
