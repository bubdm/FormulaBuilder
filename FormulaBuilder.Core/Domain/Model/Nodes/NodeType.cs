using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBuilder.Core.Domain.Model.Nodes
{
    public enum NodeType
    {
        EMPTY = -1,
        OPERATOR,
        PARAMETER,
        FORMULA
    }
}
