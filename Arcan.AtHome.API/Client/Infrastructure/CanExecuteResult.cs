using System.Collections.Generic;

namespace Arcan.AtHome.API.Infrastructure
{
    public class CanExecuteResult : ActionResult
    {
        public CanExecuteResult(bool canExecute)
            :base(canExecute)
        {
            Succeeded = canExecute;
        }

        public CanExecuteResult(bool canExecute, params Message[] message)
            : base(canExecute, message)
        {
        }

        public CanExecuteResult(bool canExecute, IEnumerable<Message> message)
            : base(canExecute, message)
        {
        }

        public bool CanExecute {
            get { return this.Succeeded; }}
 
    }
    public class CanExecuteResult<T> : ActionResult<T>
    {
        public CanExecuteResult(bool canExecute, T entity)
            : base(canExecute, entity)
        {
            Succeeded = canExecute;
        }
        public CanExecuteResult(bool succeeded, T entity, IEnumerable<Message> messages)
            : base(succeeded, entity, messages)
        {
            Succeeded = succeeded;
        }

        public CanExecuteResult(bool succeeded, T entity, params Message[] messages)
            : base(succeeded, entity, messages)
        {
            Succeeded = succeeded;
        }

        public bool CanExecute
        {
            get { return this.Succeeded; }
        }
    }
}   