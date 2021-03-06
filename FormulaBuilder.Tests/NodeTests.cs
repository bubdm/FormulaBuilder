using FormulaBuilder.Core.Domain.Model;
using FormulaBuilder.Core.Domain.Model.Nodes;
using FormulaBuilder.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBuilder.Tests
{
    [TestFixture]
    [Category("unit")]
    [Category("domain model")]
    class NodeTests : BaseUnitTest
    {
        [Test]
        public void Can_Create_Node()
        {
            var childEntity = new NodeEntity(
                new NodeTypeEntity(1, "parameter"), 
                "test", 
                0,
                new List<NodeEntity>()
            );
            var parentEntity = new NodeEntity(
                new NodeTypeEntity(1, "operation"),
                "+",
                0,
                new List<NodeEntity>() { childEntity });
            var childNode = BaseNode.Create(childEntity);
            var parentNode = BaseNode.Create(parentEntity);
            var expectedNodeType = typeof(AdditionNode);

            Assert.AreEqual(expectedNodeType, parentNode.GetType());
            Assert.AreEqual(parentEntity.Value, parentNode.Value);
            Assert.AreEqual(parentEntity.Children.Count(), parentNode.Children.Count());
        }

        [Test]
        public void Can_Gather_Parameters()
        {
            var tripleSumFormula = GetTripleSumFormula();
            var parameters = tripleSumFormula.RootNode.GatherParameters(tripleSumFormula);
            Assert.AreEqual(3, parameters.Count);
            Assert.That(parameters.Contains("Param1"));
            Assert.That(parameters.Contains("Param2"));
            Assert.That(parameters.Contains("Param3"));

        }
    }
}
