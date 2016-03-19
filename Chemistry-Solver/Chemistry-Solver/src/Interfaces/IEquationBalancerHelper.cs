using BSmith.Chemistry;
using System.Collections.Generic;
using System;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface containing the equation balancer helper functions.
    /// </summary>
    public interface IEquationBalancerHelper
    {
        void CondenseMolecules(List<Tuple<Molecule, int>> molecules);
        string SimplifyEquationFormat(string equation);
        void SetCoefficientTextFormat(string coefficient);
        void SetDefaultTextFormat(string text);
        void SetMoleculeTextFormat(Tuple<Molecule, int> molecule);
        void SetSubscriptTextFormat(string subscript);
    }
}
