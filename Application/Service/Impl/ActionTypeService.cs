using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using Persistence;

namespace Application.Service.Impl
{
    public class ActionTypeService : IActionTypeService
    {
        private ActionTypeRepository _actionTypeRepository;
        public ActionTypeService(ActionTypeRepository actionTypeRepository)
        {
            _actionTypeRepository = actionTypeRepository;
        }
        public HashSet<ActionType> GetAllActionTypes()
        {
            return _actionTypeRepository.GetAll().ToHashSet();
        }

        public void AddActionType(ActionType actionType)
        {
            _actionTypeRepository.Add(actionType);
        }

        public void RemoveActionType(ActionType actionType)
        {
            _actionTypeRepository.Remove(actionType);
        }
    }
}
