using System.Collections.Generic;

namespace Arcan.AtHome.API.Infrastructure
{
    public interface ICommand 
    {
        CanExecuteResult CanExecute();
        ActionResult Execute();
    }

    public interface ICommand<TArgs>
    {
        CanExecuteResult CanExecute(TArgs args);
        ActionResult Execute(TArgs args);
    }

    public interface ICommand<TArgs1, TArgs2> 
    {
        CanExecuteResult CanExecute(TArgs1 args1, TArgs2 args2);
        ActionResult Execute(TArgs1 args1, TArgs2 args2);
    }

    public interface ICommand<TArgs1, TArgs2, TArgs3> 
    {
        CanExecuteResult CanExecute(TArgs1 args1, TArgs2 args2, TArgs3 args3);
        ActionResult Execute(TArgs1 args1, TArgs2 args2, TArgs3 args3);
    }
    
    public interface ICommandWithResult<TResult>
    {
        CanExecuteResult CanExecute();
        ActionResult<TResult> Execute();
    }

    public interface ICommandWithResult<TArgs, TResult>
    {
        CanExecuteResult CanExecute(TArgs args);
        ActionResult<TResult> Execute(TArgs args);
    }

    public interface ICommandWithResult<TArgs1, TArgs2, TResult>
    {
        CanExecuteResult CanExecute(TArgs1 args1, TArgs2 args2);
        ActionResult<TResult> Execute(TArgs1 args1, TArgs2 args2);
    }

    public interface ICommandWithResult<TArgs1, TArgs2, TArgs3, TResult>
    {
        CanExecuteResult CanExecute(TArgs1 args1, TArgs2 args2, TArgs3 args3);
        ActionResult<TResult> Execute(TArgs1 args1, TArgs2 args2, TArgs3 args3);
    }
        
    public interface IQuery
    {

    }

    public interface IQuery<TResult> : IQuery
    {
        TResult Query();
    }

    public interface IQuery<TArgs, TResult> : IQuery
    {
        TResult Query(TArgs args);
    }

    public interface IQuery<TArgs1, TArgs2, TResult> : IQuery
    {
        TResult Query(TArgs1 args1, TArgs2 args2);
    }

    public interface IQuery<TArgs1, TArgs2, TArgs3, TResult> : IQuery
    {
        TResult Query(TArgs1 args1, TArgs2 args2, TArgs3 args3);
    }

    public interface ISearchQuery<TEntity> : IQuery<string, IEnumerable<TEntity>>
    {

    }
}