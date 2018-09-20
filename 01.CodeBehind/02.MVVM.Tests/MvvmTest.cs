namespace _02.MVVM.Tests
{
    using System.Windows.Media;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MvvmTest
    {
        [TestMethod]
        public void InitialCounterStateShouldBeZero()
        {
            //ARRANGE
            var viewModel = new MainWindowViewModel();

            //ACT & ASSERT
            var expectedCounter = "0";
            Assert.AreEqual(expectedCounter, viewModel.CounterText);
        }

        [TestMethod]
        public void CounterShoulBeIncremenetedWhenButtonIsClicked()
        {
            //ARRANGE
            var viewModel = new MainWindowViewModel();

            //ACT
            viewModel.IncrementCommand.Execute(null);

            //ASSERT
            var expectedCounter = "1";
            Assert.AreEqual(expectedCounter, viewModel.CounterText);
        }

        [TestMethod]
        public void CounterBackgroundSholdBeYellowIfValueIsTenOrGreater()
        {
            //ARRANGE
            var viewModel = new MainWindowViewModel();

            //ACT
            for (int i = 0; i < 12; i++)
            {
                viewModel.IncrementCommand.Execute(null);
            }

            var expectedBackground = Brushes.Yellow;
            //ASSERT
            Assert.AreEqual(expectedBackground, viewModel.CounterBackground);
        }

        [TestMethod]
        public void CounterBackgroundSholdBeYellowIfValueIsTwentyOrGreater()
        {
            //ARRANGE
            var viewModel = new MainWindowViewModel();

            //ACT
            for (int i = 0; i < 22; i++)
            {
                viewModel.IncrementCommand.Execute(null);
            }

            var expectedBackground = Brushes.Red;
            //ASSERT
            Assert.AreEqual(expectedBackground, viewModel.CounterBackground);
        }
    }
}
