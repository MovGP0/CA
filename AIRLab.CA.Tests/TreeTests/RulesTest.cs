// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Globalization;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Tests.TreeTests
{
    public class TestOp : Node
    {
        static int _currentNumber;
        private readonly int _number;

        public TestOp(params INode[] children)
            : base(children)
        {
            _number = _currentNumber;
            _currentNumber++;
        }

        public override string ToString()
        {
            var result = ToLetter().ToString(CultureInfo.InvariantCulture);
            if (!this.HasChildren()) return result;

            result += "(";
            for (var i = 0; i < Children.Length; i++)
                result += (i == 0 ? "" : ",") + Children[i];
            result += ")";
            return result;
        }

        private char ToLetter()
        {
            return ((char)('a' + _number));
        }

        public override Expression BuildExpression()
        {
            throw new NotImplementedException();
        }
    }
}
