using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace GitTask
{
    public class Git
    {
        public Git(int filesCount)
        {
            Array.ForEach(Enumerable.Range(0, filesCount)
                .Select(fileNumber => fileNumber.ToString() + ".txt").ToArray(), fileName =>
                {
                    FileStream fs = new FileStream(fileName, FileMode.Create);
                    fs.Close();
                });
        }

        public List<int> test = new List<int>();

        public void Update(int fileNumber, int value)
        {
            this.test.Add(value);
            string path = fileNumber.ToString() + ".txt";
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(value);
            sw.Close();
            fs.Close();
        }

        public int commitNumber = 0;
        public int Commit()
        {
            return this.commitNumber++;
        }

        public int Checkout(int commitNumber, int fileNumber)
        {
            return this.test[commitNumber];
        }
    }
}