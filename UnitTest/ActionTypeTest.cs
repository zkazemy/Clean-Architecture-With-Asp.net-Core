using Domain.Enums;
using NUnit.Framework;
using Persistence;

namespace UnitTest
{
    [TestFixture]
    public class ActionTypeTest
    {
        private ActionTypeRepository _actionTypeRepository;

        [SetUp]
        protected void SetUp()
        {
            _actionTypeRepository = new ActionTypeRepository();
        }

        [Test]
        public void GetAllActionType()
        {
            int currentCount = _actionTypeRepository.GetAll().Count;
            _actionTypeRepository.Add(ActionType.Test);
            _actionTypeRepository.Add(ActionType.Test2);
            Assert.AreEqual(_actionTypeRepository.GetAll().Count, currentCount + 2);
        }

        [Test]
        public void AddActionType()
        {
            _actionTypeRepository.Add(ActionType.Test);
            Assert.IsTrue(_actionTypeRepository.GetAll().Contains(ActionType.Test));
        }

        [Test]
        public void RemoveActionType()
        {
            _actionTypeRepository.Add(ActionType.Test);
            _actionTypeRepository.Remove(ActionType.Test);
            Assert.IsFalse(_actionTypeRepository.GetAll().Contains(ActionType.Test));
        }

    }
}
