using Puffix.Mvvm.Models;

namespace Puffix.Mvvm.ViewModels;

/// <summary>
/// Base contract for view-models.
/// </summary>
public interface IViewModel
{ }

/// <summary>
/// Base contract for view-models.
/// </summary>
public interface IViewModel<ModelT>
    where ModelT : IModel
{
    ModelT Model { get; }
}