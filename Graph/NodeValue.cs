using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class NodeValue
    {
        public String moves;
        public int numberOfMove;
        public int numberOfStones;
        public int startNumberOfStones;
        public NodeValue()
        {
            numberOfMove = 0;
        }
        public void Move(string a)
        {
            if (a.Contains('+'))
            {
                moves = moves + a;
                numberOfMove++;
                numberOfStones += Convert.ToInt32(a.Substring(1));
            }
            else if (a.Contains('*'))
            {
                moves = moves + a;
                numberOfMove++;
                numberOfStones *= Convert.ToInt32(a.Substring(1));
            }
        }

        public NodeValue Copy()
        {
            NodeValue newNodeValue = new NodeValue();
            newNodeValue.moves = moves;
            newNodeValue.numberOfMove = numberOfMove;
            newNodeValue.numberOfStones = numberOfStones;
            newNodeValue.startNumberOfStones = startNumberOfStones;
            return newNodeValue;
        }
    }
}
