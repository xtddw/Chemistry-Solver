using BSmith.ChemistrySolver.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSmith.Chemistry.Tests
{
    [TestClass]
    public class StoichiometryTests
    {

        [TestCategory("Stoichmetric Table Creation"), TestMethod]
        public void Stoichiometry_CreateConversionTable()
        {
            ChemicalEquation.PTable = new PeriodicTable("..\\..\\..\\Chemistry-Solver\\data\\ElementData.csv");

            var stoichiometry = new Stoichiometry();

            var equation = new ChemicalEquation("1H_(2) + 1O_(2) --> 1H_(2)O_(1)");          
            equation.Balance();

            var canceledUnit = $"{equation.Reactants[0].Item2}{equation.Reactants[0].Item1.ToString()} moles";
            var remainingUnit = $"{equation.Reactants[1].Item2}{equation.Reactants[1].Item1.ToString()} moles";

            stoichiometry.CreateConversionTable(equation);

            stoichiometry.UnitConverter.InputValue = new ConversionValue(14d, new[] { canceledUnit }, null, equation.ToString());
            stoichiometry.UnitConverter.ConversionRatio = stoichiometry.UnitConverter.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);

            var actual = stoichiometry.UnitConverter.PerformConversion();
            var expected = new ConversionValue(7d, new[] { remainingUnit }, null, equation.ToString());

            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Stoichmetric Table Creation"), TestMethod]
        public void Stoichiometry_CreateConversionTable2()
        {
            ChemicalEquation.PTable = new PeriodicTable("..\\..\\..\\Chemistry-Solver\\data\\ElementData.csv");

            var stoichiometry = new Stoichiometry();

            var equation = new ChemicalEquation("1Al_(1) + 1Cl_(2) --> 1Al_(1)Cl_(3)");
            equation.Balance();

            var canceledUnit = $"{equation.Reactants[0].Item2}{equation.Reactants[0].Item1.ToString()} mass";
            var remainingUnit = $"{equation.Products[0].Item2}{equation.Products[0].Item1.ToString()} moles";

            stoichiometry.CreateConversionTable(equation);

            stoichiometry.UnitConverter.InputValue = new ConversionValue(1d, new[] { canceledUnit }, null, equation.ToString());
            stoichiometry.UnitConverter.ConversionRatio = stoichiometry.UnitConverter.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);     
            var actual = stoichiometry.UnitConverter.PerformConversion();

            canceledUnit = $"{equation.Reactants[1].Item2}{equation.Reactants[1].Item1.ToString()} mass";

            stoichiometry.UnitConverter.InputValue = new ConversionValue(1d, new[] { canceledUnit }, null, equation.ToString());
            stoichiometry.UnitConverter.ConversionRatio = stoichiometry.UnitConverter.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);
            var actual2 = stoichiometry.UnitConverter.PerformConversion();
        }
    }
}