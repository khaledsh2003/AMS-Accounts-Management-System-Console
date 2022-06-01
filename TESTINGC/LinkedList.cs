using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTINGC
{
    using System;

    //node structure
   
    class LinkedList: Node // class made by me. One is on google
    {
        public Node head;
        public Node last=new Node();
        //constructor to create an empty LinkedList
        public LinkedList()
        {
            head = null;
            last = head;
        }

        public void addTostart(string number1)
        {
            
            Node new_node = new Node();
            new_node.data = number1;
            new_node.id += 1;
            new_node.next = null;
            if (head == null)
        
            {
                head = new_node;
                last= new_node;
            
                 return;
            }
            
            
            last.next = new_node;
            last = new_node;

        }

        //display the content of the list
        public void PrintList()
        {
            Node start = null;
            start = head;
            while (start != null)
            {
                Console.WriteLine("Connect: "+start.data+" ID: "+id);
                start = start.next;
            }
        }
        public void DeleteNode(string num1)
        {
            Node temp1=new Node();
            temp1 = head;
            if(temp1.data==num1)
            {
                head = head.next;
                return;
            }

            while (temp1 != null && temp1.next.data != num1)
            {
                temp1=temp1.next;
            }
            temp1.next=temp1.next.next;

        }

       
    };

    
       
}
