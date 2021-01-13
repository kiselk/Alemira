using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class OwnCollection : ArrayList
    {

        private ArrayList collection;

        public OwnCollection(string fileName)
        {
            collection = new ArrayList();
            collection.AddRange(File.ReadAllLines(fileName));

        }

        public void AppendFrom(string fileName)
        {
            collection.AddRange(File.ReadAllLines(fileName));
        }

        public string Find(string s)
        {
            var query = from string eachString in collection
                        where eachString.Contains(s)
                        select eachString;

            return query.First();
        }
    }
}
