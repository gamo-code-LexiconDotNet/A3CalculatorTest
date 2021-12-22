using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Moq.AutoMock;

namespace Calculator.Test
{
    public class HandleInputShould
    {
        private readonly HandleInput sut;
        private readonly AutoMocker mocker;

        public HandleInputShould()
        {
            mocker = new AutoMocker();
            sut = mocker.CreateInstance<HandleInput>();
        }

        [Theory]
        [InlineData(4, new String[] { "0 0.1 23 -5.5", "", ""}, new double[] { 0, 0.1, 23, -5.5 }, "s", false)]
        [InlineData(3, new String[] { "0.1aa 23, - 5.5", "", "" }, new double[] { 0.1, 23, 5.5 }, "s", false)]
        [InlineData(5, new String[] { "0.1aa 23, - 5.5 23, 4.4, -0.001, -a", "", "" }, new double[] { 0.1, 23, 5.5, 23, 4.4 }, "s", false)]
        [InlineData(5, new String[] { "1 2 3 4", "a 5.5 5.6", "6" }, new double[] { 1, 2, 3, 4, 5.5 }, "s", false)]
        [InlineData(2, new String[] { "1", "-2", "6" }, new double[] { 1, -2 }, "s", false)]
        [InlineData(10, new String[] { "1,", "0.1 ,-2; 12", "6" }, new double[] { 1, 0.1, -2 }, "s", false)]
        [InlineData(-1, new String[] { "1,", "0.1 ,-2 12", "6;" }, new double[] { 1, 0.1, -2, 12, 6 }, "s", true)]
        [InlineData(1, new String[] { ",aa123,", "0.1 ,-2; 12", "6" }, new double[] { 123 }, "", false)]
        public void ReadInput(int incount, string[] input, double[] expected, string pluralized, bool multi)
        {
            // assemble
            mocker.GetMock<IConsoleWrapper>()
                .SetupSequence(t => t.ReadLine())
                .Returns(input[0])
                .Returns(input[1])
                .Returns(input[2]);
            string inputs = incount > 0 ? " " + incount.ToString() : "";
            string multiInput = multi ? " (end with \";\")" : "";
            
            // act
            double[] result = sut.ReadNumbers<double>(incount);

            // assert
            mocker.GetMock<IConsoleWrapper>().Verify(
                t => t.Write("Input{0} number{1}{2}: ", inputs, pluralized, multiInput),
                Times.AtLeastOnce());
            Assert.Equal(expected, result);
        }
    }
}
