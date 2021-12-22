using Moq;
using Xunit;
using Moq.AutoMock;

namespace Calculator.Test
{
    public class HandleOperationsShould
    {
        private readonly HandleOperations sut;
        private readonly AutoMocker mocker;

        public HandleOperationsShould()
        {
            mocker = new AutoMocker();
            sut = mocker.CreateInstance<HandleOperations>();

            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(2))
                .Returns(new double[] { 1, 2 });
            
        }

        [Fact]
        public void AddMultiple()
        {
            // assemble
            mocker.GetMock<IHandleInput>().Reset();
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(new double[] { 1, 2, 3, 4 });
            mocker.GetMock<IOperations>()
                .Setup(p => p.Add(new double[] { 1, 2, 3, 4 }))
                .Returns(1);

            // act
            sut.Add();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Add()
        {
            // assemble
            mocker.GetMock<IHandleInput>().Reset();
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(new double[] { 1, 2});
            mocker.GetMock<IOperations>()
                .Setup(p => p.Add(1, 2))
                .Returns(1);

            // act
            sut.Add();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void SubtractMultiple()
        {
            // assemble
            mocker.GetMock<IHandleInput>().Reset();
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(new double[] { 1, 2, 3, 4 });
            mocker.GetMock<IOperations>()
                .Setup(p => p.Subtract(new double[] { 1, 2, 3, 4 }))
                .Returns(1);

            // act
            sut.Subtract();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Subtract()
        {
            // assemble
            mocker.GetMock<IHandleInput>().Reset();
            mocker.GetMock<IHandleInput>()
                .Setup(p => p.ReadNumbers<double>(-1))
                .Returns(new double[] { 1, 2 });
            mocker.GetMock<IOperations>()
                .Setup(p => p.Subtract(1, 2))
                .Returns(1);

            // act
            sut.Subtract();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Divide()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Divide(1, 2))
                .Returns(1);

            // act
            sut.Divide();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Multiply()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Multiply(1, 2))
                .Returns(1);

            // act
            sut.Multiply();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Modulo()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Modulo(1, 2))
                .Returns(1);

            // act
            sut.Modulo();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Power()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Power(1, 2))
                .Returns(1);

            // act
            sut.Power();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Root()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Root(1, 2))
                .Returns(1);

            // act
            sut.Root();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }

        [Fact]
        public void Log()
        {
            // assemble
            mocker.GetMock<IOperations>()
                .Setup(p => p.Log(1, 2))
                .Returns(1);

            // act
            sut.Log();

            // assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("=> 1"), Times.Once);
        }
    }
}
