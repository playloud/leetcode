using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    public class MergeTwoLinkedLists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode root = null;
            ListNode rootCursor = null;

            root = new ListNode(9999);
            rootCursor = root;
            
            ListNode cursorL1 = l1;
            ListNode cursorL2 = l2;

            while(true)
            {
                if(cursorL1 == null && cursorL2 == null)
                {
                    break;
                }
                else if(cursorL1 != null && cursorL2 == null)
                {
                    root.next = cursorL1;
                    root = root.next;
                    cursorL1 = cursorL1.next;
                }
                else if (cursorL1 == null && cursorL2 != null)
                {
                    root.next = cursorL2;
                    root = root.next;
                    cursorL2 = cursorL2.next;
                }
                else
                {
                    if(cursorL1.val < cursorL2.val)
                    {
                        root.next = cursorL1;
                        root = root.next;
                        cursorL1 = cursorL1.next;
                    }
                    else
                    {
                        root.next = cursorL2;
                        root = root.next;
                        cursorL2 = cursorL2.next;
                    }
                }
            }
            return rootCursor.next;
        }

        public void Dump(ListNode l)
        {
            while (true)
            {
                if (l == null)
                    break;
                if (l != null)
                    Console.WriteLine(l.val);
                l = l.next;
            }
        }

        public void Test()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(3);
            l1.next.next = new ListNode(5);
            l1.next.next.next = new ListNode(7);

            ListNode l2 = new ListNode(2);
            l2.next = new ListNode(4);
            l2.next.next = new ListNode(6);
            l2.next.next.next = new ListNode(8);
            
            Dump(MergeTwoLists(l1, l2));
        }
    }
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
     }
}
