using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aho_Corasick
{
    internal class Aho_Corasick
    {
       public TrieAhoCorasick Root { get; private set; }
        public string[] dict { get; private set; }
        
        public Aho_Corasick(string[] dict )
        {
            this.dict = dict;
            this.Root = new TrieAhoCorasick('$');
            this.Root.FailLink = Root;
           }
        public void init_All()
        {
            this.Root.WordIndex = -1;
            init_children();
            init_failLinks(Root);
            init_DictLinks(this.Root);
        }

        public void run(string text)
        {
            TrieAhoCorasick trie = Root;
            int cnt = 0;
          
            while (cnt<= text.Length)
            {
                if (trie.DictionaryLink != null)
                    Console.WriteLine("Found Word: {0} in index dict   {1} : {2}", this.dict[trie.DictionaryLink.WordIndex], cnt - dict[trie.DictionaryLink.WordIndex].Length, cnt);
                if (trie.WordIndex>-1)
                {
                    Console.WriteLine("Found Word {0} in index       {1} : {2}", dict[trie.WordIndex], cnt - dict[trie.WordIndex].Length, cnt);
                }
                if (cnt<text.Length)
                {
                    if (trie.Children.ContainsKey(text[cnt]))
                    {
                        trie = (TrieAhoCorasick)trie.Children[text[cnt]];
                        cnt++;
                    }
                    else if (!trie.Children.ContainsKey(text[cnt])&&trie ==this.Root)
                        cnt++;  
                    else
                        trie = trie.FailLink;
                }
                else
                    cnt++;  
            }
               
        }
      
         
        private TrieAhoCorasick[] ConvertICollectionToTrieArray(ICollection Values)
        {
            TrieAhoCorasick[] toReturn = new TrieAhoCorasick[Values.Count];
             Values.CopyTo(toReturn,0);
            return toReturn;
        }
        private void init_failLink(TrieAhoCorasick node, TrieAhoCorasick father)
        {
            bool puttenFailLink = false;

            while (!puttenFailLink)
            {
                TrieAhoCorasick[] fatherChildrenFailLink = ConvertICollectionToTrieArray(father.FailLink.Children.Values);
                for (int i = 0;!puttenFailLink && i < fatherChildrenFailLink.Length; i++)
                {
                    if (fatherChildrenFailLink[i].Value == node.Value && node.GetHashCode() != fatherChildrenFailLink[i].GetHashCode())
                    {
                        node.FailLink = fatherChildrenFailLink[i];
                        puttenFailLink = true;
                    }
                    else if (father == this.Root)
                    {
                        node.FailLink = father;
                        puttenFailLink = true;
                    }
                }
                father = father.FailLink;
            }

        }
        private void init_failLinks(TrieAhoCorasick CurRoot)
        {
            TrieAhoCorasick[] RootChildren = ConvertICollectionToTrieArray(CurRoot.Children.Values);
            for (int i = 0; i < RootChildren.Length; i++)
            {
                init_failLink( RootChildren[i], CurRoot);
            }
            for (int i = 0; i < RootChildren.Length; i++)
            {
                init_failLinks(RootChildren[i]);
            }
            if (Root.Children.Count == 0)
                return;
        }
        private void init_DictLinks(TrieAhoCorasick Root)
        {
            TrieAhoCorasick[] RootChildren = ConvertICollectionToTrieArray(Root.Children.Values);
            for (int i = 0; i < RootChildren.Length; i++)
            {
                init_DictLink(RootChildren[i]);
                init_DictLinks(RootChildren[i]);
            }
            if (Root.Children.Count ==0)
            {
                return;
            }
        }
        private void init_DictLink(TrieAhoCorasick trie)
        {
            TrieAhoCorasick PointToFirst = trie;
            bool finished = false;
            while (trie!=this.Root && !finished)
            {
                if (trie.WordIndex>-1 &&trie!=PointToFirst)
                {
                    PointToFirst.DictionaryLink = trie;
                    finished = true;
                }
                trie = trie.FailLink;
            }
        }

        private int GetIndexOfWord(string word)
        {
            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i]==word)
                    return i;
            }
            return -1;
        }
        private void init_children()
        {
            for (int i = 0; i < dict.Length; i++)
            {
                insertWord(dict[i], 0, this.Root);
            }
        }
        private TrieAhoCorasick insertWord(string word, int pos, TrieAhoCorasick Root )
        {
            if (pos == word.Length - 1)
            {
                int wordIndex = GetIndexOfWord(word);
                Root.Children.Add( word[pos],new TrieAhoCorasick(word[pos], wordIndex));
                return new TrieAhoCorasick(word[pos], wordIndex);
             }
           else if (!Root.Children.ContainsKey(word[pos]))
            {
                Root.Children.Add(word[pos], new TrieAhoCorasick(word[pos], -1));
                return insertWord(word, pos + 1, (TrieAhoCorasick)Root.Children[word[pos]]);
            }
            else
                return insertWord(word, pos + 1, (TrieAhoCorasick)Root.Children[word[pos]]);
          
        }


    }
}
