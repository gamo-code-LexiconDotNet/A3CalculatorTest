using Moq;
using Xunit;
using Moq.AutoMock;

namespace Calculator.Test
{
    public class HandleOperationsShould
    {
        private HandleOperations sut;
        private AutoMocker mocker;

        public HandleOperationsShould()
        {
            mocker = new AutoMocker();
            sut = mocker.CreateInstance<HandleOperations>();
        }

        [Theory]
        [InlineData(new double[] { -3,1,2,3,4 }, 7)]
        [InlineData(new double[] { -3 }, -3)]
        public void AddMultiple(double[] input, double expected)
        {
            // assemble
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(input);
            mocker.GetMock<IOperations>()
                .Setup(p => p.Add(input))
                .Returns(expected);

            // act
            sut.Add();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> " + expected.ToString()), Times.Once);
        }

        [Theory]
        [InlineData(new double[] { -3, 1 }, -2)]
        [InlineData(new double[] { -3, 4 }, 1)]
        public void Add(double[] input, double expected)
        {
            // assemble
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(input);
            mocker.GetMock<IOperations>()
                .Setup(p => p.Add(input[0], input[1]))
                .Returns(expected);

            // act
            sut.Add();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> " + expected.ToString()), Times.Once);
        }

        [Theory]
        [InlineData(new double[] { -3, 1, 1.5, -5 }, -0.5)]
        [InlineData(new double[] { -3, 4.0, 1 }, -8)]
        [InlineData(new double[] { -4, 3, -1.0 }, -6)]
        [InlineData(new double[] { -3 }, -3)]
        public void SubtractMultiple(double[] input, double expected)
        {
            // assemble
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(input);
            mocker.GetMock<IOperations>()
                .Setup(p => p.Subtract(input))
                .Returns(expected);

            // act
            sut.Subtract();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> " + expected.ToString()), Times.Once);
        }

        [Theory]
        [InlineData(new double[] { 1.5, 1.4 }, 0.1)]
        [InlineData(new double[] { -3, 4 }, -7)]
        [InlineData(new double[] { -4, 3 }, -7)]
        public void Subtract(double[] input, double expected)
        {
            // assemble
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(input);
            mocker.GetMock<IOperations>()
                .Setup(p => p.Subtract(input[0], input[1]))
                .Returns(expected);

            // act
            sut.Subtract();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> " + expected.ToString()), Times.Once);
        }

        [Theory]
        [InlineData(new double[] { 3, 4 }, 0.75)]
        [InlineData(new double[] { -3, 4 }, -0.75)]
        [InlineData(new double[] { -4, 3 }, -1.3333)]
        public void Divide(double[] input, double expected)
        {
            // assemble
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(input);
            mocker.GetMock<IOperations>()
                .Setup(p => p.Subtract(input[0], input[1]))
                .Returns(expected);

            // act
            sut.Subtract();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> " + expected.ToString()), Times.Once);
        }

        [Fact]
        public void NotDivideByZero()
        {
            //// assemble
            //_mocker.GetMock<IHandleInput>()
            //    .Setup(p => p.ReadNumbers<double>(-1))
            //    .Returns(input);
            //_mocker.GetMock<IOperations>()
            //    .Setup(p => p.Divide(It.IsAny<double>, It.Is<double>))
            //    .Returns(expected);

            //// act
            //_sut.Subtract();

            //// assert
            //_mocker.GetMock<IConsoleWrapper>()
            //    .Verify(p => p.Write(expected.ToString()), Times.Once);
        }

    }
}
