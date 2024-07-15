using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aho_Corasick
{
  
        class Node<T>
        {
            T value;
            Node<T> next;

            //Constractors
            public Node(T value)
            {
                this.value = value;
            }
            public Node(Node<T> next, T value)
            {
                this.next = next;
                this.value = value;
            }
            //Gets & sets
            public T GetValue()
            {
                return this.value;
            }
            public Node<T> GetNext()
            {
                return this.next;
            }
            public bool hasNext()
            {
                return !(next == null);
            }
            public override string ToString()
            {
                return $"{value}";
            }
            //commands
            public void setValue(T x)
            {
                this.value = x;
            }
            public void setNext(Node<T> next)
            {
                this.next = next;
            }
        }
    }

