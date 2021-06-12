using System.Collections.Generic;
using Domain.Enums;

namespace Application.Service
{
    public interface IActionTypeService
    {
        public HashSet<ActionType> GetAllActionTypes();
        public void AddActionType(ActionType actionType);
        public void RemoveActionType(ActionType actionType);
    }
}
