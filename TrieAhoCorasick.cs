using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aho_Corasick
{
    internal class TrieAhoCorasick
    {
        public char Value { get; private set; }
        public int WordIndex { get; set; } // if not  a word = -1
        public Hashtable Children { get; set; }
        public TrieAhoCorasick FailLink { get;  set; }
        public TrieAhoCorasick DictionaryLink { get;  set; }

        public TrieAhoCorasick(char value,Hashtable Children)
        {
            Value = value;
            this.Children = Children;
            this.Children = new Hashtable();
        }
        public TrieAhoCorasick(char value )
        {
            Value = value;
            this.Children = new Hashtable();
            
        }
        public TrieAhoCorasick(char value, int word)
        {
            Value = value;
            this.WordIndex = word;
            this.Children = new Hashtable();

        }
     



    }
}
