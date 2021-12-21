using Moq;
using Moq.AutoMock;
using System;
using Xunit;

namespace Calculator.Test
{
    public class MenuShould
    {
        private Menu sut;
        private AutoMocker mocker;

        public MenuShould()
        {
            mocker = new AutoMocker();
            sut = mocker.CreateInstance<Menu>();
        }

        [Fact]
        public void AddMenuItems()
        {
            // assemble
            sut.Title = "Title";
            sut.Heading = "Heading";
            //sut.AddItem("1", "One", Invoker);
            //sut.AddItem("1", "One", () => new string("ONE"));
            sut.AddItem("2", "Two", () => new string("TWO"));
            sut.AddItem("a", "a", () => new string("A"));

            mocker.GetMock<IConsoleWrapper>()
                .SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("0");

            // act
            sut.Run();

            // Assert
            mocker.GetMock<IConsoleWrapper>()
                .Verify(p => p.Write("ONE"), Times.Once);

        }
    }
}
