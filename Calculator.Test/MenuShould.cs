using Moq;
using System;
using Xunit;

namespace Calculator.Test
{
    public class MenuShould : IDisposable
    {
        private Menu _menu;
        private Mock<IConsoleWrapper> _mockConsoleWrapper;

        public MenuShould()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
        }

        public void Dispose()
        {
            _mockConsoleWrapper.Reset();
        }

        [Theory]
        [MemberData(nameof(InternalMenuTestData.MenuText), MemberType = typeof(InternalMenuTestData))]
        public void PrintTheMenu(string menuText)
        {
            // assemble
            _mockConsoleWrapper
                .Setup(t => t.ReadLine())
                .Returns("0");

            // act
            _menu = new Menu(_mockConsoleWrapper.Object);
            _menu.Run();

            // assert
            _mockConsoleWrapper.Verify(t => t.Write(menuText), Times.Once());
        }

        [Theory]
        [MemberData(nameof(InternalMenuTestData.MenuText), MemberType = typeof(InternalMenuTestData))]
        public void ReprintMenuOnIncorrectOption(string menuText)
        {
            // assemble
            _mockConsoleWrapper
                .SetupSequence(t => t.ReadLine())
                .Returns("q")
                .Returns("0");


            // act
            _menu = new Menu(_mockConsoleWrapper.Object);
            _menu.Run();

            // assert
            _mockConsoleWrapper.Verify(t => t.Write(menuText), Times.Exactly(2));
        }

        [Theory]
        [MemberData(nameof(InternalMenuTestData.Options), MemberType = typeof(InternalMenuTestData))]
        public void UseMenuOptions(string menuOption, string a, string b, string expected)
        {
            // assemble
            _mockConsoleWrapper
                .SetupSequence(t => t.ReadLine())
                .Returns(menuOption)
                .Returns(a)
                .Returns(b)
                .Returns("0");

            // act
            _menu = new Menu(_mockConsoleWrapper.Object);
            _menu.Run();

            // assert
            _mockConsoleWrapper.Verify(t => t.WriteLine($"=> {expected}"), Times.Once());
        }

        [Theory]
        [MemberData(nameof(InternalMenuTestData.OptionsDivideByZero), MemberType = typeof(InternalMenuTestData))]
        public void NotDivideByZero(string menuOption, string a, string b, string expected)
        {
            // assemble
            _mockConsoleWrapper
                .SetupSequence(t => t.ReadLine())
                .Returns(menuOption)
                .Returns(a)
                .Returns(b)
                .Returns("0");

            // act
            _menu = new Menu(_mockConsoleWrapper.Object);
            _menu.Run();

            // assert
            _mockConsoleWrapper.Verify(t => t.WriteLine(expected), Times.Once());
        }

        [Fact]
        public void OnlyReadNumbers()
        {
            // assemble
            string expecteda = "a must be a number\n> ";
            string expectedb = "b must be a number\n> ";

            _mockConsoleWrapper
                .SetupSequence(t => t.ReadLine())
                .Returns("1")
                .Returns("not number")
                .Returns("1")
                .Returns("not number")
                .Returns("1")
                .Returns("0");

            // act
            _menu = new Menu(_mockConsoleWrapper.Object);
            _menu.Run();

            // assert
            _mockConsoleWrapper.Verify(t => t.Write(expecteda), Times.Once());
            _mockConsoleWrapper.Verify(t => t.Write(expectedb), Times.Once());
        }



    }
}
