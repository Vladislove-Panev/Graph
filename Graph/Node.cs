using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Node
    {
        public List<Node> nexts;
        public Node last;
        public NodeValue value;
        public Node nodeFinded;
        public Node()
        {
            nexts = new List<Node>();
            value = new NodeValue();
        }
        public void Create()
        {
            for (int j = 1; j < Segments.StonesForWin; j++)
            {
                value.numberOfStones = j;
                value.startNumberOfStones = j;
                CreateGraph();
            }
        }
        public void CreateGraph()
        {
            foreach (String i in Segments.Actions)
            {
                if (value.numberOfMove < 3)
                {
                    Node newNode = new Node();
                    newNode.value = value.Copy();
                    newNode.value.Move(i);
                    nexts.Add(newNode);
                    newNode.last = this;
                    newNode.CreateGraph();
                }
            }

        }
        public Node FindResult(Node node)
        {

            if (node.nexts.Count != 0)
            {
                foreach (Node n in node.nexts)
                {
                    node = n;
                    FindResult(n);
                }
            }
            else
            {
                if (node.last != null && node.last.value.numberOfStones < Segments.StonesForWin && node.value.numberOfStones >= Segments.StonesForWin)
                {
                    if (nodeFinded == null)
                    {
                        nodeFinded = new Node();
                    }

                    nodeFinded.nexts.Add(node);

                }
            }
            return nodeFinded;
        }
        public Node FindThen(Node node)
        {
            Node node1 = new Node();
            NodeValue m1, m2, m3;
            bool isFinish = false;
            int umn = 0, max = 0;
            foreach (String a in Segments.Actions)
            {
                if (a.Contains('*'))
                {
                    if (umn < Convert.ToInt32(a.Substring(1)))
                    {
                        umn = Convert.ToInt32(a.Substring(1));
                        isFinish = true;
                    }
                }
            }
            foreach (String a in Segments.Actions)
            {
                if (a.Contains('*'))
                {
                    if (max < Convert.ToInt32(a.Substring(1)))
                    {
                        max = Convert.ToInt32(a.Substring(1));

                    }
                }
            }
            for (int i = 0; i < node.nexts.Count - 3; i++)
            {
                m1 = node.nexts[i].last.last.value;
                m2 = node.nexts[i + 1].last.last.value;
                m3 = node.nexts[i + 2].last.last.value;

                if (m1.moves == m2.moves && m1.moves == m3.moves)
                {
                    if (m1.numberOfStones == m2.numberOfStones && m1.numberOfStones == m3.numberOfStones)
                    {

                        if (m1.numberOfStones <= (Segments.StonesForWin / umn) && isFinish)
                        {
                            node1.nexts.Add(node.nexts[i]);
                            node1.nexts.Add(node.nexts[i + 1]);
                            node1.nexts.Add(node.nexts[i + 2]);
                            i = i + 2;
                        }
                        else if (m1.numberOfStones <= (Segments.StonesForWin - max) && umn == 0)
                        {
                            node1.nexts.Add(node.nexts[i]);
                            node1.nexts.Add(node.nexts[i + 1]);
                            node1.nexts.Add(node.nexts[i + 2]);
                            i = i + 2;
                        }
                    }
                }
            }
            return node1;
        }
        public Node Find(Node node)
        {
            foreach (Node a in node.nexts)
            {
                foreach (Node n in a.nexts)
                {
                    if (isWin(n))
                    {
                        if (nodeFinded == null)
                        {
                            nodeFinded = n;
                        }
                        else
                        {
                            nodeFinded.nexts.Add(n);
                        }
                    }
                }
            }
            return nodeFinded;
        }
        public bool isWin(Node nod)
        {
            bool flag = true;
            if (nod.nexts.Count != 0)
            {
                foreach (Node n in nod.nexts)
                {

                    nod = n;
                    flag = flag & isWin(n);
                }
            }
            else
            {
                if (!((nod.last.value.numberOfStones < Segments.StonesForWin && nod.value.numberOfStones >= Segments.StonesForWin)) && nod.value.numberOfMove == 3)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}

