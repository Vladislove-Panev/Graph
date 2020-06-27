using NUnit.Framework;
using Graph;
using System;
using System.Collections.Generic;

namespace GraphTests
{
    public class Tests
    {      
        [TestCase("+1", "+2", "*3", 42, ExpectedResult = "11,12")]
        [TestCase("+4", "+8", "*10", 126, ExpectedResult = "1,2,3,4,5,6,7,8")]
        [TestCase("+0", "+0", "*9", 27, ExpectedResult = "3")]
        public static string GraphTests(string a, string b, string c, int d)
        {
            Segments.Actions = new List<string>();
            Segments.Actions.Add(a);
            Segments.Actions.Add(b);
            Segments.Actions.Add(c);
            Segments.StonesForWin = d;
            Node node = new Node();
            node.Create();
            Node newNode = node.FindThen(node.FindResult(node));
            string actual = "";
            foreach (Node n in newNode.nexts)
            {
                if (!(actual.Contains(Convert.ToString(n.value.startNumberOfStones))))
                { actual = actual + n.value.startNumberOfStones + ","; }

            }
            actual = actual.Remove(actual.Length - 1);
            return actual;
        }
    }
}