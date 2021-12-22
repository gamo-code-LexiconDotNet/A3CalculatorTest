using Moq;
using Moq.AutoMock;
using System;
using Xunit;

namespace Calculator.Test
{
    public class MenuShould
    {
        private readonly Menu sut;
        private readonly AutoMocker mocker;

        public MenuShould()
        {
            mocker = new AutoMocker();
            sut = mocker.CreateInstance<Menu>();

            sut.Title = "Title";
            sut.Heading = "Heading";
            sut.AddItem("1", "One", () => new string(""));
        }

        [Fact]
        public void DisplayMenu()
        {
            // assemble
            string menu = 
                "Heading\n\n" +
                "Title\n" +
                "1) One.\n" +
                "0) Exit.\n" +
                "> ";

            mocker.GetMock<IConsoleWrapper>()
                .Setup(p => p.ReadLine())
                .Returns("0");

            // act
            sut.Run();

            // Assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write(menu), Times.Once);

        }

        [Fact]
        public void HoldAfterSelectionAnReturn()
        {
            // assemble
            string press = "\n\n\tPress any key to continue...";

            mocker.GetMock<IConsoleWrapper>()
                .SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("0");

            // act
            sut.Run();

            // Assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write(press), Times.Once);
        }

        [Fact]
        public void CatchInvalidMenuOption()
        {
            // assemble
            string menu =
               "Heading\n\n" +
               "Title\n" +
               "1) One.\n" +
               "0) Exit.\n" +
               "> ";

            mocker.GetMock<IConsoleWrapper>()
                .SetupSequence(p => p.ReadLine())
                .Returns("2")
                .Returns("x")
                .Returns("0");

            // act
            sut.Run();

            // Assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write(menu), Times.Exactly(3));
        }

        [Fact]
        public void CatchExceptions()
        {
            // assemble
            string message = "Custom Message";
            sut.AddItem("2", "Two", () => throw new DivideByZeroException(message));
            
            mocker.GetMock<IConsoleWrapper>()
                .SetupSequence(p => p.ReadLine())
                .Returns("2")
                .Returns("0");

            // act
            sut.Run();

            // Assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write(message), Times.Once);
        }
    }
}
