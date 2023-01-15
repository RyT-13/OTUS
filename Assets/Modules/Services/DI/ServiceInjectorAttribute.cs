using System;
using JetBrains.Annotations;

namespace Modules.Services.DI
{
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public sealed class ServiceInjectAttribute : Attribute
    {
    }
}
