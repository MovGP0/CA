﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface INodeDecorator<out T>
        where T : INode
    {
        void Replace(INode newNode);
        T Node { get;  }
        INode InitialParent { get;  }
        int InitialIndex { get;  }
        IModInput Instance { get;  }
    }
}