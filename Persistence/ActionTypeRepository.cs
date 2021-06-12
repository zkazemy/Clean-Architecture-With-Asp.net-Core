using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Enums;

namespace Persistence
{
   public class ActionTypeRepository : ICrudRepository<ActionType, ActionType>
    {
        private HashSet<ActionType> _actionTypes = new HashSet<ActionType>();
        public ActionTypeRepository()
        {
            _actionTypes.Add(ActionType.Comment);
            _actionTypes.Add(ActionType.EnterTheRoom);
            _actionTypes.Add(ActionType.LeaveTheRoom);
            _actionTypes.Add(ActionType.HighFive);
        }
        
        public ICollection<ActionType> GetAll()
        {
            return _actionTypes;
        }

        public void Add(ActionType actionType)
        {
            _actionTypes.Add(actionType);
        }
        
        public void Remove(ActionType actionType)
        {
            _actionTypes.Remove(actionType);
        }
    }
}
