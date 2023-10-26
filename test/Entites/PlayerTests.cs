using System.Numerics;
using client.Entites;
using client.Entites.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.Entites
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Constructor_SetsInitialPosition()
        {
            Vector2 initPos = new Vector2(0, 0);

            IPlayer player = PlayerFactory.init();

            Assert.AreEqual(initPos, player.Position);

        }
        [TestMethod]
        public void Constructor_SetX15Y10()
        {
            Vector2 initPos = new Vector2(15, 10);

            IPlayer player = PlayerFactory.X15Y10();

            Assert.AreEqual(initPos, player.Position);

        }
        [TestMethod]
        public void Constructor_Own()
        {
            Vector2 initPos = new Vector2(25, 12);

            IPlayer player = PlayerFactory.OwnPosition(initPos);

            Assert.AreEqual(initPos, player.Position);

        }
        [TestMethod]
        public void MoveVectorZero()
        {
            Vector2 moveZero = new Vector2(0, 0);
            Vector2 initPos = new Vector2(25, 12);
            IPlayer player = PlayerFactory.OwnPosition(initPos);

            player.Move(moveZero);
            Assert.AreEqual(initPos, player.Position);
        }
        [TestMethod]
        public void MoveSimple()
        {
            Vector2 move = new Vector2(1, 0);
            Vector2 initPos = new Vector2(25, 12);
            IPlayer player = PlayerFactory.OwnPosition(initPos);

            player.Move(move);
            Vector2 result = move + initPos;
            Assert.AreEqual(player.Position, result);
        }

        [TestMethod]
        public void MoveComplexNotNormalized()
        {
            Vector2 move = new Vector2(1, 1);
            Vector2 initPos = new Vector2(25, 12);
            IPlayer player = PlayerFactory.OwnPosition(initPos);

            Vector2 result = initPos + move;
            player.Move(move);
            Assert.AreNotEqual(player.Position, result);
        }
        [TestMethod]
        public void MoveComplex()
        {
            Vector2 move = new Vector2(1, 1);
            Vector2 initPos = new Vector2(25, 12);
            IPlayer player = PlayerFactory.OwnPosition(initPos);

            Vector2 normalizedMove = Vector2.Normalize(move);
            Vector2 result = initPos + normalizedMove;
            player.Move(move);
            Assert.AreEqual(player.Position, result);
        }
    }
}
